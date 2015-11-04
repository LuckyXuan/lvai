using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace la.DataServer
{
    public class SendSMS
    {
        /// <summary>
        ///  发送短信验证码。
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="code"></param>
        public static void sendSMSCode(string tel,string code)
        {

            string serverIp = "api.ucpaas.com";
            string serverPort = "443";
            string account = "504d056eca8627dac2a7f77649244aa6";    //用户sid
            string token = "226db99dab9b85dcd598062a00be2a43";      //用户sid对应的token
            string appId = "693ec3ae294646e79ee1453bcdc4dde1";      //对应的应用id，非测试应用需上线使用
            string clientNum = "60000000000001";
            string clientpwd = "";
            string friendName = "";
            string clientType = "0";
            string charge = "0";
            string phone = "";
            string date = "day";
            uint start = 0;
            uint limit = 100;
            string toPhone = tel;                         //发送短信手机号码，群发逗号区分
            string templatedId = "13356";                               //短信模板id，需通过审核
            string param = code+",2";                                     //短信参数
            string verifyCode = "1234";
            string fromSerNum = "4000000000";
            string toSerNum = "4000000000";
            string maxallowtime = "60";

            UCSRestRequest.UCSRestRequest req = new UCSRestRequest.UCSRestRequest();

            req.init(serverIp, serverPort);
            req.setAccount(account, token);
            req.enabeLog(true);
            req.setAppId(appId);
            req.enabeLog(true);

            req.SendSMS(toPhone, templatedId, param);
        }
    }
}
