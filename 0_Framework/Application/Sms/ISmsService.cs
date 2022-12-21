namespace _0_Framework.Application.Sms
{
    public interface ISmsService
    {
        void SendSms(string number, string message);
        void SendVerifySms(string number, string message);
    }
}