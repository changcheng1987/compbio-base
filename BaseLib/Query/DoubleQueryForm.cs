using System;
using System.Globalization;
using System.Windows.Forms;

namespace BaseLib.Query {
	public partial class DoubleQueryForm : Form {
		public DoubleQueryForm(double value) {
			InitializeComponent();
			StartPosition = FormStartPosition.Manual;
			okButton.Click += OkButtonOnClick;
			cancelButton.Click += CancelButtonOnClick;
			textBox1.Text = value.ToString(CultureInfo.InvariantCulture);
			textBox1.KeyDown += TextBox1OnKeyDown;
			ActiveControl = textBox1;
		}

		public double Value => double.TryParse(textBox1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double val)
			? val
			: double.NaN;

		private void TextBox1OnKeyDown(object sender, KeyEventArgs keyEventArgs) {
			if (keyEventArgs.KeyCode == Keys.Return) {
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void CancelButtonOnClick(object sender, EventArgs eventArgs) {
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void OkButtonOnClick(object sender, EventArgs eventArgs) {
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}