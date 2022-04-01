<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Labwork3Sample.MainPage" %>

<!DOCTYPE html>

<script runat="server">
    void Task1Button_Click(object sender, EventArgs e)
    {
        var years = new HashSet<int>();
        if (YearsDropDown.SelectedValue != "Усі роки")
        {
            years.Add(int.Parse(YearsDropDown.SelectedValue));
        }
        else
        {
            foreach (var item in YearsDropDown.Items)
            {
                if (int.TryParse(item.ToString(), out var year))
                {
                    years.Add(year);
                }
            }
        }
        Session["years"] = years;
        // Transfer call is redundant because Task1Button PostBackUrl property was manually set to "~/ResultPage1.aspx"
        //Server.Transfer("ResultPage1.aspx");
    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>Головна сторінка</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 53px;
        }

        .auto-style3 {
            width: 319px;
        }

        .auto-style4 {
            width: 339px;
        }

        .auto-style5 {
            width: 336px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3"><strong>Пацієнти</strong></td>
                    <td class="auto-style4"><strong>Лікарі</strong></td>
                    <td class="auto-style5"><strong>Прийом пацієнтів</strong></td>
                    <td>Рік</td>
                </tr>
                <tr>
                    <td class="auto-style2" style="vertical-align: top">&nbsp;</td>
                    <td class="auto-style3" style="vertical-align: top">
                        <asp:GridView ID="PatientsGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                    <td class="auto-style4" style="vertical-align: top">
                        <asp:GridView ID="DoctorsGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </td>
                    <td class="auto-style5" style="vertical-align: top">
                        <asp:GridView ID="VisitsGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                    <td style="vertical-align: top">
                        <asp:DropDownList ID="YearsDropDown" runat="server" Height="25px" Width="204px">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button ID="Task1Button" runat="server" Text="Завдання 1" Width="204px" OnClick="Task1Button_Click" Height="28px" PostBackUrl="~/ResultPage1.aspx" />
                        <br />
                        <br />
                        <asp:Button ID="Task2Button" runat="server" Text="Завдання 2" Width="204px" OnClick="Task2Button_Click" Height="28px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
