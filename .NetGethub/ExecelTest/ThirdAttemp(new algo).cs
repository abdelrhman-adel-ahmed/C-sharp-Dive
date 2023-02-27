using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecelTest
{
    public class ThirdAttemp_new_algo
    {
        public static string filepath = @"./test.xlsx";
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
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

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

        public static void InsertTextIntoExistingExcel(string docName, Data data, string cellName = " ", UInt32 cellNumber = 0)
        {
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.WorksheetParts.First();
                bool newRow = true;
                foreach (var item in data.GetType().GetProperties())
                {
                    Cell cell = InsertCellInWorksheet(worksheetPart, newRow);

                    cell.CellValue = new CellValue(item.GetValue(data).ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);

                    worksheetPart.Worksheet.Save();

                    newRow = false;
                }
            }
        }
        public static void InsertTextIntoExistingExcel(string docName, DataHeaders data, string cellName = " ", UInt32 cellNumber = 0)
        {
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.WorksheetParts.First();
                bool newRow = true;
                foreach (var item in data.GetType().GetProperties())
                {
                    Cell cell = InsertCellInWorksheet(worksheetPart, newRow);

                    cell.CellValue = new CellValue(item.GetValue(data).ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                   worksheetPart.Worksheet.Save();

                    newRow = false;
                }
            }
        }
        private static Cell InsertCellInWorksheet(WorksheetPart worksheetPart, bool newRow = false, string columnName = "", uint rowIndex = 0)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();

            Row row;
            if (worksheet.Descendants<Row>().LastOrDefault() != null && !newRow)
            {
                row = worksheet.Descendants<Row>().LastOrDefault();
            }
            else
            {
                row = new Row();
                sheetData.Append(row);

            }

            // get the last cell in the row , to insert the new cell after it
            Cell refCell = row?.Descendants<Cell>().LastOrDefault();

            // does provide CellReference 
            Cell newCell = new Cell();
            row.InsertAfter(newCell, refCell);

            worksheet.Save();
            return newCell;

        }

        public static void InsertDataList(List<Data> dataList)
        {
            SetTitles(filepath);
            foreach (var data in dataList)
            {
                InsertTextIntoExistingExcel(filepath, data);
            }

        }
        public static void SetTitles(string filepath)
        {
            InsertTextIntoExistingExcel(filepath, new DataHeaders());
        }

    }
}