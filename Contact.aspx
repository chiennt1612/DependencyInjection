<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DependencyInjection.Contact" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>

    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>  
        <table>
            <tr><td><asp:Label ID="Label1" For="txtFullname" runat="server" Text="Tên đầy đủ"></asp:Label></td><td>: <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Label ID="Label2" For="txtMobile" runat="server" Text="Mobile"></asp:Label></td><td>: <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Label ID="Label3" For="txtEmail" runat="server" Text="Email"></asp:Label></td><td>: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Label ID="Label4" For="txtContent" runat="server" Text="Content"></asp:Label></td><td>: <asp:TextBox ID="txtContent" runat="server"></asp:TextBox></td></tr>
            <tr><td></td><td><asp:Button ID="bntAction" runat="server" Text="Submit" OnClick="bntAction_Click" /></td></tr>
        </table>
        
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
