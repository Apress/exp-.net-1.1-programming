@rem remove the permission dll from full trust
caspol -polchgprompt off
caspol -remfulltrust WMDDetectorPermission.dll
caspol -polchgprompt on

@rem uninstall shared assemblies from assembly cache
gacutil -u WMDDetectorPermission
gacutil -u WMDDetectorDrivers

@rem remove compiled assemblies
del GenerateXmlFiles.exe
del WMDDetectorDrivers.dll
del WMDDetectorPermission.dll
del WMDDetector.exe