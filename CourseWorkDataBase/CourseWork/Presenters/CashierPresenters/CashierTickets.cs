using BL.Cashier.DomainObjects;
using BL.Cashier.Interface;
using Entities.ValidationField;
using System;
using System.Windows.Forms;

namespace CourseWork.Controllers.CashierControllers
{
    public class CashireTickets
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private string errorDataGridCellClick = "Эта строка пуста";
        private CashierForm _f3;


        private ITicketsServiceC _ticketsService;
        ValidationField _valid;

        private DataGridView _dataGridTickets;

        private Button _addTickets;


        public CashireTickets(CashierForm f3, ITicketsServiceC ticketsService, ValidationField valid)
        {
            _valid = valid;
            _ticketsService = ticketsService;

            _f3 = f3;

            _f3.Load += Form1_Load;

            _dataGridTickets = _f3.DataGridtickets;
            _dataGridTickets.CellClick += DataGridtickets_CellClick;

            _addTickets = _f3.addTicket;
            _addTickets.Click += AddTickets_Click;
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
                    _f3.ticketsidsession = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[1].Value.ToString();
                    _f3.ticketsrow = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[2].Value.ToString();
                    _f3.ticketsseats = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[3].Value.ToString();
                    _f3.ticketszone = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[4].Value.ToString();
                    _f3.ticketsbooking.Checked = (bool)_dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[5].Value;
                    _f3.ticketsrecall = _dataGridTickets.Rows[_dataGridTickets.CurrentRow.Index].Cells[6].Value.ToString();
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
                if (_valid.ValidAddTicketsTable(_f3.ticketsidsession, _f3.ticketsrow, _f3.ticketsseats, _f3.ticketszone, _f3.ticketsrecall))
                {
                    bool res = _ticketsService.InsertTicketss(new TicketsMember
                    {
                        SessionId = _f3.ticketsidsession,
                        Row = _f3.ticketsrow,
                        Seat = _f3.ticketsseats,
                        Zone = _f3.ticketszone,
                        Booking = _f3.ticketsbooking.Checked,
                        Recall = _f3.ticketsrecall

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
