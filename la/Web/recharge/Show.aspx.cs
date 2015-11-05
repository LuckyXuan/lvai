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
namespace la.Web.recharge
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int recharge_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					recharge_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(recharge_ID,user_telphone);
			}
		}
		
	private void ShowInfo(int recharge_ID,string user_telphone)
	{
		la.BLL.recharge bll=new la.BLL.recharge();
		la.Model.recharge model=bll.GetModel(recharge_ID,user_telphone);
		this.lblrecharge_ID.Text=model.recharge_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblrecharge_plat.Text=model.recharge_plat;
		this.lblrecharge_money.Text=model.recharge_money.ToString();
		this.lblrecharge_time.Text=model.recharge_time.ToString();
		this.lblrecharge_code.Text=model.recharge_code;
		this.lblrecharge_comment.Text=model.recharge_comment;

	}


    }
}
