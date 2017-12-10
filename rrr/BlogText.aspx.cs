using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BlogText : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        string blogid = Request.QueryString["id"];
        if(Request.UrlReferrer != null)
        {
            string sql = "select * from blog where JournalID = '" + blogid + "'";
            DataTable dt = SqlHelper.SqlSelect(sql, null, null, 0);
            title.Text =Server.HtmlEncode(dt.Rows[0][4].ToString());
            text.Text = Server.HtmlEncode(dt.Rows[0][3].ToString());
            string sql2 = "select userName,picture,time,text from BlogReplies inner join Users on BlogReplies.blogid = '" + blogid + "' and BlogReplies.friendid = Users.id";
            DataTable da = SqlHelper.SqlSelect(sql2, null, null, 0);
            int count = da.Rows.Count;
            for(int i=0;i<count;i++)
            {
                da.Rows[i][3] = Server.HtmlEncode(da.Rows[i][3].ToString());
            }
            blogReplies.DataSource = da;
            blogReplies.DataBind();
        }
        else
        {
            Response.Write("<script>alert('请不要修改页面')</script>");
        }
        

    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("blog.aspx");
    }

    protected void blogReplies_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void comment_Click(object sender, EventArgs e)
    {
        commentTxt.Visible = true;
        submit.Visible = true;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string friendid = Session["userID"].ToString();
        string time = DateTime.Now.ToString();
        string txt = Server.HtmlDecode(commentTxt.Text);
        string blogid = Request.QueryString["id"];
        string sql = "insert into BlogReplies(blogid,friendid,time,text) values('" + blogid + "','" + friendid + "','" + time + "','" + txt + "')";
        try
        {
            SqlHelper.InsertInto(sql, null, null, 0);
            Response.Redirect(Request.Url.ToString());
        }
        catch
        {
            Response.Write("<script>alert('发表失败，请检查后输入！');location='"+Request.Url.ToString()+"'</script>");
        }
      
    }
}