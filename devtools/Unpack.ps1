[CmdletBinding()]

param
(
	[string]$connectionString #The connection string as per CRM Sdk
)

$ErrorActionPreference = "Stop"

#Script Location
$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
Write-Verbose "Script Path: $scriptPath"

Write-Verbose "ConnectionString = $connectionString"

& "$scriptPath\Tools\xRMCIFramework\UnpackSolution.ps1" -Verbose -solutionPackager "$scriptPath\Tools\CoreTools\SolutionPackager.exe" -solutionFilesFolder "$scriptPath\..\Customizations\Main" -mappingFile "$scriptPath\mapping.xml" -solutionName "Customizations" -connectionString $connectionString -TreatPackWarningsAsErrors $true
