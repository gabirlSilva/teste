using System;

namespace Bdsh.Sync.Tabs.Installation
{
    partial class InstallationCollectControl
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
            this.labelSelectInstallationDirectory = new System.Windows.Forms.Label();
            this.progressBarZipInstallation = new System.Windows.Forms.ProgressBar();
            this.textBoxZipName = new System.Windows.Forms.TextBox();
            this.textBoxInstallationDirectory = new System.Windows.Forms.TextBox();
            this.labelDefineZipName = new System.Windows.Forms.Label();
            this.buttonSelectInstallationDirectory = new System.Windows.Forms.Button();
            this.buttonGenerateZip = new System.Windows.Forms.Button();
            this.buttonGenerateStructure = new System.Windows.Forms.Button();
            this.labelSelectZipDirectory = new System.Windows.Forms.Label();
            this.buttonSelectZipDirectory = new System.Windows.Forms.Button();
            this.textBoxZipDirectory = new System.Windows.Forms.TextBox();
            this.backgroundWorkerGenerateZip = new System.ComponentModel.BackgroundWorker(); 
            this.BackgroundWorkerGenerateStructure = new System.ComponentModel.BackgroundWorker(); 
            this.checkBoxIncludeLog = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeExtensionBak = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeExtensionZip = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeExtensionDAT = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeFolderBkp = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeFolderBackup = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeFolderTemp = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxIncludeFilesByWriteTime = new System.Windows.Forms.CheckBox();
            this.writeTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.writeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectInstallationDirectory
            // 
            this.labelSelectInstallationDirectory.AutoSize = true;
            this.labelSelectInstallationDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectInstallationDirectory.Location = new System.Drawing.Point(7, 9);
            this.labelSelectInstallationDirectory.Name = "labelSelectInstallationDirectory";
            this.labelSelectInstallationDirectory.Size = new System.Drawing.Size(225, 16);
            this.labelSelectInstallationDirectory.TabIndex = 11;
            this.labelSelectInstallationDirectory.Text = "Selecione a pasta com a instalação:";
            // 
            // progressBarZipInstallation
            // 
            this.progressBarZipInstallation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarZipInstallation.Location = new System.Drawing.Point(10, 275);
            this.progressBarZipInstallation.Name = "progressBarZipInstallation";
            this.progressBarZipInstallation.Size = new System.Drawing.Size(328, 35);
            this.progressBarZipInstallation.TabIndex = 21;
            // 
            // textBoxZipName
            // 
            this.textBoxZipName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxZipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZipName.Location = new System.Drawing.Point(10, 235);
            this.textBoxZipName.Name = "textBoxZipName";
            this.textBoxZipName.Size = new System.Drawing.Size(608, 22);
            this.textBoxZipName.TabIndex = 20;
            // 
            // textBoxInstallationDirectory
            // 
            this.textBoxInstallationDirectory.AllowDrop = true;
            this.textBoxInstallationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInstallationDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstallationDirectory.Location = new System.Drawing.Point(10, 28);
            this.textBoxInstallationDirectory.Name = "textBoxInstallationDirectory";
            this.textBoxInstallationDirectory.Size = new System.Drawing.Size(503, 22);
            this.textBoxInstallationDirectory.TabIndex = 13;
            // 
            // labelDefineZipName
            // 
            this.labelDefineZipName.AutoSize = true;
            this.labelDefineZipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDefineZipName.Location = new System.Drawing.Point(7, 216);
            this.labelDefineZipName.Name = "labelDefineZipName";
            this.labelDefineZipName.Size = new System.Drawing.Size(139, 16);
            this.labelDefineZipName.TabIndex = 19;
            this.labelDefineZipName.Text = "Defina o nome do Zip:";
            // 
            // buttonSelectInstallationDirectory
            // 
            this.buttonSelectInstallationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectInstallationDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectInstallationDirectory.Location = new System.Drawing.Point(519, 27);
            this.buttonSelectInstallationDirectory.Name = "buttonSelectInstallationDirectory";
            this.buttonSelectInstallationDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectInstallationDirectory.TabIndex = 14;
            this.buttonSelectInstallationDirectory.Text = "Selecionar";
            this.buttonSelectInstallationDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectInstallationDirectory.Click += new System.EventHandler(this.ButtonSelectInstallationDirectory_Click);
            // 
            // buttonGenerateZip
            // 
            this.buttonGenerateZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateZip.Location = new System.Drawing.Point(519, 275);
            this.buttonGenerateZip.Name = "buttonGenerateZip";
            this.buttonGenerateZip.Size = new System.Drawing.Size(100, 35);
            this.buttonGenerateZip.TabIndex = 18;
            this.buttonGenerateZip.Text = "Gerar Zip";
            this.buttonGenerateZip.UseVisualStyleBackColor = true;
            this.buttonGenerateZip.Click += new System.EventHandler(this.ButtonGenerateZip_Click);
            
