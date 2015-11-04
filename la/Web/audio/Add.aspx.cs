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
namespace la.Web.audio
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtaudio_id.Text))
			{
				strErr+="音频ID格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
			if(this.txtaudio_url.Text.Trim().Length==0)
			{
				strErr+="音频路径不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtaudio_time.Text))
			{
				strErr+="上传时间格式错误！\\n";	
			}
			if(this.txtaudio_comment.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
			}
			if(this.txtaudio_state.Text.Trim().Length==0)
			{
				strErr+="审核状态不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int audio_id=int.Parse(this.txtaudio_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
			string audio_url=this.txtaudio_url.Text;
			DateTime audio_time=DateTime.Parse(this.txtaudio_time.Text);
			string audio_comment=this.txtaudio_comment.Text;
			string audio_state=this.txtaudio_state.Text;

			la.Model.audio model=new la.Model.audio();
			model.audio_id=audio_id;
			model.user_telphone=user_telphone;
			model.audio_url=audio_url;
			model.audio_time=audio_time;
			model.audio_comment=audio_comment;
			model.audio_state=audio_state;

			la.BLL.audio bll=new la.BLL.audio();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
