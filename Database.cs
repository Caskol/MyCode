using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCode
{
    public partial class Database : Form
    {
        DBWorker worker; //создаем экземпляр базы данных
        private DataTable data = new DataTable();
        public Database()
        {
            InitializeComponent();
            worker = new DBWorker();
            data.Columns.Add("ID");
            data.Columns.Add("Канонизированная строка с кодом");
            data.Columns.Add("Количество символов кода");
            data.Columns.Add("Язык программирования");
            data.Columns.Add("Дата добавления");
        }

        private void Database_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
        private void UpdateList()
        {
            var list = worker.GetAll();//получаем весь список исходных кодов
            data.Clear();
            DataRow newRow;
            BindingSource bind = new BindingSource();
            foreach (var code in list)
            {
                newRow = data.NewRow(); //создаем новую строку в таблице
                newRow[0] = code.Id;
                newRow[1] = code.CanonizedCode;
                newRow[2] = code.SymbolsCount;
                newRow[3] = code.Language;
                newRow[4] = code.DateTime;
                data.Rows.Add(newRow);
            }
            bind.DataSource = data; //привязываем готовую таблицу токенов к bindingSource
            DataBaseGrid.DataSource = bind; //привязываем таблицу из окна к bindingSource
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DataBaseGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Нужно обязательно выбрать строки", "Важное предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow Row in DataBaseGrid.SelectedRows)
            {
                worker.DeleteFromDB(Row.Cells[0].Value.ToString());
            }
            DialogResult dr = MessageBox.Show($"Удалено {DataBaseGrid.SelectedRows.Count} шт.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateList();

        }
    }
}
