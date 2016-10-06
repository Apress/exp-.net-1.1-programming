// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>
#include <tchar.h>

using namespace System;
using namespace System::Threading;

__gc class BigClass
{
public:
	int x;			//= IL int32
	double d;		//= IL float64
	bool b;			//= IL bool
	short s;		//= IL int16
	String *sz;		//= IL object reference 
};

__gc class LittleClass
{
public:
	int x;
	int y;
};

void WriteMemoryContents(unsigned char *startAddress, int nBytes)
{
	for (int i=0 ; i< nBytes ; i++)
	{
		if (i%8==0)
			Console::Write("Address {0:x}: ", __box((int)(startAddress)+i));
		if (startAddress[i]<16)
			Console::Write("0");
		Console::Write("{0:x} ", __box(startAddress[i]));
		if (i%4==3)
			Console::Write("  ");
		if (i%8==7)
			Console::WriteLine();
	}
		Console::WriteLine();
}

// This is the entry point for this application
int _tmain(void)
{
	BigClass __pin *obj1 = new BigClass;
	obj1->x = 20;
	obj1->d = 3.455;
	obj1->b = true;
	obj1->s = 24;
	obj1->sz = S"Hello";
	LittleClass __pin *obj2 = new LittleClass;
	obj2->x = 21;
	obj2->y = 31;
	LittleClass __pin *obj3 = new LittleClass;
	obj3->x = 22;
	obj3->y = 32;

	unsigned char *x = (unsigned char*)(obj1);
	Console::WriteLine("Memory starting at &obj1-4:");
	WriteMemoryContents(x-4, 60);

	Console::WriteLine("Memory starting at obj1->s:");
	x = (unsigned char*)(&(obj1->s));
	WriteMemoryContents(x, 2);

	Console::WriteLine("Memory starting at obj1->sz:");
	x = (unsigned char*)(&(obj1->sz));
	WriteMemoryContents(x, 4);


	return 0;
}