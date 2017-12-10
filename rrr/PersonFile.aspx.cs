using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PersonFile : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
        userName.Text = Session["userName"].ToString();
        string userID = Session["userID"].ToString();
        string sql = "select * from UserInformation where userID = '" + userID + "'";
        DataTable dt = SqlHelper.SqlSelect(sql, null, null, 0);
        userAge.Text = dt.Rows[0][3].ToString();
        userBirth.Text = dt.Rows[0][4].ToString();
        constellation.Text = dt.Rows[0][10].ToString();
        AdressNow.Text = Server.HtmlEncode(dt.Rows[0][7].ToString());
        marry.Text = dt.Rows[0][6].ToString();
        blood.Text = dt.Rows[0][5].ToString();
        hometown.Text =Server.HtmlEncode(dt.Rows[0][11].ToString());
        job.Text = Server.HtmlEncode(dt.Rows[0][8].ToString());
        hobby.Text = Server.HtmlEncode(dt.Rows[0][9].ToString());
    }

    protected void change_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangeInformation.aspx");
    }
}