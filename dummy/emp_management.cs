
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Spire.Xls;            //added spire
using System.IO;
using Spire.Xls.Charts;
using Spire.Xls.Core.Spreadsheet.Charts;
using System.Drawing;
using System.Collections;
using Spire.Xls.Collections;

namespace Demo2
{
    public partial class Studentform : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataRow dr;
        public ArrayList gdv1update = new ArrayList();
       
      public  System.Data.DataTable data = new System.Data.DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DefaultEmpRecord();
                TextBox5.Text = "@thermaxglobal.com";
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Leave this method empty
        }

        private void DefaultEmpRecord()
        {
            //creating dataTable   
            dt.TableName = "EmployeeDetails";
            dt.Columns.Add(new DataColumn("EmpId", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            dt.Columns.Add(new DataColumn("DeptName", typeof(string)));
            dt.Columns.Add(new DataColumn("Mobile", typeof(string)));
            dt.Columns.Add(new DataColumn("EmailID", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("Pincode", typeof(string)));
            dt.Columns.Add(new DataColumn("Doj", typeof(string)));
            dt.Columns.Add(new DataColumn("Town", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["EmployeeDetails"] = dt;
            //bind Gridview   
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void AddNewRecordRowToGrid()
        {
            if (ViewState["EmployeeDetails"] != null)
            {
                // Get datatable from ViewState
                DataTable dtCurrentTable = (DataTable)ViewState["EmployeeDetails"];
                DataRow drCurrentRow = dtCurrentTable.NewRow();

                string newfname = TextBox1.Text; // fname
                string newlname = TextBox6.Text; //last name
                string newEmpId = TextBox2.Text; //id
                string newdept = TextBox3.Text;//dept
                string newmobile = TextBox4.Text;//mobile
                string newemail = TextBox5.Text;//
                string newaddress = TextBox7.Text;
                string newpincode = TextBox8.Text;
                string newdoj = TextBox9.Text;
                string newtown = TextBox10.Text;

                bool duplicate = false;

                foreach (DataRow row in dtCurrentTable.Rows)
                {
                    if (row["EmpId"].ToString() == newEmpId || row["Mobile"].ToString() == newmobile || row["EmailID"].ToString() == newemail)
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (!duplicate)
                {
                    // Add the data to the current row
                    drCurrentRow["EmpId"] = TextBox2.Text;
                    drCurrentRow["EmpName"] = TextBox1.Text;
                    drCurrentRow["LastName"] = TextBox6.Text;
                    drCurrentRow["DeptName"] = TextBox3.Text;
                    drCurrentRow["Mobile"] = TextBox4.Text;
                    drCurrentRow["EmailID"] = TextBox5.Text;
                    drCurrentRow["Address"] = TextBox7.Text;
                    drCurrentRow["Pincode"] = TextBox8.Text;
                    drCurrentRow["Doj"] = TextBox9.Text;
                    drCurrentRow["Town"] = TextBox10.Text;

                    // Add the row to the DataTable
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }
                    // Bind GridView with the updated DataTable
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Duplicate Records Cannot Be Entered')", true);
                }
            }

        }
        protected void AddEmpDetails_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("EmpId", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            dt.Columns.Add(new DataColumn("DeptName", typeof(string)));
            dt.Columns.Add(new DataColumn("Mobile", typeof(string)));
            dt.Columns.Add(new DataColumn("EmailID", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("Pincode", typeof(string)));
            dt.Columns.Add(new DataColumn("Doj", typeof(string)));
            dt.Columns.Add(new DataColumn("Town", typeof(string)));
            string EmpId = string.Empty;
            string EmpName = string.Empty;
            string LastName = string.Empty;
            string DeptName = string.Empty;
            string Mobile = string.Empty;
            string EmailID = string.Empty;
            string Address = string.Empty;
            string Pincode = string.Empty;
            string Doj = string.Empty;
            string Town = string.Empty;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = (GridViewRow)GridView1.Rows[i];
                if (i != e.RowIndex)
                {
                    EmpId = row.Cells[1].Text;
                    EmpName = row.Cells[2].Text;
                    LastName = row.Cells[3].Text;
                    DeptName = row.Cells[4].Text;
                    Mobile = row.Cells[5].Text;
                    EmailID = row.Cells[6].Text;
                    Address = row.Cells[7].Text;
                    Pincode = row.Cells[8].Text;
                    Doj = row.Cells[9].Text;
                    Town = row.Cells[10].Text;
                }
                else
                {
                    EmpId = ((TextBox)row.Cells[1].Controls[0]).Text;
                    EmpName = ((TextBox)row.Cells[2].Controls[0]).Text;
                    LastName = ((TextBox)row.Cells[3].Controls[0]).Text;
                    DeptName = ((TextBox)row.Cells[4].Controls[0]).Text;
                    Mobile = ((TextBox)row.Cells[5].Controls[0]).Text;
                    EmailID = ((TextBox)row.Cells[6].Controls[0]).Text;
                    Address = ((TextBox)row.Cells[7].Controls[0]).Text;
                    Pincode = ((TextBox)row.Cells[8].Controls[0]).Text;
                    Doj = ((TextBox)row.Cells[9].Controls[0]).Text;
                    Town = ((TextBox)row.Cells[10].Controls[0]).Text;
                }
                DataRow dr = dt.NewRow();
                dr["EmpId"] = EmpId;
                dr["EmpName"] = EmpName;
                dr["LastName"] = LastName;
                dr["DeptName"] = DeptName;
                dr["Mobile"] = Mobile;
                dr["EmailID"] = EmailID;
                dr["Address"] = Address;
                dr["Pincode"] = Pincode;
                dr["Doj"] = Doj;
                dr["Town"] = Town;
                dt.Rows.Add(dr);
            }
            GridView1.EditIndex = -1;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            //odd
            //TextBox txtEmpId = row.Cells[1].Controls[0] as TextBox;
            //TextBox txtEmpName = row.Cells[2].Controls[0] as TextBox;
            //TextBox txtLastName = row.Cells[3].Controls[0] as TextBox;
            //TextBox txtDeptName = row.Cells[4].Controls[0] as TextBox;
            //TextBox txtMobile = row.Cells[5].Controls[0] as TextBox;
            //TextBox txtEmailID = row.Cells[6].Controls[0] as TextBox;
            //TextBox txtAddress = row.Cells[7].Controls[0] as TextBox;
            //TextBox txtPincode = row.Cells[8].Controls[0] as TextBox;
            //TextBox txtDoj = row.Cells[9].Controls[0] as TextBox;
            //TextBox txtTown = row.Cells[10].Controls[0] as TextBox;

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("EmpId", typeof(string)));
            dt.Columns.Add(new DataColumn("EmpName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            dt.Columns.Add(new DataColumn("DeptName", typeof(string)));
            dt.Columns.Add(new DataColumn("Mobile", typeof(string)));
            dt.Columns.Add(new DataColumn("EmailID", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("Pincode", typeof(string)));
            dt.Columns.Add(new DataColumn("Doj", typeof(string)));
            dt.Columns.Add(new DataColumn("Town", typeof(string)));

            string EmpId = string.Empty;
            string EmpName = string.Empty;
            string LastName = string.Empty;
            string DeptName = string.Empty;
            string Mobile = string.Empty;
            string EmailID = string.Empty;
            string Address = string.Empty;
            string Pincode = string.Empty;
            string Doj = string.Empty;
            string Town = string.Empty;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = (GridViewRow)GridView1.Rows[i];
                if (i != e.RowIndex)
                {
                    EmpId = row.Cells[1].Text;
                    EmpName = row.Cells[2].Text;
                    LastName = row.Cells[3].Text;
                    DeptName = row.Cells[4].Text;
                    Mobile = row.Cells[5].Text;
                    EmailID = row.Cells[6].Text;
                    Address = row.Cells[7].Text;
                    Pincode = row.Cells[8].Text;
                    Doj = row.Cells[9].Text;
                    Town = row.Cells[10].Text;
                    dt.Rows[e.RowIndex].Delete();
                    dt.AcceptChanges();


                    DataRow dr = dt.NewRow();
                    dr["EmpId"] = EmpId;
                    dr["EmpName"] = EmpName;
                    dr["LastName"] = LastName;
                    dr["DeptName"] = DeptName;
                    dr["Mobile"] = Mobile;
                    dr["EmailID"] = EmailID;
                    dr["Address"] = Address;
                    dr["Pincode"] = Pincode;
                    dr["Doj"] = Doj;
                    dr["Town"] = Town;
                    dt.Rows.Add(dr);
                }
            }
            GridView1.EditIndex = -1;
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindEmpDetails();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindEmpDetails();
        }

        protected void BindEmpDetails()
        {
            if (ViewState["EmployeeDetails"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["EmployeeDetails"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //add each row into data table   
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["EmpId"] = TextBox2.Text;
                        drCurrentRow["EmpName"] = TextBox1.Text;
                        drCurrentRow["LastName"] = TextBox6.Text;
                        drCurrentRow["DeptName"] = TextBox3.Text;
                        drCurrentRow["Mobile"] = TextBox4.Text;
                        drCurrentRow["EmailID"] = TextBox5.Text;
                        drCurrentRow["Address"] = TextBox7.Text;
                        drCurrentRow["Pincode"] = TextBox8.Text;
                        drCurrentRow["Doj"] = TextBox9.Text;
                        drCurrentRow["Town"] = TextBox10.Text;
                    }
                    //Remove initial blank row   
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }
                    //Bind Gridview with latest Row   
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
        }

        // TEXTBOX
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        } // emp id   
        protected void TextBox4_TextChanged1(object sender, EventArgs e)
        {
            string mobile = TextBox4.Text.Trim();
            int mobilenumber;

            if (!int.TryParse(TextBox4.Text, out mobilenumber))
            {
                if (mobile.Length != 10)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter a valid 10-digit Mobile No.')", true);
                    TextBox4.Text = "";
                }
            }

        } //mobile

        protected void Button1_Click(object sender, EventArgs e) // clear button 
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = "@thermaxglobal.com";
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
            TextBox9.Text = string.Empty;
            TextBox10.Text = string.Empty;

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Text  = GridView1.SelectedRow.Cells[1].Text;
            TextBox1.Text  = GridView1.SelectedRow.Cells[2].Text;
            TextBox6.Text  = GridView1.SelectedRow.Cells[3].Text;
            TextBox3.Text  = GridView1.SelectedRow.Cells[4].Text;
            TextBox4.Text  = GridView1.SelectedRow.Cells[5].Text;
            TextBox5.Text  = GridView1.SelectedRow.Cells[6].Text;
            TextBox7.Text  = GridView1.SelectedRow.Cells[7].Text;
            TextBox8.Text  = GridView1.SelectedRow.Cells[8].Text;
            TextBox9.Text  = GridView1.SelectedRow.Cells[9].Text;
            TextBox10.Text = GridView1.SelectedRow.Cells[10].Text;

        } // select button

        protected void TextBox5_TextChanged(object sender, EventArgs e) // email ID
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e) // pincode
        {
            int pin;
            if (!int.TryParse(TextBox8.Text, out pin))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter a valid Pincode')", true);
                TextBox8.Text = ""; // Clear the invalid input
            }
        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)    // cache
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int remainingTime = Timer1.Interval / 1000;

            if (remainingTime == 300)
            {
                // Display alert code (e.g., JavaScript alert)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('1 minute remaining , Save Your Details');", true);
            }

            if (remainingTime <= 60)
            {

                Response.Redirect("login.aspx");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindEmpDetails();

        }

        protected void export_Click(object sender, EventArgs e)
        {


            if (ViewState["EmployeeDetails"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Records are empty')", true);
            }
            else
            {
                Export();
            }

        }

        private void Export()
        {

            Workbook workbook = new Workbook();
            DataTable dataTable = new DataTable();
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                
                dataTable.Columns.Add(cell.Text);
            }

            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                   
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < gridViewRow.Cells.Count; i++)
                {
                    dataRow[i] = gridViewRow.Cells[i].Text;
                }
                dataTable.Rows.Add(dataRow);
            }

            Worksheet worksheet = workbook.Worksheets[0];
            CellRange range = worksheet.Range["A1:L1"];
            
            range.ColumnWidth = 20;
            range.Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            range.Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            range.Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            range.Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            range.Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            range.Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            range.Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
            range.Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            worksheet.InsertDataTable(dataTable, true, 1, 1);

           string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = "D:/data_" + timestamp + ".xlsx";

workbook.SaveToFile(fileName, ExcelVersion.Version2013);
           




            //Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application(); // it will creates a workbook in excel
            //xcelApp.Application.Workbooks.Add(Type.Missing);//to use default values

            //for (int i = 1; i < GridView1.Columns.Count - 1; i++)  //for excel cells
            //{
            //    xcelApp.Cells[1, i + 1] = GridView1.Columns[i].HeaderText; //[  1  , i + 1 ] 1 is row and i + 1 is shifted column              
            //    xcelApp.Cells[1, i + 1].Font.Size = 15;
            //    xcelApp.Cells[1, i + 1].Font.Bold = true;
            //    xcelApp.Cells[1, i + 1].Font.Color = System.Drawing.Color.Black;
            //    xcelApp.Cells[1, i + 1].Interior.Color = System.Drawing.Color.SpringGreen;
            //    xcelApp.Cells[1, i + 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //    xcelApp.Cells[1, i + 1].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
            //}

            //for (int i = 0; i < GridView1.Rows.Count; i++)                      //for rows
            //{
            //    for (int j = 0; j < GridView1.Columns.Count; j++)             //for columns data
            //    {
            //        xcelApp.Cells[i + 2, j + 1] = GridView1.Rows[i].Cells[j].Text.ToString();

            //        xcelApp.Cells[i + 2, j + 1].Font.Size = 13;
            //        xcelApp.Cells[i + 2, j + 1].Font.Bold = true;
            //        xcelApp.Cells[i + 2, j + 1].Font.Name = "Courier New";
            //        xcelApp.Cells[i + 2, j + 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //        xcelApp.Cells[i + 2, j + 1].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            //    }
            //}
            //xcelApp.Columns.AutoFit();
            //xcelApp.Visible = true;
        }

        protected void search2_TextChanged(object sender, EventArgs e)
        {
            string keyword = search2.Text;          
            BindEmpDetails();
        }

        
        
    }
}
