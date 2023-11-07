using AccountingContracts;
using Microsoft.Extensions.Logging;
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
    public partial class FormAddAUpdate : Form
    {
        private readonly IUserLogic _logic;
        private readonly ICityLogic _citylogic;
        private bool _isUpdate = false;
        private int? _id;
        public int Id { set { _id = value; } }
        public FormAddAUpdate(IUserLogic logic, ICityLogic citylogic)
        {
            InitializeComponent();
            _logic = logic;
            _citylogic = citylogic;
            List<string> cityNames = _citylogic.ReadList(null).Select(c => c.CityName).ToList();
            listBoxControl1.FillListBox(cityNames);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(listBoxControl1.Value) || string.IsNullOrEmpty(controlInputRangeDate1.Value.ToString()))
            {
                MessageBox.Show("Не все данные заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                var model = new UserBindingModel
                {
                    Id = _id ?? 0,
                    Login = textBox1.Text,
                    UserLoginAttempts = textBox2.Text,
                    CityId = _citylogic.ReadElement(new CitySearchModel() { CityName = listBoxControl1.Value }).Id,
                    CreationDate = (DateTime)controlInputRangeDate1.Value
                };

                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);

                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                _isUpdate = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAddAUpdate_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _logic.ReadElement(new UserSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBox1.Text = view.Login;
                        textBox2.Text = view.UserLoginAttempts;
                        listBoxControl1.Value = view.CityName;
                        controlInputRangeDate1.Value = view.CreationDate;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormAddAUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isUpdate)
            {
                DialogResult result = MessageBox.Show("Есть несохраненные данные. Вы действительно хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Отменить закрытие формы
                }
            }
        }
    }
}
