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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int audio_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					audio_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(audio_id,user_telphone);
			}
		}
			
	private void ShowInfo(int audio_id,string user_telphone)
	{
		la.BLL.audio bll=new la.BLL.audio();
		la.Model.audio model=bll.GetModel(audio_id,user_telphone);
		this.lblaudio_id.Text=model.audio_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtaudio_url.Text=model.audio_url;
		this.txtaudio_time.Text=model.audio_time.ToString();
		this.txtaudio_comment.Text=model.audio_comment;
		this.txtaudio_state.Text=model.audio_state;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			int audio_id=int.Parse(this.lblaudio_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
