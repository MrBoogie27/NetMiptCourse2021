namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFileChange = new System.Windows.Forms.Label();
            this.pathFileText = new System.Windows.Forms.TextBox();
            this.changeFileButton = new System.Windows.Forms.Button();
            this.openFileDb = new System.Windows.Forms.OpenFileDialog();
            this.Submit = new System.Windows.Forms.Button();
            this.bySoket = new System.Windows.Forms.RadioButton();
            this.byMQ = new System.Windows.Forms.RadioButton();
            this.byRPC = new System.Windows.Forms.RadioButton();
            this.fioText = new System.Windows.Forms.TextBox();
            this.groupText = new System.Windows.Forms.TextBox();
            this.taskNumeric = new System.Windows.Forms.NumericUpDown();
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.labelTask = new System.Windows.Forms.Label();
            this.addressServerText = new System.Windows.Forms.TextBox();
            this.labelAddressServer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.taskNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFileChange
            // 
            this.labelFileChange.AutoSize = true;
            this.labelFileChange.Location = new System.Drawing.Point(12, 185);
            this.labelFileChange.Name = "labelFileChange";
            this.labelFileChange.Size = new System.Drawing.Size(168, 17);
            this.labelFileChange.TabIndex = 0;
            this.labelFileChange.Text = "Выберите файл c кодом";
            // 
            // pathFileText
            // 
            this.pathFileText.Enabled = false;
            this.pathFileText.Location = new System.Drawing.Point(12, 205);
            this.pathFileText.Name = "pathFileText";
            this.pathFileText.Size = new System.Drawing.Size(291, 22);
            this.pathFileText.TabIndex = 1;
            // 
            // changeFileButton
            // 
            this.changeFileButton.Location = new System.Drawing.Point(309, 205);
            this.changeFileButton.Name = "changeFileButton";
            this.changeFileButton.Size = new System.Drawing.Size(44, 23);
            this.changeFileButton.TabIndex = 2;
            this.changeFileButton.Text = "...";
            this.changeFileButton.UseVisualStyleBackColor = true;
            this.changeFileButton.Click += new System.EventHandler(this.ChangeFileButton_Click);
            // 
            // openFileDb
            // 
            this.openFileDb.FileName = "D:\\4 курс\\ТРРП\\Входной\\sales.db";
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(12, 237);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(341, 29);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Отправить работу";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // bySoket
            // 
            this.bySoket.AutoSize = true;
            this.bySoket.Checked = true;
            this.bySoket.Location = new System.Drawing.Point(478, 31);
            this.bySoket.Name = "bySoket";
            this.bySoket.Size = new System.Drawing.Size(65, 21);
            this.bySoket.TabIndex = 5;
            this.bySoket.TabStop = true;
            this.bySoket.Text = "Soket";
            this.bySoket.UseVisualStyleBackColor = true;
            // 
            // byMQ
            // 
            this.byMQ.AutoSize = true;
            this.byMQ.Location = new System.Drawing.Point(478, 58);
            this.byMQ.Name = "byMQ";
            this.byMQ.Size = new System.Drawing.Size(126, 21);
            this.byMQ.TabIndex = 6;
            this.byMQ.Text = "Message query";
            this.byMQ.UseVisualStyleBackColor = true;
            // 
            // byRPC
            // 
            this.byRPC.AutoSize = true;
            this.byRPC.Location = new System.Drawing.Point(478, 85);
            this.byRPC.Name = "byRPC";
            this.byRPC.Size = new System.Drawing.Size(65, 21);
            this.byRPC.TabIndex = 7;
            this.byRPC.Text = "gRPC";
            this.byRPC.UseVisualStyleBackColor = true;
            // 
            // fioText
            // 
            this.fioText.Location = new System.Drawing.Point(12, 30);
            this.fioText.Name = "fioText";
            this.fioText.Size = new System.Drawing.Size(291, 22);
            this.fioText.TabIndex = 8;
            // 
            // groupText
            // 
            this.groupText.Location = new System.Drawing.Point(12, 84);
            this.groupText.Name = "groupText";
            this.groupText.Size = new System.Drawing.Size(291, 22);
            this.groupText.TabIndex = 9;
            // 
            // taskNumeric
            // 
            this.taskNumeric.Location = new System.Drawing.Point(12, 142);
            this.taskNumeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.taskNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.taskNumeric.Name = "taskNumeric";
            this.taskNumeric.Size = new System.Drawing.Size(90, 22);
            this.taskNumeric.TabIndex = 10;
            this.taskNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(12, 9);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(101, 17);
            this.labelFIO.TabIndex = 11;
            this.labelFIO.Text = "Введите ФИО";
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(12, 64);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(158, 17);
            this.labelGroup.TabIndex = 12;
            this.labelGroup.Text = "Введите номер группы";
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.Location = new System.Drawing.Point(12, 122);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(159, 17);
            this.labelTask.TabIndex = 13;
            this.labelTask.Text = "Введите номер задачи";
            // 
            // addressServerText
            // 
            this.addressServerText.Location = new System.Drawing.Point(439, 142);
            this.addressServerText.Name = "addressServerText";
            this.addressServerText.Size = new System.Drawing.Size(165, 22);
            this.addressServerText.TabIndex = 14;
            // 
            // labelAddressServer
            // 
            this.labelAddressServer.AutoSize = true;
            this.labelAddressServer.Location = new System.Drawing.Point(436, 122);
            this.labelAddressServer.Name = "labelAddressServer";
            this.labelAddressServer.Size = new System.Drawing.Size(164, 17);
            this.labelAddressServer.TabIndex = 15;
            this.labelAddressServer.Text = "Введите адрес сервера";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 279);
            this.Controls.Add(this.labelAddressServer);
            this.Controls.Add(this.addressServerText);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.taskNumeric);
            this.Controls.Add(this.groupText);
            this.Controls.Add(this.fioText);
            this.Controls.Add(this.byRPC);
            this.Controls.Add(this.byMQ);
            this.Controls.Add(this.bySoket);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.changeFileButton);
            this.Controls.Add(this.pathFileText);
            this.Controls.Add(this.labelFileChange);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFileChange;
        private System.Windows.Forms.TextBox pathFileText;
        private System.Windows.Forms.Button changeFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDb;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.RadioButton bySoket;
        private System.Windows.Forms.RadioButton byMQ;
        private System.Windows.Forms.RadioButton byRPC;
        private System.Windows.Forms.TextBox fioText;
        private System.Windows.Forms.TextBox groupText;
        private System.Windows.Forms.NumericUpDown taskNumeric;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.TextBox addressServerText;
        private System.Windows.Forms.Label labelAddressServer;
    }
}

