using System;
using System.Globalization;

namespace BaseLibS.Util {
	public static class Parser {
		public static double Double(string s) {
			return double.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public static bool TryDouble(string s, out double x) {
			return double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out x);
		}

		public static float Float(string s) {
			return float.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public static bool TryFloat(string s, out float x) {
			return float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out x);
		}

		public static int Int(string s) {
			return int.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public static bool TryInt(string s, out int x) {
			return int.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out x);
		}

		public static uint Uint(string s) {
			return uint.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public static bool TryUint(string s, out uint x) {
			return uint.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out x);
		}

		public static decimal Decimal(string s) {
			return decimal.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public static bool TryDecimal(string s, out decimal x) {
			return decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out x);
		}

		public static string ToString(double x) {
			return x.ToString(CultureInfo.InvariantCulture);
		}

		public static string ToString(float x) {
			return x.ToString(CultureInfo.InvariantCulture);
		}

		public static string ToString(int x) {
			return x.ToString(CultureInfo.InvariantCulture);
		}

		public static string ToString(uint x) {
			return x.ToString(CultureInfo.InvariantCulture);
		}

		public static string ToString(bool x) {
			return x.ToString(CultureInfo.InvariantCulture);
		}

		public static string ToString(DateTime x) {
			return x.ToString(CultureInfo.InvariantCulture);
		}

		public static string ToString(char x) {
			return x.ToString(CultureInfo.InvariantCulture);
		}
	}
}