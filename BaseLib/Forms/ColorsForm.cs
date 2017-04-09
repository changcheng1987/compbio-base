using System.ComponentModel;
using System.Windows.Forms;

namespace BaseLibC.Forms{
	public partial class ColorsForm : Form{
		public ColorsForm(){
			InitializeComponent();
			colorScale.Text = "Intensity";
		}

		public ColorScale ColorScale => colorScale;

		protected override void OnClosing(CancelEventArgs e){
			e.Cancel = true;
			Visible = false;
		}
	}
}