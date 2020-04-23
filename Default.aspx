<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_051_Mega_Challenge_War.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ButtonStart" runat="server" OnClick="ButtonStart_Click" Text="War!" />
            <br />
            <br />
            <asp:Label ID="resultLable" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
