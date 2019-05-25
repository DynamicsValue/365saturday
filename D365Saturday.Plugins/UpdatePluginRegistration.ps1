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
$AssemblyPath = "$scriptPath\bin\Debug\D365Saturday.Plugins.dll"
$SolutionName = 'Customizations'
$MappingJsonPath = "$scriptPath\PluginRegistrationMapping.json"
$IsWorkflowActivityAssembly = $false
$SolutionName = "Customizations"
$RegistrationType = "reset"

& "$scriptPath\..\devtools\Tools\xRMCIFramework\PluginRegistration.ps1" -Verbose -CrmConnectionString "$CrmConnectionString" -AssemblyPath "$AssemblyPath" -MappingJsonPath "$MappingJsonPath" -SolutionName $SolutionName -IsWorkflowActivityAssembly $IsWorkflowActivityAssembly -RegistrationType $RegistrationType
