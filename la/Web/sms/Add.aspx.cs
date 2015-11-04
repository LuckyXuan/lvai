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
namespace la.Web.sms
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtsms_id.Text))
			{
				strErr+="短信编码格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(this.txtsms_content.Text.Trim().Length==0)
			{
				strErr+="短信内容不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtsms_time.Text))
			{
				strErr+="发送时间格式错误！\\n";	
			}
			if(this.txtsms_comment.Text.Trim().Length==0)
			{
				strErr+="说明不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int sms_id=int.Parse(this.txtsms_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
			string sms_content=this.txtsms_content.Text;
			DateTime sms_time=DateTime.Parse(this.txtsms_time.Text);
			string sms_comment=this.txtsms_comment.Text;
			bool sms_ispay=this.chksms_ispay.Checked;

			la.Model.sms model=new la.Model.sms();
			model.sms_id=sms_id;
			model.user_telphone=user_telphone;
			model.sms_content=sms_content;
			model.sms_time=sms_time;
			model.sms_comment=sms_comment;
			model.sms_ispay=sms_ispay;

			la.BLL.sms bll=new la.BLL.sms();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
