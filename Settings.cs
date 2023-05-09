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
    public partial class Settings : Form
    {
        byte plagiat;
        uint maximumSymbols;
        public Settings(byte plagiarism, uint symbols)
        {
            InitializeComponent();
            plagiat=plagiarism;
            maximumSymbols=symbols;
            trackBarPlagiat.Value = plagiat;
            numericUpDownSymbols.Value = maximumSymbols;
        }
        public Settings()
        {
            MessageBox.Show("Это окно не должно было открыться так...");
            this?.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void trackBarPlagiat_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownPlagiat.Value = trackBarPlagiat.Value;
        }

        private void numericUpDownPlagiat_ValueChanged(object sender, EventArgs e)
        {
            trackBarPlagiat.Value = Convert.ToInt32(numericUpDownPlagiat.Value);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            plagiat = Convert.ToByte(trackBarPlagiat.Value);
            if (numericUpDownSymbols.Value > 25000)
            {
                DialogResult dr = MessageBox.Show("Не рекомендуется изменять максимально допустимое количество символов на число, которое больше 25000.\n" +
                    "Это может повлечь за собой повышенный расход оперативной памяти, нестабильную работу и более долгое сравнение.\n" +
                    "Изменять это значение стоит только тогда, когда Вы имеете более мощный компьютер с большим количеством оперативной памяти (например, сервер).\n\n\n" +
                    "Вы действительно хотите изменить это значение?", "Важное предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                    maximumSymbols = Convert.ToUInt32(numericUpDownSymbols.Value);
                else
                    MessageBox.Show("Процент плагиата сохранен. Максимальное количество символов осталось неизменным.");
            }
            else
                maximumSymbols = Convert.ToUInt32(numericUpDownSymbols.Value);
        }
        public List<string> GetData()
        {
            List<string> data = new List<string>();
            data.Add(plagiat.ToString());
            data.Add(maximumSymbols.ToString());
            return data;
        }
    }
}
