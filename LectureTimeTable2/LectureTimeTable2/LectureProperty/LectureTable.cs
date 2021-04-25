using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace LectureTimeTable2.LectureProperty
{
    class LectureTable
    {
        LectureScreen LectureScreen;
        LectureMenu LectureMenu;

        public LectureTable()
        {
            this.LectureScreen = new LectureScreen();
        }

        public void LoadComputeMajor()
        {
            try
            {
                Excel.Application application = new Application();
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2021년도 1학기 강의시간표.xlsx");
                Excel.Sheets sheets = workbook.Sheets;
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;
                Excel.Range cellRange = worksheet.get_Range("B2", "L104") as Excel.Range;
                Array data = (Array)cellRange.Cells.Value2;

                Console.Clear();
                Console.SetWindowSize(150, 40);
                for (int row = 1; row <= 103; row++)
                {
                    Console.Write(row < 10 ? "00"+row + " " : row < 100 ? "0" + row + " " : row + " ");
                    for (int column = 1; column <= 11; column++)
                    {
                        if (column == 4)
                        {
                            string major = data.GetValue(row, column).ToString();
                            Console.Write(major.PadRight(32 - major.Length, ' '));
                        }

                        else
                        {
                            Console.Write(data.GetValue(row, column));
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine("\n");
                }

                application.Workbooks.Close();
                application.Quit();

                LectureScreen.PrintProgressNotice();
                Console.ReadLine();
                Console.SetWindowSize(100, 40);

            }

            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadIntelligenceMajor()
        {
            try
            {
                Excel.Application application = new Application();
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2021년도 1학기 강의시간표.xlsx");
                Excel.Sheets sheets = workbook.Sheets;
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;
                Excel.Range cellRange = worksheet.get_Range("B105", "L152") as Excel.Range;
                Array data = (Array)cellRange.Cells.Value2;

                Console.Clear();
                Console.SetWindowSize(150, 40);

                for (int row = 1; row <= 48; row++)
                {
                    Console.Write(row < 10 ? "00" + row + " " : "0" + row + " ");

                    for (int column = 1; column <= 11; column++)
                    {
                        if(column == 4)
                        {
                            string major = data.GetValue(row, column).ToString();
                            Console.Write(major.PadRight(40 - major.Length, ' '));
                        }

                        else
                        {
                            Console.Write(data.GetValue(row, column));
                            Console.Write(" ");
                        }
                    }

                    Console.WriteLine("\n");
                }

                application.Workbooks.Close();
                application.Quit();
                LectureScreen.PrintProgressNotice();
                Console.ReadLine();
                Console.SetWindowSize(100, 40);
            }

            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadEngineeringMajor()
        {
            try
            {
                Excel.Application application = new Application();
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2021년도 1학기 강의시간표.xlsx");
                Excel.Sheets sheets = workbook.Sheets;
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;
                Excel.Range cellRange = worksheet.get_Range("B153", "L169") as Excel.Range;
                Array data = (Array)cellRange.Cells.Value2;

                Console.Clear();
                Console.SetWindowSize(150, 40);

                for (int row = 1; row <= 17; row++)
                {
                    Console.Write(row < 10 ? "00" + row + " " : "0"+ row + " ");

                    for (int column = 1; column <= 11; column++)
                    {
                            Console.Write(data.GetValue(row, column));
                            Console.Write(" ");
                    }

                    Console.WriteLine("\n");
                }

                application.Workbooks.Close();
                application.Quit();
                LectureScreen.PrintProgressNotice();
                Console.ReadLine();
                Console.SetWindowSize(100, 40);
            }

            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
