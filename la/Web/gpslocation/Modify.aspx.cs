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
namespace la.Web.gpslocation
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int gps_id = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					gps_id=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(gps_id,user_telphone);
			}
		}
			
	private void ShowInfo(int gps_id,string user_telphone)
	{
		la.BLL.gpslocation bll=new la.BLL.gpslocation();
		la.Model.gpslocation model=bll.GetModel(gps_id,user_telphone);
		this.lblgps_id.Text=model.gps_id.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.txtlocation_lat.Text=model.location_lat.ToString();
		this.txtlocation_lng.Text=model.location_lng.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDecimal(txtlocation_lat.Text))
			{
				strErr+="location_lat格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtlocation_lng.Text))
			{
				strErr+="location_lng格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int gps_id=int.Parse(this.lblgps_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			decimal location_lat=decimal.Parse(this.txtlocation_lat.Text);
			decimal location_lng=decimal.Parse(this.txtlocation_lng.Text);


			la.Model.gpslocation model=new la.Model.gpslocation();
			model.gps_id=gps_id;
			model.user_telphone=user_telphone;
			model.location_lat=location_lat;
			model.location_lng=location_lng;

			la.BLL.gpslocation bll=new la.BLL.gpslocation();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
