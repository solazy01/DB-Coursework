using System.Collections.Generic;
using BL.Admin.DominObjects;
using Entities.AdminSingleTable;
using Entities.ComboBox;
using Entities.Validation;

namespace BL.Admin.Interface
{
    public interface IFilmsService
    {
        ValidationResult<List<TableFilms>> SelectFilm();
        bool InsertFilms(FilmsMember filmsMember);
        bool UpdateFilms(FilmsMember filmsMember);
        bool DeleteFilms(FilmsMember filmsMember);

        ValidationResult<List<FilmsName>> SelectFName();
    }
}
