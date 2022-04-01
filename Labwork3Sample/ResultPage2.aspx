<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultPage2.aspx.cs" Inherits="Labwork3Sample.ResultPage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Завдання 2</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 166px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" title="Завдання 2">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <br />
                    <asp:Label ID="ResultLabel" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:ListBox ID="ResultListBox" runat="server" Width="209px"></asp:ListBox>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
