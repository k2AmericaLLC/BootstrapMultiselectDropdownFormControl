<% @Import Namespace="CMS.CustomTables.Types.Customtable" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BootstrapMultiselectDropdown.ascx.cs" Inherits="CMSApp.CMSFormControls.CMSFormControls_BootstrapMultiselectDropdown" %>

    <!-- Load jQuery -->
    <script src="https://code.jquery.com/jquery-3.2.1.min.js" integrity="sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4=" crossorigin="anonymous"></script>
    <!-- Load Bootstrap -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <!-- Load the plugin bundle. -->
    <link rel="stylesheet" href="../App_Themes/Multi-Select/filter_multi_select.css" />
    <script src="../App_Themes/Multi-Select/filter-multi-select-bundle.min.js"></script>

<!-- Data source can be user choice, Currenty its a sample values -->
<asp:ListBox ID="drpMultiselectOptions" runat="server" SelectionMode="Multiple" CssClass="filter-multi-select">
</asp:ListBox>



<script type="text/javascript">        
    const selectedOptions = $('[id*=drpMultiselectOptions]').filterMultiSelect({
        placeholderText: "Please select",
        filterText: "Search",
        selectAllText: "Select All"
    })
    
</script>
