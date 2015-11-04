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
namespace la.Web.sendgift
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				int sendgift_ID = -1;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					sendgift_ID=(Convert.ToInt32(Request.Params["id0"]));
				}
				int virtualgoods_ID = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					virtualgoods_ID=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(sendgift_ID,virtualgoods_ID);
			}
		}
		
	private void ShowInfo(int sendgift_ID,int virtualgoods_ID)
	{
		la.BLL.sendgift bll=new la.BLL.sendgift();
		la.Model.sendgift model=bll.GetModel(sendgift_ID,virtualgoods_ID);
		this.lblsendgift_ID.Text=model.sendgift_ID.ToString();
		this.lblvirtualgoods_ID.Text=model.virtualgoods_ID.ToString();
		this.lblsender_id.Text=model.sender_id.ToString();
		this.lblaccepter_id.Text=model.accepter_id.ToString();
		this.lblsend_time.Text=model.send_time.ToString();
		this.lblsendgift_comment.Text=model.sendgift_comment;
		this.lblsendgift_msg.Text=model.sendgift_msg;
		this.lblsendgift_count.Text=model.sendgift_count.ToString();

	}


    }
}
