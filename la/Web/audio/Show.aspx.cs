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
namespace la.Web.audio
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblaudio_url.Text=model.audio_url;
		this.lblaudio_time.Text=model.audio_time.ToString();
		this.lblaudio_comment.Text=model.audio_comment;
		this.lblaudio_state.Text=model.audio_state;

	}


    }
}
