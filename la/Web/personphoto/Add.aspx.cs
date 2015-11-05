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
namespace la.Web.personphoto
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtpersonphoto_id.Text))
			{
				strErr+="相片ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtalbum_id.Text))
			{
				strErr+="相册_id格式错误！\\n";	
			}
			if(this.txtpersonphoto_path.Text.Trim().Length==0)
			{
				strErr+="相片路径不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int personphoto_id=int.Parse(this.txtpersonphoto_id.Text);
			int album_id=int.Parse(this.txtalbum_id.Text);
			string personphoto_path=this.txtpersonphoto_path.Text;

			la.Model.personphoto model=new la.Model.personphoto();
			model.personphoto_id=personphoto_id;
			model.album_id=album_id;
			model.personphoto_path=personphoto_path;

			la.BLL.personphoto bll=new la.BLL.personphoto();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
