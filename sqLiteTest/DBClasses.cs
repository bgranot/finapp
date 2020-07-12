using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace sqLiteTest
{

  public class trade1
  {
    // trade table
    [AutoIncrement]
    [PrimaryKey]
    [Required]
    public long Id { set; get; }
    public DateTime tDate{ set; get; }
    [Reference]
    public stock stock { set; get; }
  }

  public class stock
  {
    //parent table (eg stock)
    [AutoIncrement]
    [PrimaryKey]
    [Required]
    public long Id { set; get; }
    public string Symbol { set; get; }
    [Reference]
    public List<account> account { get; set; }
    //public List<trade> trade { get; set; }
  }

  public class account
  {
    //account table
    [AutoIncrement]
    [PrimaryKey]
    [Required]
    public long Id { set; get; }
    public string accName { set; get; }
    public string accDescription { set; get; }
  }
}

//OrmLite is able to CREATE, DROP and ALTER RDBMS Tables from your code-first Data Models with rich annotations for controlling how the underlying RDBMS Tables are constructed.