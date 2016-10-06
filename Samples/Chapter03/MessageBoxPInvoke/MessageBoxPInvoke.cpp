// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>
#include <tchar.h>

using namespace System;
using namespace System::Runtime::InteropServices;

[DllImport("user32.dll")]
extern int MessageBox(IntPtr hWnd, String *text, String *caption, unsigned int type);

int _tmain(void)
{
	MessageBox(NULL, S"Hello", S"Hello Dialog", 1);
    return 0;
}