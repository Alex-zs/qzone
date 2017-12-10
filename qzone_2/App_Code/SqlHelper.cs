using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// SqlHelper 的摘要说明
/// </summary>
public class SqlHelper
{
    static string str = @"server=.;Integrated Security=SSPI;database=Q-Zone;";

    public  SqlHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
       
    }
    public DataTable SqlSelect(string sql,string[] column,string[] columnvalue,int n)
    {
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(str);
        command.Connection = conn;
        command.CommandText = sql;
        command.CommandType = CommandType.Text;
        for(int i=0;i<n;i++)
        {
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@"+column[i],SqlDbType.VarChar){Value=columnvalue[i]}
            });

        }
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.SelectCommand = command;
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public void Update(string sql, string[] column, string[] columnvalue, int n)
    {
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(str);
        command.Connection = conn;
        command.CommandText = sql;
        command.CommandType = CommandType.Text;
        for (int i = 0; i < n; i++)
        {
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@"+column[i],SqlDbType.VarChar){Value=columnvalue[i]}
            });
        }
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.SelectCommand = command;
        da.Fill(dt);
        conn.Close();
    }
    public void InsertInto(string sql, string[] column, string[] columnvalue, int n)
    {
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(str);
        command.Connection = conn;
        command.CommandText = sql;
        command.CommandType = CommandType.Text;
        for (int i = 0; i < n; i++)
        {
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@"+column[i],SqlDbType.VarChar){Value=columnvalue[i]}
            });
        }
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.SelectCommand = command;
        da.Fill(dt);
        conn.Close();
    }
    public void Delete(string sql, string[] column, string[] columnvalue, int n)
    {
        SqlCommand command = new SqlCommand();
        SqlConnection conn = new SqlConnection(str);
        command.Connection = conn;
        command.CommandText = sql;
        command.CommandType = CommandType.Text;
        for (int i = 0; i < n; i++)
        {
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@"+column[i],SqlDbType.VarChar){Value=columnvalue[i]}
            });
        }
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.SelectCommand = command;
        da.Fill(dt);
        conn.Close();
    }
    

}