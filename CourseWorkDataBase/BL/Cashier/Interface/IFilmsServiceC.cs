using Entities.Validation;
using System.Collections.Generic;


namespace BL.Cashier.Interface
{
    public interface IFilmsServiceC
    {
        ValidationResult<List<Entities.AdminSingleTable.TableFilms>> SelectFilm();
    }
}
