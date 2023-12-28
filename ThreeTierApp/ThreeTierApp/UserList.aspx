<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="ThreeTierApp.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p><a href="Userregistration.aspx">Back to Userregistration</a></p>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="1" cellspacing="1">
                <thead><td colspan="3" align="center">User List</td></thead>
                <tr>
                    <td>Name</td>
                    <td>Email</td>
                    <td>Mobile Number</td>
                    <td>Address</td>
                    <td>Country</td>
                    <td>Sex</td>
                    <td>Day of birth</td>
                </tr>
                <% foreach (BussinessObject.UserBO user in listUser)
                    { %>
                <tr>
                    <td><%Response.Write(user.Name);%></td>
                    <td><%=user.EmailID%></td>
                    <td><%=user.Mobilenumber%></td>
                    <td><%=user.address%></td>
                    <td><%=user.country%></td>
                    <td><%=user.SexName%></td>
                    <td><%=user.DOBDisplay%></td>
                </tr>
                <% } %>
            </table>
        </div>
    </form>
</body>
</html>
