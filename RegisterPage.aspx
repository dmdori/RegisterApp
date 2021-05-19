<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="WebApplication1.RegisterPage" %>


<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
    <link rel="stylesheet" href="StyleSheet1.css" type="text/css"/>
   <%-- <script language="javascript" src="ValidateRegistration.js" type="text/javascript" ></script>
    <script  language="javascript" type="text/javascript">--%>

</head>

<body>
    <form id="registerpage" runat="server">
        <h1>Welcome to the Registration Page !</h1>
        <div class="container">
            <div class="labelTop"> 
                <asp:Label ID="Label1"  runat="server">Insert personal data in the database!</asp:Label>
            </div>
            <br />
             <div class="tableDiv">
                 <table >
                     <tr>
                         <td class="tdLabel">First name:
                         </td>
                         <td >
                             <asp:TextBox ID="FirstText" runat="server"  CssClass="textBox" ></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td class="tdLabel">Last name:</td>
                         <td >
                             <asp:TextBox ID="LastText" runat="server" CssClass="textBox"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td class="tdLabel">Email:</td>
                         <td >
                             <asp:TextBox ID="EmailText" CssClass="textBox" runat="server" ></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td class="tdLabel">Password:</td>
                         <td>
                             <asp:TextBox ID="PasswText" type="password" runat="server" CssClass="textBox"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td class="tdLabel">Phone:</td>
                         <td>
                             <asp:TextBox ID="PhoneText" runat="server" CssClass="textBox"></asp:TextBox>
                         </td>
                     </tr>
                 </table>
                 <br />
                 &nbsp;<asp:Button ID="SubmitBtn" CssClass="btn" runat="server" Text="Submit" OnClick="SubmitBtn_Click"      />
               
             </div>         
            <br /> <br />  <br /> 
        </div>
        <asp:Button ID="BtnView" CssClass="btnToReg" runat="server" OnClick="BtnView_click" Text="View data" />
        <br />
        <div class="footer">
            <strong>(C) 2021</strong>
        </div>
    </form>
    
</body>

</html>
