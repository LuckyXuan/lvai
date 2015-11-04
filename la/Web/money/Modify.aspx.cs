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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace la.Web.money
{
    public partial class Modify : Page
    {       

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
		this.txtmoney_change.Text=model.money_change.ToString();
		this.txtmoneychange_time.Text=model.moneychange_time.ToString();
		this.txtmoneychange_comment.Text=model.moneychange_comment;
		this.txtmoney_balance.Text=model.money_balance.ToString();
		this.txtmoneychange_type.Text=model.moneychange_type;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDecimal(txtmoney_change.Text))
			{
				strErr+="财富变化格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtmoneychange_time.Text))
			{
				strErr+="财富变化时间格式错误！\\n";	
			}
			if(this.txtmoneychange_comment.Text.Trim().Length==0)
			{
				strErr+="财富变化说明不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtmoney_balance.Text))
			{
				strErr+="余额格式错误！\\n";	
			}
			if(this.txtmoneychange_type.Text.Trim().Length==0)
			{
				strErr+="财富变化类型不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int money_id=int.Parse(this.lblmoney_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			decimal money_change=decimal.Parse(this.txtmoney_change.Text);
			DateTime moneychange_time=DateTime.Parse(this.txtmoneychange_time.Text);
			string moneychange_comment=this.txtmoneychange_comment.Text;
			decimal money_balance=decimal.Parse(this.txtmoney_balance.Text);
			string moneychange_type=this.txtmoneychange_type.Text;


			la.Model.money model=new la.Model.money();
			model.money_id=money_id;
			model.user_telphone=user_telphone;
			model.money_change=money_change;
			model.moneychange_time=moneychange_time;
			model.moneychange_comment=moneychange_comment;
			model.money_balance=money_balance;
			model.moneychange_type=moneychange_type;

			la.BLL.money bll=new la.BLL.money();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
