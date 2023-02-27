using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Linq;
using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Drawing;

namespace ExecelTest
{
    public class FirstAttemp
    {
        public static string filepath = @"./test.xlsx";
        public static string[] alpha = { "", "A", "B", "C", "D", "E" };
        public static void CreateExcelFile(string filepath, string sheetName)
        {
            // Create a spreadsheet document by supplying the filepath.
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(
                filepath,
                SpreadsheetDocumentType.Workbook
            );
            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
            AppendChild<Sheets>(new Sheets());
            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = sheetName
            };
            sheets.Append(sheet);
            //Save & close
            workbookpart.Workbook.Save();
            spreadsheetDocument.Close();
        }
        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            Row row;
            if (sheetData.Elements<Row>().Any(r => r.RowIndex == rowIndex))
            {
                row = sheetData.Elements<Row>().First(r => r.RowIndex == rowIndex);
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            Cell refCell = row.Descendants<Cell>().LastOrDefault();

            Cell newCell = new Cell() { CellReference = cellReference };
            row.InsertAfter(newCell, refCell);

            worksheet.Save();
            return newCell;

        }
        public static void InsertTextExistingExcel(string docName, string text, string cellName, UInt32 cellNumber)
        {
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.WorksheetParts.First();
                Cell cell = InsertCellInWorksheet(cellName, cellNumber, worksheetPart);

                cell.CellValue = new CellValue(text);
                cell.DataType = new EnumValue<CellValues>(CellValues.String);

                worksheetPart.Worksheet.Save();
            }
        }
        public static void InsertDate(Data data, UInt32 rowNum)
        {
            int index = 1;
            foreach (var prop in data.GetType().GetProperties())
            {
                InsertTextExistingExcel(filepath, prop.GetValue(data).ToString(), alpha[index], rowNum);
                index++;
            }
        }
        public static void InsertDate(List<Data> dataList)
        {
            UInt32 rowNum = 1;
            foreach (var data in dataList)
            {
                InsertDate(data, rowNum);
                rowNum++;
            }
        }
    }
}