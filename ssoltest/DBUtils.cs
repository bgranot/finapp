using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;

namespace ssoltest {
  public static class DBUtils
  {
    static OrmLiteConnectionFactory connFact = null;

    public static void InitConnectionFactory()
    {
      string connStr = Path.Combine(Directory.GetCurrentDirectory(), "ssoldb.db");
      connFact = new OrmLiteConnectionFactory(connStr, SqliteDialect.Provider);
    }

    public static OrmLiteConnectionFactory Factory => connFact;
  }
}
