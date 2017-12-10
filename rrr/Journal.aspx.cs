using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Journal : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string title =Server.HtmlDecode(biaoti.Value);
        string text = Server.HtmlDecode(TextBox2.Text);
        if(title == "" || text == "")
        {
            Response.Write("<script>alert('请输入！')</script>");
        }
        else
        {
            string time = DateTime.Now.ToLongDateString().ToString();
            string userid = Session["userID"].ToString();
            string[] column = new string[4] { "userid", "time", "title", "text" };
            string[] columnvalue = new string[4] { userid, time, title, text };
            string sql = "insert into blog(userid,time,text,title) values(@";
            sql = sql + column[0] + ",@" + column[1] + ",@" + column[3] + ",@" + column[2] + ")";
            try
            {
                SqlHelper.InsertInto(sql, column, columnvalue, 4);
                Response.Write("<script>alert('发布成功！');location='blog.aspx'</script>");
            }
            catch
            {
                Response.Write("<script>alert('抱歉，发布失败，请正常输入！');location='blog.aspx'</script>");
            }
        }
        
        
    }
}