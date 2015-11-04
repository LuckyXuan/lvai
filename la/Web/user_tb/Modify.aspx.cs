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
namespace la.Web.user_tb
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string user_telphone= Request.Params["id"];
					ShowInfo(user_telphone);
				}
			}
		}
			
	private void ShowInfo(string user_telphone)
	{
		la.BLL.user_tb bll=new la.BLL.user_tb();
		la.Model.user_tb model=bll.GetModel(user_telphone);
		this.lbluser_telphone.Text=model.user_telphone;
		this.chkuser_sex.Checked=model.user_sex;
		this.txtuser_nikeName.Text=model.user_nikeName;
		this.txtuser_photo.Text=model.user_photo;
		this.txtuser_birthday.Text=model.user_birthday.ToString();
		this.txtuser_height.Text=model.user_height;
		this.txtuser_weight.Text=model.user_weight;
		this.txtuser_address.Text=model.user_address;
		this.txtuser_job.Text=model.user_job;
		this.txtuser_income.Text=model.user_income;
		this.txtuser_pwd.Text=model.user_pwd;
		this.txtuser_marrystate.Text=model.user_marrystate;
		this.txtuser_edu.Text=model.user_edu;
		this.txtpersoncenter_bg.Text=model.personcenter_bg;
		this.txtuser_photo_state.Text=model.user_photo_state;
		this.txtuser_state.Text=model.user_state;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtuser_nikeName.Text.Trim().Length==0)
			{
				strErr+="用户昵称不能为空！\\n";	
			}
			if(this.txtuser_photo.Text.Trim().Length==0)
			{
				strErr+="用户头像不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtuser_birthday.Text))
			{
				strErr+="出生年月格式错误！\\n";	
			}
			if(this.txtuser_height.Text.Trim().Length==0)
			{
				strErr+="身高不能为空！\\n";	
			}
			if(this.txtuser_weight.Text.Trim().Length==0)
			{
				strErr+="体重不能为空！\\n";	
			}
			if(this.txtuser_address.Text.Trim().Length==0)
			{
				strErr+="常住地不能为空！\\n";	
			}
			if(this.txtuser_job.Text.Trim().Length==0)
			{
				strErr+="职业不能为空！\\n";	
			}
			if(this.txtuser_income.Text.Trim().Length==0)
			{
				strErr+="年收入不能为空！\\n";	
			}
			if(this.txtuser_pwd.Text.Trim().Length==0)
			{
				strErr+="用户密码不能为空！\\n";	
			}
			if(this.txtuser_marrystate.Text.Trim().Length==0)
			{
				strErr+="感情状况不能为空！\\n";	
			}
			if(this.txtuser_edu.Text.Trim().Length==0)
			{
				strErr+="学历不能为空！\\n";	
			}
			if(this.txtpersoncenter_bg.Text.Trim().Length==0)
			{
				strErr+="个人中心背景不能为空！\\n";	
			}
			if(this.txtuser_photo_state.Text.Trim().Length==0)
			{
				strErr+="头像审核状态不能为空！\\n";	
			}
			if(this.txtuser_state.Text.Trim().Length==0)
			{
				strErr+="用户状态不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string user_telphone=this.lbluser_telphone.Text;
			bool user_sex=this.chkuser_sex.Checked;
			string user_nikeName=this.txtuser_nikeName.Text;
			string user_photo=this.txtuser_photo.Text;
			DateTime user_birthday=DateTime.Parse(this.txtuser_birthday.Text);
			string user_height=this.txtuser_height.Text;
			string user_weight=this.txtuser_weight.Text;
			string user_address=this.txtuser_address.Text;
			string user_job=this.txtuser_job.Text;
			string user_income=this.txtuser_income.Text;
			string user_pwd=this.txtuser_pwd.Text;
			string user_marrystate=this.txtuser_marrystate.Text;
			string user_edu=this.txtuser_edu.Text;
			string personcenter_bg=this.txtpersoncenter_bg.Text;
			string user_photo_state=this.txtuser_photo_state.Text;
			string user_state=this.txtuser_state.Text;


			la.Model.user_tb model=new la.Model.user_tb();
			model.user_telphone=user_telphone;
			model.user_sex=user_sex;
			model.user_nikeName=user_nikeName;
			model.user_photo=user_photo;
			model.user_birthday=user_birthday;
			model.user_height=user_height;
			model.user_weight=user_weight;
			model.user_address=user_address;
			model.user_job=user_job;
			model.user_income=user_income;
			model.user_pwd=user_pwd;
			model.user_marrystate=user_marrystate;
			model.user_edu=user_edu;
			model.personcenter_bg=personcenter_bg;
			model.user_photo_state=user_photo_state;
			model.user_state=user_state;

			la.BLL.user_tb bll=new la.BLL.user_tb();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
