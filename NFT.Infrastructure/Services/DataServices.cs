using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NFT.Domain.Dto.Transaction;
using NFT.Domain.Services;
using System.Reflection;
using System.Text.Json;

namespace NFT.Infrastructure.Services
{
    public class DataServices : IDataServices
    {
        private readonly ILogger<IDataServices> logger;

        public DataServices(ILogger<IDataServices> logger)
        {
            this.logger = logger;
        }

        public void WriteTransaction(string hash, TransactionDto transaction)
        {
            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (dirPath is null) return;
            dirPath = Path.Combine(dirPath, "Transaction", hash);
            Directory.CreateDirectory(dirPath);
            var filePath = Path.Combine(dirPath, $"{hash}.json");
            File.WriteAllText(filePath, JsonSerializer.Serialize(transaction));
            logger.Log(LogLevel.Information, string.Format(Res.Log.WriteTransaction, hash));
        }


        public void WriteImages(string hash, Stream stream, string fileName)
        {

            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (dirPath is null) return;
            dirPath = Path.Combine(dirPath, "Transaction", hash);
            Directory.CreateDirectory(dirPath);
            var filePath = Path.Combine(dirPath, $"{fileName}.png");

            using (FileStream fileStream = File.Create(filePath))
            {
                stream.CopyTo(fileStream);
            }
            logger.Log(LogLevel.Information, string.Format(Res.Log.WriteImage, fileName));
        }

    }
}
