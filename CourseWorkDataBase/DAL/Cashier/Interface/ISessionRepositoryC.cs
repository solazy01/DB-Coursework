using Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Cashier.Interface
{
    public interface ISessionRepositoryC
    {
        ValidationResult<List<Entities.AdminSingleTable.TableSession>> SelectSession();
    }
}
