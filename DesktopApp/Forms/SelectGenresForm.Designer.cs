namespace DesktopApp.Forms
{
    partial class SelectGenresForm
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
            this.genresLB = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // genresLB
            // 
            this.genresLB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genresLB.CheckOnClick = true;
            this.genresLB.ColumnWidth = 150;
            this.genresLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genresLB.FormattingEnabled = true;
            this.genresLB.Location = new System.Drawing.Point(20, 20);
            this.genresLB.Margin = new System.Windows.Forms.Padding(0);
            this.genresLB.MultiColumn = true;
            this.genresLB.Name = "genresLB";
            this.genresLB.Size = new System.Drawing.Size(450, 221);
            this.genresLB.TabIndex = 1;
            // 
            // SelectGenresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(490, 261);
            this.Controls.Add(this.genresLB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectGenresForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "SelectGenresForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectGenresForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox genresLB;
    }
}