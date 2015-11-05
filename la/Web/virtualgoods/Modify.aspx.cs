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
namespace la.Web.virtualgoods
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int virtualgoods_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(virtualgoods_ID);
				}
			}
		}
			
	private void ShowInfo(int virtualgoods_ID)
	{
		la.BLL.virtualgoods bll=new la.BLL.virtualgoods();
		la.Model.virtualgoods model=bll.GetModel(virtualgoods_ID);
		this.lblvirtualgoods_ID.Text=model.virtualgoods_ID.ToString();
		this.txtvirtualgoods_name.Text=model.virtualgoods_name;
		this.txtvirtualgoods_price.Text=model.virtualgoods_price.ToString();
		this.txtvirtualgoods_comment.Text=model.virtualgoods_comment;
		this.txtvirtualgoods_pic_url.Text=model.virtualgoods_pic_url;
		this.txtvirtualgoods_type.Text=model.virtualgoods_type;
		this.txtvirtualgoods_fun.Text=model.virtualgoods_fun;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtvirtualgoods_name.Text.Trim().Length==0)
			{
				strErr+="虚拟物品名称不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtvirtualgoods_price.Text))
			{
				strErr+="虚拟物品价格格式错误！\\n";	
			}
			if(this.txtvirtualgoods_comment.Text.Trim().Length==0)
			{
				strErr+="虚拟物品说明不能为空！\\n";	
			}
			if(this.txtvirtualgoods_pic_url.Text.Trim().Length==0)
			{
				strErr+="虚拟物品图片不能为空！\\n";	
			}
			if(this.txtvirtualgoods_type.Text.Trim().Length==0)
			{
				strErr+="虚拟物品类别不能为空！\\n";	
			}
			if(this.txtvirtualgoods_fun.Text.Trim().Length==0)
			{
				strErr+="虚拟物品功能不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int virtualgoods_ID=int.Parse(this.lblvirtualgoods_ID.Text);
			string virtualgoods_name=this.txtvirtualgoods_name.Text;
			decimal virtualgoods_price=decimal.Parse(this.txtvirtualgoods_price.Text);
			string virtualgoods_comment=this.txtvirtualgoods_comment.Text;
			string virtualgoods_pic_url=this.txtvirtualgoods_pic_url.Text;
			string virtualgoods_type=this.txtvirtualgoods_type.Text;
			string virtualgoods_fun=this.txtvirtualgoods_fun.Text;


			la.Model.virtualgoods model=new la.Model.virtualgoods();
			model.virtualgoods_ID=virtualgoods_ID;
			model.virtualgoods_name=virtualgoods_name;
			model.virtualgoods_price=virtualgoods_price;
			model.virtualgoods_comment=virtualgoods_comment;
			model.virtualgoods_pic_url=virtualgoods_pic_url;
			model.virtualgoods_type=virtualgoods_type;
			model.virtualgoods_fun=virtualgoods_fun;

			la.BLL.virtualgoods bll=new la.BLL.virtualgoods();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
