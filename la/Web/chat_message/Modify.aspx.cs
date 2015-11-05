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
namespace la.Web.chat_message
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int chat_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(chat_ID);
				}
			}
		}
			
	private void ShowInfo(int chat_ID)
	{
		la.BLL.chat_message bll=new la.BLL.chat_message();
		la.Model.chat_message model=bll.GetModel(chat_ID);
		this.lblchat_ID.Text=model.chat_ID.ToString();
		this.txtchat_FROM.Text=model.chat_FROM.ToString();
		this.txtchat_TO.Text=model.chat_TO.ToString();
		this.txtchat_content.Text=model.chat_content;
		this.txtchat_time.Text=model.chat_time.ToString();
		this.txtchat_comment.Text=model.chat_comment;
		this.txtchat_state.Text=model.chat_state;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtchat_FROM.Text))
			{
				strErr+="聊天记录FROM格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtchat_TO.Text))
			{
				strErr+="聊天记录TO格式错误！\\n";	
			}
			if(this.txtchat_content.Text.Trim().Length==0)
			{
				strErr+="聊天内容不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtchat_time.Text))
			{
				strErr+="聊天时间格式错误！\\n";	
			}
			if(this.txtchat_comment.Text.Trim().Length==0)
			{
				strErr+="聊天备注不能为空！\\n";	
			}
			if(this.txtchat_state.Text.Trim().Length==0)
			{
				strErr+="聊天记录状态不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int chat_ID=int.Parse(this.lblchat_ID.Text);
			int chat_FROM=int.Parse(this.txtchat_FROM.Text);
			int chat_TO=int.Parse(this.txtchat_TO.Text);
			string chat_content=this.txtchat_content.Text;
			DateTime chat_time=DateTime.Parse(this.txtchat_time.Text);
			string chat_comment=this.txtchat_comment.Text;
			string chat_state=this.txtchat_state.Text;


			la.Model.chat_message model=new la.Model.chat_message();
			model.chat_ID=chat_ID;
			model.chat_FROM=chat_FROM;
			model.chat_TO=chat_TO;
			model.chat_content=chat_content;
			model.chat_time=chat_time;
			model.chat_comment=chat_comment;
			model.chat_state=chat_state;

			la.BLL.chat_message bll=new la.BLL.chat_message();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
