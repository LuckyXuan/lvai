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
namespace la.Web.personphoto
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int personphoto_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					personphoto_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				int album_id = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					album_id=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(personphoto_id,album_id);
			}
		}
			
	private void ShowInfo(int personphoto_id,int album_id)
	{
		la.BLL.personphoto bll=new la.BLL.personphoto();
		la.Model.personphoto model=bll.GetModel(personphoto_id,album_id);
		this.lblpersonphoto_id.Text=model.personphoto_id.ToString();
		this.lblalbum_id.Text=model.album_id.ToString();
		this.txtpersonphoto_path.Text=model.personphoto_path;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtpersonphoto_path.Text.Trim().Length==0)
			{
				strErr+="相片路径不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int personphoto_id=int.Parse(this.lblpersonphoto_id.Text);
			int album_id=int.Parse(this.lblalbum_id.Text);
			string personphoto_path=this.txtpersonphoto_path.Text;


			la.Model.personphoto model=new la.Model.personphoto();
			model.personphoto_id=personphoto_id;
			model.album_id=album_id;
			model.personphoto_path=personphoto_path;

			la.BLL.personphoto bll=new la.BLL.personphoto();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
