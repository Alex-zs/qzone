using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userHead : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        Boolean fileOk = false;
        if (pic_upload.HasFile)//验证是否包含文件
        {
            //取得文件的扩展名,并转换成小写
            string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
            //验证上传文件是否图片格式
            fileOk = IsImage(fileExtension);

            if (fileOk)
            {
                //对上传文件的大小进行检测，限定文件最大不超过8M
                if (pic_upload.PostedFile.ContentLength < 8192000)
                {
                    string filepath = "/images/";
                    if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(Server.MapPath(filepath));
                    }
                    string userID = Session["userID"].ToString();
                    string virpath = filepath + CreatePasswordHash(pic_upload.FileName, 4) + fileExtension;//这是存到服务器上的虚拟路径
                    string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
                    pic_upload.PostedFile.SaveAs(mappath);//保存图片
                    string sql = " update Users set picture =@";
                    //显示图片
                    string[] column = new string[2] { "virpath","userID8" };
                    string[] columnvalue = new string[2] { virpath,userID };
                    sql = sql + column[0] + " where id =@" + column[1];
                    SqlHelper.Update(sql,column,columnvalue,2);
                    Response.Write("<script>alert('修改成功!');window.location.href='qzone.aspx'</script>");



                }
                else
                {
                    pic.ImageUrl = "";
                    lbl_pic.Text = "文件大小超出8M！请重新选择！";
                }
            }
            else
            {
                pic.ImageUrl = "";
                lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
            }
        }
        else
        {
            pic.ImageUrl = "";
            lbl_pic.Text = "请选择要上传的图片！";
        }

    }
    public bool IsImage(string str)
    {
        bool isimage = false;
        string thestr = str.ToLower();
        //限定只能上传jpg和gif图片
        string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
        //对上传的文件的类型进行一个个匹对
        for (int i = 0; i < allowExtension.Length; i++)
        {
            if (thestr == allowExtension[i])
            {
                isimage = true;
                break;
            }
        }
        return isimage;
    }

    public string CreateSalt(int saltLenght)
    {
        //生成一个加密的随机数
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[saltLenght];
        rng.GetBytes(buff);
        //返回一个Base64随机数的字符串
        return Convert.ToBase64String(buff);
    }


    /// <summary>
    /// 返回加密后的字符串
    /// </summary>
    public string CreatePasswordHash(string pwd, int saltLenght)
    {
        string strSalt = CreateSalt(saltLenght);
        //把密码和Salt连起来
        string saltAndPwd = String.Concat(pwd, strSalt);
        //对密码进行哈希
        string hashenPwd = Md5Hash(saltAndPwd);
        //转为小写字符并截取前16个字符串
        hashenPwd = hashenPwd.ToLower().Substring(0, 16);
        //返回哈希后的值
        return hashenPwd;
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


    protected void back2_Click(object sender, EventArgs e)
    {
        Response.Redirect("qzone.aspx");
    }
}