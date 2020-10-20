using System;
using System.Windows.Forms;
using BL.Admin.Interface;
using BL.Admin.DomainObjects;
using Entities.Function;

namespace CourseWork.Controllers
{
    class AdminStaffHall
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private string errorDataGridCellClick = "Эта строка пуста";
        private AdminForm _f1;

        private IStaffHallService _staffhallService;
        private IStaffService _staffService;

        private DataGridView _dataGridStaffHall;
        private Button _addStaffHall;
        private Button _deleteStaffHall;
        private Button _updateStaffHall;

        private ComboBox _staffId;


        public AdminStaffHall(AdminForm f1, IStaffHallService staffhallService, IStaffService staffService)
        {
            _staffhallService = staffhallService;
            _staffService = staffService;

            _f1 = f1;

            _f1.Load += Form1_Load;

            _dataGridStaffHall = _f1.DataGridstaffhall;
            _dataGridStaffHall.CellClick += dataGridStaffHall_CellClick;

            _addStaffHall = _f1.addStaffHall;
            _addStaffHall.Click += AddStaffHall_Click;


            _deleteStaffHall = _f1.deleteStaffHall;
            _deleteStaffHall.Click += DeleteStaffHall_Click;

            _updateStaffHall = _f1.updateStaffHall;
            _updateStaffHall.Click += UpdateStaffHall_Click;

            _staffId = _f1.staffhallsid;
            _staffId.Click += StaffHallSID_Click;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputStaffHall(_dataGridStaffHall);
        }


        #region Обработчик, заполняющий TextBox при нажатии на ячейку

        private void dataGridStaffHall_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridStaffHall.CurrentRow != null)
                {
                    _f1.staffhallhid = _dataGridStaffHall.Rows[_dataGridStaffHall.CurrentRow.Index].Cells[0].Value.ToString();
                    _f1.staffhallsid.Text = _dataGridStaffHall.Rows[_dataGridStaffHall.CurrentRow.Index].Cells[1].Value.ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(errorDataGridCellClick);
            }
        }

        #endregion

        #region Add

        private void AddStaffHall_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = _staffhallService.InsertStaffHalls(new StaffHallMember
                {
                    HallId = _f1.staffhallhid,
                    StaffId = Convert.ToString(FunctionOther.GetNumber(_f1.staffhallsid.Text))

                });
                if (res == false)
                {
                    MessageBox.Show("Не удалось выполнить запрос!");
                }
                else
                {
                    outputStaffHall(_dataGridStaffHall);
                    if (_dataGridStaffHall.CurrentRow != null)
                    {
                        _dataGridStaffHall.Rows[_dataGridStaffHall.CurrentRow.Index].Selected = false;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(errorController);
            }
        }

        #endregion

        #region Delete
        private void DeleteStaffHall_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = _staffhallService.DeleteStaffHalls(new StaffHallMember
                {
                    HallId = _f1.staffhallhid,
                    StaffId = Convert.ToString(FunctionOther.GetNumber(_f1.staffhallsid.Text))

                });
                if (res == false)
                {
                    MessageBox.Show("Не удалось выполнить запрос!");
                }
                else
                {
                    outputStaffHall(_dataGridStaffHall);
                    if (_dataGridStaffHall.CurrentRow != null)
                    {
                        _dataGridStaffHall.Rows[_dataGridStaffHall.CurrentRow.Index].Selected = false;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(errorController);
            }
        }


        #endregion

        #region Update
        private void UpdateStaffHall_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = _staffhallService.UpdateStaffHalls(new StaffHallMember
                {
                    HallId = _f1.staffhallhid,
                    StaffId = Convert.ToString(FunctionOther.GetNumber(_f1.staffhallsid.Text))
                });
                if (res == false)
                {
                    MessageBox.Show("Не удалось выполнить запрос!");
                }
                else
                {
                    MessageBox.Show("Данные обновлены!");
                    outputStaffHall(_dataGridStaffHall);
                    if (_dataGridStaffHall.CurrentRow != null)
                    {
                        _dataGridStaffHall.Rows[_dataGridStaffHall.CurrentRow.Index].Selected = false;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(errorController);
            }
        }

        #endregion



        public void outputStaffHall(DataGridView dataGridStaffHall)
        {
            dataGridStaffHall.Rows.Clear();

            try
            {
                var res = _staffhallService.SelectStaffHall();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        dataGridStaffHall.Rows.Add(c.HallId, c.StaffId);
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


        private void StaffHallSID_Click(object sender, EventArgs e)
        {
            _staffId.Items.Clear();

            try
            {
                var res = _staffService.SelectStaffID();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        _staffId.Items.Add(c.Name);
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
