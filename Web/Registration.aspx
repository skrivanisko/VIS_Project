<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Web.Registration" %>

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
        <p style="margin-left: 640px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
        <p style="margin-left: 640px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; REGISTRACE</p>
        <p style="margin-left: 640px">
            &nbsp;</p>
        <p style="margin-left: 640px">
            Login:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="LoginText" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 640px">
            Heslo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:TextBox ID="PassText" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 640px">
            Jméno:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="NameText" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 640px">
            Příjmení:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="SurnameText" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 640px">
            Datum narození:&nbsp;&nbsp;
            <asp:TextBox ID="BirthText" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 640px">
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="EmailText" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 640px">
            &nbsp;</p>
        <div style="margin-left: 720px">
&nbsp;<asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Zpět" />
&nbsp;<asp:Button ID="FinishRegistrationButton" runat="server" OnClick="FinishRegistrationButton_Click" Text="Registrovat" />
        </div>
    </form>
</body>
</html>
