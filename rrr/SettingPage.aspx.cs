using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SettingPage : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
    }

    protected void changePic_Click(object sender, EventArgs e)
    {
        Response.Redirect("userHead.aspx");
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Session.Clear();
        if (Request.Cookies["Mycook"] != null)
        {
            HttpCookie cookies = new HttpCookie("Mycook"); 
            cookies.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookies);
        }
        Response.Redirect("Wrong.aspx");
    }

  

    protected void permission_Click(object sender, EventArgs e)
    {
        Response.Redirect("Permission.aspx");
    }

    protected void deleteTalk_Click(object sender, EventArgs e)
    {
        string userid = Session["userID"].ToString();
        string sql = "select talkID,userName,picture,time,text from Talk inner join Users on Talk.userId = '"+userid+"' and Talk.userId = Users.id order by time  desc";
        DataTable dt = SqlHelper.SqlSelect(sql, null, null, 0);
        int count = dt.Rows.Count;
        for(int i = 0;i<count;i++)
        {
            dt.Rows[i][4] = Server.HtmlEncode(dt.Rows[i][4].ToString());
        }
        talkList.DataSource = dt;
        talkList.DataBind();
        form1.Visible = false;
        form2.Visible = true;
    }

    protected void talkList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "delete")
        {
            string talkid = e.CommandArgument.ToString();
            string sql = "delete from Talk where talkID = '" + talkid + "'";
            SqlHelper.Delete(sql, null, null, 0);
            Response.Write("<script>alert('删除成功！');location='" + Request.Url.ToString() + "'</script>");
        }
    }
}