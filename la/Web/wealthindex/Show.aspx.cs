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
namespace la.Web.wealthindex
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int wealthindex_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					wealthindex_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				string user_telphone = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					user_telphone= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(wealthindex_ID,user_telphone);
			}
		}
		
	private void ShowInfo(int wealthindex_ID,string user_telphone)
	{
		la.BLL.wealthindex bll=new la.BLL.wealthindex();
		la.Model.wealthindex model=bll.GetModel(wealthindex_ID,user_telphone);
		this.lblwealthindex_ID.Text=model.wealthindex_ID.ToString();
		this.lbluser_telphone.Text=model.user_telphone;
		this.lblwealthindex_changevalue.Text=model.wealthindex_changevalue.ToString();
		this.lblwealthindex_time.Text=model.wealthindex_time.ToString();
		this.lblwealthindex_comment.Text=model.wealthindex_comment;
		this.lblwealthindex_changetype.Text=model.wealthindex_changetype;
		this.lblwealthindex_result.Text=model.wealthindex_result.ToString();

	}


    }
}
