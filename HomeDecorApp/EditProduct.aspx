<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="HomeDecorApp.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #e83e8c;
        }
        .auto-style2 {
            width: 636px;
            height: 539px;
        }
        .auto-style3 {
            height: 539px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="3" class="auto-style1">
        <tr>
            <td class="auto-style3">
                <asp:Panel ID="Panel1" runat="server" Width="700px">
                    <table cellspacing="3" class="auto-style1">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProdId" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="catName" HeaderText="Category Name">
                                        <HeaderStyle ForeColor="#993399" Height="10px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="prodName" HeaderText="Product Name">
                                        <HeaderStyle ForeColor="#993399" Height="10px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="prodDesc" HeaderText="Product Description">
                                        <HeaderStyle ForeColor="#993399" Height="10px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="prodPrice" HeaderText="Price">
                                        <HeaderStyle ForeColor="#993399" Height="10px" />
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="prodStock" HeaderText="Stock">
                                        <HeaderStyle ForeColor="#993399" Height="10px" />
                                        <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:ImageField DataImageUrlField="prodImage" HeaderText="Product Imge">
                                            <HeaderStyle ForeColor="#993399" Height="10px" />
                                            <ControlStyle Height="140px" Width="140px" />
                                        </asp:ImageField>
                                        <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                                        <ItemStyle Width="70px" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True">
                                        <ItemStyle Width="70px" />
                                        </asp:CommandField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="auto-style2">
                <asp:Panel ID="Panel2" runat="server" Height="700px" Width="500px" Visible="False">
                    <table cellpadding="4" cellspacing="3" class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#FF33CC" Text="Category Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="42px" Width="340px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Please select the category" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#FF33CC" Text="Product Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="54px" Width="326px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter the product name" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#FF33CC" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="66px" TextMode="MultiLine" Width="326px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please give the product decription" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#FF33CC" Text="Product price (in Rupees)"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Height="63px" Width="326px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please enter the product price" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#FF33CC" Text="Product stock"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Height="54px" Width="326px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please enter the product stock" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" BackColor="#CCCCFF" ForeColor="#CC0099" Height="76px" Text="Update" Width="231px" OnClick="Button1_Click" />
            </td>
            <td>
                 <asp:Button ID="Button2" runat="server" Height="81px" OnClick="Button2_Click" Text="Cancel" Width="253px" /></td>
            <td>&nbsp;</td>
            <td>
              &nbsp;

            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
                </asp:Panel>
            </td>
            <td class="auto-style2">
                </td>
            <td class="auto-style2">
                </td>
            <td class="auto-style2">
                </td>
            <td class="auto-style3">
                </td>
        </tr>
    </table>
                
            </asp:Content>
