<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormKlijentApp.aspx.cs" Inherits="WebServis1.WebFormKlijentApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 297px;
        }
    </style>
</head>
<body style="height: 349px">
    <form id="form1" runat="server">
        
        <asp:Label ID="Label1" runat="server" Text="Label">Konverter Valuta</asp:Label>
        <br />
        <br />
        <asp:TextBox ID="inputField" runat="server" OnTextChanged="inputField_TextChanged" Width="174px"></asp:TextBox> 
        <br />
        <br />
        
        <asp:DropDownList ID="dropdownList" runat="server">
            <asp:ListItem Selected="True" Value="bameur">BAM -&gt; EUR</asp:ListItem>
            <asp:ListItem Value="bamchf">BAM -&gt; CHF</asp:ListItem>
            <asp:ListItem Value="eurbam">EUR -&gt; BAM</asp:ListItem>
            <asp:ListItem Value="eurchf">EUR -&gt; CHF</asp:ListItem>
            <asp:ListItem Value="chfbam">CHF -&gt; BAM</asp:ListItem>
            <asp:ListItem Value="chfeur">CHF -&gt; EUR</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        
        <asp:Button ID="Convert" runat="server" Text="convert" OnClick="ConvertClick" />
        <br />
        <br />
        <asp:Label ID="ResultLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
