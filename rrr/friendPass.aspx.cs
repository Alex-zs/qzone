using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class friendPass : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
        string userID = Session["userID"].ToString();
            string[] column = new string[1] { "userId5" };
            string[] columnvalue = new string[1] { userID };
            string sql = "select userName,userMail,picture,id from Users  innner join (select userID from FriendPass where friendID = @";
            sql = sql + column[0] + ") as us on id = us.userID";
            System.Data.DataTable dt = new DataTable();
            Session["dt"] = SqlHelper.SqlSelect(sql,column,columnvalue,1);
            DataBindToRepeater(1);

        
    }
    void DataBindToRepeater(int currentPage)
    {
        DataTable dt = (DataTable)Session["dt"];
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = dt.DefaultView;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一

        friendList.DataSource = pds;

        friendList.DataBind();
    }
    protected void btnUp_Click(object sender, EventArgs e)
    {
        string nowPage = lbNow.Text;

        int toPage = Convert.ToInt32(nowPage) - 1;

        if (toPage != 0)
        {
            lbNow.Text = Convert.ToString(toPage);

            DataBindToRepeater(toPage);
        }
        else
        {
            Response.Write("<script>alert('这是第一页！')</script>");
        }
    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        string nowPage = lbNow.Text;

        int toPage = Convert.ToInt32(nowPage) + 1;

        if (toPage <= Convert.ToInt32(lbTotal.Text))
        {
            lbNow.Text = Convert.ToString(toPage);

            DataBindToRepeater(toPage);
        }
        else
        {
            Response.Write("<script>alert('已到最后一页！')</script>");
        }
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        lbNow.Text = "1";

        DataBindToRepeater(1);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        lbNow.Text = lbTotal.Text;

        DataBindToRepeater(Convert.ToInt32(lbTotal.Text));
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        int jump = 0;
        try
        {
            jump = Convert.ToInt32(txtJump.Text);
            int pageNumbers = Convert.ToInt32(lbTotal.Text);
            if (jump <= pageNumbers)
            {
                lbNow.Text = txtJump.Text;
                DataBindToRepeater(jump);
            }
            else
            {

                Response.Write("<script>alert('没有此页！')</script>");
            }
        }
        catch
        {
            Response.Write("<script>alert('请正确输入！')</script>");
        }
    }

    protected void friendList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string friendid = e.CommandArgument.ToString();
        string userid = Session["userID"].ToString();
        string[] column = new string[2] { "FP_userid", "FP_friend" };
        string[] columnvalue = new string[2] { userid, friendid };
        if (e.CommandName == "agree")
        {
            
            string sql = "insert into UserFriend(userID,friendID) values(@";
            sql = sql + column[0] + ",@" + column[1] + ")";
            SqlHelper.InsertInto(sql, column, columnvalue, 2);
            string sql2 = "insert into UserFriend(userID,friendID) values(@";
            sql2 = sql2 + column[1] + ",@" + column[0] + ")";
            SqlHelper.InsertInto(sql2, column, columnvalue, 2);
            string sql3 = "delete from FriendPass where userID =@";
            sql3 = sql3 + column[1] + " and friendID = @" + column[0];
            SqlHelper.Delete(sql3, column, columnvalue, 2);
            Response.Write("<script>alert('添加成功！');location='"+Request.Url.ToString()+"'</script>");
       }
        if(e.CommandName == "disagree")
        {
            string sql = "delete from FriendPass where userID =@";
            sql = sql + column[1] + " and friendID =@" + column[0];
            SqlHelper.Delete(sql, column, columnvalue, 2);
            Response.Write("<script>alert('已拒绝！');location='" + Request.Url.ToString() + "'</script>");
        }
    }
    
}