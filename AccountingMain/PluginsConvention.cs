using AccountingBussinessLogic;
using AccountingContracts;
using AccountingDataBaseImplemet.Implements;
using AccountingMain;
using ComponentsLibraryNet60.DocumentWithChart;
using ComponentsLibraryNet60.DocumentWithTable;
using ComponentsLibraryNet60.Models;
using ControlsLibraryNet60.Data;
using ControlsLibraryNet60.Models;
using CustomComponents;
using iTextSharp.text;
using PluginsConventionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordDiagranLibrary;

namespace AccountingMain
{
    public class PluginsConvention : IPluginsConvention
    {
        private readonly IUserLogic _userLogic;
        private readonly ICityLogic _cityLogic;
        private readonly ControlDataListTable _controlDataListTable;
        private readonly ComponentDocumentWithTableHeaderColumnExcel _excelDoc;
        private readonly WordDiagramComponent _wordDoc;
        private readonly PDFDocumentGenerator _pdfDoc;
        public string PluginName { get; set; } = "AccountingMain";
        public PluginsConvention()
        {
            _userLogic = new UserLogic(new UserStorage());
            _cityLogic = new CityLogic(new CityStorage());
            _excelDoc = new();
            _wordDoc = new();
            _pdfDoc = new();
            _controlDataListTable = new();
        }

        public UserControl GetControl
        {
            get { return _controlDataListTable; }
        }

        public PluginsConventionElement GetElement
        {
            get
            {
                UserSearchModel model = _controlDataListTable.GetSelectedObject<UserSearchModel>();
                int id = -1;
                if (model != null) id = model.Id;          
                byte[] bytes = new byte[16];
                BitConverter.GetBytes(id).CopyTo(bytes, 0);
                return new()
                {
                    Id = new Guid(bytes)
                };
            }
        }
        
        public Form GetForm(PluginsConventionElement element)
        {

            FormAddAUpdate form = new FormAddAUpdate(_userLogic, _cityLogic);

            if (element == null)
            {
                return form;
            }
            else
            {
                form.Id = element.Id.GetHashCode();
                return form;
            }
        }

        public Form GetThesaurus()
        {
           
            return new FormDirectory(_cityLogic);
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            _userLogic.Delete(new UserBindingModel() { Id = element.Id.GetHashCode() });
            return true;
        }

        public void ReloadData()
        {
            try
            {
                _controlDataListTable.Clear();

                var listconfig = new DataListRowConfig
                {
                    PatternString = "Город: {CityName} Ид: {Id} Логин: {Login} Дата: {CreationDate}.",
                    StartSymbol = '{',
                    FinishSymbol = '}'
                };

                _controlDataListTable.LoadConfig(listconfig);
                var list = _userLogic.ReadList(null);

                 if (list != null)
                 {
                        _controlDataListTable.AddTable(list);
                 }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                var list = _userLogic.ReadList(null);
                List<List<string>> loginAttemptsList = list
         .OrderByDescending(user => user.Id)
         .Select(user =>
             user.UserLoginAttempts != null ? user.UserLoginAttempts.Split(',').ToList() : new List<string>()
         )
         .ToList();

                _pdfDoc.GenerateDocument(
                    saveDocument.FileName, "Пользователи",
                    loginAttemptsList);
                MessageBox.Show("Сохранено успешно", "Результат",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                var list = _userLogic.ReadList(null);
                _excelDoc.CreateDoc(new ComponentDocumentWithTableHeaderDataConfig<UserViewModel>
                {
                    FilePath = saveDocument.FileName,
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
                MessageBox.Show("Сохранено успешно", "Результат",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
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



                _wordDoc.CreateDoc(new WordDiagranLibrary.DataForDiagram(
                    saveDocument.FileName, "Пользователи", "Diagram",
                    WordDiagranLibrary.LegendPosition.Bottom,
                    dictionary, citiesWithUsers));
                MessageBox.Show("Сохранено успешно", "Результат",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}