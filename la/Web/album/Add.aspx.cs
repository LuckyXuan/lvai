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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtalbum_id.Text))
			{
				strErr+="相册_id格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int album_id=int.Parse(this.txtalbum_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
