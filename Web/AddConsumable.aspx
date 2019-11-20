<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddConsumable.aspx.cs" Inherits="Web.AddConsumable" %>

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
        Potravina:
        <asp:Label ID="test" runat="server" Text="Label"></asp:Label>
        <p>
            Kategorie:
            <asp:DropDownList ID="CategoryList" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            Množství:
            <asp:TextBox ID="AmountTextBox" runat="server"></asp:TextBox>
&nbsp;Porce:
            <asp:Label ID="AmountLabel" runat="server" Text="Množství"></asp:Label>
        </p>
        <asp:Calendar ID="Calendar" runat="server" Width="290px"></asp:Calendar>
        <asp:Button ID="OKButton" runat="server" OnClick="OKButton_Click" Text="OK" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Zpět" />
    </form>
</body>
</html>
