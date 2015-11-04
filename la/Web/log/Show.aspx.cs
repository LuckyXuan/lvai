using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace la.Web.log
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int log_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					log_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(log_id,user_telphone);
			}
		}
		
	private void ShowInfo(int log_id,string user_telphone)
	{
		la.BLL.log bll=new la.BLL.log();
		la.Model.log model=bll.GetModel(log_id,user_telphone);
		this.lbllog_id.Text=model.log_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lbllog_ip.Text=model.log_ip;
		this.lbllog_time.Text=model.log_time.ToString();
		this.lblLAT.Text=model.LAT.ToString();
		this.lblLNG.Text=model.LNG.ToString();

	}


    }
}
