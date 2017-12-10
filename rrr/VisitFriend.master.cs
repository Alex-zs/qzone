using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VisitFriend : System.Web.UI.MasterPage
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string visitID = Session["visitID"].ToString();
            string[] column = new string[1] { "visitID" };
            string[] columnvalue = new string[1] { visitID };
            string sql2 = "select * from Users where id =@";
            sql2 = sql2 + column[0];
            DataTable da = SqlHelper.SqlSelect(sql2, column, columnvalue, 1);
            userPicture.ImageUrl = da.Rows[0][4].ToString();
            userName.Text = da.Rows[0][1].ToString();
        }
        

    }

    protected void homepage_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendQzone.aspx");
    }

    protected void Journal_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendBlog.aspx");
    }

    protected void Album_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendAlbum.aspx");
    }

    protected void PersonalFile_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendPersonFile.aspx");
    }

    protected void messageBoard_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendLeaveMessage.aspx");
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("qzone.aspx");
    }
}
