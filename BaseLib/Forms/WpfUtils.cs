using System.Drawing;
using System.Reflection;
using System.Windows;

namespace BaseLib.Forms{
	public static class WpfUtils{
		public static float GetDpiScale(Graphics g){
			return GetDpiScale1();
			//try{
			//	return g.DpiX/96f;
			//} catch (Exception){
			//	return 1f;
			//}
		}

		private static float GetDpiScale1(){
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