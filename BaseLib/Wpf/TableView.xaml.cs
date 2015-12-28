﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using BaseLib.Forms.Table;
using BaseLibS.Util;

namespace BaseLib.Wpf{
	/// <summary>
	/// Interaction logic for TableView.xaml
	/// </summary>
	public partial class TableView{
		public event EventHandler SelectionChanged;
		private readonly TableViewWf tableView;

		public TableView(){
			InitializeComponent();
			tableView = new TableViewWf();
			tableView.SelectionChanged += (sender, args) =>{
				SelectionChanged?.Invoke(sender, args);
				long c = tableView.SelectedCount;
				long t = tableView.RowCount;
				SelectedTextBlock.Text = c > 0 ? "" + StringUtils.WithDecimalSeparators(c) + " selected" : "";
				ItemsTextBlock.Text = "" + StringUtils.WithDecimalSeparators(t) + " items";
			};
			MainPanel.Child = tableView;
			KeyDown += (sender, args) => tableView.Focus();
		}

		public ITableModel TableModel{
			get { return tableView.TableModel; }
			set{
				tableView.TableModel = value;
				ItemsTextBlock.Text = value != null ? "" + StringUtils.WithDecimalSeparators(value.RowCount) + " items" : "";
			}
		}

		public void Select(){
			tableView.Select();
		}

		public void SwitchOnTextBox(){
			tableView.SetCellText = s => AuxTextBox.Text = s;
			MainGrid.RowDefinitions.Clear();
			MainGrid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(100, GridUnitType.Star)});
			MainGrid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(5)});
			MainGrid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(30)});
			MainGrid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(17)});
		}

		public void SwitchOffTextBox(){
			AuxTextBox.Text = "";
			tableView.SetCellText = null;
			MainGrid.RowDefinitions.Clear();
			MainGrid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(100, GridUnitType.Star)});
			MainGrid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(0)});
			MainGrid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(0)});
			MainGrid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(17)});
		}

		public bool MultiSelect{
			get { return tableView.MultiSelect; }
			set { tableView.MultiSelect = value; }
		}

		public bool Sortable{
			get { return tableView.Sortable; }
			set { tableView.Sortable = value; }
		}

		public int RowCount => tableView.RowCount;

		public int RowHeaderWidth{
			get { return tableView.RowHeaderWidth; }
			set { tableView.RowHeaderWidth = value; }
		}

		public int ColumnHeaderHeight{
			get { return tableView.ColumnHeaderHeight; }
			set { tableView.ColumnHeaderHeight = value; }
		}

		public int VisibleX{
			get { return tableView.VisibleX; }
			set { tableView.VisibleX = value; }
		}

		public int VisibleY{
			get { return tableView.VisibleY; }
			set { tableView.VisibleY = value; }
		}

		public void SetSelectedRow(int row){
			tableView.SetSelectedRow(row);
		}

		public void SetSelectedRow(int row, bool add, bool fire){
			tableView.SetSelectedRow(row, add, fire);
		}

		public bool HasSelectedRows(){
			return tableView.HasSelectedRows();
		}

		public void SetSelectedRows(IList<int> rows){
			tableView.SetSelectedRows(rows);
		}

		public void SetSelectedRows(IList<int> rows, bool add, bool fire){
			tableView.SetSelectedRows(rows, add, fire);
		}

		public void SetSelectedRowAndMove(int row){
			tableView.SetSelectedRowAndMove(row);
		}

		public void SetSelectedRowsAndMove(IList<int> rows){
			tableView.SetSelectedRowsAndMove(rows);
		}

		public void Invalidate(){
			tableView.Invalidate(true);
		}

		public int[] GetSelectedRows(){
			return tableView.GetSelectedRows();
		}

		public int GetSelectedRow(){
			return tableView.GetSelectedRow();
		}

		public void ScrollToRow(int row){
			tableView.ScrollToRow(row);
		}

		public void BringSelectionToTop(){
			tableView.BringSelectionToTop();
		}

		public void FireSelectionChange(){
			tableView.FireSelectionChange();
		}

		public bool ModelRowIsSelected(int row){
			return tableView.ModelRowIsSelected(row);
		}

		public void ClearSelection(){
			tableView.ClearSelection();
		}

		public void SelectAll(){
			tableView.SelectAll();
		}

		public void SetSelection(bool[] selection){
			tableView.SetSelection(selection);
		}

		public void SetSelectedIndex(int index){
			tableView.SetSelectedIndex(index);
		}

		public void SetSelectedViewIndex(int index){
			tableView.SetSelectedViewIndex(index);
		}

		public void SetSelectedIndex(int index, object sender){
			tableView.SetSelectedIndex(index, sender);
		}

		public void AddContextMenuItem(ToolStripItem item){
			tableView.AddContextMenuItem(item);
		}

		public object GetEntry(int row, int col){
			return tableView.GetEntry(row, col);
		}

		private void TextButton_OnClick(object sender, RoutedEventArgs e){
			if (textBoxVisible){
				SwitchOffTextBox();
			} else{
				SwitchOnTextBox();
			}
			textBoxVisible = !textBoxVisible;
		}

		public void RegisterScrollViewer(ScrollViewer scrollViewer){
			MainPanel.RegisterScrollViewer(scrollViewer);
		}

		public void UnregisterScrollViewer(ScrollViewer scrollViewer){
			MainPanel.UnregisterScrollViewer(scrollViewer);
		}

		public void ClearSelectionFire(){
			tableView.ClearSelectionFire();
		}

		private bool textBoxVisible;
	}
}