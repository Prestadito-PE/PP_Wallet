﻿namespace Prestadito.Wallet.Application.Dto.Deposit.DisableDeposit
{
    public class DisableDepositResponse
    {
        public string StrId { get; set; } = string.Empty;
        public string StrRolId { get; set; } = string.Empty;
        public bool BlnEmailValidated { get; set; }
        public string StrStatusId { get; set; } = string.Empty;
        public string StrEmail { get; set; } = string.Empty;
    }
}
