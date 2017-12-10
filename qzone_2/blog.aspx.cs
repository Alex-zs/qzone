using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
        string userID = Session["userID"].ToString();
            string[] column = new string[1] { "userID10" };
            string[] columnvalue = new string[1] { userID };
            string sql = "select * from blog where userid = @";
            sql = sql + column[0] + " Order By time Desc";
            System.Data.DataTable dt = new DataTable();
            Session["dt"] = SqlHelper.SqlSelect(sql, column, columnvalue, 1);
            DataBindToRepeater(1);
       
    }
    void DataBindToRepeater(int currentPage)
    {
        DataTable dt = (DataTable)Session["dt"];
        int count = dt.Rows.Count;
        for(int i = 0;i<count;i++)
        {
            dt.Rows[i][4] = Server.HtmlEncode(dt.Rows[i][4].ToString());
        }
        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = dt.DefaultView;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一

        blogList.DataSource = pds;

        blogList.DataBind();
    }
    protected void writeblog_Click(object sender, EventArgs e)
    {
        Response.Redirect("Journal.aspx");

    }

    protected void blogList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "title")
        {
            string blogId = e.CommandArgument.ToString();
            Response.Write("<script>location='BlogText.aspx?id=" + blogId + "'</script>");
        }
        if (e.CommandName == "delete")
        {
            string blogid = e.CommandArgument.ToString();
            string sql = "delete from blog where JournalID = '" + blogid + "'";
            SqlHelper.Delete(sql, null, null, 0);
            Response.Write("<script>alert('删除成功！');location = '" + Request.Url.ToString() +"'</script>");
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

    protected void delete_Click(object sender, EventArgs e)
    {
        

    }
}