using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Friend : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }

        string userID = Session["userID"].ToString();
            string[] column = new string[2] { "userID6","userID7" };
            string[] columnvalue = new string[] { userID,userID };
            string sql = "select id,userName,userMail,picture  from Users inner join (select friendID from Users inner join UserFriend on Users.id = UserFriend.userID and Users.id =@";
            sql = sql + column[0] + " ) as friend on Users.id = friend.friendID and Users.id !=@" + column[1]+"";
            System.Data.DataTable dt = new DataTable();
            Session["dt"] = SqlHelper.SqlSelect(sql,column,columnvalue,2);
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

    protected void insertFriend_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsertFriend.aspx");
    }

    protected void friendList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "delete")
        {
            string friendid = e.CommandArgument.ToString();
            string userid = Session["userID"].ToString();
            string[] column = new string[2] { "F_userID","F_friendID" };
            string[] columnvalue = new string[2] { userid, friendid };
            string sql = "delete from UserFriend where userID = @";
            sql = sql + column[0] + " and friendID =@" + column[1];
            SqlHelper.Delete(sql, column, columnvalue, 2);
            Response.Write("<script>alert('删除成功！');location='" + Request.Url.ToString() + "'</script>");
        }
        if(e.CommandName == "userName")
        {
            string friendid = e.CommandArgument.ToString();
            Session["visitID"] = friendid;
            Response.Redirect("FriendQzone.aspx");
        }

    }


    protected void agreeFriend_Click(object sender, EventArgs e)
    {
        Response.Redirect("friendPass.aspx");
    }
}