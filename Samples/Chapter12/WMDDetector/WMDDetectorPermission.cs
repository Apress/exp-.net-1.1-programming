using System;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Reflection;

[assembly:AssemblyKeyFile("ApressWMDDetectors.snk")]
[assembly:AssemblyVersion("1.0.1.0")]

namespace Apress.Expert.WMDDetector
{


	[Flags]
	public enum WMDDetectorPermissions {All = 3, Read = 2, Reset = 1, None = 0}

	[Serializable()]
	public class WMDDetectorPermission: CodeAccessPermission , IUnrestrictedPermission
	{
		WMDDetectorPermissions state;

		public WMDDetectorPermission(WMDDetectorPermissions state)
		{
			this.state = state;
		}
 
		public WMDDetectorPermission(PermissionState permState)
		{
			if (permState == PermissionState.Unrestricted)
				this.state =  WMDDetectorPermissions.All;
			else
				this.state = WMDDetectorPermissions.None;
		}
   
		public WMDDetectorPermissions State
		{
			get
			{
				return state;
			}
		}

		public bool IsUnrestricted()
		{
			return (state == WMDDetectorPermissions.All);
		}

		public override IPermission Copy()
		{
			return new WMDDetectorPermission(this.state);
		}

		public override IPermission Intersect(IPermission target)
		{
			WMDDetectorPermission rhs = target as WMDDetectorPermission;
			if (rhs == null)
				return null;
			if ((this.state & rhs.state) == WMDDetectorPermissions.None)
				return null;
			return new WMDDetectorPermission ( this.state & rhs.state ) ;
		}

		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null || !(target is WMDDetectorPermission))
				return false;
			WMDDetectorPermission rhs = (WMDDetectorPermission)target;

			WMDDetectorPermissions subsetFlags = this.state;
			WMDDetectorPermissions supersetFlags = rhs.state;
			return (subsetFlags & (~supersetFlags) ) == 0;
		}

		public override void FromXml(SecurityElement xml)
		{
			string element = xml.Attribute("Unrestricted");          
			if(element != null)
			{  
				state = (WMDDetectorPermissions)Enum.Parse(typeof(WMDDetectorPermissions), element, false);
			}
			else
				throw new ArgumentException("XML element does not correctly parse to a WMDDetectorPermission");
		}

		public override SecurityElement ToXml()
		{
			SecurityElement element = new SecurityElement("IPermission");
			Type type = typeof(WMDDetectorPermission);
			StringBuilder assemblyName = new StringBuilder(type.Assembly.ToString());
			assemblyName.Replace('\"', '\'');
			element.AddAttribute("class", type.FullName + ", " + assemblyName);
			element.AddAttribute("description", "Apress WMD detector");
			element.AddAttribute("version", "1.*");
			element.AddAttribute("Unrestricted", state.ToString());
			return element;
		}
	}

	[AttributeUsageAttribute(AttributeTargets.All, AllowMultiple = true)]
	public class WMDDetectorPermissionAttribute: CodeAccessSecurityAttribute
	{
		WMDDetectorPermissions state;

		public WMDDetectorPermissionAttribute(SecurityAction action): base (action)
		{  
		}

		public WMDDetectorPermissions Access
		{
			get
			{
				if (this.Unrestricted)
					return WMDDetectorPermissions.All;
				return state;
			}
			set
			{
				this.state = value;
				if (value == WMDDetectorPermissions.All)
					this.Unrestricted = true;
			}
		}

		public override IPermission CreatePermission()
		{
			return new WMDDetectorPermission(state);
		}
	}
}
