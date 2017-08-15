using System;
using System.Globalization;
using System.Windows.Forms;
using BaseLibS.Param;

namespace BaseLib.Param{
	[Serializable]
	internal class DoubleParamWf : DoubleParam{
		[NonSerialized] private TextBox control;
		internal DoubleParamWf(string name, double value) : base(name, value){}
		public override ParamType Type => ParamType.WinForms;

		public override void SetValueFromControl(){
			bool success = double.TryParse(control.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double val);
			val = success ? val : double.NaN;
			Value = val;
		}

		public override void UpdateControlFromValue(){
			if (control == null){
				return;
			}
			control.Text = Value.ToString(CultureInfo.InvariantCulture);
		}

		public override object CreateControl(){
			control = new TextBox{Text = Value.ToString(CultureInfo.InvariantCulture) };
			control.TextChanged += (sender, e) =>{
				SetValueFromControl();
				ValueHasChanged();
			};
			return control;
		}
	}
}