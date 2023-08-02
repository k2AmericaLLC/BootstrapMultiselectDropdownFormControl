# Bootstrap multiselect Dropdown Form control
Multiselect dropdown field in page types allows to select multiple values from a dropdown.

## Description
This project contains Multiselect dropdown form control field which allows the user to select multiple values. For example, user can select multiple values in page type fields.
* Download the files provided in the git.
* Copy files in MultiSelect folder.
* Open webApp.sln and paste the provided files in CMSFormControls folder.
* Copy all JS and Css files and place them in below location of WebApp.Sln.
“CMSModules\Content\CMSDesk\App_Themes\Multi-Select”.
* Create a custom table in your admin application under the name of “MultiselectDropdown” and place the generated code in your WebApp.Sln.

## Requirements and Pre-Requisites
* Kentico Xperience 13 (supports both ASP.NET core and ASP.NET MVC 5 development modules)
* Basic knowledge of developing ASP .NET MVC 5 applications with Kentico Xperience.
* Multiselect dropdown plugin (Owned by MIT)

## Installation
* Install the Kentico instance in your local machine.
* Download the plugin for Multiselect dropdown (Owned by MIT).
  
## License
Multiselect dropdown plugin provided under MIT License.

## Using the Multiselect dropdown form control field
### Live Site
* Open the live site application and create the page layout and page templates.
### Xperience Application
* Create the custom form control in webApp.sln.
* Run the solution and login into administration application.
* Open the “Administration interface” application and switch to “form controls”. Click on “New form control” and register your form control. 
* Open the page type application and select the page type which you want to add your custom form control. Create the new fields in page editing form as per requirements. An example shown below:
  
	<img src="https://github.com/k2AmericaLLC/BootstrapMultiselectDropdownFormControl/assets/138684450/01f763c8-383a-43de-84ff-28a25346f439" alt= “Creating-fields-in-page-types” width="600" height="300">
 
	<img src="https://github.com/k2AmericaLLC/BootstrapMultiselectDropdownFormControl/assets/138684450/a5eb2775-c500-4a04-86ab-bbf62b44126c" alt= “Creating-fields-in-page-types-2” width="600" height="300">
 

* Data source can be user choice, so create a custom table. In custom table create a new filed with name “DropdownListValues” and assign validations. In my case user cannot enter duplicate values in column.
  
	<img src="https://github.com/k2AmericaLLC/BootstrapMultiselectDropdownFormControl/assets/138684450/1ff0deaf-bf65-427b-a04d-98b4f28d9094" alt= “creating-field-in-custom-tables” width="600" height="300">

* The above field should be unique. Select validation rules -> Add general condition. Add the following code in code tab.
```
foreach (i IN GlobalObjects.CustomTables["customtable.TableName"].Items){
if (i.FieldName == FieldName.Value){ 
	return false;
 }
}
return true;
``` 
* Open the Pages application -> open page type which you added the field -> select the values and save. For reference example is shown below.

  <img src="https://github.com/k2AmericaLLC/BootstrapMultiselectDropdownFormControl/assets/138684450/e31c3591-2039-436f-adba-b890a8f5c393" alt= “output” width="600" height="300">
