<%@ Page Title="" Language="C#" MasterPageFile="~/Site5.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="HomeDecorApp.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
        border: 1px solid #E83E8C;
    }
        .auto-style2 {
            width: 225px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="4" cellspacing="4" class="auto-style1">
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0099" Text="Username"></asp:Label>
            </td>
        <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="53px" Width="335px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="TextBox1" ErrorMessage="Enter the username"></asp:RequiredFieldValidator>
            </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0099" Text="Password"></asp:Label>
            </td>
        <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="53px" Width="335px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="TextBox2" ErrorMessage="Enter the password"></asp:RequiredFieldValidator>
            </td>
    </tr>
    <tr>
        <td class="auto-style2">
                <asp:Button ID="Button1" runat="server" BackColor="#CCCCFF" ForeColor="#CC0099" Height="59px" Text="Login" Width="219px" OnClick="Button1_Click" />
            </td>
        <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0099"></asp:Label>
            </td>
    </tr>
    <tr>
        <td class="auto-style2">
                &nbsp;</td>
        <td>
                &nbsp;</td>
    </tr>
</table>
</asp:Content>
