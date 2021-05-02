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

            workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);

            workbook.Close();
            application.Quit();
        }

        public void sAddRegistrationCourse(List<RegistrationVO> registrations)
        {
            string[] registrationSplit;

            string courseTime1;
            string courseTime2;
            for (int index = 0; index < registrations.Count; index++)
            {
                // 시간 정보가 한개 있을 때 
                if (registrations[index].CourseTime.Length <= 20)
                {
                    AddRegistrationCourse("월", registrations[index].CourseTime, registrations, index);
                    AddRegistrationCourse("화", registrations[index].CourseTime, registrations, index);
                    AddRegistrationCourse("수", registrations[index].CourseTime, registrations, index);
                    AddRegistrationCourse("목", registrations[index].CourseTime, registrations, index);
                    AddRegistrationCourse("금", registrations[index].CourseTime, registrations, index);
                }
                
                // 시간 정보가 2개 있을 때 
                else
                {
                    registrationSplit = registrations[index].CourseTime.Split(',');
                    courseTime1 = registrationSplit[0];
                    courseTime2 = registrationSplit[1];

                    // 첫 번째 시간 정보 엑셀 값 넣기
                    AddRegistrationCourse("월", courseTime1, registrations, index);
                    AddRegistrationCourse("화", courseTime1, registrations, index);
                    AddRegistrationCourse("수", courseTime1, registrations, index);
                    AddRegistrationCourse("목", courseTime1, registrations, index);
                    AddRegistrationCourse("금", courseTime1, registrations, index);

                    // 두 번째 시간 정보 엑셀 값 넣기 
                    AddRegistrationCourse("월", courseTime2, registrations, index);
                    AddRegistrationCourse("화", courseTime2, registrations, index);
                    AddRegistrationCourse("수", courseTime2, registrations, index);
                    AddRegistrationCourse("목", courseTime2, registrations, index);
                    AddRegistrationCourse("금", courseTime2, registrations, index);
                }
            }
        }

        // 해당 시간에 맞는 위치에 과목이름 추가 하기 
        /*public void AddRegistrationCourse(string day, List<RegistrationVO> registrations, int index)
        {
            if (registrations[index].CourseTime.Contains(day))
            {
                if (registrations[index].CourseTime.Contains("9:00~10:30"))
                {
                    worksheet.Cells[3, 2] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 3] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 4] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("10:30~12:00"))
                {
                    worksheet.Cells[3, 5] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 6] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 7] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("12:00~13:30"))
                {
                    worksheet.Cells[3, 8] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 9] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 10] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("13:30~15:00"))
                {
                    worksheet.Cells[3, 11] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 12] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 13] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("15:00~16:30"))
                {
                    worksheet.Cells[3, 14] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 15] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 16] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("16:30~18:00"))
                {
                    worksheet.Cells[3, 17] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 18] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 19] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("16:30~18:30"))
                {
                    worksheet.Cells[3, 17] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 18] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 19] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 20] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("18:30~19:30"))
                {
                    worksheet.Cells[3, 21] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 22] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("18:30~20:30"))
                {
                    worksheet.Cells[3, 21] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 22] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 23] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 24] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("18:00~20:00"))
                {
                    worksheet.Cells[3, 20] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 21] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 22] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 23] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("18:00~19:00"))
                {
                    worksheet.Cells[3, 20] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 21] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (registrations[index].CourseTime.Contains("19:00~20:00"))
                {
                    worksheet.Cells[3, 22] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 23] = registrations[index].Title + registrations[index].ClassRoom;
                }
            }
        }*/

        public void AddRegistrationCourse(string day, string courseTime, List<RegistrationVO> registrations, int index)
        {

            if (courseTime.Contains(day))
            {
                if (courseTime.Contains("9:00~10:30"))
                {
                    worksheet.Cells[3, 2] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 3] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 4] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("10:30~12:00"))
                {
                    worksheet.Cells[3, 5] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 6] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 7] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("12:00~13:30"))
                {
                    worksheet.Cells[3, 8] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 9] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 10] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("13:30~15:00"))
                {
                    worksheet.Cells[3, 11] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 12] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 13] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("15:00~16:30"))
                {
                    worksheet.Cells[3, 14] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 15] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 16] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("16:30~18:00"))
                {
                    worksheet.Cells[3, 17] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 18] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 19] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("16:30~18:30"))
                {
                    worksheet.Cells[3, 17] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 18] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 19] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 20] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("18:30~19:30"))
                {
                    worksheet.Cells[3, 21] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 22] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("18:30~20:30"))
                {
                    worksheet.Cells[3, 21] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 22] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 23] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 24] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("18:00~20:00"))
                {
                    worksheet.Cells[3, 20] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 21] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 22] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 23] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("18:00~19:00"))
                {
                    worksheet.Cells[3, 20] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 21] = registrations[index].Title + registrations[index].ClassRoom;
                }

                else if (courseTime.Contains("19:00~20:00"))
                {
                    worksheet.Cells[3, 22] = registrations[index].Title + registrations[index].ClassRoom;
                    worksheet.Cells[3, 23] = registrations[index].Title + registrations[index].ClassRoom;
                }
            }
        }
    }
}
