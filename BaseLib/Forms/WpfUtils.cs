using System.Reflection;
using System.Windows;

namespace BaseLib.Forms{
	public static class WpfUtils{
		public static float GetDpiScaleX(){
			PropertyInfo dpiXProperty = typeof (SystemParameters).GetProperty("DpiX",
				BindingFlags.NonPublic | BindingFlags.Static);
			if (dpiXProperty == null){
				return 1;
			}
			int dpiX = (int) dpiXProperty.GetValue(null, null);
			return dpiX/96f;
		}
	}
}