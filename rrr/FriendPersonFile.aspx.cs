using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FriendPersonFile : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
        string userID = Session["visitID"].ToString();
        string sql2 = "select * from Users where id = '" + userID + "'";
        DataTable da = SqlHelper.SqlSelect(sql2, null, null, 0);
        userName.Text = da.Rows[0][1].ToString();
        string sql = "select * from UserInformation where userID = '" + userID + "'";
        DataTable dt = SqlHelper.SqlSelect(sql, null, null, 0);
        userAge.Text = dt.Rows[0][3].ToString();
        userBirth.Text = dt.Rows[0][4].ToString();
        constellation.Text = dt.Rows[0][10].ToString();
        AdressNow.Text = dt.Rows[0][7].ToString();
        marry.Text = dt.Rows[0][6].ToString();
        blood.Text = dt.Rows[0][5].ToString();
        hometown.Text = dt.Rows[0][11].ToString();
        job.Text = dt.Rows[0][8].ToString();
        hobby.Text = dt.Rows[0][9].ToString();
    }
}