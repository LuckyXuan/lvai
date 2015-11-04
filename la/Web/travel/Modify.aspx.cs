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
namespace la.Web.travel
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int travle_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(travle_ID);
				}
			}
		}
			
	private void ShowInfo(int travle_ID)
	{
		la.BLL.travel bll=new la.BLL.travel();
		la.Model.travel model=bll.GetModel(travle_ID);
		this.lbltravle_ID.Text=model.travle_ID.ToString();
		this.txtpromoter_userid.Text=model.promoter_userid.ToString();
		this.txtrelease_time.Text=model.release_time.ToString();
		this.txtDestination.Text=model.Destination;
		this.txtstartplace.Text=model.startplace;
		this.txtreturn_time.Text=model.return_time.ToString();
		this.txtstart_time.Text=model.start_time.ToString();
		this.txttransportation.Text=model.transportation;
		this.txtfee.Text=model.fee;
		this.txttravle_theme.Text=model.travle_theme;
		this.txttravle_personcount.Text=model.travle_personcount.ToString();
		this.txtcompanion_condition.Text=model.companion_condition;
		this.txttravle_msg.Text=model.travle_msg;
		this.txtpic1.Text=model.pic1;
		this.txtpic2.Text=model.pic2;
		this.txtpic3.Text=model.pic3;
		this.txtincome_condition.Text=model.income_condition;
		this.txtcar_condition.Text=model.car_condition;
		this.txtheight_condition.Text=model.height_condition;
		this.txtcredit_condition.Text=model.credit_condition;
		this.txtwantget_gift.Text=model.wantget_gift;
		this.txtwantsend_gift.Text=model.wantsend_gift;
		this.txtreg_fee.Text=model.reg_fee.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtpromoter_userid.Text))
			{
				strErr+="发起人格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtrelease_time.Text))
			{
				strErr+="发布时间格式错误！\\n";	
			}
			if(this.txtDestination.Text.Trim().Length==0)
			{
				strErr+="目的地不能为空！\\n";	
			}
			if(this.txtstartplace.Text.Trim().Length==0)
			{
				strErr+="出发地不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtreturn_time.Text))
			{
				strErr+="返回时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtstart_time.Text))
			{
				strErr+="出发时间格式错误！\\n";	
			}
			if(this.txttransportation.Text.Trim().Length==0)
			{
				strErr+="交通方式不能为空！\\n";	
			}
			if(this.txtfee.Text.Trim().Length==0)
			{
				strErr+="费用说明不能为空！\\n";	
			}
			if(this.txttravle_theme.Text.Trim().Length==0)
			{
				strErr+="旅行主题不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txttravle_personcount.Text))
			{
				strErr+="需要旅伴人数格式错误！\\n";	
			}
			if(this.txtcompanion_condition.Text.Trim().Length==0)
			{
				strErr+="旅伴要求不能为空！\\n";	
			}
			if(this.txttravle_msg.Text.Trim().Length==0)
			{
				strErr+="留言不能为空！\\n";	
			}
			if(this.txtpic1.Text.Trim().Length==0)
			{
				strErr+="图1不能为空！\\n";	
			}
			if(this.txtpic2.Text.Trim().Length==0)
			{
				strErr+="图2不能为空！\\n";	
			}
			if(this.txtpic3.Text.Trim().Length==0)
			{
				strErr+="图3不能为空！\\n";	
			}
			if(this.txtincome_condition.Text.Trim().Length==0)
			{
				strErr+="旅伴收入要求不能为空！\\n";	
			}
			if(this.txtcar_condition.Text.Trim().Length==0)
			{
				strErr+="旅伴车辆要求不能为空！\\n";	
			}
			if(this.txtheight_condition.Text.Trim().Length==0)
			{
				strErr+="旅伴身高要求不能为空！\\n";	
			}
			if(this.txtcredit_condition.Text.Trim().Length==0)
			{
				strErr+="旅伴信用要求不能为空！\\n";	
			}
			if(this.txtwantget_gift.Text.Trim().Length==0)
			{
				strErr+="想得到的礼品不能为空！\\n";	
			}
			if(this.txtwantsend_gift.Text.Trim().Length==0)
			{
				strErr+="想送出的礼品不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtreg_fee.Text))
			{
				strErr+="报名费用（旅币)格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int travle_ID=int.Parse(this.lbltravle_ID.Text);
			int promoter_userid=int.Parse(this.txtpromoter_userid.Text);
			DateTime release_time=DateTime.Parse(this.txtrelease_time.Text);
			string Destination=this.txtDestination.Text;
			string startplace=this.txtstartplace.Text;
			DateTime return_time=DateTime.Parse(this.txtreturn_time.Text);
			DateTime start_time=DateTime.Parse(this.txtstart_time.Text);
			string transportation=this.txttransportation.Text;
			string fee=this.txtfee.Text;
			string travle_theme=this.txttravle_theme.Text;
			int travle_personcount=int.Parse(this.txttravle_personcount.Text);
			string companion_condition=this.txtcompanion_condition.Text;
			string travle_msg=this.txttravle_msg.Text;
			string pic1=this.txtpic1.Text;
			string pic2=this.txtpic2.Text;
			string pic3=this.txtpic3.Text;
			string income_condition=this.txtincome_condition.Text;
			string car_condition=this.txtcar_condition.Text;
			string height_condition=this.txtheight_condition.Text;
			string credit_condition=this.txtcredit_condition.Text;
			string wantget_gift=this.txtwantget_gift.Text;
			string wantsend_gift=this.txtwantsend_gift.Text;
			decimal reg_fee=decimal.Parse(this.txtreg_fee.Text);


			la.Model.travel model=new la.Model.travel();
			model.travle_ID=travle_ID;
			model.promoter_userid=promoter_userid;
			model.release_time=release_time;
			model.Destination=Destination;
			model.startplace=startplace;
			model.return_time=return_time;
			model.start_time=start_time;
			model.transportation=transportation;
			model.fee=fee;
			model.travle_theme=travle_theme;
			model.travle_personcount=travle_personcount;
			model.companion_condition=companion_condition;
			model.travle_msg=travle_msg;
			model.pic1=pic1;
			model.pic2=pic2;
			model.pic3=pic3;
			model.income_condition=income_condition;
			model.car_condition=car_condition;
			model.height_condition=height_condition;
			model.credit_condition=credit_condition;
			model.wantget_gift=wantget_gift;
			model.wantsend_gift=wantsend_gift;
			model.reg_fee=reg_fee;

			la.BLL.travel bll=new la.BLL.travel();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
