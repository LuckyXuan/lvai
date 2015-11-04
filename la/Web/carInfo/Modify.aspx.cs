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
namespace la.Web.carInfo
{
    public partial class Modify : Page
    {       

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
		this.txtcar_level.Text=model.car_level;
		this.txtcar_brand.Text=model.car_brand;
		this.txtcar_type.Text=model.car_type;
		this.txtcar_photo1.Text=model.car_photo1;
		this.txtcar_photo2.Text=model.car_photo2;
		this.txtcar_photo3.Text=model.car_photo3;
		this.txtcar_photo1_state.Text=model.car_photo1_state;
		this.txtcar_photo2_state.Text=model.car_photo2_state;
		this.txtcar_photo3_state.Text=model.car_photo3_state;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtcar_level.Text.Trim().Length==0)
			{
				strErr+="车辆等级不能为空！\\n";	
			}
			if(this.txtcar_brand.Text.Trim().Length==0)
			{
				strErr+="车辆牌子不能为空！\\n";	
			}
			if(this.txtcar_type.Text.Trim().Length==0)
			{
				strErr+="车辆型号不能为空！\\n";	
			}
			if(this.txtcar_photo1.Text.Trim().Length==0)
			{
				strErr+="车辆图片1不能为空！\\n";	
			}
			if(this.txtcar_photo2.Text.Trim().Length==0)
			{
				strErr+="车辆图片2不能为空！\\n";	
			}
			if(this.txtcar_photo3.Text.Trim().Length==0)
			{
				strErr+="车辆图片3不能为空！\\n";	
			}
			if(this.txtcar_photo1_state.Text.Trim().Length==0)
			{
				strErr+="车辆图片1审核状态不能为空！\\n";	
			}
			if(this.txtcar_photo2_state.Text.Trim().Length==0)
			{
				strErr+="车辆图片2审核状态不能为空！\\n";	
			}
			if(this.txtcar_photo3_state.Text.Trim().Length==0)
			{
				strErr+="车辆图片3审核状态不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int car_id=int.Parse(this.lblcar_id.Text);
			string user_telphone=this.lbluser_telphone.Text;
			string car_level=this.txtcar_level.Text;
			string car_brand=this.txtcar_brand.Text;
			string car_type=this.txtcar_type.Text;
			string car_photo1=this.txtcar_photo1.Text;
			string car_photo2=this.txtcar_photo2.Text;
			string car_photo3=this.txtcar_photo3.Text;
			string car_photo1_state=this.txtcar_photo1_state.Text;
			string car_photo2_state=this.txtcar_photo2_state.Text;
			string car_photo3_state=this.txtcar_photo3_state.Text;


			la.Model.carInfo model=new la.Model.carInfo();
			model.car_id=car_id;
			model.user_telphone=user_telphone;
			model.car_level=car_level;
			model.car_brand=car_brand;
			model.car_type=car_type;
			model.car_photo1=car_photo1;
			model.car_photo2=car_photo2;
			model.car_photo3=car_photo3;
			model.car_photo1_state=car_photo1_state;
			model.car_photo2_state=car_photo2_state;
			model.car_photo3_state=car_photo3_state;

			la.BLL.carInfo bll=new la.BLL.carInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
