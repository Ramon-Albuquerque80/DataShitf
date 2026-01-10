namespace DataShift.Menu_Principal
{
    partial class MainMenu
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.comboTurnos = new System.Windows.Forms.ComboBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.BtnProdutos = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panelMenu.Controls.Add(this.buttonAdicionar);
            this.panelMenu.Controls.Add(this.comboTurnos);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 450);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.ForeColor = System.Drawing.Color.Teal;
            this.buttonAdicionar.Location = new System.Drawing.Point(165, 3);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(22, 21);
            this.buttonAdicionar.TabIndex = 1;
            this.buttonAdicionar.Text = "+";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // comboTurnos
            // 
            this.comboTurnos.FormattingEnabled = true;
            this.comboTurnos.Location = new System.Drawing.Point(3, 3);
            this.comboTurnos.Name = "comboTurnos";
            this.comboTurnos.Size = new System.Drawing.Size(156, 21);
            this.comboTurnos.TabIndex = 0;
            this.comboTurnos.SelectedIndexChanged += new System.EventHandler(this.ComboTurnos_SelectedIndexChanged);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(600, 80);
            this.panelTitleBar.TabIndex = 1;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelDesktop.Controls.Add(this.BtnProdutos);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(200, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(600, 370);
            this.panelDesktop.TabIndex = 2;
            // 
            // BtnProdutos
            // 
            this.BtnProdutos.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProdutos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnProdutos.Location = new System.Drawing.Point(0, 0);
            this.BtnProdutos.Name = "BtnProdutos";
            this.BtnProdutos.Size = new System.Drawing.Size(600, 70);
            this.BtnProdutos.TabIndex = 0;
            this.BtnProdutos.Text = "Produtos";
            this.BtnProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnProdutos.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.panelMenu.ResumeLayout(false);
            this.panelDesktop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button BtnProdutos;
        private System.Windows.Forms.ComboBox comboTurnos;
        private System.Windows.Forms.Button buttonAdicionar;
    }
}