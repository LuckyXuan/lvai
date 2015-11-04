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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtgps_id.Text))
			{
				strErr+="gps定位编码格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int gps_id=int.Parse(this.txtgps_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
			decimal location_lat=decimal.Parse(this.txtlocation_lat.Text);
			decimal location_lng=decimal.Parse(this.txtlocation_lng.Text);

			la.Model.gpslocation model=new la.Model.gpslocation();
			model.gps_id=gps_id;
			model.user_telphone=user_telphone;
			model.location_lat=location_lat;
			model.location_lng=location_lng;

			la.BLL.gpslocation bll=new la.BLL.gpslocation();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
