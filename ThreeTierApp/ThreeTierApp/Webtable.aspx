<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webtable.aspx.cs" Inherits="ThreeTierApp.Webtable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 401px;
            width: 1458px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Userinfo" Font-Size="70px"></asp:Label>
        </div>
        <asp:GridView ID="GridView1" runat="server" Height="190px" Width="1458px">
        </asp:GridView>
    </form>
</body>
</html>
