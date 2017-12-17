using System;
using System.Windows.Forms;
using BaseLibS.Table;

namespace BaseLib.Forms {
	public partial class FastaFilesParamControl : UserControl {
		public FastaFilesParamControl() {
			InitializeComponent();
			tableView1.TableModel = CreateTable();
			addButton.Click += AddButton_OnClick;
			removeButton.Click += RemoveButton_OnClick;
		}

		private static DataTable2 CreateTable() {
			DataTable2 table = new DataTable2("fasta file table");
			table.AddColumn("Fasta file path", 370, ColumnType.Text,
				"Path to the fasta file used in the Andromeda searches.");
			table.AddColumn("Identifier parse rule", 80, ColumnType.Text);
			table.AddColumn("Description parse rule", 80, ColumnType.Text);
			table.AddColumn("Taxonomy parse rule", 80, ColumnType.Text);
			table.AddColumn("Organism", 80, ColumnType.Text);
			table.AddColumn("Taxonomy ID", 80, ColumnType.Text);
			return table;
		}
		private void AddButton_OnClick(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog { Multiselect = true, Filter = Filter };
			if (ofd.ShowDialog() == DialogResult.OK) {
				//AddFastaFiles(ofd.FileNames, listBox1);
			}
		}

		private void RemoveButton_OnClick(object sender, EventArgs e) {
			//if (listBox1.SelectedIndex >= 0) {
			//	listBox1.Items.RemoveAt(listBox1.SelectedIndex);
			//}
		}
		public string Filter { get; set; }
	}
}
