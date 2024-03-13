using Microsoft.Extensions.DependencyInjection;
using NFT.Domain.Services;

namespace NFT.Application
{
    public static class Transaction
    {
        public static readonly ServiceProvider serviceProvider = BootStrapper.BootStrapper.CreateServices();
        public static readonly INFTServices nftServices = serviceProvider.GetService<INFTServices>()!;
        public static readonly IDataServices dataServices = serviceProvider.GetService<IDataServices>()!;

        public async static Task AskAndCallTransaction()
        {
            Console.WriteLine(Res.Messages.Insert);
            string hash = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(hash))
            {
                Console.WriteLine(Res.Messages.Empty);
                return;
            }


            var transaction = await nftServices!.GetTransaction(hash);

            dataServices.WriteTransaction(hash, transaction.Data);

            var assets = await nftServices.GetAssets(transaction.Data);

            var streams = await nftServices.GetImageStreams(assets.Data);

            foreach (var item in streams.Data)
            {
                dataServices.WriteImages(hash, item.Stream!, item.FileName!);
            }

        }

    }
}
