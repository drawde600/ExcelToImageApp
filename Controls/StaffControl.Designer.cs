namespace ExcelToImageApp.Controls
{
    partial class StaffControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkDeselectAll = new System.Windows.Forms.CheckBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblPattern = new System.Windows.Forms.Label();
            this.cmbPattern = new System.Windows.Forms.ComboBox();
            this.clbStaff = new System.Windows.Forms.CheckedListBox();
            this.mainLayout.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.topPanel, 0, 0);
            this.mainLayout.Controls.Add(this.clbStaff, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(10);
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(800, 500);
            this.mainLayout.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.AutoSize = true;
            this.topPanel.Controls.Add(this.btnGenerate);
            this.topPanel.Controls.Add(this.chkSelectAll);
            this.topPanel.Controls.Add(this.chkDeselectAll);
            this.topPanel.Controls.Add(this.lblOutputFolder);
            this.topPanel.Controls.Add(this.txtOutputFolder);
            this.topPanel.Controls.Add(this.btnBrowse);
            this.topPanel.Controls.Add(this.lblPattern);
            this.topPanel.Controls.Add(this.cmbPattern);
            this.topPanel.Controls.Add(this.lblSummary);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(13, 13);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(774, 31);
            this.topPanel.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.Location = new System.Drawing.Point(3, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(106, 25);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate Images";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Checked = true;
            this.chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAll.Location = new System.Drawing.Point(115, 3);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.chkSelectAll.Size = new System.Drawing.Size(74, 22);
            this.chkSelectAll.TabIndex = 1;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Click += new System.EventHandler(this.ChkSelectAll_Click);
            // 
            // chkDeselectAll
            // 
            this.chkDeselectAll.AutoSize = true;
            this.chkDeselectAll.Location = new System.Drawing.Point(195, 3);
            this.chkDeselectAll.Name = "chkDeselectAll";
            this.chkDeselectAll.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.chkDeselectAll.Size = new System.Drawing.Size(87, 22);
            this.chkDeselectAll.TabIndex = 2;
            this.chkDeselectAll.Text = "Deselect All";
            this.chkDeselectAll.UseVisualStyleBackColor = true;
            this.chkDeselectAll.Click += new System.EventHandler(this.ChkDeselectAll_Click);
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(288, 0);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblOutputFolder.Size = new System.Drawing.Size(84, 23);
            this.lblOutputFolder.TabIndex = 3;
            this.lblOutputFolder.Text = "Output Folder:";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(378, 3);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(250, 23);
            this.txtOutputFolder.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(634, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.Location = new System.Drawing.Point(670, 0);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblPattern.Size = new System.Drawing.Size(94, 23);
            this.lblPattern.TabIndex = 7;
            this.lblPattern.Text = "Filename Pattern:";
            // 
            // cmbPattern
            // 
            this.cmbPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPattern.FormattingEnabled = true;
            this.cmbPattern.Items.AddRange(new object[] {
            "{STAFF}{SEPA}{POSITION}{SEPA}{SEQNO}.{EXT}",
            "{STAFF}{SEPA}{POSITION}{SEPA}{SEQNO3}.{EXT}"});
            this.cmbPattern.Location = new System.Drawing.Point(770, 3);
            this.cmbPattern.Name = "cmbPattern";
            this.cmbPattern.Size = new System.Drawing.Size(220, 23);
            this.cmbPattern.TabIndex = 8;
            this.cmbPattern.SelectedIndex = 0;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(670, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblSummary.Size = new System.Drawing.Size(107, 23);
            this.lblSummary.TabIndex = 6;
            this.lblSummary.Text = "Total: 0, Selected: 0";
            // 
            // clbStaff
            // 
            this.clbStaff.CheckOnClick = true;
            this.clbStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbStaff.FormattingEnabled = true;
            this.clbStaff.Location = new System.Drawing.Point(13, 50);
            this.clbStaff.Name = "clbStaff";
            this.clbStaff.Size = new System.Drawing.Size(774, 437);
            this.clbStaff.TabIndex = 1;
            this.clbStaff.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ClbStaff_ItemCheck);
            // 
            // StaffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayout);
            this.Name = "StaffControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel topPanel;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.CheckBox chkDeselectAll;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.CheckedListBox clbStaff;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.ComboBox cmbPattern;
    }
}
