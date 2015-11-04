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
namespace la.Web.credit
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtcredit_id.Text))
			{
				strErr+="信用积分ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtcredit_change.Text))
			{
				strErr+="信用积分变化格式错误！\\n";	
			}
			if(this.txtcreditchange_type.Text.Trim().Length==0)
			{
				strErr+="信用积分变化类型不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtcreditchange_time.Text))
			{
				strErr+="信用积分变化时间格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtcredit_balance.Text))
			{
				strErr+="信用积分余额格式错误！\\n";	
			}
			if(this.txtcreditchange_comment.Text.Trim().Length==0)
			{
				strErr+="信用积分变化说明不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int credit_id=int.Parse(this.txtcredit_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
			decimal credit_change=decimal.Parse(this.txtcredit_change.Text);
			string creditchange_type=this.txtcreditchange_type.Text;
			DateTime creditchange_time=DateTime.Parse(this.txtcreditchange_time.Text);
			decimal credit_balance=decimal.Parse(this.txtcredit_balance.Text);
			string creditchange_comment=this.txtcreditchange_comment.Text;

			la.Model.credit model=new la.Model.credit();
			model.credit_id=credit_id;
			model.user_telphone=user_telphone;
			model.credit_change=credit_change;
			model.creditchange_type=creditchange_type;
			model.creditchange_time=creditchange_time;
			model.credit_balance=credit_balance;
			model.creditchange_comment=creditchange_comment;

			la.BLL.credit bll=new la.BLL.credit();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
