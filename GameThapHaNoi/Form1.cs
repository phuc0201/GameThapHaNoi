using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace GameThapHaNoi
{
    public partial class Form1 : Form
    {
        public Graphics grp;
        Managerment mng;
        public int level;
        public int Mode = 0;
        public Form1()
        {
            InitializeComponent();
            level=trackBar1.Value= 2;
            grp = pnl_Game.CreateGraphics();
            mng = new Managerment(pnl_Game, grp);
        }
        private void pnl_Paint(object sender, PaintEventArgs e)
        {
        }
        private void comToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mode = 2;
            pnl_Game.Controls.Clear();
            mng.CreateDisk();
            mng.Draw_Com(grp, level);                          
            mng.Answer(1, 3, level, level,grp);      
        }
        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mode = 1;
            grp.Clear(pnl_Game.BackColor);
            pnl_Game.BackgroundImage = new Bitmap(Properties.Resources.Background1);
            mng.CreateDisk();
            pnl_Game.Controls.Clear();
            mng.DrawPlayer(grp, level);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0 || trackBar1.Value == 1)
                trackBar1.Value = 2;
            if (trackBar1.Value == 10)
                trackBar1.Value = 9;
            lb_level.Text = trackBar1.Value.ToString();
            level = trackBar1.Value;
            if(Mode==2)
            {
                mng.CreateDisk();
                grp.Clear(pnl_Game.BackColor);
                mng.Draw_Com(grp, level);
            }
            else
            {
                mng.CreateDisk();
                pnl_Game.Controls.Clear();
                mng.DrawPlayer(grp, level);
            }
        }

        public void timerTick(object sender, EventArgs e)
        {
        }
    }
}
