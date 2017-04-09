using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace BaseLib.Forms{
	public static class WpfUtils{
		public static float GetDpiScale(Graphics g){
			uint dpiX;
			uint dpiY;
			ScreenExtensions.GetDpi(DpiType.Effective, out dpiX, out dpiY);
			return dpiX/96f;
			//return GetDpiScale1();
			//try{
			//	return g.DpiX/96f;
			//} catch (Exception){
			//	return 1f;
			//}
		}

		//private static float GetDpiScale1(){
		//	PropertyInfo dpiXProperty = typeof (SystemParameters).GetProperty("DpiX",
		//		BindingFlags.NonPublic | BindingFlags.Static);
		//	if (dpiXProperty == null){
		//		return 1;
		//	}
		//	int dpiX = (int) dpiXProperty.GetValue(null, null);
		//	return dpiX/96f;
		//}
	}

	public static class ScreenExtensions{
		public static void GetDpi(DpiType dpiType, out uint dpiX, out uint dpiY){
			var pnt = new System.Drawing.Point(1, 1);
			var mon = MonitorFromPoint(pnt, 2 /*MONITOR_DEFAULTTONEAREST*/);
			GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
		}

		//https://msdn.microsoft.com/en-us/library/windows/desktop/dd145062(v=vs.85).aspx
		[DllImport("User32.dll")]
		private static extern IntPtr MonitorFromPoint([In] System.Drawing.Point pt, [In] uint dwFlags);

		//https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510(v=vs.85).aspx
		[DllImport("Shcore.dll")]
		private static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX,
			[Out] out uint dpiY);
	}

	//https://msdn.microsoft.com/en-us/library/windows/desktop/dn280511(v=vs.85).aspx
	public enum DpiType{
		Effective = 0,
		Angular = 1,
		Raw = 2,
	}
}