namespace Bdsh.Sync.Tabs.Installation
{
    partial class InstallationCompareControl
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
            this.buttonGenerateInstallationComparePDF = new System.Windows.Forms.Button();
            this.textBoxInstallationComparePDFName = new System.Windows.Forms.TextBox();
            this.labelDefineInstallationComparePDFName = new System.Windows.Forms.Label();
            this.labelSelectInstallationComparePDFDirectory = new System.Windows.Forms.Label();
            this.textBoxInstallationComparePDFDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectInstallationComparePDFDirectory = new System.Windows.Forms.Button();
            this.dataGridViewInstallationCompare = new System.Windows.Forms.DataGridView();
            this.ColumnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAnalyzedVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBaseVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAnalyzeInstallation = new System.Windows.Forms.Button();
            this.labelSelectBaseInstallationDirectory = new System.Windows.Forms.Label();
            this.textBoxBaseInstallationDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectBaseInstallationDirectory = new System.Windows.Forms.Button();
            this.labelSelectInstallationToBeAnalyzedDirectory = new System.Windows.Forms.Label();
            this.textBoxInstallationToBeAnalyzedDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectInstallationToBeAnalyzedDirectory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstallationCompare)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerateInstallationComparePDF
            // 
            this.buttonGenerateInstallationComparePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateInstallationComparePDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateInstallationComparePDF.Location = new System.Drawing.Point(519, 454);
            this.buttonGenerateInstallationComparePDF.Name = "buttonGenerateInstallationComparePDF";
            this.buttonGenerateInstallationComparePDF.Size = new System.Drawing.Size(100, 35);
            this.buttonGenerateInstallationComparePDF.TabIndex = 34;
            this.buttonGenerateInstallationComparePDF.Text = "Gerar PDF";
            this.buttonGenerateInstallationComparePDF.UseVisualStyleBackColor = true;
            this.buttonGenerateInstallationComparePDF.Click += new System.EventHandler(this.ButtonGenerateInstallationComparePDF_Click);
            // 
            // textBoxInstallationComparePDFName
            // 
            this.textBoxInstallationComparePDFName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInstallationComparePDFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstallationComparePDFName.Location = new System.Drawing.Point(10, 417);
            this.textBoxInstallationComparePDFName.Name = "textBoxInstallationComparePDFName";
            this.textBoxInstallationComparePDFName.Size = new System.Drawing.Size(608, 22);
            this.textBoxInstallationComparePDFName.TabIndex = 33;
            // 
            // labelDefineInstallationComparePDFName
            // 
            this.labelDefineInstallationComparePDFName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDefineInstallationComparePDFName.AutoSize = true;
            this.labelDefineInstallationComparePDFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDefineInstallationComparePDFName.Location = new System.Drawing.Point(7, 398);
            this.labelDefineInstallationComparePDFName.Name = "labelDefineInstallationComparePDFName";
            this.labelDefineInstallationComparePDFName.Size = new System.Drawing.Size(147, 16);
            this.labelDefineInstallationComparePDFName.TabIndex = 32;
            this.labelDefineInstallationComparePDFName.Text = "Defina o nome do PDF:";
            // 
            // labelSelectInstallationComparePDFDirectory
            // 
            this.labelSelectInstallationComparePDFDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSelectInstallationComparePDFDirectory.AutoSize = true;
            this.labelSelectInstallationComparePDFDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectInstallationComparePDFDirectory.Location = new System.Drawing.Point(7, 347);
            this.labelSelectInstallationComparePDFDirectory.Name = "labelSelectInstallationComparePDFDirectory";
            this.labelSelectInstallationComparePDFDirectory.Size = new System.Drawing.Size(231, 16);
            this.labelSelectInstallationComparePDFDirectory.TabIndex = 29;
            this.labelSelectInstallationComparePDFDirectory.Text = "Selecione a pasta onde ficará o PDF:";
            // 
            // textBoxInstallationComparePDFDirectory
            // 
            this.textBoxInstallationComparePDFDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInstallationComparePDFDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstallationComparePDFDirectory.Location = new System.Drawing.Point(10, 366);
            this.textBoxInstallationComparePDFDirectory.Name = "textBoxInstallationComparePDFDirectory";
            this.textBoxInstallationComparePDFDirectory.Size = new System.Drawing.Size(503, 22);
            this.textBoxInstallationComparePDFDirectory.TabIndex = 30;
            // 
            // buttonSelectInstallationComparePDFDirectory
            // 
            this.buttonSelectInstallationComparePDFDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectInstallationComparePDFDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectInstallationComparePDFDirectory.Location = new System.Drawing.Point(519, 365);
            this.buttonSelectInstallationComparePDFDirectory.Name = "buttonSelectInstallationComparePDFDirectory";
            this.buttonSelectInstallationComparePDFDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectInstallationComparePDFDirectory.TabIndex = 31;
            this.buttonSelectInstallationComparePDFDirectory.Text = "Selecionar";
            this.buttonSelectInstallationComparePDFDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectInstallationComparePDFDirectory.Click += new System.EventHandler(this.ButtonSelectInstallationComparePDFDirectory_Click);
            // 
            // dataGridViewInstallationCompare
            // 
            this.dataGridViewInstallationCompare.AllowUserToAddRows = false;
            this.dataGridViewInstallationCompare.AllowUserToDeleteRows = false;
            this.dataGridViewInstallationCompare.AllowUserToResizeRows = false;
            this.dataGridViewInstallationCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInstallationCompare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInstallationCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInstallationCompare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFile,
            this.ColumnAnalyzedVersion,
            this.ColumnBaseVersion});
            this.dataGridViewInstallationCompare.Location = new System.Drawing.Point(10, 114);
            this.dataGridViewInstallationCompare.Name = "dataGridViewInstallationCompare";
            this.dataGridViewInstallationCompare.ReadOnly = true;
            this.dataGridViewInstallationCompare.Size = new System.Drawing.Size(608, 180);
            this.dataGridViewInstallationCompare.TabIndex = 28;
            // 
            // ColumnFile
            // 
            this.ColumnFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFile.HeaderText = "Arquivo";
            this.ColumnFile.Name = "ColumnFile";
            this.ColumnFile.ReadOnly = true;
            // 
            // ColumnAnalyzedVersion
            // 
            this.ColumnAnalyzedVersion.HeaderText = "Versão Analizada";
            this.ColumnAnalyzedVersion.Name = "ColumnAnalyzedVersion";
            this.ColumnAnalyzedVersion.ReadOnly = true;
            this.ColumnAnalyzedVersion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnAnalyzedVersion.Width = 150;
            // 
            // ColumnBaseVersion
            // 
            this.ColumnBaseVersion.HeaderText = "Versão Base";
            this.ColumnBaseVersion.Name = "ColumnBaseVersion";
            this.ColumnBaseVersion.ReadOnly = true;
            this.ColumnBaseVersion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnBaseVersion.Width = 150;
            // 
            // buttonAnalyzeInstallation
            // 
            this.buttonAnalyzeInstallation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalyzeInstallation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnalyzeInstallation.Location = new System.Drawing.Point(519, 311);
            this.buttonAnalyzeInstallation.Name = "buttonAnalyzeInstallation";
            this.buttonAnalyzeInstallation.Size = new System.Drawing.Size(100, 35);
            this.buttonAnalyzeInstallation.TabIndex = 27;
            this.buttonAnalyzeInstallation.Text = "Analizar";
            this.buttonAnalyzeInstallation.UseVisualStyleBackColor = true;
            this.buttonAnalyzeInstallation.Click += new System.EventHandler(this.ButtonAnalyzeInstallation_Click);
            // 
            // labelSelectBaseInstallationDirectory
            // 
            this.labelSelectBaseInstallationDirectory.AutoSize = true;
            this.labelSelectBaseInstallationDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectBaseInstallationDirectory.Location = new System.Drawing.Point(7, 67);
            this.labelSelectBaseInstallationDirectory.Name = "labelSelectBaseInstallationDirectory";
            this.labelSelectBaseInstallationDirectory.Size = new System.Drawing.Size(259, 16);
            this.labelSelectBaseInstallationDirectory.TabIndex = 24;
            this.labelSelectBaseInstallationDirectory.Text = "Selecione a pasta com a instalação base:";
            // 
            // textBoxBaseInstallationDirectory
            // 
            this.textBoxBaseInstallationDirectory.AllowDrop = true;
            this.textBoxBaseInstallationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBaseInstallationDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBaseInstallationDirectory.Location = new System.Drawing.Point(10, 86);
            this.textBoxBaseInstallationDirectory.Name = "textBoxBaseInstallationDirectory";
            this.textBoxBaseInstallationDirectory.Size = new System.Drawing.Size(503, 22);
            this.textBoxBaseInstallationDirectory.TabIndex = 25;
            // 
            // buttonSelectBaseInstallationDirectory
            // 
            this.buttonSelectBaseInstallationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectBaseInstallationDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectBaseInstallationDirectory.Location = new System.Drawing.Point(519, 85);
            this.buttonSelectBaseInstallationDirectory.Name = "buttonSelectBaseInstallationDirectory";
            this.buttonSelectBaseInstallationDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectBaseInstallationDirectory.TabIndex = 26;
            this.buttonSelectBaseInstallationDirectory.Text = "Selecionar";
            this.buttonSelectBaseInstallationDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectBaseInstallationDirectory.Click += new System.EventHandler(this.ButtonSelectBaseInstallationDirectory_Click);
            // 
            // labelSelectInstallationToBeAnalyzedDirectory
            // 
            this.labelSelectInstallationToBeAnalyzedDirectory.AutoSize = true;
            this.labelSelectInstallationToBeAnalyzedDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectInstallationToBeAnalyzedDirectory.Location = new System.Drawing.Point(7, 9);
            this.labelSelectInstallationToBeAnalyzedDirectory.Name = "labelSelectInstallationToBeAnalyzedDirectory";
            this.labelSelectInstallationToBeAnalyzedDirectory.Size = new System.Drawing.Size(321, 16);
            this.labelSelectInstallationToBeAnalyzedDirectory.TabIndex = 21;
            this.labelSelectInstallationToBeAnalyzedDirectory.Text = "Selecione a pasta com a instalação a ser analisada:";
            // 
            // textBoxInstallationToBeAnalyzedDirectory
            // 
            this.textBoxInstallationToBeAnalyzedDirectory.AllowDrop = true;
            this.textBoxInstallationToBeAnalyzedDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInstallationToBeAnalyzedDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstallationToBeAnalyzedDirectory.Location = new System.Drawing.Point(10, 28);
            this.textBoxInstallationToBeAnalyzedDirectory.Name = "textBoxInstallationToBeAnalyzedDirectory";
            this.textBoxInstallationToBeAnalyzedDirectory.Size = new System.Drawing.Size(503, 22);
            this.textBoxInstallationToBeAnalyzedDirectory.TabIndex = 22;
            // 
            // buttonSelectInstallationToBeAnalyzedDirectory
            // 
            this.buttonSelectInstallationToBeAnalyzedDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectInstallationToBeAnalyzedDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectInstallationToBeAnalyzedDirectory.Location = new System.Drawing.Point(519, 27);
            this.buttonSelectInstallationToBeAnalyzedDirectory.Name = "buttonSelectInstallationToBeAnalyzedDirectory";
            this.buttonSelectInstallationToBeAnalyzedDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectInstallationToBeAnalyzedDirectory.TabIndex = 23;
            this.buttonSelectInstallationToBeAnalyzedDirectory.Text = "Selecionar";
            this.buttonSelectInstallationToBeAnalyzedDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectInstallationToBeAnalyzedDirectory.Click += new System.EventHandler(this.ButtonSelectInstallationToBeAnalyzedDirectory_Click);
            // 
            // InstallationCompareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonGenerateInstallationComparePDF);
            this.Controls.Add(this.textBoxInstallationComparePDFName);
            this.Controls.Add(this.labelDefineInstallationComparePDFName);
            this.Controls.Add(this.labelSelectInstallationComparePDFDirectory);
            this.Controls.Add(this.textBoxInstallationComparePDFDirectory);
            this.Controls.Add(this.buttonSelectInstallationComparePDFDirectory);
            this.Controls.Add(this.dataGridViewInstallationCompare);
            this.Controls.Add(this.buttonAnalyzeInstallation);
            this.Controls.Add(this.labelSelectBaseInstallationDirectory);
            this.Controls.Add(this.textBoxBaseInstallationDirectory);
            this.Controls.Add(this.buttonSelectBaseInstallationDirectory);
            this.Controls.Add(this.labelSelectInstallationToBeAnalyzedDirectory);
            this.Controls.Add(this.textBoxInstallationToBeAnalyzedDirectory);
            this.Controls.Add(this.buttonSelectInstallationToBeAnalyzedDirectory);
            this.Name = "InstallationCompareControl";
            this.Size = new System.Drawing.Size(630, 535);
            this.Load += new System.EventHandler(this.InstallationCompareControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstallationCompare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateInstallationComparePDF;
        private System.Windows.Forms.TextBox textBoxInstallationComparePDFName;
        private System.Windows.Forms.Label labelDefineInstallationComparePDFName;
        private System.Windows.Forms.Label labelSelectInstallationComparePDFDirectory;
        private System.Windows.Forms.TextBox textBoxInstallationComparePDFDirectory;
        private System.Windows.Forms.Button buttonSelectInstallationComparePDFDirectory;
        private System.Windows.Forms.DataGridView dataGridViewInstallationCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAnalyzedVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBaseVersion;
        private System.Windows.Forms.Button buttonAnalyzeInstallation;
        private System.Windows.Forms.Label labelSelectBaseInstallationDirectory;
        private System.Windows.Forms.TextBox textBoxBaseInstallationDirectory;
        private System.Windows.Forms.Button buttonSelectBaseInstallationDirectory;
        private System.Windows.Forms.Label labelSelectInstallationToBeAnalyzedDirectory;
        private System.Windows.Forms.TextBox textBoxInstallationToBeAnalyzedDirectory;
        private System.Windows.Forms.Button buttonSelectInstallationToBeAnalyzedDirectory;
    }
}
