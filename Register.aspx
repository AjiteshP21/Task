<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Tsk_Login.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
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
            <div class="form-group">
                <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName" Text="Name:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" Placeholder="Please Enter your Name" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblRadio" runat="server" Text="Gender:" CssClass="form-label"></asp:Label>
                <div class="form-check form-check-inline">
                    <asp:RadioButton ID="RbMale" runat="server" Text="Male" GroupName="gender" CssClass="form-check-input" />
                </div>
                <div class="form-check form-check-inline">
                    <asp:RadioButton ID="RbFemale" runat="server" Text="Female" GroupName="gender" CssClass="form-check-input" />
                </div>
            </div>
            <div class="form-group mt-3">
                <asp:Label ID="lblPlace" runat="server" AssociatedControlID="ddlPlace" Text="Place:" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlPlace" runat="server" CssClass="form-control">
                    <asp:ListItem Text="---Option---" Value=""></asp:ListItem>
                    <asp:ListItem Text="Mumbai" Value="Mumbai"></asp:ListItem>
                    <asp:ListItem Text="Pune" Value="Pune"></asp:ListItem>
                    <asp:ListItem Text="Satara" Value="Satara"></asp:ListItem>
                    <asp:ListItem Text="Delhi" Value="Delhi"></asp:ListItem>
                    <asp:ListItem Text="Thane" Value="Thane"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername" Text="Username:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" Placeholder="Please enter a username" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl_Password" runat="server" AssociatedControlID="txt_Password" Text="Confirm Password:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="btn btn-primary mt-3" />
                 <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="Btn_Back" CssClass="btn btn-secondary mt-3" />
            </div>
            <div class="form-group">
                <asp:Label ID="successMessage" runat="server" ForeColor="green"></asp:Label>
            </div>
            
            <div class="form-group">
                <asp:Label ID="errorMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
