using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DSR_Prospects_feb_month : System.Web.UI.Page
{
    global gl = new global();
    public int total = 0;
    decimal totalPrice = 0M;
    int totalItems = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                gl.ddl_select("Departmentmaster", "Depart_id,Departmentnm", "Departmentnm", "Depart_id", "0", "'Select'", DropDownList1);

                gl.ddl_select("locationmaster", "location_id,Location_name", "Location_name", "location_id", "0", "'Select'", DropDownList2);

                gl.ddl_select("Modelmaster", "Modelid,Modelnm", "Modelnm", "Modelid", "0", "'Select'", DropDownList3);

                gl.ddlcond("Employee_Reg", "Name", "Emp_id", "Departmentnm", "'" + DropDownList1.SelectedValue + "'", DropDownList4);

                gl.display("Prospects", GridView1);
            }
        }
        catch { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Button1.Text == "update")
            {
                int idd = Convert.ToInt32(GridView1.SelectedValue);
                gl.update("Prospects", "Branch='" + DropDownList5.SelectedItem.Text + "',Customer_name='" + TextBox1.Text + "',Departmentnm='" + DropDownList1.SelectedItem.Text + "',Name='" + DropDownList4.SelectedItem.Text + "',Location_name='" + DropDownList2.SelectedItem.Text + "',Modelnm='" + DropDownList3.SelectedItem.Text + "', Units='" + TextBox2.Text + "', Finance='" + TextBox3.Text + "',  Status='" + TextBox4.Text + "',Date='" + txtdate.Text + "'", "Prospect_id", "'" + idd + "'");
                Label1.Text = "Updated Successfully";
            }
            else
            {
                //                                      Branch,                        Customer_name,                  Departmentnm,                                 Name,                                Location_name,                               Modelnm,                           Units,                 Finance,                Status,                 Date

                gl.insert("Prospects", "'" + DropDownList5.SelectedItem.Text + "','" + TextBox1.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList4.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + txtdate.Text + "'");
                Label1.Text = "Submitted Successfully";
            }
            gl.display("Prospects", GridView1);
        }
        catch { }
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        txtdate.Text = "";
        DropDownList1.SelectedItem.Text = "";
        DropDownList2.SelectedItem.Text = "";
        DropDownList3.SelectedItem.Text = "";
        DropDownList4.SelectedItem.Text = "";
        DropDownList5.SelectedItem.Text = "";
        Button1.Text = "submit";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Prospects_feb_month.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idd = Convert.ToInt32(GridView1.SelectedValue).ToString();
            gl.read1("Prospects", "Prospect_id", "'" + idd + "'");
            string Departmentnm = gl.ds.Tables[0].Rows[0]["Departmentnm"].ToString();
            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (DropDownList1.Items[i].Text == Departmentnm)
                {
                    DropDownList1.Items[i].Selected = true;
                }
                else
                {
                    DropDownList1.Items[i].Selected = false;
                }

            }


            string Location_name = gl.ds.Tables[0].Rows[0]["Location_name"].ToString();
            for (int i = 0; i < DropDownList2.Items.Count; i++)
            {
                if (DropDownList2.Items[i].Text == Location_name)
                {
                    DropDownList2.Items[i].Selected = true;
                }
                else
                {
                    DropDownList2.Items[i].Selected = false;
                }

            }

            string Modelnm = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();
            for (int i = 0; i < DropDownList3.Items.Count; i++)
            {
                if (DropDownList3.Items[i].Text == Modelnm)
                {
                    DropDownList3.Items[i].Selected = true;
                }
                else
                {
                    DropDownList3.Items[i].Selected = false;
                }

            }

            string Name = gl.ds.Tables[0].Rows[0]["Name"].ToString();
            for (int i = 0; i < DropDownList4.Items.Count; i++)
            {
                if (DropDownList4.Items[i].Text == Name)
                {
                    DropDownList4.Items[i].Selected = true;
                }
                else
                {
                    DropDownList4.Items[i].Selected = false;
                }

            }

            string Branch = gl.ds.Tables[0].Rows[0]["Branch"].ToString();
            for (int i = 0; i < DropDownList4.Items.Count; i++)
            {
                if (DropDownList5.Items[i].Text == Branch)
                {
                    DropDownList5.Items[i].Selected = true;
                }
                else
                {
                    DropDownList5.Items[i].Selected = false;
                }

            }
            DropDownList1.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Departmentnm"].ToString();
            DropDownList2.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Location_name"].ToString();
            DropDownList3.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Modelnm"].ToString();
            DropDownList4.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Name"].ToString();
            DropDownList5.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Branch"].ToString();
            TextBox1.Text = gl.ds.Tables[0].Rows[0]["Customer_name"].ToString();
            TextBox2.Text = gl.ds.Tables[0].Rows[0]["Units"].ToString();
            TextBox3.Text = gl.ds.Tables[0].Rows[0]["Finance"].ToString();
            TextBox4.Text = gl.ds.Tables[0].Rows[0]["Status"].ToString();
            txtdate.Text = gl.ds.Tables[0].Rows[0]["Date"].ToString();
            Button1.Text = "update";
        }
        catch { }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            gl.delete("Prospects", "Prospect_id", "'" + id1 + "'");
            gl.display("Prospects", GridView1);
        }
        catch { }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPrice = (Label)e.Row.FindControl("paidmoney");

                Label lblPrice = (Label)e.Row.FindControl("Label4");

                decimal price = Decimal.Parse(lblPrice.Text);

                totalPrice += price;

                totalItems += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("Label5");


                lblTotalPrice.Text = totalPrice.ToString();
            }
        }
        catch { }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gl.query("select * from Employee_Reg where Departmentnm='" + DropDownList1.SelectedItem.Text + "'");
            if (gl.ds.Tables[0].Rows.Count == 0)
            { }
            else
            {
                DropDownList4.SelectedItem.Text = gl.ds.Tables[0].Rows[0]["Name"].ToString();
            }
        }
        catch { }
    }

}    
