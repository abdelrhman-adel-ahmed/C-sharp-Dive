using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExecelTest
{
    public  class SecondAttemp
    {
        public static string filepath = @"./test.xlsx";
        public static string[] alpha = new string[] { "", "A", "B", "C", "D", "E" };
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

        public static void InsertTextIntoExistingExcel(string docName, string text, string cellName, UInt32 cellNumber)
        {
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                //get the first worksheet in the workbook
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.WorksheetParts.First();
                Cell cell = InsertCellInWorksheet(cellName, cellNumber, worksheetPart);

                cell.CellValue = new CellValue(text);
                cell.DataType = new EnumValue<CellValues>(CellValues.String);

                worksheetPart.Worksheet.Save();
            }
        }
        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart, bool newRow = false)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            Row row;
            if (worksheet.Descendants<Row>().LastOrDefault() != null)
            {
                row = worksheet.Descendants<Row>().LastOrDefault();
            }
            else
            {
                row = new Row();
                sheetData.Append(row);

            }
            //check if the sheet Data contain any cells in that row 
            // new approach : get the last row indifr the sheetData , if the sheetData is empty 
            // if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            // {
            //     row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            // }
            // //else append new row to the sheet Data
            // else
            // {
            //     row = new Row() { RowIndex = rowIndex };
            //     sheetData.Append(row);
            // }
            // get the last cell in the row , to insert the new cell after it
            Cell refCell = row.Descendants<Cell>().LastOrDefault();

            // does provide CellReference 
            Cell newCell = new Cell();
            row.InsertAfter(newCell, refCell);

            worksheet.Save();
            return newCell;

        }

        public static void InsertDate(Data data, UInt32 rowIndex = 1)
        {
            int counter = 1;
            foreach (var item in data.GetType().GetProperties())
            {
                InsertTextIntoExistingExcel(filepath, item.GetValue(data).ToString(), alpha[counter], rowIndex);
                counter++;
            }
        }
        public static void InsertDate(List<Data> dataList)
        {
            UInt32 rowIndex = 1;
            foreach (var data in dataList)
            {
                InsertDate(data, rowIndex);
                rowIndex++;
            }

        }

    }
}
