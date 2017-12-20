using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BaseLibS.Table;
using BaseLibS.Util;

namespace BaseLib.Forms {
	public partial class FastaFilesParamControl : UserControl {
		private DataTable2 table;

		public FastaFilesParamControl() {
			InitializeComponent();
			tableView1.TableModel = CreateTable();
			addButton.Click += AddButton_OnClick;
			removeButton.Click += RemoveButton_OnClick;
			identifierRuleButton.Click += IdentifierRuleButtonOnClick;
			descriptionRuleButton.Click += DescriptionRuleButtonOnClick;
			taxonomyRuleButton.Click += TaxonomyRuleButtonOnClick;
			taxonomyIdButton.Click += TaxonomyIdButtonOnClick;
			testButton.Click += TestButtonOnClick;
		}

		private void TestButtonOnClick(object sender, EventArgs eventArgs) {
			int[] sel = tableView1.GetSelectedRows();
			if (sel.Length != 1) {
				MessageBox.Show("Please select exactly one row.");
				return;
			}
			int ind = sel[0];
			string path = (string) table.GetEntry(ind, 0);
			string identifierRule = (string) table.GetEntry(ind, 1);
			string descriptionRule = (string) table.GetEntry(ind, 2);
			string taxonomyRule = (string) table.GetEntry(ind, 3);
			TestParseRulesForm f = new TestParseRulesForm(path, identifierRule, descriptionRule, taxonomyRule);
			f.ShowDialog();
		}

		private void TaxonomyIdButtonOnClick(object sender, EventArgs eventArgs) {
			int[] sel = tableView1.GetSelectedRows();
			if (sel.Length == 0) {
				MessageBox.Show(Loc.PleaseSelectSomeRows);
				return;
			}
			EditTaxonomyForm f = new EditTaxonomyForm();
			f.ShowDialog();
		}

		private void TaxonomyRuleButtonOnClick(object sender, EventArgs eventArgs) {
			int[] sel = tableView1.GetSelectedRows();
			if (sel.Length == 0) {
				MessageBox.Show(Loc.PleaseSelectSomeRows);
				return;
			}
			EditParseRuleForm f = new EditParseRuleForm(new string[0], new string[0]);
			f.ShowDialog();
		}

		private void DescriptionRuleButtonOnClick(object sender, EventArgs eventArgs) {
			int[] sel = tableView1.GetSelectedRows();
			if (sel.Length == 0) {
				MessageBox.Show(Loc.PleaseSelectSomeRows);
				return;
			}
			EditParseRuleForm f = new EditParseRuleForm(new string[0], new string[0]);
			f.ShowDialog();
		}

		private void IdentifierRuleButtonOnClick(object sender, EventArgs eventArgs) {
			int[] sel = tableView1.GetSelectedRows();
			if (sel.Length == 0) {
				MessageBox.Show(Loc.PleaseSelectSomeRows);
				return;
			}
			string[] parseRules = { @">.*\|(.*)\|", @">(gi\|[0-9]*)", @">IPI:([^\| .]*)", @">(.*)", @">([^ ]*)", @">([^\t]*)" };
			string[] descriptions = {
				"Uniprot identifier", "NCBI accession", "IPI accession", "Everything after “>”", "Up to first space",
				"Up to first tab character"
			};

			EditParseRuleForm f = new EditParseRuleForm(parseRules, descriptions);
			f.ShowDialog();
		}

		private DataTable2 CreateTable() {
			table = new DataTable2("fasta file table");
			table.AddColumn("Fasta file path", 285, ColumnType.Text, "Path to the fasta file used in the Andromeda searches.");
			table.AddColumn("Identifier rule", 85, ColumnType.Text);
			table.AddColumn("Description rule", 100, ColumnType.Text);
			table.AddColumn("Taxonomy rule", 95, ColumnType.Text);
			table.AddColumn("Taxonomy ID", 90, ColumnType.Text);
			table.AddColumn("Organism", 90, ColumnType.Text);
			return table;
		}

		private void AddButton_OnClick(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog {Multiselect = true, Filter = Filter};
			if (ofd.ShowDialog() == DialogResult.OK) {
				AddFastaFiles(ofd.FileNames);
			}
		}

