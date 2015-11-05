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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txttalent_ID.Text))
			{
				strErr+="才艺指数ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int talent_ID=int.Parse(this.txttalent_ID.Text);
			string user_telphone=this.txtuser_telphone.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
