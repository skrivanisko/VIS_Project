<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DietPlanForm.aspx.cs" Inherits="Web.DietPlanForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DropDownList ID="ConsumablesChoice" runat="server" Height="36px" OnSelectedIndexChanged="ConsumablesChoice_SelectedIndexChanged" Width="391px">
        </asp:DropDownList>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SelectConsumableButton" runat="server" OnClick="SelectConsumableButton_Click" Text="Přidej Potravinu" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Calendar ID="Calendar" runat="server" Height="94px" OnSelectionChanged="Calendar_SelectionChanged" Width="392px"></asp:Calendar>
        <div style="margin-left: 160px">
            <asp:Button ID="PercentageButton" runat="server" OnClick="PercentageButton_Click" Text="Percentage" />
            <asp:Button ID="UpdateMacros" runat="server" OnClick="UpdateMacros_Click" Text="Nomální Makra" />
        </div>
        <br />
        <asp:ListBox ID="DietPlan" runat="server" Height="273px" style="margin-bottom: 0px" Width="399px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BackButton" runat="server" Height="29px" Text="Zpět" Width="99px" OnClick="BackButton_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DeleteButton" runat="server" Text="Smazat" Width="92px" OnClick="DeleteButton_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DetailButton" runat="server" Text="Detail" Width="86px" OnClick="DetailButton_Click" />
        <br />
&nbsp;<asp:Label ID="Macros" runat="server" Text="Macros"></asp:Label>
    </form>
</body>
</html>
