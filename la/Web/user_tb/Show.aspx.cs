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
namespace la.Web.user_tb
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
					string user_telphone= strid;
					ShowInfo(user_telphone);
				}
			}
		}
		
	private void ShowInfo(string user_telphone)
	{
		la.BLL.user_tb bll=new la.BLL.user_tb();
		la.Model.user_tb model=bll.GetModel(user_telphone);
		this.lbluser_telphone.Text=model.user_telphone;
		this.lbluser_sex.Text=model.user_sex?"是":"否";
		this.lbluser_nikeName.Text=model.user_nikeName;
		this.lbluser_photo.Text=model.user_photo;
		this.lbluser_birthday.Text=model.user_birthday.ToString();
		this.lbluser_height.Text=model.user_height;
		this.lbluser_weight.Text=model.user_weight;
		this.lbluser_address.Text=model.user_address;
		this.lbluser_job.Text=model.user_job;
		this.lbluser_income.Text=model.user_income;
		this.lbluser_pwd.Text=model.user_pwd;
		this.lbluser_marrystate.Text=model.user_marrystate;
		this.lbluser_edu.Text=model.user_edu;
		this.lblpersoncenter_bg.Text=model.personcenter_bg;
		this.lbluser_photo_state.Text=model.user_photo_state;
		this.lbluser_state.Text=model.user_state;

	}


    }
}
