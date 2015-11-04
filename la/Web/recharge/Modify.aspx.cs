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
namespace la.Web.recharge
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int recharge_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					recharge_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(recharge_ID,user_telphone);
			}
		}
			
	private void ShowInfo(int recharge_ID,string user_telphone)
	{
		la.BLL.recharge bll=new la.BLL.recharge();
		la.Model.recharge model=bll.GetModel(recharge_ID,user_telphone);
		this.lblrecharge_ID.Text=model.recharge_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtrecharge_plat.Text=model.recharge_plat;
		this.txtrecharge_money.Text=model.recharge_money.ToString();
		this.txtrecharge_time.Text=model.recharge_time.ToString();
		this.txtrecharge_code.Text=model.recharge_code;
		this.txtrecharge_comment.Text=model.recharge_comment;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtrecharge_plat.Text.Trim().Length==0)
			{
				strErr+="充值平台不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtrecharge_money.Text))
			{
				strErr+="充值金额格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtrecharge_time.Text))
			{
				strErr+="充值时间格式错误！\\n";	
			}
			if(this.txtrecharge_code.Text.Trim().Length==0)
			{
				strErr+="交易编码不能为空！\\n";	
			}
			if(this.txtrecharge_comment.Text.Trim().Length==0)
			{
				strErr+="充值说明不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int recharge_ID=int.Parse(this.lblrecharge_ID.Text);
			string user_telphone=this.lbluser_telphone.Text;
			string recharge_plat=this.txtrecharge_plat.Text;
			decimal recharge_money=decimal.Parse(this.txtrecharge_money.Text);
			DateTime recharge_time=DateTime.Parse(this.txtrecharge_time.Text);
			string recharge_code=this.txtrecharge_code.Text;
			string recharge_comment=this.txtrecharge_comment.Text;


			la.Model.recharge model=new la.Model.recharge();
			model.recharge_ID=recharge_ID;
			model.user_telphone=user_telphone;
			model.recharge_plat=recharge_plat;
			model.recharge_money=recharge_money;
			model.recharge_time=recharge_time;
			model.recharge_code=recharge_code;
			model.recharge_comment=recharge_comment;

			la.BLL.recharge bll=new la.BLL.recharge();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
