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
namespace la.Web.video
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtvideo_ID.Text))
			{
				strErr+="视频ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(this.txtvideo_url.Text.Trim().Length==0)
			{
				strErr+="视频路径不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtvideo_uploadtime.Text))
			{
				strErr+="视频上传时间格式错误！\\n";	
			}
			if(this.txtvideo_comment.Text.Trim().Length==0)
			{
				strErr+="视频说明不能为空！\\n";	
			}
			if(this.txtvideo_state.Text.Trim().Length==0)
			{
				strErr+="视频审核状态不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int video_ID=int.Parse(this.txtvideo_ID.Text);
			string user_telphone=this.txtuser_telphone.Text;
			string video_url=this.txtvideo_url.Text;
			DateTime video_uploadtime=DateTime.Parse(this.txtvideo_uploadtime.Text);
			string video_comment=this.txtvideo_comment.Text;
			string video_state=this.txtvideo_state.Text;

			la.Model.video model=new la.Model.video();
			model.video_ID=video_ID;
			model.user_telphone=user_telphone;
			model.video_url=video_url;
			model.video_uploadtime=video_uploadtime;
			model.video_comment=video_comment;
			model.video_state=video_state;

			la.BLL.video bll=new la.BLL.video();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
