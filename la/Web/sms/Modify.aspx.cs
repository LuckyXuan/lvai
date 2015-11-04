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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int sms_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					sms_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(sms_id,user_telphone);
			}
		}
			
	private void ShowInfo(int sms_id,string user_telphone)
	{
		la.BLL.sms bll=new la.BLL.sms();
		la.Model.sms model=bll.GetModel(sms_id,user_telphone);
		this.lblsms_id.Text=model.sms_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtsms_content.Text=model.sms_content;
		this.txtsms_time.Text=model.sms_time.ToString();
		this.txtsms_comment.Text=model.sms_comment;
		this.chksms_ispay.Checked=model.sms_ispay;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			int sms_id=int.Parse(this.lblsms_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
