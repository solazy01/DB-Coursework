using System;
using System.Collections.Generic;
using CourseWork.Entities.Function_Other;

namespace CourseWork.Entities.Validation
{
    public class ValidatorsTextBox
    {
        private bool ValidKey;
        public List<string> ErrorStrings { get; set; }
        private string ErrorString { get; set; }


        public ValidatorsTextBox()
        {
            ErrorStrings = new List<string>();
            ValidKey = true;
            ErrorString = "--- Введите корректные значения ---\n" +
                          "------------------------------------\n";
        }

        /*==============================================================================*/

        #region Экипаж

        #region Проверка правильность полей добавления Экипажа

        public bool ValidAddFilm(string id,string Title, string Country,
            string Producer, string Duration, string ReleaseDate,
            string Genre, string BasePrice)
        {
            try
            {
                if (id.Length >=1)
                {
                    ErrorString += "-- Поле ID должно быть пустым!\n";
                    ValidKey = false;
                }

                if (Title == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Title) == true)
                    {
                        ErrorString += "-- В поле Серия паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Country == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Country) == true)
                    {
                        ErrorString += "-- В поле Номер паспорта введен некоректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Producer == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Producer) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Duration == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Duration) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (ReleaseDate == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(ReleaseDate) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Genre == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Genre) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (BasePrice == string.Empty)
                {
                    ErrorString += "-- Поле Должность не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(BasePrice) == true)
                    {
                        ErrorString += "-- В поле Должность введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #region  Проверка правильность полей обновления Экипажа

        public bool ValidUpdateCrew(string Id_Crew,string Serial_Crew, string Num_Crew,
           string FirstName_Crew, string SecondName_Crew, string Patronymic_Crew,
           string PhoneNumber_Crew, string PositionID_Crew, string YachtID_Crew)
        {
            try
            {
                if (Id_Crew == string.Empty)
                {
                    ErrorString += "-- Поле ID не должно быть пустым!\n";
                    ValidKey = false;
                }
               

                if (Serial_Crew == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Serial_Crew) == true)
                    {
                        ErrorString += "-- В поле Серия паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Serial_Crew.Length < 2)
                        {
                            ErrorString += "-- Поле Серия паспорта  должно 2 знака Пример - ЕЕ!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Num_Crew == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Num_Crew) == true)
                    {
                        ErrorString += "-- В поле Номер паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Num_Crew.Length < 6)
                        {
                            ErrorString += "-- Поле Номер паспорта должно иметь 6 знаков Пример - 123456!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (FirstName_Crew == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(FirstName_Crew) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (SecondName_Crew == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(SecondName_Crew) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Patronymic_Crew == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Patronymic_Crew) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (PhoneNumber_Crew.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (PositionID_Crew == string.Empty)
                {
                    ErrorString += "-- Поле Должность не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(PositionID_Crew) == true)
                    {
                        ErrorString += "-- В поле Должность введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (YachtID_Crew == string.Empty)
                {
                    ErrorString += "-- Поле Номер яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(YachtID_Crew) == true)
                    {
                        ErrorString += "-- В поле Номер яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #region Проверка правильность полей удаление Экипажа

        public bool ValidDeleteCrew(string ID_Crew)
        {
            try
            {
                if (ID_Crew == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
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

        #endregion

        /*==============================================================================*/

        #region Должность

        #region  Проверка правильность полей добавления Должности

        public bool ValidAddPosition(string ID_Position,string PositionName_Position, string Salary_Position)
        {
            try
            {

                if (ID_Position.Length >= 1)
                {
                    ErrorString += "-- В поле ID должно быть пустым!\n";
                    ValidKey = false;
                }

                if (PositionName_Position == string.Empty)
                {
                    ErrorString += "-- Поле название должности не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(PositionName_Position) == true)
                    {
                        ErrorString += "-- В поле название должности введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Salary_Position == string.Empty)
                {
                    ErrorString += "-- Поле Зарплата не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Salary_Position) == true)
                    {
                        ErrorString += "-- В поле Зарплата введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (OtherFunction.valids(Salary_Position) == false)
                        {
                            ErrorString += "-- Поле Зарплата не может начинатся с 0\n";
                            ValidKey = false;
                        }
                    }
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

        #region Проверка правильность полей изменения Должности

        public bool ValidUpdatePosition(string ID_Position, string PositionName_Position, string Salary_Position)
        {
            try
            {
                if (ID_Position == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(ID_Position) == true)
                    {
                        ErrorString += "-- В поле ID введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(ID_Position) < 0 || Convert.ToInt32(ID_Position) == 0)
                        {
                            ErrorString += "-- В поле ID не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }

                if (PositionName_Position == string.Empty)
                {
                    ErrorString += "-- Поле название должности не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(PositionName_Position) == true)
                    {
                        ErrorString += "-- В поле название должности введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Salary_Position == string.Empty)
                {
                    ErrorString += "-- Поле Зарплата не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Salary_Position) == true)
                    {
                        ErrorString += "-- В поле Зарплата введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (OtherFunction.valids(Salary_Position) == false)
                        {
                            ErrorString += "-- Поле Зарплата не может начинатся с 0\n";
                            ValidKey = false;
                        }
                    }
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

        #region Проверка правильность полей удаление Должности

        public bool ValidDeletePosition(string ID_Position)
        {
            try
            {
                if (ID_Position == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(ID_Position) == true)
                    {
                        ErrorString += "-- В поле ID введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(ID_Position) < 0 || Convert.ToInt32(ID_Position) == 0)
                        {
                            ErrorString += "-- В поле ID не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
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

        #endregion

        /*==============================================================================*/

        #region Контракт 

        #region Проверка правильность полей добавления Контракта

        public bool ValidAddContract(string id, string StartDate_Contract, string EndDate_Contract,string YachtId_Contract, string ClientId_Contract)
        {
            try
            {
                if (id.Length > 1)
                {
                    ErrorString += "-- Поле ID должно быть пустым\n";
                    ValidKey = false;
                }

                if (StartDate_Contract == string.Empty)
                {
                    ErrorString += "-- Поле начало даты контракт не может быть пустым\n";
                    ValidKey = false;
                }
                

                if (EndDate_Contract == string.Empty)
                {
                    ErrorString += "-- Поле конец даты контракт не может быть пустым\n";
                    ValidKey = false;
                }


                if (Convert.ToDateTime(StartDate_Contract).AddDays(1) < DateTime.Now)
                {
                    ErrorString += "-- Поле начало контракта не должно быть меньше сегодняшнего дня!\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(StartDate_Contract) > Convert.ToDateTime(EndDate_Contract))
                {
                    ErrorString += "-- Поле начало контракта не должно быть больше или равно оканчанию контракта!\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(EndDate_Contract) <= Convert.ToDateTime(StartDate_Contract))
                {
                    ErrorString += "-- Поле окончание контракта не должно быть меньше или равно начале контракта!\n";
                    ValidKey = false;
                }

                if (YachtId_Contract == string.Empty)
                {
                    ErrorString += "-- Поле ID яхты должности не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(YachtId_Contract) == true)
                    {
                        ErrorString += "-- В поле ID яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (ClientId_Contract == string.Empty)
                {
                    ErrorString += "-- Поле ID клиента не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(ClientId_Contract) == true)
                    {
                        ErrorString += "-- В поле ID клиента введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(ClientId_Contract) <= 0)
                        {
                            ErrorString += "-- В поле ID клиента не может быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
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

        #region Проврка правильности полей удаления Контракта 

        public bool ValidDeleteContract(string textBox_ID_Contract)
        {
            try
            {
                if (textBox_ID_Contract == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
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

        #endregion

        /*==============================================================================*/

        #region Соревнование

        #region Проверка правильность полей добавления Соревнования

        public bool ValidAddTournament(string id, string Date_Tournamnet,
          string Name_Tournamnet)
        {
            try
            {
                if (Convert.ToInt32(id) <= 0)
                {
                    ErrorString += "-- Поле ID не может быть меньше равно 0\n";
                    ValidKey = false;
                }

                if (Date_Tournamnet == string.Empty)
                {
                    ErrorString += "-- Поле Дата проведения не может быть пустым\n";
                    ValidKey = false;
                }

                if (Name_Tournamnet == string.Empty)
                {
                    ErrorString += "-- Поле Название соревнования не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Name_Tournamnet) == true)
                    {
                        ErrorString += "-- В поле Название соревнования введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #region  Проверка полей обновление Соревнования

        public bool ValidUpdateTournament(string id,string Date_Tournamnet,
          string Name_Tournamnet, string ID)
        {
            try
            {
                if (Convert.ToInt32(id) <= 0)
                {
                    ErrorString += "-- Поле ID не может быть меньше равно 0\n";
                    ValidKey = false;
                }

                if (Date_Tournamnet == string.Empty)
                {
                    ErrorString += "-- Поле Дата проведения не может быть пустым\n";
                    ValidKey = false;
                }

                if (Name_Tournamnet == string.Empty)
                {
                    ErrorString += "-- Поле Название соревнования не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Name_Tournamnet) == true)
                    {
                        ErrorString += "-- В поле Название соревнования введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (ID == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(ID) == true)
                    {
                        ErrorString += "-- В поле ID введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #region Проврка правильности полей удаления Соревнования

        public bool ValidDeleteTournament(string ID_Tournamnet)
        {
            try
            {
                if (ID_Tournamnet == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(ID_Tournamnet) == true)
                    {
                        ErrorString += "-- В поле ID введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(ID_Tournamnet) <= 0)
                        {
                            ErrorString += "-- Поле ID не может быть меньше равно 0\n";
                            ValidKey = false;
                        }
                    }
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

        #endregion

        /*==============================================================================*/

        #region Участники соревнований

        #region Проверка правильность полей добавления Участники Соревнования

        public bool ValidAddTournamentParticipans(string TournamentId_TournamentParticipan,
          string YachtId_TournamentParticipan, string WinnerYacht_TournamentParticipan)
        {
            try
            {
                if (TournamentId_TournamentParticipan == string.Empty)
                {
                    ErrorString += "-- Поле ID Участникa Соревнования не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(TournamentId_TournamentParticipan) == true)
                    {
                        ErrorString += "-- В поле ID Участникa Соревнования введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (YachtId_TournamentParticipan == string.Empty)
                {
                    ErrorString += "-- Поле ID яхты не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(YachtId_TournamentParticipan) == true)
                    {
                        ErrorString += "-- В поле ID яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (WinnerYacht_TournamentParticipan == string.Empty)
                {
                    ErrorString += "-- Поле занятое место соревнования не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(WinnerYacht_TournamentParticipan) == true)
                    {
                        ErrorString += "-- В поле занятое место введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #region  Проверка полей обновление Участники соревнований

        public bool ValidUpdateTournamentParticipans(string TournamentId_TournamentParticipan,
          string YachtId_TournamentParticipan, string WinnerYacht_TournamentParticipan)
        {
            try
            {
                if (TournamentId_TournamentParticipan == string.Empty)
                {
                    ErrorString += "-- Поле ID Участникa Соревнования не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(TournamentId_TournamentParticipan) == true)
                    {
                        ErrorString += "-- В поле ID Участникa Соревнования введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (YachtId_TournamentParticipan == string.Empty)
                {
                    ErrorString += "-- Поле ID яхты не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(YachtId_TournamentParticipan) == true)
                    {
                        ErrorString += "-- В поле ID яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (WinnerYacht_TournamentParticipan == string.Empty)
                {
                    ErrorString += "-- Поле занятое место  соревнования не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(WinnerYacht_TournamentParticipan) == true)
                    {
                        ErrorString += "-- В поле занятое место введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #region Проврка правильности полей удаления  Участники соревнований

        public bool ValidDeleteTournamentParticipans(string TournamentId_TournamentParticipan,
         string YachtId_TournamentParticipan)
        {
            try
            {
                if (TournamentId_TournamentParticipan == string.Empty)
                {
                    ErrorString += "-- Поле ID Участникa Соревнования не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(TournamentId_TournamentParticipan) == true)
                    {
                        ErrorString += "-- В поле ID Участникa Соревнования введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (YachtId_TournamentParticipan == string.Empty)
                {
                    ErrorString += "-- Поле ID яхты не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(YachtId_TournamentParticipan) == true)
                    {
                        ErrorString += "-- В поле ID яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #endregion

        /*==============================================================================*/

        #region Яхта

        #region Проверка полей правильность добавления Яхты

        public bool ValidAddYacht( string id,string serial_yacht, string number_yacht, string name_yacht, string draught,  string idOwnerYacht, string IssuerYear)
        {
            try
            {
                if (Convert.ToDateTime(IssuerYear) > DateTime.Now)
                {
                    ErrorString += "-- Поле год производства яхты не может бить больше сегодняшего дня\n";
                    ValidKey = false;
                }


                if (id.Length >= 1)
                {
                    ErrorString += "-- Поле ID должно быть пустым!\n";
                    ValidKey = false;
                }

                if (serial_yacht == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(serial_yacht) == true)
                    {
                        ErrorString += "-- В поле Серия паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (serial_yacht.Length < 3)
                        {
                            ErrorString += "-- Поле Серия паспорта  должно 2 знака Пример - ЕЕE!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (number_yacht == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(number_yacht) == true)
                    {
                        ErrorString += "-- В поле Номер паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (number_yacht.Length < 6)
                        {
                            ErrorString += "-- Поле Номер паспорта должно иметь 6 знаков Пример - 123456!\n";
                            ValidKey = false;
                        }
                    }
                }


                if (name_yacht == string.Empty)
                {
                    ErrorString += "-- Поле Название яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(name_yacht) == true)
                    {
                        ErrorString += "-- В поле Название яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (draught == string.Empty)
                {
                    ErrorString += "-- Поле Водоизмещени яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(draught) == true)
                    {
                        ErrorString += "-- В поле Водоизмещени яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(draught) <= 0)
                        {
                            ErrorString += "-- Поле Водоизмещени яхты не должно быть меньше или равно 0\n";
                            ValidKey = false;
                        }
                    }
                }


                if (idOwnerYacht == string.Empty)
                {
                    ErrorString += "-- Поле ID владельца яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(idOwnerYacht) == true)
                    {
                        ErrorString += "-- В поле ID владельца яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idOwnerYacht) <= 0)
                        {
                            ErrorString += "--Поле ID владельца яхты не может быть меньше или равно 0!\n";
                            ValidKey = false;
                        }
                    }
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

        #region Проверка полей правильность Обновление Яхты
        public bool ValidUpdateYacht(string ID_Yacht,string serial_yacht, string number_yacht, string name_yacht, string draught,  string idOwnerYacht, string IssuerYear)
        {
            try
            {
                if (Convert.ToDateTime(IssuerYear) > DateTime.Now)
                {
                    ErrorString += "-- Поле год производства яхты не может бить больше сегодняшего дня\n";
                    ValidKey = false;
                }


                if (ID_Yacht == string.Empty)
                {
                    ErrorString += "-- Поле ID не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (serial_yacht == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(serial_yacht) == true)
                    {
                        ErrorString += "-- В поле Серия паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (serial_yacht.Length < 3)
                        {
                            ErrorString += "-- Поле Серия паспорта  должно 2 знака Пример - ЕЕE!\n";
                            ValidKey = false;
                        }
                    }
                }


                if (number_yacht == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(number_yacht) == true)
                    {
                        ErrorString += "-- В поле Номер паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (number_yacht.Length < 6)
                        {
                            ErrorString += "-- Поле Номер паспорта должно иметь 6 знаков Пример - 123456!\n";
                            ValidKey = false;
                        }
                    }
                }


                if (name_yacht == string.Empty)
                {
                    ErrorString += "-- Поле Название яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(name_yacht) == true)
                    {
                        ErrorString += "-- В поле Название яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (draught == string.Empty)
                {
                    ErrorString += "-- Поле Водоизмещени яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(draught) == true)
                    {
                        ErrorString += "-- В поле Водоизмещени яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                }


                if (idOwnerYacht == string.Empty)
                {
                    ErrorString += "-- Поле ID владельца яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(idOwnerYacht) == true)
                    {
                        ErrorString += "-- В поле ID владельца яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(idOwnerYacht) <= 0)
                        {
                            ErrorString += "--Поле ID владельца яхты не может быть меньше или равно 0!\n";
                            ValidKey = false;
                        }
                    }
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

        #region Проверка полей правильность Удаление Яхты

        public bool ValidDeleteYacht(string id_Yacht)
        {
            try
            {
                if (id_Yacht == string.Empty)
                {
                    ErrorString += "-- Поле ID яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(id_Yacht) == true)
                    {
                        ErrorString += "-- В поле ID яхты  введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #endregion

        /*==============================================================================*/

        #region Владелец

        #region Проверка полей правильности Добавления 

        public bool ValidAddOwner(string ownerid,string login,string password, string serial_Owner, string Num_Owner, string FirstName_Owner, string SecondName_Owner,
            string Patronymic_Owner,string PhoneNumber_Owner)
        {
            try
            {
                if (ownerid.Length >= 1)
                {
                    ErrorString += "-- Поле ID должно быть пустым!\n";
                    ValidKey = false;
                }


                if (login == string.Empty)
                {
                    ErrorString += "-- Поле Логин не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(login) == true)
                    {
                        ErrorString += "-- В поле Логин введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (password == string.Empty)
                {
                    ErrorString += "-- Поле Пароль не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (serial_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(serial_Owner) == true)
                    {
                        ErrorString += "-- В поле Серия паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (serial_Owner.Length < 2)
                        {
                            ErrorString += "-- Поле Серия паспорта  должно 2 знака Пример - ЕЕ!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Num_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Num_Owner) == true)
                    {
                        ErrorString += "-- В поле Номер паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Num_Owner.Length < 6)
                        {
                            ErrorString += "-- Поле Номер паспорта должно иметь 6 знаков Пример - 123456!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (FirstName_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(FirstName_Owner) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (SecondName_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(SecondName_Owner) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Patronymic_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Patronymic_Owner) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (PhoneNumber_Owner.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
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

        #region Проверка полей правильности Обновления

        public bool ValidUpdateOwner(string id_owner,string serial_Owner, string Num_Owner, string FirstName_Owner, string SecondName_Owner,
           string Patronymic_Owner, string PhoneNumber_Owner)
        {
            try
            {
                if (id_owner == string.Empty)
                {
                    ErrorString += "-- Поле ID не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (serial_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(serial_Owner) == true)
                    {
                        ErrorString += "-- В поле Серия паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (serial_Owner.Length < 2)
                        {
                            ErrorString += "-- Поле Серия паспорта  должно 2 знака Пример - ЕЕ!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Num_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Num_Owner) == true)
                    {
                        ErrorString += "-- В поле Номер паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Num_Owner.Length < 6)
                        {
                            ErrorString += "-- Поле Номер паспорта должно иметь 6 знаков Пример - 123456!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (FirstName_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(FirstName_Owner) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (SecondName_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(SecondName_Owner) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Patronymic_Owner == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Patronymic_Owner) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (PhoneNumber_Owner.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
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

        #region Проверка полей правильности Удаления 

        public bool ValidDeleteOwner(string id_owner)
        {
            try
            {
                if (id_owner == string.Empty)
                {
                    ErrorString += "-- Поле ID не должно быть пустым!\n";
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

        #endregion

        /*==============================================================================*/

        #region Клиенты

        #region Проверка полей правильности Обновления Клиента

        public bool ValidUpdateClient(string id_Client, string serial_Client, string Num_Client, string FirstName_Client, string SecondName_Client,
           string Patronymic_Client, string PhoneNumber_Client)
        {
            try
            {
                if (id_Client == string.Empty)
                {
                    ErrorString += "-- Поле ID не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (serial_Client == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(serial_Client) == true)
                    {
                        ErrorString += "-- В поле Серия паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (serial_Client.Length < 2)
                        {
                            ErrorString += "-- Поле Серия паспорта  должно 2 знака Пример - ЕЕ!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (Num_Client == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Num_Client) == true)
                    {
                        ErrorString += "-- В поле Номер паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Num_Client.Length < 6)
                        {
                            ErrorString += "-- Поле Номер паспорта должно иметь 6 знаков Пример - 123456!\n";
                            ValidKey = false;
                        }
                    }
                }

                if (FirstName_Client == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(FirstName_Client) == true)
                    {
                        ErrorString += "-- В поле Фамилия введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (SecondName_Client == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(SecondName_Client) == true)
                    {
                        ErrorString += "-- В поле Имя введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Patronymic_Client == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Patronymic_Client) == true)
                    {
                        ErrorString += "-- В поле Отчество введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (PhoneNumber_Client.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
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

        #region Проверка полей правильности Удаления Клиента

        public bool ValidDeleteClient(string id_Client)
        {
            try
            {
                if (id_Client == string.Empty)
                {
                    ErrorString += "-- Поле ID не должно быть пустым!\n";
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

        #endregion

        /*==============================================================================*/

        #region Login

        #region Проверка полей входа в систему 

        public bool ValidLogin(string Login, string Password)
        {
            try
            {
                if (Login == string.Empty)
                {
                    ErrorString += "-- Поле Логин не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (Password == string.Empty)
                {
                    ErrorString += "-- Поле Пароль не должно быть пустым!\n";
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

        #endregion

        /*==============================================================================*/

        #region Registration

        #region Проверка полей регистрации в системе

        public bool ValidRegistration(string Login, string Password, string serial_Client, string Num_Client, string FirstName_Client, string SecondName_Client,
            string Patronymic_Client, string PhoneNumber_Client)
        {
            try
            {
                if (Login == string.Empty)
                {
                    ErrorString += "-- Поле Логин не должно быть пустым!\n";
                    ValidKey = false;
                }
                

                if (Password == string.Empty)
                {
                    ErrorString += "-- Поле Пароль не должно быть пустым!\n";
                    ValidKey = false;
                }



                if (serial_Client == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (serial_Client.Length < 2)
                    {
                        ErrorString += "-- Поле Серия паспорта должно содержать 2 символа\n";
                        ValidKey = false;
                    }
                }


                if (Num_Client == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (Num_Client.Length < 6)
                    {
                        ErrorString += "-- В поле Номер паспорта должно содержать 6 символа\n";
                        ValidKey = false;
                    }
                }


                if (FirstName_Client == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (SecondName_Client == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                

                if (Patronymic_Client == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (PhoneNumber_Client.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
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

        #endregion

        /*==============================================================================*/

        #region FormsClient

        #region Проверка добавления контракта 

        public bool ValidAddContractForms(string Yacht, string startdate, string enddate)
        {
            try
            {
                

                if (Yacht == string.Empty)
                {
                    ErrorString += "-- Поле Яхта не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(startdate).AddDays(1) < DateTime.Now)
                {
                    ErrorString += "-- Поле начало контракта не должно быть меньше сегодняшнего дня!\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(startdate) > Convert.ToDateTime(enddate))
                {
                    ErrorString += "-- Поле начало контракта не должно быть больше или равно оканчанию контракта!\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(enddate) <= Convert.ToDateTime(startdate))
                {
                    ErrorString += "-- Поле окончание контракта не должно быть меньше или равно начале контракта!\n";
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

        #region Проверка полей Обновления персональных  данных

        public bool ValidUpdatePrivateData(string FirstName, string SecondName,string Patrynomic, string PhoneNumber )
        {
            try
            {
                
                if (FirstName == string.Empty)
                {
                    ErrorString += "-- Поле Фамилия не должно быть пустым!\n";
                    ValidKey = false;
                }
                

                if (SecondName == string.Empty)
                {
                    ErrorString += "-- Поле Имя не должно быть пустым!\n";
                    ValidKey = false;
                }
                

                if (Patrynomic == string.Empty)
                {
                    ErrorString += "-- Поле Отчество не должно быть пустым!\n";
                    ValidKey = false;
                }
                

                if (PhoneNumber.Length < 15)
                {
                    ErrorString += "-- Поле Номер телефона не должно быть пустым!\n";
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

        #region Проврка полей обновления логина

        public bool ValidUpdateNewLogin(string newLogin)
        {
            try
            {
                if (newLogin == string.Empty)
                {
                    ErrorString += "-- Поле Новый логин не должно быть пустым!\n";
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

        #region Проверка полей обновления пароль

        public bool ValidUpdateNewPassword(string oldPassword, string newPassword)
        {
            try
            {
                if (oldPassword == string.Empty)
                {
                    ErrorString += "-- Поле Страрый пароль не должно быть пустым!\n";
                    ValidKey = false;
                }
                

                if (newPassword == string.Empty)
                {
                    ErrorString += "-- Поле Новый пароль не должно быть пустым!\n";
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

        #endregion

        /*==============================================================================*/

        #region FormsOwner

        #region Проверка добаления яхты

        public bool ValidAddYachtOwner(string id, string serial, string number, string yachtName, string Draught, string IssuerYear)
        {
            try
            {
                if (id.Length >= 1)
                {
                    ErrorString += "-- Поле ID должно быть пустым!\n";
                    ValidKey = false;
                }

                if (Convert.ToDateTime(IssuerYear) > DateTime.Now)
                {
                    ErrorString += "-- Поле год производства яхты не может бить больше сегодняшего дня\n";
                    ValidKey = false;
                }

                if (serial == string.Empty)
                {
                    ErrorString += "-- Поле Серия паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(serial) == true)
                    {
                        ErrorString += "-- В поле Серия паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (serial.Length < 3)
                        {
                            ErrorString += "-- В поле Серия паспорта иметь 3 знака Пример - УУУ \n";
                            ValidKey = false;
                        }
                    }
                }

                if (number == string.Empty)
                {
                    ErrorString += "-- Поле Номер паспорта не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(number) == true)
                    {
                        ErrorString += "-- В поле Номер паспорта введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (number.Length < 6)
                        {
                            ErrorString += "-- В поле Номер паспорта должно иметь 6 знаков Пример - 123456\n";
                            ValidKey = false;
                        }
                    }
                }

                if (yachtName == string.Empty)
                {
                    ErrorString += "-- Поле Названия яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(yachtName) == true)
                    {
                        ErrorString += "-- В поле Названия яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
                }

                if (Draught == string.Empty)
                {
                    ErrorString += "-- Поле Водоизмещение не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(Draught) == true)
                    {
                        ErrorString += "-- В поле Водоизмещение введен не коректный символ\n";
                        ValidKey = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Draught) <= 0)
                        {
                            ErrorString += "-- В поле Водоизмещение не может быть меньше равно 0\n";
                            ValidKey = false;
                        }
                    }
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

        #region Проверка обновления яхты

        public bool ValidUpdateYachtOwner(string id, string yachtName)
        {
            try
            {
                if (id == string.Empty)
                {
                    ErrorString += "-- Поле ID не должно быть пустым!\n";
                    ValidKey = false;
                }

                if (yachtName == string.Empty)
                {
                    ErrorString += "-- Поле Названия яхты не должно быть пустым!\n";
                    ValidKey = false;
                }
                else
                {
                    if (OtherFunction.valid(yachtName) == true)
                    {
                        ErrorString += "-- В поле Названия яхты введен не коректный символ\n";
                        ValidKey = false;
                    }
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

        #endregion
    }
}
