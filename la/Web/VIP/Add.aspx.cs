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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtVIPID.Text))
			{
				strErr+="VIPID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int VIPID=int.Parse(this.txtVIPID.Text);
			string user_telphone=this.txtuser_telphone.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
