ApplicationConfiguration.Initialize();

var form = new Form();

var flowLayoutPanel = new FlowLayoutPanel();
    flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
    flowLayoutPanel.WrapContents = false;
    flowLayoutPanel.AutoScroll = true;
    flowLayoutPanel.AutoSize = true;

Point? p = null;

var Btn1 = new Button();
var stoqView = new Button();

Btn1.Text = "to aq";
Btn1.Width = 150;

// var APanel = new FlowLayoutPanel();
//     APanel.BackColor = Color.Blue;
//     APanel.AutoSize = true;

var BPanel = new FlowLayoutPanel();
    BPanel.BackColor = Color.Green;
    BPanel.AutoSize = true;

BPanel.Location = new Point(50,100);

Btn1.MouseMove += (s, e) =>
{
    if (p is null)
        return;

    var dx = e.Location.X - p.Value.X;
    var dy = e.Location.Y - p.Value.Y;
    Btn1.Location = new Point(
        Btn1.Location.X + dx, 
        Btn1.Location.Y + dy
    );
};

form.KeyPreview = true;
form.KeyDown += (s, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Btn1.MouseDown += (s, e) =>
{

    p = e.Location;

    var parent = Btn1.Parent;
    if(parent == BPanel)
    {
        BPanel.Controls.Remove(Btn1);
        form.Controls.Add(Btn1);
        Btn1.BringToFront();

    }
};

Btn1.MouseUp += (s, e) =>
{
    p = null;
    if(Btn1.Top > BPanel.Top && Btn1.Bottom < BPanel.Bottom )   
    {
        BPanel.Controls.Add(Btn1);
        MessageBox.Show("TA NO BPANEL");
        return;
    }

};

form.Controls.Add(BPanel);
form.Controls.Add(Btn1);
Btn1.BringToFront();
Application.Run(form);