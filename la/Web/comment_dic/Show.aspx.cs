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
namespace la.Web.comment_dic
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
					int 评价字典编号=(Convert.ToInt32(strid));
					ShowInfo(评价字典编号);
				}
			}
		}
		
	private void ShowInfo(int 评价字典编号)
	{
		la.BLL.comment_dic bll=new la.BLL.comment_dic();
		la.Model.comment_dic model=bll.GetModel(评价字典编号);
		this.lbl评价字典编号.Text=model.评价字典编号.ToString();
		this.lbl评价字典内容.Text=model.评价字典内容;
		this.lbl对应分值.Text=model.对应分值.ToString();

	}


    }
}
