namespace Prestadito.Wallet.Application.Dto.Deposit.UpdateDeposit
{
    public class UpdateDepositRequest
    {
        public string StrId { get; set; } = string.Empty;
        public decimal DblDepositAmount { get; set; }
        public decimal DblFinancialTransactionTax { get; set; }
        public string StrUserId { get; set; } = string.Empty;
        public string StrDepositNumber { get; set; } = string.Empty;
        public string StrVerificationNumber { get; set; } = string.Empty;
        public DateTime DteDeposit { get; set; }
        public string StrBankCode { get; set; } = string.Empty;
        public bool BlnActive { get; set; }
    }
}
