using System;
using System.Drawing;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

Panel pn = new Panel();
pn.BackColor = Color.Pink;
form.Controls.Add(pn);
form.BackColor = Color.Red;
form.TransparencyKey = Color.Red;

var rand = new Random();

int directionX = 10;
int directionY = 10;

var tm = new Timer();
tm.Interval = 1;
tm.Tick += delegate
{
    var x = pn.Location.X;
    var y = pn.Location.Y;

    x += directionX;
    y += directionY;

    if(y > form.Height - pn.Height || y < 0)
    {            
        directionY *= -1;
        pn.BackColor = Color.FromArgb((byte)rand.Next(0,255), (byte)rand.Next(0,255), (byte)rand.Next(0,255));
    }

    if(x > form.Width - pn.Width || x < 0)
    {
        directionX *= -1;
        pn.BackColor = Color.FromArgb((byte)rand.Next(0,255), (byte)rand.Next(0,255), (byte)rand.Next(0,255));
    }



    pn.Location = new Point(x, y);
};

form.Load += delegate
{
    tm.Start();
};

form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Application.Run(form);
