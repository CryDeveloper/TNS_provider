using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TNS__provider_.Model;

namespace TNS__provider_.Classes
{
    internal class GlobalData
    {
        public static Frame ActiveMainFrame = new Frame();
        public static DB_TNSEntities ConnectDB = new DB_TNSEntities();
    }
}
