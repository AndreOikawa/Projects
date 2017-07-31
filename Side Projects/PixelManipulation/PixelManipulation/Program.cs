using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

public class MainForm : System.Windows.Forms.Form
{
    private System.ComponentModel.Container components;

    public MainForm()
    {
        InitializeComponent();
        CenterToScreen();
        SetStyle(ControlStyles.ResizeRedraw, true);
    }

    //  Clean up any resources being used.

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }
    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(255, 255);
        this.Text = "Fun with graphics";
        this.Resize += new System.EventHandler(this.Form1_Resize);
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
    }
    #endregion

    [STAThread]
    static void Main()
    {
        Application.Run(new MainForm());
    }

    struct RGB
    {
        public int r, g, b;
    }
    struct Pos
    {
        public int x, y;
    }
    private void Draw(int x, int y, ref RGB previous)
    {
        Random rgb = new Random();
        //create a graphics object from the form
        Graphics g = this.CreateGraphics();
        g.SmoothingMode =
        System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        // create  a  pen object with which to draw

        int rChange = 1;
        int gChange = 1;
        int bChange = 0;
        //int pickOne = rgb.Next(0, 3);
        //if (pickOne == 0)
            previous.r = rgb.Next(previous.r - rChange, previous.r + rChange +1);
        //else if (pickOne == 1)
            previous.g = rgb.Next(previous.g - gChange, previous.g + gChange +1);
        //else
            previous.b = rgb.Next(previous.b - bChange, previous.b + bChange +1);
        if (previous.r < 0)
            previous.r = rgb.Next(0, rChange + 1);
        else if (previous.r > 255)
            previous.r = rgb.Next(255 - rChange, 256);
        if (previous.b < 0)
            previous.b = rgb.Next(0, bChange + 1);
        else if (previous.b > 255)
            previous.b = rgb.Next(255 - bChange, 256);
        if (previous.g < 0)
            previous.g = rgb.Next(0, gChange + 1);
        else if (previous.g > 255)
            previous.g = rgb.Next(255 - gChange, 256);

        Pen p = new Pen(Color.FromArgb(previous.r, previous.g, previous.b), 1);  // draw the line 
        p.DashCap= System.Drawing.Drawing2D.DashCap.Round;
        p.Width = 6F;
        // call a member of the graphics class
        g.DrawLine(p, x, y, x + 1, y + 1);
    }

    private void DrawDistinct(int x, int y, RGB previous)
    {
        Graphics g = this.CreateGraphics();
        Pen p = new Pen(Color.FromArgb(previous.r, previous.g, previous.b), 1);  // draw the line 

        // call a member of the graphics class
        g.DrawLine(p, x, y, x + 1, y + 1);
    }
    private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        Random rgb = new Random();
        RGB previous = new RGB { r = rgb.Next(0, 256), g = rgb.Next(0, 256), b = rgb.Next(0, 256) };
        List<RGB> colours = new List<RGB>();
        for (int r = 0; r <= 255; r++)
        {
            for (int g = 0; g <= 255; g++)
            {
                for (int b = 0; b <= 255; b++)
                {
                    RGB colour = new RGB { r = r, g = g, b = b };
                    colours.Add(colour);
                }
            }
        }
        List<Pos> screen = new List<Pos>();
        for (int px = 0; px <= 255; px++)
        {
            for (int posy = 0; posy <= 255; posy++)
            {
                screen.Add(new Pos { x = px, y = posy });
            }
        }
        int pixels = 255 * 255;
        int x = 127;
        int y = 127;
        for (int i = 0; i < 200000; i++)
        {
            if (x < 0) x = 255;
            if (y < 0) y = 255;
            if (x > 255) x = 0;
            if (y > 255) y = 0;
            Draw((rgb.Next(0, 2) == 0) ? --x : ++x, (rgb.Next(0, 2) == 0) ? --y : ++y, ref previous);
        }
        //DrawDistinct(x, y, colours[index]);
        //colours.RemoveAt(index);
        //int counter = 1;
        //while (screen.Count > 0)
        //{
        //    //int indexRGB = rgb.Next(0, colours.Count);
        //    //int index = rgb.Next(0, screen.Count);
        //    //Pos random = screen[index];
        //    //DrawDistinct(random.x, random.y, colours[indexRGB]);
        //    //colours.RemoveAt(indexRGB);
        //    screen.RemoveAt(0);
        //    //right / left
        //    for (int i = 0; i < counter; i++)
        //    {
        //        //DrawDistinct((counter % 2 == 0) ? ++x : --x, y, colours[index]);
        //        //colours.RemoveAt(index);
        //        Draw((counter % 2 == 0) ? ++x : --x, y, ref previous);
        //        pixels--;
        //    }
        //    //up/down
        //    for (int i = 0; i < counter; i++)
        //    {
        //        //DrawDistinct(x, (counter % 2 == 0) ? ++y : --y, colours[index]);
        //        //colours.RemoveAt(index);

        //        Draw(x, (counter % 2 == 0) ? ++y : --y, ref previous);
        //        pixels--;
        //    }
        //    counter++;
        //}
        Console.WriteLine("done");


    }
    private void Form1_Resize(object sender, System.EventArgs e)
    {
        // Invalidate();  See ctor!
    }
}