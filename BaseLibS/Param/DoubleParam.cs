using System;
using System.Globalization;

namespace BaseLibS.Param{
	[Serializable]
	public class DoubleParam : Parameter<double>{
        /// <summary>
        /// only for xml serialization
        /// </summary>
	    private DoubleParam() : this("", 0.0) { }

	    public DoubleParam(string name, double value) : base(name){
			Value = value;
			Default = value;
		}

		public override string StringValue{
			get => Value.ToString(CultureInfo.InvariantCulture);
			set => Value = double.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		public override void Clear(){
			Value = 0;
		}
		public override ParamType Type => ParamType.Server;
	}
}