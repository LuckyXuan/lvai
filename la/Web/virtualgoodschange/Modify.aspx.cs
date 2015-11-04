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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int virtualgoodschange_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					virtualgoodschange_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				int virtualgoods_ID = -1;
				if (Request.Params["id2"] != null && Request.Params["id2"].Trim() != "")
				{
					virtualgoods_ID=(Convert.ToInt32(Request.Params["id2"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(virtualgoodschange_ID,user_telphone,virtualgoods_ID);
			}
		}
			
	private void ShowInfo(int virtualgoodschange_ID,string user_telphone,int virtualgoods_ID)
	{
		la.BLL.virtualgoodschange bll=new la.BLL.virtualgoodschange();
		la.Model.virtualgoodschange model=bll.GetModel(virtualgoodschange_ID,user_telphone,virtualgoods_ID);
		this.lblvirtualgoodschange_ID.Text=model.virtualgoodschange_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblvirtualgoods_ID.Text=model.virtualgoods_ID.ToString();
		this.txtvirtualgoodschange_count.Text=model.virtualgoodschange_count.ToString();
		this.txtvirtualgoodschange_time.Text=model.virtualgoodschange_time.ToString();
		this.txtvirtualgoodschange_comment.Text=model.virtualgoodschange_comment;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			int virtualgoodschange_ID=int.Parse(this.lblvirtualgoodschange_ID.Text);
			string user_telphone=this.lbluser_telphone.Text;
			int virtualgoods_ID=int.Parse(this.lblvirtualgoods_ID.Text);
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
