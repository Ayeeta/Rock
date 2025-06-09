// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using DocumentFormat.OpenXml.Office2013.Word;
using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Security;
using Rock.Web.UI.Controls;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;

namespace RockWeb.Blocks.Utility
{

    [DisplayName("Active Small Groups")]
    [Category("Utility > Small Groups")]
    [Description("List active small groups")]

    #region Block Attributes

   

    [LinkedPage("Related Page")]

    #endregion Block Attributes
    [Rock.SystemGuid.BlockTypeGuid("9250AF45-ECB0-40C5-929D-322794222A25")]
    

    public partial class Blocks_Utility_EA_SmallGroupList : Rock.Web.UI.RockBlock
    {

        #region Attribute Keys

        // Attribute keys are used to access the block's attributes.

        #endregion Attribute Keys

        #region PageParameterKeys

        //Page parameters are used to pass data to the block from the URL.

        #endregion PageParameterKeys

        #region Fields

        // Used for private variables.

        #endregion

        #region Properties

        // Used for public / protected properties.

        #endregion

        #region Base Control Methods

        // Overrides of the base RockBlock methods (i.e. OnInit, OnLoad)

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);           

            // This event gets fired after block settings are updated. It's nice to repaint the screen if these settings would alter it.
            this.BlockUpdated += Block_BlockUpdated;
            this.AddConfigurationUpdateTrigger(upnlContent);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Page.IsPostBack)
            {
                BindGrid();
            }


        }

        #endregion

        #region Events

        // Handlers called by the controls on your block.

        /// <summary>
        /// Handles the BlockUpdated event of the control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Block_BlockUpdated(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gSmallGroups_RowSelected(object sender, RowEventArgs e)
        {
            NavigateToLinkedPage("RelatedPage", "GroupId", (int)e.RowKeyValues["Id"]);
            
        }

      

        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            // This event is triggered when the text in the search box changes.
            // It can be used to filter the grid based on the search criteria.
            BindGrid();
        }

      


        #endregion

        #region Methods

        // helper functional methods (like BindGrid(), etc.)
        protected void BindGrid()
        {
            var rockContext = new RockContext();
            var groupService = new GroupService(rockContext);

            var query = groupService
                .Queryable()
                .Where(g =>
                    g.IsActive &&
                    g.GroupType.Name == "Small Group")
                .Select(g => new
                {
                    g.Id,
                    g.Name,
                    g.CreatedDateTime
                });

            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                var keyword = tbSearch.Text.Trim();
                query = query.Where(g => g.Name.Contains(keyword));
            }

            gSmallGroups.DataSource = query.ToList();
            gSmallGroups.DataBind();


            hfGroupNames.Value = string.Join("|", query.Select(g => g.Name));
        }




        #endregion
    }
}