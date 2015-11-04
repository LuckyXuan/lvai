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
namespace la.Web.credit
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int credit_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					credit_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(credit_id,user_telphone);
			}
		}
		
	private void ShowInfo(int credit_id,string user_telphone)
	{
		la.BLL.credit bll=new la.BLL.credit();
		la.Model.credit model=bll.GetModel(credit_id,user_telphone);
		this.lblcredit_id.Text=model.credit_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblcredit_change.Text=model.credit_change.ToString();
		this.lblcreditchange_type.Text=model.creditchange_type;
		this.lblcreditchange_time.Text=model.creditchange_time.ToString();
		this.lblcredit_balance.Text=model.credit_balance.ToString();
		this.lblcreditchange_comment.Text=model.creditchange_comment;

	}


    }
}