		private void AddFastaFiles(string[] fileNames) {
			HashSet<string> currentFiles = GetCurrentFiles();
			int count = 0;
			foreach (string fileName in fileNames) {
				if (!currentFiles.Contains(fileName)) {
					AddFastaFile(fileName);
					count++;
				}
			}
			if (count > 0) {
				tableView1.Invalidate(true);
			}
		}

		private void AddFastaFile(string fileName) {
			GuessRules(fileName, out string identifierRule, out string descriptionRule, out string taxonomyRule,
				out string taxonomyId);
			AddFastaFile(fileName, identifierRule, descriptionRule, taxonomyRule, taxonomyId);
		}

		private void GuessRules(string fileName, out string identifierRule, out string descriptionRule,
			out string taxonomyRule, out string taxonomyId) {
			descriptionRule = @">(.*)";
			taxonomyRule = "";
			if (LooksLikeUniprot(fileName)) {
				identifierRule = @">.*\|(.*)\|";
				taxonomyId = GetUniprotTaxonomyId(fileName);
				return;
			}
			identifierRule = @">.*\|(.*)\|";
			taxonomyId = "";
		}

		private string GetUniprotTaxonomyId(string fileName) {
			if (!fileName.ToUpper().EndsWith(".FASTA")) {
				return "";
			}
			fileName = fileName.Substring(0, fileName.Length - 6);
			if (fileName.ToLower().EndsWith("_additional")) {
				fileName = fileName.Substring(0, fileName.Length - 11);
			}
			int ind = fileName.IndexOf("_", StringComparison.InvariantCulture);
			if (ind < 0) {
				return "";
			}
			string s = fileName.Substring(ind + 1);
			bool ok = int.TryParse(s, out _);
			return !ok ? "" : s;
		}

		private bool LooksLikeUniprot(string fileName) {
			if (!fileName.ToUpper().EndsWith(".FASTA")) {
				return false;
			}
			fileName = fileName.Substring(0, fileName.Length - 6);
			if (fileName.ToLower().EndsWith("_additional")) {
				fileName = fileName.Substring(0, fileName.Length - 11);
			}
			return fileName.ToUpper().StartsWith("UP") && fileName.Contains("_");
		}

		private void AddFastaFile(string fileName, string identifierRule, string descriptionRule, string taxonomyRule,
			string taxonomyId) {
			DataRow2 row = table.NewRow();
			row["Fasta file path"] = fileName;
			row["Identifier rule"] = identifierRule;
			row["Description rule"] = descriptionRule;
			row["Taxonomy rule"] = taxonomyRule;
			row["Taxonomy ID"] = taxonomyId;
			row["Organism"] = "";
			table.AddRow(row);
		}

		private HashSet<string> GetCurrentFiles() {
			int col = table.GetColumnIndex("Fasta file path");
			HashSet<string> result = new HashSet<string>();
			for (int i = 0; i < table.RowCount; i++) {
				string s = (string) table.GetEntry(i, col);
				result.Add(s);
			}
			return result;
		}

		private void RemoveButton_OnClick(object sender, EventArgs e) {
			int[] sel = tableView1.GetSelectedRows();
			if (sel.Length == 0) {
				MessageBox.Show(Loc.PleaseSelectSomeRows);
				return;
			}
			table.RemoveRows(sel);
			tableView1.Invalidate(true);
		}

		public string Filter { get; set; } = FileUtils.fastaFilter;

		public string[][] Value {
			get {
				string[][] result = new string[table.RowCount][];
				for (int i = 0; i < result.Length; i++) {
					result[i] = new string[5];
					for (int j = 0; j < result[i].Length; j++) {
						result[i][j] = (string) table.GetEntry(i, j);
					}
				}
				return result;
			}
			set {
				table.Clear();
				foreach (string[] t in value) {
					if (t.Length >= 5) {
						AddFastaFile(t[0], t[1], t[2], t[3], t[4]);
					} else {
						AddFastaFile(t[0], "", "", "", "");
					}
				}
			}
		}
	}
}