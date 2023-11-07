using AccountingContracts;
using ComponentsLibraryNet60.DocumentWithTable;
using ComponentsLibraryNet60.Models;
using ControlsLibraryNet60.Data;
using ControlsLibraryNet60.Models;
using CustomComponents;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace AccountingMain
{
    public partial class FormMain : Form
    {
        private readonly IUserLogic _userLogic;

        public FormMain(IUserLogic userLogic)
        {
            _userLogic = userLogic;
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            controlDataListTable1.Clear();

            var listconfig = new DataListRowConfig
            {
                PatternString = "Город: {CityName} Ид: {Id} Логин: {Login} Дата: {CreationDate}.",
                StartSymbol = '{',
                FinishSymbol = '}'
            };

            controlDataListTable1.LoadConfig(listconfig);

            try
            {
                var list = _userLogic.ReadList(null);

                if (list != null)
                {
                    controlDataListTable1.AddTable(list);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void myListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                создатьToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.U && e.Control)
            {
                изменитьToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.D && e.Control)
            {
                удалитьToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.S && e.Control)
            {
                wordToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.T && e.Control)
            {
                pdfToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.C && e.Control)
            {
                excelToolStripMenuItem_Click(sender, null);
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormAddAUpdate));

            if (service is FormAddAUpdate form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSearchModel user = controlDataListTable1.GetSelectedObject<UserSearchModel>();
            if (user != null)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormAddAUpdate));

                if (service is FormAddAUpdate form)
                {
                    form.Id = user.Id;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSearchModel user = controlDataListTable1.GetSelectedObject<UserSearchModel>();
            if (user != null)
            {

                // Если пользователь подтверждает удаление
                var model = _userLogic.ReadElement(user);
                if (model != null)
                {
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var operationResult = _userLogic.Delete(new UserBindingModel()
                        {
                            Id = model.Id,
                            Login = model.Login,
                            CityId = model.CityId,
                            CreationDate = model.CreationDate,
                            UserLoginAttempts = model.UserLoginAttempts,
                        });

                        if (!operationResult)
                        {
                            throw new Exception("Ошибка при удалении");
                        }

                        LoadData();

                        MessageBox.Show("Удаление прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Word Documents (*.docx)|*.docx|All Files (*.*)|*.*";
            string filePath = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
            }
            try
            {

                var list = _userLogic.ReadList(null);

                var dictionary = list
     .GroupBy(user => user.CreationDate.Year) // Группируем по году создания аккаунта
     .ToDictionary(
         yearGroup => yearGroup.Key.ToString(), // Год является ключом, преобразуем его в строку
         yearGroup => yearGroup
             .GroupBy(user => user.CityName) // Внутренняя группировка по городу
             .Select(cityGroup => cityGroup.Count()) // Преобразование в количество аккаунтов
             .ToList() // Преобразование группы городов в список количеств
     );

                var citiesWithUsers = list
                    .Select(user => user.CityName)
                    .Distinct() // Удаление дубликатов
                    .ToList();



                wordDiagramComponent1.CreateDoc(new WordDiagranLibrary.DataForDiagram(
                    filePath, "Пользователи", "Diagram",
                    WordDiagranLibrary.LegendPosition.Bottom,
                    dictionary, citiesWithUsers));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            string filePath = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
            }
            try
            {
                var list = _userLogic.ReadList(null);
                List<List<string>> loginAttemptsList = list
         .OrderByDescending(user => user.Id) // Используйте здесь свойство для сортировки в обратном порядке
         .Select(user =>
             user.UserLoginAttempts != null ? user.UserLoginAttempts.Split(',').ToList() : new List<string>()
         )
         .ToList();

                pdfDocumentGenerator1.GenerateDocument(
                    filePath, "Пользователи",
                    loginAttemptsList);
                MessageBox.Show("Сохарнено успешно", "Результат",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel Workbooks (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            string filePath = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
            }
            try
            {
                var list = _userLogic.ReadList(null);
                componentDocumentWithTableHeaderColumnExcel1.CreateDoc(new ComponentDocumentWithTableHeaderDataConfig<UserViewModel>
                {
                    FilePath = filePath,
                    Header = "Пользователи",
                    UseUnion = true,
                    ColumnsRowsWidth = new List<(int, int)> { (0, 5), (0, 5), (0, 10), (0, 10) },
                    ColumnUnion = new List<(int StartIndex, int Count)> { (2, 2) },
                    Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                    {
                    (0, 0, "Id", "Id"),
                    (1, 0, "Login", "Login"),
                     (2, 0, "Inf", ""),
                    (2, 1, "CreationDate", "CreationDate"),
                    (3, 1, "CityName", "CityName")
                    },
                    Data = list
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void myListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                создатьToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.U && e.Control)
            {
                изменитьToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.D && e.Control)
            {
                удалитьToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.S && e.Control)
            {
                wordToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.T && e.Control)
            {
                pdfToolStripMenuItem_Click(sender, null);
            }
            if (e.KeyCode == Keys.C && e.Control)
            {
                excelToolStripMenuItem_Click(sender, null);
            }
        }

        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormDirectory));

            if (service is FormDirectory form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}