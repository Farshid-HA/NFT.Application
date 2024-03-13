namespace NFT.Domain.Dto.Transaction
{
    public class InputDto
    {
        public string? Address { get; set; }
        public List<AmountDto>? Amount { get; set; }
        public string? TxHash { get; set; }
        public int OutputIndex { get; set; }
        public string? DataHash { get; set; }
        public string? InlineDtum { get; set; }
        public string? ReferenceScriptHash { get; set; }
        public bool Collateral { get; set; }
        public bool Reference { get; set; }

    }
}
