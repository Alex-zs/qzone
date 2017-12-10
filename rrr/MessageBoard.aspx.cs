using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MessageBoard : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }

            string userid = Session["userID"].ToString();
            string sql = "select  LiuYan.id,friendID,userName,time,text,picture from LiuYan inner join Users on LiuYan.userID='" + userid+"' and LiuYan.friendID=Users.id order by time desc";
            Session["dt"] = SqlHelper.SqlSelect(sql, null, null, 0);
            DataBindToRepeater(1);
      
        
    }



    protected void messageList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "delete")
        {
            string messageid = e.CommandArgument.ToString();
            SqlHelper.Delete("delete from LiuYan where id = '" + messageid + "'", null, null, 0);
            Response.Write("<script>alert('删除成功！');location='" + Request.Url.ToString() + "'</script>");
        }
    }
    void DataBindToRepeater(int currentPage)
    {
        DataTable dt = (DataTable)Session["dt"];
        int count = Convert.ToInt32(dt.Rows.Count);
        for (int i = 0; i < count; i++)
        {
            dt.Rows[i][4] = Server.HtmlEncode(dt.Rows[i][4].ToString());
        }
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        pds.CurrentPageIndex = currentPage - 1;//当前页数从零开始，故把接受的数减一
        messageList.DataSource = pds;
        messageList.DataBind();
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

}