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
namespace la.Web.account
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtaccount_id.Text))
			{
				strErr+="实际账户编码格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtaccount_balance.Text))
			{
				strErr+="账户余额格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtaccount_change.Text))
			{
				strErr+="账户变更数量格式错误！\\n";	
			}
			if(this.txtaccount_changetype.Text.Trim().Length==0)
			{
				strErr+="账户变更类型不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtaccount_change_time.Text))
			{
				strErr+="账户变更时间格式错误！\\n";	
			}
			if(this.txtaccount_change_comment.Text.Trim().Length==0)
			{
				strErr+="账户变更备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int account_id=int.Parse(this.txtaccount_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
			decimal account_balance=decimal.Parse(this.txtaccount_balance.Text);
			decimal account_change=decimal.Parse(this.txtaccount_change.Text);
			string account_changetype=this.txtaccount_changetype.Text;
			DateTime account_change_time=DateTime.Parse(this.txtaccount_change_time.Text);
			string account_change_comment=this.txtaccount_change_comment.Text;

			la.Model.account model=new la.Model.account();
			model.account_id=account_id;
			model.user_telphone=user_telphone;
			model.account_balance=account_balance;
			model.account_change=account_change;
			model.account_changetype=account_changetype;
			model.account_change_time=account_change_time;
			model.account_change_comment=account_change_comment;

			la.BLL.account bll=new la.BLL.account();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
