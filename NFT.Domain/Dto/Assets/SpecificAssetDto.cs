using System.Text.Json.Serialization;

namespace NFT.Domain.Dto.Assets
{
    public class SpecificAssetDto
    {
        [JsonPropertyName("asset")]
        public string? Asset { get; set; }
        [JsonPropertyName("policy_id")]
        public string? Policy_Id { get; set; }
        [JsonPropertyName("asset_name")]
        public string? AssetName { get; set; }
        [JsonPropertyName("fingerprint")]
        public string? Fingerprint { get; set; }
        [JsonPropertyName("quantity")]
        public string? Quantity { get; set; }
        [JsonPropertyName("initial_mint_tx_hash")]
        public string? InitialMintTxHash { get; set; }
        [JsonPropertyName("mint_or_burn_count")]
        public int MintOrBurnCount { get; set; }
        [JsonPropertyName("onchain_metadata")]
        public OnChainMetaData? OnchainMetaData { get; set; }
        [JsonPropertyName("onchain_metadata_standard")]
        public string? OnChainMetaDataStandard { get; set; }
        [JsonPropertyName("onchain_metadata_extra")]
        public string? OnChainMetaDataExtra { get; set; }
        [JsonPropertyName("metadata")]
        public MetaData? MetaData { get; set; }
    }
}
