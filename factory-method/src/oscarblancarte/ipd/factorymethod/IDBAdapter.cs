using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Oracle.DataAccess.Client; 

namespace oscarblancarte.ipd.factorymethod{
    public interface IDBAdapter {
        IDbConnection getConnection();
    }
}