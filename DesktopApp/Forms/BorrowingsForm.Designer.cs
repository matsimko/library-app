using System;
using System.Windows.Forms;

namespace DesktopApp.Forms
{
    partial class BorrowingsForm
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
            this.borrowingsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.borrowingsDGW = new System.Windows.Forms.DataGridView();
            this.fnameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newBorrowingBtn = new System.Windows.Forms.Button();
            this.CloseBorrowingsBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nidCB = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lnameCB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fnameCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.authorCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.activeOnlyCheckB = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.showBorrowingsBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.borrowingsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borrowingsDGW)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // borrowingsPanel
            // 
            this.borrowingsPanel.Controls.Add(this.tableLayoutPanel1);
            this.borrowingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borrowingsPanel.Location = new System.Drawing.Point(0, 29);
            this.borrowingsPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.borrowingsPanel.Name = "borrowingsPanel";
            this.borrowingsPanel.Size = new System.Drawing.Size(1264, 956);
            this.borrowingsPanel.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.borrowingsDGW, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 956);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // borrowingsDGW
            // 
            this.borrowingsDGW.AllowUserToAddRows = false;
            this.borrowingsDGW.AllowUserToDeleteRows = false;
            this.borrowingsDGW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borrowingsDGW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.borrowingsDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.borrowingsDGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fnameCol,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.tableLayoutPanel1.SetColumnSpan(this.borrowingsDGW, 2);
            this.borrowingsDGW.Location = new System.Drawing.Point(8, 388);
            this.borrowingsDGW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.borrowingsDGW.Name = "borrowingsDGW";
            this.borrowingsDGW.ReadOnly = true;
            this.borrowingsDGW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.borrowingsDGW.Size = new System.Drawing.Size(1248, 558);
            this.borrowingsDGW.TabIndex = 0;
            // 
            // fnameCol
            // 
            this.fnameCol.DataPropertyName = "UserFirstName";
            this.fnameCol.FillWeight = 15F;
            this.fnameCol.HeaderText = "Jméno";
            this.fnameCol.Name = "fnameCol";
            this.fnameCol.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UserLastName";
            this.Column1.FillWeight = 15F;
            this.Column1.HeaderText = "Příjmení";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserNationalIdNum";
            this.Column2.FillWeight = 10F;
            this.Column2.HeaderText = "Rodné číslo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BookCopyInfo";
            this.Column3.FillWeight = 40F;
            this.Column3.HeaderText = "Kopie knihy";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "BorrowDate";
            this.Column4.FillWeight = 10F;
            this.Column4.HeaderText = "Datum výpůjčky";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ClosingDate";
            this.Column5.FillWeight = 10F;
            this.Column5.HeaderText = "Datum konce výpůjčky";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ReturnDate";
            this.Column6.FillWeight = 10F;
            this.Column6.HeaderText = "Datum vrácení výpůjčky";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.newBorrowingBtn);
            this.panel1.Controls.Add(this.CloseBorrowingsBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(343, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 300);
            this.panel1.TabIndex = 2;
            // 
            // newBorrowingBtn
            // 
            this.newBorrowingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newBorrowingBtn.AutoSize = true;
            this.newBorrowingBtn.Location = new System.Drawing.Point(557, 257);
            this.newBorrowingBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newBorrowingBtn.Name = "newBorrowingBtn";
            this.newBorrowingBtn.Padding = new System.Windows.Forms.Padding(4);
            this.newBorrowingBtn.Size = new System.Drawing.Size(134, 38);
            this.newBorrowingBtn.TabIndex = 1;
            this.newBorrowingBtn.Text = "Nová výpůjčka";
            this.newBorrowingBtn.UseVisualStyleBackColor = true;
            this.newBorrowingBtn.Click += new System.EventHandler(this.newBorrowingBtn_Click);
            // 
            // CloseBorrowingsBtn
            // 
            this.CloseBorrowingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBorrowingsBtn.AutoSize = true;
            this.CloseBorrowingsBtn.Location = new System.Drawing.Point(699, 257);
            this.CloseBorrowingsBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CloseBorrowingsBtn.Name = "CloseBorrowingsBtn";
            this.CloseBorrowingsBtn.Padding = new System.Windows.Forms.Padding(4);
            this.CloseBorrowingsBtn.Size = new System.Drawing.Size(210, 38);
            this.CloseBorrowingsBtn.TabIndex = 0;
            this.CloseBorrowingsBtn.Text = "Ukončit vybrané výpůjčky";
            this.CloseBorrowingsBtn.UseVisualStyleBackColor = true;
            this.CloseBorrowingsBtn.Click += new System.EventHandler(this.CloseBorrowingsBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.nidCB, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lnameCB, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.fnameCB, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.authorCB, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.titleTB, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.activeOnlyCheckB, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 10);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(327, 368);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 5, 4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Kniha";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 247);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Rodné číslo";
            // 
            // nidCB
            // 
            this.nidCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nidCB.FormattingEnabled = true;
            this.nidCB.Location = new System.Drawing.Point(100, 243);
            this.nidCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nidCB.Name = "nidCB";
            this.nidCB.Size = new System.Drawing.Size(180, 28);
            this.nidCB.TabIndex = 16;
            this.nidCB.TextChanged += new System.EventHandler(this.nidCB_TextChanged);
            this.nidCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboboxKeyUp);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 209);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Příjmení";
            // 
            // lnameCB
            // 
            this.lnameCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnameCB.FormattingEnabled = true;
            this.lnameCB.Location = new System.Drawing.Point(100, 205);
            this.lnameCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lnameCB.Name = "lnameCB";
            this.lnameCB.Size = new System.Drawing.Size(180, 28);
            this.lnameCB.TabIndex = 14;
            this.lnameCB.TextChanged += new System.EventHandler(this.lnameCB_TextChanged);
            this.lnameCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboboxKeyUp);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 171);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Jméno";
            // 
            // fnameCB
            // 
            this.fnameCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fnameCB.Location = new System.Drawing.Point(100, 167);
            this.fnameCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fnameCB.Name = "fnameCB";
            this.fnameCB.Size = new System.Drawing.Size(180, 28);
            this.fnameCB.TabIndex = 12;
            this.fnameCB.TextChanged += new System.EventHandler(this.fnameCB_TextChanged);
            this.fnameCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboboxKeyUp);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Autor";
            // 
            // authorCB
            // 
            this.authorCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.authorCB.FormattingEnabled = true;
            this.authorCB.Location = new System.Drawing.Point(100, 80);
            this.authorCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.authorCB.Name = "authorCB";
            this.authorCB.Size = new System.Drawing.Size(180, 28);
            this.authorCB.TabIndex = 8;
            this.authorCB.TextChanged += new System.EventHandler(this.authorCB_TextChanged);
            this.authorCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboboxKeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Název";
            // 
            // titleTB
            // 
            this.titleTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.titleTB.Location = new System.Drawing.Point(100, 44);
            this.titleTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.titleTB.Name = "titleTB";
            this.titleTB.Size = new System.Drawing.Size(223, 26);
            this.titleTB.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label5, 2);
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(0, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 15, 4, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 29);
            this.label5.TabIndex = 19;
            this.label5.Text = "Uživatel";
            // 
            // activeOnlyCheckB
            // 
            this.activeOnlyCheckB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.activeOnlyCheckB.AutoSize = true;
            this.activeOnlyCheckB.Checked = true;
            this.activeOnlyCheckB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel2.SetColumnSpan(this.activeOnlyCheckB, 2);
            this.activeOnlyCheckB.Location = new System.Drawing.Point(4, 291);
            this.activeOnlyCheckB.Margin = new System.Windows.Forms.Padding(4, 15, 4, 5);
            this.activeOnlyCheckB.Name = "activeOnlyCheckB";
            this.activeOnlyCheckB.Size = new System.Drawing.Size(183, 24);
            this.activeOnlyCheckB.TabIndex = 20;
            this.activeOnlyCheckB.Text = "Pouze aktivní výpůjčky";
            this.activeOnlyCheckB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.showBorrowingsBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.clearBtn, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 320);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(327, 48);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // showBorrowingsBtn
            // 
            this.showBorrowingsBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.showBorrowingsBtn.AutoSize = true;
            this.showBorrowingsBtn.Location = new System.Drawing.Point(187, 5);
            this.showBorrowingsBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showBorrowingsBtn.Name = "showBorrowingsBtn";
            this.showBorrowingsBtn.Padding = new System.Windows.Forms.Padding(4);
            this.showBorrowingsBtn.Size = new System.Drawing.Size(136, 38);
            this.showBorrowingsBtn.TabIndex = 21;
            this.showBorrowingsBtn.Text = "Hledat výpůjčky";
            this.showBorrowingsBtn.UseVisualStyleBackColor = true;
            this.showBorrowingsBtn.Click += new System.EventHandler(this.showBorrowingsBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.AutoSize = true;
            this.clearBtn.Location = new System.Drawing.Point(90, 5);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Padding = new System.Windows.Forms.Padding(4);
            this.clearBtn.Size = new System.Drawing.Size(89, 38);
            this.clearBtn.TabIndex = 22;
            this.clearBtn.Text = "Vymazat";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // BorrowingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.borrowingsPanel);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "BorrowingsForm";
            this.Text = "Výpůjčky";
            this.Controls.SetChildIndex(this.borrowingsPanel, 0);
            this.borrowingsPanel.ResumeLayout(false);
            this.borrowingsPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borrowingsDGW)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel borrowingsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView borrowingsDGW;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newBorrowingBtn;
        private System.Windows.Forms.Button CloseBorrowingsBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox nidCB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox lnameCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox fnameCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox authorCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox activeOnlyCheckB;
        private System.Windows.Forms.Button showBorrowingsBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private TableLayoutPanel tableLayoutPanel3;
        private Button clearBtn;
    }
}
