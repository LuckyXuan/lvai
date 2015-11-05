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
namespace la.Web.video
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblvideo_url.Text=model.video_url;
		this.lblvideo_uploadtime.Text=model.video_uploadtime.ToString();
		this.lblvideo_comment.Text=model.video_comment;
		this.lblvideo_state.Text=model.video_state;

	}


    }
}
