using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BaseLibS.Graph;
using BaseLibS.Num;
using BaseLibS.Table;
using BaseLibS.Util;

namespace BaseLib.Forms.Table {
	internal partial class FindForm : Form {
		private const int expandedHeight = 700;
		private readonly TableViewControlModel tableViewWf;
		private readonly ICompoundScrollableControl tableView;
		private readonly ITableModel tableModel;
		private long searchRowIndView = -1;
		private int[] multipleColumns = new int[0];
		private readonly TableViewControlModel searchResultsTableView;

		public FindForm(TableViewControlModel tableViewWf, ICompoundScrollableControl tableView) {
			InitializeComponent();
			Text = Loc.Find;
			searchResultsTableView = new TableViewControlModel(null);
			tableView1.Client = searchResultsTableView;
			searchResultsTableView.origColumnHeaderHeight = 26;
			searchResultsTableView.HasHelp = true;
			searchResultsTableView.MultiSelect = true;
			searchResultsTableView.Sortable = true;
			searchResultsTableView.TableModel = null;
			this.tableViewWf = tableViewWf;
			this.tableView = tableView;
			tableModel = tableViewWf.TableModel;
			wildcardsComboBox.SelectedIndex = 0;
			wildcardsComboBox.Enabled = false;
			helpButton.Enabled = false;
			columnSelectButton.Enabled = false;
			lookInComboBox.Items.Add("Whole table");
			for (int i = 0; i < tableModel.ColumnCount; i++) {
				lookInComboBox.Items.Add(tableModel.GetColumnName(i));
			}
			lookInComboBox.Items.Add("Multiple columns");
			lookInComboBox.SelectedIndex = 0;
			lookInComboBox.SelectedIndexChanged += LookInComboBoxSelectedIndexChanged;
			useCheckBox.Visible = false;
			wildcardsComboBox.Visible = false;
			helpButton.Visible = false;
			searchResultsTableView.SelectionChanged += SearchResultsTableSelectionChanged;
			expressionTextBox.TextChanged += (sender, args) => { searchRowIndView = -1; };
			expressionTextBox.Focus();
			expressionTextBox.SelectAll();
		}

		protected override void OnLoad(EventArgs e) {
			expressionTextBox.Select();
		}

		protected override void OnClosing(CancelEventArgs e) {
			e.Cancel = true;
			Visible = false;
		}

		private void SearchResultsTableSelectionChanged(object sender, EventArgs e) {
			tableViewWf.ClearSelection();
			int[] rows = searchResultsTableView.GetSelectedRows();
			if (rows.Length > 0) {
				int row = rows[0];
				int ind = (int)searchResultsTableView.GetEntry(row, 0) - 1;
				string cname = (string)searchResultsTableView.GetEntry(row, 1);
				tableViewWf.SetSelectedViewIndex(ind);
				tableViewWf.ScrollToRow(ind);
				int colInd = tableModel.GetColumnIndex(cname);
				tableViewWf.ScrollToColumn(colInd);
				tableViewWf.tableView.SwitchOnTextBox();
				object entry = tableViewWf.GetEntry(ind, colInd);
				if (entry != null && !(entry is DBNull)) {
					tableViewWf.tableView.SetAuxText(entry.ToString());
				}
			}
			tableView.Invalidate(true);
		}

		private void LookInComboBoxSelectedIndexChanged(object sender, EventArgs e) {
			columnSelectButton.Enabled = lookInComboBox.SelectedIndex == tableModel.ColumnCount + 1;
		}

		private IEnumerable<int> GetColumnIndices() {
			int ind = lookInComboBox.SelectedIndex;
			if (ind == 0) {
				return ArrayUtils.ConsecutiveInts(0, tableModel.ColumnCount);
			}
			return ind <= tableModel.ColumnCount ? new[] {ind - 1} : multipleColumns;
		}

		private bool MatchCase => matchCaseCheckBox.Checked;
		private bool MatchWholeWord => matchWholeWordCheckBox.Checked;
		private bool SearchUp => searchUpCheckBox.Checked;
		private string SearchString => expressionTextBox.Text;

