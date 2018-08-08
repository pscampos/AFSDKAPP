namespace FinalProjectApp
{
    partial class frmFinalProjectApp
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
            this.dthInicio = new System.Windows.Forms.DateTimePicker();
            this.dthFim = new System.Windows.Forms.DateTimePicker();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.piPointTagSearchPage1 = new OSIsoft.AF.UI.PropertyPage.PIPointTagSearchPage();
            this.lblDthInicio = new System.Windows.Forms.Label();
            this.lblDthFim = new System.Windows.Forms.Label();
            this.chkShowSnapshot = new System.Windows.Forms.CheckBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dthInicio
            // 
            this.dthInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dthInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dthInicio.Location = new System.Drawing.Point(360, 47);
            this.dthInicio.Name = "dthInicio";
            this.dthInicio.Size = new System.Drawing.Size(200, 20);
            this.dthInicio.TabIndex = 0;
            // 
            // dthFim
            // 
            this.dthFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dthFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dthFim.Location = new System.Drawing.Point(648, 47);
            this.dthFim.Name = "dthFim";
            this.dthFim.Size = new System.Drawing.Size(200, 20);
            this.dthFim.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(322, 122);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(733, 374);
            this.dataGrid.TabIndex = 2;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(863, 47);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(114, 23);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(560, 93);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(114, 23);
            this.btnUpdateData.TabIndex = 4;
            this.btnUpdateData.Text = "Update Data";
            this.btnUpdateData.UseVisualStyleBackColor = true;
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Location = new System.Drawing.Point(680, 93);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(114, 23);
            this.btnDeleteData.TabIndex = 5;
            this.btnDeleteData.Text = "Delete Data";
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // piPointTagSearchPage1
            // 
            this.piPointTagSearchPage1.AccessibleDescription = "PI point tag search property page";
            this.piPointTagSearchPage1.AccessibleName = "PI point tag search page";
            this.piPointTagSearchPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.piPointTagSearchPage1.BackColor = System.Drawing.Color.Transparent;
            this.piPointTagSearchPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.piPointTagSearchPage1.HelpContext = ((long)(0));
            this.piPointTagSearchPage1.Location = new System.Drawing.Point(18, 35);
            this.piPointTagSearchPage1.Margin = new System.Windows.Forms.Padding(0);
            this.piPointTagSearchPage1.MinimumSize = new System.Drawing.Size(250, 300);
            this.piPointTagSearchPage1.Name = "piPointTagSearchPage1";
            this.piPointTagSearchPage1.Size = new System.Drawing.Size(292, 461);
            this.piPointTagSearchPage1.TabIndex = 6;
            // 
            // lblDthInicio
            // 
            this.lblDthInicio.AutoSize = true;
            this.lblDthInicio.Location = new System.Drawing.Point(319, 51);
            this.lblDthInicio.Name = "lblDthInicio";
            this.lblDthInicio.Size = new System.Drawing.Size(32, 13);
            this.lblDthInicio.TabIndex = 7;
            this.lblDthInicio.Text = "Start:";
            // 
            // lblDthFim
            // 
            this.lblDthFim.AutoSize = true;
            this.lblDthFim.Location = new System.Drawing.Point(616, 51);
            this.lblDthFim.Name = "lblDthFim";
            this.lblDthFim.Size = new System.Drawing.Size(29, 13);
            this.lblDthFim.TabIndex = 8;
            this.lblDthFim.Text = "End:";
            // 
            // chkShowSnapshot
            // 
            this.chkShowSnapshot.AutoSize = true;
            this.chkShowSnapshot.Location = new System.Drawing.Point(810, 97);
            this.chkShowSnapshot.Name = "chkShowSnapshot";
            this.chkShowSnapshot.Size = new System.Drawing.Size(101, 17);
            this.chkShowSnapshot.TabIndex = 9;
            this.chkShowSnapshot.Text = "Show Snapshot";
            this.chkShowSnapshot.UseVisualStyleBackColor = true;
            this.chkShowSnapshot.CheckedChanged += new System.EventHandler(this.chkShowSnapshot_CheckedChanged);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(322, 93);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(114, 23);
            this.btnClearData.TabIndex = 10;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(442, 93);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(114, 23);
            this.btnImportExcel.TabIndex = 11;
            this.btnImportExcel.Text = "Import Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmFinalProjectApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 511);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.chkShowSnapshot);
            this.Controls.Add(this.lblDthFim);
            this.Controls.Add(this.lblDthInicio);
            this.Controls.Add(this.piPointTagSearchPage1);
            this.Controls.Add(this.btnDeleteData);
            this.Controls.Add(this.btnUpdateData);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.dthFim);
            this.Controls.Add(this.dthInicio);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmFinalProjectApp";
            this.Text = "App";
            this.Load += new System.EventHandler(this.frmFinalProjectApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dthInicio;
        private System.Windows.Forms.DateTimePicker dthFim;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.Button btnDeleteData;
        private OSIsoft.AF.UI.PropertyPage.PIPointTagSearchPage piPointTagSearchPage1;
        private System.Windows.Forms.Label lblDthInicio;
        private System.Windows.Forms.Label lblDthFim;
        private System.Windows.Forms.CheckBox chkShowSnapshot;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

