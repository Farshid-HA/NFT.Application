using NFT.Domain.Dto.Transaction;

namespace NFT.Domain.Services
{
    public interface IDataServices
    {
        void WriteTransaction(string hash, TransactionDto transaction);
        void WriteImages(string hash, Stream stream,string fileName);
    }
}
