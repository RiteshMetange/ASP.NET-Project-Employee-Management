using Spire.Xls;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class Studentform : Page
    {
        DataTable dt;
        DataRow dr;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                DefaultEmpRecord();
                TextBox5.Text = "@thermaxglobal.com";
            }


            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }




        public override void VerifyRenderingInServerForm(Control control)
        {
            // Required for GridView export
        }

        /* ---------- INITIAL GRID ---------- */
        private void DefaultEmpRecord()
        {
            dt = new DataTable();
            dt.Columns.Add("EmpId");
            dt.Columns.Add("EmpName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("DeptName");
            dt.Columns.Add("Mobile");
            dt.Columns.Add("EmailID");
            dt.Columns.Add("Address");
            dt.Columns.Add("Pincode");
            dt.Columns.Add("Doj");
            dt.Columns.Add("Town");

            dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["EmployeeDetails"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        /* ---------- ADD EMPLOYEE ---------- */
        protected void AddEmpDetails_Click(object sender, EventArgs e)
        {
            AddNewRecordRowToGrid();
        }

        private void AddNewRecordRowToGrid()
        {
            if (ViewState["EmployeeDetails"] == null) return;

            DataTable table = (DataTable)ViewState["EmployeeDetails"];
            DataRow row = table.NewRow();

            foreach (DataRow r in table.Rows)
            {
                if (r["EmpId"].ToString() == TextBox2.Text)
                {
                    ClientScript.RegisterStartupScript(
                        GetType(), "dup", "alert('Duplicate Employee ID');", true);
                    return;
                }
            }

            row["EmpId"] = TextBox2.Text;
            row["EmpName"] = TextBox1.Text;
            row["LastName"] = TextBox6.Text;
            row["DeptName"] = TextBox3.Text;
            row["Mobile"] = TextBox4.Text;
            row["EmailID"] = TextBox5.Text;
            row["Address"] = TextBox7.Text;
            row["Pincode"] = TextBox8.Text;
            row["Doj"] = TextBox9.Text;
            row["Town"] = TextBox10.Text;

            if (table.Rows[0][0].ToString() == "")
                table.Rows.RemoveAt(0);

            table.Rows.Add(row);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        /* ---------- GRID EVENTS ---------- */
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindEmpDetails();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindEmpDetails();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)

        {
            DataTable table = (DataTable)ViewState["EmployeeDetails"];

            if (table == null) return;

            GridViewRow row = GridView1.Rows[e.RowIndex];

            // Update values (BoundFields use Controls[0])
            table.Rows[e.RowIndex]["EmpId"] =
                ((TextBox)row.Cells[1].Controls[0]).Text;

            table.Rows[e.RowIndex]["EmpName"] =
                ((TextBox)row.Cells[2].Controls[0]).Text;

            table.Rows[e.RowIndex]["LastName"] =
                ((TextBox)row.Cells[3].Controls[0]).Text;

            table.Rows[e.RowIndex]["DeptName"] =
                ((TextBox)row.Cells[4].Controls[0]).Text;

            table.Rows[e.RowIndex]["Mobile"] =
                ((TextBox)row.Cells[5].Controls[0]).Text;

            table.Rows[e.RowIndex]["EmailID"] =
                ((TextBox)row.Cells[6].Controls[0]).Text;

            table.Rows[e.RowIndex]["Address"] =
                ((TextBox)row.Cells[7].Controls[0]).Text;

            table.Rows[e.RowIndex]["Pincode"] =
                ((TextBox)row.Cells[8].Controls[0]).Text;

            table.Rows[e.RowIndex]["Doj"] =
                ((TextBox)row.Cells[9].Controls[0]).Text;

            table.Rows[e.RowIndex]["Town"] =
                ((TextBox)row.Cells[10].Controls[0]).Text;

            // Exit edit mode
            GridView1.EditIndex = -1;

            // Save and rebind
            ViewState["EmployeeDetails"] = table;
            GridView1.DataSource = table;
            GridView1.DataBind();
        }



        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable table = (DataTable)ViewState["EmployeeDetails"];
            if (table == null) return;

            int rowIndex = e.RowIndex + (GridView1.PageIndex * GridView1.PageSize);

            if (rowIndex >= 0 && rowIndex < table.Rows.Count)
            {
                table.Rows.RemoveAt(rowIndex);
            }

            ViewState["EmployeeDetails"] = table;
            GridView1.EditIndex = -1;
            BindEmpDetails();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            TextBox2.Text = row.Cells[1].Text;
            TextBox1.Text = row.Cells[2].Text;
            TextBox6.Text = row.Cells[3].Text;
            TextBox3.Text = row.Cells[4].Text;
            TextBox4.Text = row.Cells[5].Text;
            TextBox5.Text = row.Cells[6].Text;
            TextBox7.Text = row.Cells[7].Text;
            TextBox8.Text = row.Cells[8].Text;
            TextBox9.Text = row.Cells[9].Text;
            TextBox10.Text = row.Cells[10].Text;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindEmpDetails();
        }

        private void BindEmpDetails()
        {
            if (ViewState["EmployeeDetails"] != null)
            {
                GridView1.DataSource = (DataTable)ViewState["EmployeeDetails"];
                GridView1.DataBind();
            }
        }

        /* ---------- VALIDATION EVENTS ---------- */
        protected void TextBox2_TextChanged(object sender, EventArgs e) { }
        protected void TextBox1_TextChanged(object sender, EventArgs e) { }
        protected void TextBox5_TextChanged(object sender, EventArgs e) { }
        protected void TextBox9_TextChanged(object sender, EventArgs e) { }

        protected void TextBox4_TextChanged1(object sender, EventArgs e)
        {
            if (!long.TryParse(TextBox4.Text, out _))
            {
                ClientScript.RegisterStartupScript(
                    GetType(), "mob", "alert('Enter valid mobile number');", true);
                TextBox4.Text = "";
            }
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(TextBox8.Text, out _))
            {
                ClientScript.RegisterStartupScript(
                    GetType(), "pin", "alert('Enter valid pincode');", true);
                TextBox8.Text = "";
            }
        }

        /* ---------- CLEAR ---------- */
        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox2.Text = TextBox3.Text = "";
            TextBox4.Text = TextBox6.Text = TextBox7.Text = "";
            TextBox8.Text = TextBox9.Text = TextBox10.Text = "";
            TextBox5.Text = "@thermaxglobal.com";
        }

        /* ---------- EXPORT ---------- */
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
        protected void Export()
        {
            DataTable table = ViewState["EmployeeDetails"] as DataTable;

            if (table == null || table.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(
                    this, GetType(), "alert",
                    "alert('No records to export');", true);
                return;
            }

            // REMOVE empty first row (important)
            for (int i = table.Rows.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(table.Rows[i]["EmpId"].ToString()))
                {
                    table.Rows.RemoveAt(i);
                }
            }

            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.InsertDataTable(table, true, 1, 1);
            worksheet.AllocatedRange.AutoFitColumns();

            // ✅ SAFE export folder (Desktop instead of C:\)
            string folderPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + @"\EmployeeExports\";

            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }

            string fileName = folderPath +
                "EmployeeData_" +
                DateTime.Now.ToString("yyyyMMddHHmmss") +
                ".xlsx";

            workbook.SaveToFile(fileName, ExcelVersion.Version2013);

            ScriptManager.RegisterStartupScript(
                this, GetType(), "alert",
                $"alert('Export successful! File saved to Desktop');", true);
        }


    }
}
