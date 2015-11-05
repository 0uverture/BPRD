
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.33440
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Selsort
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module Selsort.exe
// MVID: {F56E40B6-6BF4-4BD5-9DA5-5642F7912C65}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00A20000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit Class1
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  4
    .locals init (int32 V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  br.s       IL_0032

    IL_0004:  ldloc.0
    IL_0005:  stloc.1
    IL_0006:  ldloc.0
    IL_0007:  ldc.i4.1
    IL_0008:  add
    IL_0009:  stloc.2
    IL_000a:  br.s       IL_001a

    IL_000c:  ldarg.0
    IL_000d:  ldloc.2
    IL_000e:  ldelem.i4
    IL_000f:  ldarg.0
    IL_0010:  ldloc.1
    IL_0011:  ldelem.i4
    IL_0012:  bge.s      IL_0016

    IL_0014:  ldloc.2
    IL_0015:  stloc.1
    IL_0016:  ldloc.2
    IL_0017:  ldc.i4.1
    IL_0018:  add
    IL_0019:  stloc.2
    IL_001a:  ldloc.2
    IL_001b:  ldarg.0
    IL_001c:  ldlen
    IL_001d:  conv.i4
    IL_001e:  blt.s      IL_000c

    IL_0020:  ldarg.0
    IL_0021:  ldloc.0
    IL_0022:  ldelem.i4
    IL_0023:  stloc.3
    IL_0024:  ldarg.0
    IL_0025:  ldloc.0
    IL_0026:  ldarg.0
    IL_0027:  ldloc.1
    IL_0028:  ldelem.i4
    IL_0029:  stelem.i4
    IL_002a:  ldarg.0
    IL_002b:  ldloc.1
    IL_002c:  ldloc.3
    IL_002d:  stelem.i4
    IL_002e:  ldloc.0
    IL_002f:  ldc.i4.1
    IL_0030:  add
    IL_0031:  stloc.0
    IL_0032:  ldloc.0
    IL_0033:  ldarg.0
    IL_0034:  ldlen
    IL_0035:  conv.i4
    IL_0036:  blt.s      IL_0004

    IL_0038:  ret
  } // end of method Class1::SelectionSort

  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method Class1::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Class1::.ctor

} // end of class Class1


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
