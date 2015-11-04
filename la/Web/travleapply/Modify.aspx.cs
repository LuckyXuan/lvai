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
namespace la.Web.travleapply
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int travleapply_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					travleapply_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				int travle_ID = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					travle_ID=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(travleapply_ID,travle_ID);
			}
		}
			
	private void ShowInfo(int travleapply_ID,int travle_ID)
	{
		la.BLL.travleapply bll=new la.BLL.travleapply();
		la.Model.travleapply model=bll.GetModel(travleapply_ID,travle_ID);
		this.lbltravleapply_ID.Text=model.travleapply_ID.ToString();
		this.lbltravle_ID.Text=model.travle_ID.ToString();
		this.txtapplyer_ID.Text=model.applyer_ID.ToString();
		this.txtapply_time.Text=model.apply_time.ToString();
		this.txtapply_state.Text=model.apply_state;
		this.txtapply_msg.Text=model.apply_msg;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtapplyer_ID.Text))
			{
				strErr+="申请人ID格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtapply_time.Text))
			{
				strErr+="申请时间格式错误！\\n";	
			}
			if(this.txtapply_state.Text.Trim().Length==0)
			{
				strErr+="匹配状态不能为空！\\n";	
			}
			if(this.txtapply_msg.Text.Trim().Length==0)
			{
				strErr+="申请留言不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int travleapply_ID=int.Parse(this.lbltravleapply_ID.Text);
			int travle_ID=int.Parse(this.lbltravle_ID.Text);
			int applyer_ID=int.Parse(this.txtapplyer_ID.Text);
			DateTime apply_time=DateTime.Parse(this.txtapply_time.Text);
			string apply_state=this.txtapply_state.Text;
			string apply_msg=this.txtapply_msg.Text;


			la.Model.travleapply model=new la.Model.travleapply();
			model.travleapply_ID=travleapply_ID;
			model.travle_ID=travle_ID;
			model.applyer_ID=applyer_ID;
			model.apply_time=apply_time;
			model.apply_state=apply_state;
			model.apply_msg=apply_msg;

			la.BLL.travleapply bll=new la.BLL.travleapply();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
