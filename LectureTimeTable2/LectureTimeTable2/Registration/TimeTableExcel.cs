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

        // 엑셀 초기화(?) 
        public void InitializeTimeTableExcel()
        {
            // 경로 지정 
            string desktopath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktopath, "시간표.xlsx");

            // 기본 값 넣어주기 
            worksheet.Cells[1, 4] = "월";
            worksheet.Cells[1, 7] = "화";
            worksheet.Cells[1, 10] = "수";
            worksheet.Cells[1, 13] = "목";
            worksheet.Cells[1, 16] = "금";
            worksheet.Cells[2, 1] = "09:00~09:30";
            worksheet.Cells[3, 1] = "09:30~10:00";
            worksheet.Cells[4, 1] = "10:00~10:30";
            worksheet.Cells[5, 1] = "10:30~11:00";
            worksheet.Cells[6, 1] = "11:00~11:30";
            worksheet.Cells[7, 1] = "11:30~12:00";
            worksheet.Cells[8, 1] = "12:00~12:30";
            worksheet.Cells[9, 1] = "12:30~13:00";
            worksheet.Cells[10, 1] = "13:00~13:30";
            worksheet.Cells[11, 1] = "13:30~14:00";
            worksheet.Cells[12, 1] = "14:00~14:30";
            worksheet.Cells[13, 1] = "14:30~15:00";
            worksheet.Cells[14, 1] = "15:00~15:30";
            worksheet.Cells[15, 1] = "15:30~16:00";
            worksheet.Cells[16, 1] = "16:00~16:30";
            worksheet.Cells[17, 1] = "16:30~17:00";
            worksheet.Cells[18, 1] = "17:00~17:30";
            worksheet.Cells[19, 1] = "17:30~18:00";
            worksheet.Cells[20, 1] = "18:00~18:30";
            worksheet.Cells[21, 1] = "18:30~19:00";
            worksheet.Cells[22, 1] = "19:00~19:30";
            worksheet.Cells[23, 1] = "19:30~20:00";
            worksheet.Cells[24, 1] = "20:00~20:30";

        }

        public void RunAddRegistrationCourse(List<RegistrationVO> registrations)
        {
            string[] registrationSplit;

            string courseTime1;
            string courseTime2;
            for (int index = 0; index < registrations.Count; index++)
            {
                // 시간 정보가 한개 있을 때 
                if (registrations[index].CourseTime.Length <= 20)
                {
                    if (registrations[index].CourseTime.Contains("월"))
                    {
                        AddRegistrationCourse(3, registrations[index].CourseTime, registrations, index);
                    }
                    

                    if (registrations[index].CourseTime.Contains("화"))
                    {
                        AddRegistrationCourse(6, registrations[index].CourseTime, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("수"))
                    {
                        AddRegistrationCourse(9, registrations[index].CourseTime, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("목"))
                    {
                        AddRegistrationCourse(12, registrations[index].CourseTime, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("금"))
                    {
                        AddRegistrationCourse(15, registrations[index].CourseTime, registrations, index);
                    }
                }

                // 시간 정보가 2개 있을 때 
                else
                {
                    registrationSplit = registrations[index].CourseTime.Split(',');
                    courseTime1 = registrationSplit[0];
                    courseTime2 = registrationSplit[1];

                    // 첫 번째 시간 정보 엑셀 값 넣기
                    if (registrations[index].CourseTime.Contains("월"))
                    {
                        AddRegistrationCourse(3, courseTime1, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("화"))
                    {
                        AddRegistrationCourse(6, courseTime1, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("수"))
                    {
                        AddRegistrationCourse(9, courseTime1, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("목"))
                    {
                        AddRegistrationCourse(12, courseTime1, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("금"))
                    {
                        AddRegistrationCourse(15, courseTime1, registrations, index);
                    }

                    // 두 번째 시간 정보 엑셀 값 넣기
                    if (registrations[index].CourseTime.Contains("월"))
                    {
                        AddRegistrationCourse(3, courseTime2, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("화"))
                    {
                        AddRegistrationCourse(6, courseTime2, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("수"))
                    {
                        AddRegistrationCourse(9, courseTime2, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("목"))
                    {
                        AddRegistrationCourse(12, courseTime2, registrations, index);
                    }

                    if (registrations[index].CourseTime.Contains("금"))
                    {
                        AddRegistrationCourse(15, courseTime2, registrations, index);
                    }
                }
            }
        }

        // 엑셀파일 저장하기 
        public void SaveTimeTableExccel(string path)
        {
            workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);

            workbook.Close();
            application.Quit();
        }

        public void AddRegistrationCourse(int day, string courseTime, List<RegistrationVO> registrations, int index)
        {

            if (courseTime.Contains("9:00~10:30"))
            {
                worksheet.Cells[2, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[3, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[4, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("9:00~10:00"))
            {
                worksheet.Cells[2, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[3, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if(courseTime.Contains("9:00~11:00"))
            {
                worksheet.Cells[2, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[3, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[4, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[5, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("9:00~12:00"))
            {
                worksheet.Cells[2, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[3, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[4, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[5, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[6, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[7, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("10:30~11:30"))
            {
                worksheet.Cells[5, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[6, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("10:00~12:00"))
            {
                worksheet.Cells[4, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[5, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[6, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[7, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("10:30~12:00"))
            {
                worksheet.Cells[5, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[6, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[7, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("10:30~12:30"))
            {
                worksheet.Cells[5, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[6, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[7, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[8, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("12:00~13:30"))
            {
                worksheet.Cells[7, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[8, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[9, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[10, day] = registrations[index].Title + registrations[index].ClassRoom;
            }


            else if (courseTime.Contains("12:00~15:00"))
            {
                worksheet.Cells[8, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[9, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[10, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[11, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("12:00~18:00"))
            {
                worksheet.Cells[8, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[9, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[10, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[11, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[15, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[16, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[17, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[18, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[19, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("13:30~16:00"))
            {
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[15, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[16, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("13:30~16:30"))
            {
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[15, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[16, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[17, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("13:30~15:00"))
            {
                worksheet.Cells[11, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("13:30~15:30"))
            {
                worksheet.Cells[11, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("13:30~18:30"))
            {
                worksheet.Cells[11, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[15, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[16, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[17, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[18, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[19, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[20, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("13:30~18:30"))
            {
                worksheet.Cells[11, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[15, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[16, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[17, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[18, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[19, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[20, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[21, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[22, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("14:30~16:30"))
            {
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[12, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[13, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("15:00~16:30"))
            {
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[15, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[16, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("15:30~17:30"))
            {
                worksheet.Cells[15, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[16, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[17, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[18, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("15:00~18:00"))
            {
                worksheet.Cells[14, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[15, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[16, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[17, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[18, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[19, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("16:30~18:00"))
            {
                worksheet.Cells[17, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[18, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[19, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("16:30~18:30"))
            {
                worksheet.Cells[17, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[18, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[19, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[20, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("18:30~19:30"))
            {
                worksheet.Cells[21, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[22, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("18:30~20:30"))
            {
                worksheet.Cells[21, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[22, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[23, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[24, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("18:00~20:00"))
            {
                worksheet.Cells[20, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[21, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[22, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[23, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("18:00~19:00"))
            {
                worksheet.Cells[20, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[21, day] = registrations[index].Title + registrations[index].ClassRoom;
            }

            else if (courseTime.Contains("19:00~20:00"))
            {
                worksheet.Cells[22, day] = registrations[index].Title + registrations[index].ClassRoom;
                worksheet.Cells[23, day] = registrations[index].Title + registrations[index].ClassRoom;
            }
        }

        public void PrintTimeTable()
        {
            Excel.Range cellRange = worksheet.get_Range("A1", "Q24") as Excel.Range;
            Array data = (Array)cellRange.Cells.Value2;
            for(int col = 1; col <=24; col++)
            {
                for(int row = 1; row<=16; row++)
                {
                    Console.Write(data.GetValue(col, row));
                }
                Console.WriteLine("\n");
            }
        }
    }
}
