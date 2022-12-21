namespace _0_Framework.Application.Sms.Results
{
    public class SmsIrResult
    {
        public byte Status { get; set; }
        public string Message { get; set; }
    }

    public class SmsIrResult<TData> : SmsIrResult
    {
        public TData Data { get; set; }
    }
}