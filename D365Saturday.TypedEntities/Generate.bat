@ECHO OFF
ECHO Generating entities...

.\Bin\coretools\CrmSvcUtil.exe ^
/codewriterfilter:"CrmSvcUtilExtensions.BasicFilteringService, CrmSvcUtilExtensions" ^
/url:https://365saturday.crm11.dynamics.com/XRMServices/2011/Organization.svc ^
/namespace:TypedEntities /serviceContextName:XrmServiceContext ^
/username:jordi@365saturday.onmicrosoft.com /password:365Sat$$ ^
/out:GeneratedCode.cs

ECHO Generating option sets...
.\Bin\coretools\CrmSvcUtil.exe ^
/codewriterfilter:"Microsoft.Crm.Sdk.Samples.FilteringService, GeneratePicklistEnums" ^
/codecustomization:"Microsoft.Crm.Sdk.Samples.CodeCustomizationService, GeneratePicklistEnums" ^
/namingservice:"Microsoft.Crm.Sdk.Samples.NamingService, GeneratePicklistEnums" ^
/url:https://365saturday.crm11.dynamics.com/XRMServices/2011/Organization.svc ^
/namespace:TypedEntities /serviceContextName:XrmServiceContext ^
/username:jordi@365saturday.onmicrosoft.com /password:365Sat$$ ^
/out:OptionSets.cs

ECHO Done! :)
pause