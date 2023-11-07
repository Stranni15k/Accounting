namespace AccountingMain
{
    partial class FormAddAUpdate
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            listBoxControl1 = new CustListBox.ListBoxControl();
            label3 = new Label();
            controlInputRangeDate1 = new ControlsLibraryNet60.Input.ControlInputRangeDate();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 22);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(25, 97);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 23);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 79);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 2;
            label2.Text = "Даты авторизаций";
            // 
            // listBoxControl1
            // 
            listBoxControl1.Location = new Point(25, 152);
            listBoxControl1.Name = "listBoxControl1";
            listBoxControl1.Size = new Size(213, 131);
            listBoxControl1.TabIndex = 4;
            listBoxControl1.Value = null;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 134);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 5;
            label3.Text = "Город";
            // 
            // controlInputRangeDate1
            // 
            controlInputRangeDate1.Location = new Point(25, 304);
            controlInputRangeDate1.Margin = new Padding(5, 3, 5, 3);
            controlInputRangeDate1.MaxDate = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            controlInputRangeDate1.MinDate = new DateTime(0L);
            controlInputRangeDate1.Name = "controlInputRangeDate1";
            controlInputRangeDate1.Size = new Size(213, 23);
            controlInputRangeDate1.TabIndex = 6;
            controlInputRangeDate1.Value = new DateTime(2023, 11, 7, 23, 31, 40, 449);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 286);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 7;
            label4.Text = "Дата создания";
            // 
            // button1
            // 
            button1.Location = new Point(44, 336);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(145, 336);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormAddAUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 371);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(controlInputRangeDate1);
            Controls.Add(label3);
            Controls.Add(listBoxControl1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "FormAddAUpdate";
            Text = "FormAddAUpdate";
            FormClosing += FormAddAUpdate_FormClosing;
            Load += FormAddAUpdate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private CustListBox.ListBoxControl listBoxControl1;
        private Label label3;
        private ControlsLibraryNet60.Input.ControlInputRangeDate controlInputRangeDate1;
        private Label label4;
        private Button button1;
        private Button button2;
    }
}