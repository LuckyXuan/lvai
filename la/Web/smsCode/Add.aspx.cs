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
namespace la.Web.smsCode
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtsmscode_id.Text))
			{
				strErr+="短信验证码编码格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtsmscode_sendtime.Text))
			{
				strErr+="验证码发送时间格式错误！\\n";	
			}
			if(this.txtsmscode.Text.Trim().Length==0)
			{
				strErr+="验证码不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int smscode_id=int.Parse(this.txtsmscode_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
			DateTime smscode_sendtime=DateTime.Parse(this.txtsmscode_sendtime.Text);
			string smscode=this.txtsmscode.Text;

			la.Model.smsCode model=new la.Model.smsCode();
			model.smscode_id=smscode_id;
			model.user_telphone=user_telphone;
			model.smscode_sendtime=smscode_sendtime;
			model.smscode=smscode;

			la.BLL.smsCode bll=new la.BLL.smsCode();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
