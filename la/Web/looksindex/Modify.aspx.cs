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
namespace la.Web.looksindex
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int looksindex_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					looksindex_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(looksindex_id,user_telphone);
			}
		}
			
	private void ShowInfo(int looksindex_id,string user_telphone)
	{
		la.BLL.looksindex bll=new la.BLL.looksindex();
		la.Model.looksindex model=bll.GetModel(looksindex_id,user_telphone);
		this.lbllooksindex_id.Text=model.looksindex_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtlooksindex_change_value.Text=model.looksindex_change_value.ToString();
		this.txtlooksindex_change_time.Text=model.looksindex_change_time.ToString();
		this.txtlooksindex_change_comment.Text=model.looksindex_change_comment;
		this.txtlooksindex_result.Text=model.looksindex_result.ToString();
		this.txtlooksindex_change_type.Text=model.looksindex_change_type;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDecimal(txtlooksindex_change_value.Text))
			{
				strErr+="容貌指数变化值格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlooksindex_change_time.Text))
			{
				strErr+="容貌指数变化时间格式错误！\\n";	
			}
			if(this.txtlooksindex_change_comment.Text.Trim().Length==0)
			{
				strErr+="容貌指数变化说明不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtlooksindex_result.Text))
			{
				strErr+="容貌指数结果格式错误！\\n";	
			}
			if(this.txtlooksindex_change_type.Text.Trim().Length==0)
			{
				strErr+="容貌指数变化类型不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int looksindex_id=int.Parse(this.lbllooksindex_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			decimal looksindex_change_value=decimal.Parse(this.txtlooksindex_change_value.Text);
			DateTime looksindex_change_time=DateTime.Parse(this.txtlooksindex_change_time.Text);
			string looksindex_change_comment=this.txtlooksindex_change_comment.Text;
			decimal looksindex_result=decimal.Parse(this.txtlooksindex_result.Text);
			string looksindex_change_type=this.txtlooksindex_change_type.Text;


			la.Model.looksindex model=new la.Model.looksindex();
			model.looksindex_id=looksindex_id;
			model.user_telphone=user_telphone;
			model.looksindex_change_value=looksindex_change_value;
			model.looksindex_change_time=looksindex_change_time;
			model.looksindex_change_comment=looksindex_change_comment;
			model.looksindex_result=looksindex_result;
			model.looksindex_change_type=looksindex_change_type;

			la.BLL.looksindex bll=new la.BLL.looksindex();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
