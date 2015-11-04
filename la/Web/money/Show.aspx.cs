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
namespace la.Web.money
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int money_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					money_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(money_id,user_telphone);
			}
		}
		
	private void ShowInfo(int money_id,string user_telphone)
	{
		la.BLL.money bll=new la.BLL.money();
		la.Model.money model=bll.GetModel(money_id,user_telphone);
		this.lblmoney_id.Text=model.money_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblmoney_change.Text=model.money_change.ToString();
		this.lblmoneychange_time.Text=model.moneychange_time.ToString();
		this.lblmoneychange_comment.Text=model.moneychange_comment;
		this.lblmoney_balance.Text=model.money_balance.ToString();
		this.lblmoneychange_type.Text=model.moneychange_type;

	}


    }
}
