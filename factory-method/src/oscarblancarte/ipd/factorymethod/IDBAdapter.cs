using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace oscarblancarte.ipd.factorymethod{
    public interface IDBAdapter {
        IDbConnection GetConnection();
    }
}