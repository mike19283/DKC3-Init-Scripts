using DKC3_Init_scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKC3_Init_scripts
{
    public partial class SpriteSelect : Form
    {
        public Sprites selection;
        ROM rom;
        public SpriteSelect(ROM rom)
        {
            InitializeComponent();
            this.rom = rom;
            listBox_sprites.Items.AddRange(rom.sprites.ToArray());
            listBox_sprites.SelectedIndex = 0;
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            var temp = (Sprites)listBox_sprites.SelectedItem;
            selection = temp;
            this.DialogResult = DialogResult.OK;
        }

        private void listBox_sprites_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                button_select_Click(0, new EventArgs());
            }
        }

        private void listBox_sprites_DoubleClick(object sender, EventArgs e)
        {
            button_select_Click(0, new EventArgs());
        }
    }
}
