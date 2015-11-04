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
namespace la.Web.sendgift
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtsendgift_ID.Text))
			{
				strErr+="送礼ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtvirtualgoods_ID.Text))
			{
				strErr+="虚拟物品ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtsender_id.Text))
			{
				strErr+="送礼人格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtaccepter_id.Text))
			{
				strErr+="接受人格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtsend_time.Text))
			{
				strErr+="送礼时间格式错误！\\n";	
			}
			if(this.txtsendgift_comment.Text.Trim().Length==0)
			{
				strErr+="送礼说明不能为空！\\n";	
			}
			if(this.txtsendgift_msg.Text.Trim().Length==0)
			{
				strErr+="送礼留言不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtsendgift_count.Text))
			{
				strErr+="送礼数量格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int sendgift_ID=int.Parse(this.txtsendgift_ID.Text);
			int virtualgoods_ID=int.Parse(this.txtvirtualgoods_ID.Text);
			int sender_id=int.Parse(this.txtsender_id.Text);
			int accepter_id=int.Parse(this.txtaccepter_id.Text);
			DateTime send_time=DateTime.Parse(this.txtsend_time.Text);
			string sendgift_comment=this.txtsendgift_comment.Text;
			string sendgift_msg=this.txtsendgift_msg.Text;
			int sendgift_count=int.Parse(this.txtsendgift_count.Text);

			la.Model.sendgift model=new la.Model.sendgift();
			model.sendgift_ID=sendgift_ID;
			model.virtualgoods_ID=virtualgoods_ID;
			model.sender_id=sender_id;
			model.accepter_id=accepter_id;
			model.send_time=send_time;
			model.sendgift_comment=sendgift_comment;
			model.sendgift_msg=sendgift_msg;
			model.sendgift_count=sendgift_count;

			la.BLL.sendgift bll=new la.BLL.sendgift();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
