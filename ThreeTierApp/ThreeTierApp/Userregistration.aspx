<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Userregistration.aspx.cs" Inherits="ThreeTierApp.Userregistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #cars {
            height: 27px;
            width: 151px;
        }
        #txtcountry {
            height: 19px;
            width: 159px;
        }
        #txtdbo {
            height: 22px;
            width: 151px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0px auto; padding-le padding-right: 30px;overflow: auto;">  
        <div> 
            <table style="width :50%">  
                <tr>  
                    <td colspan="2" style="background-color: Green; height: 30px;color: White;" align="center">  
                        User Registration  
                    </td>  
                </tr>  
                <tr>  
                    <td> Name </td>  
                    <td>  
           <asp:TextBox ID="txtname" Width="150px" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>  
                        Address </td>  
                    <td>  
            <asp:TextBox ID="txtAddress" Width="150px" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td> EmailID </td>  
             <td>  
            <asp:TextBox ID="txtEmailid" Width="150px" runat="server"></asp:TextBox>  
             </td>  
                </tr>  
                <tr>  
                    <td> Mobile Number   </td>  
                    <td>  
            <asp:TextBox ID="txtmobile" Width="150px" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td> Country   </td>  
                    <td>                          
                          <asp:DropDownList ID="txtcountry" runat="server" OnSelectedIndexChanged="txtcountry_SelectedIndexChanged">
                              <asp:ListItem>USA</asp:ListItem>
                              <asp:ListItem>VietNam</asp:ListItem>                              
                          </asp:DropDownList>

                    </td>  
                </tr>
                <tr>  
                    <td> Sex   </td> 
                    <td>                                                                 
                        <asp:RadioButtonList ID="txtsex" runat="server" Width="154px">
                            <asp:ListItem Value="True">Male</asp:ListItem>
                            <asp:ListItem Value="False">Female</asp:ListItem>
                        </asp:RadioButtonList>                        
                    </td>
                    <td>  
                        &nbsp;</td>  
                </tr>
                <tr>  
                    <td> Date of birth   </td>
                        <label><td>
                            <input type="date" id="txtdbo" name="dbo" runat="server" />
                               </td></label>
                    <td>  
                        &nbsp;</td>  
                </tr>
                <tr>  
                    <td align="center" colspan="2">  
                        <asp:Button ID="BtnSave" runat="server" Width="100px" Text="Save" OnClick="BtnSave_Click" />                        
                    </td>  
                </tr> 
                <tr>
                    <td colspan="2"><span style="color:red; font-size:50px;"><%=ErrorMessage%></span></td>
                </tr>
            </table>  
        </div>  
    </div>  
    </form>  
</body>  
</html>  
