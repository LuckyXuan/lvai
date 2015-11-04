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
namespace la.Web.wealthindex
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtwealthindex_ID.Text))
			{
				strErr+="财富指数ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtwealthindex_changevalue.Text))
			{
				strErr+="财富指数变化值格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtwealthindex_time.Text))
			{
				strErr+="财富指数变化时间格式错误！\\n";	
			}
			if(this.txtwealthindex_comment.Text.Trim().Length==0)
			{
				strErr+="财富指数变化说明不能为空！\\n";	
			}
			if(this.txtwealthindex_changetype.Text.Trim().Length==0)
			{
				strErr+="财富指数变化类型不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtwealthindex_result.Text))
			{
				strErr+="财富指数结果格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int wealthindex_ID=int.Parse(this.txtwealthindex_ID.Text);
			string user_telphone=this.txtuser_telphone.Text;
			decimal wealthindex_changevalue=decimal.Parse(this.txtwealthindex_changevalue.Text);
			DateTime wealthindex_time=DateTime.Parse(this.txtwealthindex_time.Text);
			string wealthindex_comment=this.txtwealthindex_comment.Text;
			string wealthindex_changetype=this.txtwealthindex_changetype.Text;
			decimal wealthindex_result=decimal.Parse(this.txtwealthindex_result.Text);

			la.Model.wealthindex model=new la.Model.wealthindex();
			model.wealthindex_ID=wealthindex_ID;
			model.user_telphone=user_telphone;
			model.wealthindex_changevalue=wealthindex_changevalue;
			model.wealthindex_time=wealthindex_time;
			model.wealthindex_comment=wealthindex_comment;
			model.wealthindex_changetype=wealthindex_changetype;
			model.wealthindex_result=wealthindex_result;

			la.BLL.wealthindex bll=new la.BLL.wealthindex();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
