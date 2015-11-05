using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using la.DAL;

namespace la.DataServer
{
    public   class SMSServer
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tel">电话号码</param>
        /// <returns></returns>
        public static Model.smsCode getLastSmsCode(string tel)
        {
            return new DAL.smsCode().getLastCode(tel); 
        }

    }
}
