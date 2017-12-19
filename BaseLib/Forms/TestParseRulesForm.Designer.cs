namespace MaxQuantPLib.AndromedaConf
{
	partial class TestParseRulesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.minEntryTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.maxEntryTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.testButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.filePathTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.selectFileButton = new System.Windows.Forms.ToolStripButton();
            this.mainTable = new BaseLib.Forms.Table.TableView();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.minEntryTextBox,
            this.toolStripLabel2,
            this.maxEntryTextBox,
            this.testButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(620, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel1.Text = "Min. entry";
            // 
            // minEntryTextBox
            // 
            this.minEntryTextBox.Name = "minEntryTextBox";
            this.minEntryTextBox.Size = new System.Drawing.Size(100, 25);
            this.minEntryTextBox.Text = "1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel2.Text = "Max. entry";
            // 
            // maxEntryTextBox
            // 
            this.maxEntryTextBox.Name = "maxEntryTextBox";
            this.maxEntryTextBox.Size = new System.Drawing.Size(100, 25);
            this.maxEntryTextBox.Text = "100";
            // 
            // testButton
            // 
            this.testButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.testButton.Image = global::MaxQuantPLib.Properties.Resources.refreshButton;
            this.testButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(23, 22);
            this.testButton.Text = "toolStripButton1";
            this.testButton.ToolTipText = "Refresh";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePathTextBox,
            this.selectFileButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(620, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(270, 25);
            // 
            // selectFileButton
            // 
            this.selectFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectFileButton.Image = global::MaxQuantPLib.Properties.Resources.upload64;
            this.selectFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(23, 22);
            this.selectFileButton.Text = "toolStripButton2";
            this.selectFileButton.ToolTipText = "Select .fasta file";
            // 
            // mainTable
            // 
            this.mainTable.ColumnHeaderHeight = 26;
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.HasSelectionAgent = false;
            this.mainTable.Location = new System.Drawing.Point(0, 50);
            this.mainTable.Margin = new System.Windows.Forms.Padding(0);
            this.mainTable.MultiSelect = true;
            this.mainTable.Name = "mainTable";
            this.mainTable.RowHeaderWidth = 70;
            this.mainTable.Size = new System.Drawing.Size(620, 404);
            this.mainTable.Sortable = true;
            this.mainTable.TabIndex = 4;
            this.mainTable.TableModel = null;
            this.mainTable.VisibleX = 0;
            this.mainTable.VisibleY = 0;
            // 
            // TestParseRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 454);
            this.Controls.Add(this.mainTable);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TestParseRulesForm";
            this.Text = "Testing parse rules";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private BaseLib.Forms.Table.TableView mainTable;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox minEntryTextBox;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripTextBox maxEntryTextBox;
		private System.Windows.Forms.ToolStripButton testButton;
		private System.Windows.Forms.ToolStripTextBox filePathTextBox;
		private System.Windows.Forms.ToolStripButton selectFileButton;
	}
}