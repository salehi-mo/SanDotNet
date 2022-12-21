using System;

namespace _0_Framework.Application.Sms.Results
{
    public class PackResult
    {
        public Guid PackId { get; set; }

        public int RecipientCount { get; set; }

        public int CreationDateTime { get; set; }
    }
}