            // 
            // labelSelectZipDirectory
            // 
            this.labelSelectZipDirectory.AutoSize = true;
            this.labelSelectZipDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectZipDirectory.Location = new System.Drawing.Point(7, 152);
            this.labelSelectZipDirectory.Name = "labelSelectZipDirectory";
            this.labelSelectZipDirectory.Size = new System.Drawing.Size(223, 16);
            this.labelSelectZipDirectory.TabIndex = 15;
            this.labelSelectZipDirectory.Text = "Selecione a pasta onde ficará o Zip:";
            // 
            // buttonSelectZipDirectory
            // 
            this.buttonSelectZipDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectZipDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectZipDirectory.Location = new System.Drawing.Point(519, 170);
            this.buttonSelectZipDirectory.Name = "buttonSelectZipDirectory";
            this.buttonSelectZipDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonSelectZipDirectory.TabIndex = 17;
            this.buttonSelectZipDirectory.Text = "Selecionar";
            this.buttonSelectZipDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectZipDirectory.Click += new System.EventHandler(this.ButtonSelectZipDirectory_Click);
            // 
            // textBoxZipDirectory
            // 
            this.textBoxZipDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxZipDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZipDirectory.Location = new System.Drawing.Point(10, 171);
            this.textBoxZipDirectory.Name = "textBoxZipDirectory";
            this.textBoxZipDirectory.Size = new System.Drawing.Size(503, 22);
            this.textBoxZipDirectory.TabIndex = 16;
            // 
            // backgroundWorkerGenerateZip
            // 
            this.backgroundWorkerGenerateZip.WorkerReportsProgress = true;
            this.backgroundWorkerGenerateZip.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerGenerateZip_DoWork);
            this.backgroundWorkerGenerateZip.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerGenerateZip_ProgressChanged);
            this.backgroundWorkerGenerateZip.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerGenerateZip_RunWorkerCompleted);
            //
            // BackgroundWorkerGenerateStructure
            //
            this.BackgroundWorkerGenerateStructure.WorkerReportsProgress = true;
            this.BackgroundWorkerGenerateStructure.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerGenerateStructure_DoWork);
            this.BackgroundWorkerGenerateStructure.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerGenerateZip_ProgressChanged);
            this.BackgroundWorkerGenerateStructure.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerGenerateStructure_RunWorkerCompleted);
            // 
            // checkBoxIncludeLog
            // 
            this.checkBoxIncludeLog.AutoSize = true;
            this.checkBoxIncludeLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeLog.Location = new System.Drawing.Point(353, 103);
            this.checkBoxIncludeLog.Name = "checkBoxIncludeLog";
            this.checkBoxIncludeLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIncludeLog.Size = new System.Drawing.Size(49, 20);
            this.checkBoxIncludeLog.TabIndex = 29;
            this.checkBoxIncludeLog.Text = ".log";
            this.checkBoxIncludeLog.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeExtensionBak
            // 
            this.checkBoxIncludeExtensionBak.AutoSize = true;
            this.checkBoxIncludeExtensionBak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeExtensionBak.Location = new System.Drawing.Point(208, 103);
            this.checkBoxIncludeExtensionBak.Name = "checkBoxIncludeExtensionBak";
            this.checkBoxIncludeExtensionBak.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIncludeExtensionBak.Size = new System.Drawing.Size(53, 20);
            this.checkBoxIncludeExtensionBak.TabIndex = 28;
            this.checkBoxIncludeExtensionBak.Text = ".bak";
            this.checkBoxIncludeExtensionBak.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeExtensionZip
            // 
            this.checkBoxIncludeExtensionZip.AutoSize = true;
            this.checkBoxIncludeExtensionZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeExtensionZip.Location = new System.Drawing.Point(63, 103);
            this.checkBoxIncludeExtensionZip.Name = "checkBoxIncludeExtensionZip";
            this.checkBoxIncludeExtensionZip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIncludeExtensionZip.Size = new System.Drawing.Size(47, 20);
            this.checkBoxIncludeExtensionZip.TabIndex = 27;
            this.checkBoxIncludeExtensionZip.Text = ".zip";
            this.checkBoxIncludeExtensionZip.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeExtensionDAT
            // 
            this.checkBoxIncludeExtensionDAT.AutoSize = true;
            this.checkBoxIncludeExtensionDAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeExtensionDAT.Location = new System.Drawing.Point(498, 77);
            this.checkBoxIncludeExtensionDAT.Name = "checkBoxIncludeExtensionDAT";
            this.checkBoxIncludeExtensionDAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIncludeExtensionDAT.Size = new System.Drawing.Size(58, 20);
            this.checkBoxIncludeExtensionDAT.TabIndex = 26;
            this.checkBoxIncludeExtensionDAT.Text = ".DAT";
            this.checkBoxIncludeExtensionDAT.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeFolderBkp
            // 
            this.checkBoxIncludeFolderBkp.AutoSize = true;
            this.checkBoxIncludeFolderBkp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeFolderBkp.Location = new System.Drawing.Point(353, 77);
            this.checkBoxIncludeFolderBkp.Name = "checkBoxIncludeFolderBkp";
            this.checkBoxIncludeFolderBkp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIncludeFolderBkp.Size = new System.Drawing.Size(50, 20);
            this.checkBoxIncludeFolderBkp.TabIndex = 25;
            this.checkBoxIncludeFolderBkp.Text = "bkp";
            this.checkBoxIncludeFolderBkp.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeFolderBackup
            // 
            this.checkBoxIncludeFolderBackup.AutoSize = true;
            this.checkBoxIncludeFolderBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeFolderBackup.Location = new System.Drawing.Point(208, 77);
            this.checkBoxIncludeFolderBackup.Name = "checkBoxIncludeFolderBackup";
            this.checkBoxIncludeFolderBackup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIncludeFolderBackup.Size = new System.Drawing.Size(72, 20);
            this.checkBoxIncludeFolderBackup.TabIndex = 24;
            this.checkBoxIncludeFolderBackup.Text = "backup";
            this.checkBoxIncludeFolderBackup.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeFolderTemp
            // 
            this.checkBoxIncludeFolderTemp.AutoSize = true;
            this.checkBoxIncludeFolderTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeFolderTemp.Location = new System.Drawing.Point(63, 77);
            this.checkBoxIncludeFolderTemp.Name = "checkBoxIncludeFolderTemp";
            this.checkBoxIncludeFolderTemp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxIncludeFolderTemp.Size = new System.Drawing.Size(57, 20);
            this.checkBoxIncludeFolderTemp.TabIndex = 23;
            this.checkBoxIncludeFolderTemp.Text = "temp";
            this.checkBoxIncludeFolderTemp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 53);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Não incluir:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "dias";
            // 
            // checkBoxIncludeFilesByWriteTime
            // 
            this.checkBoxIncludeFilesByWriteTime.AutoSize = true;
            this.checkBoxIncludeFilesByWriteTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.checkBoxIncludeFilesByWriteTime.Location = new System.Drawing.Point(63, 129);
            this.checkBoxIncludeFilesByWriteTime.Name = "checkBoxIncludeFilesByWriteTime";
            this.checkBoxIncludeFilesByWriteTime.Size = new System.Drawing.Size(197, 20);
            this.checkBoxIncludeFilesByWriteTime.TabIndex = 33;
            this.checkBoxIncludeFilesByWriteTime.Text = "Arquivos criados há mais de";
            this.checkBoxIncludeFilesByWriteTime.UseVisualStyleBackColor = true;
            // 
            // writeTime
            // 
            this.writeTime.Location = new System.Drawing.Point(263, 126);
            this.writeTime.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.writeTime.Name = "writeTime";
            this.writeTime.Size = new System.Drawing.Size(38, 20);
            this.writeTime.TabIndex = 34;
            this.writeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonGenerateStructure
            // 
            this.buttonGenerateStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateStructure.Location = new System.Drawing.Point(344, 275);
            this.buttonGenerateStructure.Name = "buttonGenerateStructure";
            this.buttonGenerateStructure.Size = new System.Drawing.Size(169, 35);
            this.buttonGenerateStructure.TabIndex = 35;
            this.buttonGenerateStructure.Text = "Gerar Árvore de Estrutura";
            this.buttonGenerateStructure.UseVisualStyleBackColor = true;
            this.buttonGenerateStructure.Click += new System.EventHandler(this.buttonGenerateStructure_Click);
            // 
            // InstallationCollectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonGenerateStructure);
            this.Controls.Add(this.writeTime);
            this.Controls.Add(this.checkBoxIncludeFilesByWriteTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxIncludeLog);
            this.Controls.Add(this.checkBoxIncludeExtensionBak);
            this.Controls.Add(this.checkBoxIncludeExtensionZip);
            this.Controls.Add(this.checkBoxIncludeExtensionDAT);
            this.Controls.Add(this.checkBoxIncludeFolderBkp);
            this.Controls.Add(this.checkBoxIncludeFolderBackup);
            this.Controls.Add(this.checkBoxIncludeFolderTemp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSelectInstallationDirectory);
            this.Controls.Add(this.progressBarZipInstallation);
            this.Controls.Add(this.textBoxZipName);
            this.Controls.Add(this.textBoxInstallationDirectory);
            this.Controls.Add(this.labelDefineZipName);
            this.Controls.Add(this.buttonSelectInstallationDirectory);
            this.Controls.Add(this.buttonGenerateZip);
            this.Controls.Add(this.labelSelectZipDirectory);
            this.Controls.Add(this.buttonSelectZipDirectory);
            this.Controls.Add(this.textBoxZipDirectory);
            this.Name = "InstallationCollectControl";
            this.Size = new System.Drawing.Size(630, 322);
            this.Load += new System.EventHandler(this.InstallationCollectControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.writeTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }        

        #endregion

        private System.Windows.Forms.Label labelSelectInstallationDirectory;
        private System.Windows.Forms.ProgressBar progressBarZipInstallation;
        private System.Windows.Forms.TextBox textBoxZipName;
        private System.Windows.Forms.TextBox textBoxInstallationDirectory;
        private System.Windows.Forms.Label labelDefineZipName;
        private System.Windows.Forms.Button buttonSelectInstallationDirectory;
        private System.Windows.Forms.Button buttonGenerateZip;
        private System.Windows.Forms.Label labelSelectZipDirectory;
        private System.Windows.Forms.Button buttonSelectZipDirectory;
        private System.Windows.Forms.TextBox textBoxZipDirectory;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGenerateZip;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerGenerateStructure;
        private System.Windows.Forms.CheckBox checkBoxIncludeLog;
        private System.Windows.Forms.CheckBox checkBoxIncludeExtensionBak;
        private System.Windows.Forms.CheckBox checkBoxIncludeExtensionZip;
        private System.Windows.Forms.CheckBox checkBoxIncludeExtensionDAT;
        private System.Windows.Forms.CheckBox checkBoxIncludeFolderBkp;
        private System.Windows.Forms.CheckBox checkBoxIncludeFolderBackup;
        private System.Windows.Forms.CheckBox checkBoxIncludeFolderTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxIncludeFilesByWriteTime;
        private System.Windows.Forms.NumericUpDown writeTime;
        private System.Windows.Forms.Button buttonGenerateStructure;
    }
}
