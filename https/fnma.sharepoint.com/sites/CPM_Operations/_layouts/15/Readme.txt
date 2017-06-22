Register the new app to get Client Id and Client Secret here:
https://tenant.sharepoint.com/<site>/_layouts/15/appregnew.aspx



Setup App permissions here using the below xml:
https://tenant.sharepoint.com/<site>/_layouts/15/appinv.aspx

<AppPermissionRequests AllowAppOnlyPolicy="true">
    <AppPermissionRequest Scope="http://sharepoint/content/sitecollection" Right="FullControl" />
</AppPermissionRequests>


Ref: https://dev.office.com/sharepoint/docs/sp-add-ins/add-in-permissions-in-sharepoint


Add the ClientId and ClientSecret in the App.config file of the solution.
<appSettings>
  <add key="ClientId" value="<From App reg new >"/>
  <add key="ClientSecret" value="<From App reg new>"/>
</appSettings>


Add the missing assemblies from the Nuget Package manager and .Net Fx if required.
