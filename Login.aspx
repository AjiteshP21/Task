<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tsk_Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>

        .container {
            font-family: 'Verdana', 'Comic Sans MS';
            max-width: 600px;
        }
        .form-check-inline {
            margin-right: 15px;
        }
        .form-group {
            margin-bottom: 1rem;
        }
        .form-control {
            margin-top: .25rem;
        }
        .btn {
            margin-right: .5rem;
        }
        .alert {
            margin-top: 1rem;
        }
    </style> 

</head>
<body>
    <form id="form1" runat="server">
        <div class="container p-5 my-5 border">
            <asp:Label ID="lblUserName" runat="server" AssociatedControlID="txtUsername" Text="Name : " CssClass="form-label mt-3 "></asp:Label>
            <asp:TextBox ID ="txtUsername" runat="server" CssClass="form-label"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password : "  CssClass="form-label mt-3"></asp:Label>
            <asp:TextBox ID ="txtPassword" runat="server" Textmode="Password" CssClass="form-label"></asp:TextBox>
            <br />
            <asp:Button ID="btn_submit" runat="server" Text="Log in" OnClick="Loadbtn_submit" CssClass="btn btn-primary mt-3 mr-5"/>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btn_register" CssClass="btn btn-secondary mt-3 mr-5"/>
            <br />
            <asp:Label ID="errorMessage" runat="server" CssClass="danger"></asp:Label>
            <br />
            <asp:Label ID ="loginMessage" runat="server" CssClass="success"></asp:Label>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>

