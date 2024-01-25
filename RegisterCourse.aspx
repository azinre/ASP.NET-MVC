<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">   
    <title>Course Registration</title>
    <link rel="stylesheet" href="App_Themes/Theme1/SiteStyles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Algonquin College Course Registration</h1>        
        <div>
            <asp:Label for="ddlStudent" runat="server" Text="Student:" ></asp:Label>
            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" AutoPostBack="true" 
                OnSelectedIndexChanged="StudentSelectChange">
               
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvStudent" runat="server" ControlToValidate="ddlStudent"
            ErrorMessage="Must select one." Display="Dynamic" CssClass="error" InitialValue="-1"></asp:RequiredFieldValidator>                         
        </div>
        
             <asp:Label ID="studentSummary" runat="server" Text="" Visible="false" Class="distinct" ></asp:Label>            

        <h3>Following courses are available for registration</h3>         
        <asp:Label ID="lblErrorMsg" runat="server" CssClass="error" ></asp:Label>
        <asp:CheckBoxList ID="coursesSelectedLst" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CourseSelectChange" >
            </asp:CheckBoxList>  
         
        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="saveButton_Click"/><br />
        </div>
        <div>
            <a href="AddStudent.aspx" class="btn btn-secondary">Add students</a>
        </div>
    </form>
</body>
</html>

