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
        public Settings(byte plagiarism)
        {
            InitializeComponent();
            trackBarPlagiat.Value = plagiarism;
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
        }
        public byte GetData()
        {
            return plagiat;
        }
    }
}
