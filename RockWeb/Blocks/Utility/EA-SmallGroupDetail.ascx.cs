using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rock;


namespace RockWeb.Blocks.Utility
{
   
    [DisplayName("Small Group Detail")]
    [Category("Utility > Small Group Details")]
    [Description("Small Group Details")]

    #region Block Attributes

    

    #endregion Block Attributes
    [Rock.SystemGuid.BlockTypeGuid("DA29EA52-4B81-4580-B6AE-CFC53AD4059B")]
    
    public partial class Blocks_Utility_EA_SmallGroupDetail : Rock.Web.UI.RockBlock
    {


        #region Attribute Keys

        // Attribute keys are used to access the block's attributes.

        #endregion Attribute Keys

        #region PageParameterKeys

        // Page parameters are used to pass data to the block from the URL.

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
            this.AddConfigurationUpdateTrigger(upnlSmallGroupDetails);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                              
               ShowGroupDetails();
            }

            base.OnLoad(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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

        }

        #endregion

        #region Methods

        // helper functional methods (like BindGrid(), etc.)
        private void ShowGroupDetails()
        {
            // Assume GroupId is passed via page parameter
            int groupId = PageParameter("GroupId").AsInteger();
            var rockContext = new RockContext();
            var groupService = new GroupService(rockContext);
            var group = groupService.Get(groupId);

            if (group != null)
            {
                lTitle.Text = group.Name;
                lName.Text = group.Name;
                lDescription.Text = group.Description;
                lCreatedDate.Text = group.CreatedDateTime?.ToShortDateString() ?? "N/A";
                lModifiedDate.Text = group.ModifiedDateTime?.ToShortDateString() ?? "N/A";
                lCapacity.Text = group.GroupCapacity.HasValue ? group.GroupCapacity.ToString() : "Unlimited";
            }
        }

        #endregion
    }
}