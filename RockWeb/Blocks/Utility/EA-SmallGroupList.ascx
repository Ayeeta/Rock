<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EA-SmallGroupList.ascx.cs" Inherits="RockWeb.Blocks.Utility.Blocks_Utility_EA_SmallGroupList" %>
<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>    

        <asp:HiddenField ID="hfGroupNames" runat="server" />

        <div class="row margin-b-md">
            <div class="col-md-6">
                <asp:TextBox ID="tbSearch" runat="server" CssClass="form-control"
                             AutoPostBack="true" OnTextChanged="tbSearch_TextChanged"
                             Placeholder="Type to search group name..." />
            </div>
        </div>

       
        <style>
            .ui-autocomplete {
                background-color: white !important;
                border: 1px solid #ccc;
                z-index: 10000 !important;
                list-style: none; 
                padding-left: 0;
                margin: 0;
                max-height: 200px;
                overflow-y: auto;
            }

            .ui-menu-item-wrapper {
                cursor: pointer;
                padding: 8px 12px;
            }
        </style>

       
        <script type="text/javascript">
            Sys.Application.add_load(function () {
                var groupNames = $('#<%= hfGroupNames.ClientID %>').val().split('|');

                $('#<%= tbSearch.ClientID %>').autocomplete({
                    source: groupNames,
                    select: function (event, ui) {
                        $(this).val(ui.item.value);
                        __doPostBack('<%= tbSearch.UniqueID %>', '');
                    }
                });
            });
        </script>

        <Rock:Grid ID="gSmallGroups" runat="server" AllowSorting="true" ShowActionRow="true"
                   OnRowSelected="gSmallGroups_RowSelected" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Group Name" />
                <asp:BoundField DataField="CreatedDateTime" HeaderText="Date Created" />
            </Columns>
        </Rock:Grid>

    </ContentTemplate>
</asp:UpdatePanel>
