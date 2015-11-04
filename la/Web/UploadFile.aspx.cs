using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace la.Web
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Write(Server.MapPath("~/Temp/") + "log.txt", "ios");
            string dirPath = Server.MapPath("~/Temp/");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string filePath = dirPath + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";

            try
            {
                HttpPostedFile file = Request.Files[0];
                file.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                Write(Server.MapPath("~/Temp/")+"log.txt", ex.Message);
            
            }
            

         
        }

        public void Write(string path,string content)
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