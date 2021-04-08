namespace Bdsh.Sync.Tabs.Database.LogicalStructure
{
    partial class DBLogicalStructureCompareControl
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
            this.buttonGenerateStructureCompareCSV = new System.Windows.Forms.Button();
            this.labelSelectConfigFile = new System.Windows.Forms.Label();
            this.textBoxConfigFilePath = new System.Windows.Forms.TextBox();
            this.buttonSelectConfigFilePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGenerateStructureCompareCSV
            // 
            this.buttonGenerateStructureCompareCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateStructureCompareCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateStructureCompareCSV.Location = new System.Drawing.Point(517, 66);
            this.buttonGenerateStructureCompareCSV.Name = "buttonGenerateStructureCompareCSV";
            this.buttonGenerateStructureCompareCSV.Size = new System.Drawing.Size(100, 35);
            this.buttonGenerateStructureCompareCSV.TabIndex = 57;
            this.buttonGenerateStructureCompareCSV.Text = "Gerar CSV";
            this.buttonGenerateStructureCompareCSV.UseVisualStyleBackColor = true;
            this.buttonGenerateStructureCompareCSV.Click += new System.EventHandler(this.ButtonGenerateStructureCompareCSV_Click);
            // 
            // labelSelectConfigFile
            // 
            this.labelSelectConfigFile.AutoSize = true;
            this.labelSelectConfigFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectConfigFile.Location = new System.Drawing.Point(7, 9);
            this.labelSelectConfigFile.Name = "labelSelectConfigFile";
            this.labelSelectConfigFile.Size = new System.Drawing.Size(297, 16);
            this.labelSelectConfigFile.TabIndex = 54;
            this.labelSelectConfigFile.Text = "Selecione o arquivo de configuração da analise:";
            // 
            // textBoxConfigFilePath
            // 
            this.textBoxConfigFilePath.AllowDrop = true;
            this.textBoxConfigFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConfigFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConfigFilePath.Location = new System.Drawing.Point(10, 28);
            this.textBoxConfigFilePath.Name = "textBoxConfigFilePath";
            this.textBoxConfigFilePath.Size = new System.Drawing.Size(501, 22);
            this.textBoxConfigFilePath.TabIndex = 55;
            // 
            // buttonSelectConfigFilePath
            // 
            this.buttonSelectConfigFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectConfigFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectConfigFilePath.Location = new System.Drawing.Point(517, 27);
            this.buttonSelectConfigFilePath.Name = "buttonSelectConfigFilePath";
            this.buttonSelectConfigFilePath.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectConfigFilePath.TabIndex = 56;
            this.buttonSelectConfigFilePath.Text = "Selecionar";
            this.buttonSelectConfigFilePath.UseVisualStyleBackColor = true;
            this.buttonSelectConfigFilePath.Click += new System.EventHandler(this.ButtonSelectConfigFilePath_Click);
            // 
            // DBLogicalStructureCompareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonGenerateStructureCompareCSV);
            this.Controls.Add(this.labelSelectConfigFile);
            this.Controls.Add(this.textBoxConfigFilePath);
            this.Controls.Add(this.buttonSelectConfigFilePath);
            this.Name = "DBLogicalStructureCompareControl";
            this.Size = new System.Drawing.Size(630, 118);
            this.Load += new System.EventHandler(this.DBLogicalStructureCompareControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerateStructureCompareCSV;
        private System.Windows.Forms.Label labelSelectConfigFile;
        private System.Windows.Forms.TextBox textBoxConfigFilePath;
        private System.Windows.Forms.Button buttonSelectConfigFilePath;
    }
}
