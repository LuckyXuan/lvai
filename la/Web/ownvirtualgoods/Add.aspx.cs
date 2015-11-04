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
namespace la.Web.ownvirtualgoods
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtproperty_ID.Text))
			{
				strErr+="财产ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtvirtualgoods_ID.Text))
			{
				strErr+="虚拟物品ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtproperty_count.Text))
			{
				strErr+="财产数量格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int property_ID=int.Parse(this.txtproperty_ID.Text);
			int virtualgoods_ID=int.Parse(this.txtvirtualgoods_ID.Text);
			string user_telphone=this.txtuser_telphone.Text;
			int property_count=int.Parse(this.txtproperty_count.Text);

			la.Model.ownvirtualgoods model=new la.Model.ownvirtualgoods();
			model.property_ID=property_ID;
			model.virtualgoods_ID=virtualgoods_ID;
			model.user_telphone=user_telphone;
			model.property_count=property_count;

			la.BLL.ownvirtualgoods bll=new la.BLL.ownvirtualgoods();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
