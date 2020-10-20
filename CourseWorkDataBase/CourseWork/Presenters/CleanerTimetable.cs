using BL.Cleaner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork.Presenters
{
    public class CleanerTimetable
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private CleanerForm _f4;

        private ITimetableService _timetableService;
        private DataGridView _dataGridTimetable;



        public CleanerTimetable(CleanerForm f4, ITimetableService timetableService)
        {
            _timetableService = timetableService;

            _f4 = f4;

            _f4.Load += Form1_Load;

            _dataGridTimetable = _f4.DataGridtimetable;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputTimetable(_dataGridTimetable);
        }


        public void outputTimetable(DataGridView dataGridTimetable)
        {
            try
            {
                var res = _timetableService.SelectTimetable();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        dataGridTimetable.Rows.Add(c.Title, c.Date, c.Time, c.HallId);
                    }

                }
                else
                {
                    MessageBox.Show(errorDataBase);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(errorController);
            }
        }
    }
}
