rem THIS FILE CLEANS UP ALL FILES CREATED DURING COMPILATION OF 
rem THE GREETME SAMPLE. RESTORES PROJECT TO THE STATE IT WAS IN
rem WHEN YOU DOWNLOADED THE SAMPLE FROM THE WEB SITE (ASSUMING
rem YOU HAVEN'T DONE ANYTHING TO THE FILES OTHER THAN COMPILE THEM!)

rem DELETE ALL FILES CREATED DURING PROJECT COMPILATION
rem ---------------------------------------------------
del *.dll
del *.resources
del *.resx
del *.netmodule

cd en-US
del *.dll
del *.resources
del *.resx
cd ..

cd en-GB
del *.dll
del *.resources
del *.resx
cd ..

cd de
del *.dll
del *.resources
del *.resx
cd ..

cd Test Form
del *.exe
cd ..



rem REMOVE FILES FROM GLOBAL ASSEMBLY CACHE
rem ---------------------------------------
gacutil /u GreetMe
gacutil /u GreetMe.resources


