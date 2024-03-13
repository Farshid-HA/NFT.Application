using NFT.Domain.Dto;
using NFT.Domain.Dto.Assets;
using NFT.Domain.Dto.Transaction;

namespace NFT.Domain.Services
{
    public interface INFTServices
    {
        Task<ResultDto<TransactionDto>> GetTransaction(string hash);
        Task<ResultDto<List<SpecificAssetDto>>> GetAssets(TransactionDto assetsPath);
        Task<ResultDto<List<AssetStream>>>GetImageStreams(List<SpecificAssetDto> assets);
    }
}
