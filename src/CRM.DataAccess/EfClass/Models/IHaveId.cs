using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccess.EfClass.Models;

public interface IHaveId<TId>
{
    TId Id { get; set; }
}
