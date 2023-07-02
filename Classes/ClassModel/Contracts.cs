using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS__provider_.Classes;

namespace TNS__provider_.Model
{
    public partial class Contracts
    {
        public string ListServices
        {
            get
            {
                string listServices = "";
                List<ServicesInContract> service = GlobalData.ConnectDB.ServicesInContract.Where(x => x.ContractNumberId == Id).ToList();
                foreach (var item in service)
                {
                    listServices += item.Services.NameService +", ";
                }

                //List<TypesContract> = GlobalData.ConnectDB.TypesContract.Where(x => x.Id == )

                return listServices;

            }
        }
    }
}
