// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>
#include <tchar.h>
using namespace System;

#pragma unmanaged
int DoubleIt(int x)
{
	return 2*x;
}

class Test
{
public:
	int DoubleIt(int x)
	{
		return 2*x;
	}
};

#pragma managed
int _tmain(void)
{
    Console::WriteLine(DoubleIt(3));
    return 0;
}