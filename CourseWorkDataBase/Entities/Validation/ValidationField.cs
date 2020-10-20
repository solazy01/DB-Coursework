using System;
using System.Collections.Generic;

namespace Entities.ValidationField
{
    public class ValidationField
    {
        private bool ValidKey;
        public List<string> ErrorStrings { get; set; }
        private string ErrorString { get; set; }


        public ValidationField()
        {
            ErrorStrings = new List<string>();
            ValidKey = true;
            ErrorString = "--- Введите корректные значения ---\n" +
                          "-----------------------------------\n";
        }


        #region Films
                public bool ValidAddFilmsTable(string title, string country, string producer, string duration, string date, string genre, string baseprice)
                {
                    try
                    {
                        if (title == string.Empty)
                        {
                            ErrorString += "-- Поле названия не должно быть пустым!\n";
                            ValidKey = false;
                        }

                        if (country == string.Empty)
                        {
                            ErrorString += "-- Поле страна не должно быть пустым!\n";
                            ValidKey = false;
                        }

                        if (producer == string.Empty)
                        {
                            ErrorString += "-- Поле продюссер не должно быть пустым!\n";
                            ValidKey = false;
                        }

                        if (duration == string.Empty)
                        {
                            ErrorString += "-- Поле длительности не должно быть пустым!\n";
                            ValidKey = false;
                        }

                        if (date == string.Empty)
                        {
                            ErrorString += "-- Поле даты не должно быть пустым!\n";
                            ValidKey = false;
                        }

                        if (genre == string.Empty)
                        {
                            ErrorString += "-- Поле жанра не должно быть пустым!\n";
                            ValidKey = false;
                        }

                        if (baseprice == string.Empty)
                        {
                            ErrorString += "-- Поле цены не должно быть пустым!\n";
                            ValidKey = false;
                        }


                        if (duration.Length < 8)
                        {
                            ErrorString += "-- Длительность указана некорректно\n";
                            ValidKey = false;
                        }


                        if (date.Length < 10)
                        {
                            ErrorString += "-- Дата указана некорректно\n";
                            ValidKey = false;
                        }

                        if (ValidKey)
                        {
                            return ValidKey;
                        }
                        else
                        {
                            ErrorStrings.Add(ErrorString);
                            return ValidKey;
                        }
                    }
                    finally
                    {
                        ValidKey = true;
                        ErrorString = "--- Введите корректные значения ---\n" +
                                      "-----------------------------------------\n";
                    }
                }

                public bool ValidDeleteFilmsTable(string id)
                {
                    try
                    {
                        if (id == string.Empty)
                        {
                            ErrorString += "-- Выберете строку, которую нужно удалить!\n";
                            ValidKey = false;
                        }
                        if (ValidKey)
                        {
                            return ValidKey;
                        }
                        else
                        {
                            ErrorStrings.Add(ErrorString);
                            return ValidKey;
                        }
            
                    }
                    finally
                    {
                        ValidKey = true;
                        ErrorString = "--- Введите корректные значения ---\n" +
                                      "-----------------------------------------\n";
                    }
                }
                #endregion

        #region Session
                public bool ValidAddSessionTable(string date, string time, string hallid)
                {
                    try
                    {

                        if (date.Length < 10)
                        {
                            ErrorString += "-- Поле дата заполненно некорректно!\n";
                            ValidKey = false;
                        }

                        if (time.Length  < 8)
                        {
                            ErrorString += "-- Поле время заполненно некорректно!\n";
                            ValidKey = false;
                        }

                        if (hallid == string.Empty)
                        {
                            ErrorString += "-- Поле номер зала не должно быть пустым!\n";
                            ValidKey = false;
                        }



                        if (ValidKey)
                        {
                            return ValidKey;
                        }
                        else
                        {
                            ErrorStrings.Add(ErrorString);
                            return ValidKey;
                        }
                    }
                    finally
                    {
                        ValidKey = true;
                        ErrorString = "--- Введите корректные значения ---\n" +
                                      "-----------------------------------------\n";
                    }
                }
                public bool ValidDeleteSessionTable(string id)
                {
                    try
                    {
                        if (id == string.Empty)
                        {
                            ErrorString += "-- Выберете строку, которую нужно удалить!\n";
                            ValidKey = false;
                        }
                        if (ValidKey)
                        {
                            return ValidKey;
                        }
                        else
                        {
                            ErrorStrings.Add(ErrorString);
                            return ValidKey;
                        }

                    }
                    finally
                    {
                        ValidKey = true;
                        ErrorString = "--- Введите корректные значения ---\n" +
                                      "-----------------------------------------\n";
                    }
                }
                #endregion

