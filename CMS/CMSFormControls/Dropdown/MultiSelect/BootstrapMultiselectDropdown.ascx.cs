using System;
using System.Collections.Generic;
using System.Linq;
using CMS;
using CMS.Base;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.CustomTables;
using CMS.FormEngine.Web.UI;
using CMS.Helpers;
using org.pdfclown.util.collections.generic;
using CMS.DataEngine;
using CMS.CustomTables.Types.Customtable;
using CMS.DocumentEngine.Web.UI;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CMSApp.CMSFormControls
{
    public partial class CMSFormControls_BootstrapMultiselectDropdown : FormEngineUserControl
    {

        /// <summary>
        /// Gets or sets the value entered into the field, a color key in this case.
        /// </summary>
        public override object Value
        {
            get
            {
                var selectedValues = new List<string>();
                foreach(ListItem item in drpMultiselectOptions.Items)
                {
                    if (item.Selected)
                    {
                        selectedValues.Add(item.Value);
                    }
                }
                return selectedValues.Join(",");
            }
            set
            {
                SetSelectorWidth();
                BindListBox();

                if (value != null)
                {
                    var selectedValues = value.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (ListItem item in drpMultiselectOptions.Items)
                    {
                        item.Selected = selectedValues.Contains(item.Value);
                    }
                }
                
            }
        }

        /// <summary>
        /// Property used to access the Width parameter of the form control.
        /// </summary>
        public int SelectorWidth
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("SelectorWidth"), 0);
            }
            set
            {
                SetValue("SelectorWidth", value);
            }
        }

        //
        // Summary:
        //     Returns an array of values of any other fields returned by the control.
        //
        // Remarks:
        //     It returns an array where first dimension is attribute name and the second dimension
        //     is its value.
        public override object[,] GetOtherValues()
        {
            object[,] array = new object[1, 2];
            array[0, 0] = "SelectedValues";
            var SelectedOptions = new List<string>();
            foreach(ListItem item in drpMultiselectOptions.Items)
            {
                if (item.Selected)
                {
                    SelectedOptions.Add(item.Text);
                }
            }
            array[0, 1] = SelectedOptions.Join(",");
            return array;
        }

        /// <summary>
        /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
        /// </summary>
        public override bool IsValid()
        {
            if ((string)Value != "")
            {
                return true;
            }
            else
            {
                // Sets the form control validation error message
                this.ValidationError = "Please choose a option.";
                return false;
            }
        }

        /// <summary>
        /// Sets up the internal DropDownList control.
        /// </summary>
        protected void SetSelectorWidth()
        {
            // Applies the width specified through the parameter of the form control if it is valid
            if (SelectorWidth > 0)
            {
                drpMultiselectOptions.Width = SelectorWidth;
            }

          
        }

        /// <summary>
        /// Handler for the Load event of the control.
        /// </summary>
        protected void Page_Load(object Sender, EventArgs e)
        {
            // Initializes the drop-down list options
            if (!IsPostBack)
            {
                SetSelectorWidth();                
            }  
        }

        public void BindListBox()
        {
            string customTableClassName = "customtable.MultiselectDropdown";

            DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(customTableClassName);
            if(customTable != null)
            {
                var customTableData = CustomTableItemProvider.GetItems(customTableClassName);
                drpMultiselectOptions.DataSource = customTableData;
                drpMultiselectOptions.DataTextField = "DropdownListvalues";
                drpMultiselectOptions.DataValueField = "ItemID";
                drpMultiselectOptions.DataBind();

            }

        }
    }
}