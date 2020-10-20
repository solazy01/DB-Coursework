using Entities.Validation;
using System.Collections.Generic;

namespace BL.Cashier.Interface
{
    public interface ISessionServiceC
    {
        ValidationResult<List<Entities.AdminSingleTable.TableSession>> SelectSession();
    }
}
