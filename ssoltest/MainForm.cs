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
using ServiceStack.OrmLite.Dapper;
using ServiceStack.OrmLite.Sqlite;

namespace ssoltest {
  public partial class MainForm : Form {
    public MainForm() {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e) {
      DBUtils.InitConnectionFactory();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {

    }

    public void Log(string txt) {
      msgsLB.Items.Insert(0, txt);
    }

    private void createTablesBTN_Click(object sender, EventArgs e) {
      using (IDbConnection db = DBUtils.Factory.Open()) {
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
        Account ac = new Account() { accName = "testACC1" };
        db.Insert<Account>(ac);
      }
      Log("Tables created");
    }

    private void addStockBTN_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(stockNameTB.Text)) {
        Log("No name");
        return;
      }
      using (IDbConnection db = DBUtils.Factory.Open()) {
        Account ac = db.Select<Account>().FirstOrDefault();
        if (ac == null) {
          Log("No account");
          return;
        }
        Stock st = db.Select<Stock>().FirstOrDefault(x => x.Symbol == stockNameTB.Text);
        if (st != null) {
          Log("Already exists");
          return;
        }
        st = new Stock() {Symbol = stockNameTB.Text, AccountId = ac.Id};
        ac.stocks.Add(st);
        db.Save(ac, references: true);
      }
      Log("Stock added");
    }

    private void button1_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(stockNameTB.Text)) {
        Log("No name");
        return;
      }
      int qty = (int) quantityNUD.Value;
      if (qty == 0) {
        Log("No tranaction");
        return;
      }
      using (IDbConnection db = DBUtils.Factory.Open()) {
        Stock st = db.Select<Stock>().FirstOrDefault(x => x.Symbol == stockNameTB.Text);
        if (st == null) {
          Log("No such stock");
          return;
        }
        Trade tr = new Trade() {date = DateTime.Now, quantity = qty, StockId = st.Id};
        st.trades.Add(tr);
        db.Save(st, references: true);
      }
      Log("Trade added");
    }

    private void quantityNUD_ValueChanged(object sender, EventArgs e) {
      quantityNUD.ForeColor = quantityNUD.Value > 0 ? Color.Green : (quantityNUD.Value < 0 ? Color.Red : SystemColors.ControlText);
    }

    private void showTradesBTN_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(stockNameTB.Text)) {
        Log("No name");
        return;
      }
      using (IDbConnection db = DBUtils.Factory.Open()) {
        Stock st = db.Select<Stock>().FirstOrDefault(x => x.Symbol == stockNameTB.Text);
        if (st == null) {
          Log("No such stock");
          return;
        }
        // foreach (Trade tr in st.trades)
        //   Log($"{tr.date} : {tr.quantity}");
        IEnumerable<Trade> trades = db.Select<Trade>(x => x.StockId == st.Id);
        foreach (Trade tr in trades)
          Log($"{tr.date} : {tr.quantity}");
      }
    }
  }
}
