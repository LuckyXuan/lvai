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
namespace la.Web.carInfo
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int car_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					car_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(car_id,user_telphone);
			}
		}
		
	private void ShowInfo(int car_id,string user_telphone)
	{
		la.BLL.carInfo bll=new la.BLL.carInfo();
		la.Model.carInfo model=bll.GetModel(car_id,user_telphone);
		this.lblcar_id.Text=model.car_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblcar_level.Text=model.car_level;
		this.lblcar_brand.Text=model.car_brand;
		this.lblcar_type.Text=model.car_type;
		this.lblcar_photo1.Text=model.car_photo1;
		this.lblcar_photo2.Text=model.car_photo2;
		this.lblcar_photo3.Text=model.car_photo3;
		this.lblcar_photo1_state.Text=model.car_photo1_state;
		this.lblcar_photo2_state.Text=model.car_photo2_state;
		this.lblcar_photo3_state.Text=model.car_photo3_state;

	}


    }
}
