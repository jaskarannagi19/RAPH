namespace Vision.TADataReceiver
{
    partial class frmLogStatus
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
            LogForm = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.logViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeTACodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.punchTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verificationModeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceSerialNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logMessageDataGridViewTextBoxColumn,
            this.employeeTACodeDataGridViewTextBoxColumn,
            this.logTimeDataGridViewTextBoxColumn,
            this.punchTypeDataGridViewTextBoxColumn,
            this.verificationModeDataGridViewTextBoxColumn,
            this.terminalTypeDataGridViewTextBoxColumn,
            this.terminaIDDataGridViewTextBoxColumn,
            this.deviceSerialNoDataGridViewTextBoxColumn,
            this.transactionIDDataGridViewTextBoxColumn,
            this.eventTypeDataGridViewTextBoxColumn,
            this.Action});
            this.dataGridView1.DataSource = this.logViewModelBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1290, 381);
            this.dataGridView1.TabIndex = 0;
            // 
            // logViewModelBindingSource
            // 
            this.logViewModelBindingSource.DataSource = typeof(Vision.Model.BMDevice.LogViewModel);
            // 
            // logMessageDataGridViewTextBoxColumn
            // 
            this.logMessageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.logMessageDataGridViewTextBoxColumn.DataPropertyName = "LogMessage";
            this.logMessageDataGridViewTextBoxColumn.HeaderText = "Log Message";
            this.logMessageDataGridViewTextBoxColumn.Name = "logMessageDataGridViewTextBoxColumn";
            this.logMessageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeTACodeDataGridViewTextBoxColumn
            // 
            this.employeeTACodeDataGridViewTextBoxColumn.DataPropertyName = "EmployeeTACode";
            this.employeeTACodeDataGridViewTextBoxColumn.HeaderText = "TA Code";
            this.employeeTACodeDataGridViewTextBoxColumn.Name = "employeeTACodeDataGridViewTextBoxColumn";
            this.employeeTACodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logTimeDataGridViewTextBoxColumn
            // 
            this.logTimeDataGridViewTextBoxColumn.DataPropertyName = "LogTime";
            this.logTimeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.logTimeDataGridViewTextBoxColumn.Name = "logTimeDataGridViewTextBoxColumn";
            this.logTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // punchTypeDataGridViewTextBoxColumn
            // 
            this.punchTypeDataGridViewTextBoxColumn.DataPropertyName = "PunchType";
            this.punchTypeDataGridViewTextBoxColumn.HeaderText = "Punch Type";
            this.punchTypeDataGridViewTextBoxColumn.Name = "punchTypeDataGridViewTextBoxColumn";
            this.punchTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // verificationModeDataGridViewTextBoxColumn
            // 
            this.verificationModeDataGridViewTextBoxColumn.DataPropertyName = "VerificationMode";
            this.verificationModeDataGridViewTextBoxColumn.HeaderText = "Verification Mode";
            this.verificationModeDataGridViewTextBoxColumn.Name = "verificationModeDataGridViewTextBoxColumn";
            this.verificationModeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // terminalTypeDataGridViewTextBoxColumn
            // 
            this.terminalTypeDataGridViewTextBoxColumn.DataPropertyName = "TerminalType";
            this.terminalTypeDataGridViewTextBoxColumn.HeaderText = "Terminal Type";
            this.terminalTypeDataGridViewTextBoxColumn.Name = "terminalTypeDataGridViewTextBoxColumn";
            this.terminalTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // terminaIDDataGridViewTextBoxColumn
            // 
            this.terminaIDDataGridViewTextBoxColumn.DataPropertyName = "TerminaID";
            this.terminaIDDataGridViewTextBoxColumn.HeaderText = "Terminal ID";
            this.terminaIDDataGridViewTextBoxColumn.Name = "terminaIDDataGridViewTextBoxColumn";
            this.terminaIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deviceSerialNoDataGridViewTextBoxColumn
            // 
            this.deviceSerialNoDataGridViewTextBoxColumn.DataPropertyName = "DeviceSerialNo";
            this.deviceSerialNoDataGridViewTextBoxColumn.HeaderText = "Device Ser. No.";
            this.deviceSerialNoDataGridViewTextBoxColumn.Name = "deviceSerialNoDataGridViewTextBoxColumn";
            this.deviceSerialNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionIDDataGridViewTextBoxColumn
            // 
            this.transactionIDDataGridViewTextBoxColumn.DataPropertyName = "TransactionID";
            this.transactionIDDataGridViewTextBoxColumn.HeaderText = "Transaction ID";
            this.transactionIDDataGridViewTextBoxColumn.Name = "transactionIDDataGridViewTextBoxColumn";
            this.transactionIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eventTypeDataGridViewTextBoxColumn
            // 
            this.eventTypeDataGridViewTextBoxColumn.DataPropertyName = "EventType";
            this.eventTypeDataGridViewTextBoxColumn.HeaderText = "Event Type";
            this.eventTypeDataGridViewTextBoxColumn.Name = "eventTypeDataGridViewTextBoxColumn";
            this.eventTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.DataPropertyName = "Action";
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // frmLogStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 381);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmLogStatus";
            this.Text = "Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource logViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn logMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeTACodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn punchTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn verificationModeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceSerialNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
    }
}