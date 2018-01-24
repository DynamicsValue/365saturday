<?xml version="1.0"?>
<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
  <appSettings>
    <add key="CRMUsername" value="@@CrmUsername" 
         xdt:Transform="SetAttributes" xdt:Locator="Match(key)" />
    <add key="CRMPassword" value="@@CrmPassword@@"
         xdt:Transform="SetAttributes" xdt:Locator="Match(key)" />
    <add key="CRMUrl" value="@@CrmUrl@@"
         xdt:Transform="SetAttributes" xdt:Locator="Match(key)" />
  </appSettings>
</configuration>