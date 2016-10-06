@rem compile assemblies and add libraries to assembly cache
csc /target:library WMDDetectorPermission.cs
gacutil /i WMDDetectorPermission.dll

csc /r:WMDDetectorPermission.dll /target:library WMDDetectorDrivers.cs
gacutil /i WMDDetectorDrivers.dll

csc /r:WMDDetectorPermission.dll GenerateXmlFiles.cs
csc /r:WMDDetectorDrivers.dll /r:System.Windows.Forms.dll /target:winexe WMDDetector.cs

@rem run app to generate the Xml files describing permission and permission set
GenerateXmlFiles

@rem add permission dll to full trust list
caspol -polchgprompt off
caspol -addfulltrust WMDDetectorPermission.dll
caspol -polchgprompt on

