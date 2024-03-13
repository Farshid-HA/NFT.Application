using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using NFT.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NFT.Infrastructure.Services
{
    public class APIServices : IAPIServices
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<IAPIServices> logger;
        public APIServices(IConfiguration configuration, ILogger<IAPIServices> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<Stream> DownloadIPFSNFT(string ipfsCid)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string ipfsUrl = $"{configuration["ProjectSettings:Gateway"]!}{ipfsCid}";
                    HttpResponseMessage response = await client.GetAsync(ipfsUrl);


                    Stream contentStream = await response.Content.ReadAsStreamAsync();
                    return contentStream;

                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
            }

            return default!;
        }

        public async Task<T> GetData<T>(string baseUrl, string url, string projectId)
        {
            try
            {
                var client = new HttpClient(
                    new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true,
                    }
                    , false);
                T result = default!;

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("project_id", projectId);
                client.Timeout = TimeSpan.FromSeconds(300);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + url);
                if (!response.IsSuccessStatusCode)
                {
                    logger.Log(LogLevel.Error, Res.Log.APIResultError);
                    return result;
                }
                var option = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

                };
                result = JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), option)!;
                return result;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
            }

            return default!;
        }



    }
}
