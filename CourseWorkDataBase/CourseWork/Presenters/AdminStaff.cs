using System;
using System.Windows.Forms;
using BL.Admin.Interface;
using BL.Admin.DomainObjects;
using Entities.ValidationField;

namespace CourseWork.Controllers
{
    public class AdminStaff
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private string errorDataGridCellClick = "Эта строка пуста";
        private AdminForm _f1;

        private IStaffService _staffService;

        ValidationField _valid;

        private DataGridView _dataGridStaff;
        private Button _addStaff;
        private Button _deleteStaff;
        private Button _updateStaff;

        private ComboBox _role;
        private ComboBox _Position;


        public AdminStaff(AdminForm f1, IStaffService staffService, ValidationField valid)
        {
            _valid = valid;
            _staffService = staffService;

            _f1 = f1;

            _f1.Load += Form1_Load;

            _dataGridStaff = _f1.DataGridstaff;
            _dataGridStaff.CellClick += dataGridStaff_CellClick;

            _addStaff = _f1.addStaff;
            _addStaff.Click += AddStaff_Click;


            _deleteStaff = _f1.deleteStaff;
            _deleteStaff.Click += DeleteStaff_Click;

            _updateStaff = _f1.updateStaff;
            _updateStaff.Click += UpdateStaff_Click;

            _role = _f1.staffvacant;
            _role.Click += ClickRole;

            _Position = _f1.staffPosition;
            _Position.Click += ClickPosition;

            _role.DropDownStyle = ComboBoxStyle.DropDownList;
            _Position.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            outputStaff(_dataGridStaff);
        }



        #region Обработчик, заполняющий TextBox при нажатии на ячейку

        private void dataGridStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_dataGridStaff.CurrentRow != null)
                {
                    _f1.idstaff = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[0].Value.ToString();
                    _f1.stafffname = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[1].Value.ToString();
                    _f1.stafflname = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[2].Value.ToString();
                    _f1.staffpatronymic = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[3].Value.ToString();
                    _f1.staffposition = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[4].Value.ToString();
                    _f1.staffbirth = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[5].Value.ToString();
                    _f1.staffentry = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[6].Value.ToString();

                    _f1.stafflogin = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[7].Value.ToString();
                    _f1.staffvacant.Text = _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Cells[8].Value.ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(errorDataGridCellClick);
            }
        }

        #endregion

        #region Add

        private void AddStaff_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddStaffTable(_f1.stafffname, _f1.stafflname, _f1.staffpatronymic, _f1.staffposition, _f1.staffbirth, _f1.staffentry))
                {
                    bool res = _staffService.InsertStaffs(new StaffMember
                    {
                        FirstName = _f1.stafffname,
                        SecondName = _f1.stafflname,
                        Patronymic = _f1.staffpatronymic,
                        Position = _f1.staffposition,
                        BirthDate = _f1.staffbirth,
                        EntryDate = _f1.staffentry,
                        Login = _f1.stafflogin,
                        Password = _f1.staffpass,
                        Role = _f1.staffvacant.Text

                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputStaff(_dataGridStaff);
                        if (_dataGridStaff.CurrentRow != null)
                        {
                            _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Selected = false;
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
        private void DeleteStaff_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidDeleteStaffTable(_f1.stafflogin))
                {
                    bool res = _staffService.DeleteStaffs(new StaffMember
                    {
                        Login = _f1.stafflogin

                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        outputStaff(_dataGridStaff);
                        if (_dataGridStaff.CurrentRow != null)
                        {
                            _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Selected = false;
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
        private void UpdateStaff_Click(object sender, EventArgs e)
        {
            try
            {
                if (_valid.ValidAddStaffTable(_f1.stafffname, _f1.stafflname, _f1.staffpatronymic, _f1.staffposition, _f1.staffbirth, _f1.staffentry))
                {
                    bool res = _staffService.UpdateStaffs(new StaffMember
                    {
                        FirstName = _f1.stafffname,
                        SecondName = _f1.stafflname,
                        Patronymic = _f1.staffpatronymic,
                        Position = _f1.staffposition,
                        BirthDate = _f1.staffbirth,
                        EntryDate = _f1.staffentry,
                        StaffId = _f1.idstaff,
                        Login = _f1.stafflogin,
                        Password = _f1.staffpass,
                        Role = _f1.staffvacant.Text
                    });
                    if (res == false)
                    {
                        MessageBox.Show("Не удалось выполнить запрос!");
                    }
                    else
                    {
                        MessageBox.Show("Данные обновлены!");
                        outputStaff(_dataGridStaff);
                        if (_dataGridStaff.CurrentRow != null)
                        {
                            _dataGridStaff.Rows[_dataGridStaff.CurrentRow.Index].Selected = false;
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

        private void ClickRole(object sender, EventArgs e)
        {
            _role.Items.Clear();

            try
            {
                var res = _staffService.SelectRole();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        _role.Items.Add(c.Name);
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

        private void ClickPosition(object sender, EventArgs e)
        {
            _Position.Items.Clear();

            try
            {
                var res = _staffService.SelectPosition();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        _Position.Items.Add(c.Name);
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


        public void outputStaff(DataGridView dataGridStaff)
        {
            dataGridStaff.Rows.Clear();

            try
            {
                var res = _staffService.SelectStaff();

                if (res.IsValid)
                {
                    foreach (var c in res.ResultObject)
                    {
                        dataGridStaff.Rows.Add(c.StaffId, c.FirstName, c.SecondName, c.Patronymic, c.Position, c.BirthDate,
                             c.EntryDate, c.Login, c.Role);
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
