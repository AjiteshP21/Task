<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Tsk_Login.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
     <style>
        .container {
             font-family: 'Verdana', 'Comic Sans MS';
            max-width: 600px;
        }/*
        .form-label {
            font-weight: bold;
        }*/
        .form-check-inline{
            margin-right: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container p-5 my-5 border">
            <%--<asp:Label ID ="lblId" runat="server" Text="EmpId" CssClass="form-label" CssClass="form-control"></asp:Label> 
            <asp:TextBox ID ="txtId" runat="server" CssClass="form-control"></asp:TextBox>--%>
            <br />
            <asp:Label ID="lblName" runat="server" Text="Employee Name" AssociatedControlID="txtName" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" PlaceHolder="Please enter your name" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="lblDesig" runat="server" Text="Designation" AssociatedControlID="txtDesig" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDesig" runat="server" PlaceHolder="Please enter your designation" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="lblPlace" runat="server" Text="Place" AssociatedControlID="txtPlace" CssClass="form-label"></asp:Label>
            <asp:TextBox ID ="txtPlace" runat="server" PlaceHolder="District / Village" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="lblState" runat="server" Text="State" AssociatedControlID="txtState" CssClass="form-label"></asp:Label>
            <asp:TextBox ID ="txtState" runat="server" PlaceHolder="State" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="lblCountry" runat="server" Text="Place" AssociatedControlID="txtCountry" CssClass="form-label"></asp:Label>
            <asp:TextBox ID ="txtCountry" runat="server" PlaceHolder="Country" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="btn_Submit" runat="server" Text="Add New Employee" OnClick="btnClick_Submit" CssClass="btn btn-success mt-3"/>
            <asp:Button ID="btn_Edit" runat="server" Text="Edit" OnClick="btnClick_Edit" CssClass="btn btn-secondary mt-3"/>
            <br />
            <asp:Button ID="btn_Delete" runat="server" Text="Delete" OnClick="btnClick_Delete" CssClass="btn btn-danger mt-3"/>
            <asp:Button ID="btn_LogOut" runat="server" Text="Log out" OnClick="btnLogOut_click" CssClass="btn btn-primary mt-3"/>
              <br />
            <asp:Label ID="errorMessage" runat="server" ></asp:Label>
        </div>
        <%--<div>
            <asp:GridView ID=" EmployeeGridView" runat="server" ></asp:GridView>
        </div>--%>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>

















<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Tsk_Login.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .container {
            font-family: Verdana, 'Comic Sans MS';
            max-width: 600px;
        }
        .form-label {
            font-weight: bold;
        }
        .form-check-inline {
            margin-right: 15px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="container p-5 my-5 border">
            <asp:Label ID="Label1" runat="server" Text="Employee Name" AssociatedControlID="txtName" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" PlaceHolder="Please enter your name" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Designation" AssociatedControlID="txtDesig" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" PlaceHolder="Please enter your designation" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Place" AssociatedControlID="txtPlace" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" PlaceHolder="District / Village" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="State" AssociatedControlID="txtState" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" PlaceHolder="State" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Country" AssociatedControlID="txtCountry" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" PlaceHolder="Country" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnClick_Submit" CssClass="btn btn-success mt-3" />
            <br />
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="EmployeeGridView" runat="server"></asp:GridView>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>--%>