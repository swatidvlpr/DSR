using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DSR_Stockentry : System.Web.UI.Page
{
    global gl = new global();
    public SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ToString());
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();
            gl.ddl_select("companymaster", "company_id,companyname", "companyname", "company_id", "0", "'Select'", ddlcmpnynm);
            gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'", ddlbranch);
            //        gl.ddl_select("Categorymaster", "Category_id,Categorynm", "Categorynm", "Category_id", "0", "'Select'", ddlctgrynm);
            //        gl.ddl_select("Modelmaster", "Modelid,Modelnm", "Modelnm", "Modelid", "0", "'Select'", ddlmdlnm);             
        }
    }
    protected void ddlcmpnynm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            gl.ddlcond("Categorymaster", "Categorynm", "Category_id", "companyid", "'" + ddlcmpnynm.SelectedValue + "'", ddlctgrynm);
            ddlctgrynm.SelectedIndex = 0;
        }
        catch
        {
        }
    }
    protected void ddlctgrynm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gl.ddlcond("Modelmaster", "Modelnm", "Modelid", "Category_id", "'" + ddlctgrynm.SelectedValue + "'", ddlmdlnm);
            ddlmdlnm.SelectedIndex = 0;
        }
        catch
        {

        }
    }
    protected void ddlmdlnm_SelectedIndexChanged(object sender, EventArgs e)
    {
        gl.query("select * from Modelmaster where Modelnm='" + ddlmdlnm.SelectedItem.Text + "'");
        txtmdlno.Text = gl.ds.Tables[0].Rows[0]["Modelno"].ToString();

        //ds.Clear();
        //da = new SqlDataAdapter("select * from Stock_master where Company_id='" + ddlcmpnynm.SelectedValue + "' and Category_id='" + ddlctgrynm.SelectedValue + "' and Modelnm='" + ddlmdlnm.SelectedItem.Text + "'", con);
        //da.Fill(ds);
        //if (ds.Tables[0].Rows.Count == 0)
        //{
        //    txtopng.Text = "0";
        //}
        //else
        //{
        //    txtopng.Text = ds.Tables[0].Rows[0]["Stack"].ToString();
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {
            int idd = Convert.ToInt32(GridView1.SelectedValue);
            gl.update("Stock_master", "Company_id='" + ddlcmpnynm.SelectedValue + "',Category_id='" + ddlctgrynm.SelectedValue + "',Modelnm='" + ddlmdlnm.SelectedItem.Text + "',Model_no='" + txtmdlno.Text + "', branchname='"+ddlbranch.SelectedItem.Text+"', Date='"+txtdate.Text+"', Particulars='"+txtparticulars.Text+"', Recived_qty='"+txtrecivedqnty.Text+"', Recived_price='"+txtrecivedprice.Text+"', Issue_qty='"+txtissueqnty.Text+"', Issue_price='"+txtissueprice.Text+"', Balance_qty='"+txtbalanceqnty.Text+"', Balance_price='"+txtbalanceprice.Text+"'", "Stock_id", "'" + idd + "'");
            Label1.Text = "Updated Successfully";
            display();
        }
        else
        {                                                                                                                                                                                                                       // Company_id,                          Category_id,                     Modelnm,                            Model_no,              branchname,                 Date,                       Particulars,               Recived_qty,     Recived_price,                   Issue_qty,           Issue_price,                 Balance_qty,         Balance_price
             gl.insert1("Stock_master", "Company_id, Category_id, Modelnm, Model_no, branchname, Date, Particulars, Recived_qty, Recived_price, Issue_qty, Issue_price, Balance_qty, Balance_price", "'" + ddlcmpnynm.SelectedValue + "','" + ddlctgrynm.SelectedValue + "','" + ddlmdlnm.SelectedItem.Text + "','" + txtmdlno.Text + "','"+ddlbranch.SelectedItem.Text+"','"+txtdate.Text+"','"+txtparticulars.Text+"','"+txtrecivedqnty.Text+"','"+txtrecivedprice.Text+"','"+txtissueqnty.Text+"','"+txtissueprice.Text+"','"+txtbalanceqnty.Text+"','"+txtbalanceprice.Text+"'");
            Label1.Text = "Submitted Successfully";
            display();
            ddlcmpnynm.SelectedIndex = 0;
            ddlctgrynm.SelectedIndex = 0;
            ddlmdlnm.SelectedIndex = 0;
            ddlbranch.SelectedIndex = 0;
            txtdate.Text = "";
            txtparticulars.Text = "";
            txtrecivedqnty.Text = "0";
            txtrecivedprice.Text = "00.00";
            txtissueqnty.Text = "0";
            txtissueprice.Text = "00.00";
            txtbalanceqnty.Text = "0";
            txtbalanceprice.Text = "00.00";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        gl.delete("Stock_master", "Stock_id", "'"+id+"'");
        display();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idd = GridView1.SelectedValue.ToString();
        gl.query("Select * from VW_Stockmaster where Stock_id='"+idd+"'");

        string Company_id = gl.ds.Tables[0].Rows[0]["Company_id"].ToString();

        for (int i = 0; i < ddlcmpnynm.Items.Count; i++)
        {
            if (ddlcmpnynm.Items[i].Value == Company_id)
            {
                ddlcmpnynm.Items[i].Selected = true;
                da = new SqlDataAdapter("select Category_id,Categorynm,companyid from Categorymaster where companyid='" + Company_id + "'", con);
                da.Fill(ds);
                ddlctgrynm.DataSource = ds;
                ddlctgrynm.DataTextField = "Categorynm";
                ddlctgrynm.DataValueField = "Category_id";
                ddlctgrynm.DataBind();
               
            }
            else
            {
                ddlcmpnynm.Items[i].Selected = false;
            }
        }


        txtmdlno.Text = gl.ds.Tables[0].Rows[0]["Model_no"].ToString();
        txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
        txtparticulars.Text = gl.ds.Tables[0].Rows[0]["Particulars"].ToString();
        txtparticulars.Text = gl.ds.Tables[0].Rows[0]["Particulars"].ToString();
        txtrecivedqnty.Text = gl.ds.Tables[0].Rows[0]["Recived_qty"].ToString();
        string reciveprice = gl.ds.Tables[0].Rows[0]["Recived_price"].ToString();
        txtrecivedprice.Text = Convert.ToDecimal(reciveprice).ToString("N");
        txtissueqnty.Text = gl.ds.Tables[0].Rows[0]["Issue_qty"].ToString();
        string Issueprice = gl.ds.Tables[0].Rows[0]["Issue_price"].ToString();
        txtissueprice.Text = Convert.ToDecimal(Issueprice).ToString("N");

        txtbalanceqnty.Text = gl.ds.Tables[0].Rows[0]["Balance_qty"].ToString();
        string balanceprice = gl.ds.Tables[0].Rows[0]["Balance_price"].ToString();
        txtbalanceprice.Text = Convert.ToDecimal(balanceprice).ToString("N");
        string Branchnm = gl.ds.Tables[0].Rows[0]["branchname"].ToString();

        for (int i = 0; i < ddlbranch.Items.Count; i++)
        {
            if (ddlbranch.Items[i].Text == Branchnm)
            {
                ddlbranch.Items[i].Selected = true;
            }
            else
            {
                ddlbranch.Items[i].Selected = false;
            }
        }
       
         
    
        
        string cte_name = gl.ds.Tables[0].Rows[0]["Category_id"].ToString();
        for (int ii = 0; ii < ddlctgrynm.Items.Count; ii++)
        {
            if (ddlctgrynm.Items[ii].Value == cte_name)
            {
                ddlctgrynm.Items[ii].Selected = true;
                ds.Reset();
                da = new SqlDataAdapter("select Modelid,Modelnm,Category_id from Modelmaster where Category_id='" + cte_name + "'", con);
                da.Fill(ds);
                ddlmdlnm.DataSource = ds;
                ddlmdlnm.DataTextField = "Modelnm";
                ddlmdlnm.DataValueField = "Modelid";
                ddlmdlnm.DataBind();

            }
            else
            {
                ddlctgrynm.Items[ii].Selected = false;
            }
        }
        string mdl_name = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();
        for (int i2 = 0; i2 < ddlmdlnm.Items.Count; i2++)
        {
            if (ddlmdlnm.Items[i2].Text == mdl_name)
            {

                ddlmdlnm.Items[i2].Selected = true;
            }
            else
            {

                ddlmdlnm.Items[i2].Selected = false;
            }
        
        }

            Button1.Text = "Update";
        }


    
    protected void txtrecivedqnty_TextChanged(object sender, EventArgs e)
    {
        int reciveqty = Convert.ToInt32(txtrecivedqnty.Text);
        int issueqty = Convert.ToInt32(txtissueqnty.Text);
        int totalqnty = reciveqty + issueqty;
        txtbalanceqnty.Text = totalqnty.ToString();

    }
    protected void txtissueqnty_TextChanged(object sender, EventArgs e)
    {
        int reciveqty = Convert.ToInt32(txtrecivedqnty.Text);
        int issueqty = Convert.ToInt32(txtissueqnty.Text);
        int totalqnty = reciveqty + issueqty;
        txtbalanceqnty.Text = totalqnty.ToString();
    }
    protected void txtrecivedprice_TextChanged(object sender, EventArgs e)
    {
        double recivedprice = Convert.ToDouble(txtrecivedprice.Text);
        double issueprice = Convert.ToDouble(txtissueprice.Text);
       double totalprice  = recivedprice + issueprice;
       txtbalanceprice.Text = totalprice.ToString("N");
    }
    protected void txtissueprice_TextChanged(object sender, EventArgs e)
    {
        double recivedprice = Convert.ToDouble(txtrecivedprice.Text);
        double issueprice = Convert.ToDouble(txtissueprice.Text);
        double totalprice = recivedprice + issueprice;
        txtbalanceprice.Text = totalprice.ToString();
    }

    public void display()
    {
        gl.query("Select * from VW_Stockmaster");
        GridView1.DataSource = gl.ds;
        GridView1.DataBind();
    
    }
    protected void ddlctgrynm_DataBound(object sender, EventArgs e)
    {
        Convert.ToInt32(ddlctgrynm.SelectedValue);
        ddlctgrynm.Items.Insert(0, new ListItem("-Select-", "-Select-")); 
    }
    protected void ddlmdlnm_DataBound(object sender, EventArgs e)
    {
        Convert.ToInt32(ddlmdlnm.SelectedValue);
        ddlmdlnm.Items.Insert(0, new ListItem("-Select-", "-Select-")); 
    }
}