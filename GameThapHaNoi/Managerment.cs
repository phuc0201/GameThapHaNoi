using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GameThapHaNoi
{
    class Managerment
    {
        Stack<Disk> stack1 = new Stack<Disk>();
        Stack<Disk> stack2 = new Stack<Disk>();
        Stack<Disk> stack3 = new Stack<Disk>();
        Stack<Image> stackDisk;
        Panel pnl { get; set; }
        Image BackGround = new Bitmap(Properties.Resources.Background1);
        Image disk1 = new Bitmap(Properties.Resources.disk1);
        Image disk2 = new Bitmap(Properties.Resources.disk2);
        Image disk3 = new Bitmap(Properties.Resources.disk3);
        Image disk4 = new Bitmap(Properties.Resources.disk4);
        Image disk5 = new Bitmap(Properties.Resources.disk5);
        Image disk6 = new Bitmap(Properties.Resources.disk6);
        Image disk7 = new Bitmap(Properties.Resources.disk7);
        Image disk8 = new Bitmap(Properties.Resources.disk8);
        Image disk9 = new Bitmap(Properties.Resources.disk9);
        public Managerment(Panel Pnl, Graphics g)
        {
            pnl = Pnl;
            stackDisk = new Stack<Image>();
        }

        public Managerment()
        {

        }
        public void CreateDisk()
        {
            stack1.Clear();
            stack2.Clear();
            stack3.Clear();
            stackDisk.Clear();
            stackDisk.Push(disk9);
            stackDisk.Push(disk8);
            stackDisk.Push(disk7);
            stackDisk.Push(disk6);
            stackDisk.Push(disk5);
            stackDisk.Push(disk4);
            stackDisk.Push(disk3);
            stackDisk.Push(disk2);
            stackDisk.Push(disk1);
        }
        public void DrawPlayer(Graphics g, int level)
        {
            PictureBox ptb;
            for (int i = 0; i < level; i++)
            {
                ptb = new PictureBox()
                {
                    Width = 400 - i * 40,
                    Height = 40,
                    Location = new Point(i * 20, 668 - i * 40),
                    BackgroundImage = stackDisk.Pop(),
                };
                ptb.MouseDown += Ptb_MouseDown;
                ptb.MouseMove += Ptb_MouseMove;
                ptb.MouseUp += Ptb_MouseUp;
                pnl.Controls.Add(ptb);
                disk = new Disk(ptb.Width,ptb);
                stack1.Push(disk);
            }
        }
        Point point;
        Point pointPictureBox;
        private void Ptb_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if(pointPictureBox.X<400)
            {
                if (p.Left >= 800 && (stack3.Count == 0 || p.Width < stack3.Peek().Width))
                {
                    p.Left = 1000 - p.Width / 2;
                    p.Top = 668 - stack3.Count *40;
                    Disk disk = new Disk(p.Width, p);
                    stack3.Push(disk);
                    stack1.Pop();
                }
                else if (p.Left >= 400 && (stack2.Count == 0 || p.Width < stack2.Peek().Width))
                {
                    p.Left = 600 - p.Width / 2;
                    p.Top = 668 - stack2.Count * 40;
                    Disk disk = new Disk(p.Width, p);
                    stack2.Push(disk);
                    stack1.Pop();                  
                }
                else
                {
                    p.Left = pointPictureBox.X;
                    p.Top = pointPictureBox.Y;
                }
            }
            else if (pointPictureBox.X < 800)
            {
                if (p.Left >= 800 && (stack3.Count == 0 || p.Width < stack3.Peek().Width))
                {
                    p.Left = 1000 - p.Width / 2;
                    p.Top = 668 - stack3.Count * 40;
                    Disk disk = new Disk(p.Width, p);
                    stack3.Push(disk);
                    stack2.Pop();
                }
                else if (p.Left <= 400 && (stack1.Count == 0 || p.Width < stack1.Peek().Width))
                {
                    p.Left = 200 - p.Width / 2;
                    p.Top = 668 - stack1.Count * 40;
                    Disk disk = new Disk(p.Width, p);
                    stack1.Push(disk);
                    stack2.Pop();
                }
                else
                {
                    p.Left = pointPictureBox.X;
                    p.Top = pointPictureBox.Y;
                }
            }
            else if (pointPictureBox.X >=800)
            {
                if (p.Left <= 400 && (stack1.Count == 0 || p.Width < stack1.Peek().Width))
                {
                    p.Left = 200 - p.Width / 2;
                    p.Top = 668 - stack1.Count * 40;
                    Disk disk = new Disk(p.Width, p);
                    stack1.Push(disk);
                    stack3.Pop();
                }
                else if (p.Left <= 800 && (stack2.Count == 0 || p.Width < stack2.Peek().Width))
                {
                    p.Left = 600 - p.Width / 2;
                    p.Top = 668 - stack2.Count * 40;
                    Disk disk = new Disk(p.Width, p);
                    stack2.Push(disk);
                    stack3.Pop();
                }

                else
                {
                    p.Left = pointPictureBox.X;
                    p.Top = pointPictureBox.Y;
                }
            }
        }

        private void Ptb_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                if (pointPictureBox.X <= 400 && stack1.Count!=0 && p == stack1.Peek().PictureboxDisk)
                {
                     p.Left += e.X - point.X;
                     p.Top += e.Y - point.Y;
                }
                else if (pointPictureBox.X <= 800 && stack2.Count != 0 && p == stack2.Peek().PictureboxDisk)
                {
                     p.Left += e.X - point.X;
                     p.Top += e.Y - point.Y;
                }
                else if (pointPictureBox.X <= 1200 && stack3.Count != 0 && p == stack3.Peek().PictureboxDisk)
                {
                     p.Left += e.X - point.X;
                     p.Top += e.Y - point.Y;
                }
                else
                {
                    p.Left = p.Left;
                    p.Top = p.Top;
                }

            }
        }

        private void Ptb_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;
            pointPictureBox = p.Location;
            point = e.Location;
        }

        Disk disk;
        public void Draw_Com(Graphics g, int level)
        {           
            g.DrawImage(BackGround, 0, 0);
            for (int i=0; i<level; i++)
            {
                Image Img = stackDisk.Pop();
                int x = i*20;
                int y = 668 - i * 40;
                g.DrawImage(Img,x,y);
                disk = new Disk(x,y,Img);
                stack1.Push(disk);
            }
        }
        public void DrawDisk(Graphics g, int x, int y, Image img)
        {
            g.DrawImage(img, x, y);
        }
        public void Retrace(Graphics g)
        {
            g.Clear(pnl.BackColor);
            g.DrawImage(BackGround, 0, 0);
            if (stack1.Count!=0)      
            {
                 foreach (var disk in stack1)
                 DrawDisk(g, disk.LocationX, disk.LocationY, disk.Img);
            }
            if (stack2.Count != 0)
            {
                 foreach (var disk in stack2)
                 DrawDisk(g, disk.LocationX, disk.LocationY, disk.Img);
            }
            if (stack3.Count != 0)
            {
                 foreach (var disk in stack3)
                 DrawDisk(g, disk.LocationX, disk.LocationY, disk.Img);
            }
        }
        public void Answer(int start, int end, int n, int level, Graphics g)
        {
            //Tham khảo thuật toán đệ quy của thầy Vinh, sách CTDL và giải thuật 
            if (n == 1)
            {
                Thread.Sleep(500);
                Move(start, end,g);               
            }
            else
            {
                //chuyển n-1 số sang cột trung gian 
                Answer(start, 6 - start - end, n - 1, level,g);
                //Chuyển 1 đĩa từ cột start sang end
                Answer(start, end, 1, level,g);
                //Chuyển n-1 đĩa từ cột trung sang end
                Answer(6 - start - end, end, n - 1, level,g);
            }
        }
        private void Move(int start, int end, Graphics g)
        {
            if (start==1)
             {
                 Disk movedisk = stack1.Pop();               
                 if (end==2)
                 {
                    movedisk.LocationX += 400;
                    movedisk.LocationY = 668 - stack2.Count * 40; 
                    stack2.Push(movedisk);
                 }
                 else
                 {
                    movedisk.LocationX += 800;
                    movedisk.LocationY = 668 - stack3.Count * 40;
                    stack3.Push(movedisk);
                 }
                Retrace(g);
            }
            else if (start == 2)
             {
                Disk movedisk = stack2.Pop();
                if (end == 1)
                 {
                    movedisk.LocationX -= 400;
                    movedisk.LocationY = 668 - stack1.Count * 40;
                    stack1.Push(movedisk);
                 }
                 else 
                 {
                    movedisk.LocationX += 400;
                    movedisk.LocationY = 668 - stack3.Count * 40;
                    stack3.Push(movedisk);
                 }
                Retrace(g);
            }
             else
             {
                Disk movedisk = stack3.Pop();
                if (end == 1)
                {
                    movedisk.LocationX -= 800;
                    movedisk.LocationY = 668 - stack1.Count * 40;
                    stack1.Push(movedisk);
                }
                else
                {
                    movedisk.LocationX -= 400;
                    movedisk.LocationY = 668 - stack2.Count * 40;
                    stack2.Push(movedisk);
                }
                Retrace(g);
            }
        }
    }
}
