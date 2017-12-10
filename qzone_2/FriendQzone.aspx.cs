using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FriendQzone : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
        
        if(!IsPostBack)
        {
            string friendid = Session["visitID"].ToString();        //获取好友id
            string sql2 = "select * from Permission where userid ='" + friendid + "'";
            DataTable da = SqlHelper.SqlSelect(sql2, null, null, 0);
            string qzoneType = da.Rows[0][3].ToString();
            if(qzoneType == "仅自己")
            {
                Response.Write("<script>alert('拒绝访问,返回我的空间');location='qzone.aspx'</script>");
            }
            if (qzoneType == "仅好友")
            {
                string sql3 = "select * from UserFriend where userID = '" + friendid + "' and friendID = '" + Session["userID"].ToString()+"'";
                DataTable ds = SqlHelper.SqlSelect(sql3, null, null, 0);
                if(ds.Rows.Count != 0)
                {
                    string[] column = new string[1] { "visitID2" };
                    string[] columnvalue = new string[1] { friendid };
                    string sql = "select text,time,userName,picture,userId,talkID from (select talkID,userId,text,time from Talk where userId =@";
                    sql = sql + column[0] + ") as tk inner join Users on tk.userId = Users.id Order By time Desc";
                    System.Data.DataTable dt = new DataTable();
                    Session["dt"] = SqlHelper.SqlSelect(sql, column, columnvalue, 1);
                    DataBindToRepeater(1);
                }
                else
                {
                    Response.Write("<script>alert('拒绝访问,返回我的空间');location='qzone.aspx'</script>");
                }
            }
            if(qzoneType == "所有人")
            {
                string[] column = new string[1] { "visitID2" };
                string[] columnvalue = new string[1] { friendid };
                string sql = "select text,time,userName,picture,userId,talkID from (select talkID,userId,text,time from Talk where userId =@";
                sql = sql + column[0] + ") as tk inner join Users on tk.userId = Users.id Order By time Desc";
                System.Data.DataTable dt = new DataTable();
                Session["dt"] = SqlHelper.SqlSelect(sql, column, columnvalue, 1);
                DataBindToRepeater(1);
            }
            
        }
        
    }
    void DataBindToRepeater(int currentPage)
    {
        DataTable dt = (DataTable)Session["dt"];
        int count = dt.Rows.Count;
        for(int i =0;i<count;i++)
        {
            dt.Rows[i][0] = Server.HtmlEncode(dt.Rows[i][0].ToString());
        }
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = dt.DefaultView;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一

        talklist.DataSource = pds;

        talklist.DataBind();
    }
    protected void talklist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "reply":
                TextBox replyEdit = (TextBox)e.Item.FindControl("replyEdit");
                Button button = (Button)e.Item.FindControl("submit");
                Button back = (Button)e.Item.FindControl("back");
                Label talk = (Label)e.Item.FindControl("talkid");
                replyEdit.Visible = true;
                button.Visible = true;
                back.Visible = true;
                Session["talkid"] = talk.Text;
                break;
            case "back":
                TextBox replyEdit2 = (TextBox)e.Item.FindControl("replyEdit");
                Button button2 = (Button)e.Item.FindControl("submit");
                Button back2 = (Button)e.Item.FindControl("back");
                replyEdit2.Visible = false;
                button2.Visible = false;
                back2.Visible = false;
                break;
            default:
                break;
        }
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
    protected void replys_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void talklist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            int ID = Convert.ToInt32(rowv["talkID"]);
            //找到对应ID下的Book
            string select = "select userName,picture,time,text from Users inner join (select friendid,time,text from TalkReplies where talkid='" + ID + "') as tk on Users.id = tk.friendid";
            //找到内嵌Repeater
            DataTable da = SqlHelper.SqlSelect(select, null, null, 0);
            int count = da.Rows.Count;
            for(int i=0;i<count;i++)
            {
                da.Rows[i][3] = Server.HtmlEncode(da.Rows[i][3].ToString());
            }
            Repeater rept = (Repeater)e.Item.FindControl("replys");
            //数据绑定
            rept.DataSource = da;
            rept.DataBind();


        }

    }
    protected void back_Click(object sender, EventArgs e)
    {
        Control item = ((Button)sender).Parent;
        TextBox replyEdit = (TextBox)item.FindControl("replyEdit");
        Button button = (Button)item.FindControl("submit");
        Button back = (Button)item.FindControl("back");
        replyEdit.Visible = false;
        button.Visible = false;
        back.Visible = false;

    }

    protected void submit_Click1(object sender, EventArgs e)
    {
        Control item = ((Button)sender).Parent;
        TextBox txt = (TextBox)item.FindControl("replyEdit");
        string text = txt.Text;
        string userid = Session["visitID"].ToString();
        string friendid = Session["userID"].ToString();
        string talkid = Session["talkid"].ToString();
        string time = DateTime.Now.ToString();
        string[] column = new string[5] { "userid22", "friendid12", "talkid", "time12", "text" };
        string[] columnvalue = new string[5] { userid, friendid, talkid, time, text };
        string sql = "insert into TalkReplies(userid,friendid,talkid,time,text) values(@";
        sql = sql + column[0] + ",@" + column[1] + ",@" + column[2] + ",@" + column[3] + ",@" + column[4] + ")";
        SqlHelper.InsertInto(sql, column, columnvalue, 5);
        Response.Redirect(Request.Url.ToString());
    }
}