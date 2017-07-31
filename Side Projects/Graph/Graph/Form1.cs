using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{

	public partial class Graph : Form
	{
		private int _radius = 12;
		private int _nodeCount = 0;
		private class Node
		{
			public string shape;
			public Color colour;
			public int xPos, yPos, nodeNum, width, height;
			public List<Connector> connections;
			public Node() { }
			public Node(string s, Color c, int x, int y, int num, int w, int h)
			{
				xPos = x;
				yPos = y;
				nodeNum = num;
				height = h;
				width = w;
				colour = c;
				shape = s;
				connections = new List<Connector>();
			}
			public override string ToString()
			{
				return nodeNum.ToString();
			}
			public void AddEdge(ref Connector edge)
			{
				connections.Add(edge);
			}
		}

		private class Connector
		{
			public Node x, y;
			public Color colour;
			public Connector() { }
			public Connector(Node _x, Node _y, Color c)
			{
				x = _x;
				y = _y;
				colour = c;
			}
		}

		private List<Node> _graph = new List<Node>();

		private HashSet<Connector> _edges = new HashSet<Connector>();
		public Graph()
		{
			InitializeComponent();
		}
		private void DrawIt(int x, int y, int width, int height, Color colour, Graphics g, string shape, string value)
		{
			//System.Drawing.Graphics graphics = this.CreateGraphics();
			SolidBrush myBrush = new SolidBrush(colour);

			if (shape == "Rect")
			{
				Rectangle rectangle = new Rectangle(x, y, width, height);
				g.FillRectangle(myBrush, rectangle);
				myBrush.Dispose();
			}
			else if (shape == "Circle")
			{
				g.FillEllipse(
					myBrush,
					x, y, width, height);
				g.DrawString(value, new Font("Arial", 14), Brushes.Black, new Point(x + width / 10, y + height / 10));
			}
			else if (shape == "Line")
			{
				g.DrawLine(new Pen(colour, 2f), new Point(x + _radius, y + _radius), new Point(width + _radius, height + _radius));
			}
		}
		private void addBtn_Click(object sender, EventArgs e)
		{
			_nodeCount++;
			Node node = new Node(
				"Circle",
				Color.Red,
				Canvas.Location.X + Canvas.Width / 2,
				Canvas.Location.Y + Canvas.Height / 2,
				_nodeCount,
				2 * _radius,
				2 * _radius);

			_graph.Add(node);

			deleteBox.Items.Add(node);
			deleteBox.SelectedIndex = 0;

			connectABox.Items.Add(node);
			connectABox.SelectedIndex = 0;

			connectBBox.Items.Add(node);
			connectBBox.SelectedIndex = 0;
		}

		private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// Create a local version of the graphics object for the PictureBox.
			Graphics g = e.Graphics;

			// Draw a line in the PictureBox.
			DrawIt(0, 0, Canvas.Width, Canvas.Height, Color.White, g, "Rect", "");

			foreach (Connector edge in _edges)
				DrawIt(edge.x.xPos, edge.x.yPos, edge.y.xPos, edge.y.yPos, edge.colour, g, "Line", "");

			foreach (Node node in _graph)
			{
				DrawIt(node.xPos, node.yPos, node.width, node.height, node.colour, g, node.shape, node.nodeNum.ToString());
			}


		}

		private void delBtn_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (Connector edge in ((Node)deleteBox.SelectedItem).connections)
				{
					_edges.Remove(edge);
				}
				_graph.Remove((Node)deleteBox.SelectedItem);

				connectABox.Items.Remove(deleteBox.SelectedItem);

				if (connectABox.Items.Count == 0) connectABox.Text = "";
				else connectABox.SelectedIndex = 0;

				connectBBox.Items.Remove(deleteBox.SelectedItem);

				if (connectBBox.Items.Count == 0) connectBBox.Text = "";
				else connectBBox.SelectedIndex = 0;

				deleteBox.Items.Remove(deleteBox.SelectedItem);

				if (deleteBox.Items.Count == 0) deleteBox.Text = "";
				else deleteBox.SelectedIndex = 0;
			}
			catch (Exception x)
			{

			}
		}

		private void conBtn_Click(object sender, EventArgs e)
		{
			if (connectABox.SelectedItem != connectBBox.SelectedItem)
			{
				Connector line = new Connector();
				line.x = (Node)connectABox.SelectedItem;
				line.y = (Node)connectBBox.SelectedItem;
				line.colour = Color.BlueViolet;
				if (_edges.Add(line))
				{
					_graph.Find(x => x.nodeNum == ((Node)connectABox.SelectedItem).nodeNum).AddEdge(ref line);
					_graph.Find(x => x.nodeNum == ((Node)connectBBox.SelectedItem).nodeNum).AddEdge(ref line);
				}

			}
		}


		private void Refresh_Tick(object sender, EventArgs e)
		{
			Canvas.Paint += new PaintEventHandler(pictureBox1_Paint);
			Canvas.Refresh();

		}

		private bool _dragging = false;
		private Node _draggingNode;
		private void Canvas_Click(object sender, EventArgs e)
		{
			Point pos = Canvas.PointToClient(Cursor.Position);
			label5.Text = pos.ToString();
			if (!_dragging)
				foreach (Node node in _graph)
				{
					Point center = new Point(node.xPos + node.width / 2, node.yPos + node.height / 2);

					if (AbsDist(center, pos) <= Math.Pow(node.width / 2, 2))
					{
						_dragging = true;
						_draggingNode = node;
						label4.Text = _draggingNode.nodeNum.ToString();
						break;
						//MessageBox.Show("hello");
					}
				}
			else
			{
				deleteBox.Items.Clear();
				deleteBox.Items.AddRange(_graph.Cast<object>().ToArray());
				deleteBox.SelectedIndex = 0;

				connectABox.Items.Clear();
				connectABox.Items.AddRange(_graph.Cast<object>().ToArray());
				connectABox.SelectedIndex = 0;

				connectBBox.Items.Clear();
				connectBBox.Items.AddRange(_graph.Cast<object>().ToArray());
				connectBBox.SelectedIndex = 0;

				_dragging = false;
				_draggingNode = new Node();
				label4.Text = "";
			}
		}

		private double AbsDist(Point p1, Point p2)
		{
			double val = (Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
			return val;
		}



		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			label3.Text = e.Location.ToString();
			if (_dragging)
			{
				_graph.Remove(_draggingNode);
				_draggingNode.xPos = e.Location.X;
				_draggingNode.yPos = e.Location.Y;

				int len = _draggingNode.connections.Count;
				for (int i = 0; i < len; i++)
				{
					if (_draggingNode.connections[i].x.nodeNum == _draggingNode.nodeNum)
					{
						_draggingNode.connections[i].x = _draggingNode;
					}
					else
					{
						_draggingNode.connections[i].y = _draggingNode;
					}
				}


				_graph.Add(_draggingNode);
			}
		}
	}
}
