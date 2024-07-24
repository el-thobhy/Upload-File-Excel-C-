using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace AplikasiUploadExcel.Api.Services
{
    public static class UploadExcel
    {
        public static List<T> Import<T>(string filePath) where T : new()
        {
            XSSFWorkbook workbook;
            using(var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(stream);
            }
            var sheet = workbook.GetSheetAt(0);
            var rowHeader = sheet.GetRow(0);
            var colIndexList = new Dictionary<string, int>();
            foreach(var cell in rowHeader.Cells)
            {
                var colName = cell.StringCellValue;
                colIndexList.Add(colName, cell.ColumnIndex);
            }

            var listResult = new List<T>();
            var currentRow = 1;
            while(currentRow <= sheet.LastRowNum)
            {
                var row = sheet.GetRow(currentRow);
                if (row == null) break;
                var obj = new T();
                foreach(var property in typeof(T).GetProperties())
                {
                    if (!colIndexList.ContainsKey(property.Name))
                    {
                        throw new Exception($"Column {property.Name} Not found");
                    }
                    var colIndex = colIndexList[property.Name];
                    var cell = row.GetCell(colIndex);

                    if(cell.CellType == CellType.Blank)
                    {
                        property.SetValue(obj, null);
                    }
                    else if(property.PropertyType == typeof(string))
                    {
                        cell.SetCellType(CellType.String);
                        property.SetValue(obj, cell.StringCellValue);
                    }
                    else if(property.PropertyType == typeof(int))
                    {
                        cell.SetCellType(CellType.Numeric);
                        property.SetValue(obj, Convert.ToInt32(cell.NumericCellValue));
                    }
                    else if(property.PropertyType == typeof(decimal))
                    {
                        cell.SetCellType(CellType.Numeric);
                        property.SetValue(obj, Convert.ToDecimal(cell.NumericCellValue));
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        if (property == null)
                        {
                            property.SetValue(obj, null);
                        }
                        else
                        {
                            property.SetValue(obj, cell.DateCellValue);
                        }
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        property.SetValue(obj, cell.DateCellValue);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        cell.SetCellType(CellType.Boolean);
                        property.SetValue(obj, cell.BooleanCellValue);
                    }
                    else
                    {
                        property.SetValue(obj, Convert.ChangeType(cell.StringCellValue, property.PropertyType));
                    }
                }
                listResult.Add(obj);
                currentRow++;
            }
            return listResult;
        }

        public static byte[] Export<T>(List<T> source)
        {
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("Sheet1");
            var rowHeader = sheet.CreateRow(0);

            var properties = typeof(T).GetProperties();

            //header
            var font = workbook.CreateFont();
            font.IsBold = true;
            var style = workbook.CreateCellStyle();
            style.SetFont(font);

            var colIndex = 0;
            foreach ( var property in properties)
            {
                var cell = rowHeader.GetCell(colIndex);
                cell.SetCellValue(property.Name);
                cell.CellStyle = style;
                colIndex++;
            }
            //endheader

            //content
            var rowNum = 1;
            foreach(var item in source)
            {
                var rowContent = sheet.CreateRow(rowNum);
                var colContentIndex = 0;
                foreach ( var property in properties)
                {
                    var cellContent = rowContent.CreateCell(colContentIndex);
                    var value = property.GetValue(item, null);
                    if(value == null)
                    {
                        cellContent.SetCellValue("");
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        cellContent.SetCellValue(value.ToString());
                    }
                    else if (property.PropertyType == typeof(int))
                    {
                        cellContent.SetCellValue(Convert.ToInt32(value));
                    }
                    else if (property.PropertyType == typeof(decimal?))
                    {
                        cellContent.SetCellValue(Convert.ToDouble(value));
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        var dateValue = (DateTime)value;
                        cellContent.SetCellValue(dateValue.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        cellContent.SetCellValue(value.ToString());
                    }
                    colContentIndex++;
                }
                rowNum++;
            }
            //end of context

            var stream = new MemoryStream();
            workbook.Write(stream);
            var content = stream.ToArray();
            return content;
        }
    }
}
