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
namespace la.Web.album
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int album_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					album_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(album_id,user_telphone);
			}
		}
			
	private void ShowInfo(int album_id,string user_telphone)
	{
		la.BLL.album bll=new la.BLL.album();
		la.Model.album model=bll.GetModel(album_id,user_telphone);
		this.lblalbum_id.Text=model.album_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtalbum_time.Text=model.album_time.ToString();
		this.txtalbum_comment.Text=model.album_comment;
		this.chkalbum_isvalid.Checked=model.album_isvalid;
		this.chkalbum_isprivate.Checked=model.album_isprivate;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtalbum_time.Text))
			{
				strErr+="相册上传时间格式错误！\\n";	
			}
			if(this.txtalbum_comment.Text.Trim().Length==0)
			{
				strErr+="相册说明不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int album_id=int.Parse(this.lblalbum_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			DateTime album_time=DateTime.Parse(this.txtalbum_time.Text);
			string album_comment=this.txtalbum_comment.Text;
			bool album_isvalid=this.chkalbum_isvalid.Checked;
			bool album_isprivate=this.chkalbum_isprivate.Checked;


			la.Model.album model=new la.Model.album();
			model.album_id=album_id;
			model.user_telphone=user_telphone;
			model.album_time=album_time;
			model.album_comment=album_comment;
			model.album_isvalid=album_isvalid;
			model.album_isprivate=album_isprivate;

			la.BLL.album bll=new la.BLL.album();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
