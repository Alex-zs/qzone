using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Permission : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        string userid = Session["userID"].ToString();
        string sql = "select * from Permission where userid = '" + userid + "'";
        DataTable dt = SqlHelper.SqlSelect(sql, null, null, 0);
        nowQzonePermission.Text = dt.Rows[0][3].ToString();
        nowTalkPermission.Text = dt.Rows[0][2].ToString();

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string userid = Session["userID"].ToString();
        string qzoneType = visitPermission.SelectedValue;
        string talkType = talkPermission.SelectedValue;
        string sql = "update Permission set qzone_type = '"+qzoneType+"' ,talk_type = '"+talkType+"' where userid = '"+userid+"'";
        SqlHelper.InsertInto(sql, null, null, 0);
        Response.Write("<script>alert('修改成功');location='qzone.aspx'</script>");
       
    }
}