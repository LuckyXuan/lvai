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
namespace la.Web.VIP
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int VIPID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					VIPID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(VIPID,user_telphone);
			}
		}
		
	private void ShowInfo(int VIPID,string user_telphone)
	{
		la.BLL.VIP bll=new la.BLL.VIP();
		la.Model.VIP model=bll.GetModel(VIPID,user_telphone);
		this.lblVIPID.Text=model.VIPID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblVIP_change_credit.Text=model.VIP_change_credit.ToString();
		this.lblVIP_change_comment.Text=model.VIP_change_comment;
		this.lblVIP_change_time.Text=model.VIP_change_time.ToString();
		this.lblVIP_credit.Text=model.VIP_credit.ToString();
		this.lblVIP_level.Text=model.VIP_level.ToString();
		this.lblVIP_change_type.Text=model.VIP_change_type;

	}


    }
}
