using BL.Cashier.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork.Controllers.CashierControllers
{
    public class CashierFilms
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private CashierForm _f3;

        private IFilmsServiceC _filmsService;
        private DataGridView _dataGridFilms;



        public CashierFilms(CashierForm f3, IFilmsServiceC filmsService)
        {
            _filmsService = filmsService;

            _f3 = f3;

            _f3.Load += Form1_Load;

            _dataGridFilms = _f3.DataGridfilms;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputFilms(_dataGridFilms);
        }


        public void outputFilms(DataGridView dataGridFilms)
        {
            try
            {
                var res = _filmsService.SelectFilm();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        dataGridFilms.Rows.Add(c.FilmId, c.Title, c.Country, c.Producer, c.Duration, c.ReleaseDate,
                             c.Genre, c.BasePrice);
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
