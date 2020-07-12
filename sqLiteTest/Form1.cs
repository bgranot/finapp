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
        if (db.TableExists<trade1>())
          db.DropAndCreateTable<trade1>();
        else
          db.CreateTable<trade1>();

        if (db.TableExists<stock>())
          db.DropAndCreateTable<stock>();
        else
          db.CreateTable<stock>();

        if (db.TableExists<account>())
          db.DropAndCreateTable<account>();
        else
          db.CreateTable<account>();
      }
      MessageBox.Show("Done");
    }


    private void BtnAddData_Click(object sender, EventArgs e)
    {
      DateTime tDate = new DateTime(2020, 7, 1);
      newTrade("XYZ", "test account", tDate , 12.345f, 100f);
    }

    private void newTrade(string Stock, string Account, DateTime tTime, float price, float Qty)
    {
      // fill data
      using (IDbConnection db = DBUtils.Factory.Open())
      {
        long stID = 0;
        long acID = 0;
        stock stk = new stock();
        account acc = new account();
        
        var ac = db.Select<account>("accName = @acn", new { acn = Account });
        if (ac.Count >= 1){
          acID = ac[0].Id;
          acc = ac[0];
        }
        else{

        }

        var st = db.Select<stock>("Symbol = @symbol", new { symbol = Stock });
        if (st.Count >= 1)
        {
          stID = st[0].Id;
          stk = st[0];
        }
        else
        {
          stk = new stock()
          {
            Symbol = "XYZ",
            account = ac
          };
        };


        trade1 tr = new trade1()
        {
          tDate = new DateTime(2020, 7, 1),
          stock = stk,
        };

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
      List<stock> goodStocks = null;
      using (IDbConnection db = DBUtils.Factory.Open())
      {
        string queryStr = $"select * from Stock where value>{minV}";
        try
        {
          goodStocks = db.Select<stock>(queryStr);
        }
        catch (Exception ex)
        {
          MessageBox.Show($"Failed listing plates holes, Error:\n{ex.Message}");
          return;
        }
      }
      // foreach (stock s in goodStocks)
      //  lbResults.Items.Add($"Stock({s.Symbol}) => value({s.account.accName})");
    }
  }
}

//https://github.com/ServiceStack/ServiceStack.OrmLite
