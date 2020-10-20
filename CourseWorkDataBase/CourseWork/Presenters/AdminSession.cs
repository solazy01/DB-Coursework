using BL.Admin.DomainObjects;
using BL.Admin.Interface;
using System;
using System.Windows.Forms;
using Entities.Function;
using Entities.ValidationField;

namespace CourseWork.Controllers
{
    public class AdminSession
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private string errorDataGridCellClick = "Эта строка пуста";
        private AdminForm _f1;

        private ISessionService _sessionService;

        private IFilmsService _filmsService;

        ValidationField _valid;

        private DataGridView _dataGridSession;
        private Button _addSession;
        private Button _deleteSession;
        private Button _updateSession;

        private ComboBox _filmName;


        public AdminSession(AdminForm f1, ISessionService sessionService, IFilmsService filmsService, ValidationField valid)
        {
            _valid = valid;

            _sessionService = sessionService;
            _filmsService = filmsService;

            _f1 = f1;

            _f1.Load += Form1_Load;

            _dataGridSession = _f1.DataGridsession;
            _dataGridSession.CellClick += dataGridSession_CellClick;

            _addSession = _f1.addSession;
            _addSession.Click += AddSession_Click;


            _deleteSession = _f1.deleteSession;
            _deleteSession.Click += DeleteSession_Click;

            _updateSession = _f1.updateSession;
            _updateSession.Click += UpdateSession_Click;

            _filmName = _f1.sessionidfilm;
            _filmName.Click += SessionIDFilm_Click;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputSession(_dataGridSession);
        }

        #region Обработчик, заполняющий TextBox при нажатии на ячейку

        private void dataGridSession_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridSession.CurrentRow != null)
                {
                    _f1.idsession = _dataGridSession.Rows[_dataGridSession.CurrentRow.Index].Cells[0].Value.ToString();
                    _f1.sessionidfilm.Text = _dataGridSession.Rows[_dataGridSession.CurrentRow.Index].Cells[1].Value.ToString();
                    _f1.sessiondate = _dataGridSession.Rows[_dataGridSession.CurrentRow.Index].Cells[2].Value.ToString();
                    _f1.sessiontime = _dataGridSession.Rows[_dataGridSession.CurrentRow.Index].Cells[3].Value.ToString();
                    _f1.sessionidhall = _dataGridSession.Rows[_dataGridSession.CurrentRow.Index].Cells[4].Value.ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(errorDataGridCellClick);
            }
        }

        #endregion

        #region Add

        private void AddSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddSessionTable(_f1.sessiondate, _f1.sessiontime, _f1.sessionidhall))
                {
                    bool res = _sessionService.InsertSessions(new SessionMember
                {
                    FilmId = Convert.ToString(FunctionOther.GetNumber(_f1.sessionidfilm.Text)),
                    Date = _f1.sessiondate,
                    Time = _f1.sessiontime,
                    HallId = _f1.sessionidhall

                });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputSession(_dataGridSession);
                        if (_dataGridSession.CurrentRow != null)
                        {
                            _dataGridSession.Rows[_dataGridSession.CurrentRow.Index].Selected = false;
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
        private void DeleteSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidDeleteSessionTable(_f1.idsession))
                {
                    bool res = _sessionService.DeleteSessions(new SessionMember
                    {
                        SessionId = _f1.idsession

                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputSession(_dataGridSession);
                        if (_dataGridSession.CurrentRow != null)
                        {
                            _dataGridSession.Rows[_dataGridSession.CurrentRow.Index].Selected = false;
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
        private void UpdateSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddSessionTable(_f1.sessiondate, _f1.sessiontime, _f1.sessionidhall))
                {
                    bool res = _sessionService.UpdateSessions(new SessionMember
                {
                    FilmId = Convert.ToString(FunctionOther.GetNumber(_f1.sessionidfilm.Text)),
                    Date = _f1.sessiondate,
                    Time = _f1.sessiontime,
                    HallId = _f1.sessionidhall,
                    SessionId = _f1.idsession

                });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputSession(_dataGridSession);
                        if (_dataGridSession.CurrentRow != null)
                        {
                            _dataGridSession.Rows[_dataGridSession.CurrentRow.Index].Selected = false;
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


        private void SessionIDFilm_Click(object sender, EventArgs e)
        {
            _filmName.Items.Clear();

            try
            {
                var res = _filmsService.SelectFName();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        _filmName.Items.Add(c.Name);
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
