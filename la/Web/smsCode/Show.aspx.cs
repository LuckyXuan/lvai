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
namespace la.Web.smsCode
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int smscode_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					smscode_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(smscode_id,user_telphone);
			}
		}
		
	private void ShowInfo(int smscode_id,string user_telphone)
	{
		la.BLL.smsCode bll=new la.BLL.smsCode();
		la.Model.smsCode model=bll.GetModel(smscode_id,user_telphone);
		this.lblsmscode_id.Text=model.smscode_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblsmscode_sendtime.Text=model.smscode_sendtime.ToString();
		this.lblsmscode.Text=model.smscode;

	}


    }
}
