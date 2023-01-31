namespace DesktopApp.Forms
{
    partial class BookDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl = new System.Windows.Forms.Label();
            this.copiesDGW = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reserveBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.genreLbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.langLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.yearLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.authorLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.descLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copiesDGW)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.copiesDGW, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.descLbl, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 619);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl.Location = new System.Drawing.Point(4, 545);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(656, 29);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Popis";
            // 
            // copiesDGW
            // 
            this.copiesDGW.AllowUserToDeleteRows = false;
            this.copiesDGW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.copiesDGW.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.copiesDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.copiesDGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.c,
            this.reserveBtn});
            this.copiesDGW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copiesDGW.Location = new System.Drawing.Point(4, 185);
            this.copiesDGW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.copiesDGW.Name = "copiesDGW";
            this.copiesDGW.ReadOnly = true;
            this.copiesDGW.RowTemplate.Height = 20;
            this.copiesDGW.Size = new System.Drawing.Size(656, 355);
            this.copiesDGW.TabIndex = 2;
            this.copiesDGW.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.copiesDGW_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "LanguageName";
            this.Column1.FillWeight = 10F;
            this.Column1.HeaderText = "Jazyk";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ReleaseYear";
            this.Column2.FillWeight = 5F;
            this.Column2.HeaderText = "Rok vydání";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TranslatorFullName";
            this.Column3.FillWeight = 15F;
            this.Column3.HeaderText = "Překlatel";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // c
            // 
            this.c.DataPropertyName = "PeopleInQueueCount";
            this.c.FillWeight = 8F;
            this.c.HeaderText = "Počet lidí ve frontě rezervací";
            this.c.Name = "c";
            this.c.ReadOnly = true;
            // 
            // reserveBtn
            // 
            this.reserveBtn.DataPropertyName = "ReserveText";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4);
            this.reserveBtn.DefaultCellStyle = dataGridViewCellStyle3;
            this.reserveBtn.FillWeight = 15F;
            this.reserveBtn.HeaderText = "";
            this.reserveBtn.Name = "reserveBtn";
            this.reserveBtn.ReadOnly = true;
            this.reserveBtn.Text = "Reserve";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.genreLbl, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.langLbl, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.yearLbl, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.authorLbl, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.titleLbl, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(656, 150);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // genreLbl
            // 
            this.genreLbl.AutoSize = true;
            this.genreLbl.Location = new System.Drawing.Point(94, 120);
            this.genreLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 10);
            this.genreLbl.Name = "genreLbl";
            this.genreLbl.Size = new System.Drawing.Size(0, 20);
            this.genreLbl.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 120);
            this.label11.Margin = new System.Windows.Forms.Padding(0, 0, 4, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Žánry";
            // 
            // langLbl
            // 
            this.langLbl.AutoSize = true;
            this.langLbl.Location = new System.Drawing.Point(94, 90);
            this.langLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 10);
            this.langLbl.Name = "langLbl";
            this.langLbl.Size = new System.Drawing.Size(0, 20);
            this.langLbl.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 90);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 0, 4, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Jazyk";
            // 
            // yearLbl
            // 
            this.yearLbl.AutoSize = true;
            this.yearLbl.Location = new System.Drawing.Point(94, 60);
            this.yearLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 10);
            this.yearLbl.Name = "yearLbl";
            this.yearLbl.Size = new System.Drawing.Size(0, 20);
            this.yearLbl.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 4, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Rok vydání";
            // 
            // authorLbl
            // 
            this.authorLbl.AutoSize = true;
            this.authorLbl.Location = new System.Drawing.Point(94, 30);
            this.authorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 10);
            this.authorLbl.Name = "authorLbl";
            this.authorLbl.Size = new System.Drawing.Size(0, 20);
            this.authorLbl.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 0, 4, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Autor";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(94, 0);
            this.titleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 10);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(0, 20);
            this.titleLbl.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 4, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Název";
            // 
            // descLbl
            // 
            this.descLbl.AutoSize = true;
            this.descLbl.Location = new System.Drawing.Point(4, 579);
            this.descLbl.Margin = new System.Windows.Forms.Padding(4, 5, 0, 20);
            this.descLbl.MaximumSize = new System.Drawing.Size(680, 0);
            this.descLbl.Name = "descLbl";
            this.descLbl.Size = new System.Drawing.Size(0, 20);
            this.descLbl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(553, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pokud je na tlačítku \"Přidat se do fronty\", kniha je aktuálně půjčená, nebo rezer" +
    "vovaná";
            // 
            // BookDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 619);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BookDetailForm";
            this.Text = "BookDetailForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copiesDGW)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label descLbl;
        private System.Windows.Forms.DataGridView copiesDGW;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label genreLbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label langLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label yearLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label authorLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn c;
        private System.Windows.Forms.DataGridViewButtonColumn reserveBtn;
        private System.Windows.Forms.Label label1;
    }
}