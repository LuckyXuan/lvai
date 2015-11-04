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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int smscode_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					smscode_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(smscode_id,user_telphone);
			}
		}
			
	private void ShowInfo(int smscode_id,string user_telphone)
	{
		la.BLL.smsCode bll=new la.BLL.smsCode();
		la.Model.smsCode model=bll.GetModel(smscode_id,user_telphone);
		this.lblsmscode_id.Text=model.smscode_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtsmscode_sendtime.Text=model.smscode_sendtime.ToString();
		this.txtsmscode.Text=model.smscode;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			int smscode_id=int.Parse(this.lblsmscode_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			DateTime smscode_sendtime=DateTime.Parse(this.txtsmscode_sendtime.Text);
			string smscode=this.txtsmscode.Text;


			la.Model.smsCode model=new la.Model.smsCode();
			model.smscode_id=smscode_id;
			model.user_telphone=user_telphone;
			model.smscode_sendtime=smscode_sendtime;
			model.smscode=smscode;

			la.BLL.smsCode bll=new la.BLL.smsCode();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
