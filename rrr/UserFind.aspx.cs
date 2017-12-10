using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserFind : System.Web.UI.Page
{

    /// <summary>  
    /// 验证码类型(0-字母数字混合,1-数字,2-字母)  
    /// </summary>  
    private string validateCodeType = "0";
    /// <summary>  
    /// 验证码字符个数  
    /// </summary>  
    private int validateCodeCount = 4;
    /// <summary>  
    /// 验证码的字符集，去掉了一些容易混淆的字符  
    /// </summary>  
    char[] character = { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };

    static string str = @"server=.;Integrated Security=SSPI;database=Q-Zone;";

    private string GenerateCheckCode()
    {
        char code;
        string checkCode = String.Empty;
        System.Random random = new Random();

        for (int i = 0; i < validateCodeCount; i++)
        {
            code = character[random.Next(character.Length)];

            // 要求全为数字或字母  
            if (validateCodeType == "1")
            {
                if ((int)code < 48 || (int)code > 57)
                {
                    i--;
                    continue;
                }
            }
            else if (validateCodeType == "2")
            {
                if ((int)code < 65 || (int)code > 90)
                {
                    i--;
                    continue;
                }
            }
            checkCode += code;
        }

        Response.Cookies.Add(new System.Web.HttpCookie("CheckCode", checkCode));
        Session["CheckCode"] = checkCode;
        return checkCode;
    }

    protected void send_Click(object sender, EventArgs e)
    {
        int flag = 1;
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        string mail = emailAdress.Text;
        string selStr = "select * from Users where userMail='" + mail + "'";
        SqlDataAdapter da = new SqlDataAdapter(selStr, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            flag = 2;
        }
        if(mail == "")
        {
            flag = 3;
        }
        if(flag == 1 )
        {


            String txtuserEmail = emailAdress.Text;
            Session["userName"] = txtuserEmail;
            string validCode = GenerateCheckCode();  //获取系统生成的验证码  
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            string mailFrom = "330953853@qq.com"; //登陆用户名
            string userPassword = "ulldpxudytplcbee";//客户端授权码
            string mailTo = txtuserEmail;
            string mailSubject = "验证码";
            string mailContent = "你的验证码是" + validCode;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = false;//设置为HTML格式
            mailMessage.Priority = MailPriority.Normal;//优先级        
            smtpClient.Send(mailMessage); // 发送邮件
            form1.Visible = false;
            form2.Visible = true;
        }
        if(flag == 2)
        {
            Response.Write("<script>alert('用户不存在！')</script>");
        }
        if(flag == 3)
        {
            Response.Write("<script>alert('请输入邮箱！')</script>");
        }
           

        
       
    }

    protected void validate_Click(object sender, EventArgs e)
    {
        string code = validateCode.Text;
        string codes = Session["CheckCode"].ToString();
        if (code == codes)
        {
            string UserName = Session["userName"].ToString();
            string sql = "select * from Readers where name='" + UserName + "'";
            SqlConnection conn = new SqlConnection(str);
            System.Data.DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();
            String password = dt.Rows[0][2].ToString();
            Session["password"] = password;
            Response.Redirect("UserPassword.aspx");
        }
        else
        {
            Response.Write("<script>alert('验证码错误！');location='UserFind.aspx'</script>");
        }
        
    }
}