		private void UseCheckBoxCheckedChanged(object sender, EventArgs e) {
			wildcardsComboBox.Enabled = useCheckBox.Checked;
			helpButton.Enabled = useCheckBox.Checked;
		}

		private void FindAllButtonClick(object sender, EventArgs e) {
			toolStripStatusLabel1.Text = "";
			if (lookInComboBox.SelectedIndex > tableModel.ColumnCount) {
				if (multipleColumns.Length == 0) {
					MessageBox.Show("Please select columns.");
					return;
				}
			}
			bool matchCase = MatchCase;
			bool matchWholeWord = MatchWholeWord;
			string searchString = SearchString;
			if (string.IsNullOrEmpty(searchString)) {
				MessageBox.Show("Please enter a search string.");
				return;
			}
			IEnumerable<int> colInds = GetColumnIndices();
			if (!matchCase) {
				searchString = searchString.ToLower();
			}
			int[][] matchingCols;
			int[] searchInds = FindAll(matchCase, matchWholeWord, searchString, colInds, out matchingCols);
			if (searchInds.Length == 0) {
				toolStripStatusLabel1.Text = "Search string not found.";
			}
			Height = expandedHeight;
			searchResultsTableView.TableModel = CreateSearchResultsTable(searchInds, matchingCols);
			tableView1.VisibleY = 0;
			tableView1.Invalidate(true);
		}

		private ITableModel CreateSearchResultsTable(IList<int> searchInds, IList<int[]> matchingCols) {
			DataTable2 table = new DataTable2("Search results", "Search results");
			table.AddColumn("Row", 100, ColumnType.Integer, "");
			table.AddColumn("Column", 80, ColumnType.Text, "");
			for (int index = 0; index < searchInds.Count; index++) {
				int searchInd = searchInds[index];
				for (int i = 0; i < matchingCols[index].Length; i++) {
					string colName = tableModel.GetColumnName(matchingCols[index][i]);
					DataRow2 row = table.NewRow();
					row["Row"] = searchInd + 1;
					row["Column"] = colName;
					table.AddRow(row);
				}
			}
			return table;
		}

		private int[] FindAll(bool matchCase, bool matchWholeWord, string searchString, IEnumerable<int> colInds,
			out int[][] matchingCols) {
			List<int> result = new List<int>();
			List<int[]> matchingCols2 = new List<int[]>();
			for (int i = 0; i < tableModel.RowCount; i++) {
				int modelInd = tableViewWf.GetModelIndex(i);
				int[] matchingCols1;
				if (MatchRow(modelInd, colInds, matchCase, matchWholeWord, searchString, out matchingCols1)) {
					result.Add(i);
					matchingCols2.Add(matchingCols1);
				}
			}
			matchingCols = matchingCols2.ToArray();
			return result.ToArray();
		}

		private void FindNextButtonClick(object sender, EventArgs e) {
			if (lookInComboBox.SelectedIndex > tableModel.ColumnCount) {
				if (multipleColumns.Length == 0) {
					MessageBox.Show("Please select columns.");
					return;
				}
			}
			bool matchCase = MatchCase;
			bool matchWholeWord = MatchWholeWord;
			bool searchUp = SearchUp;
			string searchString = SearchString;
			if (string.IsNullOrEmpty(searchString)) {
				MessageBox.Show("Please enter a search string.");
				return;
			}
			IEnumerable<int> colInds = GetColumnIndices();
			if (!matchCase) {
				searchString = searchString.ToLower();
			}
			if (searchUp) {
				if (searchRowIndView < 0) {
					searchRowIndView = tableModel.RowCount;
				}
				FindUp(matchCase, matchWholeWord, searchString, colInds);
			} else {
				FindDown(matchCase, matchWholeWord, searchString, colInds);
			}
		}

