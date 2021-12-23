using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace GameThapHaNoi
{
    class Disk
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public PictureBox PictureboxDisk { get; set; }
        public Image Img { get; set; }

        public Disk(int x, PictureBox ptb)
        {
            Width = x;
            PictureboxDisk = ptb;
        }
        public Disk(int x, int y, Image img)
        {
            LocationX = x;
            LocationY = y;
            Img = img;
        }
        public Disk() { }
    }
}
