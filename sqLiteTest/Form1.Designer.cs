namespace sqLiteTest
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnMakeDb = new System.Windows.Forms.Button();
      this.btnQuery = new System.Windows.Forms.Button();
      this.tbMinValue = new System.Windows.Forms.TextBox();
      this.lbResults = new System.Windows.Forms.ListBox();
      this.btnAddData = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnMakeDb
      // 
      this.btnMakeDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMakeDb.Location = new System.Drawing.Point(563, 425);
      this.btnMakeDb.Name = "btnMakeDb";
      this.btnMakeDb.Size = new System.Drawing.Size(75, 23);
      this.btnMakeDb.TabIndex = 0;
      this.btnMakeDb.Text = "Create DB";
      this.btnMakeDb.UseVisualStyleBackColor = true;
      this.btnMakeDb.Click += new System.EventHandler(this.BtnMakeDb_Click);
      // 
      // btnQuery
      // 
      this.btnQuery.Location = new System.Drawing.Point(26, 28);
      this.btnQuery.Name = "btnQuery";
      this.btnQuery.Size = new System.Drawing.Size(75, 23);
      this.btnQuery.TabIndex = 1;
      this.btnQuery.Text = "Query";
      this.btnQuery.UseVisualStyleBackColor = true;
      this.btnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
      // 
      // tbMinValue
      // 
      this.tbMinValue.Location = new System.Drawing.Point(107, 28);
      this.tbMinValue.Name = "tbMinValue";
      this.tbMinValue.Size = new System.Drawing.Size(148, 20);
      this.tbMinValue.TabIndex = 2;
      // 
      // lbResults
      // 
      this.lbResults.FormattingEnabled = true;
      this.lbResults.Location = new System.Drawing.Point(30, 73);
      this.lbResults.Name = "lbResults";
      this.lbResults.Size = new System.Drawing.Size(627, 264);
      this.lbResults.TabIndex = 3;
      // 
      // btnAddData
      // 
      this.btnAddData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddData.Location = new System.Drawing.Point(563, 377);
      this.btnAddData.Name = "btnAddData";
      this.btnAddData.Size = new System.Drawing.Size(75, 23);
      this.btnAddData.TabIndex = 4;
      this.btnAddData.Text = "Add Data";
      this.btnAddData.UseVisualStyleBackColor = true;
      this.btnAddData.Click += new System.EventHandler(this.BtnAddData_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(689, 460);
      this.Controls.Add(this.btnAddData);
      this.Controls.Add(this.lbResults);
      this.Controls.Add(this.tbMinValue);
      this.Controls.Add(this.btnQuery);
      this.Controls.Add(this.btnMakeDb);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnMakeDb;
    private System.Windows.Forms.Button btnQuery;
    private System.Windows.Forms.TextBox tbMinValue;
    private System.Windows.Forms.ListBox lbResults;
    private System.Windows.Forms.Button btnAddData;
  }
}

