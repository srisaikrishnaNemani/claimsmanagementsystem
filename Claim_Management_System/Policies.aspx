<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLoginHomePage.Master" AutoEventWireup="true" CodeBehind="Policies.aspx.cs" Inherits="Claim_Management_System.Policies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnMainPage" CssClass="button" runat="server" Text="Main Page" OnClick="btnMainPage_Click" />

    <div>
        <asp:Panel runat="server" ID="panelViewPolicy">
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lblmemberId" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:GridView ID="gridViewPlan" runat="server" AutoGenerateColumns="False" BorderColor="#E7E7FF" CssClass="auto-style8" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="JoinPolicy">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="PlanCodeId" ItemStyle-CssClass="gridview-hidden-column" HeaderStyle-CssClass="gridview-hidden-column" HeaderText="Plan Id">
                        <HeaderStyle CssClass="gridview-hidden-column" />
                        <ItemStyle CssClass="gridview-hidden-column" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
                    <asp:BoundField DataField="PlanDescription" HeaderText="Plan Description" />
                    <asp:BoundField DataField="Coverage1" HeaderText="Coverage 1 (3 months) ₹" />
                    <asp:BoundField DataField="Coverage2" HeaderText="Coverage 2 (6 months) ₹" />
                    <asp:BoundField DataField="Coverage3" HeaderText="Coverage 3 (9 months) ₹" />
                    <asp:BoundField DataField="Coverage4" HeaderText="Coverage 4 (12 months) ₹" />
                    <asp:BoundField DataField="Coverage5" HeaderText="Coverage 5 (15 months) ₹" />

                    <asp:TemplateField HeaderText="CoverageNumber">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlCoverage" runat="server" AutoPostBack="false" CssClass="box">
                                <asp:ListItem Text="Coverage1" Value="1" />
                                <asp:ListItem Text="Coverage2" Value="2" />
                                <asp:ListItem Text="Coverage3" Value="3" />
                                <asp:ListItem Text="Coverage4" Value="4" />
                                <asp:ListItem Text="Coverage5" Value="5" />
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="Join" ControlStyle-CssClass="approve_button" Text="Join">
                        <ControlStyle CssClass="approve_button" />
                    </asp:ButtonField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
