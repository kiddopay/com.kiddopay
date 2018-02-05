using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Domains.Wallet
{
    public class TopUpMessage
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public decimal Nominal { get; set; }
    }
}
