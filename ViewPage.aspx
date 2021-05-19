<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="WebApplication1.ViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View</title>
    <link rel="stylesheet" href="StyleSheet1.css" type="text/css"/>
</head>

<body>
    <form id="viewpage" runat="server">
        
         <div class="container">
              <h1>View database information</h1>
            <div class="tableDiv">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Id" OnPageIndexChanging="PageIndexChanging" OnRowCancelingEdit="RowCancelingEdit" 
                    OnRowDeleting="RowDeleting" OnRowEditing="RowEditing" OnRowUpdating="RowUpdating">
                    <HeaderStyle Font-Names="Arial" Height="50px"/>
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="PasswordVal" HeaderText="Password" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
              <br />
                <asp:Button ID="BtnRegister" CssClass="btn" runat="server" OnClick="BtnRegister_click" Text="Register" />
                <br />
            </div>

        </div>
       <div class="footer">
            <strong>(C) 2021</strong>
        </div> 
    </form>
    
</body>
</html>

