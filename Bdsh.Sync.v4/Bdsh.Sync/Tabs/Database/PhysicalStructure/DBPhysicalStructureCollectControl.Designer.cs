namespace Bdsh.Sync.Tabs.Database.PhysicalStructure
{
    partial class DBPhysicalStructureCollectControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.buttonGenerateCSV = new System.Windows.Forms.Button();
            this.textBoxCSVName = new System.Windows.Forms.TextBox();
            this.labelDefineCSVName = new System.Windows.Forms.Label();
            this.labelSelecCSVDirectory = new System.Windows.Forms.Label();
            this.textBoxCSVDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectCSVDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConnectionString.Location = new System.Drawing.Point(10, 28);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(608, 22);
            this.textBoxConnectionString.TabIndex = 38;
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionString.Location = new System.Drawing.Point(7, 9);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(119, 16);
            this.labelConnectionString.TabIndex = 37;
            this.labelConnectionString.Text = "String de conexão:";
            // 
            // buttonGenerateCSV
            // 
            this.buttonGenerateCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateCSV.Location = new System.Drawing.Point(519, 195);
            this.buttonGenerateCSV.Name = "buttonGenerateCSV";
            this.buttonGenerateCSV.Size = new System.Drawing.Size(100, 35);
            this.buttonGenerateCSV.TabIndex = 36;
            this.buttonGenerateCSV.Text = "Gerar CSV";
            this.buttonGenerateCSV.UseVisualStyleBackColor = true;
            this.buttonGenerateCSV.Click += new System.EventHandler(this.ButtonGenerateCSV_Click);
            // 
            // textBoxCSVName
            // 
            this.textBoxCSVName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCSVName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCSVName.Location = new System.Drawing.Point(10, 156);
            this.textBoxCSVName.Name = "textBoxCSVName";
            this.textBoxCSVName.Size = new System.Drawing.Size(608, 22);
            this.textBoxCSVName.TabIndex = 35;
            // 
            // labelDefineCSVName
            // 
            this.labelDefineCSVName.AutoSize = true;
            this.labelDefineCSVName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDefineCSVName.Location = new System.Drawing.Point(7, 137);
            this.labelDefineCSVName.Name = "labelDefineCSVName";
            this.labelDefineCSVName.Size = new System.Drawing.Size(161, 16);
            this.labelDefineCSVName.TabIndex = 34;
            this.labelDefineCSVName.Text = "Defina o nome dos CSVs:";
            // 
            // labelSelecCSVDirectory
            // 
            this.labelSelecCSVDirectory.AutoSize = true;
            this.labelSelecCSVDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelecCSVDirectory.Location = new System.Drawing.Point(7, 73);
            this.labelSelecCSVDirectory.Name = "labelSelecCSVDirectory";
            this.labelSelecCSVDirectory.Size = new System.Drawing.Size(253, 16);
            this.labelSelecCSVDirectory.TabIndex = 31;
            this.labelSelecCSVDirectory.Text = "Selecione a pasta onde ficarão os CSVs:";
            // 
            // textBoxCSVDirectory
            // 
            this.textBoxCSVDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCSVDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCSVDirectory.Location = new System.Drawing.Point(10, 92);
            this.textBoxCSVDirectory.Name = "textBoxCSVDirectory";
            this.textBoxCSVDirectory.Size = new System.Drawing.Size(503, 22);
            this.textBoxCSVDirectory.TabIndex = 32;
            // 
            // buttonSelectCSVDirectory
            // 
            this.buttonSelectCSVDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectCSVDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectCSVDirectory.Location = new System.Drawing.Point(519, 91);
            this.buttonSelectCSVDirectory.Name = "buttonSelectCSVDirectory";
            this.buttonSelectCSVDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectCSVDirectory.TabIndex = 33;
            this.buttonSelectCSVDirectory.Text = "Selecionar";
            this.buttonSelectCSVDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectCSVDirectory.Click += new System.EventHandler(this.ButtonSelectCSVDirectory_Click);
            // 
            // DBPhysicalStructureCollectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxConnectionString);
            this.Controls.Add(this.labelConnectionString);
            this.Controls.Add(this.buttonGenerateCSV);
            this.Controls.Add(this.textBoxCSVName);
            this.Controls.Add(this.labelDefineCSVName);
            this.Controls.Add(this.labelSelecCSVDirectory);
            this.Controls.Add(this.textBoxCSVDirectory);
            this.Controls.Add(this.buttonSelectCSVDirectory);
            this.Name = "DBPhysicalStructureCollectControl";
            this.Size = new System.Drawing.Size(630, 240);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.Button buttonGenerateCSV;
        private System.Windows.Forms.TextBox textBoxCSVName;
        private System.Windows.Forms.Label labelDefineCSVName;
        private System.Windows.Forms.Label labelSelecCSVDirectory;
        private System.Windows.Forms.TextBox textBoxCSVDirectory;
        private System.Windows.Forms.Button buttonSelectCSVDirectory;
    }
}
