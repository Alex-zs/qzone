using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InsertFriend : System.Web.UI.Page
{
    
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (search.SelectedValue == "用户名")
        {
            string userName = btn_search.Text;
            string[] column = new string[1] { "userName1" };
            string[] columnvalue = new string[1] { "%"+userName+"%" };
            string sql = "select * from Users where userName like ";
            sql = sql + "@" + column[0];
            DataTable dt = SqlHelper.SqlSelect(sql,column,columnvalue,1);
            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('查无此人')</script>");
            }
            else
            {
                friends.DataSource = dt;
                friends.DataBind();
            }



        }
        if (search.SelectedValue == "邮箱")
        {
            string userName = btn_search.Text;
            string[] column = new string[1] { "userName2" };
            string[] columnvalue = new string[1] { "%"+userName+"%" };
            string sql = "select * from Users where userMail like @";
            sql = sql + column[0];
            DataTable dt = SqlHelper.SqlSelect(sql, column, columnvalue, 1);
            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('查无此人')</script>");
            }
            else
            {
                friends.DataSource = dt;
                friends.DataBind();
            }
            
           
        }
    }

    protected void friends_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "insertFriend")
        {
            string friendid = e.CommandArgument.ToString();
            string userid = Session["userID"].ToString();
            string[] column = new string[2] { "userid2", "friendid1" };
            string[] columnvalue = new string[2] { userid, friendid };
            string sql = "select * from UserFriend where userID = @";
            sql = sql + column[0] + " and friendID = @" + column[1];
            DataTable dt = SqlHelper.SqlSelect(sql,column,columnvalue,2);
            if(dt.Rows.Count == 0)
            {
                string[] column2 = new string[2] { "mail","friendid" };
                string[] columnvalue2 = new string[2] { userid,friendid };
                string sql2 = "insert into FriendPass(userID,friendID) values('"+ userid +"','"+ friendid +"')";
                sql = sql + "(@" + column2[0] + ",@" + column2[1] + ")";
                SqlHelper.InsertInto(sql2,column2,columnvalue2,2);
                Response.Write("<script>alert('申请中！')</script>");
            }
            else
            {
                Response.Write("<script>alert('您已添加此好友，请勿重复添加！')</script>");
            }
        }
    }
    
}