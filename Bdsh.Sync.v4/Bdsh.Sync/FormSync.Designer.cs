namespace Bdsh.Sync
{
    partial class FormSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSync));
            this.tabControlSync = new System.Windows.Forms.TabControl();
            this.tabPageInstallation = new System.Windows.Forms.TabPage();
            this.Include = new System.Windows.Forms.TabControl();
            this.tabPageInstallationCollect = new System.Windows.Forms.TabPage();
            this.installationCollectControl = new Bdsh.Sync.Tabs.Installation.InstallationCollectControl();
            this.tabPageInstallationCompare = new System.Windows.Forms.TabPage();
            this.installationCompareControl = new Bdsh.Sync.Tabs.Installation.InstallationCompareControl();
            this.tabPageDBPhysicalStructure = new System.Windows.Forms.TabPage();
            this.tabControlDBPhysicalStructure = new System.Windows.Forms.TabControl();
            this.tabPageDBPhysicalStructureCollect = new System.Windows.Forms.TabPage();
            this.dbPhysicalStructureCollectControl = new Bdsh.Sync.Tabs.Database.PhysicalStructure.DBPhysicalStructureCollectControl();
            this.tabPageDBPhysicalStructureCompare = new System.Windows.Forms.TabPage();
            this.dbPhysicalStructureCompareControl = new Bdsh.Sync.Tabs.Database.PhysicalStructure.DBPhysicalStructureCompareControl();
            this.tabPageDBLogicalStructure = new System.Windows.Forms.TabPage();
            this.tabControlDBLogicalStructure = new System.Windows.Forms.TabControl();
            this.tabPageDBLogicalStructureCollect = new System.Windows.Forms.TabPage();
            this.dbLogicalStructureCollectControl = new Bdsh.Sync.Tabs.Database.LogicalStructure.DBLogicalStructureCollectControl();
            this.tabPageDBLogicalStructureCompare = new System.Windows.Forms.TabPage();
            this.dbLogicalStructureCompareControl = new Bdsh.Sync.Tabs.Database.LogicalStructure.DBLogicalStructureCompareControl();
            this.tabControlSync.SuspendLayout();
            this.tabPageInstallation.SuspendLayout();
            this.Include.SuspendLayout();
            this.tabPageInstallationCollect.SuspendLayout();
            this.tabPageInstallationCompare.SuspendLayout();
            this.tabPageDBPhysicalStructure.SuspendLayout();
            this.tabControlDBPhysicalStructure.SuspendLayout();
            this.tabPageDBPhysicalStructureCollect.SuspendLayout();
            this.tabPageDBPhysicalStructureCompare.SuspendLayout();
            this.tabPageDBLogicalStructure.SuspendLayout();
            this.tabControlDBLogicalStructure.SuspendLayout();
            this.tabPageDBLogicalStructureCollect.SuspendLayout();
            this.tabPageDBLogicalStructureCompare.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSync
            // 
            this.tabControlSync.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSync.Controls.Add(this.tabPageInstallation);
            this.tabControlSync.Controls.Add(this.tabPageDBPhysicalStructure);
            this.tabControlSync.Controls.Add(this.tabPageDBLogicalStructure);
            this.tabControlSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlSync.Location = new System.Drawing.Point(0, 0);
            this.tabControlSync.Name = "tabControlSync";
            this.tabControlSync.SelectedIndex = 0;
            this.tabControlSync.Size = new System.Drawing.Size(636, 585);
            this.tabControlSync.TabIndex = 0;
            this.tabControlSync.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPageInstallation
            // 
            this.tabPageInstallation.Controls.Add(this.Include);
            this.tabPageInstallation.Location = new System.Drawing.Point(4, 25);
            this.tabPageInstallation.Name = "tabPageInstallation";
            this.tabPageInstallation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstallation.Size = new System.Drawing.Size(628, 556);
            this.tabPageInstallation.TabIndex = 0;
            this.tabPageInstallation.Text = "Instalação";
            this.tabPageInstallation.UseVisualStyleBackColor = true;
            // 
            // Include
            // 
            this.Include.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Include.Controls.Add(this.tabPageInstallationCollect);
            this.Include.Controls.Add(this.tabPageInstallationCompare);
            this.Include.Location = new System.Drawing.Point(-3, -1);
            this.Include.Name = "Include";
            this.Include.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Include.RightToLeftLayout = true;
            this.Include.SelectedIndex = 0;
            this.Include.Size = new System.Drawing.Size(632, 560);
            this.Include.TabIndex = 0;
            this.Include.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPageInstallationCollect
            // 
            this.tabPageInstallationCollect.Controls.Add(this.installationCollectControl);
            this.tabPageInstallationCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageInstallationCollect.Location = new System.Drawing.Point(4, 25);
            this.tabPageInstallationCollect.Name = "tabPageInstallationCollect";
            this.tabPageInstallationCollect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstallationCollect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageInstallationCollect.Size = new System.Drawing.Size(624, 531);
            this.tabPageInstallationCollect.TabIndex = 0;
            this.tabPageInstallationCollect.Text = "Coleta";
            this.tabPageInstallationCollect.UseVisualStyleBackColor = true;
            // 
            // installationCollectControl
            // 
            this.installationCollectControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.installationCollectControl.Location = new System.Drawing.Point(-2, -1);
            this.installationCollectControl.Name = "installationCollectControl";
            this.installationCollectControl.Size = new System.Drawing.Size(630, 310);
            this.installationCollectControl.TabIndex = 0;
            this.installationCollectControl.Load += new System.EventHandler(this.installationCollectControl_Load);
            // 
            // tabPageInstallationCompare
            // 
            this.tabPageInstallationCompare.Controls.Add(this.installationCompareControl);
            this.tabPageInstallationCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageInstallationCompare.Location = new System.Drawing.Point(4, 25);
            this.tabPageInstallationCompare.Name = "tabPageInstallationCompare";
            this.tabPageInstallationCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstallationCompare.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageInstallationCompare.Size = new System.Drawing.Size(624, 531);
            this.tabPageInstallationCompare.TabIndex = 1;
            this.tabPageInstallationCompare.Text = "Comparação";
            this.tabPageInstallationCompare.UseVisualStyleBackColor = true;
            // 
            // installationCompareControl
            // 
            this.installationCompareControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.installationCompareControl.Location = new System.Drawing.Point(-2, -1);
            this.installationCompareControl.Name = "installationCompareControl";
            this.installationCompareControl.Size = new System.Drawing.Size(630, 574);
            this.installationCompareControl.TabIndex = 0;
            // 
            // tabPageDBPhysicalStructure
            // 
            this.tabPageDBPhysicalStructure.Controls.Add(this.tabControlDBPhysicalStructure);
            this.tabPageDBPhysicalStructure.Location = new System.Drawing.Point(4, 25);
            this.tabPageDBPhysicalStructure.Name = "tabPageDBPhysicalStructure";
            this.tabPageDBPhysicalStructure.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDBPhysicalStructure.Size = new System.Drawing.Size(628, 556);
            this.tabPageDBPhysicalStructure.TabIndex = 1;
            this.tabPageDBPhysicalStructure.Text = "DB - Estrutura Física";
            this.tabPageDBPhysicalStructure.UseVisualStyleBackColor = true;
            // 
            // tabControlDBPhysicalStructure
            // 
            this.tabControlDBPhysicalStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlDBPhysicalStructure.Controls.Add(this.tabPageDBPhysicalStructureCollect);
            this.tabControlDBPhysicalStructure.Controls.Add(this.tabPageDBPhysicalStructureCompare);
            this.tabControlDBPhysicalStructure.Location = new System.Drawing.Point(-3, -1);
            this.tabControlDBPhysicalStructure.Name = "tabControlDBPhysicalStructure";
            this.tabControlDBPhysicalStructure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControlDBPhysicalStructure.RightToLeftLayout = true;
            this.tabControlDBPhysicalStructure.SelectedIndex = 0;
            this.tabControlDBPhysicalStructure.Size = new System.Drawing.Size(632, 560);
            this.tabControlDBPhysicalStructure.TabIndex = 1;
            this.tabControlDBPhysicalStructure.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPageDBPhysicalStructureCollect
            // 
            this.tabPageDBPhysicalStructureCollect.Controls.Add(this.dbPhysicalStructureCollectControl);
            this.tabPageDBPhysicalStructureCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDBPhysicalStructureCollect.Location = new System.Drawing.Point(4, 25);
            this.tabPageDBPhysicalStructureCollect.Name = "tabPageDBPhysicalStructureCollect";
            this.tabPageDBPhysicalStructureCollect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDBPhysicalStructureCollect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageDBPhysicalStructureCollect.Size = new System.Drawing.Size(624, 531);
            this.tabPageDBPhysicalStructureCollect.TabIndex = 0;
            this.tabPageDBPhysicalStructureCollect.Text = "Coleta";
            this.tabPageDBPhysicalStructureCollect.UseVisualStyleBackColor = true;
            // 
            // dbPhysicalStructureCollectControl
            // 
            this.dbPhysicalStructureCollectControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbPhysicalStructureCollectControl.Location = new System.Drawing.Point(-2, -1);
            this.dbPhysicalStructureCollectControl.Name = "dbPhysicalStructureCollectControl";
            this.dbPhysicalStructureCollectControl.Size = new System.Drawing.Size(630, 250);
            this.dbPhysicalStructureCollectControl.TabIndex = 0;
            // 
            // tabPageDBPhysicalStructureCompare
            // 
            this.tabPageDBPhysicalStructureCompare.Controls.Add(this.dbPhysicalStructureCompareControl);
            this.tabPageDBPhysicalStructureCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDBPhysicalStructureCompare.Location = new System.Drawing.Point(4, 25);
            this.tabPageDBPhysicalStructureCompare.Name = "tabPageDBPhysicalStructureCompare";
            this.tabPageDBPhysicalStructureCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDBPhysicalStructureCompare.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageDBPhysicalStructureCompare.Size = new System.Drawing.Size(624, 531);
            this.tabPageDBPhysicalStructureCompare.TabIndex = 1;
            this.tabPageDBPhysicalStructureCompare.Text = "Comparação";
            this.tabPageDBPhysicalStructureCompare.UseVisualStyleBackColor = true;
            // 
            // dbPhysicalStructureCompareControl
            // 
            this.dbPhysicalStructureCompareControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbPhysicalStructureCompareControl.Location = new System.Drawing.Point(-2, -1);
            this.dbPhysicalStructureCompareControl.Name = "dbPhysicalStructureCompareControl";
            this.dbPhysicalStructureCompareControl.Size = new System.Drawing.Size(630, 386);
            this.dbPhysicalStructureCompareControl.TabIndex = 0;
            // 
            // tabPageDBLogicalStructure
            // 
            this.tabPageDBLogicalStructure.Controls.Add(this.tabControlDBLogicalStructure);
            this.tabPageDBLogicalStructure.Location = new System.Drawing.Point(4, 25);
            this.tabPageDBLogicalStructure.Name = "tabPageDBLogicalStructure";
            this.tabPageDBLogicalStructure.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDBLogicalStructure.Size = new System.Drawing.Size(628, 556);
            this.tabPageDBLogicalStructure.TabIndex = 2;
            this.tabPageDBLogicalStructure.Text = "DB - Estrutura Lógica";
            this.tabPageDBLogicalStructure.UseVisualStyleBackColor = true;
            // 
            // tabControlDBLogicalStructure
            // 
            this.tabControlDBLogicalStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlDBLogicalStructure.Controls.Add(this.tabPageDBLogicalStructureCollect);
            this.tabControlDBLogicalStructure.Controls.Add(this.tabPageDBLogicalStructureCompare);
            this.tabControlDBLogicalStructure.Location = new System.Drawing.Point(-3, -1);
            this.tabControlDBLogicalStructure.Name = "tabControlDBLogicalStructure";
            this.tabControlDBLogicalStructure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControlDBLogicalStructure.RightToLeftLayout = true;
            this.tabControlDBLogicalStructure.SelectedIndex = 0;
            this.tabControlDBLogicalStructure.Size = new System.Drawing.Size(632, 560);
            this.tabControlDBLogicalStructure.TabIndex = 1;
            this.tabControlDBLogicalStructure.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPageDBLogicalStructureCollect
            // 
            this.tabPageDBLogicalStructureCollect.Controls.Add(this.dbLogicalStructureCollectControl);
            this.tabPageDBLogicalStructureCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDBLogicalStructureCollect.Location = new System.Drawing.Point(4, 25);
            this.tabPageDBLogicalStructureCollect.Name = "tabPageDBLogicalStructureCollect";
            this.tabPageDBLogicalStructureCollect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDBLogicalStructureCollect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageDBLogicalStructureCollect.Size = new System.Drawing.Size(624, 531);
            this.tabPageDBLogicalStructureCollect.TabIndex = 0;
            this.tabPageDBLogicalStructureCollect.Text = "Coleta";
            this.tabPageDBLogicalStructureCollect.UseVisualStyleBackColor = true;
            // 
            // dbLogicalStructureCollectControl
            // 
            this.dbLogicalStructureCollectControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbLogicalStructureCollectControl.Location = new System.Drawing.Point(-2, -1);
            this.dbLogicalStructureCollectControl.Name = "dbLogicalStructureCollectControl";
            this.dbLogicalStructureCollectControl.Size = new System.Drawing.Size(630, 460);
            this.dbLogicalStructureCollectControl.TabIndex = 0;
            // 
            // tabPageDBLogicalStructureCompare
            // 
            this.tabPageDBLogicalStructureCompare.Controls.Add(this.dbLogicalStructureCompareControl);
            this.tabPageDBLogicalStructureCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDBLogicalStructureCompare.Location = new System.Drawing.Point(4, 25);
            this.tabPageDBLogicalStructureCompare.Name = "tabPageDBLogicalStructureCompare";
            this.tabPageDBLogicalStructureCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDBLogicalStructureCompare.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPageDBLogicalStructureCompare.Size = new System.Drawing.Size(624, 531);
            this.tabPageDBLogicalStructureCompare.TabIndex = 1;
            this.tabPageDBLogicalStructureCompare.Text = "Comparação";
            this.tabPageDBLogicalStructureCompare.UseVisualStyleBackColor = true;
            // 
            // dbLogicalStructureCompareControl
            // 
            this.dbLogicalStructureCompareControl.Location = new System.Drawing.Point(-2, -1);
            this.dbLogicalStructureCompareControl.Name = "dbLogicalStructureCompareControl";
            this.dbLogicalStructureCompareControl.Size = new System.Drawing.Size(630, 105);
            this.dbLogicalStructureCompareControl.TabIndex = 0;
            // 
            // FormSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 583);
            this.Controls.Add(this.tabControlSync);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSync";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BDS Sync";
            this.tabControlSync.ResumeLayout(false);
            this.tabPageInstallation.ResumeLayout(false);
            this.Include.ResumeLayout(false);
            this.tabPageInstallationCollect.ResumeLayout(false);
            this.tabPageInstallationCompare.ResumeLayout(false);
            this.tabPageDBPhysicalStructure.ResumeLayout(false);
            this.tabControlDBPhysicalStructure.ResumeLayout(false);
            this.tabPageDBPhysicalStructureCollect.ResumeLayout(false);
            this.tabPageDBPhysicalStructureCompare.ResumeLayout(false);
            this.tabPageDBLogicalStructure.ResumeLayout(false);
            this.tabControlDBLogicalStructure.ResumeLayout(false);
            this.tabPageDBLogicalStructureCollect.ResumeLayout(false);
            this.tabPageDBLogicalStructureCompare.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSync;
        private System.Windows.Forms.TabPage tabPageInstallation;
        private System.Windows.Forms.TabPage tabPageDBPhysicalStructure;
        private System.Windows.Forms.TabPage tabPageDBLogicalStructure;
        private System.Windows.Forms.TabControl Include;
        private System.Windows.Forms.TabPage tabPageInstallationCollect;
        private System.Windows.Forms.TabPage tabPageInstallationCompare;
        private Tabs.Installation.InstallationCollectControl installationCollectControl;
        private Tabs.Installation.InstallationCompareControl installationCompareControl;
        private System.Windows.Forms.TabControl tabControlDBPhysicalStructure;
        private System.Windows.Forms.TabPage tabPageDBPhysicalStructureCollect;
        private System.Windows.Forms.TabPage tabPageDBPhysicalStructureCompare;
        private Tabs.Database.PhysicalStructure.DBPhysicalStructureCollectControl dbPhysicalStructureCollectControl;
        private Tabs.Database.PhysicalStructure.DBPhysicalStructureCompareControl dbPhysicalStructureCompareControl;
        private System.Windows.Forms.TabControl tabControlDBLogicalStructure;
        private System.Windows.Forms.TabPage tabPageDBLogicalStructureCollect;
        private System.Windows.Forms.TabPage tabPageDBLogicalStructureCompare;
        private Tabs.Database.LogicalStructure.DBLogicalStructureCollectControl dbLogicalStructureCollectControl;
        private Tabs.Database.LogicalStructure.DBLogicalStructureCompareControl dbLogicalStructureCompareControl;
    }
}