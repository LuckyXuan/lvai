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
namespace la.Web.talent
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int talent_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					talent_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(talent_ID,user_telphone);
			}
		}
		
	private void ShowInfo(int talent_ID,string user_telphone)
	{
		la.BLL.talent bll=new la.BLL.talent();
		la.Model.talent model=bll.GetModel(talent_ID,user_telphone);
		this.lbltalent_ID.Text=model.talent_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lbltalent_change_value.Text=model.talent_change_value.ToString();
		this.lbltalent_change_comment.Text=model.talent_change_comment;
		this.lbltalent_change_time.Text=model.talent_change_time.ToString();
		this.lbltalent_change_type.Text=model.talent_change_type;
		this.lbltalent_result.Text=model.talent_result.ToString();

	}


    }
}
