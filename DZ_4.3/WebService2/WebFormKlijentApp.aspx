<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormKlijentApp.aspx.cs" Inherits="WebService2.WebFormKlijentApp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Find employee by id<br />
        </div>
        <asp:TextBox ID="inputField" runat="server" OnTextChanged="inputField_TextChanged" Width="174px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Find" runat="server" OnClick="Find_Click" Text="Find" Width="72px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <br />
        <br />
        <asp:Label ID="ResultLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
