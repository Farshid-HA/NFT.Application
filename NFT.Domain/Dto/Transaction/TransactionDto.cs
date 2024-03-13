namespace NFT.Domain.Dto.Transaction
{
    public class TransactionDto
    {
        public string? Hash { get; set; }
        public List<InputDto>? Inputs { get; set; }
        public List<OutPutDto>? Outputs { get; set; }
    }
}
