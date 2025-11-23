# Excel to Image Converter Plan

## Goal Description
Create a C# WinForms application that reads data from an Excel file (`SampleData.xlsx`) and generates an image for each row of data.

## User Review Required
> [!IMPORTANT]
> **Excel Sheets**: I will look for sheets named "Class", "Group", "Student", "Staff", "CCA". If they are missing, the app will log a warning.
> **Image Design**: I will use a standard "ID Card" style layout for all types initially.

## Proposed Changes

### Project Structure
`C:\Users\drawd\TestData\ExcelToImageApp\`

#### [NEW] ExcelToImageApp (WinForms Project)
- **MainForm.cs**:
    - `TabControl` with 6 tabs (Main, Class, Group, Student, Staff, CCA).
    - **Main Tab**:
        - `txtFilePath` (Double-click opens `OpenFileDialog`).
        - `txtBaseFolder` + `btnBrowseBase`: Defaults to Excel file's directory upon load.
        - `btnLoad`: Loads data from Excel.
        - `btnGenerateAll`: Triggers generation for all active tabs.
        - `rtbLog`: Displays logs.
        - `grpSummary`: Displays summary counts for Class and Group.
    - **Class Tab**:
        - `btnGenerateClass` (Top Left).
        - `txtOutputFolderClass` + `btnBrowseOutputClass`: Defaults to `Path.Combine(BaseDir, "Class")`.
        - `chkSelectAllClass`, `chkDeselectAllClass`.
        - `clbClasses` (CheckedListBox): Populated with Class names, **all checked by default**.
    - **Group Tab**:
        - `btnGenerateGroup`.
        - `txtOutputFolderGroup` + `btnBrowseOutputGroup`: Defaults to `Path.Combine(BaseDir, "Group")`.
        - `chkSelectAllGroup`, `chkDeselectAllGroup`.
        - `clbGroups` (CheckedListBox): Populated with Group names.
    - **Other Tabs**: Placeholder tabs for now.
- **Models/**:
    - `ClassModel`: Represents a Class.
    - `GroupModel`: Represents a Group.
- **Services/ExcelService.cs**:
    - `LoadClassData(string filePath)`: Reads "Class" sheet.
    - `LoadGroupData(string filePath)`: Reads "Group" sheet.
- **Services/ImageGenerator.cs**: **DEFERRED**. `Generate` button will show `MessageBox.Show("Not yet supported")`.

### Dependencies
- `ClosedXML`

## Verification Plan

### Manual Verification
1.  **Load**: Ensure Class and Group data populates the respective checklists.
2.  **Generate**: Click generate on "Class" and "Group" tabs, verify message box appears.
3.  **Generate All**: Click "Generate All" on Main tab, verify it triggers both Class and Group generation messages.
4.  **Summary**: Verify summary labels on Main tab update correctly when items are checked/unchecked.
