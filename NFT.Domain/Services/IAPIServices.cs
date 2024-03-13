namespace NFT.Domain.Services
{
    public interface IAPIServices
    {
        Task<T> GetData<T>(string baseUrl, string url, string projectId);
        Task<Stream> DownloadIPFSNFT(string ipfsCid);
    }
}
