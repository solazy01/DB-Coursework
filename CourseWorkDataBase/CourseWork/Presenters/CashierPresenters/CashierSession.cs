using BL.Cashier.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork.Controllers.CashierControllers
{
    public class CashierSession
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private string errorDataGridCellClick = "Эта строка пуста";
        private CashierForm _f3;

        private ISessionServiceC _sessionService;


        private DataGridView _dataGridSession;


        public CashierSession(CashierForm f3, ISessionServiceC sessionService)
        {
            _sessionService = sessionService;

            _f3 = f3;

            _f3.Load += Form1_Load;

            _dataGridSession = _f3.DataGridsession;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputSession(_dataGridSession);
        }


        public void outputSession(DataGridView dataGridSession)
        {
            dataGridSession.Rows.Clear();

            try
            {
                var res = _sessionService.SelectSession();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        dataGridSession.Rows.Add(c.SessionId, c.FilmId, c.Date, c.Time, c.HallId);
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
