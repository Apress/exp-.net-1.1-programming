// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>
#include <tchar.h>
#include <vcclr.h>

using namespace System;
using namespace System::Runtime::InteropServices;

__gc class ManTest
{
public:
	ManTest(int x)
	{
		this->x = x;
	}

	int DoubleIt()
	{
		return 2*x;
	}

private:
	int x;
};

class TemplateWrapper
{
private:
	gcroot<ManTest*> pTest;
public:
	TemplateWrapper(int x)
	{
		pTest = new ManTest(x);
	}
	int DoubleIt()
	{
		return pTest->DoubleIt();
	}	
};
class RawWrapper
{
private:
	void *handle;

public:
	RawWrapper(int x)
	{
		ManTest *pTest = new ManTest(x);
		GCHandle gcHandle = GCHandle::Alloc(pTest);
		System::IntPtr intPtr = GCHandle::op_Explicit(gcHandle);
		handle = intPtr.ToPointer();
	}

	int DoubleIt()
	{
		GCHandle gcHandle = GCHandle::op_Explicit(handle);
		Object *pObject = gcHandle.Target;
		ManTest *pTest = __try_cast<ManTest*>(pObject);
		return pTest->DoubleIt();
	}
	~RawWrapper()
	{
		GCHandle gcHandle = GCHandle::op_Explicit(handle);
		gcHandle.Free();
	}
};


// This is the entry point for this application
int _tmain(void)
{
	RawWrapper *pRaw = new RawWrapper(2);
	Console::WriteLine(S"Using RawWrapper: {0}", __box(pRaw->DoubleIt()));
	delete pRaw;
	TemplateWrapper *pTemplate = new TemplateWrapper(2);
	Console::WriteLine(S"Using TemplateWrapper: {0}", __box(pTemplate->DoubleIt()));
	delete pRaw;
    return 0;
}