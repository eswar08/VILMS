using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VILMS_DA
{
    interface Idbmanager
    {
        DataSet GetDataInDataSet(string query);
        bool RunQuery(string query, out int noOfRowsaffected);
    }
}
