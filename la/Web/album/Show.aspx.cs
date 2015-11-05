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
namespace la.Web.album
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblalbum_time.Text=model.album_time.ToString();
		this.lblalbum_comment.Text=model.album_comment;
		this.lblalbum_isvalid.Text=model.album_isvalid?"是":"否";
		this.lblalbum_isprivate.Text=model.album_isprivate?"是":"否";

	}


    }
}
