namespace Bdsh.Sync.Tabs.Database.PhysicalStructure
{
    partial class DBPhysicalStructureCompareControl
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonSQLServer = new System.Windows.Forms.RadioButton();
            this.radioButtonOracle = new System.Windows.Forms.RadioButton();
            this.buttonGenerateStructureCompareCSV = new System.Windows.Forms.Button();
            this.textBoxStructureCompareCSVName = new System.Windows.Forms.TextBox();
            this.labelDefineStructureCompareCSVName = new System.Windows.Forms.Label();
            this.labelSelectStructureCompareCSVDirectory = new System.Windows.Forms.Label();
            this.textBoxStructureCompareCSVDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectStructureCompareCSVDirectory = new System.Windows.Forms.Button();
            this.labelSelectDatabaseType = new System.Windows.Forms.Label();
            this.textBoxStructureBaseConnectionString = new System.Windows.Forms.TextBox();
            this.radioButtonStructureBaseConnectionString = new System.Windows.Forms.RadioButton();
            this.radioButtonStructureBaseCSV = new System.Windows.Forms.RadioButton();
            this.labelSelectStructureBase = new System.Windows.Forms.Label();
            this.textBoxStructureBaseCSV = new System.Windows.Forms.TextBox();
            this.buttonSelectStructureBaseCSV = new System.Windows.Forms.Button();
            this.labelSelectStructureToBeComparedCSV = new System.Windows.Forms.Label();
            this.textBoxStructureToBeComparedCSV = new System.Windows.Forms.TextBox();
            this.buttonSelectStructureToBeComparedCSV = new System.Windows.Forms.Button();
            this.backgroundWorkerGenerateStructureCompareCSV = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButtonSQLServer);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonOracle);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(153, 175);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(181, 28);
            this.flowLayoutPanel1.TabIndex = 70;
            // 
            // radioButtonSQLServer
            // 
            this.radioButtonSQLServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSQLServer.AutoSize = true;
            this.radioButtonSQLServer.Checked = true;
            this.radioButtonSQLServer.Location = new System.Drawing.Point(3, 3);
            this.radioButtonSQLServer.Name = "radioButtonSQLServer";
            this.radioButtonSQLServer.Size = new System.Drawing.Size(77, 17);
            this.radioButtonSQLServer.TabIndex = 45;
            this.radioButtonSQLServer.TabStop = true;
            this.radioButtonSQLServer.Text = "SQLServer";
            this.radioButtonSQLServer.UseVisualStyleBackColor = true;
            // 
            // radioButtonOracle
            // 
            this.radioButtonOracle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonOracle.AutoSize = true;
            this.radioButtonOracle.Location = new System.Drawing.Point(86, 3);
            this.radioButtonOracle.Name = "radioButtonOracle";
            this.radioButtonOracle.Size = new System.Drawing.Size(56, 17);
            this.radioButtonOracle.TabIndex = 46;
            this.radioButtonOracle.Text = "Oracle";
            this.radioButtonOracle.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateStructureCompareCSV
            // 
            this.buttonGenerateStructureCompareCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateStructureCompareCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateStructureCompareCSV.Location = new System.Drawing.Point(521, 341);
            this.buttonGenerateStructureCompareCSV.Name = "buttonGenerateStructureCompareCSV";
            this.buttonGenerateStructureCompareCSV.Size = new System.Drawing.Size(100, 35);
            this.buttonGenerateStructureCompareCSV.TabIndex = 69;
            this.buttonGenerateStructureCompareCSV.Text = "Gerar CSV";
            this.buttonGenerateStructureCompareCSV.UseVisualStyleBackColor = true;
            this.buttonGenerateStructureCompareCSV.Click += new System.EventHandler(this.ButtonGenerateStructureCompareCSV_Click);
            // 
            // textBoxStructureCompareCSVName
            // 
            this.textBoxStructureCompareCSVName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStructureCompareCSVName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStructureCompareCSVName.Location = new System.Drawing.Point(12, 301);
            this.textBoxStructureCompareCSVName.Name = "textBoxStructureCompareCSVName";
            this.textBoxStructureCompareCSVName.Size = new System.Drawing.Size(608, 22);
            this.textBoxStructureCompareCSVName.TabIndex = 68;
            // 
            // labelDefineStructureCompareCSVName
            // 
            this.labelDefineStructureCompareCSVName.AutoSize = true;
            this.labelDefineStructureCompareCSVName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDefineStructureCompareCSVName.Location = new System.Drawing.Point(9, 282);
            this.labelDefineStructureCompareCSVName.Name = "labelDefineStructureCompareCSVName";
            this.labelDefineStructureCompareCSVName.Size = new System.Drawing.Size(147, 16);
            this.labelDefineStructureCompareCSVName.TabIndex = 67;
            this.labelDefineStructureCompareCSVName.Text = "Defina o nome do CSV:";
            // 
            // labelSelectStructureCompareCSVDirectory
            // 
            this.labelSelectStructureCompareCSVDirectory.AutoSize = true;
            this.labelSelectStructureCompareCSVDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectStructureCompareCSVDirectory.Location = new System.Drawing.Point(9, 218);
            this.labelSelectStructureCompareCSVDirectory.Name = "labelSelectStructureCompareCSVDirectory";
            this.labelSelectStructureCompareCSVDirectory.Size = new System.Drawing.Size(231, 16);
            this.labelSelectStructureCompareCSVDirectory.TabIndex = 64;
            this.labelSelectStructureCompareCSVDirectory.Text = "Selecione a pasta onde ficará o CSV:";
            // 
            // textBoxStructureCompareCSVDirectory
            // 
            this.textBoxStructureCompareCSVDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStructureCompareCSVDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStructureCompareCSVDirectory.Location = new System.Drawing.Point(12, 237);
            this.textBoxStructureCompareCSVDirectory.Name = "textBoxStructureCompareCSVDirectory";
            this.textBoxStructureCompareCSVDirectory.Size = new System.Drawing.Size(503, 22);
            this.textBoxStructureCompareCSVDirectory.TabIndex = 65;
            // 
            // buttonSelectStructureCompareCSVDirectory
            // 
            this.buttonSelectStructureCompareCSVDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectStructureCompareCSVDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectStructureCompareCSVDirectory.Location = new System.Drawing.Point(521, 236);
            this.buttonSelectStructureCompareCSVDirectory.Name = "buttonSelectStructureCompareCSVDirectory";
            this.buttonSelectStructureCompareCSVDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectStructureCompareCSVDirectory.TabIndex = 66;
            this.buttonSelectStructureCompareCSVDirectory.Text = "Selecionar";
            this.buttonSelectStructureCompareCSVDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectStructureCompareCSVDirectory.Click += new System.EventHandler(this.ButtonSelectStructureCompareCSVDirectory_Click);
            // 
            // labelSelectDatabaseType
            // 
            this.labelSelectDatabaseType.AutoSize = true;
            this.labelSelectDatabaseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectDatabaseType.Location = new System.Drawing.Point(9, 179);
            this.labelSelectDatabaseType.Name = "labelSelectDatabaseType";
            this.labelSelectDatabaseType.Size = new System.Drawing.Size(122, 16);
            this.labelSelectDatabaseType.TabIndex = 63;
            this.labelSelectDatabaseType.Text = "Tipo da database :";
            // 
            // textBoxStructureBaseConnectionString
            // 
            this.textBoxStructureBaseConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStructureBaseConnectionString.Enabled = false;
            this.textBoxStructureBaseConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStructureBaseConnectionString.Location = new System.Drawing.Point(150, 126);
            this.textBoxStructureBaseConnectionString.Name = "textBoxStructureBaseConnectionString";
            this.textBoxStructureBaseConnectionString.Size = new System.Drawing.Size(468, 22);
            this.textBoxStructureBaseConnectionString.TabIndex = 62;
            // 
            // radioButtonStructureBaseConnectionString
            // 
            this.radioButtonStructureBaseConnectionString.AutoSize = true;
            this.radioButtonStructureBaseConnectionString.Location = new System.Drawing.Point(10, 127);
            this.radioButtonStructureBaseConnectionString.Name = "radioButtonStructureBaseConnectionString";
            this.radioButtonStructureBaseConnectionString.Size = new System.Drawing.Size(111, 17);
            this.radioButtonStructureBaseConnectionString.TabIndex = 61;
            this.radioButtonStructureBaseConnectionString.Text = "String de conexão";
            this.radioButtonStructureBaseConnectionString.UseVisualStyleBackColor = true;
            this.radioButtonStructureBaseConnectionString.CheckedChanged += new System.EventHandler(this.RadioButtonStructureBaseConnectionString_CheckedChanged);
            // 
            // radioButtonStructureBaseCSV
            // 
            this.radioButtonStructureBaseCSV.AutoSize = true;
            this.radioButtonStructureBaseCSV.Checked = true;
            this.radioButtonStructureBaseCSV.Location = new System.Drawing.Point(10, 101);
            this.radioButtonStructureBaseCSV.Name = "radioButtonStructureBaseCSV";
            this.radioButtonStructureBaseCSV.Size = new System.Drawing.Size(61, 17);
            this.radioButtonStructureBaseCSV.TabIndex = 60;
            this.radioButtonStructureBaseCSV.TabStop = true;
            this.radioButtonStructureBaseCSV.Text = "Arquivo";
            this.radioButtonStructureBaseCSV.UseVisualStyleBackColor = true;
            this.radioButtonStructureBaseCSV.CheckedChanged += new System.EventHandler(this.RadioButtonStructureBaseCSV_CheckedChanged);
            // 
            // labelSelectStructureBase
            // 
            this.labelSelectStructureBase.AutoSize = true;
            this.labelSelectStructureBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectStructureBase.Location = new System.Drawing.Point(7, 81);
            this.labelSelectStructureBase.Name = "labelSelectStructureBase";
            this.labelSelectStructureBase.Size = new System.Drawing.Size(178, 16);
            this.labelSelectStructureBase.TabIndex = 57;
            this.labelSelectStructureBase.Text = "Selecione a database base:";
            // 
            // textBoxStructureBaseCSV
            // 
            this.textBoxStructureBaseCSV.AllowDrop = true;
            this.textBoxStructureBaseCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStructureBaseCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStructureBaseCSV.Location = new System.Drawing.Point(88, 100);
            this.textBoxStructureBaseCSV.Name = "textBoxStructureBaseCSV";
            this.textBoxStructureBaseCSV.Size = new System.Drawing.Size(425, 22);
            this.textBoxStructureBaseCSV.TabIndex = 58;
            // 
            // buttonSelectStructureBaseCSV
            // 
            this.buttonSelectStructureBaseCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectStructureBaseCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectStructureBaseCSV.Location = new System.Drawing.Point(519, 99);
            this.buttonSelectStructureBaseCSV.Name = "buttonSelectStructureBaseCSV";
            this.buttonSelectStructureBaseCSV.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectStructureBaseCSV.TabIndex = 59;
            this.buttonSelectStructureBaseCSV.Text = "Selecionar";
            this.buttonSelectStructureBaseCSV.UseVisualStyleBackColor = true;
            this.buttonSelectStructureBaseCSV.Click += new System.EventHandler(this.ButtonSelectStructureBaseCSV_Click);
            // 
            // labelSelectStructureToBeComparedCSV
            // 
            this.labelSelectStructureToBeComparedCSV.AutoSize = true;
            this.labelSelectStructureToBeComparedCSV.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelSelectStructureToBeComparedCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectStructureToBeComparedCSV.Location = new System.Drawing.Point(7, 9);
            this.labelSelectStructureToBeComparedCSV.Name = "labelSelectStructureToBeComparedCSV";
            this.labelSelectStructureToBeComparedCSV.Size = new System.Drawing.Size(313, 16);
            this.labelSelectStructureToBeComparedCSV.TabIndex = 54;
            this.labelSelectStructureToBeComparedCSV.Text = "Selecione o arquivo da  database  a ser analisada:";
            // 
            // textBoxStructureToBeComparedCSV
            // 
            this.textBoxStructureToBeComparedCSV.AllowDrop = true;
            this.textBoxStructureToBeComparedCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStructureToBeComparedCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStructureToBeComparedCSV.Location = new System.Drawing.Point(10, 28);
            this.textBoxStructureToBeComparedCSV.Name = "textBoxStructureToBeComparedCSV";
            this.textBoxStructureToBeComparedCSV.Size = new System.Drawing.Size(503, 22);
            this.textBoxStructureToBeComparedCSV.TabIndex = 55;
            // 
            // buttonSelectStructureToBeComparedCSV
            // 
            this.buttonSelectStructureToBeComparedCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectStructureToBeComparedCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectStructureToBeComparedCSV.Location = new System.Drawing.Point(519, 27);
            this.buttonSelectStructureToBeComparedCSV.Name = "buttonSelectStructureToBeComparedCSV";
            this.buttonSelectStructureToBeComparedCSV.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectStructureToBeComparedCSV.TabIndex = 56;
            this.buttonSelectStructureToBeComparedCSV.Text = "Selecionar";
            this.buttonSelectStructureToBeComparedCSV.UseVisualStyleBackColor = true;
            this.buttonSelectStructureToBeComparedCSV.Click += new System.EventHandler(this.ButtonSelectStructureToBeComparedCSV_Click);
            // 
            // backgroundWorkerGenerateStructureCompareCSV
            // 
            this.backgroundWorkerGenerateStructureCompareCSV.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerGenerateStructureCompareCSV_DoWork);
            // 
            // DBPhysicalStructureCompareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonGenerateStructureCompareCSV);
            this.Controls.Add(this.textBoxStructureCompareCSVName);
            this.Controls.Add(this.labelDefineStructureCompareCSVName);
            this.Controls.Add(this.labelSelectStructureCompareCSVDirectory);
            this.Controls.Add(this.textBoxStructureCompareCSVDirectory);
            this.Controls.Add(this.buttonSelectStructureCompareCSVDirectory);
            this.Controls.Add(this.labelSelectDatabaseType);
            this.Controls.Add(this.textBoxStructureBaseConnectionString);
            this.Controls.Add(this.radioButtonStructureBaseConnectionString);
            this.Controls.Add(this.radioButtonStructureBaseCSV);
            this.Controls.Add(this.labelSelectStructureBase);
            this.Controls.Add(this.textBoxStructureBaseCSV);
            this.Controls.Add(this.buttonSelectStructureBaseCSV);
            this.Controls.Add(this.labelSelectStructureToBeComparedCSV);
            this.Controls.Add(this.textBoxStructureToBeComparedCSV);
            this.Controls.Add(this.buttonSelectStructureToBeComparedCSV);
            this.Name = "DBPhysicalStructureCompareControl";
            this.Size = new System.Drawing.Size(630, 386);
            this.Load += new System.EventHandler(this.DBPhysicalStructureCompare_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonSQLServer;
        private System.Windows.Forms.RadioButton radioButtonOracle;
        private System.Windows.Forms.Button buttonGenerateStructureCompareCSV;
        private System.Windows.Forms.TextBox textBoxStructureCompareCSVName;
        private System.Windows.Forms.Label labelDefineStructureCompareCSVName;
        private System.Windows.Forms.Label labelSelectStructureCompareCSVDirectory;
        private System.Windows.Forms.TextBox textBoxStructureCompareCSVDirectory;
        private System.Windows.Forms.Button buttonSelectStructureCompareCSVDirectory;
        private System.Windows.Forms.Label labelSelectDatabaseType;
        private System.Windows.Forms.TextBox textBoxStructureBaseConnectionString;
        private System.Windows.Forms.RadioButton radioButtonStructureBaseConnectionString;
        private System.Windows.Forms.RadioButton radioButtonStructureBaseCSV;
        private System.Windows.Forms.Label labelSelectStructureBase;
        private System.Windows.Forms.TextBox textBoxStructureBaseCSV;
        private System.Windows.Forms.Button buttonSelectStructureBaseCSV;
        private System.Windows.Forms.Label labelSelectStructureToBeComparedCSV;
        private System.Windows.Forms.TextBox textBoxStructureToBeComparedCSV;
        private System.Windows.Forms.Button buttonSelectStructureToBeComparedCSV;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGenerateStructureCompareCSV;
    }
}
