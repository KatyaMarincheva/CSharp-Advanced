using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using ClosedXML.Excel;

namespace _13.LINQToExcel
{
    class LINQToExcel
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            List<Student> students = new List<Student>();
            string[] head = new string[12];

            using (StreamReader sr = new StreamReader("../../Students-data.txt"))
            {
                 head = Regex.Split(sr.ReadLine().Trim(), @"\t");

                while (sr.Peek() > -1)
                {
                    string[] line = Regex.Split(sr.ReadLine().Trim(), @"\s+");
                    students.Add(new Student(int.Parse(line[0]), line[1], line[2], line[3], line[4], line[5],
                        int.Parse(line[6]), int.Parse(line[7]), int.Parse(line[8]), double.Parse(line[9]), int.Parse(line[10]), double.Parse(line[11])));
                    students.Last().CalculateResult();
                }
            }

            var query = from st in students
                where st.StudentType.Equals("Online")
                orderby st.result descending
                select st;

            var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Problem13");
            ws.Cell("A1").Value = "Softuni OOP Course Results";
            ws.Cell("A1").Style.Font.FontSize = 15;
            ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Range("A1:M2").Merge();

            for (int i = 0; i < head.Length; i++)
            {
                ws.Cell(3, i + 1).Value = head[i];
            }
            ws.Cell(3, 13).Value = "Result";
            ws.Column("M").Style.Fill.BackgroundColor = XLColor.LightGreen;
            ws.Columns("A", "L").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            var rngHeaders = ws.Range("A3:M3");
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Green;
            rngHeaders.Style.Font.FontColor = XLColor.White;
            ws.Cell("A1").Value = "Softuni OOP Course Results";
            ws.Cell("A1").Style.Font.FontSize = 15;
            ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Range("A1:M2").Merge();

            ws.Column(1).InsertColumnsBefore(1);
            ws.Cell(4, 1).InsertData(query.AsEnumerable());
            ws.Cell("N4").Value = ws.Range(ws.Cell("A4"), ws.Columns("A").CellsUsed().Last());
            ws.Column(1).Delete();

            ws.Columns("A", "M").AdjustToContents();
            workbook.SaveAs("../../Output.xlsx");
        }
    }
}
