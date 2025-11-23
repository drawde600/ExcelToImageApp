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
    }
}
