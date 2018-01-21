[CmdletBinding()]

param
(
)

$ErrorActionPreference = "Stop"

#Script Location
$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
Write-Verbose "Script Path: $scriptPath"

& "$scriptPath\Tools\xRMCIFramework\PackSolution.ps1" -Verbose -CoreToolsPath "$scriptPath\Tools\CoreTools\" -unpackedFilesFolder "$scriptPath\..\Customizations\Main" -mappingFile "$scriptPath\mapping.xml" -PackageType Both -TreatPackWarningsAsErrors $false -UpdateVersion $false -OutputPath "C:\temp"
