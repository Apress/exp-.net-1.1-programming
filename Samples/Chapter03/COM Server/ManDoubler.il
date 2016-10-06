
//  Microsoft (R) .NET Framework IL Disassembler.  Version 1.0.3705.0
//  Copyright (C) Microsoft Corporation 1998-2001. All rights reserved.

.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:3300:0
}
.assembly ManDoubler
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ImportedFromTypeLibAttribute::.ctor(string) = ( 01 00 08 50 72 6F 6A 65 63 74 31 00 00 )          // ...Project1..
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 62 38 33 31 30 39 66 37 2D 64 39 65 35   // ..$b83109f7-d9e5
                                                                                                  2D 34 64 31 35 2D 62 64 36 63 2D 65 37 32 36 65   // -4d15-bd6c-e726e
                                                                                                  34 32 32 33 62 35 32 00 00 )                      // 4223b52..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module Project1.dll
// MVID: {B6A498F0-F2DE-44BA-9E19-15BB321D59A4}
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001
// Image base: 0x02dd0000
//
// ============== CLASS STRUCTURE DECLARATION ==================
//
.namespace ManDoubler
{
  .class interface public abstract auto ansi import _Doubler
  {
  } // end of class _Doubler

  .class public auto ansi import DoublerClass
         extends [mscorlib]System.Object
         implements ManDoubler._Doubler,
                    ManDoubler.Doubler
  {
  } // end of class DoublerClass

  .class interface public abstract auto ansi import Doubler
         implements ManDoubler._Doubler
  {
  } // end of class Doubler

} // end of namespace ManDoubler


// =============================================================


// =============== GLOBAL FIELDS AND METHODS ===================


// =============================================================


// =============== CLASS MEMBERS DECLARATION ===================
//   note that class flags, 'extends' and 'implements' clauses
//          are provided here for information only

.namespace ManDoubler
{
  .class interface public abstract auto ansi import _Doubler
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 D0 10 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 35 30 36 44 31 36 34 33 2D 46 43 32 44   // ..$506D1643-FC2D
                                                                                                    2D 34 32 39 41 2D 39 44 46 44 2D 31 46 33 46 31   // -429A-9DFD-1F3F1
                                                                                                    42 33 46 42 45 43 43 00 00 )                      // B3FBECC..
    .method public hidebysig newslot virtual abstract 
            instance int16  DoubleItVB6([in][out] int16& x) runtime managed internalcall
    {
      .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 00 00 03 60 00 00 )                         // .....`..
    } // end of method _Doubler::DoubleItVB6

  } // end of class _Doubler

  .class public auto ansi import DoublerClass
         extends [mscorlib]System.Object
         implements ManDoubler._Doubler,
                    ManDoubler.Doubler
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 02 00 00 00 ) 
    .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 46 33 42 38 45 34 41 38 2D 41 31 33 45   // ..$F3B8E4A8-A13E
                                                                                                    2D 34 39 33 45 2D 42 38 46 36 2D 32 36 31 39 37   // -493E-B8F6-26197
                                                                                                    46 35 32 42 46 46 46 00 00 )                      // F52BFFF..
    .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(int16) = ( 01 00 00 00 00 00 ) 
    .method public specialname rtspecialname 
            instance void  .ctor() runtime managed internalcall
    {
    } // end of method DoublerClass::.ctor

    .method public hidebysig newslot virtual 
            instance int16  DoubleItVB6([in][out] int16& x) runtime managed internalcall
    {
      .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 00 00 03 60 00 00 )                         // .....`..
      .override ManDoubler._Doubler::DoubleItVB6
    } // end of method DoublerClass::DoubleItVB6

  } // end of class DoublerClass

  .class interface public abstract auto ansi import Doubler
         implements ManDoubler._Doubler
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 35 30 36 44 31 36 34 33 2D 46 43 32 44   // ..$506D1643-FC2D
                                                                                                    2D 34 32 39 41 2D 39 44 46 44 2D 31 46 33 46 31   // -429A-9DFD-1F3F1
                                                                                                    42 33 46 42 45 43 43 00 00 )                      // B3FBECC..
    .custom instance void [mscorlib]System.Runtime.InteropServices.CoClassAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 17 4D 61 6E 44 6F 75 62 6C 65 72 2E 44 6F   // ...ManDoubler.Do
                                                                                                                            75 62 6C 65 72 43 6C 61 73 73 00 00 )             // ublerClass..
  } // end of class Doubler


// =============================================================

} // end of namespace ManDoubler

//*********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file ManDoubler.res
