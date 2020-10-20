using System;
using System.Windows.Forms;
using BL.Admin.Service;
using BL.Login.Service;
using CourseWork.Controllers;
using CourseWork.Controllers.LoginController;
using DAL.Admin.Repository;
using DAL.Login.Repository;
using Entities.Security;
using CourseWork.Controllers.CashierControllers;
using DAL.Cashier.Repository;
using BL.Cashier.Service;
using Entities.ValidationField;
using DAL.Cleaner;
using CourseWork.Presenters;
using BL.Cleaner;

namespace CourseWork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            AuthForm f2 = new AuthForm();

            ValidationField valid = new ValidationField();

            string connectionStringLogin =
                String.Format("Server={0}; Port={1};" + "User Id={2}; Password={3}; Database={4};",
                    DES.Decrypt("6LiCDo8gfjbrOYXuRWqbKw==", true),
                    DES.Decrypt("ecO+kizstzM=", true),
                    DES.Decrypt("TadpY3GnE3o=", true),
                    DES.Decrypt("G5V2n3PhQBo=", true),
                    DES.Decrypt("04ZE2yXOXwww9p6ZbFbp9A==", true)
                );


            LoginRepository loginRepository = new LoginRepository(connectionStringLogin);
            LoginService loginService = new LoginService(loginRepository);

            LoginPresenter loginPresenter = new LoginPresenter(f2, loginService);



            Application.Run(f2);

            /*============================================================================================*/


            switch (loginPresenter.Vacant)
            {
                case "admin":
                    { 
                        AdminForm f1 = new AdminForm();


                        string connectionString =
                            String.Format("Server={0}; Port={1};" + "User Id={2}; Password={3}; Database={4};",
                                DES.Decrypt("6LiCDo8gfjbrOYXuRWqbKw==", true),
                                DES.Decrypt("ecO+kizstzM=", true),
                                "admin",
                                DES.Decrypt("hfeeVI+gSGA=", true),
                                DES.Decrypt("04ZE2yXOXwww9p6ZbFbp9A==", true)
                            );

                        FilmsRepository filmsRepository = new FilmsRepository(connectionString);
                        FilmsService filmsService = new FilmsService(filmsRepository);

                        AdminFilms adminFilms = new AdminFilms(f1, filmsService, valid);


                        SessionRepository sessionRepository = new SessionRepository(connectionString);
                        SessionService sessionService = new SessionService(sessionRepository);

                        AdminSession adminSession = new AdminSession(f1, sessionService, filmsService, valid);


                        TicketsRepository ticketsRepository = new TicketsRepository(connectionString);
                        TicketsService ticketsService = new TicketsService(ticketsRepository);

                        AdminTickets adminTickets = new AdminTickets(f1, ticketsService, valid);


                        StaffRepository staffRepository = new StaffRepository(connectionString);
                        StaffService staffService = new StaffService(staffRepository);

                        AdminStaff adminStaff = new AdminStaff(f1, staffService, valid);


                        HallRepository hallRepository = new HallRepository(connectionString);
                        HallService hallService = new HallService(hallRepository);

                        AdminHall adminHall = new AdminHall(f1, hallService, valid);


                        StaffHallRepository staffhallRepository = new StaffHallRepository(connectionString);
                        StaffHallService staffhallService = new StaffHallService(staffhallRepository);

                        AdminStaffHall adminStaffHall = new AdminStaffHall(f1, staffhallService, staffService);

                        Application.Run(f1);
                    }break;
                case "cashier":
                {

                    CashierForm f3 = new CashierForm();


                    string connectionString =
                        String.Format("Server={0}; Port={1};" + "User Id={2}; Password={3}; Database={4};",
                            DES.Decrypt("6LiCDo8gfjbrOYXuRWqbKw==", true),
                            DES.Decrypt("ecO+kizstzM=", true),
                            "cashier",
                            DES.Decrypt("DvWyPJXmeps=", true),
                            DES.Decrypt("04ZE2yXOXwww9p6ZbFbp9A==", true)
                        );


                    FilmsRepositoryC  filmsRepository = new FilmsRepositoryC(connectionString);
                    FilmsServiceC filmsService = new FilmsServiceC(filmsRepository);

                    CashierFilms cashireFilms = new CashierFilms(f3, filmsService);

                    SessionRepositoryC sessionRepository = new SessionRepositoryC(connectionString);
                    SessionServiceC sessionService = new SessionServiceC(sessionRepository);

                    CashierSession cashireSession = new CashierSession(f3, sessionService);

                    TicketsRepositoryC ticketsRepository = new TicketsRepositoryC(connectionString);
                    TicketsServiceC ticketsService = new TicketsServiceC(ticketsRepository);

                    CashireTickets cashireTickets = new CashireTickets(f3, ticketsService, valid);

                    Application.Run(f3);
                }break;
                case "cleaner":
                    {
                        CleanerForm f4 = new CleanerForm();


                        string connectionString =
                            String.Format("Server={0}; Port={1};" + "User Id={2}; Password={3}; Database={4};",
                                DES.Decrypt("6LiCDo8gfjbrOYXuRWqbKw==", true),
                                DES.Decrypt("ecO+kizstzM=", true),
                                "cleaner",
                                DES.Decrypt("DvWyPJXmeps=", true),
                                DES.Decrypt("04ZE2yXOXwww9p6ZbFbp9A==", true)
                            );
                        TimetableRepository timetableRepository = new TimetableRepository(connectionString);
                        TimetableService timetableService = new TimetableService(timetableRepository);

                        CleanerTimetable cashireFilms = new CleanerTimetable(f4, timetableService);
                        Application.Run(f4);
                    }break;
            }
        }
    }
}
