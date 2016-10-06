.assembly extern mscorlib {}
.assembly Clock
{
	.ver 2:0:1:0
}

.module Clock.dll
 
.namespace Apress.ExpertDotNet.ClockSample
{	
	.class public ansi auto sealed Clock extends [mscorlib]System.ValueType
	{
		.field private unsigned int8 hours

		.method specialname public instance unsigned int8 get_Hours() cil managed
		{
			ldarg.0
			ldfld unsigned int8  Apress.ExpertDotNet.ClockSample.Clock::hours
			ret
		}

		.method specialname public instance void set_Hours(unsigned int8 'value')
		{
			ldarg.0
			ldarg.1
			stfld unsigned int8  Apress.ExpertDotNet.ClockSample.Clock::hours
			ret
		}

		.property instance unsigned int8 Hours ()
		{
			.get instance unsigned int8 get_Hours()
			.set instance void set_Hours(unsigned int8 'value')
		}
	}
} 
