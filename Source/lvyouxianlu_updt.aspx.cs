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

public partial class lvyouxianlu_updt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
            jiaotonggongju.Items.Add("����");
            jiaotonggongju.Items.Add("��");
            jiaotonggongju.Items.Add("�ɻ�");
            jiaotonggongju.Items.Add("�ִ�");
			// xingbie.Items.Add("male"); 
			// xingbie.Items.Add("female");
            string sql;
            sql = "select * from lvyouxianlu where id=" + Request.QueryString["id"].ToString().Trim() ;
            getdata(sql);
        }
    }



    private void getdata(string sql)
    {
        DataSet result = new DataSet();
        result = new Class1().hsggetdata(sql);
        if (result != null)
        {
            if (result.Tables[0].Rows.Count > 0)
            {
                bianhao.Text = result.Tables[0].Rows[0]["bianhao"].ToString().Trim();mingcheng.Text = result.Tables[0].Rows[0]["mingcheng"].ToString().Trim();shijian.Text = result.Tables[0].Rows[0]["shijian"].ToString().Trim();jiage.Text = result.Tables[0].Rows[0]["jiage"].ToString().Trim();jiaotonggongju.Text = result.Tables[0].Rows[0]["jiaotonggongju"].ToString().Trim();jianjie.Text = result.Tables[0].Rows[0]["jianjie"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update lvyouxianlu set bianhao='" + bianhao.Text.ToString().Trim() + "',mingcheng='" + mingcheng.Text.ToString().Trim() + "',shijian='" + shijian.Text.ToString().Trim() + "',jiage='" + jiage.Text.ToString().Trim() + "',jiaotonggongju='" + jiaotonggongju.Text.ToString().Trim() + "',jianjie='" + jianjie.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
        int result;
        result = new Class1().hsgexucute(sql);
        if (result == 1)
        {
            Response.Write("<script>javascript:alert('�޸ĳɹ�');</script>");
        }
        else
        {
            Response.Write("<script>javascript:alert('ϵͳ����');</script>");
        }
    }
}

