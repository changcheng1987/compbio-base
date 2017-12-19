using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BaseLibS.Table;
using BaseLibS.Util;
using Utils.Parsing.Misc;

namespace MaxQuantPLib.AndromedaConf{
	public partial class TestParseRulesForm : Form{
		private readonly string identifierParseRule;
		private readonly string descriptionParseRule;
		private readonly string variationParseRule;
		private readonly string modificationParseRule;
		private readonly string taxonomyParseRule;
		private readonly DataTable2 tableModel;
		public TestParseRulesForm(string identifierParseRule, string descriptionParseRule, string taxonomyParseRule,
			string variationParseRule, string modificationParseRule){
			InitializeComponent();
			this.identifierParseRule = identifierParseRule;
			this.descriptionParseRule = descriptionParseRule;
			this.variationParseRule = variationParseRule;
			this.modificationParseRule = modificationParseRule;
			this.taxonomyParseRule = taxonomyParseRule;
			tableModel = CreateTable();
			mainTable.TableModel = tableModel;
			selectFileButton.Click += SelectFileButton_OnClick;
			testButton.Click += TestButton_OnClick;
		}
		private void SelectFileButton_OnClick(object sender, EventArgs e){
			OpenFileDialog ofd = new OpenFileDialog{Filter = FileUtils.fastaFilter};
			if (ofd.ShowDialog() == DialogResult.OK){
				string s = ofd.FileName;
				filePathTextBox.Text = s;
				TestButton_OnClick(sender, e);
			}
		}
		private void TestButton_OnClick(object sender, EventArgs e){
			int minEntry;
			if (!Parser.TryInt(minEntryTextBox.Text, out minEntry)){
				minEntry = 1;
				minEntryTextBox.Text = "1";
			}
			int maxEntry;
			if (!Parser.TryInt(maxEntryTextBox.Text, out maxEntry)){
				maxEntry = 100;
				maxEntryTextBox.Text = "100";
			}
			minEntry = Math.Max(0, minEntry);
			maxEntry = Math.Max(0, maxEntry);
			maxEntry = Math.Max(minEntry, maxEntry);
			minEntry--;
			string filePath = filePathTextBox.Text;
			if (string.IsNullOrEmpty(filePath)){
				MessageBox.Show("Please specify a fasta File");
				return;
			}
			if (!File.Exists(filePath)){
				MessageBox.Show("The File " + filePath + " does not exist.");
				return;
			}
			TestFile(filePath, minEntry, maxEntry);
		}
		private static DataTable2 CreateTable(){
			DataTable2 t = new DataTable2("databases");
			t.AddColumn("Header", 110, ColumnType.Text, "");
			t.AddColumn("Sequence", 110, ColumnType.Text, "");
			t.AddColumn("Identifier", 80, ColumnType.Text, "");
			t.AddColumn("Description", 80, ColumnType.Text, "");
			t.AddColumn("Taxonomy string", 80, ColumnType.Text, "");
			t.AddColumn("Variation string", 80, ColumnType.Text, "");
			t.AddColumn("Modification string", 80, ColumnType.Text, "");
			return t;
		}
		private void TestFile(string filePath, int minEntry, int maxEntry){
			Regex nameRegex = null;
			if (!string.IsNullOrEmpty(identifierParseRule)){
				nameRegex = new Regex(identifierParseRule);
			}
			Regex descriptionRegex = null;
			if (!string.IsNullOrEmpty(descriptionParseRule)){
				descriptionRegex = new Regex(descriptionParseRule);
			}
			Regex variationRegex = null;
			if (!string.IsNullOrEmpty(variationParseRule)){
				variationRegex = new Regex(variationParseRule);
			}
			Regex modificationRegex = null;
			if (!string.IsNullOrEmpty(modificationParseRule)){
				modificationRegex = new Regex(modificationParseRule);
			}
			Regex taxonomyRegex = null;
			if (!string.IsNullOrEmpty(taxonomyParseRule)){
				taxonomyRegex = new Regex(taxonomyParseRule);
			}
			string[] headers;
			string[] sequences;
			GetDataFromFile(filePath, minEntry, maxEntry, out headers, out sequences);
			tableModel.Clear();
			for (int i = 0; i < headers.Length; i++){
				DataRow2 r = tableModel.NewRow();
				string header = headers[i];
				r["Sequence"] = sequences[i];
				r["Header"] = header;
				if (nameRegex != null){
					r["Identifier"] = nameRegex.Match(header).Groups[1].ToString();
				}
				if (descriptionRegex != null){
					r["Description"] = descriptionRegex.Match(header).Groups[1].ToString();
				}
				if (variationRegex != null){
					r["Variation string"] = variationRegex.Match(header).Groups[1].ToString();
				}
				if (modificationRegex != null){
					r["Modification string"] = modificationRegex.Match(header).Groups[1].ToString();
				}
				if (taxonomyRegex != null){
					r["Taxonomy string"] = taxonomyRegex.Match(header).Groups[1].ToString();
				}
				tableModel.AddRow(r);
			}
			mainTable.Invalidate(true);
		}
		private static void GetDataFromFile(string filePath, int minEntry, int maxEntry, out string[] headers,
			out string[] sequences){
			List<string> headers1 = new List<string>();
			List<string> sequences1 = new List<string>();
			int count = 0;
			FastaParser fp = new FastaParser(filePath, (header, sequence) =>{
				if (count < minEntry){
					count++;
					return false;
				}
				if (count >= maxEntry){
					return true;
				}
				headers1.Add(">" + header);
				sequences1.Add(sequence);
				count++;
				return false;
			});
			fp.Parse();
			headers = headers1.ToArray();
			sequences = sequences1.ToArray();
		}
	}
}