using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS__provider_.Classes;

namespace TNS__provider_.Model
{
    public partial class Subscribers
    {
        public string FullName { get => ($"{Surname} {Name} {Patronymic}"); }

    }
}
