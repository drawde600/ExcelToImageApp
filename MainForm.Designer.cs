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
            tabControl = new TabControl();
            tabMain = new TabPage();
            mainLayout = new TableLayoutPanel();
            lblExcelFile = new Label();
            txtFilePath = new TextBox();
            btnBrowseFile = new Button();
            lblBaseFolder = new Label();
            txtBaseFolder = new TextBox();
            btnBrowseBase = new Button();
            btnLoad = new Button();
            btnGenerateAll = new Button();
            btnClean = new Button();
            lblReferenceSubfolder = new Label();
            txtReferenceSubfolder = new TextBox();
            chkCopyToAll = new CheckBox();
            lblSeparator = new Label();
            cmbSeparator = new ComboBox();
            chkUppercase = new CheckBox();
            lblSchoolName = new Label();
            txtSchoolName = new TextBox();
            lblSchoolShortName = new Label();
            txtSchoolShortName = new TextBox();
            grpSummary = new GroupBox();
            lblMainClassSummary = new Label();
            lblMainGroupSummary = new Label();
            lblMainCCASummary = new Label();
            lblMainStaffSummary = new Label();
            lblMainStudentSummary = new Label();
            lblLog = new Label();
            rtbLog = new RichTextBox();
            tabClass = new TabPage();
            classLayout = new TableLayoutPanel();
            classTopPanel = new FlowLayoutPanel();
            btnGenerateClass = new Button();
            chkSelectAllClass = new CheckBox();
            chkDeselectAllClass = new CheckBox();
            lblOutputFolderClass = new Label();
            txtOutputFolderClass = new TextBox();
            btnBrowseOutputClass = new Button();
            lblClassFilenamePattern = new Label();
            cmbClassFilenamePattern = new ComboBox();
            lblClassSummary = new Label();
            clbClasses = new CheckedListBox();
            tabGroup = new TabPage();
            groupLayout = new TableLayoutPanel();
            groupTopPanel = new FlowLayoutPanel();
            btnGenerateGroup = new Button();
            chkSelectAllGroup = new CheckBox();
            chkDeselectAllGroup = new CheckBox();
            lblOutputFolderGroup = new Label();
            txtOutputFolderGroup = new TextBox();
            btnBrowseOutputGroup = new Button();
            lblGroupFilenamePattern = new Label();
            cmbGroupFilenamePattern = new ComboBox();
            lblGroupSummary = new Label();
            clbGroups = new CheckedListBox();
            tabStudent = new TabPage();
            _studentControl = new ExcelToImageApp.Controls.StudentControl();
            tabStaff = new TabPage();
            _staffControl = new ExcelToImageApp.Controls.StaffControl();
            tabCCA = new TabPage();
            ccaLayout = new TableLayoutPanel();
            ccaTopPanel = new FlowLayoutPanel();
            btnGenerateCCA = new Button();
            chkSelectAllCCA = new CheckBox();
            chkDeselectAllCCA = new CheckBox();
            lblOutputFolderCCA = new Label();
            txtOutputFolderCCA = new TextBox();
            btnBrowseOutputCCA = new Button();
            lblCCAFilenamePattern = new Label();
            cmbCCAFilenamePattern = new ComboBox();
            lblCCASummary = new Label();
            clbCCAs = new CheckedListBox();
            tabControl.SuspendLayout();
            tabMain.SuspendLayout();
            mainLayout.SuspendLayout();
            grpSummary.SuspendLayout();
            tabClass.SuspendLayout();
            classLayout.SuspendLayout();
            classTopPanel.SuspendLayout();
            tabGroup.SuspendLayout();
            groupLayout.SuspendLayout();
            groupTopPanel.SuspendLayout();
            tabStudent.SuspendLayout();
            tabStaff.SuspendLayout();
            tabCCA.SuspendLayout();
            ccaLayout.SuspendLayout();
            ccaTopPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabMain);
            tabControl.Controls.Add(tabClass);
            tabControl.Controls.Add(tabGroup);
            tabControl.Controls.Add(tabStudent);
            tabControl.Controls.Add(tabStaff);
            tabControl.Controls.Add(tabCCA);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(960, 600);
            tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(mainLayout);
            tabMain.Location = new Point(4, 24);
            tabMain.Name = "tabMain";
            tabMain.Padding = new Padding(3);
            tabMain.Size = new Size(952, 572);
            tabMain.TabIndex = 0;
            tabMain.Text = "Main";
            tabMain.UseVisualStyleBackColor = true;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 3;
            mainLayout.ColumnStyles.Add(new ColumnStyle());
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.ColumnStyles.Add(new ColumnStyle());
            mainLayout.Controls.Add(lblExcelFile, 0, 0);
            mainLayout.Controls.Add(txtFilePath, 1, 0);
            mainLayout.Controls.Add(btnBrowseFile, 2, 0);
            mainLayout.Controls.Add(lblBaseFolder, 0, 1);
            mainLayout.Controls.Add(txtBaseFolder, 1, 1);
            mainLayout.Controls.Add(btnBrowseBase, 2, 1);
            mainLayout.Controls.Add(btnLoad, 1, 2);
            mainLayout.Controls.Add(btnGenerateAll, 2, 2);
            mainLayout.Controls.Add(lblReferenceSubfolder, 0, 3);
            mainLayout.Controls.Add(txtReferenceSubfolder, 1, 3);
            mainLayout.Controls.Add(chkCopyToAll, 0, 2);
            mainLayout.Controls.Add(lblSeparator, 0, 4);
            mainLayout.Controls.Add(cmbSeparator, 1, 4);
            mainLayout.Controls.Add(chkUppercase, 2, 4);
            mainLayout.Controls.Add(lblSchoolName, 0, 5);
            mainLayout.Controls.Add(txtSchoolName, 1, 5);
            mainLayout.Controls.Add(lblSchoolShortName, 0, 6);
            mainLayout.Controls.Add(txtSchoolShortName, 1, 6);
            mainLayout.Controls.Add(btnClean, 2, 6);
            mainLayout.Controls.Add(grpSummary, 0, 7);
            mainLayout.Controls.Add(lblLog, 0, 8);
            mainLayout.Controls.Add(rtbLog, 0, 9);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(3, 3);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(20);
            mainLayout.RowCount = 10;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 0F));
            mainLayout.Size = new Size(946, 566);
            mainLayout.TabIndex = 0;
            // 
            // lblExcelFile
            // 
            lblExcelFile.AutoSize = true;
            lblExcelFile.Location = new Point(23, 20);
            lblExcelFile.Name = "lblExcelFile";
            lblExcelFile.Size = new Size(57, 15);
            lblExcelFile.TabIndex = 0;
            lblExcelFile.Text = "Excel File:";
            // 
            // txtFilePath
            // 
            txtFilePath.Dock = DockStyle.Fill;
            txtFilePath.Location = new Point(145, 23);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(617, 23);
            txtFilePath.TabIndex = 1;
            txtFilePath.DoubleClick += TxtFilePath_DoubleClick;
            // 
            // btnBrowseFile
            // 
            btnBrowseFile.AutoSize = true;
            btnBrowseFile.Location = new Point(768, 23);
            btnBrowseFile.Name = "btnBrowseFile";
            btnBrowseFile.Size = new Size(69, 25);
            btnBrowseFile.TabIndex = 2;
            btnBrowseFile.Text = "Browse";
            btnBrowseFile.UseVisualStyleBackColor = true;
            btnBrowseFile.Click += BtnBrowseFile_Click;
            // 
            // lblBaseFolder
            // 
            lblBaseFolder.AutoSize = true;
            lblBaseFolder.Location = new Point(23, 51);
            lblBaseFolder.Name = "lblBaseFolder";
            lblBaseFolder.Size = new Size(70, 15);
            lblBaseFolder.TabIndex = 3;
            lblBaseFolder.Text = "Base Folder:";
            // 
            // txtBaseFolder
            // 
            txtBaseFolder.Dock = DockStyle.Fill;
            txtBaseFolder.Location = new Point(145, 54);
            txtBaseFolder.Name = "txtBaseFolder";
            txtBaseFolder.Size = new Size(617, 23);
            txtBaseFolder.TabIndex = 4;
            // 
            // btnBrowseBase
            // 
            btnBrowseBase.AutoSize = true;
            btnBrowseBase.Location = new Point(768, 54);
            btnBrowseBase.Name = "btnBrowseBase";
            btnBrowseBase.Size = new Size(69, 25);
            btnBrowseBase.TabIndex = 5;
            btnBrowseBase.Text = "Browse";
            btnBrowseBase.UseVisualStyleBackColor = true;
            btnBrowseBase.Click += BtnBrowseBase_Click;
            // 
            // btnLoad
            // 
            btnLoad.Dock = DockStyle.Top;
            btnLoad.Location = new Point(145, 85);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(617, 40);
            btnLoad.TabIndex = 6;
            btnLoad.Text = "Load Data";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += BtnLoad_Click;
            // 
            // btnGenerateAll
            // 
            btnGenerateAll.Dock = DockStyle.Top;
            btnGenerateAll.Location = new Point(768, 85);
            btnGenerateAll.Name = "btnGenerateAll";
            btnGenerateAll.Size = new Size(155, 40);
            btnGenerateAll.TabIndex = 10;
            btnGenerateAll.Text = "Generate All";
            btnGenerateAll.UseVisualStyleBackColor = true;
            btnGenerateAll.Click += BtnGenerateAll_Click;
            btnGenerateAll.Enabled = false;
            // 
            // btnClean
            // 
            btnClean.AutoSize = true;
            btnClean.Dock = DockStyle.Top;
            btnClean.Location = new Point(663, 220);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(100, 40);
            btnClean.TabIndex = 11;
            btnClean.Text = "CLEAN";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += BtnClean_Click;
            // 
            // lblReferenceSubfolder
            // 
            lblReferenceSubfolder.AutoSize = true;
            lblReferenceSubfolder.Location = new Point(23, 128);
            lblReferenceSubfolder.Name = "lblReferenceSubfolder";
            lblReferenceSubfolder.Size = new Size(116, 15);
            lblReferenceSubfolder.TabIndex = 11;
            lblReferenceSubfolder.Text = "Reference Subfolder:";
            // 
            // txtReferenceSubfolder
            // 
            mainLayout.SetColumnSpan(txtReferenceSubfolder, 2);
            txtReferenceSubfolder.Dock = DockStyle.Fill;
            txtReferenceSubfolder.Location = new Point(145, 131);
            txtReferenceSubfolder.Name = "txtReferenceSubfolder";
            txtReferenceSubfolder.Size = new Size(778, 23);
            txtReferenceSubfolder.TabIndex = 12;
            txtReferenceSubfolder.Text = "ReferenceImage";
            // 
            // chkCopyToAll
            // 
            chkCopyToAll.AutoSize = true;
            chkCopyToAll.Location = new Point(663, 131);
            chkCopyToAll.Name = "chkCopyToAll";
            chkCopyToAll.Size = new Size(94, 19);
            chkCopyToAll.TabIndex = 13;
            chkCopyToAll.Text = "Copy to All";
            chkCopyToAll.UseVisualStyleBackColor = true;
            // 
            // lblSeparator
            // 
            lblSeparator.AutoSize = true;
            lblSeparator.Location = new Point(23, 157);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(60, 15);
            lblSeparator.TabIndex = 14;
            lblSeparator.Text = "Separator:";
            // 
            // cmbSeparator
            // 
            cmbSeparator.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeparator.FormattingEnabled = true;
            cmbSeparator.Items.AddRange(new object[] { "_", "-", " " });
            cmbSeparator.Location = new Point(145, 160);
            cmbSeparator.Name = "cmbSeparator";
            cmbSeparator.Size = new Size(80, 23);
            cmbSeparator.TabIndex = 15;
            // 
            // chkUppercase
            // 
            chkUppercase.AutoSize = true;
            chkUppercase.Checked = true;
            chkUppercase.CheckState = CheckState.Checked;
            chkUppercase.Location = new Point(768, 160);
            chkUppercase.Name = "chkUppercase";
            chkUppercase.Size = new Size(155, 19);
            chkUppercase.TabIndex = 16;
            chkUppercase.Text = "Convert all to Uppercase";
            chkUppercase.UseVisualStyleBackColor = true;
            chkUppercase.Checked = true;
            chkUppercase.CheckedChanged += ChkUppercase_CheckedChanged;
            // 
            // lblSchoolName
            // 
            lblSchoolName.AutoSize = true;
            lblSchoolName.Location = new Point(23, 186);
            lblSchoolName.Name = "lblSchoolName";
            lblSchoolName.Size = new Size(81, 15);
            lblSchoolName.TabIndex = 16;
            lblSchoolName.Text = "School Name:";
            // 
            // txtSchoolName
            // 
            mainLayout.SetColumnSpan(txtSchoolName, 2);
            txtSchoolName.Dock = DockStyle.Fill;
            txtSchoolName.Location = new Point(145, 189);
            txtSchoolName.Name = "txtSchoolName";
            txtSchoolName.Size = new Size(778, 23);
            txtSchoolName.TabIndex = 17;
            txtSchoolName.Text = "SCHOOL";
            // 
            // lblSchoolShortName
            // 
            lblSchoolShortName.AutoSize = true;
            lblSchoolShortName.Location = new Point(23, 215);
            lblSchoolShortName.Name = "lblSchoolShortName";
            lblSchoolShortName.Size = new Size(112, 15);
            lblSchoolShortName.TabIndex = 18;
            lblSchoolShortName.Text = "School Short Name:";
            // 
            // txtSchoolShortName
            // 
            txtSchoolShortName.Dock = DockStyle.Left;
            txtSchoolShortName.Location = new Point(145, 218);
            txtSchoolShortName.Name = "txtSchoolShortName";
            txtSchoolShortName.Size = new Size(80, 23);
            txtSchoolShortName.TabIndex = 19;
            txtSchoolShortName.Text = "SC";
            // 
            // grpSummary
            // 
            mainLayout.SetColumnSpan(grpSummary, 3);
            grpSummary.Controls.Add(lblMainClassSummary);
            grpSummary.Controls.Add(lblMainGroupSummary);
            grpSummary.Controls.Add(lblMainCCASummary);
            grpSummary.Controls.Add(lblMainStaffSummary);
            grpSummary.Controls.Add(lblMainStudentSummary);
            grpSummary.Dock = DockStyle.Fill;
            grpSummary.Location = new Point(23, 247);
            grpSummary.Name = "grpSummary";
            grpSummary.Size = new Size(900, 70);
            grpSummary.TabIndex = 9;
            grpSummary.TabStop = false;
            grpSummary.Text = "Data Summary";
            // 
            // lblMainClassSummary
            // 
            lblMainClassSummary.AutoSize = true;
            lblMainClassSummary.Location = new Point(10, 20);
            lblMainClassSummary.Name = "lblMainClassSummary";
            lblMainClassSummary.Size = new Size(141, 15);
            lblMainClassSummary.TabIndex = 0;
            lblMainClassSummary.Text = "Class: 0 items (0 selected)";
            // 
            // lblMainGroupSummary
            // 
            lblMainGroupSummary.AutoSize = true;
            lblMainGroupSummary.Location = new Point(200, 20);
            lblMainGroupSummary.Name = "lblMainGroupSummary";
            lblMainGroupSummary.Size = new Size(147, 15);
            lblMainGroupSummary.TabIndex = 1;
            lblMainGroupSummary.Text = "Group: 0 items (0 selected)";
            // 
            // lblMainCCASummary
            // 
            lblMainCCASummary.AutoSize = true;
            lblMainCCASummary.Location = new Point(400, 20);
            lblMainCCASummary.Name = "lblMainCCASummary";
            lblMainCCASummary.Size = new Size(138, 15);
            lblMainCCASummary.TabIndex = 2;
            lblMainCCASummary.Text = "CCA: 0 items (0 selected)";
            // 
            // lblMainStaffSummary
            // 
            lblMainStaffSummary.AutoSize = true;
            lblMainStaffSummary.Location = new Point(580, 20);
            lblMainStaffSummary.Name = "lblMainStaffSummary";
            lblMainStaffSummary.Size = new Size(138, 15);
            lblMainStaffSummary.TabIndex = 3;
            lblMainStaffSummary.Text = "Staff: 0 items (0 selected)";
            // 
            // lblMainStudentSummary
            // 
            lblMainStudentSummary.AutoSize = true;
            lblMainStudentSummary.Location = new Point(10, 40);
            lblMainStudentSummary.Name = "lblMainStudentSummary";
            lblMainStudentSummary.Size = new Size(155, 15);
            lblMainStudentSummary.TabIndex = 4;
            lblMainStudentSummary.Text = "Student: 0 items (0 selected)";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new Point(23, 320);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(30, 15);
            lblLog.TabIndex = 7;
            lblLog.Text = "Log:";
            // 
            // rtbLog
            // 
            mainLayout.SetColumnSpan(rtbLog, 3);
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Location = new Point(23, 549);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(900, 1);
            rtbLog.TabIndex = 8;
            rtbLog.Text = "";
            // 
            // tabClass
            // 
            tabClass.Controls.Add(classLayout);
            tabClass.Location = new Point(4, 24);
            tabClass.Name = "tabClass";
            tabClass.Padding = new Padding(3);
            tabClass.Size = new Size(192, 72);
            tabClass.TabIndex = 1;
            tabClass.Text = "Class";
            tabClass.UseVisualStyleBackColor = true;
            // 
            // classLayout
            // 
            classLayout.ColumnCount = 2;
            classLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            classLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            classLayout.Controls.Add(classTopPanel, 0, 0);
            classLayout.Controls.Add(clbClasses, 0, 1);
            classLayout.Dock = DockStyle.Fill;
            classLayout.Location = new Point(3, 3);
            classLayout.Name = "classLayout";
            classLayout.Padding = new Padding(10);
            classLayout.RowCount = 3;
            classLayout.RowStyles.Add(new RowStyle());
            classLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            classLayout.RowStyles.Add(new RowStyle());
            classLayout.Size = new Size(186, 66);
            classLayout.TabIndex = 0;
            // 
            // classTopPanel
            // 
            classTopPanel.AutoSize = true;
            classLayout.SetColumnSpan(classTopPanel, 2);
            classTopPanel.Controls.Add(btnGenerateClass);
            classTopPanel.Controls.Add(chkSelectAllClass);
            classTopPanel.Controls.Add(chkDeselectAllClass);
            classTopPanel.Controls.Add(lblOutputFolderClass);
            classTopPanel.Controls.Add(txtOutputFolderClass);
            classTopPanel.Controls.Add(btnBrowseOutputClass);
            classTopPanel.Controls.Add(lblClassFilenamePattern);
            classTopPanel.Controls.Add(cmbClassFilenamePattern);
            classTopPanel.Controls.Add(lblClassSummary);
            classTopPanel.Dock = DockStyle.Fill;
            classTopPanel.Location = new Point(13, 13);
            classTopPanel.Name = "classTopPanel";
            classTopPanel.Size = new Size(160, 138);
            classTopPanel.TabIndex = 0;
            // 
            // btnGenerateClass
            // 
            btnGenerateClass.AutoSize = true;
            btnGenerateClass.Location = new Point(3, 3);
            btnGenerateClass.Name = "btnGenerateClass";
            btnGenerateClass.Size = new Size(106, 25);
            btnGenerateClass.TabIndex = 0;
            btnGenerateClass.Text = "Generate Images";
            btnGenerateClass.UseVisualStyleBackColor = true;
            btnGenerateClass.Enabled = false;
            btnGenerateClass.Click += BtnGenerateClass_Click;
            // 
            // chkSelectAllClass
            // 
            chkSelectAllClass.AutoSize = true;
            chkSelectAllClass.Checked = true;
            chkSelectAllClass.CheckState = CheckState.Checked;
            chkSelectAllClass.Location = new Point(3, 34);
            chkSelectAllClass.Name = "chkSelectAllClass";
            chkSelectAllClass.Size = new Size(74, 19);
            chkSelectAllClass.TabIndex = 1;
            chkSelectAllClass.Text = "Select All";
            chkSelectAllClass.UseVisualStyleBackColor = true;
            chkSelectAllClass.Click += ChkSelectAllClass_Click;
            // 
            // chkDeselectAllClass
            // 
            chkDeselectAllClass.AutoSize = true;
            chkDeselectAllClass.Location = new Point(3, 59);
            chkDeselectAllClass.Name = "chkDeselectAllClass";
            chkDeselectAllClass.Size = new Size(87, 19);
            chkDeselectAllClass.TabIndex = 2;
            chkDeselectAllClass.Text = "Deselect All";
            chkDeselectAllClass.UseVisualStyleBackColor = true;
            chkDeselectAllClass.Click += ChkDeselectAllClass_Click;
            // 
            // lblOutputFolderClass
            // 
            lblOutputFolderClass.AutoSize = true;
            lblOutputFolderClass.Location = new Point(3, 81);
            lblOutputFolderClass.Name = "lblOutputFolderClass";
            lblOutputFolderClass.Padding = new Padding(0, 5, 0, 0);
            lblOutputFolderClass.Size = new Size(84, 20);
            lblOutputFolderClass.TabIndex = 3;
            lblOutputFolderClass.Text = "Output Folder:";
            // 
            // txtOutputFolderClass
            // 
            txtOutputFolderClass.Location = new Point(3, 104);
            txtOutputFolderClass.Name = "txtOutputFolderClass";
            txtOutputFolderClass.Size = new Size(300, 23);
            txtOutputFolderClass.TabIndex = 4;
            // 
            // btnBrowseOutputClass
            // 
            btnBrowseOutputClass.Location = new Point(3, 133);
            btnBrowseOutputClass.Name = "btnBrowseOutputClass";
            btnBrowseOutputClass.Size = new Size(30, 23);
            btnBrowseOutputClass.TabIndex = 5;
            btnBrowseOutputClass.Text = "...";
            btnBrowseOutputClass.UseVisualStyleBackColor = true;
            btnBrowseOutputClass.Click += BtnBrowseOutputClass_Click;
            classTopPanel.SetFlowBreak(btnBrowseOutputClass, true);
            // 
            // lblClassFilenamePattern
            // 
            lblClassFilenamePattern.AutoSize = true;
            lblClassFilenamePattern.Location = new Point(39, 130);
            lblClassFilenamePattern.Name = "lblClassFilenamePattern";
            lblClassFilenamePattern.Padding = new Padding(0, 5, 0, 0);
            lblClassFilenamePattern.Size = new Size(99, 20);
            lblClassFilenamePattern.TabIndex = 6;
            lblClassFilenamePattern.Text = "Filename Pattern:";
            // 
            // cmbClassFilenamePattern
            // 
            cmbClassFilenamePattern.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassFilenamePattern.FormattingEnabled = true;
            cmbClassFilenamePattern.Items.AddRange(new object[] { "{CLASS}{SEPA}{SEQNO}.{EXT}", "{SEQNO}{SEPA}{CLASS}.{EXT}", "{CLASS}{SEPA}{SEQNO3}.{EXT}", "{SEQNO3}{SEPA}{SHORTSCHOOL}{SEPA}{CLASS}.{EXT}", "IMG{SEPA}{CLASS}{SEPA}{SEQNO}.{EXT}" });
            cmbClassFilenamePattern.Location = new Point(3, 162);
            cmbClassFilenamePattern.Name = "cmbClassFilenamePattern";
            cmbClassFilenamePattern.Size = new Size(180, 23);
            cmbClassFilenamePattern.TabIndex = 7;
            cmbClassFilenamePattern.SelectedIndex = 3;
            classTopPanel.SetFlowBreak(cmbClassFilenamePattern, true);
            // 
            // lblClassSummary
            // 
            lblClassSummary.AutoSize = true;
            lblClassSummary.Location = new Point(3, 188);
            lblClassSummary.Name = "lblClassSummary";
            lblClassSummary.Padding = new Padding(0, 5, 0, 0);
            lblClassSummary.Size = new Size(107, 20);
            lblClassSummary.TabIndex = 6;
            lblClassSummary.Text = "Total: 0, Selected: 0";
            // 
            // clbClasses
            // 
            clbClasses.CheckOnClick = true;
            clbClasses.Dock = DockStyle.Fill;
            clbClasses.FormattingEnabled = true;
            clbClasses.Location = new Point(13, 157);
            clbClasses.Name = "clbClasses";
            clbClasses.Size = new Size(77, 1);
            clbClasses.TabIndex = 1;
            // 
            // tabGroup
            // 
            tabGroup.Controls.Add(groupLayout);
            tabGroup.Location = new Point(4, 24);
            tabGroup.Name = "tabGroup";
            tabGroup.Padding = new Padding(3);
            tabGroup.Size = new Size(192, 72);
            tabGroup.TabIndex = 2;
            tabGroup.Text = "Group";
            tabGroup.UseVisualStyleBackColor = true;
            // 
            // groupLayout
            // 
            groupLayout.ColumnCount = 2;
            groupLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            groupLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            groupLayout.Controls.Add(groupTopPanel, 0, 0);
            groupLayout.Controls.Add(clbGroups, 0, 1);
            groupLayout.Dock = DockStyle.Fill;
            groupLayout.Location = new Point(3, 3);
            groupLayout.Name = "groupLayout";
            groupLayout.Padding = new Padding(10);
            groupLayout.RowCount = 3;
            groupLayout.RowStyles.Add(new RowStyle());
            groupLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            groupLayout.RowStyles.Add(new RowStyle());
            groupLayout.Size = new Size(186, 66);
            groupLayout.TabIndex = 0;
            // 
            // groupTopPanel
            // 
            groupTopPanel.AutoSize = true;
            groupLayout.SetColumnSpan(groupTopPanel, 2);
            groupTopPanel.Controls.Add(btnGenerateGroup);
            groupTopPanel.Controls.Add(chkSelectAllGroup);
            groupTopPanel.Controls.Add(chkDeselectAllGroup);
            groupTopPanel.Controls.Add(lblOutputFolderGroup);
            groupTopPanel.Controls.Add(txtOutputFolderGroup);
            groupTopPanel.Controls.Add(btnBrowseOutputGroup);
            groupTopPanel.Controls.Add(lblGroupFilenamePattern);
            groupTopPanel.Controls.Add(cmbGroupFilenamePattern);
            groupTopPanel.Controls.Add(lblGroupSummary);
            groupTopPanel.Dock = DockStyle.Fill;
            groupTopPanel.Location = new Point(13, 13);
            groupTopPanel.Name = "groupTopPanel";
            groupTopPanel.Size = new Size(160, 109);
            groupTopPanel.TabIndex = 0;
            // 
            // btnGenerateGroup
            // 
            btnGenerateGroup.AutoSize = true;
            btnGenerateGroup.Location = new Point(3, 3);
            btnGenerateGroup.Name = "btnGenerateGroup";
            btnGenerateGroup.Size = new Size(106, 25);
            btnGenerateGroup.TabIndex = 0;
            btnGenerateGroup.Text = "Generate Images";
            btnGenerateGroup.UseVisualStyleBackColor = true;
            btnGenerateGroup.Enabled = false;
            btnGenerateGroup.Click += BtnGenerateGroup_Click;
            // 
            // chkSelectAllGroup
            // 
            chkSelectAllGroup.AutoSize = true;
            chkSelectAllGroup.Checked = true;
            chkSelectAllGroup.CheckState = CheckState.Checked;
            chkSelectAllGroup.Location = new Point(3, 34);
            chkSelectAllGroup.Name = "chkSelectAllGroup";
            chkSelectAllGroup.Size = new Size(74, 19);
            chkSelectAllGroup.TabIndex = 1;
            chkSelectAllGroup.Text = "Select All";
            chkSelectAllGroup.UseVisualStyleBackColor = true;
            chkSelectAllGroup.Click += ChkSelectAllGroup_Click;
            // 
            // chkDeselectAllGroup
            // 
            chkDeselectAllGroup.AutoSize = true;
            chkDeselectAllGroup.Location = new Point(3, 59);
            chkDeselectAllGroup.Name = "chkDeselectAllGroup";
            chkDeselectAllGroup.Size = new Size(87, 19);
            chkDeselectAllGroup.TabIndex = 2;
            chkDeselectAllGroup.Text = "Deselect All";
            chkDeselectAllGroup.UseVisualStyleBackColor = true;
            chkDeselectAllGroup.Click += ChkDeselectAllGroup_Click;
            // 
            // lblOutputFolderGroup
            // 
            lblOutputFolderGroup.AutoSize = true;
            lblOutputFolderGroup.Location = new Point(3, 81);
            lblOutputFolderGroup.Name = "lblOutputFolderGroup";
            lblOutputFolderGroup.Padding = new Padding(0, 5, 0, 0);
            lblOutputFolderGroup.Size = new Size(84, 20);
            lblOutputFolderGroup.TabIndex = 3;
            lblOutputFolderGroup.Text = "Output Folder:";
            // 
            // txtOutputFolderGroup
            // 
            txtOutputFolderGroup.Location = new Point(3, 104);
            txtOutputFolderGroup.Name = "txtOutputFolderGroup";
            txtOutputFolderGroup.Size = new Size(300, 23);
            txtOutputFolderGroup.TabIndex = 4;
            // 
            // btnBrowseOutputGroup
            // 
            btnBrowseOutputGroup.Location = new Point(3, 133);
            btnBrowseOutputGroup.Name = "btnBrowseOutputGroup";
            btnBrowseOutputGroup.Size = new Size(30, 23);
            btnBrowseOutputGroup.TabIndex = 5;
            btnBrowseOutputGroup.Text = "...";
            btnBrowseOutputGroup.UseVisualStyleBackColor = true;
            btnBrowseOutputGroup.Click += BtnBrowseOutputGroup_Click;
            // 
            // lblGroupFilenamePattern
            // 
            lblGroupFilenamePattern.AutoSize = true;
            lblGroupFilenamePattern.Location = new Point(39, 130);
            lblGroupFilenamePattern.Name = "lblGroupFilenamePattern";
            lblGroupFilenamePattern.Padding = new Padding(0, 5, 0, 0);
            lblGroupFilenamePattern.Size = new Size(106, 20);
            lblGroupFilenamePattern.TabIndex = 6;
            lblGroupFilenamePattern.Text = "Filename Pattern:";
            // 
            // cmbGroupFilenamePattern
            // 
            cmbGroupFilenamePattern.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGroupFilenamePattern.FormattingEnabled = true;
            cmbGroupFilenamePattern.Items.AddRange(new object[] {"{GROUP}{SEPA}{SEQNO}.{EXT}","{GROUP}{SEPA}{SEQNO3}.{EXT}"});
            cmbGroupFilenamePattern.Location = new Point(151, 128);
            cmbGroupFilenamePattern.Name = "cmbGroupFilenamePattern";
            cmbGroupFilenamePattern.Size = new Size(180, 23);
            cmbGroupFilenamePattern.TabIndex = 7;
            cmbGroupFilenamePattern.SelectedIndex = 0;
            // 
            // lblGroupSummary
            // 
            lblGroupSummary.AutoSize = true;
            lblGroupSummary.Location = new Point(39, 130);
            lblGroupSummary.Name = "lblGroupSummary";
            lblGroupSummary.Padding = new Padding(0, 5, 0, 0);
            lblGroupSummary.Size = new Size(107, 20);
            lblGroupSummary.TabIndex = 6;
            lblGroupSummary.Text = "Total: 0, Selected: 0";
            // 
            // clbGroups
            // 
            clbGroups.CheckOnClick = true;
            groupLayout.SetColumnSpan(clbGroups, 2);
            clbGroups.Dock = DockStyle.Fill;
            clbGroups.FormattingEnabled = true;
            clbGroups.Location = new Point(13, 128);
            clbGroups.Name = "clbGroups";
            clbGroups.Size = new Size(160, 1);
            clbGroups.TabIndex = 1;
            // 
            // tabStudent
            // 
            tabStudent.Controls.Add(_studentControl);
            _studentControl.GenerateRequested += StudentControl_GenerateRequested;
            tabStudent.Location = new Point(4, 24);
            tabStudent.Name = "tabStudent";
            tabStudent.Size = new Size(192, 72);
            tabStudent.TabIndex = 3;
            tabStudent.Text = "Student";
            tabStudent.UseVisualStyleBackColor = true;
            // 
            // _studentControl
            // 
            _studentControl.Dock = DockStyle.Fill;
            _studentControl.Location = new Point(0, 0);
            _studentControl.Name = "_studentControl";
            _studentControl.Size = new Size(192, 72);
            _studentControl.TabIndex = 0;
            _studentControl.SelectionChanged += StudentControl_SelectionChanged;
            // 
            // tabStaff
            // 
            tabStaff.Controls.Add(_staffControl);
            _staffControl.GenerateRequested += StaffControl_GenerateRequested;
            _staffControl.SelectionChanged += StaffControl_SelectionChanged;
            tabStaff.Location = new Point(4, 24);
            tabStaff.Name = "tabStaff";
            tabStaff.Size = new Size(192, 72);
            tabStaff.TabIndex = 4;
            tabStaff.Text = "Staff";
            tabStaff.UseVisualStyleBackColor = true;
            // 
            // _staffControl
            // 
            _staffControl.Dock = DockStyle.Fill;
            _staffControl.Location = new Point(0, 0);
            _staffControl.Name = "_staffControl";
            _staffControl.Size = new Size(192, 72);
            _staffControl.TabIndex = 0;
            // 
            // tabCCA
            // 
            tabCCA.Controls.Add(ccaLayout);
            tabCCA.Location = new Point(4, 24);
            tabCCA.Name = "tabCCA";
            tabCCA.Padding = new Padding(3);
            tabCCA.Size = new Size(192, 72);
            tabCCA.TabIndex = 5;
            tabCCA.Text = "CCA";
            tabCCA.UseVisualStyleBackColor = true;
            // 
            // ccaLayout
            // 
            ccaLayout.ColumnCount = 2;
            ccaLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ccaLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ccaLayout.Controls.Add(ccaTopPanel, 0, 0);
            ccaLayout.Controls.Add(clbCCAs, 0, 1);
            ccaLayout.Dock = DockStyle.Fill;
            ccaLayout.Location = new Point(3, 3);
            ccaLayout.Name = "ccaLayout";
            ccaLayout.Padding = new Padding(10);
            ccaLayout.RowCount = 3;
            ccaLayout.RowStyles.Add(new RowStyle());
            ccaLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ccaLayout.RowStyles.Add(new RowStyle());
            ccaLayout.Size = new Size(186, 66);
            ccaLayout.TabIndex = 0;
            // 
            // ccaTopPanel
            // 
            ccaTopPanel.AutoSize = true;
            ccaLayout.SetColumnSpan(ccaTopPanel, 2);
            ccaTopPanel.Controls.Add(btnGenerateCCA);
            ccaTopPanel.Controls.Add(chkSelectAllCCA);
            ccaTopPanel.Controls.Add(chkDeselectAllCCA);
            ccaTopPanel.Controls.Add(lblOutputFolderCCA);
            ccaTopPanel.Controls.Add(txtOutputFolderCCA);
            ccaTopPanel.Controls.Add(btnBrowseOutputCCA);
            ccaTopPanel.Controls.Add(lblCCAFilenamePattern);
            ccaTopPanel.Controls.Add(cmbCCAFilenamePattern);
            ccaTopPanel.Controls.Add(lblCCASummary);
            ccaTopPanel.Dock = DockStyle.Fill;
            ccaTopPanel.Location = new Point(13, 13);
            ccaTopPanel.Name = "ccaTopPanel";
            ccaTopPanel.Size = new Size(160, 109);
            ccaTopPanel.TabIndex = 0;
            // 
            // btnGenerateCCA
            // 
            btnGenerateCCA.AutoSize = true;
            btnGenerateCCA.Location = new Point(3, 3);
            btnGenerateCCA.Name = "btnGenerateCCA";
            btnGenerateCCA.Size = new Size(106, 25);
            btnGenerateCCA.TabIndex = 0;
            btnGenerateCCA.Text = "Generate Images";
            btnGenerateCCA.UseVisualStyleBackColor = true;
            btnGenerateCCA.Enabled = false;
            btnGenerateCCA.Click += BtnGenerateCCA_Click;
            // 
            // chkSelectAllCCA
            // 
            chkSelectAllCCA.AutoSize = true;
            chkSelectAllCCA.Checked = true;
            chkSelectAllCCA.CheckState = CheckState.Checked;
            chkSelectAllCCA.Location = new Point(3, 34);
            chkSelectAllCCA.Name = "chkSelectAllCCA";
            chkSelectAllCCA.Size = new Size(74, 19);
            chkSelectAllCCA.TabIndex = 1;
            chkSelectAllCCA.Text = "Select All";
            chkSelectAllCCA.UseVisualStyleBackColor = true;
            chkSelectAllCCA.Click += ChkSelectAllCCA_Click;
            // 
            // chkDeselectAllCCA
            // 
            chkDeselectAllCCA.AutoSize = true;
            chkDeselectAllCCA.Location = new Point(3, 59);
            chkDeselectAllCCA.Name = "chkDeselectAllCCA";
            chkDeselectAllCCA.Size = new Size(87, 19);
            chkDeselectAllCCA.TabIndex = 2;
            chkDeselectAllCCA.Text = "Deselect All";
            chkDeselectAllCCA.UseVisualStyleBackColor = true;
            chkDeselectAllCCA.Click += ChkDeselectAllCCA_Click;
            // 
            // lblOutputFolderCCA
            // 
            lblOutputFolderCCA.AutoSize = true;
            lblOutputFolderCCA.Location = new Point(3, 81);
            lblOutputFolderCCA.Name = "lblOutputFolderCCA";
            lblOutputFolderCCA.Padding = new Padding(0, 5, 0, 0);
            lblOutputFolderCCA.Size = new Size(84, 20);
            lblOutputFolderCCA.TabIndex = 3;
            lblOutputFolderCCA.Text = "Output Folder:";
            // 
            // txtOutputFolderCCA
            // 
            txtOutputFolderCCA.Location = new Point(3, 104);
            txtOutputFolderCCA.Name = "txtOutputFolderCCA";
            txtOutputFolderCCA.Size = new Size(300, 23);
            txtOutputFolderCCA.TabIndex = 4;
            // 
            // btnBrowseOutputCCA
            // 
            btnBrowseOutputCCA.Location = new Point(3, 133);
            btnBrowseOutputCCA.Name = "btnBrowseOutputCCA";
            btnBrowseOutputCCA.Size = new Size(30, 23);
            btnBrowseOutputCCA.TabIndex = 5;
            btnBrowseOutputCCA.Text = "...";
            btnBrowseOutputCCA.UseVisualStyleBackColor = true;
            btnBrowseOutputCCA.Click += BtnBrowseOutputCCA_Click;
            // 
            // lblCCAFilenamePattern
            // 
            lblCCAFilenamePattern.AutoSize = true;
            lblCCAFilenamePattern.Location = new Point(39, 130);
            lblCCAFilenamePattern.Name = "lblCCAFilenamePattern";
            lblCCAFilenamePattern.Padding = new Padding(0, 5, 0, 0);
            lblCCAFilenamePattern.Size = new Size(106, 20);
            lblCCAFilenamePattern.TabIndex = 6;
            lblCCAFilenamePattern.Text = "Filename Pattern:";
            // 
            // cmbCCAFilenamePattern
            // 
            cmbCCAFilenamePattern.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCCAFilenamePattern.FormattingEnabled = true;
            cmbCCAFilenamePattern.Items.AddRange(new object[] {"{CCA}{SEPA}{SEQNO}.{EXT}","{CCA}{SEPA}{SEQNO3}.{EXT}"});
            cmbCCAFilenamePattern.Location = new Point(151, 128);
            cmbCCAFilenamePattern.Name = "cmbCCAFilenamePattern";
            cmbCCAFilenamePattern.Size = new Size(180, 23);
            cmbCCAFilenamePattern.TabIndex = 7;
            cmbCCAFilenamePattern.SelectedIndex = 0;
            // 
            // lblCCASummary
            // 
            lblCCASummary.AutoSize = true;
            lblCCASummary.Location = new Point(39, 130);
            lblCCASummary.Name = "lblCCASummary";
            lblCCASummary.Padding = new Padding(0, 5, 0, 0);
            lblCCASummary.Size = new Size(107, 20);
            lblCCASummary.TabIndex = 6;
            lblCCASummary.Text = "Total: 0, Selected: 0";
            // 
            // clbCCAs
            // 
            clbCCAs.CheckOnClick = true;
            ccaLayout.SetColumnSpan(clbCCAs, 2);
            clbCCAs.Dock = DockStyle.Fill;
            clbCCAs.FormattingEnabled = true;
            clbCCAs.Location = new Point(13, 128);
            clbCCAs.Name = "clbCCAs";
            clbCCAs.Size = new Size(160, 1);
            clbCCAs.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 600);
            Controls.Add(tabControl);
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel });
            statusLabel.Text = "Ready.";
            Controls.Add(statusStrip);
            Name = "MainForm";
            Text = "Excel to Image Converter";
            tabControl.ResumeLayout(false);
            tabMain.ResumeLayout(false);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            grpSummary.ResumeLayout(false);
            grpSummary.PerformLayout();
            tabClass.ResumeLayout(false);
            classLayout.ResumeLayout(false);
            classLayout.PerformLayout();
            classTopPanel.ResumeLayout(false);
            classTopPanel.PerformLayout();
            tabGroup.ResumeLayout(false);
            groupLayout.ResumeLayout(false);
            groupLayout.PerformLayout();
            groupTopPanel.ResumeLayout(false);
            groupTopPanel.PerformLayout();
            tabStudent.ResumeLayout(false);
            tabStaff.ResumeLayout(false);
            tabCCA.ResumeLayout(false);
            ccaLayout.ResumeLayout(false);
            ccaLayout.PerformLayout();
            ccaTopPanel.ResumeLayout(false);
            ccaTopPanel.PerformLayout();
            ResumeLayout(false);

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
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Label lblMainGroupSummary;
        private System.Windows.Forms.Label lblMainCCASummary;

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
        private System.Windows.Forms.Label lblGroupFilenamePattern;
        private System.Windows.Forms.ComboBox cmbGroupFilenamePattern;
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

        // CCA Tab Controls
        private System.Windows.Forms.TableLayoutPanel ccaLayout;
        private System.Windows.Forms.FlowLayoutPanel ccaTopPanel;
        private System.Windows.Forms.Button btnGenerateCCA;
        private System.Windows.Forms.CheckBox chkSelectAllCCA;
        private System.Windows.Forms.CheckBox chkDeselectAllCCA;
        private System.Windows.Forms.Label lblOutputFolderCCA;
        private System.Windows.Forms.TextBox txtOutputFolderCCA;
        private System.Windows.Forms.Button btnBrowseOutputCCA;
        private System.Windows.Forms.Label lblCCASummary;
        private System.Windows.Forms.CheckedListBox clbCCAs;
        private System.Windows.Forms.Label lblCCAFilenamePattern;
        private System.Windows.Forms.ComboBox cmbCCAFilenamePattern;
        private System.Windows.Forms.Label lblMainStaffSummary;
        private System.Windows.Forms.Label lblMainStudentSummary;
        private ExcelToImageApp.Controls.StaffControl _staffControl;
        private ExcelToImageApp.Controls.StudentControl _studentControl;
        private System.Windows.Forms.Label lblReferenceSubfolder;
        private System.Windows.Forms.TextBox txtReferenceSubfolder;
        private System.Windows.Forms.CheckBox chkCopyToAll;
        private System.Windows.Forms.Label lblClassFilenamePattern;
        private System.Windows.Forms.ComboBox cmbClassFilenamePattern;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.ComboBox cmbSeparator;
        private System.Windows.Forms.CheckBox chkUppercase;
        private System.Windows.Forms.Label lblSchoolName;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.Label lblSchoolShortName;
        private System.Windows.Forms.TextBox txtSchoolShortName;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}
