using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS__provider_.Model
{
    public partial class Employees
    {
        public string FulName { get => ($"{Surname} {Name} {Patronymic}"); }
    }
}

