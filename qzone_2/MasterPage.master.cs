using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
            string userID = Session["userID"].ToString();
            string[] column = new string[1] { "userID3" };
            string[] columnvalue = new string[1] { userID };
            string sql2 = "select * from Users where id =@";
            sql2 = sql2 + column[0];
            DataTable da = SqlHelper.SqlSelect(sql2,column,columnvalue,1);
            userPicture.ImageUrl = da.Rows[0][4].ToString();
            userName.Text = Session["userName"].ToString();
            

        
    }

   
    protected void homepage_Click(object sender, EventArgs e)
    {
        Response.Redirect("qzone.aspx");
    }

    protected void Journal_Click(object sender, EventArgs e)
    {
        Response.Redirect("blog.aspx");

    }

    protected void Album_Click(object sender, EventArgs e)
    {
        Response.Redirect("Album.aspx");
    }

    protected void Friend_Click(object sender, EventArgs e)
    {
        Response.Redirect("Friend.aspx");
    }

    protected void PersonalFile_Click(object sender, EventArgs e)
    {
        Response.Redirect("PersonFile.aspx");

    }

    protected void messageBoard_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageBoard.aspx");
    }

    protected void Setting_Click(object sender, EventArgs e)
    {
        Response.Redirect("SettingPage.aspx");
    }
    
}
