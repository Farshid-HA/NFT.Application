using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NFT.Domain.Dto;
using NFT.Domain.Dto.Assets;
using NFT.Domain.Dto.Transaction;
using NFT.Domain.Enum;
using NFT.Domain.Services;
using System;
using System.Text.Json;

namespace NFT.Infrastructure.Services
{
    public class NFTServices : INFTServices
    {
        private readonly IAPIServices apiServices;
        private readonly IConfiguration configuration;
        private readonly ILogger<INFTServices> logger;

        private static string BuildTransactionUrl(string hash) => $"/txs/{hash}/utxos";
        private static string BuildAssetUrl(string assetPath) => $"/assets/{assetPath}";

        public NFTServices(IAPIServices apiServices, IConfiguration configuration, ILogger<INFTServices> logger)
        {
            this.apiServices = apiServices;
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<ResultDto<TransactionDto>> GetTransaction(string hash)
        {

            if (string.IsNullOrEmpty(hash)) return new ResultDto<TransactionDto>(new(), MessageCodes.BadRequest);
            var result = await apiServices.GetData<TransactionDto>(configuration["ProjectSettings:BaseUrl"]!, BuildTransactionUrl(hash), configuration["ProjectSettings:ProjectId"]!);

            if (result is null) return new();

            logger.Log(LogLevel.Information, Res.Log.GetTransaction);

            return new(result);
        }

        public async Task<ResultDto<List<SpecificAssetDto>>> GetAssets(TransactionDto transactions)
        {
            if (transactions is null) return new(new(), MessageCodes.BadRequest);
            var specificAsset = new List<SpecificAssetDto>();

            var assetPathList = (from item in transactions.Inputs
                                 from units in item.Amount!
                                 where Convert.ToDouble(units.Quantity) == 1 && units.Unit != "lovelace"
                                 select new AssetPathDto { Name = units.Unit }).ToList();

            assetPathList.AddRange(from amount in transactions.Outputs
                                   from units in amount.Amount!
                                   where Convert.ToDouble(units.Quantity) == 1 && units.Unit != "lovelace"
                                   select new AssetPathDto { Name = units.Unit });

            foreach (var assetPath in assetPathList)
            {
                specificAsset.Add(await apiServices.GetData<SpecificAssetDto>(configuration["ProjectSettings:BaseUrl"]!, BuildAssetUrl(assetPath.Name!), configuration["ProjectSettings:ProjectId"]!));
            }

            logger.Log(LogLevel.Information, Res.Log.GetAssets);

            return new(specificAsset);
        }

        public async Task<ResultDto<List<AssetStream>>> GetImageStreams(List<SpecificAssetDto> assets)
        {
            var streams = new List<AssetStream>();
            foreach (var item in assets)
            {
                streams.Add(new AssetStream(item.OnchainMetaData!.Name, await apiServices.DownloadIPFSNFT(item.OnchainMetaData!.Image!.Replace("ipfs://", string.Empty))));
            }
            logger.Log(LogLevel.Information, Res.Log.GetImages);
            return new(streams);
        }

    }
}
