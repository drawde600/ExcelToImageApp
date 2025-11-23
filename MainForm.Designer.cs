namespace ExcelToImageApp
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblExcelFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.lblBaseFolder = new System.Windows.Forms.Label();
            this.txtBaseFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseBase = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGenerateAll = new System.Windows.Forms.Button();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblMainClassSummary = new System.Windows.Forms.Label();
            this.lblMainGroupSummary = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tabClass = new System.Windows.Forms.TabPage();
            this.classLayout = new System.Windows.Forms.TableLayoutPanel();
            this.classTopPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerateClass = new System.Windows.Forms.Button();
            this.chkSelectAllClass = new System.Windows.Forms.CheckBox();
            this.chkDeselectAllClass = new System.Windows.Forms.CheckBox();
            this.lblOutputFolderClass = new System.Windows.Forms.Label();
            this.txtOutputFolderClass = new System.Windows.Forms.TextBox();
            this.btnBrowseOutputClass = new System.Windows.Forms.Button();
            this.lblClassSummary = new System.Windows.Forms.Label();
            this.clbClasses = new System.Windows.Forms.CheckedListBox();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.groupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupTopPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerateGroup = new System.Windows.Forms.Button();
            this.chkSelectAllGroup = new System.Windows.Forms.CheckBox();
            this.chkDeselectAllGroup = new System.Windows.Forms.CheckBox();
            this.lblOutputFolderGroup = new System.Windows.Forms.Label();
            this.txtOutputFolderGroup = new System.Windows.Forms.TextBox();
            this.btnBrowseOutputGroup = new System.Windows.Forms.Button();
            this.lblGroupSummary = new System.Windows.Forms.Label();
            this.clbGroups = new System.Windows.Forms.CheckedListBox();
            this.tabStudent = new System.Windows.Forms.TabPage();
            this.tabStaff = new System.Windows.Forms.TabPage();
            this.tabCCA = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.tabClass.SuspendLayout();
            this.classLayout.SuspendLayout();
            this.classTopPanel.SuspendLayout();
            this.tabGroup.SuspendLayout();
            this.groupLayout.SuspendLayout();
            this.groupTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabClass);
            this.tabControl.Controls.Add(this.tabGroup);
            this.tabControl.Controls.Add(this.tabStudent);
            this.tabControl.Controls.Add(this.tabStaff);
            this.tabControl.Controls.Add(this.tabCCA);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 600);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.mainLayout);
            this.tabMain.Location = new System.Drawing.Point(4, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(792, 572);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 3;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.Controls.Add(this.lblExcelFile, 0, 0);
            this.mainLayout.Controls.Add(this.txtFilePath, 1, 0);
            this.mainLayout.Controls.Add(this.btnBrowseFile, 2, 0);
            this.mainLayout.Controls.Add(this.lblBaseFolder, 0, 1);
            this.mainLayout.Controls.Add(this.txtBaseFolder, 1, 1);
            this.mainLayout.Controls.Add(this.btnBrowseBase, 2, 1);
            this.mainLayout.Controls.Add(this.btnLoad, 1, 2);
            this.mainLayout.Controls.Add(this.btnGenerateAll, 2, 2);
            this.mainLayout.Controls.Add(this.grpSummary, 0, 3);
            this.mainLayout.Controls.Add(this.lblLog, 0, 4);
            this.mainLayout.Controls.Add(this.rtbLog, 0, 5);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(3, 3);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(20);
            this.mainLayout.RowCount = 6;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(786, 566);
            this.mainLayout.TabIndex = 0;
            // 
            // lblExcelFile
            // 
            this.lblExcelFile.AutoSize = true;
            this.lblExcelFile.Location = new System.Drawing.Point(23, 20);
            this.lblExcelFile.Name = "lblExcelFile";
            this.lblExcelFile.Size = new System.Drawing.Size(55, 15);
            this.lblExcelFile.TabIndex = 0;
            this.lblExcelFile.Text = "Excel File:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilePath.Location = new System.Drawing.Point(84, 23);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(604, 23);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.DoubleClick += new System.EventHandler(this.TxtFilePath_DoubleClick);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.AutoSize = true;
            this.btnBrowseFile.Location = new System.Drawing.Point(694, 23);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(69, 25);
            this.btnBrowseFile.TabIndex = 2;
            this.btnBrowseFile.Text = "Browse";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.BtnBrowseFile_Click);
            // 
            // lblBaseFolder
            // 
            this.lblBaseFolder.AutoSize = true;
            this.lblBaseFolder.Location = new System.Drawing.Point(23, 51);
            this.lblBaseFolder.Name = "lblBaseFolder";
            this.lblBaseFolder.Size = new System.Drawing.Size(70, 15);
            this.lblBaseFolder.TabIndex = 3;
            this.lblBaseFolder.Text = "Base Folder:";
            // 
            // txtBaseFolder
            // 
            this.txtBaseFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBaseFolder.Location = new System.Drawing.Point(99, 54);
            this.txtBaseFolder.Name = "txtBaseFolder";
            this.txtBaseFolder.Size = new System.Drawing.Size(589, 23);
            this.txtBaseFolder.TabIndex = 4;
            // 
            // btnBrowseBase
            // 
            this.btnBrowseBase.AutoSize = true;
            this.btnBrowseBase.Location = new System.Drawing.Point(694, 54);
            this.btnBrowseBase.Name = "btnBrowseBase";
            this.btnBrowseBase.Size = new System.Drawing.Size(69, 25);
            this.btnBrowseBase.TabIndex = 5;
            this.btnBrowseBase.Text = "Browse";
            this.btnBrowseBase.UseVisualStyleBackColor = true;
            this.btnBrowseBase.Click += new System.EventHandler(this.BtnBrowseBase_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoad.Location = new System.Drawing.Point(99, 85);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(589, 40);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnGenerateAll
            // 
            this.btnGenerateAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenerateAll.Location = new System.Drawing.Point(694, 85);
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.Size = new System.Drawing.Size(100, 40);
            this.btnGenerateAll.TabIndex = 10;
            this.btnGenerateAll.Text = "Generate All";
            this.btnGenerateAll.UseVisualStyleBackColor = true;
            this.btnGenerateAll.Click += new System.EventHandler(this.BtnGenerateAll_Click);
            // 
            // grpSummary
            // 
            this.mainLayout.SetColumnSpan(this.grpSummary, 3);
            this.grpSummary.Controls.Add(this.lblMainClassSummary);
            this.grpSummary.Controls.Add(this.lblMainGroupSummary);
            this.grpSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSummary.Location = new System.Drawing.Point(23, 131);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(740, 50);
            this.grpSummary.TabIndex = 9;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Data Summary";
            // 
            // lblMainClassSummary
            // 
            this.lblMainClassSummary.AutoSize = true;
            this.lblMainClassSummary.Location = new System.Drawing.Point(10, 20);
            this.lblMainClassSummary.Name = "lblMainClassSummary";
            this.lblMainClassSummary.Size = new System.Drawing.Size(120, 15);
            this.lblMainClassSummary.TabIndex = 0;
            this.lblMainClassSummary.Text = "Class: 0 items (0 selected)";
            // 
            // lblMainGroupSummary
            // 
            this.lblMainGroupSummary.AutoSize = true;
            this.lblMainGroupSummary.Location = new System.Drawing.Point(200, 20);
            this.lblMainGroupSummary.Name = "lblMainGroupSummary";
            this.lblMainGroupSummary.Size = new System.Drawing.Size(120, 15);
            this.lblMainGroupSummary.TabIndex = 1;
            this.lblMainGroupSummary.Text = "Group: 0 items (0 selected)";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(23, 184);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(30, 15);
            this.lblLog.TabIndex = 7;
            this.lblLog.Text = "Log:";
            // 
            // rtbLog
            // 
            this.mainLayout.SetColumnSpan(this.rtbLog, 3);
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(23, 202);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(740, 341);
            this.rtbLog.TabIndex = 8;
            this.rtbLog.Text = "";
            // 
            // tabClass
            // 
            this.tabClass.Controls.Add(this.classLayout);
            this.tabClass.Location = new System.Drawing.Point(4, 24);
            this.tabClass.Name = "tabClass";
            this.tabClass.Padding = new System.Windows.Forms.Padding(3);
            this.tabClass.Size = new System.Drawing.Size(792, 572);
            this.tabClass.TabIndex = 1;
            this.tabClass.Text = "Class";
            this.tabClass.UseVisualStyleBackColor = true;
            // 
            // classLayout
            // 
            this.classLayout.ColumnCount = 2;
            this.classLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.classLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.classLayout.Controls.Add(this.classTopPanel, 0, 0);
            this.classLayout.Controls.Add(this.clbClasses, 0, 1);
            this.classLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classLayout.Location = new System.Drawing.Point(3, 3);
            this.classLayout.Name = "classLayout";
            this.classLayout.Padding = new System.Windows.Forms.Padding(10);
            this.classLayout.RowCount = 3;
            this.classLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.classLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.classLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.classLayout.Size = new System.Drawing.Size(786, 566);
            this.classLayout.TabIndex = 0;
            // 
            // classTopPanel
            // 
            this.classTopPanel.AutoSize = true;
            this.classLayout.SetColumnSpan(this.classTopPanel, 2);
            this.classTopPanel.Controls.Add(this.btnGenerateClass);
            this.classTopPanel.Controls.Add(this.chkSelectAllClass);
            this.classTopPanel.Controls.Add(this.chkDeselectAllClass);
            this.classTopPanel.Controls.Add(this.lblOutputFolderClass);
            this.classTopPanel.Controls.Add(this.txtOutputFolderClass);
            this.classTopPanel.Controls.Add(this.btnBrowseOutputClass);
            this.classTopPanel.Controls.Add(this.lblClassSummary);
            this.classTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classTopPanel.Location = new System.Drawing.Point(13, 13);
            this.classTopPanel.Name = "classTopPanel";
            this.classTopPanel.Size = new System.Drawing.Size(760, 51);
            this.classTopPanel.TabIndex = 0;
            // 
            // btnGenerateClass
            // 
            this.btnGenerateClass.AutoSize = true;
            this.btnGenerateClass.Location = new System.Drawing.Point(3, 3);
            this.btnGenerateClass.Name = "btnGenerateClass";
            this.btnGenerateClass.Size = new System.Drawing.Size(106, 25);
            this.btnGenerateClass.TabIndex = 0;
            this.btnGenerateClass.Text = "Generate Images";
            this.btnGenerateClass.UseVisualStyleBackColor = true;
            this.btnGenerateClass.Click += new System.EventHandler(this.BtnGenerateClass_Click);
            // 
            // chkSelectAllClass
            // 
            this.chkSelectAllClass.AutoSize = true;
            this.chkSelectAllClass.Checked = true;
            this.chkSelectAllClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAllClass.Location = new System.Drawing.Point(115, 3);
            this.chkSelectAllClass.Name = "chkSelectAllClass";
            this.chkSelectAllClass.Size = new System.Drawing.Size(74, 19);
            this.chkSelectAllClass.TabIndex = 1;
            this.chkSelectAllClass.Text = "Select All";
            this.chkSelectAllClass.UseVisualStyleBackColor = true;
            this.chkSelectAllClass.Click += new System.EventHandler(this.ChkSelectAllClass_Click);
            // 
            // chkDeselectAllClass
            // 
            this.chkDeselectAllClass.AutoSize = true;
            this.chkDeselectAllClass.Location = new System.Drawing.Point(195, 3);
            this.chkDeselectAllClass.Name = "chkDeselectAllClass";
            this.chkDeselectAllClass.Size = new System.Drawing.Size(87, 19);
            this.chkDeselectAllClass.TabIndex = 2;
            this.chkDeselectAllClass.Text = "Deselect All";
            this.chkDeselectAllClass.UseVisualStyleBackColor = true;
            this.chkDeselectAllClass.Click += new System.EventHandler(this.ChkDeselectAllClass_Click);
            // 
            // lblOutputFolderClass
            // 
            this.lblOutputFolderClass.AutoSize = true;
            this.lblOutputFolderClass.Location = new System.Drawing.Point(288, 0);
            this.lblOutputFolderClass.Name = "lblOutputFolderClass";
            this.lblOutputFolderClass.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblOutputFolderClass.Size = new System.Drawing.Size(84, 20);
            this.lblOutputFolderClass.TabIndex = 3;
            this.lblOutputFolderClass.Text = "Output Folder:";
            // 
            // txtOutputFolderClass
            // 
            this.txtOutputFolderClass.Location = new System.Drawing.Point(378, 3);
            this.txtOutputFolderClass.Name = "txtOutputFolderClass";
            this.txtOutputFolderClass.Size = new System.Drawing.Size(300, 23);
            this.txtOutputFolderClass.TabIndex = 4;
            // 
            // btnBrowseOutputClass
            // 
            this.btnBrowseOutputClass.Location = new System.Drawing.Point(684, 3);
            this.btnBrowseOutputClass.Name = "btnBrowseOutputClass";
            this.btnBrowseOutputClass.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseOutputClass.TabIndex = 5;
            this.btnBrowseOutputClass.Text = "...";
            this.btnBrowseOutputClass.UseVisualStyleBackColor = true;
            this.btnBrowseOutputClass.Click += new System.EventHandler(this.BtnBrowseOutputClass_Click);
            // 
            // lblClassSummary
            // 
            this.lblClassSummary.AutoSize = true;
            this.lblClassSummary.Location = new System.Drawing.Point(3, 31);
            this.lblClassSummary.Name = "lblClassSummary";
            this.lblClassSummary.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblClassSummary.Size = new System.Drawing.Size(107, 20);
            this.lblClassSummary.TabIndex = 6;
            this.lblClassSummary.Text = "Total: 0, Selected: 0";
            // 
            // clbClasses
            // 
            this.clbClasses.CheckOnClick = true;
            this.classLayout.SetColumnSpan(this.clbClasses, 2);
            this.clbClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbClasses.FormattingEnabled = true;
            this.clbClasses.Location = new System.Drawing.Point(13, 70);
            this.clbClasses.Name = "clbClasses";
            this.clbClasses.Size = new System.Drawing.Size(760, 483);
            this.clbClasses.TabIndex = 1;
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.groupLayout);
            this.tabGroup.Location = new System.Drawing.Point(4, 24);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(792, 572);
            this.tabGroup.TabIndex = 2;
            this.tabGroup.Text = "Group";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // groupLayout
            // 
            this.groupLayout.ColumnCount = 2;
            this.groupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.groupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.groupLayout.Controls.Add(this.groupTopPanel, 0, 0);
            this.groupLayout.Controls.Add(this.clbGroups, 0, 1);
            this.groupLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLayout.Location = new System.Drawing.Point(3, 3);
            this.groupLayout.Name = "groupLayout";
            this.groupLayout.Padding = new System.Windows.Forms.Padding(10);
            this.groupLayout.RowCount = 3;
            this.groupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.groupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.groupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.groupLayout.Size = new System.Drawing.Size(786, 566);
            this.groupLayout.TabIndex = 0;
            // 
            // groupTopPanel
            // 
            this.groupTopPanel.AutoSize = true;
            this.groupLayout.SetColumnSpan(this.groupTopPanel, 2);
            this.groupTopPanel.Controls.Add(this.btnGenerateGroup);
            this.groupTopPanel.Controls.Add(this.chkSelectAllGroup);
            this.groupTopPanel.Controls.Add(this.chkDeselectAllGroup);
            this.groupTopPanel.Controls.Add(this.lblOutputFolderGroup);
            this.groupTopPanel.Controls.Add(this.txtOutputFolderGroup);
            this.groupTopPanel.Controls.Add(this.btnBrowseOutputGroup);
            this.groupTopPanel.Controls.Add(this.lblGroupSummary);
            this.groupTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTopPanel.Location = new System.Drawing.Point(13, 13);
            this.groupTopPanel.Name = "groupTopPanel";
            this.groupTopPanel.Size = new System.Drawing.Size(760, 51);
            this.groupTopPanel.TabIndex = 0;
            // 
            // btnGenerateGroup
            // 
            this.btnGenerateGroup.AutoSize = true;
            this.btnGenerateGroup.Location = new System.Drawing.Point(3, 3);
            this.btnGenerateGroup.Name = "btnGenerateGroup";
            this.btnGenerateGroup.Size = new System.Drawing.Size(106, 25);
            this.btnGenerateGroup.TabIndex = 0;
            this.btnGenerateGroup.Text = "Generate Images";
            this.btnGenerateGroup.UseVisualStyleBackColor = true;
            this.btnGenerateGroup.Click += new System.EventHandler(this.BtnGenerateGroup_Click);
            // 
            // chkSelectAllGroup
            // 
            this.chkSelectAllGroup.AutoSize = true;
            this.chkSelectAllGroup.Checked = true;
            this.chkSelectAllGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectAllGroup.Location = new System.Drawing.Point(115, 3);
            this.chkSelectAllGroup.Name = "chkSelectAllGroup";
            this.chkSelectAllGroup.Size = new System.Drawing.Size(74, 19);
            this.chkSelectAllGroup.TabIndex = 1;
            this.chkSelectAllGroup.Text = "Select All";
            this.chkSelectAllGroup.UseVisualStyleBackColor = true;
            this.chkSelectAllGroup.Click += new System.EventHandler(this.ChkSelectAllGroup_Click);
            // 
            // chkDeselectAllGroup
            // 
            this.chkDeselectAllGroup.AutoSize = true;
            this.chkDeselectAllGroup.Location = new System.Drawing.Point(195, 3);
            this.chkDeselectAllGroup.Name = "chkDeselectAllGroup";
            this.chkDeselectAllGroup.Size = new System.Drawing.Size(87, 19);
            this.chkDeselectAllGroup.TabIndex = 2;
            this.chkDeselectAllGroup.Text = "Deselect All";
            this.chkDeselectAllGroup.UseVisualStyleBackColor = true;
            this.chkDeselectAllGroup.Click += new System.EventHandler(this.ChkDeselectAllGroup_Click);
            // 
            // lblOutputFolderGroup
            // 
            this.lblOutputFolderGroup.AutoSize = true;
            this.lblOutputFolderGroup.Location = new System.Drawing.Point(288, 0);
            this.lblOutputFolderGroup.Name = "lblOutputFolderGroup";
            this.lblOutputFolderGroup.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblOutputFolderGroup.Size = new System.Drawing.Size(84, 20);
            this.lblOutputFolderGroup.TabIndex = 3;
            this.lblOutputFolderGroup.Text = "Output Folder:";
            // 
            // txtOutputFolderGroup
            // 
            this.txtOutputFolderGroup.Location = new System.Drawing.Point(378, 3);
            this.txtOutputFolderGroup.Name = "txtOutputFolderGroup";
            this.txtOutputFolderGroup.Size = new System.Drawing.Size(300, 23);
            this.txtOutputFolderGroup.TabIndex = 4;
            // 
            // btnBrowseOutputGroup
            // 
            this.btnBrowseOutputGroup.Location = new System.Drawing.Point(684, 3);
            this.btnBrowseOutputGroup.Name = "btnBrowseOutputGroup";
            this.btnBrowseOutputGroup.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseOutputGroup.TabIndex = 5;
            this.btnBrowseOutputGroup.Text = "...";
            this.btnBrowseOutputGroup.UseVisualStyleBackColor = true;
            this.btnBrowseOutputGroup.Click += new System.EventHandler(this.BtnBrowseOutputGroup_Click);
            // 
            // lblGroupSummary
            // 
            this.lblGroupSummary.AutoSize = true;
            this.lblGroupSummary.Location = new System.Drawing.Point(3, 31);
            this.lblGroupSummary.Name = "lblGroupSummary";
            this.lblGroupSummary.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblGroupSummary.Size = new System.Drawing.Size(107, 20);
            this.lblGroupSummary.TabIndex = 6;
            this.lblGroupSummary.Text = "Total: 0, Selected: 0";
            // 
            // clbGroups
            // 
            this.clbGroups.CheckOnClick = true;
            this.groupLayout.SetColumnSpan(this.clbGroups, 2);
            this.clbGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbGroups.FormattingEnabled = true;
            this.clbGroups.Location = new System.Drawing.Point(13, 70);
            this.clbGroups.Name = "clbGroups";
            this.clbGroups.Size = new System.Drawing.Size(760, 483);
            this.clbGroups.TabIndex = 1;
            // 
            // tabStudent
            // 
            this.tabStudent.Location = new System.Drawing.Point(4, 24);
            this.tabStudent.Name = "tabStudent";
            this.tabStudent.Size = new System.Drawing.Size(792, 572);
            this.tabStudent.TabIndex = 3;
            this.tabStudent.Text = "Student";
            this.tabStudent.UseVisualStyleBackColor = true;
            // 
            // tabStaff
            // 
            this.tabStaff.Location = new System.Drawing.Point(4, 24);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Size = new System.Drawing.Size(792, 572);
            this.tabStaff.TabIndex = 4;
            this.tabStaff.Text = "Staff";
            this.tabStaff.UseVisualStyleBackColor = true;
            // 
            // tabCCA
            // 
            this.tabCCA.Location = new System.Drawing.Point(4, 24);
            this.tabCCA.Name = "tabCCA";
            this.tabCCA.Size = new System.Drawing.Size(792, 572);
            this.tabCCA.TabIndex = 5;
            this.tabCCA.Text = "CCA";
            this.tabCCA.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Excel to Image Converter";
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.tabClass.ResumeLayout(false);
            this.classLayout.ResumeLayout(false);
            this.classLayout.PerformLayout();
            this.classTopPanel.ResumeLayout(false);
            this.classTopPanel.PerformLayout();
            this.tabGroup.ResumeLayout(false);
            this.groupLayout.ResumeLayout(false);
            this.groupLayout.PerformLayout();
            this.groupTopPanel.ResumeLayout(false);
            this.groupTopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Label lblExcelFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Label lblBaseFolder;
        private System.Windows.Forms.TextBox txtBaseFolder;
        private System.Windows.Forms.Button btnBrowseBase;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TabPage tabStudent;
        private System.Windows.Forms.TabPage tabStaff;
        private System.Windows.Forms.TabPage tabCCA;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblMainClassSummary;
        private System.Windows.Forms.Label lblClassSummary;
        private System.Windows.Forms.Button btnGenerateAll;
        private System.Windows.Forms.Label lblMainGroupSummary;

        // Group Tab Controls
        private System.Windows.Forms.TableLayoutPanel groupLayout;
        private System.Windows.Forms.FlowLayoutPanel groupTopPanel;
        private System.Windows.Forms.Button btnGenerateGroup;
        private System.Windows.Forms.CheckBox chkSelectAllGroup;
        private System.Windows.Forms.CheckBox chkDeselectAllGroup;
        private System.Windows.Forms.Label lblOutputFolderGroup;
        private System.Windows.Forms.TextBox txtOutputFolderGroup;
        private System.Windows.Forms.Button btnBrowseOutputGroup;
        private System.Windows.Forms.Label lblGroupSummary;
        private System.Windows.Forms.CheckedListBox clbGroups;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.TabPage tabClass;
        private System.Windows.Forms.TableLayoutPanel classLayout;
        private System.Windows.Forms.FlowLayoutPanel classTopPanel;
        private System.Windows.Forms.Button btnGenerateClass;
        private System.Windows.Forms.CheckBox chkSelectAllClass;
        private System.Windows.Forms.CheckBox chkDeselectAllClass;
        private System.Windows.Forms.Label lblOutputFolderClass;
        private System.Windows.Forms.TextBox txtOutputFolderClass;
        private System.Windows.Forms.Button btnBrowseOutputClass;
        private System.Windows.Forms.CheckedListBox clbClasses;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}
