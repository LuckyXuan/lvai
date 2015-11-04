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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int sendgift_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					sendgift_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				int virtualgoods_ID = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					virtualgoods_ID=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(sendgift_ID,virtualgoods_ID);
			}
		}
			
	private void ShowInfo(int sendgift_ID,int virtualgoods_ID)
	{
		la.BLL.sendgift bll=new la.BLL.sendgift();
		la.Model.sendgift model=bll.GetModel(sendgift_ID,virtualgoods_ID);
		this.lblsendgift_ID.Text=model.sendgift_ID.ToString();
		this.lblvirtualgoods_ID.Text=model.virtualgoods_ID.ToString();
		this.txtsender_id.Text=model.sender_id.ToString();
		this.txtaccepter_id.Text=model.accepter_id.ToString();
		this.txtsend_time.Text=model.send_time.ToString();
		this.txtsendgift_comment.Text=model.sendgift_comment;
		this.txtsendgift_msg.Text=model.sendgift_msg;
		this.txtsendgift_count.Text=model.sendgift_count.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			int sendgift_ID=int.Parse(this.lblsendgift_ID.Text);
			int virtualgoods_ID=int.Parse(this.lblvirtualgoods_ID.Text);
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
