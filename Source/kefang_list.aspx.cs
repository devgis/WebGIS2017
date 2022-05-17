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

public partial class kefang_list : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            
            string sql;
            sql = "select * from kefang where jiudian='"+Request.QueryString["jd"].ToString().Trim()+"' order by id desc";
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
                DataGrid1.DataSource = result.Tables[0];
                DataGrid1.DataBind();
                Label1.Text = "以上数据中共" + result.Tables[0].Rows.Count+"条";
            }
            else
            {
                DataGrid1.DataSource = null;
                DataGrid1.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql;
        sql = "select * from kefang where jiudian='"+Request.QueryString["jd"].ToString().Trim()+"'";
        if (bh.Text.ToString().Trim() != "")
        {
            sql = sql + " and kefangbianhao like '%" + bh.Text.ToString().Trim() + "%'";
        }
        

        sql = sql + " order by id desc";

        getdata(sql);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("kefang_add.aspx?jd="+Request.QueryString["jd"].ToString().Trim());
    }
}

