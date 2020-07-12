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
      }
      MessageBox.Show("Done");
    }


    private void BtnAddData_Click(object sender, EventArgs e)
    {
      DateTime tDate = new DateTime(2020, 7, 1);
      newTrade("XYZ", "test Account", tDate , 12.345f, 100f);
    }

    private void newTrade(string stock, string account, DateTime tTime, float price, float Qty)
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

        //var st = db.Select<Stock>("Symbol = @symbol", new { symbol = Stock });
        //var st = ac.stocks.Where("Symbol=@stck", new {stck = stock});
        var st = ac.stocks.Where(x => x.Symbol == stock).FirstOrDefault();
        if (st == null) {
          st = new Stock() {Symbol = stock};
          db.Insert<Stock>(st);
        }

        Trade tr = new Trade() {tDate = new DateTime(2020, 7, 1)};
        st.trades.Add(tr);

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
