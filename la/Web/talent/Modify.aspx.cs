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
namespace la.Web.talent
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int talent_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					talent_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(talent_ID,user_telphone);
			}
		}
			
	private void ShowInfo(int talent_ID,string user_telphone)
	{
		la.BLL.talent bll=new la.BLL.talent();
		la.Model.talent model=bll.GetModel(talent_ID,user_telphone);
		this.lbltalent_ID.Text=model.talent_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txttalent_change_value.Text=model.talent_change_value.ToString();
		this.txttalent_change_comment.Text=model.talent_change_comment;
		this.txttalent_change_time.Text=model.talent_change_time.ToString();
		this.txttalent_change_type.Text=model.talent_change_type;
		this.txttalent_result.Text=model.talent_result.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDecimal(txttalent_change_value.Text))
			{
				strErr+="才艺指数变化值格式错误！\\n";	
			}
			if(this.txttalent_change_comment.Text.Trim().Length==0)
			{
				strErr+="才艺指数变化说明不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txttalent_change_time.Text))
			{
				strErr+="才艺指数变化时间格式错误！\\n";	
			}
			if(this.txttalent_change_type.Text.Trim().Length==0)
			{
				strErr+="才艺指数变化类型不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txttalent_result.Text))
			{
				strErr+="才艺指数结果格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int talent_ID=int.Parse(this.lbltalent_ID.Text);
			string user_telphone=this.lbluser_telphone.Text;
			decimal talent_change_value=decimal.Parse(this.txttalent_change_value.Text);
			string talent_change_comment=this.txttalent_change_comment.Text;
			DateTime talent_change_time=DateTime.Parse(this.txttalent_change_time.Text);
			string talent_change_type=this.txttalent_change_type.Text;
			decimal talent_result=decimal.Parse(this.txttalent_result.Text);


			la.Model.talent model=new la.Model.talent();
			model.talent_ID=talent_ID;
			model.user_telphone=user_telphone;
			model.talent_change_value=talent_change_value;
			model.talent_change_comment=talent_change_comment;
			model.talent_change_time=talent_change_time;
			model.talent_change_type=talent_change_type;
			model.talent_result=talent_result;

			la.BLL.talent bll=new la.BLL.talent();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
