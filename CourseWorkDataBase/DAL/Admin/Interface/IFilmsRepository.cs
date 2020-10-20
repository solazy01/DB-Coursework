using System.Collections.Generic;
using DAL.Admin.DataAccesObjects;
using Entities.AdminSingleTable;
using Entities.ComboBox;
using Entities.Validation;

namespace DAL.Admin.Interface
{
    public interface IFilmsRepository
    {
        ValidationResult<List<TableFilms>> SelectFilms();
        bool InsertFilm(FilmsMember filmsMember);
        bool UpdateFilm(FilmsMember filmsMember);
        bool DeleteFilm(FilmsMember filmsMember);

        ValidationResult<List<FilmsName>> SelectFilmsName();
    }
}
