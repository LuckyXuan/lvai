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
namespace la.Web.virtualgoodschange
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtvirtualgoodschange_ID.Text))
			{
				strErr+="虚拟物品变化记录ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtvirtualgoods_ID.Text))
			{
				strErr+="虚拟物品ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtvirtualgoodschange_count.Text))
			{
				strErr+="虚拟物品变化记录数量格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtvirtualgoodschange_time.Text))
			{
				strErr+="虚拟物品变化时间格式错误！\\n";	
			}
			if(this.txtvirtualgoodschange_comment.Text.Trim().Length==0)
			{
				strErr+="虚拟物品变化记录说明不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int virtualgoodschange_ID=int.Parse(this.txtvirtualgoodschange_ID.Text);
			string user_telphone=this.txtuser_telphone.Text;
			int virtualgoods_ID=int.Parse(this.txtvirtualgoods_ID.Text);
			int virtualgoodschange_count=int.Parse(this.txtvirtualgoodschange_count.Text);
			DateTime virtualgoodschange_time=DateTime.Parse(this.txtvirtualgoodschange_time.Text);
			string virtualgoodschange_comment=this.txtvirtualgoodschange_comment.Text;

			la.Model.virtualgoodschange model=new la.Model.virtualgoodschange();
			model.virtualgoodschange_ID=virtualgoodschange_ID;
			model.user_telphone=user_telphone;
			model.virtualgoods_ID=virtualgoods_ID;
			model.virtualgoodschange_count=virtualgoodschange_count;
			model.virtualgoodschange_time=virtualgoodschange_time;
			model.virtualgoodschange_comment=virtualgoodschange_comment;

			la.BLL.virtualgoodschange bll=new la.BLL.virtualgoodschange();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
