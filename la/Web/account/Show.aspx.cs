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
namespace la.Web.account
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int account_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					account_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(account_id,user_telphone);
			}
		}
		
	private void ShowInfo(int account_id,string user_telphone)
	{
		la.BLL.account bll=new la.BLL.account();
		la.Model.account model=bll.GetModel(account_id,user_telphone);
		this.lblaccount_id.Text=model.account_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblaccount_balance.Text=model.account_balance.ToString();
		this.lblaccount_change.Text=model.account_change.ToString();
		this.lblaccount_changetype.Text=model.account_changetype;
		this.lblaccount_change_time.Text=model.account_change_time.ToString();
		this.lblaccount_change_comment.Text=model.account_change_comment;

	}


    }
}
