<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="HomeDecorApp.EditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #e83e8c;
        }
        .auto-style2 {
            width: 806px;
        }
        .auto-style3 {
            width: 991px;
        }
        .auto-style4 {
            width: 7px;
        }
        .auto-style5 {
            width: 991px;
            height: 59px;
        }
        .auto-style6 {
            height: 59px;
        }
        .auto-style7 {
            width: 7px;
            height: 59px;
        }
        .auto-style8 {
            height: 153px;
        }
        .auto-style10 {
            color: #FF33CC;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="3" class="auto-style1">
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style5"></td>
            <td class="auto-style5"></td>
            <td class="auto-style6"></td>
            <td class="auto-style7"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="300px" Width="687px" DataKeyNames="CatId" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="CatName" HeaderText="Category Name">
                        <HeaderStyle BorderStyle="Solid" ForeColor="#CC0099" Height="7px" Width="25px" />
                        <ItemStyle Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CatDesc" HeaderText="Category description">
                        <HeaderStyle BorderStyle="Solid" ForeColor="#CC0099" Height="7px" />
                        <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="CatImage" HeaderText="Category image">
                            <ControlStyle Height="130px" Width="130px" />
                            <HeaderStyle BorderStyle="Double" ForeColor="#CC0099" Height="7px" Width="15px" />
                            <ItemStyle Width="100px" />
                        </asp:ImageField>
                        <asp:CommandField ShowSelectButton="True" SelectText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="762px" Width="893px" Visible="False">
                    <table cellpadding="3" cellspacing="3" class="auto-style1">
                        <caption>
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#FF33CC"></asp:Label>
                        </caption>
        <tr>
            <td class="auto-style10" colspan="2">Enter the new details corresponding to the category:-</td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#FF33CC" Text="Category Name"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="TextBox1" runat="server" Height="54px" Width="326px"></asp:TextBox>
            </td>
            <td class="auto-style8">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter the category name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
       
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#FF33CC" Text="Category description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="54px" Width="326px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please give a description" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" BackColor="#CCCCFF" ForeColor="#CC0099" Height="86px" Text="Update" Width="284px" OnClick="Button1_Click" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Height="81px" OnClick="Button2_Click" Text="Cancel" Width="214px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
                </asp:Panel>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
