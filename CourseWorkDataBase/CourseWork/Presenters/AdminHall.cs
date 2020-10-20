using System;
using System.Windows.Forms;
using BL.Admin.Interface;
using BL.Admin.DomainObjects;
using Entities.ValidationField;

namespace CourseWork.Controllers
{
    public class AdminHall
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private string errorDataGridCellClick = "Эта строка пуста";
        private AdminForm _f1;

        private IHallService _hallService;

        ValidationField _valid;

        private DataGridView _dataGridHall;
        private Button _addHall;
        private Button _deleteHall;
        private Button _updateHall;


        public AdminHall(AdminForm f1, IHallService hallService, ValidationField valid)
        {
            _valid = valid;
            _hallService = hallService;

            _f1 = f1;

            _f1.Load += Form1_Load;

            _dataGridHall = _f1.DataGridhall;
            _dataGridHall.CellClick += dataGridHall_CellClick;

            _addHall = _f1.addHall;
            _addHall.Click += AddHall_Click;


            _deleteHall = _f1.deleteHall;
            _deleteHall.Click += DeleteHall_Click;

            _updateHall = _f1.updateHall;
            _updateHall.Click += UpdateHall_Click;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputHall(_dataGridHall);
        }

        #region Обработчик, заполняющий TextBox при нажатии на ячейку

        private void dataGridHall_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridHall.CurrentRow != null)
                {
                    _f1.idhall = _dataGridHall.Rows[_dataGridHall.CurrentRow.Index].Cells[0].Value.ToString();
                    _f1.rowshall = _dataGridHall.Rows[_dataGridHall.CurrentRow.Index].Cells[1].Value.ToString();
                    _f1.seatshall = _dataGridHall.Rows[_dataGridHall.CurrentRow.Index].Cells[2].Value.ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(errorDataGridCellClick);
            }
        }

        #endregion

        #region Add

        private void AddHall_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddHallTable(_f1.rowshall, _f1.seatshall))
                {
                        bool res = _hallService.InsertHalls(new HallMember
                    {
                        Numbers_of_rows = _f1.rowshall,
                        Number_of_seats = _f1.seatshall

                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputHall(_dataGridHall);
                        if (_dataGridHall.CurrentRow != null)
                        {
                            _dataGridHall.Rows[_dataGridHall.CurrentRow.Index].Selected = false;
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
        private void DeleteHall_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidDeleteHallTable(_f1.idhall))
                {
                    bool res = _hallService.DeleteHalls(new HallMember
                    {
                        HallId = _f1.idhall

                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputHall(_dataGridHall);
                        if (_dataGridHall.CurrentRow != null)
                        {
                            _dataGridHall.Rows[_dataGridHall.CurrentRow.Index].Selected = false;
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
        private void UpdateHall_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddHallTable(_f1.rowshall, _f1.seatshall))
                {
                    bool res = _hallService.UpdateHalls(new HallMember
                    {
                        Numbers_of_rows = _f1.rowshall,
                        Number_of_seats = _f1.seatshall,
                        HallId = _f1.idhall
                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        MessageBox.Show("Данные обновлены!");
                        outputHall(_dataGridHall);
                        if (_dataGridHall.CurrentRow != null)
                        {
                            _dataGridHall.Rows[_dataGridHall.CurrentRow.Index].Selected = false;
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


        public void outputHall(DataGridView dataGridHall)
        {
            dataGridHall.Rows.Clear();

            try
            {
                var res = _hallService.SelectHall();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        dataGridHall.Rows.Add(c.HallId, c.Numbers_of_rows, c.Number_of_seats_in_a_row);
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
