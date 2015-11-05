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
namespace la.Web.log
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtlog_id.Text))
			{
				strErr+="日志编号格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(this.txtlog_ip.Text.Trim().Length==0)
			{
				strErr+="登录IP不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlog_time.Text))
			{
				strErr+="登录时间格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtLAT.Text))
			{
				strErr+="LAT格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtLNG.Text))
			{
				strErr+="LNG格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int log_id=int.Parse(this.txtlog_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
			string log_ip=this.txtlog_ip.Text;
			DateTime log_time=DateTime.Parse(this.txtlog_time.Text);
			decimal LAT=decimal.Parse(this.txtLAT.Text);
			decimal LNG=decimal.Parse(this.txtLNG.Text);

			la.Model.log model=new la.Model.log();
			model.log_id=log_id;
			model.user_telphone=user_telphone;
			model.log_ip=log_ip;
			model.log_time=log_time;
			model.LAT=LAT;
			model.LNG=LNG;

			la.BLL.log bll=new la.BLL.log();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
