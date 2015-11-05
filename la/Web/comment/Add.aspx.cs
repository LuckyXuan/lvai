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
namespace la.Web.comment
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txt评价编号.Text))
			{
				strErr+="评价编号格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttravle_ID.Text))
			{
				strErr+="旅行ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txt评价字典编号.Text))
			{
				strErr+="评价字典编号格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txt评价时间.Text))
			{
				strErr+="评价时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int 评价编号=int.Parse(this.txt评价编号.Text);
			int travle_ID=int.Parse(this.txttravle_ID.Text);
			string user_telphone=this.txtuser_telphone.Text;
			int 评价字典编号=int.Parse(this.txt评价字典编号.Text);
			DateTime 评价时间=DateTime.Parse(this.txt评价时间.Text);

			la.Model.comment model=new la.Model.comment();
			model.评价编号=评价编号;
			model.travle_ID=travle_ID;
			model.user_telphone=user_telphone;
			model.评价字典编号=评价字典编号;
			model.评价时间=评价时间;

			la.BLL.comment bll=new la.BLL.comment();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
