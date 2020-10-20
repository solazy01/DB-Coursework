using System;
using System.Windows.Forms;
using BL.Admin.DominObjects;
using BL.Admin.Interface;
using Entities.ValidationField;

namespace CourseWork.Controllers
{
    public class AdminFilms
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private string errorDataGridCellClick = "Эта строка пуста";
        private AdminForm _f1;

        private IFilmsService _filmsService;

        ValidationField _valid;

        private DataGridView _dataGridFilms;
        private Button _addFilms;
        private Button _deleteFilms;
        private Button _updateFilms;


        public AdminFilms(AdminForm f1, IFilmsService filmsService, ValidationField valid)
        {
            _valid = valid;

            _filmsService = filmsService;

            _f1 = f1;

            _f1.Load += Form1_Load;

            _dataGridFilms = _f1.DataGridfilms;
            _dataGridFilms.CellClick += dataGridFilms_CellClick;

            _addFilms = _f1.addFilm;
            _addFilms.Click += AddFilm_Click;

            _deleteFilms = _f1.deleteFilm;
            _deleteFilms.Click += DeleteFilm_Click;

            _updateFilms = _f1.updateFilm;
            _updateFilms.Click += UpdateFilm_Click;


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputFilms(_dataGridFilms);
        }


        #region Обработчик, заполняющий TextBox при нажатии на ячейку таблицы
        private void dataGridFilms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridFilms.CurrentRow != null)
                {
                    _f1.idfilm = _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Cells[0].Value.ToString();
                    _f1.titlefilm = _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Cells[1].Value.ToString();
                    _f1.countryfilm = _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Cells[2].Value.ToString();
                    _f1.producerFilm = _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Cells[3].Value.ToString();
                    _f1.durationFilm = _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Cells[4].Value.ToString();
                    _f1.dateFilm = _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Cells[5].Value.ToString();
                    _f1.genreFilm = _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Cells[6].Value.ToString();
                    _f1.priceFilm = _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Cells[7].Value.ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(errorDataGridCellClick);
            }
        }

        #endregion

        #region Add
        private void AddFilm_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddFilmsTable(_f1.titlefilm, _f1.countryfilm, _f1.producerFilm, _f1.durationFilm, _f1.dateFilm, _f1.genreFilm, _f1.priceFilm))
                {
                    bool res = _filmsService.InsertFilms(new FilmsMember
                    {
                        Title = _f1.titlefilm,
                        Country = _f1.countryfilm,
                        Producer = _f1.producerFilm,
                        Duration = _f1.durationFilm,
                        ReleaseDate = _f1.dateFilm,
                        Genre = _f1.genreFilm,
                        BasePrice = _f1.priceFilm
                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputFilms(_dataGridFilms);
                        if (_dataGridFilms.CurrentRow != null)
                        {
                            _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Selected = false;
                        }
                    }
                }
                else
                {
                    foreach (var v in _valid.ErrorStrings)
                    {
                        MessageBox.Show(v);
                    }
                    _valid.ErrorStrings.Clear();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(errorController);
            }
        }


        #endregion

        #region Delete
        private void DeleteFilm_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidDeleteFilmsTable(_f1.idfilm))
                {

                    bool res = _filmsService.DeleteFilms(new FilmsMember
                {
                    FilmId = _f1.idfilm

                });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputFilms(_dataGridFilms);
                        if (_dataGridFilms.CurrentRow != null)
                        {
                            _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Selected = false;
                        }
                    }
                }
                else
                {
                    foreach (var v in _valid.ErrorStrings)
                    {
                        MessageBox.Show(v);
                    }
                    _valid.ErrorStrings.Clear();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(errorController);
            }
        }


        #endregion

        #region Update
        private void UpdateFilm_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddFilmsTable(_f1.titlefilm, _f1.countryfilm, _f1.producerFilm, _f1.durationFilm, _f1.dateFilm, _f1.genreFilm, _f1.priceFilm))
                {
                    bool res = _filmsService.UpdateFilms(new FilmsMember
                {
                    Title = _f1.titlefilm,
                    Country = _f1.countryfilm,
                    Producer = _f1.producerFilm,
                    Duration = _f1.durationFilm,
                    ReleaseDate = _f1.dateFilm,
                    Genre = _f1.genreFilm,
                    BasePrice = _f1.priceFilm,
                    FilmId = _f1.idfilm
                });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputFilms(_dataGridFilms);
                        if (_dataGridFilms.CurrentRow != null)
                        {
                            _dataGridFilms.Rows[_dataGridFilms.CurrentRow.Index].Selected = false;
                        }
                    }
                }
                else
                {
                    foreach (var v in _valid.ErrorStrings)
                    {
                        MessageBox.Show(v);
                    }
                    _valid.ErrorStrings.Clear();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(errorController);
            }
        }

        #endregion

        public void outputFilms(DataGridView dataGridFilms)
        {
            dataGridFilms.Rows.Clear();

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
