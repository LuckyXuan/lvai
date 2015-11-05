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
namespace la.Web.VIP
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int VIPID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					VIPID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(VIPID,user_telphone);
			}
		}
			
	private void ShowInfo(int VIPID,string user_telphone)
	{
		la.BLL.VIP bll=new la.BLL.VIP();
		la.Model.VIP model=bll.GetModel(VIPID,user_telphone);
		this.lblVIPID.Text=model.VIPID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtVIP_change_credit.Text=model.VIP_change_credit.ToString();
		this.txtVIP_change_comment.Text=model.VIP_change_comment;
		this.txtVIP_change_time.Text=model.VIP_change_time.ToString();
		this.txtVIP_credit.Text=model.VIP_credit.ToString();
		this.txtVIP_level.Text=model.VIP_level.ToString();
		this.txtVIP_change_type.Text=model.VIP_change_type;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDecimal(txtVIP_change_credit.Text))
			{
				strErr+="VIP变化积分格式错误！\\n";	
			}
			if(this.txtVIP_change_comment.Text.Trim().Length==0)
			{
				strErr+="VIP变化原因不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtVIP_change_time.Text))
			{
				strErr+="VIP变化时间格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtVIP_credit.Text))
			{
				strErr+="VIP积分值格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtVIP_level.Text))
			{
				strErr+="VIP变化后等级格式错误！\\n";	
			}
			if(this.txtVIP_change_type.Text.Trim().Length==0)
			{
				strErr+="VIP积分变化类型不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int VIPID=int.Parse(this.lblVIPID.Text);
			string user_telphone=this.lbluser_telphone.Text;
			decimal VIP_change_credit=decimal.Parse(this.txtVIP_change_credit.Text);
			string VIP_change_comment=this.txtVIP_change_comment.Text;
			DateTime VIP_change_time=DateTime.Parse(this.txtVIP_change_time.Text);
			decimal VIP_credit=decimal.Parse(this.txtVIP_credit.Text);
			int VIP_level=int.Parse(this.txtVIP_level.Text);
			string VIP_change_type=this.txtVIP_change_type.Text;


			la.Model.VIP model=new la.Model.VIP();
			model.VIPID=VIPID;
			model.user_telphone=user_telphone;
			model.VIP_change_credit=VIP_change_credit;
			model.VIP_change_comment=VIP_change_comment;
			model.VIP_change_time=VIP_change_time;
			model.VIP_credit=VIP_credit;
			model.VIP_level=VIP_level;
			model.VIP_change_type=VIP_change_type;

			la.BLL.VIP bll=new la.BLL.VIP();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
