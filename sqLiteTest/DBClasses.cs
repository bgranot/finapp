using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace sqLiteTest
{

  public class Trade
  {
    // Trade table
    [AutoIncrement]
    [PrimaryKey]
    [Required]
    public long Id { set; get; }
    public DateTime tDate{ set; get; }
  }

  public class Stock
  {
    //parent table (eg Stock)
    [AutoIncrement]
    [PrimaryKey]
    [Required]
    public long Id { set; get; }
    public string Symbol { set; get; }
    [Reference]
    public List<Trade> trades { set; get; }
  }

  public class Account
  {
    //Account table
    [AutoIncrement]
    [PrimaryKey]
    [Required]
    public long Id { set; get; }
    public string accName { set; get; }
    public string accDescription { set; get; }
    [Reference]
    public List<Stock> stocks { get; set; }
  }
}

//OrmLite is able to CREATE, DROP and ALTER RDBMS Tables from your code-first Data Models with rich annotations for controlling how the underlying RDBMS Tables are constructed.