using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class lvyouxianlu_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
        {
            Random rnd = new Random();
            int n = rnd.Next(1000, 9999);
            string newname = DateTime.Now.Year.ToString().Trim() + DateTime.Now.Month.ToString().Trim() + DateTime.Now.Day.ToString().Trim() + DateTime.Now.Hour.ToString().Trim() + DateTime.Now.Minute.ToString().Trim() + DateTime.Now.Second.ToString().Trim() + n.ToString().Trim();
            bianhao.Text = newname;

            jiaotonggongju.Items.Add("汽车");
            jiaotonggongju.Items.Add("火车");
            jiaotonggongju.Items.Add("飞机");
            jiaotonggongju.Items.Add("轮船");
			// xingbie.Items.Add("male"); 
			// xingbie.Items.Add("female");
			// addxiala("kehuxinxi","bianhao","kehubianhao");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql;
        sql="insert into lvyouxianlu(bianhao,mingcheng,shijian,jiage,jiaotonggongju,jianjie) values('"+bianhao.Text.ToString().Trim()+"','"+mingcheng.Text.ToString().Trim()+"','"+shijian.Text.ToString().Trim()+"','"+jiage.Text.ToString().Trim()+"','"+jiaotonggongju.Text.ToString().Trim()+"','"+jianjie.Text.ToString().Trim()+"') ";
        int result;
        result = new Class1().hsgexucute(sql);
        if (result == 1)
        {
            Response.Write("<script>javascript:alert('添加成功');</script>");
        }
        else
        {
            Response.Write("<script>javascript:alert('系统错误，请检查数据库设置问题');</script>");
        }
    }
	//private void addxiala(string ntable, string nzd, string nxlk)
    //{
    //    string sql;
    //    sql = "select "+nzd+" from "+ntable+" order by id desc";
    //    DataSet result = new DataSet();
    //    result = new Class1().hsggetdata(sql);
    //    if (result != null)
    //    {
    //        if (result.Tables[0].Rows.Count > 0)
    //       {
    //            int i = 0;
    //            for (i = 0; i < result.Tables[0].Rows.Count; i++)
    //            {
    //                kehubianhao.Items.Add(result.Tables[0].Rows[i][0].ToString().Trim());
    //            }
    //        }
    //    }
    //}
}

