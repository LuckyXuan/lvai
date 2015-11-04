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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int video_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					video_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(video_ID,user_telphone);
			}
		}
			
	private void ShowInfo(int video_ID,string user_telphone)
	{
		la.BLL.video bll=new la.BLL.video();
		la.Model.video model=bll.GetModel(video_ID,user_telphone);
		this.lblvideo_ID.Text=model.video_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtvideo_url.Text=model.video_url;
		this.txtvideo_uploadtime.Text=model.video_uploadtime.ToString();
		this.txtvideo_comment.Text=model.video_comment;
		this.txtvideo_state.Text=model.video_state;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			int video_ID=int.Parse(this.lblvideo_ID.Text);
			string user_telphone=this.lbluser_telphone.Text;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
