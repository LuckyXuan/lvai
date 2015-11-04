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
namespace la.Web.log
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int log_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					log_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(log_id,user_telphone);
			}
		}
			
	private void ShowInfo(int log_id,string user_telphone)
	{
		la.BLL.log bll=new la.BLL.log();
		la.Model.log model=bll.GetModel(log_id,user_telphone);
		this.lbllog_id.Text=model.log_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtlog_ip.Text=model.log_ip;
		this.txtlog_time.Text=model.log_time.ToString();
		this.txtLAT.Text=model.LAT.ToString();
		this.txtLNG.Text=model.LNG.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtlog_ip.Text.Trim().Length==0)
			{
				strErr+="登录IP不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlog_time.Text))
			{
				strErr+="登录时间格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtLAT.Text))
			{
				strErr+="LAT格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtLNG.Text))
			{
				strErr+="LNG格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int log_id=int.Parse(this.lbllog_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			string log_ip=this.txtlog_ip.Text;
			DateTime log_time=DateTime.Parse(this.txtlog_time.Text);
			decimal LAT=decimal.Parse(this.txtLAT.Text);
			decimal LNG=decimal.Parse(this.txtLNG.Text);


			la.Model.log model=new la.Model.log();
			model.log_id=log_id;
			model.user_telphone=user_telphone;
			model.log_ip=log_ip;
			model.log_time=log_time;
			model.LAT=LAT;
			model.LNG=LNG;

			la.BLL.log bll=new la.BLL.log();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
