// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>
#include <tchar.h>

using namespace System;

/*#pragma unmanaged
int DoubleIt(int x)
{
	return 2*x;
}*/

#pragma managed
class Test
{
public:
	Test(int x)
	{
		this->x = x;
	}

	int DoubleIt()
	{
		return 2*x;
	}
private:
	int x;
	int y;
	double d;
};

int _tmain(void)
{
	Test *pTest = new Test(3);
    Console::WriteLine(pTest->DoubleIt());
	delete pTest;
    return 0;
}