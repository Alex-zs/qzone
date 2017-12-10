using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class qzone : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
            string userID = Session["userID"].ToString();
            string[] column = new string[1] { "userID4" };
            string[] columnvalue = new string[1] { userID };
            string sql = "select text,time,userName,picture,userId,talkID from (select talkID,userId,text,time from Talk where userId in(select friendID  from Users inner join UserFriend on UserFriend.userID=@";
            sql = sql + column[0] + " and Users.id=UserFriend.userID)) as tk inner join Users on tk.userId = Users.id Order By talkID Desc";
            System.Data.DataTable dt = new DataTable();
            Session["dt"] = SqlHelper.SqlSelect(sql,column,columnvalue,1);
            DataBindToRepeater(1);
        
    }

   
    void DataBindToRepeater(int currentPage)
    {
        DataTable dt = (DataTable)Session["dt"];
        if(dt.Rows.Count != 0)
        {
            int count = Convert.ToInt32(dt.Rows.Count);
            for(int i = 0;i<count;i++)
            {
                dt.Rows[i][0] = Server.HtmlEncode(dt.Rows[i][0].ToString());
            }
            for(int i = 0;i<count;i++)
            {
                string userid = dt.Rows[i][4].ToString();
                string sql = "select * from Permission where userid = '" + userid + "'";
                DataTable da = SqlHelper.SqlSelect(sql, null, null, 0);
                string talkType = da.Rows[0][2].ToString();
                if (talkType == "仅好友")
                {
                    string sql2 = "select * from UserFriend where userID = '" + userid + "' and friendID = '" + Session["userID"].ToString() + "'";
                    DataTable ds = SqlHelper.SqlSelect(sql2, null, null, 0);
                    if(ds.Rows.Count == 0)
                    {
                        dt.Rows[i].Delete();
                    }
                }
                if(talkType == "仅自己")
                {
                    if(Session["userID"].ToString() != userid)
                    {
                        dt.Rows[i].Delete();
                    }
                }

                
            }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string text = Server.HtmlDecode(textbox.InnerText);
        if (text == "")
        {
            Response.Write("<script>alert('请输入！')</script>");
        }
        else
        {
            string time = DateTime.Now.ToString();
            string userid = Session["userID"].ToString();
            string[] column = new string[1] { "text1" };
            string[] columnvalue = new string[1] { text };
            string sql = "INSERT INTO Talk (userId,text,time) VALUES ('" + userid + "',@";
            sql = sql + column[0] + ",'" + time + "')";
            try
            {
                SqlHelper.InsertInto(sql, column, columnvalue, 1);
                Response.Write("<script>alert('发布成功！');location='qzone.aspx'</script>");
            }
            catch
            {
                Response.Write("<script>alert('发布失败，请重新输入！');location='qzone.aspx'</script>");
            }
        }
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
                Session["userids"] = e.CommandArgument.ToString();
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
        if(e.CommandName == "friendQzone")
        {
            string friendid = e.CommandArgument.ToString();
            if(friendid != Session["userID"].ToString())
            {
                Session["visitID"] = friendid;
                Response.Redirect("FriendQzone.aspx");
            }
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
            string select = "select userName,picture,time,text from Users inner join (select friendid,time,text from TalkReplies where talkid='"+ID+"') as tk on Users.id = tk.friendid";
            //找到内嵌Repeater
            Repeater rept = (Repeater)e.Item.FindControl("replys");
            //数据绑定
            DataTable dt = SqlHelper.SqlSelect(select, null, null, 0);
            int count = Convert.ToInt32(dt.Rows.Count);
            for(int i = 0;i<count;i++)
            {
                dt.Rows[i][3] = Server.HtmlEncode(dt.Rows[i][3].ToString());
            }
            rept.DataSource = dt;
            rept.DataBind();
            

        }

    }

    protected void back_Click(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        Control item = (Control)((Button)sender).Parent;
        TextBox txt = (TextBox)item.FindControl("replyEdit");
        string text = Server.HtmlDecode(txt.Text);
        string userid = Session["userids"].ToString();
        string friendid = Session["userID"].ToString();
        string talkid = Session["talkid"].ToString();
        string time = DateTime.Now.ToString();
        string[] column = new string[5] { "userid22","friendid12","talkid","time12","text" };
        string[] columnvalue = new string[5] { userid,friendid,talkid,time,text };
        string sql = "insert into TalkReplies(userid,friendid,talkid,time,text) values(@";
        sql = sql + column[0] + ",@" + column[1] + ",@" + column[2] + ",@" + column[3] + ",@" + column[4] + ")";
        SqlHelper.InsertInto(sql, column, columnvalue, 5);
        Response.Redirect(Request.Url.ToString());

    }
}