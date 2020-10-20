using BL.Cashier.Interface;
using DAL.Cashier.Interface;
using Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cashier.Service
{
    public class FilmsServiceC : IFilmsServiceC
    {
        private IFilmsRepositoryC _filmsRepository;

        public FilmsServiceC(IFilmsRepositoryC filmsRepository)
        {
            _filmsRepository = filmsRepository;
        }

        public ValidationResult<List<Entities.AdminSingleTable.TableFilms>> SelectFilm()
        {
            return _filmsRepository.SelectFilms();
        }
    }
}
