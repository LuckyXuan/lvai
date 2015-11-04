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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int wealthindex_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					wealthindex_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(wealthindex_ID,user_telphone);
			}
		}
			
	private void ShowInfo(int wealthindex_ID,string user_telphone)
	{
		la.BLL.wealthindex bll=new la.BLL.wealthindex();
		la.Model.wealthindex model=bll.GetModel(wealthindex_ID,user_telphone);
		this.lblwealthindex_ID.Text=model.wealthindex_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtwealthindex_changevalue.Text=model.wealthindex_changevalue.ToString();
		this.txtwealthindex_time.Text=model.wealthindex_time.ToString();
		this.txtwealthindex_comment.Text=model.wealthindex_comment;
		this.txtwealthindex_changetype.Text=model.wealthindex_changetype;
		this.txtwealthindex_result.Text=model.wealthindex_result.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			int wealthindex_ID=int.Parse(this.lblwealthindex_ID.Text);
			string user_telphone=this.lbluser_telphone.Text;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
