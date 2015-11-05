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
namespace la.Web.signlog
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtsign_id.Text))
			{
				strErr+="签到编号格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtsign_time.Text))
			{
				strErr+="签到时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int sign_id=int.Parse(this.txtsign_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
			DateTime sign_time=DateTime.Parse(this.txtsign_time.Text);

			la.Model.signlog model=new la.Model.signlog();
			model.sign_id=sign_id;
			model.user_telphone=user_telphone;
			model.sign_time=sign_time;

			la.BLL.signlog bll=new la.BLL.signlog();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
