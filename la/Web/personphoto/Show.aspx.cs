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
namespace la.Web.personphoto
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblpersonphoto_path.Text=model.personphoto_path;

	}


    }
}
