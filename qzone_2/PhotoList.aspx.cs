using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PhotoList : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string albumid = Request.QueryString["id"];     //获取相册id
            if(Request.UrlReferrer != null)
            {
                Session["albumid"] = albumid;
                string sql = "select * from Album where albumid = '" + albumid + "'";
                Session["dt"] = SqlHelper.SqlSelect(sql, null, null, 0);
                DataBindToRepeater(1);
            }
            else
            {
                Response.Write("<script>alert('请不要修改页面')</script>");
            }

        }
    }

    protected void photos_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch(e.CommandName)
        {
            case "reply":
                TextBox box = (TextBox)e.Item.FindControl("txt");
                Button button = (Button)e.Item.FindControl("submit");
                Button back = (Button)e.Item.FindControl("back");
                box.Visible = true;
                button.Visible = true;
                back.Visible = true;
                Session["photoid"] = e.CommandArgument.ToString();
                break;
        }
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

        photos.DataSource = pds;

        photos.DataBind();
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

    protected void upload_Click(object sender, EventArgs e)
    {
        Response.Redirect("AlbumUpload.aspx");
    }

    protected void photos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            int ID = Convert.ToInt32(rowv["id"]);
            //找到对应ID下的Book
            string select = "select picture,userName,time,text from PhotoComment inner join Users on PhotoComment.photoid = '"+ID+"' and PhotoComment.userid = Users.id";
            //找到内嵌Repeater
            Repeater comm = (Repeater)e.Item.FindControl("comment");
            //数据绑定
            DataTable dt = SqlHelper.SqlSelect(select, null, null, 0);
            int count = Convert.ToInt32(dt.Rows.Count);
            for (int i = 0; i < count; i++)
            {
                dt.Rows[i][3] = Server.HtmlEncode(dt.Rows[i][3].ToString());
            }
            comm.DataSource = dt;
            comm.DataBind();


        }
    }

    protected void comment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        Control control = (Control)((Button)sender).Parent;
        TextBox text = (TextBox)control.FindControl("txt");
        string time = DateTime.Now.ToString();
        string txt = text.Text;
        if (txt == "")
        {
            Response.Write("<script>alert('请输入！')</script>");
        }
        else
        {
            string userid = Session["userID"].ToString();
        string photoid = Session["photoid"].ToString();
        string sql = "insert into PhotoComment(photoid,userid,time,text) values('" + photoid + "','" + userid + "','" + time + "','" + txt + "')";
        try
        {
            SqlHelper.InsertInto(sql, null, null, 0);
            Response.Redirect(Request.Url.ToString());
        }
        catch
        {
            Response.Write("<script>alert('请正确输入！')</script>");
        }
        }
        

    }

    protected void back_Click(object sender, EventArgs e)
    {
        Control control = (Control)((Button)sender).Parent;
        TextBox box = (TextBox)control.FindControl("txt");
        Button button = (Button)control.FindControl("submit");
        Button back = (Button)control.FindControl("back");
        box.Visible = false;
        button.Visible = false;
        back.Visible = false;
    }
}