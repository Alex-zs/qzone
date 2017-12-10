using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FriendLeaveMessage : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        string friendid = Session["visitID"].ToString();
        string sql = "select userName,picture,text,time,Users.id from LiuYan inner join Users on LiuYan.userID = '" + friendid + "' and LiuYan.friendID=Users.id order by time desc";
        System.Data.DataTable dt = new DataTable();
        Session["dt"] = SqlHelper.SqlSelect(sql, null, null, 0); ;
        DataBindToRepeater(1);

    }
    void DataBindToRepeater(int currentPage)
    {
        DataTable dt = (DataTable)Session["dt"];
        int count = dt.Rows.Count;
        for (int i = 0; i < count; i++)
        {
            dt.Rows[i][2] = Server.HtmlEncode(dt.Rows[i][2].ToString());
        }
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = dt.DefaultView;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一

        LeaveMessage.DataSource = pds;

        LeaveMessage.DataBind();
    }
    protected void LeaveMessage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

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

    protected void write_Click(object sender, EventArgs e)
    {
        message.Visible = true;
        submit.Visible = true;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string friendid = Session["userID"].ToString();
        string userid = Session["visitID"].ToString();
        string time = DateTime.Now.ToString();
        string text = message.Text;
        string[] column = new string[4] { "userid20","friendid12","text3","time2" };
        string[] columnvalue = new string[4] { userid,friendid,text,time };
        string sql = "insert into LiuYan(userID,friendID,text,time) values(@";
        sql = sql + column[0] + ",@" + column[1] + ",@" + column[2] + ",@" + column[3] + ")";
        SqlHelper.InsertInto(sql, column, columnvalue, 4);
        Response.Redirect(Request.Url.ToString());
    }
}