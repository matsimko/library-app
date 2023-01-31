namespace DesktopApp.Forms
{
    partial class BooksForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.authorCB = new System.Windows.Forms.ComboBox();
            this.yearToTB = new System.Windows.Forms.TextBox();
            this.yearFromTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.selectGenresLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.langCB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.booksDGW = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksDGW)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.booksDGW, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 956);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.titleTB, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.authorCB, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.yearToTB, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.yearFromTB, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.selectGenresLbl, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.langCB, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 10);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(226, 322);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Autor";
            // 
            // titleTB
            // 
            this.titleTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.SetColumnSpan(this.titleTB, 2);
            this.titleTB.Location = new System.Drawing.Point(3, 20);
            this.titleTB.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.titleTB.Name = "titleTB";
            this.titleTB.Size = new System.Drawing.Size(223, 26);
            this.titleTB.TabIndex = 21;
            // 
            // authorCB
            // 
            this.authorCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.SetColumnSpan(this.authorCB, 2);
            this.authorCB.FormattingEnabled = true;
            this.authorCB.Location = new System.Drawing.Point(3, 76);
            this.authorCB.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.authorCB.Name = "authorCB";
            this.authorCB.Size = new System.Drawing.Size(180, 28);
            this.authorCB.TabIndex = 20;
            this.authorCB.TextChanged += new System.EventHandler(this.authorCB_TextChanged);
            this.authorCB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.authorCB_KeyDown);
            // 
            // yearToTB
            // 
            this.yearToTB.Location = new System.Drawing.Point(93, 245);
            this.yearToTB.Name = "yearToTB";
            this.yearToTB.Size = new System.Drawing.Size(50, 26);
            this.yearToTB.TabIndex = 8;
            // 
            // yearFromTB
            // 
            this.yearFromTB.Location = new System.Drawing.Point(3, 245);
            this.yearFromTB.Name = "yearFromTB";
            this.yearFromTB.Size = new System.Drawing.Size(50, 26);
            this.yearFromTB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "od";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "do";
            // 
            // selectGenresLbl
            // 
            this.selectGenresLbl.AutoSize = true;
            this.selectGenresLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectGenresLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectGenresLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.selectGenresLbl.Location = new System.Drawing.Point(0, 172);
            this.selectGenresLbl.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.selectGenresLbl.Name = "selectGenresLbl";
            this.selectGenresLbl.Size = new System.Drawing.Size(90, 20);
            this.selectGenresLbl.TabIndex = 2;
            this.selectGenresLbl.Text = "Vybrat žánr";
            this.selectGenresLbl.Click += new System.EventHandler(this.selectGenresLbl_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Rok vydání";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Název";
            // 
            // langCB
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.langCB, 2);
            this.langCB.FormattingEnabled = true;
            this.langCB.Location = new System.Drawing.Point(3, 134);
            this.langCB.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.langCB.Name = "langCB";
            this.langCB.Size = new System.Drawing.Size(121, 28);
            this.langCB.TabIndex = 23;
            this.langCB.TextUpdate += new System.EventHandler(this.langCB_TextUpdate);
            this.langCB.TextChanged += new System.EventHandler(this.langCB_TextChanged);
            this.langCB.Enter += new System.EventHandler(this.langCB_Enter);
            this.langCB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.langCB_KeyUp);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Jazyk";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.searchBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.clearBtn, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 284);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(226, 38);
            this.tableLayoutPanel3.TabIndex = 25;
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.searchBtn.AutoSize = true;
            this.searchBtn.Location = new System.Drawing.Point(112, 0);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Padding = new System.Windows.Forms.Padding(4);
            this.searchBtn.Size = new System.Drawing.Size(114, 38);
            this.searchBtn.TabIndex = 0;
            this.searchBtn.Text = "Hledat knihy";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.clearBtn.AutoSize = true;
            this.clearBtn.Location = new System.Drawing.Point(15, 0);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Padding = new System.Windows.Forms.Padding(4);
            this.clearBtn.Size = new System.Drawing.Size(89, 38);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Vymazat";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // booksDGW
            // 
            this.booksDGW.AllowUserToAddRows = false;
            this.booksDGW.AllowUserToDeleteRows = false;
            this.booksDGW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.booksDGW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.booksDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksDGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.AuthorFullName,
            this.ReleaseYear});
            this.booksDGW.Location = new System.Drawing.Point(238, 23);
            this.booksDGW.Name = "booksDGW";
            this.booksDGW.ReadOnly = true;
            this.booksDGW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.booksDGW.Size = new System.Drawing.Size(1020, 927);
            this.booksDGW.TabIndex = 1;
            this.booksDGW.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.booksDGW_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Title";
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "Název";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // AuthorFullName
            // 
            this.AuthorFullName.DataPropertyName = "AuthorFullName";
            this.AuthorFullName.FillWeight = 40F;
            this.AuthorFullName.HeaderText = "Autor";
            this.AuthorFullName.Name = "AuthorFullName";
            this.AuthorFullName.ReadOnly = true;
            // 
            // ReleaseYear
            // 
            this.ReleaseYear.DataPropertyName = "ReleaseYear";
            this.ReleaseYear.FillWeight = 13F;
            this.ReleaseYear.HeaderText = "Původní rok vydání";
            this.ReleaseYear.Name = "ReleaseYear";
            this.ReleaseYear.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(238, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(406, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Pro zobrazení detailu klikněte na odpovídající záznam v tabulce";
            // 
            // BooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "BooksForm";
            this.Text = "Knihy";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksDGW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label selectGenresLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox yearFromTB;
        private System.Windows.Forms.TextBox yearToTB;
        private System.Windows.Forms.DataGridView booksDGW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.ComboBox authorCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox langCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseYear;
        private System.Windows.Forms.Label label7;
    }
}
