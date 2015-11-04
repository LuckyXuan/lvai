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
namespace la.Web.signlog
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int sign_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					sign_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(sign_id,user_telphone);
			}
		}
			
	private void ShowInfo(int sign_id,string user_telphone)
	{
		la.BLL.signlog bll=new la.BLL.signlog();
		la.Model.signlog model=bll.GetModel(sign_id,user_telphone);
		this.lblsign_id.Text=model.sign_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtsign_time.Text=model.sign_time.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtsign_time.Text))
			{
				strErr+="签到时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int sign_id=int.Parse(this.lblsign_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			DateTime sign_time=DateTime.Parse(this.txtsign_time.Text);


			la.Model.signlog model=new la.Model.signlog();
			model.sign_id=sign_id;
			model.user_telphone=user_telphone;
			model.sign_time=sign_time;

			la.BLL.signlog bll=new la.BLL.signlog();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
