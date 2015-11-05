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
namespace la.Web.travel
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
					int travle_ID=(Convert.ToInt32(strid));
					ShowInfo(travle_ID);
				}
			}
		}
		
	private void ShowInfo(int travle_ID)
	{
		la.BLL.travel bll=new la.BLL.travel();
		la.Model.travel model=bll.GetModel(travle_ID);
		this.lbltravle_ID.Text=model.travle_ID.ToString();
		this.lblpromoter_userid.Text=model.promoter_userid.ToString();
		this.lblrelease_time.Text=model.release_time.ToString();
		this.lblDestination.Text=model.Destination;
		this.lblstartplace.Text=model.startplace;
		this.lblreturn_time.Text=model.return_time.ToString();
		this.lblstart_time.Text=model.start_time.ToString();
		this.lbltransportation.Text=model.transportation;
		this.lblfee.Text=model.fee;
		this.lbltravle_theme.Text=model.travle_theme;
		this.lbltravle_personcount.Text=model.travle_personcount.ToString();
		this.lblcompanion_condition.Text=model.companion_condition;
		this.lbltravle_msg.Text=model.travle_msg;
		this.lblpic1.Text=model.pic1;
		this.lblpic2.Text=model.pic2;
		this.lblpic3.Text=model.pic3;
		this.lblincome_condition.Text=model.income_condition;
		this.lblcar_condition.Text=model.car_condition;
		this.lblheight_condition.Text=model.height_condition;
		this.lblcredit_condition.Text=model.credit_condition;
		this.lblwantget_gift.Text=model.wantget_gift;
		this.lblwantsend_gift.Text=model.wantsend_gift;
		this.lblreg_fee.Text=model.reg_fee.ToString();

	}


    }
}
