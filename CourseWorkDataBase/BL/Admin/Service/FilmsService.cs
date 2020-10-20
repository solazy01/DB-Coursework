using System.Collections.Generic;
using BL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.Validation;
using DAL.Admin.Interface;
using BL.Admin.DominObjects;
using Entities.ComboBox;
using FilmsMemberDAO = DAL.Admin.DataAccesObjects.FilmsMember;

namespace BL.Admin.Service
{
    public class FilmsService : IFilmsService
    {
        private IFilmsRepository _filmsRepository;

        public FilmsService(IFilmsRepository filmsRepository)
        {
            _filmsRepository = filmsRepository;
        }



        public bool InsertFilms(FilmsMember filmsMember)
        {
            return _filmsRepository.InsertFilm(new FilmsMemberDAO
            {
                Country = filmsMember.Country,
                Duration = filmsMember.Duration,
                Producer = filmsMember.Producer,
                Genre = filmsMember.Genre,
                ReleaseDate = filmsMember.ReleaseDate,
                Title = filmsMember.Title,
                BasePrice =filmsMember.BasePrice
            });
        }


        public bool UpdateFilms(FilmsMember filmsMember)
        {
            return _filmsRepository.UpdateFilm(new FilmsMemberDAO
            {
                Country = filmsMember.Country,
                Duration = filmsMember.Duration,
                Producer = filmsMember.Producer,
                Genre = filmsMember.Genre,
                ReleaseDate = filmsMember.ReleaseDate,
                Title = filmsMember.Title,
                BasePrice = filmsMember.BasePrice,
                FilmId = filmsMember.FilmId,

            });
        }


        public bool DeleteFilms(FilmsMember filmsMember)
        {
            return _filmsRepository.DeleteFilm(new FilmsMemberDAO
            {
                FilmId = filmsMember.FilmId
            });
        }

        public ValidationResult<List<FilmsName>> SelectFName()
        {
            return _filmsRepository.SelectFilmsName();
        }


        public ValidationResult<List<TableFilms>> SelectFilm()
        {
            return _filmsRepository.SelectFilms();
        }
    }
}
