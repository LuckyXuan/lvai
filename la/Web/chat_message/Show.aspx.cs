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
namespace la.Web.chat_message
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int chat_ID=(Convert.ToInt32(strid));
					ShowInfo(chat_ID);
				}
			}
		}
		
	private void ShowInfo(int chat_ID)
	{
		la.BLL.chat_message bll=new la.BLL.chat_message();
		la.Model.chat_message model=bll.GetModel(chat_ID);
		this.lblchat_ID.Text=model.chat_ID.ToString();
		this.lblchat_FROM.Text=model.chat_FROM.ToString();
		this.lblchat_TO.Text=model.chat_TO.ToString();
		this.lblchat_content.Text=model.chat_content;
		this.lblchat_time.Text=model.chat_time.ToString();
		this.lblchat_comment.Text=model.chat_comment;
		this.lblchat_state.Text=model.chat_state;

	}


    }
}
