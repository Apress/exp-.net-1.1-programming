REM This file extracts the public key from the .snk file and 
REM distributes to the developers in your team
REM
REM You should run this file, then the Compile.bat file in the Developers 
REM folder, then finally the Sign.bat file in this foler
REM 
REM Files in this folder are visible to the trusted administrators
REM Files in the Developers folder are visible to your developers.

sn -p AdvDotNet.snk PublicKey.snk
copy PublicKey.snk ..\Developer\PublicKey.snk




