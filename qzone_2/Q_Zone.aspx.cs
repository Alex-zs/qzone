using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Q_Zone: System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Mycook"] != null)                      
        {
            Session["userID"] = Request.Cookies["Mycook"]["userid"].ToString();
            Session["userName"] = Request.Cookies["Mycook"]["username"].ToString();
            Session["userPic"] = Request.Cookies["Mycook"]["userpic"].ToString();
            Response.Redirect("qzone.aspx");
        }
    }



    protected void login_Click(object sender, EventArgs e)
    {
        string mail = txtUserMail.Text;
        string pwd = Md5Hash(txtUserPwd.Text) ;
        string[] column = new string[2] { "mail", "pwd" };
        string[] columnvalue = new string[2] { mail, pwd };
        string sql = "select * from Users ";
        sql = sql + " where userMail =@" + column[0] + " and userPwd =@" + column[1]; 

        System.Data.DataTable dt = new DataTable();
        dt = SqlHelper.SqlSelect(sql,column,columnvalue,2);
        int count = dt.Rows.Count;
        bool result = false;   //验证结果  
        string userCode = txtValidate.Value; //获取用户输入的验证码  
        if (String.IsNullOrEmpty(userCode))
        {
            //请输入验证码  
            return;
        }

        string validCode = Session["CheckCode"] as String;  //获取系统生成的验证码  
        if (!string.IsNullOrEmpty(validCode))
        {
            if (userCode.ToLower() == validCode.ToLower())
            {
                //验证成功  
                result = true;
            }
            else
            {
                //验证失败  
                result = false;
            }
        }
        Regex reg = new Regex(@"^\w+$");
        if (reg.IsMatch(pwd))
        {
           
        }
        else
        {
            count = 3;
        }
        if (result == false)
        {
            count = 2;
        }
        if (count == 0)
            Response.Write("<script>alert('用户名或密码错误！');location='Q_Zone.aspx'</script>");
        else if (count == 2)
        {
            Response.Write("<script>alert('验证码错误！');location='Q_Zone.aspx'</script>");
        }

        else if (count == 3)
        {
            Response.Write("<script>alert('密码只能为字母、数字和下划线！！');location='Q_Zone.aspx'</script>");
        }
        else       
        {


            Session["userID"] = dt.Rows[0][0].ToString();
            Session["userName"] = dt.Rows[0][1].ToString();
            Session["userPic"] = dt.Rows[0][4].ToString();
            if(autoLogin.Checked)
            {
                HttpCookie cookie = new HttpCookie("Mycook");   //初始化cooki
                DateTime time = DateTime.Now;       
                cookie.Expires = time.AddDays(3);               //设置过期时间
                cookie.Values.Add("userid", Session["userID"].ToString());
                cookie.Values.Add("username", Session["userName"].ToString());
                cookie.Values.Add("userpic", Session["userPic"].ToString());
                Response.AppendCookie(cookie);
            }
            Response.Write("<script>alert('登录成功！');location='qzone.aspx'</script>");
        }

    }

    protected void register_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");         //转到Register.aspx
    }

    protected void findPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserFind.aspx");
    }

    private static string Md5Hash(string input)
    {
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        byte[] data = md5Hasher.ComputeHash(System.Text.Encoding.Default.GetBytes(input));
        System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

}