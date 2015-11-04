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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtlooksindex_id.Text))
			{
				strErr+="容貌指数ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int looksindex_id=int.Parse(this.txtlooksindex_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
