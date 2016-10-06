// This is the main project file for VC++ application project 
// generated using an Application Wizard.

using namespace System;

#include "stdafx.h"
#include <tchar.h>

#using <mscorlib.dll>

#pragma unmanaged
__nogc class UnNoTest
{
public:
   UnNoTest(int x) { this->x = x; }
   int DoubleIt() { return 2 * x; }
private:
   int x;
};


#pragma managed
__nogc class ManNoTest
{
public:
   ManNoTest(int x) { this->x = x; }
   int DoubleIt() { return 2 * x; }
private:
   int x;
};

#pragma managed
__gc class ManGCTest
{
public:
   ManGCTest(int x) { this->x = x; }
   int DoubleIt() { return 2 * x; }
private:
   int x;
};

#pragma managed
int _tmain(void)
{
   UnNoTest *pUnNoTest = new UnNoTest(3);
   System::Console::WriteLine(pUnNoTest->DoubleIt());
   delete pUnNoTest;

   ManNoTest *pManNoTest = new ManNoTest(3);
   System::Console::WriteLine(pManNoTest->DoubleIt());
   delete pManNoTest;

   ManGCTest *pManGCTest = new ManGCTest(3);
   System::Console::WriteLine(pManGCTest->DoubleIt());
   return 0;
}
