using AccountingContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMain
{
    public partial class FormDirectory : Form
    {
        private readonly ICityLogic _cityLogic;
        public FormDirectory(ICityLogic cityLogic)
        {
            InitializeComponent();
            _cityLogic = cityLogic;
        }

        private void FormDirectory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            try
            {
                var list = _cityLogic.ReadList(null);

                foreach (var item in list)
                {

                    dataGridView1.Rows.Add(item.CityName);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CityBindingModel GetModel(string rowData)
        {
            try
            {
                CityViewModel model = _cityLogic.ReadElement(new CitySearchModel() { CityName = rowData });
                if (model == null)
                {
                    return new CityBindingModel() { Id = 0, CityName = rowData };
                }
                return new CityBindingModel()
                {
                    Id = model.Id,
                    CityName = rowData,
                };

            }
            catch
            {
                MessageBox.Show("Ошибка при создании");
                return null;
            }
        }

        private void SaveData(string rowData)
        {
            var model = GetModel(rowData);
            if (model != null)
            {
                var haveElement = _cityLogic.ReadElement(new CitySearchModel() { Id = model.Id });
                var operationResult = haveElement != null ? _cityLogic.Update(model) : _cityLogic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void FormDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.EndEdit();
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string text = selectedRow.Cells["Данные"].Value.ToString();
                SaveData(text);
            }
            if (e.KeyCode == Keys.Insert)
            {
                dataGridView1.Rows.Add();
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    string text = selectedRow.Cells["Данные"].Value.ToString();

                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить строку: " + text + "?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var model = GetModel(text);
                        var operationResult = _cityLogic.Delete(model);

                        if (!operationResult)
                        {
                            throw new Exception("Ошибка при удалении");
                        }

                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);

                        MessageBox.Show("Удаление прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = dataGridView1.CurrentCell;

            if (currentCell != null)
            {
                string text = currentCell.Value.ToString();
                SaveData(text);
            }
        }

        private void FormDirectory_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
