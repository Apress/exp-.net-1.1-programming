using System;

namespace Apress.ExpertDotNet.DisposeBothResources
{
	class APIFunctionSimulator
	{
		public static IntPtr GetResource()
		{
			// substitute for an API function
			return (IntPtr)4;
		}

		public static void ReleaseResource(IntPtr handle)
		{
			// in a real app this would call something to release
			// the handle
		}

		public static string UseResource(IntPtr handle)
		{
			return "The handle is " + handle.ToString();
		}
	}

	class EntryPoint
	{
		static void Main()
		{
			ResourceUser ru = new ResourceUser();
			ru.UseResource();
			ru.UseResource();
			// WRONG! Forgot to call Dispose()

			using (ru = new ResourceUser())
			{
				ru.UseResource();
				ru.UseResource();
			}

			ru = new ResourceUser();
			try
			{
				ru.UseResource();
				ru.UseResource();
			}
			finally
			{
				ru.Dispose();
			}

			UseUnmanagedResource();
		}

		static void UseUnmanagedResource()
		{
			IntPtr handle = APIFunctionSimulator.GetResource(); 
			try
			{
				string result = APIFunctionSimulator.UseResource(handle);
				Console.WriteLine("In EntryPoint.UseUnmanagedResource, result is :" + result);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception in UseUnmanagedResource: " + e.Message);
			}
			finally
			{
				if (handle.ToInt32() != 0)
				{
					APIFunctionSimulator.ReleaseResource(handle);
				}
			}
		}

	}

	class ResourceUser : IDisposable
	{
		private IntPtr handle;
		private int [] bigArray = new int[100000];

		public ResourceUser()
		{
			handle = APIFunctionSimulator.GetResource();
			if (handle.ToInt32() == 0)
				throw new ApplicationException();
		}

		public void Dispose()
		{
			lock(this)
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}
		}

		private void Dispose(bool disposing)
		{
			if (handle.ToInt32() != 0)
			{
				APIFunctionSimulator.ReleaseResource(handle);
				handle = (IntPtr) 0;
			}
			if (disposing)
			{
				bigArray = null;
			}
		}

		public void UseResource()
		{
			if (handle.ToInt32() == 0)
				throw new ObjectDisposedException("handle used in UseResource class after object disposed");
			string result = APIFunctionSimulator.UseResource(handle);
			Console.WriteLine("In ResourceUser.UseResource, result is :" + result);
		}

		~ResourceUser()
		{
			Dispose(false);
		}
	}

}
