using Entities.Validation;
using System.Collections.Generic;

namespace DAL.Cashier.Interface
{
    public interface IFilmsRepositoryC
    {
        ValidationResult<List<Entities.AdminSingleTable.TableFilms>> SelectFilms();
    }
}
