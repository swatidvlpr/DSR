using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Deliveryreport : System.Web.UI.Page
{
    global gl = new global();
    string invoice = "";
    string date = "";
    public int total = 0;


    decimal totalPrice = 0M;
    decimal totalamt = 0M;
    //string dt;
    int totalItems = 0;
    int totalItems1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            string idd = Request.QueryString["id"].ToString();
            gl.query("Select * from Delivery_challan_add where Challlan_no='" + idd + "'");
        
        
        
        }

    }
}