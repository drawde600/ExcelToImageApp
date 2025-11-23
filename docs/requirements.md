# Requirements Specification: Excel to Image Converter

## 1. Overview
The goal is to develop a C# Windows Forms (WinForms) application that reads data from a specific Excel file (`SampleData.xlsx`) and generates images based on that data. The application supports multiple data types, each with its own processing logic and output settings.

## 2. Input Data
- **Source**: An Excel file (`.xlsx`).
- **Sheets**: The application expects the following sheets:
    - **Class**: Contains class names.
    - **Group**: Contains group names.
    - **Student**: Contains student details (Pending).
    - **Staff**: Contains staff details (Pending).
    - **CCA**: Contains Co-Curricular Activity details (Pending).
- **Data Structure**: Generally, the first row is a header, and subsequent rows contain data.

## 3. User Interface (UI)
The application features a **TabControl** layout with the following tabs:

### 3.1. Main Tab
- **Excel File Selection**:
    - Textbox showing the selected file path.
    - "Browse" button to select the file.
    - Double-clicking the textbox also opens the file browser.
- **Base Folder Selection**:
    - Textbox showing the base output directory.
    - "Browse" button to select the folder.
    - Defaults to the directory of the selected Excel file.
- **Actions**:
    - **Load Data**: Reads the Excel file and populates the other tabs.
    - **Generate All**: Triggers the generation process for all active tabs (Class, Group, etc.).
- **Summary**:
    - Displays a summary of loaded items (Total / Selected) for each data type (Class, Group).
- **Log**:
    - A rich text box displaying status messages, errors, and progress.

### 3.2. Data Tabs (Class, Group, etc.)
Each data type (Class, Group, Student, Staff, CCA) has its own tab with consistent functionality:
- **Selection List**:
    - A `CheckedListBox` displaying the items loaded from Excel.
    - Items are **checked by default**.
- **Selection Controls**:
    - "Select All" button/checkbox.
    - "Deselect All" button/checkbox.
- **Output Configuration**:
    - "Output Folder" textbox.
    - "Browse" button for the output folder.
    - **Default Path**: `[Base Folder]\[Data Type]` (e.g., `...\Class`, `...\Group`).
- **Action**:
    - "Generate Images" button (specific to that tab).
- **Summary**:
    - Displays "Total items" and "Selected items" count specific to that tab.

## 4. Functional Requirements
- **Data Loading**:
    - Must validate the Excel file path.
    - Must handle missing sheets gracefully (log warning).
    - Must populate the respective tabs with data from the Excel sheets.
- **Image Generation**:
    - **Current Status**: Logic is stubbed (shows "Not yet supported" message).
    - **Future Goal**: Generate an image for each selected item using a predefined template/layout.
    - Images should be saved to the specified Output Folder.
- **Configuration Persistence**:
    - (Optional) Save last used paths for convenience.

## 5. Technical Constraints
- **Framework**: .NET 9.0 (Windows Forms).
- **Language**: C#.
- **Libraries**:
    - `ClosedXML` for Excel file handling.
- **OS**: Windows.

## 6. Future Scope
- Implement actual image rendering logic.
- Implement tabs for Student, Staff, and CCA.
- Add progress bars for generation.
- Allow customization of image templates.
