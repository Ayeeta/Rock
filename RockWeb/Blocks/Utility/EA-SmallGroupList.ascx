<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EA-SmallGroupList.ascx.cs" Inherits="RockWeb.Blocks.Utility.Blocks_Utility_EA_SmallGroupList" %>
<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>
        <h2 class="title">Active Small Groups</h2>

        <Rock:Grid ID="gSmallGroups" runat="server" AllowSorting="true" ShowActionRow="true"
            OnRowSelected="gSmallGroups_RowSelected" DataKeyNames="Id">

            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Group Name" />
                <asp:BoundField DataField="CreatedDateTime" HeaderText="Date Created" />
            </Columns>

        </Rock:Grid>

    </ContentTemplate>


</asp:UpdatePanel>
