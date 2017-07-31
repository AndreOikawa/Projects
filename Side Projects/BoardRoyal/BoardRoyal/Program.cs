using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BoardRoyal;
using BoardRoyal.Struct;
using System.Threading;

public class MainForm : System.Windows.Forms.Form
{
    private Container components;
    private int TileMod = 16;
    private int FormDimensions = 512;
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
        this.ClientSize = new System.Drawing.Size(FormDimensions, FormDimensions);
        this.Text = "Fun with graphics";
        this.Resize += new System.EventHandler(this.Form1_Resize);
        this.Paint += new PaintEventHandler(this.MainForm_Paint);
    }
    #endregion

    [STAThread]
    static void Main()
    {
        
        Application.Run(new MainForm());
        
    }


    #region Draw
    //private void Draw(int x, int y, ref RGB previous)
    //{
    //    Random rgb = new Random();
    //    //create a graphics object from the form
    //    // create  a  pen object with which to draw

    //    int rChange = 1;
    //    int gChange = 1;
    //    int bChange = 0;
    //    //int pickOne = rgb.Next(0, 3);
    //    //if (pickOne == 0)
    //    previous.r = rgb.Next(previous.r - rChange, previous.r + rChange + 1);
    //    //else if (pickOne == 1)
    //    previous.g = rgb.Next(previous.g - gChange, previous.g + gChange + 1);
    //    //else
    //    previous.b = rgb.Next(previous.b - bChange, previous.b + bChange + 1);
    //    if (previous.r < 0)
    //        previous.r = rgb.Next(0, rChange + 1);
    //    else if (previous.r > 255)
    //        previous.r = rgb.Next(255 - rChange, 256);
    //    if (previous.b < 0)
    //        previous.b = rgb.Next(0, bChange + 1);
    //    else if (previous.b > 255)
    //        previous.b = rgb.Next(255 - bChange, 256);
    //    if (previous.g < 0)
    //        previous.g = rgb.Next(0, gChange + 1);
    //    else if (previous.g > 255)
    //        previous.g = rgb.Next(255 - gChange, 256);

    //    Pen p = new Pen(Color.FromArgb(previous.r, previous.g, previous.b), 1);  // draw the line 
    //    p.DashCap = System.Drawing.Drawing2D.DashCap.Round;
    //    p.Width = 6F;
    //    // call a member of the graphics class
    //    g.DrawLine(p, x, y, x + 1, y + 1);
    //}
    private void DrawReset()
    {
        this.BackColor = Color.White;
        Graphics g = this.CreateGraphics();
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        SolidBrush b = new SolidBrush(Color.White);
        g.FillRectangle(b, new Rectangle(0, 0, FormDimensions, FormDimensions));
    }
    private void DrawBoard()
    {

        Graphics g = this.CreateGraphics();
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        Pen p = new Pen(Color.Black, 1);  // draw the line 
        p.DashCap = System.Drawing.Drawing2D.DashCap.Round;
        // call a member of the graphics class
        for (int i = 0; i < this.Width; i++)
        {
            if (i % TileMod == 0) g.DrawLine(p, i, 0, i, this.Height);
        }
        for (int i = 0; i < this.Height; i++)
        {
            if (i % TileMod == 0) g.DrawLine(p, 0, i, this.Width, i);
        }

    }

    private void DrawPlayers(Team team)
    {
        Graphics g = this.CreateGraphics();
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        SolidBrush b = new SolidBrush(team.teamColor);
        foreach (var player in team.players)
        {
            g.FillRectangle(b, new Rectangle(TileMod * player.myPos.x + 2, TileMod * player.myPos.y + 2, TileMod - 4, TileMod - 4));
        }

    }

    private void DrawResetPlayer(Team team)
    {
        Graphics g = this.CreateGraphics();
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        SolidBrush b = new SolidBrush(Color.White);
        foreach (var player in team.players)
        {
            g.FillRectangle(b, new Rectangle(TileMod * player.myPos.x + 1 , TileMod * player.myPos.y + 1, TileMod - 2, TileMod - 2));
        }

    }

    private void Display(List<Team> teams)
    {

        foreach (var team in teams)
        {
            DrawPlayers(team);
        }

    }

    #endregion
    private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        Random rng = new Random();
        int boardDimensions = FormDimensions / TileMod;
        int numPlayers = 10;

        GameObject game = new GameObject() { teams = new List<Team>(), board = new List<Board>() };
        GameController controller = new GameController();

        controller.InitializeGameValues(ref game, boardDimensions, numPlayers);
        int turn = rng.Next(0, game.teams.Count);
        DrawReset();
        DrawBoard();
        Display(game.teams);
        int rounds = 0;
        while (!controller.IsGameOver(ref game) && rounds < 10000)
        {
            DrawResetPlayer(game.teams[turn]);
            controller.Move(ref game, ref turn, boardDimensions);

            DrawPlayers(game.teams[turn]);
            Thread.Sleep(1);
            if (++turn == game.teams.Count) turn = 0;
            rounds++;
        }
        Thread.Sleep(2000);
        this.Dispose();
        //Console.Read();
        //return;
    }
    private void Form1_Resize(object sender, System.EventArgs e)
    {
    }
}