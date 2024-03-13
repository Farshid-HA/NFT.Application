namespace NFT.Domain.Dto.Assets
{
    public class AssetStream
    {
        public string? FileName { get; set; }
        public Stream? Stream { get; set; }

        public AssetStream(string? fileName, Stream? stream)
        {
            FileName = fileName;
            Stream = stream;
        }
    }
}
