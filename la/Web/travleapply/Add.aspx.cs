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
namespace la.Web.travleapply
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txttravleapply_ID.Text))
			{
				strErr+="申请ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttravle_ID.Text))
			{
				strErr+="旅行ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtapplyer_ID.Text))
			{
				strErr+="申请人ID格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtapply_time.Text))
			{
				strErr+="申请时间格式错误！\\n";	
			}
			if(this.txtapply_state.Text.Trim().Length==0)
			{
				strErr+="匹配状态不能为空！\\n";	
			}
			if(this.txtapply_msg.Text.Trim().Length==0)
			{
				strErr+="申请留言不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int travleapply_ID=int.Parse(this.txttravleapply_ID.Text);
			int travle_ID=int.Parse(this.txttravle_ID.Text);
			int applyer_ID=int.Parse(this.txtapplyer_ID.Text);
			DateTime apply_time=DateTime.Parse(this.txtapply_time.Text);
			string apply_state=this.txtapply_state.Text;
			string apply_msg=this.txtapply_msg.Text;

			la.Model.travleapply model=new la.Model.travleapply();
			model.travleapply_ID=travleapply_ID;
			model.travle_ID=travle_ID;
			model.applyer_ID=applyer_ID;
			model.apply_time=apply_time;
			model.apply_state=apply_state;
			model.apply_msg=apply_msg;

			la.BLL.travleapply bll=new la.BLL.travleapply();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
