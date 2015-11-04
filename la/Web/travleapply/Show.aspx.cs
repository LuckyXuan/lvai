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
namespace la.Web.travleapply
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int travleapply_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					travleapply_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				int travle_ID = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					travle_ID=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(travleapply_ID,travle_ID);
			}
		}
		
	private void ShowInfo(int travleapply_ID,int travle_ID)
	{
		la.BLL.travleapply bll=new la.BLL.travleapply();
		la.Model.travleapply model=bll.GetModel(travleapply_ID,travle_ID);
		this.lbltravleapply_ID.Text=model.travleapply_ID.ToString();
		this.lbltravle_ID.Text=model.travle_ID.ToString();
		this.lblapplyer_ID.Text=model.applyer_ID.ToString();
		this.lblapply_time.Text=model.apply_time.ToString();
		this.lblapply_state.Text=model.apply_state;
		this.lblapply_msg.Text=model.apply_msg;

	}


    }
}
