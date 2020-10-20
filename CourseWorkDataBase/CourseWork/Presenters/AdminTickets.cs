using BL.Admin.DomainObjects;
using BL.Admin.Interface;
using Entities.ValidationField;
using System;
using System.Windows.Forms;

namespace CourseWork.Controllers
{
    public class AdminTickets
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private string errorDataGridCellClick = "Эта строка пуста";
        private AdminForm _f1;

        private ITicketsService _ticketsService;

        ValidationField _valid;

        private DataGridView _dataGridTickets;
        private Button _addTickets;
        private Button _deleteTickets;
        private Button _updateTickets;


        public AdminTickets(AdminForm f1, ITicketsService ticketsService, ValidationField valid)
        {
            _valid = valid;

            _ticketsService = ticketsService;

            _f1 = f1;

            _f1.Load += Form1_Load;

            _dataGridTickets = _f1.DataGridtickets;
            _dataGridTickets.CellClick += DataGridtickets_CellClick;

            _addTickets = _f1.addTicket;
            _addTickets.Click += AddTickets_Click;

            _deleteTickets = _f1.deleteTicket;
            _deleteTickets.Click += DeleteTickets_Click;

            _updateTickets = _f1.updateTicket;
            _updateTickets.Click += UpdateTickets_Click;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputTickets(_dataGridTickets);
        }


        #region Обработчик, заполняющий TextBox при нажатии на ячейку таблицы
        private void DataGridtickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridTickets.CurrentRow != null)
                {
                    _f1.idticket = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[0].Value.ToString();
                    _f1.ticketsidsession = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[1].Value.ToString();
                    _f1.ticketsrow = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[2].Value.ToString();
                    _f1.ticketsseats = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[3].Value.ToString();
                    _f1.ticketszone = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[4].Value.ToString();
                    _f1.ticketsbooking.Checked = (bool)_dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[5].Value;
                    _f1.ticketsrecall = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[6].Value.ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(errorDataGridCellClick);
            }
        }

        #endregion

        #region Add

        private void AddTickets_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddTicketsTable(_f1.ticketsidsession, _f1.ticketsrow, _f1.ticketsseats, _f1.ticketszone, _f1.ticketsrecall))
                {
                    bool res = _ticketsService.InsertTicketss(new TicketsMember
                    {
                        SessionId = _f1.ticketsidsession,
                        Row = _f1.ticketsrow,
                        Seat = _f1.ticketsseats,
                        Zone = _f1.ticketszone,
                        Booking = _f1.ticketsbooking.Checked,
                        Recall = _f1.ticketsrecall

                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputTickets(_dataGridTickets);
                        if (_dataGridTickets.CurrentRow != null)
                        {
                            _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Selected = false;
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
        private void DeleteTickets_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidDeleteFilmsTable(_f1.idticket))
                {
                    bool res = _ticketsService.DeleteTicketss(new TicketsMember
                    {
                        TicketId = _f1.idticket

                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputTickets(_dataGridTickets);
                        if (_dataGridTickets.CurrentRow != null)
                        {
                            _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Selected = false;
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
        private void UpdateTickets_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddTicketsTable(_f1.ticketsidsession, _f1.ticketsrow, _f1.ticketsseats, _f1.ticketszone, _f1.ticketsrecall))
                {
                    bool res = _ticketsService.UpdateTicketss(new TicketsMember
                    {
                        SessionId = _f1.ticketsidsession,
                        Row = _f1.ticketsrow,
                        Seat = _f1.ticketsseats,
                        Zone = _f1.ticketszone,
                        Booking = _f1.ticketsbooking.Checked,
                        Recall = _f1.ticketsrecall,
                        TicketId = _f1.idticket
                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        MessageBox.Show("Данные обновлены!");
                        outputTickets(_dataGridTickets);
                        if (_dataGridTickets.CurrentRow != null)
                        {
                            _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Selected = false;
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

        public void outputTickets(DataGridView dataGridTickets)
        {
            dataGridTickets.Rows.Clear();

            try
            {
                var res = _ticketsService.SelectTickets();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        dataGridTickets.Rows.Add(c.TicketId, c.SessionId, c.Row, c.Seat, c.Zone, c.Booking,
                             c.Recall);
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
