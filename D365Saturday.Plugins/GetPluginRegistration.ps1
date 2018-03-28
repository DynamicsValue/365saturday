[CmdletBinding()]

param
(
	[string]$CrmConnectionString #The connection string as per CRM Sdk
)

$ErrorActionPreference = "Stop"

#Script Location
$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
Write-Verbose "Script Path: $scriptPath"

Write-Verbose "ConnectionString = $connectionString"

if ($CrmConnectionString -eq '')
{
	$CrmConnectionString = $Env:CrmCon
}
$AssemblyName = 'D365Saturday.Plugins'
$MappingJsonPath = "$scriptPath\PluginRegistrationMapping.json"

& "$scriptPath\..\devtools\Tools\xRMCIFramework\GetPluginRegistrationJsonMapping.ps1" -Verbose -CrmConnectionString "$CrmConnectionString" -AssemblyName "$AssemblyName" -MappingJsonPath "$MappingJsonPath" -solutionName "Customizations"
