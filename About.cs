using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MyCode.Properties;

namespace MyCode
{
    public partial class About : Form
    {
        private Point oldLoc;
        public About(Form parent)
        {
            InitializeComponent();
            this.Size=new Size((int)(parent.Size.Width/1.5), (int)(parent.Size.Height/1.5));
            pictureBoxLogo.Location = new Point(this.Size.Width / 2 - pictureBoxLogo.Size.Width / 2, 20); //центрируем логотип по ширине - получаем координату половины окна и вычитаем половину размера логотипа, т.к. отсчет координат идет с левого верхнего края
            pictureBoxLogo.Image = parent.Icon.ToBitmap();
            buttonClose.Location = new Point(this.Size.Width / 2 - buttonClose.Size.Width / 2, this.Size.Height - 20 - buttonClose.Size.Height);
            labelAbout.Size = new Size(this.Size.Width - 40, this.Size.Height - buttonClose.Size.Height - pictureBoxLogo.Size.Height - 60);
            labelAbout.Location = new Point(20, pictureBoxLogo.Location.Y + pictureBoxLogo.Size.Height + 20);
            labelAbout.Text = "Данная программа была разработана в качестве дипломной работы программиста и является демонстрацией знаний разработчика. Дипломная работа была защищена с оценкой 5 (grade A).\n\nРазработчик: Аркадий Веркин (Arkadiy Verkin) aka Caskol\nGitHub: https://github.com/Caskol/MyCode\nBryansk 2023";
            oldLoc = pictureBoxLogo.Location;
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            while (pictureBoxLogo.Location.X <= this.Width)
            {
                pictureBoxLogo.Location = new Point(pictureBoxLogo.Location.X + pictureBoxLogo.Location.X/20, pictureBoxLogo.Location.Y);
                await Task.Delay(1);
            }
            pictureBoxLogo.Location = new Point(0-pictureBoxLogo.Width,pictureBoxLogo.Location.Y);
            while (pictureBoxLogo.Location.X < oldLoc.X)
            {
                pictureBoxLogo.Location = new Point(pictureBoxLogo.Location.X + (oldLoc.X-pictureBoxLogo.Location.X)/20+1, pictureBoxLogo.Location.Y);
                await Task.Delay(1);
            }
        }
    }
}
