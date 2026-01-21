<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Studentform.aspx.cs"
    Inherits="EmployeeManagement.Studentform" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>

    <!-- Responsive -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- CSS -->
    <link href="<%= ResolveUrl("~/Content/Studentform.css") %>" rel="stylesheet" />

    <!-- Real-time Validation Scripts -->
    <script type="text/javascript">
        function validateRegex(input, regex, msgId) {
            var msg = document.getElementById(msgId);

            if (input.value.trim() === "") {
                msg.innerHTML = "";
                return;
            }

            if (!regex.test(input.value)) {
                msg.innerHTML = "Invalid input";
                msg.style.color = "red";
            } else {
                msg.innerHTML = " Valid";
                msg.style.color = "limegreen";
            }
        }

        function validateDOJ(input, msgId) {
            var msg = document.getElementById(msgId);

            if (input.value === "") {
                msg.innerHTML = "❌ Date required";
                msg.style.color = "red";
                return;
            }

            
        }
    </script>
</head>

<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="container">

        <h2 class="form-title">Employee Form</h2>

        <table class="form-table">

            <tr>
                <td class="label">Emp ID</td>
                <td class="field">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="input-text"
                        onkeyup="validateRegex(this, /^[A-Za-z0-9]+$/, 'msgEmpId')" />
                    <span id="msgEmpId"></span>
                </td>
            </tr>

            <tr>
                <td class="label">First Name</td>
                <td class="field">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input-text"
                        onkeyup="validateRegex(this, /^[A-Za-z ]+$/, 'msgName')" />
                    <span id="msgName"></span>
                </td>
            </tr>

            <tr>
                <td class="label">Last Name</td>
                <td class="field">
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="input-text"
                        onkeyup="validateRegex(this, /^[A-Za-z ]+$/, 'msgName2')" />
                    <span id="msgName2"></span>
                </td>
            </tr>

            <tr>
                <td class="label">Department</td>
                <td class="field">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="input-text" />
                </td>
            </tr>

            <tr>
                <td class="label">Mobile</td>
                <td class="field">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="input-text" MaxLength="10"
                        onkeyup="validateRegex(this, /^[0-9]{10}$/, 'msgMobile')" />
                    <span id="msgMobile"></span>
                </td>
            </tr>

            <tr>
                <td class="label">Email</td>
                <td class="field">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="input-text"
                        onkeyup="validateRegex(this, /^[a-zA-Z0-9._%+-]+@thermaxglobal\.com$/, 'msgEmail')" />
                    <span id="msgEmail"></span>
                </td>
            </tr>

            <tr>
                <td class="label">Address</td>
                <td class="field">
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="input-text" />
                </td>
            </tr>

            <tr>
                <td class="label">Pincode</td>
                <td class="field">
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="input-text" MaxLength="6"
                        onkeyup="validateRegex(this, /^[0-9]{6}$/, 'msgPin')" />
                    <span id="msgPin"></span>
                </td>
            </tr>

            <tr>
                <td class="label">Date of Joining</td>
                <td class="field">
                    <asp:TextBox ID="TextBox9" runat="server"
                        CssClass="input-text"
                        TextMode="Date"
                        oninput="validateDOJ(this, 'msgDOJ')" />
                    <span id="msgDOJ"></span>
                </td>
            </tr>

            <tr>
                <td class="label">Town</td>
                <td class="field">
                    <asp:TextBox ID="TextBox10" runat="server" CssClass="input-text" />
                </td>
            </tr>

        </table>

        <div style="margin-top:20px">
            <asp:Button ID="AddEmpDetails" runat="server"
                Text="Add Employee"
                CssClass="btn btn-add"
                OnClick="AddEmpDetails_Click" />

            <asp:Button ID="Button1" runat="server"
                Text="Clear"
                CssClass="btn btn-clear"
                OnClick="Button1_Click" />

            <asp:Button ID="export" runat="server"
                Text="Export"
                CssClass="btn btn-export"
                OnClick="export_Click" />
        </div>

        <br />

        <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="false"
            AllowPaging="true"
            PageSize="5"
            CssClass="grid"
            OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting"
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            OnPageIndexChanging="GridView1_PageIndexChanging">

            <Columns>
                <asp:CommandField ShowEditButton="true"
                    ShowDeleteButton="true"
                    ShowSelectButton="true" />

                <asp:BoundField DataField="EmpId" HeaderText="Emp ID" />
                <asp:BoundField DataField="EmpName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="DeptName" HeaderText="Department" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                <asp:BoundField DataField="EmailID" HeaderText="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                <asp:BoundField DataField="Doj" HeaderText="DOJ" />
                <asp:BoundField DataField="Town" HeaderText="Town" />
            </Columns>
        </asp:GridView>

        <asp:Timer ID="Timer1" runat="server"
            Interval="300000"
            OnTick="Timer1_Tick" />

    </div>
</form>
</body>
</html>
