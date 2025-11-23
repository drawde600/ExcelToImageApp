using ClosedXML.Excel;
using ExcelToImageApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExcelToImageApp.Services
{
    public class ExcelService
    {
        public List<ClassModel> LoadClassData(string filePath)
        {
            var results = new List<ClassModel>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Excel file not found.", filePath);
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                if (!workbook.Worksheets.TryGetWorksheet("Class", out var worksheet))
                {
                    // Fallback: Try getting the first worksheet if "Class" doesn't exist, 
                    // or just return empty/throw. For now, let's be strict or log.
                    // Let's try to find a sheet that *contains* "Class" or just use the first one if user didn't specify?
                    // Requirement said "sheet 'class'". I will stick to that.
                    throw new Exception("Worksheet 'Class' not found in the Excel file.");
                }

                // Assume header is in row 1, data starts row 2
                var range = worksheet.RangeUsed();
                if (range == null)
                {
                    return results;
                }
                var rows = range.RowsUsed().Skip(1); // Skip header

                foreach (var row in rows)
                {
                    // Column 1 is Class Name
                    var className = row.Cell(1).GetValue<string>();
                    if (!string.IsNullOrWhiteSpace(className))
                    {
                        results.Add(new ClassModel { ClassName = className });
                    }
                }
            }

            return results;
        }

        public List<GroupModel> LoadGroupData(string filePath)
        {
            var results = new List<GroupModel>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Excel file not found.", filePath);
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                if (!workbook.Worksheets.TryGetWorksheet("Group", out var worksheet))
                {
                    // If Group sheet missing, return empty list or throw? 
                    // Let's return empty list to be safe, or throw if strict.
                    // Based on previous logic, let's throw to alert user.
                    throw new Exception("Worksheet 'Group' not found in the Excel file.");
                }

                var range = worksheet.RangeUsed();
                if (range == null) return results;

                var rows = range.RowsUsed().Skip(1); // Skip header

                foreach (var row in rows)
                {
                    var groupName = row.Cell(1).GetValue<string>();
                    if (!string.IsNullOrWhiteSpace(groupName))
                    {
                        results.Add(new GroupModel { GroupName = groupName });
                    }
                }
            }

            return results;
        }

        public List<StudentModel> LoadStudentData(string filePath)
        {
            var results = new List<StudentModel>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Excel file not found.", filePath);
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                if (!workbook.Worksheets.TryGetWorksheet("Students", out var worksheet))
                {
                    throw new Exception("Worksheet 'Students' not found in the Excel file.");
                }

                var range = worksheet.RangeUsed();
                if (range == null) return results;

                // Identify headers (case-insensitive): NAME, INDEX NO, CLASS
                var headerRow = range.FirstRow();
                int? nameCol = null;
                int? indexCol = null;
                int? classCol = null;

                foreach (var cell in headerRow.CellsUsed())
                {
                    var header = (cell.GetValue<string>() ?? string.Empty).Trim();
                    if (header.Equals("NAME", StringComparison.OrdinalIgnoreCase))
                        nameCol = cell.Address.ColumnNumber;
                    else if (header.Equals("INDEX NO", StringComparison.OrdinalIgnoreCase))
                        indexCol = cell.Address.ColumnNumber;
                    else if (header.Equals("CLASS", StringComparison.OrdinalIgnoreCase))
                        classCol = cell.Address.ColumnNumber;
                }

                if (!nameCol.HasValue || !indexCol.HasValue || !classCol.HasValue)
                {
                    throw new Exception("Worksheet 'Students' missing required headers. Expected: NAME, INDEX NO, CLASS.");
                }

                var rows = range.RowsUsed().Skip(1); // Skip header

                foreach (var row in rows)
                {
                    var name = row.Cell(nameCol.Value).GetValue<string>();
                    var index = row.Cell(indexCol.Value).GetValue<string>();
                    var cls = row.Cell(classCol.Value).GetValue<string>();
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        results.Add(new StudentModel
                        {
                            StudentName = name?.Trim() ?? string.Empty,
                            IndexNo = index?.Trim() ?? string.Empty,
                            ClassName = cls?.Trim() ?? string.Empty
                        });
                    }
                }
            }

            return results;
        }

        public List<StaffModel> LoadStaffData(string filePath)
        {
            var results = new List<StaffModel>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Excel file not found.", filePath);
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                if (!workbook.Worksheets.TryGetWorksheet("Staff", out var worksheet))
                {
                    throw new Exception("Worksheet 'Staff' not found in the Excel file.");
                }

                var range = worksheet.RangeUsed();
                if (range == null) return results;

                // Identify column indices by header names (case-insensitive): NAME and POST
                var headerRow = range.FirstRow();
                int? nameCol = null;
                int? postCol = null;

                foreach (var cell in headerRow.CellsUsed())
                {
                    var header = (cell.GetValue<string>() ?? string.Empty).Trim();
                    if (header.Equals("NAME", StringComparison.OrdinalIgnoreCase))
                    {
                        nameCol = cell.Address.ColumnNumber;
                    }
                    else if (header.Equals("POST", StringComparison.OrdinalIgnoreCase))
                    {
                        postCol = cell.Address.ColumnNumber;
                    }
                }

                if (!nameCol.HasValue)
                {
                    throw new Exception("Worksheet 'Staff' missing required column header 'NAME'.");
                }

                var rows = range.RowsUsed().Skip(1); // Skip header

                foreach (var row in rows)
                {
                    var staffName = row.Cell(nameCol.Value).GetValue<string>();
                    var position = postCol.HasValue ? row.Cell(postCol.Value).GetValue<string>() : string.Empty;
                    if (!string.IsNullOrWhiteSpace(staffName))
                    {
                        results.Add(new StaffModel
                        {
                            StaffName = staffName?.Trim() ?? string.Empty,
                            Position = position?.Trim() ?? string.Empty
                        });
                    }
                }
            }

            return results;
        }

        public List<CCAModel> LoadCCAData(string filePath)
        {
            var results = new List<CCAModel>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Excel file not found.", filePath);
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                if (!workbook.Worksheets.TryGetWorksheet("CCA", out var worksheet))
                {
                    throw new Exception("Worksheet 'CCA' not found in the Excel file.");
                }

                var range = worksheet.RangeUsed();
                if (range == null) return results;

                var rows = range.RowsUsed().Skip(1); // Skip header

                foreach (var row in rows)
                {
                    var ccaName = row.Cell(1).GetValue<string>();
                    if (!string.IsNullOrWhiteSpace(ccaName))
                    {
                        results.Add(new CCAModel { CCAName = ccaName });
                    }
                }
            }

            return results;
        }
    }
}