        #region Hall
                public bool ValidAddHallTable(string row, string seat)
                {
                    try
                    {

                        if (row == string.Empty)
                        {
                            ErrorString += "-- Поле количество рядов не должно быть пустым!\n";
                            ValidKey = false;
                        }

                        if (seat == string.Empty)
                        {
                            ErrorString += "-- Поле количество мест в ряду не должно быть пустым!\n";
                            ValidKey = false;
                        }


                        if (ValidKey)
                        {
                            return ValidKey;
                        }
                        else
                        {
                            ErrorStrings.Add(ErrorString);
                            return ValidKey;
                        }
                    }
                    finally
                    {
                        ValidKey = true;
                        ErrorString = "--- Введите корректные значения ---\n" +
                                      "-----------------------------------------\n";
                    }
                }
                public bool ValidDeleteHallTable(string id)
                {
                    try
                    {
                        if (id == string.Empty)
                        {
                            ErrorString += "-- Выберете строку, которую нужно удалить!\n";
                            ValidKey = false;
                        }
                        if (ValidKey)
                        {
                            return ValidKey;
                        }
                        else
                        {
                            ErrorStrings.Add(ErrorString);
                            return ValidKey;
                        }

                    }
                    finally
                    {
                        ValidKey = true;
                        ErrorString = "--- Введите корректные значения ---\n" +
                                      "-----------------------------------------\n";
                    }
                }
                #endregion

        #region Staff
        public bool ValidAddStaffTable(string surname, string name, string patronymic, string position, string birthdate, string entrydate)
        {
            try
            {
                if (surname == string.Empty)
                {
                    ErrorString += "-- Поле фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (name == string.Empty)
                {
                    ErrorString += "-- Поле имя не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (patronymic == string.Empty)
                {
                    ErrorString += "-- Поле отчество не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (position == string.Empty)
                {
                    ErrorString += "-- Поле должность не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (birthdate.Length < 10)
                {
                    ErrorString += "-- Поле даты не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (entrydate.Length < 10)
                {
                    ErrorString += "-- Поле жанр не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidDeleteStaffTable(string id)
        {
            try
            {
                if (id == string.Empty)
                {
                    ErrorString += "-- Выберете строку, которую нужно удалить!\n";
                    ValidKey = false;
                }
                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }
        #endregion

        #region Tickets
        public bool ValidAddTicketsTable(string sessionid, string row, string seat, string zone, string recall)
        {
            try
            {

                if (sessionid == string.Empty)
                {
                    ErrorString += "-- Поле id сеанса не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (row == string.Empty)
                {
                    ErrorString += "-- Поле ряд не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (seat == string.Empty)
                {
                    ErrorString += "-- Поле место не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (zone == string.Empty)
                {
                    ErrorString += "-- Поле зона не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (recall != "0" & recall != "1" & recall != "2" & recall != "3" & recall != "4" & recall != "5" )
                {
                    ErrorString += "-- Отзыв должен иметь цифровое значение от 0 до 5!\n";
                    ValidKey = false;
                }



                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidAddTicketsTableC(string row, string seat, string zone, string recall)
        {
            try
            {

                if (row == string.Empty)
                {
                    ErrorString += "-- Поле ряд не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (seat == string.Empty)
                {
                    ErrorString += "-- Поле место не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (zone == string.Empty)
                {
                    ErrorString += "-- Поле зона не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (recall != "0" & recall != "1" & recall != "2" & recall != "3" & recall != "4" & recall != "5")
                {
                    ErrorString += "-- Отзыв должен иметь цифровое значение от 0 до 5!\n";
                    ValidKey = false;
                }



                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }
        public bool ValidDeleteTicketsTable(string id)
        {
            try
            {
                if (id == string.Empty)
                {
                    ErrorString += "-- Выберете строку, которую нужно удалить!\n";
                    ValidKey = false;
                }
                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    ErrorStrings.Add(ErrorString);
                    return ValidKey;
                }

            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }
        #endregion
    }
}
