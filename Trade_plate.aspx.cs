using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DSR_Trade_plate : System.Web.UI.Page
{
    global gl = new global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gl.ddl_select("Branchmaster", "Branchid,branchname", "branchname", "Branchid", "0", "'Select'",ddlbrnchnm);
            gl.display("Trade_plate", GridView1);           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "update")
        {
            int idd = Convert.ToInt32(GridView1.SelectedValue);
            gl.update("Trade_plate", "branchname='" + ddlbrnchnm.SelectedItem.Text + "',Vehicle_name='" + txtvhclnm.Text + "',Trade_plate_no='" + txtpltno.Text + "', No_of_vehicle='" + txtvhclno.Text + "', Valid_upto='" + txtvalid.Text + "', Insurance='" + txtinsrnc.Text + "',  Date='" + txtdate.Text + "'", "Trade_id", "'" + idd + "'");
            Label1.Text = "Updated Successfully";
        }
        else
        {
                                                  //branchname,                   Vehicle_name,          Trade_plate_no,           No_of_vehicle,            Valid_upto,              Insurance,                 Date


            gl.insert("Trade_plate", "'" + ddlbrnchnm.SelectedItem.Text + "','" + txtvhclnm.Text + "','" + txtpltno.Text + "','" + txtvhclno.Text + "','" + txtvalid.Text + "','" + txtinsrnc.Text + "','" + txtdate.Text + "'");

            Label1.Text = "Submitted Successfully";
        }
        gl.display("Trade_plate", GridView1);       
        ddlbrnchnm.SelectedItem.Text = "";
        txtpltno.Text = "";
        txtvhclnm.Text = "";
        txtvhclno.Text = "";
        txtvalid.Text = "";
        txtinsrnc.Text = "";
        txtdate.Text = "";
        Button1.Text = "submit";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Trade_plate.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
        gl.read1("Trade_plate", "Trade_id", "'" + idd + "'");
        string Branchname = gl.ds.Tables[0].Rows[0]["branchname"].ToString();

        for (int i = 0; i < ddlbrnchnm.Items.Count; i++)
        {
            if (ddlbrnchnm.Items[i].Text == Branchname)
            {
                ddlbrnchnm.Items[i].Selected = true;
            }
            else
            {
                ddlbrnchnm.Items[i].Selected = false;
            }
        }
        ddlbrnchnm.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["branchname"].ToString();
        txtvhclnm.Text = gl.ds.Tables[0].Rows[0]["Vehicle_name"].ToString();
        txtpltno.Text = gl.ds.Tables[0].Rows[0]["Trade_plate_no"].ToString();
        txtvhclno.Text = gl.ds.Tables[0].Rows[0]["No_of_vehicle"].ToString();
        txtvalid.Text = gl.ds.Tables[0].Rows[0]["Valid_upto"].ToString();
        txtinsrnc.Text = gl.ds.Tables[0].Rows[0]["Insurance"].ToString();
        txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
        Button1.Text = "update";
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        gl.delete("Trade_plate", "Trade_id", "'" + id1 + "'");
        gl.display("Trade_plate", GridView1);
        
    }
   
}