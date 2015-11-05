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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtcar_id.Text))
			{
				strErr+="小车编码格式错误！\\n";	
			}
			if(this.txtuser_telphone.Text.Trim().Length==0)
			{
				strErr+="用户Phone不能为空！\\n";	
			}
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
			int car_id=int.Parse(this.txtcar_id.Text);
			string user_telphone=this.txtuser_telphone.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
