<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="SuperUserHomePage.aspx.cs" Inherits="Claim_Management_System.SuperUserHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PanelNotification" runat="server">
        <h1>No admin present for Approval</h1>
    </asp:Panel>
    <asp:Panel ID="PanelGridView" runat="server">
        <asp:GridView ID="gridSuperUser" runat="server" CssClass="table" AutoGenerateColumns="False" BorderColor="White" Width="907px" OnRowCommand="gridSuperUser_RowCommand">
            <Columns>
                <asp:BoundField ItemStyle-CssClass="gridview-hidden-column" HeaderStyle-CssClass="gridview-hidden-column" HeaderText="Admin Id" DataField="AdminId">
                    <HeaderStyle CssClass="gridview-hidden-column"></HeaderStyle>

                    <ItemStyle CssClass="gridview-hidden-column"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="FirstName" DataField="FirstName" />
                <asp:BoundField HeaderText="LastName" DataField="LastName" />
                <asp:BoundField HeaderText="Age" DataField="Age" />
                <asp:BoundField HeaderText="Gender" DataField="Gender" />
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="approve_button" Text="Approve" CommandName="ApproveAdmin"></asp:ButtonField>
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="reject_button" Text="Reject" CommandName="RejectAdmin"></asp:ButtonField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
