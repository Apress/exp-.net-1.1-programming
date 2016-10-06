.assembly extern mscorlib {}
.assembly Clock 
{
	.ver 1:0:1:0
}

.module Clock.dll
 
.namespace Apress.ExpertDotNet.ClockSample
{	
	.class public ansi auto sealed Clock extends [mscorlib]System.ValueType
	{
		.field public unsigned int8 Hours
	}
} 
