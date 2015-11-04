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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int 评价编号 = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					评价编号=(Convert.ToInt32(Request.Params["id0"]));
				}
				int travle_ID = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					travle_ID=(Convert.ToInt32(Request.Params["id1"]));
				}
				string user_telphone = "";
				if (Request.Params["id2"] != null && Request.Params["id2"].Trim() != "")
				{
					user_telphone= Request.Params["id2"];
				}
				int 评价字典编号 = -1;
				if (Request.Params["id3"] != null && Request.Params["id3"].Trim() != "")
				{
					评价字典编号=(Convert.ToInt32(Request.Params["id3"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(评价编号,travle_ID,user_telphone,评价字典编号);
			}
		}
			
	private void ShowInfo(int 评价编号,int travle_ID,string user_telphone,int 评价字典编号)
	{
		la.BLL.comment bll=new la.BLL.comment();
		la.Model.comment model=bll.GetModel(评价编号,travle_ID,user_telphone,评价字典编号);
		this.lbl评价编号.Text=model.评价编号.ToString();
		this.lbltravle_ID.Text=model.travle_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lbl评价字典编号.Text=model.评价字典编号.ToString();
		this.txt评价时间.Text=model.评价时间.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txt评价时间.Text))
			{
				strErr+="评价时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int 评价编号=int.Parse(this.lbl评价编号.Text);
			int travle_ID=int.Parse(this.lbltravle_ID.Text);
			string user_telphone=this.lbluser_telphone.Text;
			int 评价字典编号=int.Parse(this.lbl评价字典编号.Text);
			DateTime 评价时间=DateTime.Parse(this.txt评价时间.Text);


			la.Model.comment model=new la.Model.comment();
			model.评价编号=评价编号;
			model.travle_ID=travle_ID;
			model.user_telphone=user_telphone;
			model.评价字典编号=评价字典编号;
			model.评价时间=评价时间;

			la.BLL.comment bll=new la.BLL.comment();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
