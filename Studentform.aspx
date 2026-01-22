<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Studentform.aspx.cs" Inherits="EmployeeManagement.Studentform" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>

    <!-- Responsive -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- CSS (Linked to the Glass UI style) -->
    <link href="~/Content/Studentform.css" rel="stylesheet" runat="server" />

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
                msg.style.color = "#fca5a5"; // Soft red to match CSS
            } else {
                msg.innerHTML = "Valid";
                msg.style.color = "#4ade80"; // Bright green
            }
        }

        function validateDOJ(input, msgId) {
            var msg = document.getElementById(msgId);

            if (input.value === "") {
                msg.innerHTML = "Date required";
                msg.style.color = "#fca5a5"; // Soft red
            } else {
                msg.innerHTML = ""; // Clear error when valid
            }
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div class="container">

            <h2 style="margin-bottom: 20px; font-weight: 600; font-size: 24px;">Employee Form</h2>

            <table class="form-table">
                <tr>
                    <td>Emp ID</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="input-text" AutoPostBack="false"
                            onkeyup="validateRegex(this, /^[A-Za-z0-9]+$/, 'msgEmpId')" placeholder="Enter ID" />
                        <span id="msgEmpId"></span>
                    </td>
                </tr>

                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="input-text" AutoPostBack="false"
                            onkeyup="validateRegex(this, /^[A-Za-z ]+$/, 'msgName')" placeholder="John" />
                        <span id="msgName"></span>
                    </td>
                </tr>

                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="input-text" AutoPostBack="false"
                            onkeyup="validateRegex(this, /^[A-Za-z ]+$/, 'msgName2')" placeholder="Doe" />
                        <span id="msgName2"></span>
                    </td>
                </tr>

                <tr>
                    <td>Department</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="input-text" AutoPostBack="false" placeholder="e.g. Engineering" />
                    </td>
                </tr>

                <tr>
                    <td>Mobile</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="input-text" MaxLength="10" AutoPostBack="false"
                            onkeyup="validateRegex(this, /^[0-9]{10}$/, 'msgMobile')" placeholder="10 Digits" />
                        <span id="msgMobile"></span>
                    </td>
                </tr>

                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="input-text" AutoPostBack="false"
                            onkeyup="validateRegex(this, /^[a-zA-Z0-9._%+-]+@thermaxglobal\.com$/, 'msgEmail')" placeholder="user@thermaxglobal.com" />
                        <span id="msgEmail"></span>
                    </td>
                </tr>

                <tr>
                    <td>Address</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="input-text" AutoPostBack="false" placeholder="Full Address" />
                    </td>
                </tr>

                <tr>
                    <td>Pincode</td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="input-text" MaxLength="6" AutoPostBack="false"
                            onkeyup="validateRegex(this, /^[0-9]{6}$/, 'msgPin')" placeholder="6 Digits" />
                        <span id="msgPin"></span>
                    </td>
                </tr>

                <tr>
                    <td>Date of Joining</td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server"
                            CssClass="input-text"
                            TextMode="Date" AutoPostBack="false"
                            oninput="validateDOJ(this, 'msgDOJ')" />
                        <span id="msgDOJ"></span>
                    </td>
                </tr>

                <tr>
                    <td>Town</td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="input-text" AutoPostBack="false" placeholder="City/Town" />
                    </td>
                </tr>

            </table>

            <div style="margin-top: 20px; display: flex; gap: 15px; flex-wrap: wrap;">
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

        </div>
    </form>
</body>
</html>