using System;
using BaseLibS.Mol;

namespace BaseLibS.Util {
	public abstract class InputParameter {
		public string Name { get; }
		public string VariableName { get; }

		protected InputParameter(string name, string variableName) {
			Name = name;
			VariableName = variableName;
		}

		public abstract Type Type { get; }
		public abstract bool IsArray { get; }
		public abstract string ElementTypeName { get; }
		public abstract object DefaultValue { get; }
	}

	public class InputParameter<T> : InputParameter {
		private readonly T defaultValue;

		public InputParameter(string name, string variableName, T defaultValue) : base(name, variableName) {
			this.defaultValue = defaultValue;
		}

		public InputParameter(string name, string variableName) : this(name, variableName, default(T)) { }
		public override bool IsArray => typeof(T).IsArray;
		public override Type Type => typeof(T);
		public override object DefaultValue => defaultValue;

		public override string ElementTypeName {
			get {
				Type t = typeof(T).GetElementType();
				if (t == typeof(string)) {
					return "string";
				}
				if (t == typeof(short)) {
					return "short";
				}
				if (t == typeof(bool)) {
					return "boolean";
				}
				if (t == typeof(int)) {
					return "int";
				}
				if (t == typeof(FastaFileInfo)) {
					return "FastaFileInfo";
				}
				throw new Exception("Unknown type: " + t);
			}
		}
	}
}