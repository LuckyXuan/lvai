using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using la.DataServer;
using System.Web.Script.Services;
using System.IO;
namespace la.Web
{
    /// <summary>
    /// DS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class DS : System.Web.Services.WebService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [WebMethod]
        public string login(string tel, string pwd)
        {
            return UserInfoServer.login(tel, pwd);
        }
        #region 短信验证登录请求 2015-11-5 凯旋 编写
        /// <summary>
        /// 短信验证登录请求
        /// </summary>
        /// <param name="tel">手机号</param>
        /// <returns></returns>
        [WebMethod]
        public string applySMSLogin(string tel)
        {
            string result = "{\"status\":";
            if (Util.validSqlInsert(tel))
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"含有非法攻击字符\",";
                result = result + "\"data\":{}}";
                return result;
            }
            //第一步判断该手机号是否存在，不存在返回结果，存在则写入数据库4位随机码
            if (new BLL.user_tb().GetModel(tel) == null)
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"该手机号未注册\",";
                result = result + "\"data\":{}}";
                return result;
            }
            try
            {
                //第二步向短信服务商发出请求。
                string code = Util.CreateRandomCode(4);
                //当上线时再将短信开通。
                // SendSMS.sendSMSCode(tel,code);
                //向数据库短信验证码写入一条数据。
                Model.smsCode smscode = new Model.smsCode();
                smscode.smscode = code;
                smscode.smscode_sendtime = DateTime.Now;
                smscode.user_telphone = tel;
                new BLL.smsCode().Add(smscode);
                //向数据库短息库写入一条数据，以便进行统计。
                Model.sms sms = new Model.sms();
                sms.sms_time = smscode.smscode_sendtime;
                sms.user_telphone = tel;
                sms.sms_content = "短信验证码内容：" + code;
                new BLL.sms().Add(sms);
            }
            catch (Exception ex)
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"" + ex.Message + "\",";
                result = result + "\"data\":{}}";
                return result;
            }
            result = result + "\"success\",";
            result = result + "\"msg\":\"\",";
            result = result + "\"data\":{}}";
            return result;
        }
        #endregion
        /// <summary>
        /// 发送短信验证码注册请求。
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [WebMethod]
        public string applySMS(string tel)
        {
            string result = "{\"status\":";
            if (Util.validSqlInsert(tel))
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"含有非法攻击字符\",";
                result = result + "\"data\":{}}";
                return result;
            }

            //第一步向数据库写入一条用户数据。
            if (new BLL.user_tb().GetModel(tel) == null)
            {
                Model.user_tb u = new Model.user_tb();
                u.user_telphone = tel;
                u.user_nikeName = UserInfoServer.NikeNameCreate();
                new BLL.user_tb().Add(u);
            }
            #region 凯旋修改10-29判断账号是否存在
            else
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"该手机号已注册\",";
                result = result + "\"data\":{}}";
                return result;
            }
            #endregion
            //第二步向短信服务商发出请求。
            string code = Util.CreateRandomCode(4);
            //当上线时再将短信开通。
            // SendSMS.sendSMSCode(tel,code);
            //向数据库短信验证码写入一条数据。
            Model.smsCode smscode = new Model.smsCode();
            smscode.smscode = code;
            smscode.smscode_sendtime = DateTime.Now;
            smscode.user_telphone = tel;
            new BLL.smsCode().Add(smscode);
            //向数据库短息库写入一条数据，以便进行统计。
            Model.sms sms = new Model.sms();
            sms.sms_time = smscode.smscode_sendtime;
            sms.user_telphone = tel;
            sms.sms_content = "短信验证码内容：" + code;
            new BLL.sms().Add(sms);

            result = result + "\"success\",";
            result = result + "\"msg\":\"\",";
            result = result + "\"data\":{}}";
            return result;
        }

        /// <summary>
        /// 对验证码进行验证。
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [WebMethod]
        public string validSMSCode(string tel, string code)
        {
            string result = "{\"status\":";
            if (Util.validSqlInsert(tel))
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"含有非法攻击字符\",";
                result = result + "\"data\":{}}";
                return result;
            }

            Model.smsCode smscode = DataServer.SMSServer.getLastSmsCode(tel);
            if (smscode == null)
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"没找到短信验证码\",";
                result = result + "\"data\":{}}";
                return result;
            }

            DateTime dt0 = DateTime.Now;
            DateTime dt1 = (DateTime)smscode.smscode_sendtime;
            if (dt0.Subtract(dt1) > new TimeSpan(0, 2, 0))
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"验证码超时\",";
                result = result + "\"data\":{}}";
                return result;
            }

            if (code != smscode.smscode)
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"验证码错误\",";
                result = result + "\"data\":{}}";
                return result;
            }

            result = result + "\"success\",";
            result = result + "\"msg\":\"验证成功\",";
            result = result + "\"data\":";

            Model.user_tb u = new BLL.user_tb().GetModel(tel);
            string jsentri = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(u);
            result = result + jsentri + "}";
            return result;
        }

        /// <summary>
        ///  完善或者更新用户信息。
        /// </summary>
        /// <param name="jsonUserInfo"></param>
        /// <returns></returns>
        [WebMethod]
        public string updateUserInfo(object jsonUserInfo)
        {
            Dictionary<string, object> dic = jsonUserInfo as Dictionary<string, object>;

            // Dictionary<string, object> dic = jsonUserInfo;
            string result = "{\"status\":";
            //if (Util.validSqlInsert(jsonUserInfo))
            //{
            //    result = result + "\"faild\",";
            //    result = result + "\"msg\":\"含有非法攻击字符\",";
            //    result = result + "\"data\":{}}";
            //    return result;
            //}


            try
            {
                Model.user_tb u = new Model.user_tb();
                //u.user_sex = (bool)dic["user_sex"];
                //return dic["user_sex"].ToString();
                u.user_sex = Convert.ToBoolean(dic["user_sex"].ToString());
                u.user_nikeName = dic["user_nikeName"].ToString();
                u.user_photo = dic["user_photo"].ToString();
                u.user_birthday = Convert.ToDateTime(dic["user_birthday"].ToString());
                u.user_height = dic["user_height"].ToString();
                u.user_weight = dic["user_weight"].ToString();
                u.user_address = dic["user_address"].ToString();
                u.user_job = dic["user_job"].ToString();
                u.user_income = dic["user_income"].ToString();
                u.user_pwd = dic["user_pwd"].ToString();
                u.user_telphone = dic["user_telphone"].ToString();
                //u = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Model.user_tb>(jsonUserInfo);
                new BLL.user_tb().Update(u);
            }
            catch (Exception e)
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"" + e.Message + "\",";
                result = result + "\"data\":{}}";
                return result;
            }

            result = result + "\"success\",";
            result = result + "\"msg\":\"更新成功\",";
            result = result + "\"data\":{}}";
            return result;
        }

        /// <summary>
        /// 上传用户头像
        /// 正常头像路径为HeadPhoto文件夹
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string uploadHeadPhoto(string tel, string imgData)
        {
            //HttpPostedFile file = context.Request.Files[i];
            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/HeadPhoto/");
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
            string filePath = dirPath + fileName;//file.FileName;

            BLL.user_tb ubll = new BLL.user_tb();
            Model.user_tb u = ubll.GetModel(tel);
            u.user_photo = "/UploadFile/HeadPhoto/" + fileName;
            ubll.Update(u);


            string Pic_Path = filePath;
            // imgData = imgData.Replace("%2B", "+");
            try
            {
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(imgData);
                        bw.Write(data);
                        bw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return "{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}";
            }


            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":{}}";
            return result;

        }

        /// <summary>
        /// 获取用户的精确定位。
        /// 首先将写入用户的最近地理位置库。
        /// 再写入到登录日志库。
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        [WebMethod]
        public string GPSLocation(string tel, decimal lng, decimal lat)
        {
            string result = "{\"status\":";
            if (Util.validSqlInsert(tel))
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"含有非法攻击字符\",";
                result = result + "\"data\":{}}";
                return result;
            }

            List<Model.gpslocation> locationlist = new BLL.gpslocation().GetModelList(" user_telphone='" + tel + "'");
            if (locationlist == null || locationlist.Count == 0)
            {
                Model.gpslocation location = new Model.gpslocation();
                location.location_lat = lat;
                location.location_lng = lng;
                location.user_telphone = tel;
                new BLL.gpslocation().Add(location);
            }
            else
            {
                Model.gpslocation location = locationlist[0];
                location.location_lat = lat;
                location.location_lng = lng;
                new BLL.gpslocation().Update(location);
            }

            Model.log log = new Model.log();
            log.LAT = lat;
            log.LNG = lng;
            log.log_time = DateTime.Now;
            log.user_telphone = tel;
            new BLL.log().Add(log);

            result = result + "\"success\",";
            result = result + "\"msg\":\"更新成功\",";
            result = result + "\"data\":{}}";
            return result;

        }

        /// <summary>
        /// 签到日志。
        /// 签到后会产生旅币交易。
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [WebMethod]
        public string signlog(string tel)
        {
            Model.signlog log = new Model.signlog();
            log.sign_time = DateTime.Now;
            log.user_telphone = tel;
            new BLL.signlog().Add(log);

            string result = "{\"status\":";
            result = result + "\"success\",";
            result = result + "\"msg\":\"更新成功\",";
            result = result + "\"data\":{}}";
            return result;
        }

        /// <summary>
        /// 更新车辆基础信息。不包括图片。
        /// </summary>
        /// <param name="carJsonstring"></param>
        /// <returns></returns>
        [WebMethod]
        public string UpdateCarInfo(object carJsonstring)
        {
            Dictionary<string, object> dic = carJsonstring as Dictionary<string, object>;
            Model.carInfo info = new Model.carInfo();
            //Dictionary<string, object> dic = carJsonstring;
            info.user_telphone = dic["user_telphone"].ToString();
            info.car_level = dic["car_level"].ToString();
            info.car_brand = dic["car_brand"].ToString();
            info.car_type = dic["car_type"].ToString();
            string temp = "";
            string data = "";
            string result = "{\"status\":";
            //Model.carInfo info = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Model.carInfo>(carJsonstring);
            string tel = info.user_telphone;
            List<Model.carInfo> carInfoL = new BLL.carInfo().GetModelList(" user_telphone='" + tel + "'");

            if (carInfoL == null || carInfoL.Count == 0)
            {
                new BLL.carInfo().Add(info);
            }
            else
            {
                try
                {
                    Model.carInfo car = carInfoL[0];
                    car.car_level = info.car_level;
                    car.car_brand = info.car_brand;
                    car.car_type = info.car_type;
                    temp = new BLL.carInfo().Update(car).ToString();
                }
                catch (Exception ex)
                {
                    temp = ex.Message;
                }

                //temp = car.user_telphone + "ff" +car.car_id.ToString();
            }

            result = result + "\"success\",";
            result = result + "\"msg\":\"" + temp + "\",";
            result = result + "\"data\":{}}";
            return result;

        }

        /// <summary>
        /// 获取车辆信息。
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [WebMethod]
        public string getCarInfo(string tel)
        {
            string result = "{\"status\":";
            List<Model.carInfo> carInfoL = new BLL.carInfo().GetModelList(" user_telphone='" + tel + "'");
            try
            {
                if (carInfoL == null || carInfoL.Count == 0)
                {
                    result = result + "\"success\",";
                    result = result + "\"msg\":\"没有找到车辆信息\",";
                    result = result + "\"data\":{}}";
                    return result;
                }
                else
                {
                    Model.carInfo car = carInfoL[0];
                    string data = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(car);
                    result = result + "\"success\",";
                    result = result + "\"msg\":\"success\",";
                    result = result + "\"data\":";
                    result = result + data;
                    result = result + "}";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result = result + "\"faild\",";
                result = result + "\"msg\":\"" + ex.Message + "\",";
                result = result + "\"data\":{}}";
                return result;

            }


        }

        /// <summary>
        /// 获取用户相册信息。
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [WebMethod]
        public string getUserAlbumInfo(string tel)
        {
            List<Model.album> albumLst = la.DataServer.AlbumServer.getAlbumListByTel(tel);
            string data = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(albumLst);
            return data;
        }

    }
}
