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
namespace la.Web.virtualgoods
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int virtualgoods_ID=(Convert.ToInt32(strid));
					ShowInfo(virtualgoods_ID);
				}
			}
		}
		
	private void ShowInfo(int virtualgoods_ID)
	{
		la.BLL.virtualgoods bll=new la.BLL.virtualgoods();
		la.Model.virtualgoods model=bll.GetModel(virtualgoods_ID);
		this.lblvirtualgoods_ID.Text=model.virtualgoods_ID.ToString();
		this.lblvirtualgoods_name.Text=model.virtualgoods_name;
		this.lblvirtualgoods_price.Text=model.virtualgoods_price.ToString();
		this.lblvirtualgoods_comment.Text=model.virtualgoods_comment;
		this.lblvirtualgoods_pic_url.Text=model.virtualgoods_pic_url;
		this.lblvirtualgoods_type.Text=model.virtualgoods_type;
		this.lblvirtualgoods_fun.Text=model.virtualgoods_fun;

	}


    }
}
