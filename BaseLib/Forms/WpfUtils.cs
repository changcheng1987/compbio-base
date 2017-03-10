using System.Reflection;
using System.Windows;
using System;

namespace BaseLib.Forms{
	public static class WpfUtils{
		public static float GetDpiScaleX(){
		    #if __MonoCS__
                throw new NotImplementedException();
            #else
                PropertyInfo dpiXProperty = typeof (SystemParameters).GetProperty("DpiX",
                    BindingFlags.NonPublic | BindingFlags.Static);
                if (dpiXProperty == null){
                    return 1;
                }
                int dpiX = (int) dpiXProperty.GetValue(null, null);
                return dpiX/96f;
            #endif
		}

		public static float GetDpiScaleY(){
		    #if __MonoCS__
                throw new NotImplementedException();
            #else
                PropertyInfo dpiYProperty = typeof (SystemParameters).GetProperty("DpiY",
                    BindingFlags.NonPublic | BindingFlags.Static);
                if (dpiYProperty == null){
                    return 1;
                }
                int dpiY = (int) dpiYProperty.GetValue(null, null);
                return dpiY/96f;
            #endif
		}
	}
}