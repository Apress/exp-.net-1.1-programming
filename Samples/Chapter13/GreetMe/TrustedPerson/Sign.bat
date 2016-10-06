rem SIGN FILES WITH THE PRIVATE KEY AND 
rem INSTALL INTO GLOBAL ASSEMBLY CACHE
rem ----------------------------------

cd ..\Developer
sn -R GreetMe.dll ../TrustedPerson/AdvDotNet.snk
sn -R en-US/GreetMe.resources.dll ../TrustedPerson/AdvDotNet.snk
sn -R en-GB/GreetMe.resources.dll ../TrustedPerson/AdvDotNet.snk
sn -R de/GreetMe.resources.dll ../TrustedPerson/AdvDotNet.snk


gacutil /i GreetMe.dll
gacutil /i en-US/GreetMe.resources.dll
gacutil /i en-GB/GreetMe.resources.dll
gacutil /i de/GreetMe.resources.dll

cd ..\TrustedPerson
