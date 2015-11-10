using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Collections.Generic;


namespace la.Web
{
    /// <summary>
    /// UploadHandler 的摘要说明。
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        /// <summary>
        /// 调用的方法。(1)uploadHeadPhoto.上传头像方法。
        ///               参数为:tel
        ///             (2)uploadVideo。上传验证视频。
        ///              参数为:tel
        ///             (3)uploadCarPhoto.上传小车图片。
        ///              参数为：tel  电话号码
        ///                     index 第几张汽车图片。
        ///             (4)uploadVideo 上传视频。
        ///              参数：tel
        ///            （5）uploadAudio 上传音频。
        ///              参数：tel
        ///            （6）uploadBg 上传背景图片。
        ///              参数：tel 
        ///             (7)uploadAlbum上传图片墙
        ///             参数：tel   files
        /// </summary>
        private string Action = "";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Action = context.Request.Form["Action"].ToString();
            switch (Action)
            {
                case "uploadHeadPhoto0":
                    {
                        UploadHeadPhoto0(context);
                        break;
                    }
                case "uploadCarPhoto0":
                    {
                        UploadCarPhoto0(context);
                        break;
                    }
                case "upUserAudio":
                    {
                        UploadUserAudio(context);
                        break;
                    }
                case "uploadVideo":
                    {
                        UploadVideo(context);
                        break;
                    }
                case "uploadUserCenterBg":
                    {
                        UploadUserCenterBg(context);
                        break;
                    }
                case "uploadAlbum":
                    {
                        UploadAlbum(context);
                        break;
                    }
            }
        }

        /// <summary>
        /// 上传音频。
        /// </summary>
        /// <param name="context"></param>
        private void UploadUserAudio(HttpContext context)
        {
            string tel = context.Request.Form["tel"].ToString();
            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/UserAudio/");
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".amr";
            string filePath = dirPath + fileName;//file.FileName;
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            BLL.audio aBLL = new BLL.audio();
            Model.audio a = new Model.audio();
            a.user_telphone = tel;
            a.audio_state = "未审核";
            a.audio_time = DateTime.Now;
            a.audio_url = filePath;
            a.audio_comment = "";
            aBLL.Add(a);
            string Pic_Path = filePath;
            try
            {
                HttpFileCollection files = context.Request.Files;
                HttpPostedFile file = context.Request.Files[0];
                file.SaveAs(Pic_Path);

            }
            catch (Exception ex)
            {
                context.Response.Write("{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}");
            }
            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":\"" + "\"}";
            context.Response.Write(result);

        }

        ///<summary>
        ///上传用户个人中心背景。
        ///</summary>
        private void UploadUserCenterBg(HttpContext context)
        {
            string tel = context.Request.Form["tel"].ToString();
            string filename = context.Request.Form["filename"].ToString();
            filename = Path.GetFileName(filename);
            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/UserCenterBg/");
            //string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
            string filePath = dirPath + filename;//file.FileName;
            #region  2015-11-2  刘
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            #endregion

            BLL.user_tb ubll = new BLL.user_tb();
            Model.user_tb u = ubll.GetModel(tel);
            u.personcenter_bg = "/UploadFile/UserCenterBg/" + filename;
            ubll.Update(u);

            string Pic_Path = filePath;
            try
            {
                HttpFileCollection files = context.Request.Files;
                HttpPostedFile file = context.Request.Files[0];
                file.SaveAs(Pic_Path);

            }
            catch (Exception ex)
            {
                context.Response.Write("{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}");
            }
            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":\"" + "\"}";
            context.Response.Write(result);
        }

        /// <summary>
        /// 上传视频。
        /// </summary>
        private void UploadVideo(HttpContext context)
        {
            string tel = context.Request.Form["tel"].ToString();
            string type = context.Request.Form["type"].ToString();
            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/UserVideo/");
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + type;
            string filePath = dirPath + fileName;//file.FileName;
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            BLL.video vBLL = new BLL.video();
            Model.video v = new Model.video();
            v.user_telphone = tel;
            v.video_state = "未审核";
            v.video_uploadtime = DateTime.Now;
            v.video_url = filePath;
            v.video_comment = "";
            vBLL.Add(v);
            string Pic_Path = filePath;
            try
            {
                HttpFileCollection files = context.Request.Files;
                HttpPostedFile file = context.Request.Files[0];
                file.SaveAs(Pic_Path);
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}");
            }
            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":\"" + "\"}";
            context.Response.Write(result);
        }
        /// <summary>
        /// 上传用户头像base64编码形式。
        /// liu
        /// </summary>
        private void UploadHeadPhoto0(HttpContext context)
        {
            string tel = context.Request.Form["tel"].ToString();
            string base64 = context.Request.Form["base64"].ToString();

            string dirPath = HttpContext.Current.Server.MapPath("~/UploadFile/HeadPhoto/");
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
            string filePath = dirPath + fileName;//file.FileName;

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }



            BLL.user_tb ubll = new BLL.user_tb();
            Model.user_tb u = ubll.GetModel(tel);
            u.user_photo = "/UploadFile/HeadPhoto/" + fileName;
            ubll.Update(u);

            string Pic_Path = filePath;
            try
            {
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64);
                        bw.Write(data);
                        bw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"retStatus\":0,\"Msg\":\"" + ex.Message + "\",\"data\":{}}");
            }


            string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":\"" + u.user_photo + "\"}";
            context.Response.Write(result);
        }
        /// <summary>
        /// 上传车辆图片0。
        /// </summary>
        private void UploadCarPhoto0(HttpContext context)
        {
            string thumbDirPath = context.Server.MapPath("~/UploadFile/CarPhoto/");
            string dirPath = context.Server.MapPath("~/UploadFile/CarPhoto/thumbCarPhoto/");
            string tel = context.Request.Form["tel"].ToString();
            string photoindex = context.Request.Form["index"].ToString();
            string filename = context.Request.Form["filename"].ToString();

            filename = Path.GetFileName(filename);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                if (!Directory.Exists(thumbDirPath))
                {
                    Directory.CreateDirectory(thumbDirPath);
                }
            }
            try
            {
                HttpFileCollection files = context.Request.Files;
                //保存缩略图
                HttpPostedFile file = context.Request.Files[0];
               // string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                //string filePath = dirPath + "thumb_" + fileName;//file.FileName;
                string filePath = dirPath + filename;
                file.SaveAs(filePath);
                //保存原图
                //HttpPostedFile thumbFile = context.Request.Files[1];
                //string thumbFileName = fileName;
                //string thumbFilePath = thumbDirPath + thumbFileName;//file.FileName;
                //thumbFile.SaveAs(thumbFilePath);
                //更新数据库
                BLL.carInfo bll = new BLL.carInfo();
                List<Model.carInfo> carList = bll.GetModelList(" user_telphone='" + tel + "'");
                if (carList == null || carList.Count == 0)
                {
                    Model.carInfo info = new Model.carInfo();
                    info.user_telphone = tel;
                    if (photoindex == "1")
                    {
                        info.car_photo1 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + filename;
                    }
                    if (photoindex == "2")
                    {
                        info.car_photo2 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + filename;
                    }
                    if (photoindex == "3")
                    {
                        info.car_photo3 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + filename;
                    }
                    bll.Add(info);
                }
                else
                {
                    Model.carInfo info = carList[0];
                    if (photoindex == "1")
                    {
                        info.car_photo1 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + filename;
                    }
                    if (photoindex == "2")
                    {
                        info.car_photo2 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + filename;
                    }
                    if (photoindex == "3")
                    {
                        info.car_photo3 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/" + filename;
                    }
                    bll.Update(info);
                }
                string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":{}}";
                context.Response.Write(result);
            }
            catch (Exception e)
            {
                string result = "{\"Status\":\"faild\",\"Msg\":\"上传失败，" + e.Message + "\",\"data\":{}}";
                context.Response.Write(result);
            }
        }

        /// <summary>
        /// 上传车辆图片。
        /// </summary>
        private void UploadCarPhoto(HttpContext context)
        {
            string dirPath = context.Server.MapPath("~/UploadFile/CarPhoto/");
            string tel = context.Request.Form["tel"].ToString();
            string photoindex = context.Request.Form["index"].ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            try
            {
                HttpFileCollection files = context.Request.Files;
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = context.Request.Files[i];
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                        string filePath = dirPath + fileName;//file.FileName;
                        file.SaveAs(filePath);
                        DataServer.Util.MakeThumbnail(filePath, dirPath + "thumbCarPhoto/thumb_" + fileName, 160, 120, "W", "jpg");

                        BLL.carInfo bll = new BLL.carInfo();
                        List<Model.carInfo> carList = bll.GetModelList(" user_telphone='" + tel + "'");
                        if (carList == null || carList.Count == 0)
                        {
                            Model.carInfo info = new Model.carInfo();
                            info.user_telphone = tel;
                            if (photoindex == "1")
                            {
                                info.car_photo1 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_" + fileName;
                            }
                            if (photoindex == "2")
                            {
                                info.car_photo2 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_" + fileName;
                            }
                            if (photoindex == "3")
                            {
                                info.car_photo3 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_" + fileName;
                            }
                            bll.Add(info);

                        }
                        else
                        {
                            Model.carInfo info = carList[0];
                            if (photoindex == "1")
                            {
                                info.car_photo1 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_" + fileName;
                            }
                            if (photoindex == "2")
                            {
                                info.car_photo2 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_" + fileName;
                            }
                            if (photoindex == "3")
                            {
                                info.car_photo3 = "/UploadFile/CarPhoto/" + "thumbCarPhoto/thumb_" + fileName;
                            }
                            bll.Update(info);
                        }
                    }
                }
                string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":{}}";
                context.Response.Write(result);
            }
            catch (Exception e)
            {
                string result = "{\"Status\":\"faild\",\"Msg\":\"上传失败，" + e.Message + "\",\"data\":{}}";
                context.Response.Write(result);
            }
        }

        /// <summary>
        /// 发布旅行图片。
        /// </summary>
        private void RealseTravelPhoto(HttpContext context)
        {
            string dirPath = context.Server.MapPath("~/UploadFile/TravelPhoto/");
            //string tel = context.Request.Form["tel"].ToString();
            string filenames = context.Request.Form["filename"].ToString();
            string []filename = filenames.Split('|');
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            try
            {
                HttpFileCollection files = context.Request.Files;
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = context.Request.Files[i];
                        string fileName = Path.GetFileName( filename[i]);
                        string filePath = dirPath + fileName;//file.FileName;
                        file.SaveAs(filePath);
                        
                        //BLL.travel bll = new BLL.travel();
                        //List<Model.travel> TravelList = bll.GetModelList(" promoter_userid='" + tel + "'");
                       
                        //Model.travel info = new Model.travel();
                        //info.promoter_userid =Convert.ToInt32( tel);
                        //string sfile = "/UploadFile/TravelPhoto/" + fileName;
                        //if (i == 1)
                        //{
                        //    info.pic1 = sfile;
                        //}
                        //if (i == 2)
                        //{
                        //    info.pic2 = sfile;
                        //}
                        //if (i == 3)
                        //{
                        //    info.pic3 = sfile;
                        //}

                        //bll.Update(info);

                    }
                }
                string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":{}}";
                context.Response.Write(result);
            }
            catch (Exception e)
            {
                string result = "{\"Status\":\"faild\",\"Msg\":\"上传失败，" + e.Message + "\",\"data\":{}}";
                context.Response.Write(result);
            }
        }

        /// <summary>
        /// 上传用户头像。
        /// </summary>
        private void UploadHeadPhoto(HttpContext context)
        {
            string dirPath = context.Server.MapPath("~/UploadFile/HeadPhoto/");
            string tel = context.Request.Form["tel"].ToString();
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            try
            {
                HttpFileCollection files = context.Request.Files;
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = context.Request.Files[i];
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                        string filePath = dirPath + fileName;//file.FileName;
                        file.SaveAs(filePath);
                        DataServer.Util.MakeThumbnail(filePath, dirPath + "thumbHeadPhoto/thumb_" + fileName, 160, 120, "HW", "jpg");
                        BLL.user_tb ubll = new BLL.user_tb();
                        Model.user_tb u = ubll.GetModel(tel);
                        u.user_photo = "/UploadFile/HeadPhoto/" + fileName;
                        ubll.Update(u);
                    }
                }
                string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":{}}";
                context.Response.Write(result);
            }
            catch (Exception e)
            {
                string result = "{\"Status\":\"faild\",\"Msg\":\"上传失败，" + e.Message + "\",\"data\":{}}";
            }
        }


        #region  2015-11-2 liu
        /**
         * 上传用户相册。
         * */
        public void UploadAlbum(HttpContext context)
        {
            string dirPath = context.Server.MapPath("~/UploadFile/PersonPhoto/");
            string tel = context.Request.Form["tel"].ToString();
            //文件名列表：13923232323_201509099898.png|132323223232_2013233434343434.png
            string fileNames = context.Request.Form["fileNameList"].ToString();
            string[] fileNameList = fileNames.Split('|');

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            try
            {
                HttpFileCollection files = context.Request.Files;
                if (files.Count > 0)
                {
                    Model.album album = new Model.album();
                    album.album_isvalid = true;
                    album.album_time = DateTime.Now;
                    album.user_telphone = tel;
                    BLL.album bll = new BLL.album();
                    bll.Add(album);

                    BLL.personphoto pbll = new BLL.personphoto();
                    //获取刚插进去的相册的ID。
                    album = bll.GetModelList(" user_telphone='" + tel + "' order by album_id desc")[0];
                    int album_id = album.album_id;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = context.Request.Files[i];
                        string fileName = fileNameList[i];
                        string filePath = dirPath + fileName;//file.FileName;
                        file.SaveAs(filePath);

                        Model.personphoto photo = new Model.personphoto();
                        photo.album_id = album_id;
                        photo.personphoto_path = "/UploadFile/PersonPhoto/" + fileName;
                        pbll.Add(photo);
                    }
                }
                string result = "{\"Status\":\"success\",\"Msg\":\"上传成功\",\"data\":{}}";
                context.Response.Write(result);
            }
            catch (Exception e)
            {
                string result = "{\"Status\":\"faild\",\"Msg\":\"上传失败，" + e.Message + "\",\"data\":{}}";
                context.Response.Write(result);
            }
        }
        #endregion







        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void Write(string path, string content)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(content);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}

/*  可以获得客户端的手机型号。
for (int j = 0; j < context.Request.Params.Keys.Count; j++)
{
                            
    object key = context.Request.Params.Keys[j];
    Write(context.Server.MapPath("~/Temp/")+"log.txt", key.ToString() + ":");
    Write(context.Server.MapPath("~/Temp/") + "log.txt", context.Request.Params[key.ToString()].ToString() + ";");
}
 * */