<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EA-SmallGroupDetail.ascx.cs" Inherits="RockWeb.Blocks.Utility.Blocks_Utility_EA_SmallGroupDetail" %>
<asp:UpdatePanel ID="upnlSmallGroupDetails" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlView" runat="server" CssClass="panel panel-block center-block">

            <div class="panel-heading">
                <h2 class="panel-title">
                    <i class="fa fa-star"></i>
                    <asp:Literal ID="lTitle" runat="server" />
                </h2>
               
            </div>            
            <div class="panel-body center-block">
                <asp:PlaceHolder ID="phGroupDetails" runat="server">
                    <dl class="dl-horizontal">
                        <dt>Name:</dt>
                        <dd>
                            <asp:Literal ID="lName" runat="server" /></dd>

                        <dt>Description:</dt>
                        <dd>
                            <asp:Literal ID="lDescription" runat="server" /></dd>

                        <dt>Date Created:</dt>
                        <dd>
                            <asp:Literal ID="lCreatedDate" runat="server" /></dd>

                        <dt>Date Modified:</dt>
                        <dd>
                            <asp:Literal ID="lModifiedDate" runat="server" /></dd>

                        <dt>Group Capacity:</dt>
                        <dd>
                            <asp:Literal ID="lCapacity" runat="server" /></dd>
                    </dl>
                </asp:PlaceHolder>
            </div>


        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>
