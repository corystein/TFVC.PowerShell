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

##Features
The below features should be available to the PowerShell cmdlet's 

1. Connect to TFS (Connect-Tfs)
2. Disconnect from TFS (Disconnect-Tfs)
3. Create Workspace (Create-TfsWorkspace)
4. Delete Workspace (Delete-TfsWorkspace)
5. Workspace exist (Exist-TfsWorkspace)
6. Server path exist (Exist-TfsServerPath)
7. Workspace mapping exist (Exist-TfsWorkspaceMapping)
8. Create Workspace mapping (Create-TfsWorkspaceMapping)
9. Get workspace (Get-TfsWorkspace)
10. Get items from TFS (Get-TfsItems)
11. Check-out item from TFS (CheckOut-TfsItem)
12. Check-in item to TFS (CheckIn-TfsItem)
13. Undo item from TFS (Undo-TfsItem)
14. Create branch in TFS (Create-TfsBranch)

###Connect to TFS server
```powershell
Import-Module "TFVC.PowerShell.psd1" -Force
Connect-Tfs -Uri "http://mytfsserver.localhost.com:8080/tfs/DefaultCollection"
```

###Disconnect from TFS server
```powershell
Disconnect-Tfs
```