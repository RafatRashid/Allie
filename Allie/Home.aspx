<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Allie.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 457px;
        }
    </style>
</head>
<body style="width: 460px">
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="AccountsDropDownList" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="LedgersDropDownList" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="TransactionDropDownList" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="VoucherDropDownList" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="BalanceSheetDropDownList" runat="server">
            </asp:DropDownList>
            <br />
        </div>
        <asp:Label ID="CompanyNameLabel" runat="server" Text="CompanyName"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="MonthNameLabel" runat="server" Text="MonthName"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="AddressLineOneLabel" runat="server" Text="AddressLineOne"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="IncomeLabel" runat="server" Text="Income"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="IncomeAmountLabel" runat="server" ForeColor="#66FF33" Text="IncomeAmount"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="AddressLineTwoLabel" runat="server" Text="AddressLineTwo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ExpensesLabel" runat="server" Text="Expenses"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ExpensesAmountLabel" runat="server" ForeColor="Red" Text="Expenses"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="AddressLineThreeLabel" runat="server" Text="AddressLineThree"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="BalanceLabel"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="BalanceAmountLabel" runat="server" ForeColor="Black" Text="BalanceAmount"></asp:Label>
    </form>
</body>
</html>
