using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;


namespace sqLiteTest
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      DBUtils.InitConnectionFactory();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      int i = 1;
      if (i > 0) { };
    }

    private void BtnMakeDb_Click(object sender, EventArgs e)
    {
      using (IDbConnection db = DBUtils.Factory.Open())
      {
        if (db.TableExists<Trade>())
          db.DropAndCreateTable<Trade>();
        else
          db.CreateTable<Trade>();

        if (db.TableExists<Stock>())
          db.DropAndCreateTable<Stock>();
        else
          db.CreateTable<Stock>();

        if (db.TableExists<Account>())
          db.DropAndCreateTable<Account>();
        else
          db.CreateTable<Account>();
        Account ac = new Account() { accName = "testACC1", accDescription = "test account1" };
        db.Insert<Account>(ac);
        ac = new Account() { accName = "testACC2", accDescription = "test account2" };
        db.Insert<Account>(ac);
        //db.Save(ac, references: true);
      }
      MessageBox.Show("Done");
    }


    private void BtnAddData_Click(object sender, EventArgs e)
    {
      DateTime dt = new DateTime(2020, 7, 1);
      newTrade("XYZ", "testACC1", dt, 12.34f, 100f);
      dt = new DateTime(2020, 7, 2);
      newTrade("XYZ", "testACC2", dt, 56.78f, 150f);
      dt = new DateTime(2020, 7, 3);
      newTrade("ABC", "testACC1", dt, 9.0f, 250f);
      MessageBox.Show("Done");
    }

    private void newTrade(string stock, string account, DateTime tTime, float Price, float Qty)
    {
      // fill data
      using (IDbConnection db = DBUtils.Factory.Open())
      {
        long stID = 0;
        long acID = 0;
        Stock stk = new Stock();
        Account acc = new Account();

        var ac = db.Select<Account>("accName = @acn", new {acn = account}).FirstOrDefault();
        if (ac == null)
          return;


  //   List<FullCustomerInfo> rows = db.Select<FullCustomerInfo>(  // Map results to FullCustomerInfo POCO
  //   db.From<Customer>()                                         // Create typed Customer SqlExpression
  //  .LeftJoin<CustomerAddress>()                                 // Implicit left join with base table
  //  .Join<Customer, Order>((c, o) => c.Id == o.CustomerId)       // Explicit join and condition
  //  .Where(c => c.Name == "Customer 1")                          // Implicit condition on base table
  //  .And<Order>(o => o.Cost < 2)                                 // Explicit condition on joined Table
  //  .Or<Customer, Order>((c, o) => c.Name == o.LineItem));



        var st = ac.stocks.Where(x => x.Symbol == stock).FirstOrDefault();
        if (st == null)
        {
          st = new Stock() { Symbol = stock, AccountId=ac.Id };
          ac.stocks.Add(st);
          stID = db.Insert<Stock>(st);
        }
        else
          stID = st.Id;

        Trade tr = new Trade() {tDate = tTime, price=Price, qty=Qty, StockId = stID };
        //st.trades.Add(tr);

        try
        {
          db.Save(tr, references: true);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString());
        }

        //var tracks = db.Select<Track>("Artist = @artist AND Album = @album",
        //new { artist = "Nirvana", album = "Heart Shaped Box" });

        //db.Save(item);
        //item.Id //populated with the auto-incremented id
        //Otherwise you can select the last insert id using:
        //var itemId = db.Insert(item, selectIdentity: true);
      }
    }

    private void BtnQuery_Click(object sender, EventArgs e)
    {
      float minV;
      if (! float.TryParse(tbMinValue.Text, out minV))
      {
        MessageBox.Show("Invalid value entered");
        return;
      }
      lbResults.Items.Clear();
      List<Stock> goodStocks = null;
      using (IDbConnection db = DBUtils.Factory.Open())
      {
        string queryStr = $"select * from Stock where value>{minV}";
        try
        {
          goodStocks = db.Select<Stock>(queryStr);
        }
        catch (Exception ex)
        {
          MessageBox.Show($"Failed listing plates holes, Error:\n{ex.Message}");
          return;
        }
      }
      // foreach (Stock s in goodStocks)
      //  lbResults.Items.Add($"Stock({s.Symbol}) => value({s.Account.accName})");
    }
  }
}

//https://github.com/ServiceStack/ServiceStack.OrmLite
//to Push to Github:
//  select changes ome tab in team explorer) and ADD a COMMENT
//  dropdown under the comment, select "commit all and push"

