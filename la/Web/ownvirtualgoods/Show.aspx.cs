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
namespace la.Web.ownvirtualgoods
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int property_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					property_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				int virtualgoods_ID = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					virtualgoods_ID=(Convert.ToInt32(Request.Params["id1"]));
				}
				string user_telphone = "";
				if (Request.Params["id2"] != null && Request.Params["id2"].Trim() != "")
				{
					user_telphone= Request.Params["id2"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(property_ID,virtualgoods_ID,user_telphone);
			}
		}
		
	private void ShowInfo(int property_ID,int virtualgoods_ID,string user_telphone)
	{
		la.BLL.ownvirtualgoods bll=new la.BLL.ownvirtualgoods();
		la.Model.ownvirtualgoods model=bll.GetModel(property_ID,virtualgoods_ID,user_telphone);
		this.lblproperty_ID.Text=model.property_ID.ToString();
		this.lblvirtualgoods_ID.Text=model.virtualgoods_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblproperty_count.Text=model.property_count.ToString();

	}


    }
}
