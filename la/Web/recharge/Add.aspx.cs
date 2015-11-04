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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtrecharge_ID.Text))
			{
				strErr+="充值ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int recharge_ID=int.Parse(this.txtrecharge_ID.Text);
			string user_telphone=this.txtuser_telphone.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
