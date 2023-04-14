using MongoDB.Bson.Serialization.Attributes;
using Prestadito.Wallet.Domain.MainModule.Core;

namespace Prestadito.Wallet.Domain.MainModule.Entities
{
    [BsonIgnoreExtraElements]
    public class DepositEntity : AuditEntity
    {
        [BsonElement("dblDepositAmount")]
        public decimal DblDepositAmount { get; set; }
        [BsonElement("dblFinancialTransactionTax")]
        public decimal DblFinancialTransactionTax { get; set; }
        [BsonElement("strUserId")]
        public string StrUserId { get; set; } = string.Empty;
        [BsonElement("strDepositNumber")]
        public string StrDepositNumber { get; set; } = string.Empty;
        [BsonElement("strVerificationNumber")]
        public string StrVerificationNumber { get; set; } = string.Empty;
        [BsonElement("dteDeposit")]
        public DateTime DteDeposit { get; set; }
        [BsonElement("strBankCode")]
        public string StrBankCode { get; set; } = string.Empty;
    }
}
