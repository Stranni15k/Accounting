namespace AccountingMain
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            создатьToolStripMenuItem = new ToolStripMenuItem();
            изменитьToolStripMenuItem = new ToolStripMenuItem();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            wordToolStripMenuItem = new ToolStripMenuItem();
            pdfToolStripMenuItem = new ToolStripMenuItem();
            excelToolStripMenuItem = new ToolStripMenuItem();
            справочникToolStripMenuItem = new ToolStripMenuItem();
            controlDataListTable1 = new ControlsLibraryNet60.Data.ControlDataListTable();
            pdfDocumentGenerator1 = new CustomComponents.PDFDocumentGenerator();
            saveFileDialog1 = new SaveFileDialog();
            componentDocumentWithTableHeaderColumnExcel1 = new ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableHeaderColumnExcel(components);
            wordDiagramComponent1 = new WordDiagranLibrary.WordDiagramComponent(components);
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, изменитьToolStripMenuItem, удалитьToolStripMenuItem, wordToolStripMenuItem, pdfToolStripMenuItem, excelToolStripMenuItem, справочникToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(143, 158);
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(142, 22);
            создатьToolStripMenuItem.Text = "Создать";
            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click;
            // 
            // изменитьToolStripMenuItem
            // 
            изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            изменитьToolStripMenuItem.Size = new Size(142, 22);
            изменитьToolStripMenuItem.Text = "Изменить";
            изменитьToolStripMenuItem.Click += изменитьToolStripMenuItem_Click;
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(142, 22);
            удалитьToolStripMenuItem.Text = "Удалить";
            удалитьToolStripMenuItem.Click += удалитьToolStripMenuItem_Click;
            // 
            // wordToolStripMenuItem
            // 
            wordToolStripMenuItem.Name = "wordToolStripMenuItem";
            wordToolStripMenuItem.Size = new Size(142, 22);
            wordToolStripMenuItem.Text = "Word";
            wordToolStripMenuItem.Click += wordToolStripMenuItem_Click;
            // 
            // pdfToolStripMenuItem
            // 
            pdfToolStripMenuItem.Name = "pdfToolStripMenuItem";
            pdfToolStripMenuItem.Size = new Size(142, 22);
            pdfToolStripMenuItem.Text = "Pdf";
            pdfToolStripMenuItem.Click += pdfToolStripMenuItem_Click;
            // 
            // excelToolStripMenuItem
            // 
            excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            excelToolStripMenuItem.Size = new Size(142, 22);
            excelToolStripMenuItem.Text = "Excel";
            excelToolStripMenuItem.Click += excelToolStripMenuItem_Click;
            // 
            // справочникToolStripMenuItem
            // 
            справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            справочникToolStripMenuItem.Size = new Size(142, 22);
            справочникToolStripMenuItem.Text = "Справочник";
            справочникToolStripMenuItem.Click += справочникToolStripMenuItem_Click;
            // 
            // controlDataListTable1
            // 
            controlDataListTable1.Dock = DockStyle.Fill;
            controlDataListTable1.Location = new Point(0, 0);
            controlDataListTable1.Margin = new Padding(4, 3, 4, 3);
            controlDataListTable1.Name = "controlDataListTable1";
            controlDataListTable1.SelectedRowIndex = -1;
            controlDataListTable1.Size = new Size(1004, 533);
            controlDataListTable1.TabIndex = 1;
            controlDataListTable1.KeyDown += myListBox1_KeyDown;
            controlDataListTable1.MouseUp += myListBox1_MouseUp;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 533);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(controlDataListTable1);
            Name = "FormMain";
            Text = "Пользователи";
            Load += FormMain_Load;
            KeyDown += FormMain_KeyDown;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem wordToolStripMenuItem;
        private ToolStripMenuItem pdfToolStripMenuItem;
        private ToolStripMenuItem excelToolStripMenuItem;
        private ToolStripMenuItem справочникToolStripMenuItem;
        private ControlsLibraryNet60.Data.ControlDataListTable controlDataListTable1;
        private CustomComponents.PDFDocumentGenerator pdfDocumentGenerator1;
        private SaveFileDialog saveFileDialog1;
        private ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableHeaderColumnExcel componentDocumentWithTableHeaderColumnExcel1;
        private WordDiagranLibrary.WordDiagramComponent wordDiagramComponent1;
    }
}