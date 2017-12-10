using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangeInformation : System.Web.UI.Page
{
    SqlHelper SqlHelper = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("Wrong.aspx");
        }

        
        if (!IsPostBack)
        {
            userName.Text = Session["userName"].ToString();
            //填充DropDownList
            int i = 0;
            Year.Items.Clear();
            for (i = 1900; i <= DateTime.Now.Year; i++)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                Year.Items.Add(item);
            }
            Month.Items.Clear();
            for (i = 1; i <= 12; i++)
            {
                string t = i < 10 ? "0" + i.ToString() : i.ToString();
                ListItem item = new ListItem(t, i.ToString());
                Month.Items.Add(item);
            }
            Day.Items.Clear();
            for (i = 1; i <= 31; i++)
            {
                string t = i < 10 ? "0" + i.ToString() : i.ToString();
                ListItem item = new ListItem(t, i.ToString());
                Day.Items.Add(item);
            }
            //给年和月的onchange 绑定方法，用于处理闰年的情况
            Year.Attributes["onchange"] = "OnSelectChange(" + Year.ClientID + "," + Month.ClientID + "," + Day.ClientID + ");";
            Month.Attributes["onchange"] = "OnSelectChange(" + Year.ClientID + "," + Month.ClientID + "," + Day.ClientID + ");";
            Year.SelectedValue = DateTime.Now.Year.ToString();
            Month.SelectedValue = DateTime.Now.Month.ToString();
            Day.SelectedValue = DateTime.Now.Day.ToString();
        }

    }
    public DateTime Date
    {
        get { return DateTime.Parse(Year.SelectedValue + "-" + Month.SelectedValue + "-" + Day.SelectedValue); }
        set
        {
            Year.SelectedValue = value.Year.ToString();
            Month.SelectedValue = value.Month.ToString();
            Day.SelectedValue = value.Day.ToString();
        }
    }
    public bool checkbirth (int birth)
    {
        string year = DateTime.Now.Year.ToString();
        string month = DateTime.Now.Month.ToString();
        string strInput = DateTime.Now.ToString("yyyy-MM-dd");
        string strOutput = Regex.Replace(strInput, "[^\\d]", "");
        int date = Convert.ToInt32(strOutput);
        if(birth >date)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string birth = Year.SelectedValue + Month.SelectedValue + Day.SelectedValue;
        string userid = Session["userID"].ToString();
        if (checkbirth(Convert.ToInt32(birth)) == false)
        {
            Response.Write("<script>alert('你还没出生吗,还是穿越过来的')</script>");
        }
        else
        {
            string userNewName = userName.Text;
            if(userNewName.Length <4 || userNewName.Length >16)
            {
                Response.Write("<script>alert('昵称长度在4到16个字符之间，请修改！');location='"+Request.Url.ToString()+"'</script>");
            }
            else
            {
                userNewName = Server.HtmlDecode(userNewName);
                try
                {
                    SqlHelper.Update("update Users set userName = '" + userNewName + "' where id = '" + userid + "'", null, null, 0);
                }
                catch
                {
                    Response.Write("<script>alert('修改失败，请正确输入！');location = '"+Request.Url.ToString()+"'</script>");

                }
                string sex = sexselect.Value;
                string star;
                if (Convert.ToInt32(Day.SelectedValue) < 10)
                {
                    star = constellation(Convert.ToInt32(Month.SelectedValue + "0" + Day.SelectedValue));
                }
                else
                {
                    star = constellation(Convert.ToInt32(Month.SelectedValue + Day.SelectedValue));
                }
                string date = Year.SelectedValue + "年" + Month.SelectedValue + "月" + Day.SelectedValue + "号";
                string age = Convert.ToString(Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(Year.SelectedValue));
                string adrs =Server.HtmlDecode(adress.Value);
                string home =Server.HtmlDecode(hometown.Value);
                string mar = marry.Value;
                string bloo = blood_select.Value;
                string work = Server.HtmlDecode(job.Text);
                string hobb = Server.HtmlDecode(hobby.Value);
                
                string[] column = new string[11] { "userid13", "sex", "age", "birth", "blood", "marry", "adress", "job", "hobby", "constell", "hometown" };
                string[] columnvalue = new string[11] { userid, sex, age, date, bloo, mar, adrs, work, hobb, star, home };
                string sql = "update UserInformation set sex = @" + column[1] + ",age = @" + column[2] + ",birthday = @" + column[3] + ",blood = @" + column[4] + ",marry = @" + column[5] + ",adress = @" + column[6] + ",job=@" + column[7] + ",hobby =@" + column[8] + ",constellation=@" + column[9] + ",hometown =@" + column[10] + " where userID = @" + column[0];
                try
                {
                    SqlHelper.Update(sql, column, columnvalue, 11);
                    Response.Redirect("PersonFile.aspx");
                }
                catch
                {
                    Response.Write("<script>alert('修改失败，请正确输入！');location = '" + Request.Url.ToString() + "'</script>");
                }

            }


        }
        

       

        
    }
    public string constellation(int s)
    {
        string star = null;
        if (s >= 120 && s <= 218)
            star = "水瓶座";
        if (s >= 219 && s <= 320)
            star = "双鱼座";
        if (s >= 823 && s <= 922)
            star = "处女座";
        if (s >= 321 && s <= 419)
            star = "白羊座";
        if (s >= 420 && s <= 520)
            star = "金牛座";
        if (s >= 521 && s <= 621)
            star = "双子座";
        if (s >= 622 && s <= 722)
            star = "巨蟹座";
        if (s >= 723 && s <= 822)
            star = "狮子座";
        if (s >= 823 && s <= 922)
            star = "处女座";
        if (s >= 923 && s <= 1023)
            star = "天枰座";
        if (s >= 1024 && s <= 1122)
            star = "天蝎座";
        if (s >= 1123 && s <= 1221)
            star = "射手座";
        if (s >= 1222 || s <= 119)
            star = "摩羯座";
        return star;
       

    }
}