		private void FindUp(bool matchCase, bool matchWholeWord, string searchString, IEnumerable<int> colInds) {
			toolStripStatusLabel1.Text = "";
			if (searchRowIndView == -1) {
				searchRowIndView = tableViewWf.RowCount;
			}
			searchRowIndView--;
			while (searchRowIndView >= 0) {
				int modelInd = tableViewWf.GetModelIndex((int) searchRowIndView);
				if (MatchRow(modelInd, colInds, matchCase, matchWholeWord, searchString, out int[] matchingCols)) {
					tableViewWf.ClearSelection();
					tableViewWf.SetSelectedViewIndex((int)searchRowIndView);
					tableViewWf.ScrollToRow((int)searchRowIndView);
					int colInd = matchingCols[0];
					tableViewWf.ScrollToColumn(colInd);
					tableViewWf.tableView.SwitchOnTextBox();
					object entry = tableViewWf.GetEntry(modelInd, colInd);
					if (entry != null && !(entry is DBNull)) {
						tableViewWf.tableView.SetAuxText(entry.ToString());
					}
					return;
				}
				searchRowIndView--;
			}
			toolStripStatusLabel1.Text = "Search string not found.";
			searchRowIndView = -1;
		}

		private void FindDown(bool matchCase, bool matchWholeWord, string searchString, IEnumerable<int> colInds) {
			toolStripStatusLabel1.Text = "";
			searchRowIndView++;
			while (searchRowIndView < tableModel.RowCount) {
				int modelInd = tableViewWf.GetModelIndex((int) searchRowIndView);
				if (MatchRow(modelInd, colInds, matchCase, matchWholeWord, searchString, out int[] matchingCols)) {
					tableViewWf.ClearSelection();
					tableViewWf.SetSelectedViewIndex((int)searchRowIndView);
					tableViewWf.ScrollToRow((int)searchRowIndView);
					int colInd = matchingCols[0];
					tableViewWf.ScrollToColumn(colInd);
					tableViewWf.tableView.SwitchOnTextBox();
					object entry = tableViewWf.GetEntry((int)searchRowIndView, colInd);
					if (entry != null && !(entry is DBNull)) {
						tableViewWf.tableView.SetAuxText(entry.ToString());
					}
					return;
				}
				searchRowIndView++;
			}
			toolStripStatusLabel1.Text = "Search string not found.";
			searchRowIndView = -1;
		}

		private bool MatchRow(int rowInd, IEnumerable<int> columnIndices, bool matchCase, bool matchWholeWord,
			string searchString, out int[] matchingCols) {
			List<int> matchingCols1 = new List<int>();
			foreach (int columnIndex in columnIndices) {
				object e = tableModel.GetEntry(rowInd, columnIndex);
				if (e == null) {
					continue;
				}
				string val = e.ToString();
				if (!matchCase) {
					val = val.ToLower();
				}
				if (MatchCell(val, matchWholeWord, searchString)) {
					matchingCols1.Add(columnIndex);
				}
			}
			matchingCols = matchingCols1.Count > 0 ? matchingCols1.ToArray() : null;
			return matchingCols1.Count > 0;
		}

		private static bool MatchCell(string val, bool matchWholeWord, string searchString) {
			if (!matchWholeWord) {
				return val.Contains(searchString);
			}
			val = StringUtils.ReduceWhitespace(val);
			string[] vals = val.Split(' ', ';');
			foreach (string s in vals) {
				if (s.Equals(searchString)) {
					return true;
				}
			}
			return false;
		}

		private void CancelButtonClick(object sender, EventArgs e) {
			Close();
		}

		private void ColumnSelectButtonClick(object sender, EventArgs e) {
			string[] names = new string[tableModel.ColumnCount];
			for (int i = 0; i < names.Length; i++) {
				names[i] = tableModel.GetColumnName(i);
			}
			SelectColumnsForm scf = new SelectColumnsForm(names, multipleColumns);
			scf.ShowDialog();
			multipleColumns = scf.SelectedIndices;
		}

		public void FocusInputField() {
			expressionTextBox.Focus();
			expressionTextBox.SelectAll();
		}
	}
}