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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtmoney_id.Text))
			{
				strErr+="财富ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int money_id=int.Parse(this.txtmoney_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
