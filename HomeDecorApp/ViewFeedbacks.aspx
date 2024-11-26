<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="ViewFeedbacks.aspx.cs" Inherits="HomeDecorApp.ViewFeedbacks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #e83e8c;
        }
        .auto-style2 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="3" class="auto-style1">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustId" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" BorderStyle="Groove" CssClass="auto-style2" ForeColor="#CC0099">
                    <Columns>
                        <asp:BoundField DataField="CustName" HeaderText="Customer Name" />
                        <asp:BoundField DataField="FBMsg" HeaderText="Feedback" />
                        <asp:CommandField SelectText="Reply" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
