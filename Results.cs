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
    public partial class Results : Form
    {
        private DataTable data = new DataTable();
        public Results(List<string> canonizedCode, List<List<float>> results)
        {
            InitializeComponent();
            data.Columns.Add("Канонизированный код");
            data.Columns.Add("Количество символов");
            data.Columns.Add("Левенштейн: токены");
            data.Columns.Add("Жаккар: токены");
            data.Columns.Add("Сёренсен-Дайс: токены");
            data.Columns.Add("Подпоследовательность (LCS): токены");
            data.Columns.Add("Общий процент плагиата: токены");
            data.Columns.Add("Левенштейн: шинглы");
            data.Columns.Add("Жаккар: шинглы");
            data.Columns.Add("Сёренсен-Дайс: шинглы");
            data.Columns.Add("Подпоследовательность (LCS): шинглы");
            data.Columns.Add("Общий процент плагиата: шинглы");

            DataRow dr = data.NewRow();
            BindingSource bindingSource = new BindingSource();
            for (int i = 0; i < results.Count; i++)
            {
                dr = data.NewRow();
                dr[0] = canonizedCode[i];
                dr[1] = canonizedCode[i].Length;
                dr[2] = results[i][0];
                dr[3] = results[i][1];
                dr[4] = results[i][2];
                dr[5] = results[i][3];
                dr[6] = results[i][4];
                dr[7] = results[i][5];
                dr[8] = results[i][6];
                dr[9] = results[i][7];
                dr[10] = results[i][8];
                dr[11] = results[i][9];
                data.Rows.Add(dr);
            }
            bindingSource.DataSource = data;
            resultsGridView.DataSource = bindingSource;
        }
    }
}
