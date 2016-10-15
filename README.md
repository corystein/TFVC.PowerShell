TFVC PowerShell CmdLet
=============================================

This project includes source to create a binary PowerShell cmdlet.  The module will allow you to interact with TFS using PowerShell. 

The TFVC PowerShell module is intended to aid in TFS source control operations.  Similiar to using Visual Studio or tf.exe the PowerShell should provide the same capabilities.

##Compile Requirements
1. Visual Studio or Xamarin
2. .NET Framework 4.6 or Mono 

##Runtime Requirements
1. PowerShell 3.0 or later
2. .NET Framework 4.6 or later


## Example
To unload and load the compiled module the below syntax can be used:

###Unload Module
```powershell
###################################################################################
# Unload module
###################################################################################
if ((Get-Module -Name "TFVC.PowerShell") -ne $null) {
	Write-Host -ForegroundColor Yellow "`r`nRemoving module [TFVC.PowerShell"
	Remove-Module -Name "TFVC.PowerShell" -Force | Out-Null
}
###################################################################################
```

###Import Module
```powershell
###################################################################################
# Load module
###################################################################################
Import-Module "TFVC.PowerShell.psd1" -Force
###################################################################################
```
###List Modules
```powershell
Get-Module
Get-Command -Module "PwC.GATT.PowerShell.Common" -CommandType cmdlet | Format-Table
```

