<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Сторінка авторизації</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
            width: 40px;
        }
        .auto-style4 {
            width: 40px;
        }
        .auto-style5 {
            height: 26px;
            width: 123px;
        }
        .auto-style6 {
            width: 123px;
        }
        .auto-style7 {
            width: 40px;
            height: 29px;
        }
        .auto-style8 {
            width: 123px;
            height: 29px;
        }
        .auto-style9 {
            height: 29px;
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style5" style="text-align: right"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6" style="text-align: right">користувач&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="UserTextBox" runat="server" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style8" style="text-align: right">пароль &nbsp; </td>
                <td class="auto-style9">
                    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6" style="text-align: right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6" style="text-align: right">&nbsp;</td>
                <td>
                    <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Увійти" Width="86px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Logout" runat="server" OnClick="Logout_Click" Text="Вийти" Width="86px" />
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
