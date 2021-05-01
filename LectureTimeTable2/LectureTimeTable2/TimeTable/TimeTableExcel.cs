using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using LectureTimeTable2.VOs;

namespace LectureTimeTable2.TimeTable
{
    class TimeTableExcel
    {
        private Excel.Application application;
        private Excel.Workbook workbook;
        private Excel.Worksheet worksheet;

        //private List<RegistrationVO> registerations; 

        public TimeTableExcel()
        {
            this.application = new Excel.Application();
            this.workbook = application.Workbooks.Add();
            this.worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

            //this.registerations = registerations;
        }

        public void InitializeTimeTableExcel()
        {
            string desktopath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktopath, "Excel.xlsx");

            worksheet.Cells[1, 3] = "월";
            worksheet.Cells[1, 4] = "화";
            worksheet.Cells[1, 5] = "수";
            worksheet.Cells[1, 6] = "목";
            worksheet.Cells[1, 7] = "금";
            worksheet.Cells[2, 1] = "09:00 ~ 09:30"; 
            worksheet.Cells[3, 1] = "09:30 ~ 10:00"; 
            worksheet.Cells[4, 1] = "10:00 ~ 10:30"; 
            worksheet.Cells[5, 1] = "10:30 ~ 11:00"; 
            worksheet.Cells[6, 1] = "11:00 ~ 11:30"; 
            worksheet.Cells[7, 1] = "11:30 ~ 12:00"; 
            worksheet.Cells[8, 1] = "12:00 ~ 12:30"; 
            worksheet.Cells[9, 1] = "12:30 ~ 13:00"; 
            worksheet.Cells[10, 1] = "13:00 ~ 13:30"; 
            worksheet.Cells[11, 1] = "13:30 ~ 14:00"; 
            worksheet.Cells[12, 1] = "14:00 ~ 14:30"; 
            worksheet.Cells[13, 1] = "14:30 ~ 15:00"; 
            worksheet.Cells[14, 1] = "15:00 ~ 15:30"; 
            worksheet.Cells[15, 1] = "15:30 ~ 16:00"; 
            worksheet.Cells[16, 1] = "16:00 ~ 16:30"; 
            worksheet.Cells[17, 1] = "16:30 ~ 17:00"; 
            worksheet.Cells[18, 1] = "17:00 ~ 17:30"; 
            worksheet.Cells[19, 1] = "17:30 ~ 18:00"; 
            worksheet.Cells[20, 1] = "18:00 ~ 18:30"; 
            worksheet.Cells[21, 1] = "18:30 ~ 19:00";
            worksheet.Cells[22, 1] = "19:00 ~ 19:30";
            worksheet.Cells[19, 1] = "19:30 ~ 20:00";

            workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);

            workbook.Close();
            application.Quit();
        }
    }
}
