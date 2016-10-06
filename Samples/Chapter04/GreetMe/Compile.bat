
rem COMPILE DEFAULT RESOURCES
rem -------------------------
resgen Strings.txt
resxgen /i:NoFlag.jpg /o:Flags.resx /n:Flag
resgen Flags.resx

rem COMPILE SOURCE FILES
rem --------------------
rem csc /t:module FlagDlg.cs
vbc /t:module /r:System.dll /r:System.drawing.dll /r:System.Windows.Forms.dll FlagDlg.vb
csc /addmodule:FlagDlg.netmodule /res:Strings.resources /res:Flags.resources /t:library GreetMe.cs

rem COMPILE en-US RESOURCES
rem -----------------------
cd en-US
resgen Strings.en-US.txt
resxgen /i:USFlag.jpg /o:Flags.en-US.resx /n:Flag
resgen Flags.en-US.resx
al /embed:Strings.en-US.resources /embed:Flags.en-US.resources /c:en-US /v:1.0.1.0 /keyfile:../AdvDotNet.snk  /out:GreetMe.resources.dll
rem /keyfile:../AdvDotNet.snk
cd ..

rem COMPILE en-GB RESOURCES
rem -----------------------
cd en-GB
resgen Strings.en-GB.txt
resxgen /i:GBFlag.jpg /o:Flags.en-GB.resx /n:Flag
resgen Flags.en-GB.resx
al /embed:Strings.en-GB.resources /embed:Flags.en-GB.resources /c:en-GB /v:1.0.1.0 /keyfile:../AdvDotNet.snk /out:GreetMe.resources.dll
rem /keyfile:../AdvDotNet.snk
cd ..

rem COMPILE de RESOURCES Note that there is no de flag because de could mean Germany or Austria
rem -------------------------------------------------------------------------------------------
cd de
resgen Strings.de.txt
al /embed:Strings.de.resources /c:de /v:1.0.1.0 /keyfile:../AdvDotNet.snk /out:GreetMe.resources.dll
rem /keyfile:../AdvDotNet.snk
cd ..

rem INSTALL INTO GLOBAL ASSEMBLY CACHE
rem ----------------------------------
gacutil /i GreetMe.dll
gacutil /i en-US/GreetMe.resources.dll
gacutil /i en-GB/GreetMe.resources.dll
gacutil /i de/GreetMe.resources.dll


rem COMPILE TEST FORM
rem -----------------
cd Test Form
csc /r:../GreetMe.dll TestForm.cs
cd ..




