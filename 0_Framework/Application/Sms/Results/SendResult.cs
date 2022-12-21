using System;

namespace _0_Framework.Application.Sms.Results
{
    public class SendResult
    {
        public Guid PackId { get; set; }
        public int?[] MessageIds { get; set; }
        public decimal Cost { get; set; }
    }
}