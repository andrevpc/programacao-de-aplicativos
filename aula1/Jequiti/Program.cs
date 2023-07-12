using System;
using System.Drawing;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
pb.Image = Image.FromFile("jequiti.jpg");
pb.SizeMode = PictureBoxSizeMode.Zoom;
form.Controls.Add(pb);

var show = false;

Timer tm = new Timer();
tm.Interval = 200;
tm.Tick += delegate
{
    if (show)
    {
        form.Hide();
        show = false;
    }

    var rand = Random.Shared;
    if (rand.Next(100) < 2)
    {
        form.Show();
        show = true;
    }
};

form.Load += delegate
{
    form.Hide();
    tm.Start();
};

form.KeyPreview = true;
form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Application.Run(form);
