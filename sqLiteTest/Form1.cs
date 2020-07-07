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
        if (db.TableExists<trade>())
          db.DropAndCreateTable<trade>();
        else
          db.CreateTable<trade>();

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
      // fill data
      using (IDbConnection db = DBUtils.Factory.Open())
      {
        trade tr = new trade()
        {
          tDate = new DateTime(2020, 7, 1),
          stock = new stock()
          {
            Symbol = "XYZ",
            account = new account
            {
              accName = "X939",
              accDescription = "Some name"
            }
          }
        };
        try
        {
          db.Save(tr, references: true);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString());
        }
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
      foreach (stock s in goodStocks)
        lbResults.Items.Add($"Stock({s.Symbol}) => value({s.account.accName})");
    }
  }
}

//https://github.com/ServiceStack/ServiceStack.OrmLite
