namespace DesktopApp.Forms
{
    partial class FormWithMenu
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.knihyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.výpůjčkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.žánryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.knihyToolStripMenuItem,
            this.výpůjčkyToolStripMenuItem,
            this.žánryToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(1264, 29);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // knihyToolStripMenuItem
            // 
            this.knihyToolStripMenuItem.Name = "knihyToolStripMenuItem";
            this.knihyToolStripMenuItem.Size = new System.Drawing.Size(55, 23);
            this.knihyToolStripMenuItem.Text = "Knihy";
            this.knihyToolStripMenuItem.Click += new System.EventHandler(this.knihyToolStripMenuItem_Click);
            // 
            // výpůjčkyToolStripMenuItem
            // 
            this.výpůjčkyToolStripMenuItem.Name = "výpůjčkyToolStripMenuItem";
            this.výpůjčkyToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.výpůjčkyToolStripMenuItem.Text = "Výpůjčky";
            this.výpůjčkyToolStripMenuItem.Click += new System.EventHandler(this.výpůjčkyToolStripMenuItem_Click);
            // 
            // žánryToolStripMenuItem
            // 
            this.žánryToolStripMenuItem.Name = "žánryToolStripMenuItem";
            this.žánryToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
            this.žánryToolStripMenuItem.Text = "Žánry";
            this.žánryToolStripMenuItem.Click += new System.EventHandler(this.žánryToolStripMenuItem_Click);
            // 
            // FormWithMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 884);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormWithMenu";
            this.Text = "FormWithMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWithMenu_FormClosing);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem knihyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem výpůjčkyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem žánryToolStripMenuItem;
    }
}