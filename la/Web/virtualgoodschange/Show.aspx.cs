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
namespace la.Web.virtualgoodschange
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int virtualgoodschange_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					virtualgoodschange_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				int virtualgoods_ID = -1;
				if (Request.Params["id2"] != null && Request.Params["id2"].Trim() != "")
				{
					virtualgoods_ID=(Convert.ToInt32(Request.Params["id2"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(virtualgoodschange_ID,user_telphone,virtualgoods_ID);
			}
		}
		
	private void ShowInfo(int virtualgoodschange_ID,string user_telphone,int virtualgoods_ID)
	{
		la.BLL.virtualgoodschange bll=new la.BLL.virtualgoodschange();
		la.Model.virtualgoodschange model=bll.GetModel(virtualgoodschange_ID,user_telphone,virtualgoods_ID);
		this.lblvirtualgoodschange_ID.Text=model.virtualgoodschange_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblvirtualgoods_ID.Text=model.virtualgoods_ID.ToString();
		this.lblvirtualgoodschange_count.Text=model.virtualgoodschange_count.ToString();
		this.lblvirtualgoodschange_time.Text=model.virtualgoodschange_time.ToString();
		this.lblvirtualgoodschange_comment.Text=model.virtualgoodschange_comment;

	}


    }
}
