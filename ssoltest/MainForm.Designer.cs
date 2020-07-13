namespace ssoltest {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.createTablesBTN = new System.Windows.Forms.Button();
      this.msgsLB = new System.Windows.Forms.ListBox();
      this.addStockBTN = new System.Windows.Forms.Button();
      this.stockNameTB = new System.Windows.Forms.TextBox();
      this.quantityNUD = new System.Windows.Forms.NumericUpDown();
      this.button1 = new System.Windows.Forms.Button();
      this.showTradesBTN = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.quantityNUD)).BeginInit();
      this.SuspendLayout();
      // 
      // createTablesBTN
      // 
      this.createTablesBTN.Location = new System.Drawing.Point(12, 12);
      this.createTablesBTN.Name = "createTablesBTN";
      this.createTablesBTN.Size = new System.Drawing.Size(75, 23);
      this.createTablesBTN.TabIndex = 0;
      this.createTablesBTN.Text = "Create tables";
      this.createTablesBTN.UseVisualStyleBackColor = true;
      this.createTablesBTN.Click += new System.EventHandler(this.createTablesBTN_Click);
      // 
      // msgsLB
      // 
      this.msgsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.msgsLB.FormattingEnabled = true;
      this.msgsLB.Location = new System.Drawing.Point(3, 195);
      this.msgsLB.Name = "msgsLB";
      this.msgsLB.Size = new System.Drawing.Size(795, 251);
      this.msgsLB.TabIndex = 1;
      // 
      // addStockBTN
      // 
      this.addStockBTN.Location = new System.Drawing.Point(12, 51);
      this.addStockBTN.Name = "addStockBTN";
      this.addStockBTN.Size = new System.Drawing.Size(91, 23);
      this.addStockBTN.TabIndex = 2;
      this.addStockBTN.Text = "Add stock";
      this.addStockBTN.UseVisualStyleBackColor = true;
      this.addStockBTN.Click += new System.EventHandler(this.addStockBTN_Click);
      // 
      // stockNameTB
      // 
      this.stockNameTB.Location = new System.Drawing.Point(122, 54);
      this.stockNameTB.Name = "stockNameTB";
      this.stockNameTB.Size = new System.Drawing.Size(100, 20);
      this.stockNameTB.TabIndex = 3;
      this.stockNameTB.Text = "apple";
      // 
      // quantityNUD
      // 
      this.quantityNUD.Location = new System.Drawing.Point(122, 88);
      this.quantityNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.quantityNUD.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.quantityNUD.Name = "quantityNUD";
      this.quantityNUD.Size = new System.Drawing.Size(120, 20);
      this.quantityNUD.TabIndex = 4;
      this.quantityNUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.quantityNUD.ValueChanged += new System.EventHandler(this.quantityNUD_ValueChanged);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 88);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(91, 23);
      this.button1.TabIndex = 5;
      this.button1.Text = "Buy/sell stock";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // showTradesBTN
      // 
      this.showTradesBTN.Location = new System.Drawing.Point(12, 128);
      this.showTradesBTN.Name = "showTradesBTN";
      this.showTradesBTN.Size = new System.Drawing.Size(91, 23);
      this.showTradesBTN.TabIndex = 6;
      this.showTradesBTN.Text = "Show trades";
      this.showTradesBTN.UseVisualStyleBackColor = true;
      this.showTradesBTN.Click += new System.EventHandler(this.showTradesBTN_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.showTradesBTN);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.quantityNUD);
      this.Controls.Add(this.stockNameTB);
      this.Controls.Add(this.addStockBTN);
      this.Controls.Add(this.msgsLB);
      this.Controls.Add(this.createTablesBTN);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.quantityNUD)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button createTablesBTN;
    private System.Windows.Forms.ListBox msgsLB;
    private System.Windows.Forms.Button addStockBTN;
    private System.Windows.Forms.TextBox stockNameTB;
    private System.Windows.Forms.NumericUpDown quantityNUD;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button showTradesBTN;
  }
}

