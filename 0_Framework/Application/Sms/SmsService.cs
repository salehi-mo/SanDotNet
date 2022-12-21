using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using IPE.SmsIrClient;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient.Models.Results;
using Microsoft.Extensions.Configuration;
using SmsIrRestful;

namespace _0_Framework.Application.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendSms(string number, string message)
        {
            Task<SmsIrResult<SendResult>> resualtSendSms = BulkSend(number, message);
            //resualtSendSms.Result.Message;
        }

        public void SendVerifySms(string number, string message)
        {
            Task<SmsIrResult<VerifySendResult>> resualtVerifySendSms = VerifySend(number, message);
            //resualtVerifySendSms.Status
        }

        private async Task<SmsIrResult<SendResult>> BulkSend(string number, string message)
        {

            var smsSecrets = _configuration.GetSection("SmsSecrets");
            SmsIr smsIr = new SmsIr(smsSecrets["ApiKey"]);

            return await smsIr.BulkSendAsync(long.Parse(smsSecrets["LineNumber"]), message, new string[] { number });
        }

        private async Task<SmsIrResult<VerifySendResult>> VerifySend(string number, string message)
        {

            var smsSecrets = _configuration.GetSection("SmsSecrets");
            SmsIr smsIr = new SmsIr(smsSecrets["ApiKey"]);

            return await smsIr.VerifySendAsync(number, 100000, new VerifySendParameter[] { new("Code", message) });
        }




        //public void SendSms(string number, string message)
        //{
        //    var token = GetToken();
        //    var lines = new SmsLine().GetSmsLines(token);
        //    if (lines == null) return;

        //    var line = lines.SMSLines.Last().LineNumber.ToString();
        //    var data = new MessageSendObject
        //    {
        //        Messages = new List<string>
        //            {message}.ToArray(),
        //        MobileNumbers = new List<string> { number }.ToArray(),
        //        LineNumber = line,
        //        SendDateTime = DateTime.Now,
        //        CanContinueInCaseOfError = true
        //    };
        //    var messageSendResponseObject =
        //        new MessageSend().Send(token, data);

        //    if (messageSendResponseObject.IsSuccessful) return;

        //    line = lines.SMSLines.First().LineNumber.ToString();
        //    data.LineNumber = line;
        //    new MessageSend().Send(token, data);

        //}

        //private string GetToken()
        //{
        //    var smsSecrets = _configuration.GetSection("SmsSecrets");
        //    var tokenService = new Token();
        //    //return tokenService.GetToken(smsSecrets["ApiKey"], smsSecrets["SecretKey"]);
        //    return tokenService.GetToken("E9OMIhsMB1X3Z15BiR9JvcHtj4mpWqXcO3fdu7OgnYqtd2d1xwWovH1PqVb5K1KL", "MyKey");
        //}
    }
}