using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : Page
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

    static string str = @"server=.;Integrated Security=SSPI;database=Q-Zone;";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnVal_Click(object sender, EventArgs e)
    {
        int flag = 1;
        string emailStr = @"^[\u4E00-\u9FA5A-Za-z0-9_]+$";
        Regex emailReg = new Regex(emailStr);
        if (emailReg.IsMatch(userName.Text.Trim()))
        {
           
        }
        else
        {
            flag = 8;
        }       
        string mail = userMail.Text;
        string name = userName.Text;
        string password = userPwd.Text;
        String passwords = userPwds.Text;
        int lenth = name.Length;
        int lenths = password.Length;
        string UserName = userName.Text;
        string[] column = new string[1] { "mail1" };
        string[] columnvalue = new string[1] { mail };
        string selStr = "select * from Users where userMail=@";
        selStr = selStr + column[0];
        DataTable dt = new DataTable();
        dt = SqlHelper.SqlSelect(selStr,column,columnvalue,1);
        if (dt.Rows.Count != 0)
        {
            flag = 2;
        }
        if (name.IndexOf(" ") > -1 || password.IndexOf(" ") > -1)
        {
            flag = 3;
        }
        if(password != passwords)
        {
            flag = 4;
        }
        if  (lenth < 4 || lenth > 20)
        {
            flag = 6;
        }
        if (lenths < 4 || lenths >20)
        {
            flag = 7;
        }
        if (lenth == 0 || lenths == 0)
        {
            flag = 0;
        }
        Regex reg = new Regex(@"^\w+$");
        if (reg.IsMatch(password))
        {
            
        }

        else
        {
            flag = 9;
        }


        if (flag == 1)
        {
            try
            {
                Session["userName"] = userName.Text;
                Session["userMail"] = userMail.Text;
                Session["userPwd"] = userPwd.Text;
                string txtEmailAddress = userMail.Text;
                string validCode = GenerateCheckCode();  //获取系统生成的验证码  
                string smtpServer = "smtp.qq.com"; //SMTP服务器
                string mailFrom = "330953853@qq.com"; //登陆用户名
                string userPassword = "ulldpxudytplcbee";//客户端授权码
                string mailTo = txtEmailAddress;
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
            catch
            {
                Response.Write("<script>alert('请正确输入！');location='Register.aspx'</script>");
            }
            
        }
        if (flag == 0)
        {
            Response.Write("<script>alert('请输入后点击！');location='Register.aspx'</script>");
        }
        if (flag == 2)
        {
            Response.Write("<script>alert('该邮箱已注册！');location='Register.aspx'</script>");
        }
        if (flag == 3)
        {
            Response.Write("<script>alert('请不要输入空格！');location='Register.aspx'</script>");
        }
        if (flag == 4)
        {
            Response.Write("<script>alert('前后密码不一致！');location='Register.aspx'</script>");
        }
        if (flag == 6)
        {
            Response.Write("<script>alert('用户名为4位到16位!');location='Register.aspx'</script>");
        }
        if (flag == 7)
        {
            Response.Write("<script>alert('请输入6到16位的密码！');location='Register.aspx'</script>");
        }
        if (flag == 8)
        {
            Response.Write("<script>alert('请输入正确格式！');Location='Rdgister.aspx'</script>");
        }
        if (flag == 9)
        {
            Response.Write("<script>alert('密码只能为字母、数字和下划线！');Location='Rdgister.aspx'</script>");
        }

    }




    protected void register_Click(object sender, EventArgs e)
    {
        string code = validateCode.Text;
        String codes = Session["CheckCode"].ToString();
        string name = Session["userName"].ToString();
        string mail = Session["userMail"].ToString();
        string password = Md5Hash(Session["userPwd"].ToString());
        
        if (code.ToLower() == codes.ToLower())
        {
            string picture = "/images/25c77902af1e00b9.jpg";
            string[] column = new string[3] { "name","mail","password" };
            string[] columnvalue = new string[3] { name,mail,password };
            string sql = "insert into  Users(userName ,userMail,userPwd,picture) values(@";
            sql = sql + column[0] + ",@" + column[1] + ",@" + column[2] + ",'" + picture + "')";
            SqlHelper.InsertInto(sql,column,columnvalue,3);
            string[] column2 = new string[1] { "name1" };
            string[] columnvalue2 = new string[1] { name };
            string sql2 = "select * from Users where userName =@";
            sql2 = sql2 + column2[0];
            System.Data.DataTable dt = new DataTable();
            dt = SqlHelper.SqlSelect(sql2,column2,columnvalue2,1);
            Session["username"] = userName.Text;
            string id = dt.Rows[0][0].ToString();
            string[] column3 = new string[2] { "userID","friendID" };
            string[] columnvalue3 = new string[2] { id,id };
            string sql3 = "insert into UserFriend(userID,friendID) values('" + id + "','" + id + "')";
            sql = sql + column3[0] + ",@" + column3[1] + ")";
            SqlHelper.InsertInto(sql3,column3,columnvalue3,2);
            Session["id"] = id;
            string[] column4 = new string[2] { "R_userid","nothing" };
            string[] columnvalue4 = new string[2] {Session["id"].ToString(), "未填写" };
            string sql4 = "insert into UserInformation(userID,sex,age,birthday,blood,marry,adress,job,hobby,constellation,hometown) values(@";
            sql4 = sql4 + column4[0] + ",@" + column4[1] + ",@" + column4[1] + ",@" + column4[1] + ",@" + column4[1] + ",@" + column4[1] + ",@" + column4[1] + ",@" + column4[1] + ",@" + column4[1] + ",@" + column4[1] + ",@"+column4[1]+")";
            SqlHelper.InsertInto(sql4, column4, columnvalue4, 2);
            SqlHelper.InsertInto("insert into Permission(userid,talk_type,qzone_type) values('" + id + "','所有人','所有人')", null, null, 0);
            Response.Write("<script>alert('注册成功！');location='Q_Zone.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('验证码出错！！');Location='Rdgister.aspx'</script>");
        }
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