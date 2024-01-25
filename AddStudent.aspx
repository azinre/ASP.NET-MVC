<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student </title>
    <link rel="stylesheet" href="App_Themes/Theme1/SiteStyles.css" />    
</head>
<body>
    <h1>Students</h1>
    <form id="form1" runat="server">
        <div>          
            <asp:Label ID="lblName" runat="server" Text="Student Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
            ErrorMessage="Name is required." EnableClientScript="true"  CssClass="error">Name is required.</asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label for="ddlType" runat="server" Text="Student Type:"></asp:Label>            
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
                <asp:ListItem Text="Full Time" Value="FullTime"></asp:ListItem>
                <asp:ListItem Text="Part Time" Value="PartTime"></asp:ListItem>
                <asp:ListItem Text="Coop" Value="Coop"></asp:ListItem>
            </asp:DropDownList><br />
            <asp:RequiredFieldValidator ID="rfvStudentType" runat="server" ControlToValidate="ddlType" InitialValue="-1" Display="Dynamic"
            ErrorMessage="Must Select One!"  CssClass="error"></asp:RequiredFieldValidator>

            

        </div>
        <div>
            <asp:Button ID="btnAdd" runat="server" Text="Add Student" OnClick="btnAdd_Click" />
        </div> 
        <div>
            <asp:Table ID="tblStudents" runat="server"  CssClass="table table-striped"> 
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>             
                </asp:TableHeaderRow>
                <asp:TableRow ID="tblMessage"> 
                    <asp:TableCell ColumnSpan="2"><span class="error">No students yet</span></asp:TableCell>
                </asp:TableRow>
            </asp:Table> 
          </div>
        <br />
        <div>
            <a href="RegisterCourse.aspx">Register for Courses</a>
        </div>
    </form>
    
</body>
</html>


