using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserChange : System.Web.UI.Page
{
    static SqlHelper SqlHelper = new SqlHelper();
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

    static string str = @"server=.;Integrated Security=SSPI;database=Library;";
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
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
                if (code < 48 || (int)code > 57)
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

    protected void changePwd_Click(object sender, EventArgs e)
    {
        bool result = false;   //验证结果  
        string userCode = this.txtValidate.Value; //获取用户输入的验证码  
        if (String.IsNullOrEmpty(userCode))
        {
            //请输入验证码  
            return;
        }

        string validCode = this.Session["CheckCode"] as String;  //获取系统生成的验证码  
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
        string name = Session["username"].ToString();
        String password = userPassword.Text;
        String passwords = userPasswords.Text;
        int lenth = password.Length;
        int flag;
        if (password == passwords)
        {
            flag = 0;
        }
        else
        {
            flag = 1;
        }
        if(lenth <6 || lenth >16)
        {
            flag = 2;
        }
        if (result == false)
        {
            flag = 3;
        }
        if (flag == 0)
        {
            string[] column = new string[2] { "password1","name2" };
            string[] columnvalue = new string[2] { password,name };
            string sql = "UPDATE Readers SET password =@";
            sql = sql + column[0] + " WHERE name =@" + column[1];
            SqlHelper.Update(sql,column,columnvalue,2);
            Response.Write("<script>alert('修改成功！');location='Edit.aspx'</script>");
        }
        if (flag == 1)
        {
            Response.Write("<script>alert('前后密码不一致！');location='UserChange.aspx'</script>");
        }
        if (flag == 2)
        {
            Response.Write("<script>alert('请输入6到16位的密码！');location='UserChange.aspx'</script>");
        }
        if (flag == 3)
        {
            Response.Write("<script>alert('验证码错误！');location='UserChange.aspx'</script>");
        }
        
    }

    protected void send_Click(object sender, EventArgs e)
    {
        int flag = 1;
        string email = Session["userName"].ToString();
        string emailAd = emailAdress.Text;
        string emailStr = @"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+";
        Regex emailReg = new Regex(emailStr);
        if (emailReg.IsMatch(email.Trim()))
        {
            
        }
        else
        {
            flag = 2;
        }

        if (email == emailAd)
        {
            flag = 1;
        }
        else
        {
            flag = 3;
        }
        if (flag == 2)
        {
            Response.Write("<script>alert('邮箱格式错误')</script>");
        }
        if (flag == 3)
        {
            Response.Write("<script>alert('邮箱地址错误！')</script>");
        }
        if (flag == 1)
        {
            
            string validCode = GenerateCheckCode();  //获取系统生成的验证码  
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            string mailFrom = "330953853@qq.com"; //登陆用户名
            string userPassword = "ulldpxudytplcbee";//客户端授权码
            string mailTo = emailAd;
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
    }

    protected void click_Click(object sender, EventArgs e)
    {
        string code = validate.Text;
        String codes = Session["CheckCode"].ToString();
        
        

        if (code == codes)
        {

            form2.Visible = false;
            form3.Visible = true;

           
        }
        else
        {
            Response.Write("<script>alert('验证码出错！！');Location='Rdgister.aspx'</script>");
        }
    }
}