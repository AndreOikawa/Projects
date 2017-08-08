using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainServer
{
	public partial class Form1 : Form
	{
		public Socket mySocket;
		public EndPoint epLocal, epRemote;
		public byte[] buffer;
		public string myIP, otherIP;
		public int port;

		int oppNum;
		private int myNum = -1;
		private bool ready = false,readyOpp = false;
		Random rng = new Random();
		public Form1()
		{
			InitializeComponent();
		}
		private void MessageCallBack(IAsyncResult aResult)
		{
			try
			{
				byte[] RecivedData = new byte[1500];
				RecivedData = (byte[])aResult.AsyncState;

				//converting byte[] into string
				ASCIIEncoding aEncoding = new ASCIIEncoding();
				string RecivedMessage = aEncoding.GetString(RecivedData);

				//Adding this message to listbox
				//ListMessages.Items.Add("Friend : " + RecivedMessage);
				oppNum = Convert.ToInt32(RecivedMessage);
				readyOpp = true;
				//ListMessages.Items.Add("Friend : " + RecivedMessage);

			

				buffer = new byte[1500];
				mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void button3_Click(object sender, EventArgs e)
		{
			//converting string messages to byte
			ASCIIEncoding aEncoding = new ASCIIEncoding();
			byte[] SendingMessage = new byte[1500];
			SendingMessage = aEncoding.GetBytes(button3.Text);

			//sending Encoding message
			mySocket.Send(SendingMessage);
			ListMessages.Items.Add("ME : " + button3.Text);
			myNum = Convert.ToInt32(button3.Text);
			button3.Text = rng.Next(0, 11).ToString();

			DisableButtons();

		}

		private void button4_Click(object sender, EventArgs e)
		{
			//converting string messages to byte
			ASCIIEncoding aEncoding = new ASCIIEncoding();
			byte[] SendingMessage = new byte[1500];
			SendingMessage = aEncoding.GetBytes(button4.Text);

			//sending Encoding message
			mySocket.Send(SendingMessage);
			ListMessages.Items.Add("ME : " + button4.Text);
			myNum = Convert.ToInt32(button4.Text);
			button4.Text = rng.Next(0, 11).ToString();

			DisableButtons();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//converting string messages to byte
			ASCIIEncoding aEncoding = new ASCIIEncoding();
			byte[] SendingMessage = new byte[1500];
			SendingMessage = aEncoding.GetBytes(button2.Text);

			//sending Encoding message
			mySocket.Send(SendingMessage);
			ListMessages.Items.Add("ME : " + button2.Text);
			myNum = Convert.ToInt32(button2.Text);
			button2.Text = rng.Next(0, 11).ToString();

			DisableButtons();
		}
		private void EnableButtons()
		{
			button1.Enabled = true;
			button2.Enabled = true;
			button3.Enabled = true;
			button4.Enabled = true;
			ready = false;
		}
		private void DisableButtons()
		{
			button1.Enabled = false;
			button2.Enabled = false;
			button3.Enabled = false;
			button4.Enabled = false;
			ready = true;
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (ready && readyOpp)
			{
				readyOpp = false;
				if (oppNum > myNum)
				{
					lblHighest.Text = oppNum.ToString();
					lblWinner.Text = "Opponent";
					EnableButtons();
				}
				else if (oppNum < myNum)
				{
					lblHighest.Text = myNum.ToString();
					lblWinner.Text = "You";
					EnableButtons();
				}
				else
				{
					lblHighest.Text = myNum.ToString();
					lblWinner.Text = "Tie";
					EnableButtons();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//converting string messages to byte
			ASCIIEncoding aEncoding = new ASCIIEncoding();
			byte[] SendingMessage = new byte[1500];
			SendingMessage = aEncoding.GetBytes(button1.Text);

			//sending Encoding message
			mySocket.Send(SendingMessage);
			ListMessages.Items.Add("ME : " + button1.Text);
			myNum = Convert.ToInt32(button1.Text);
			button1.Text = rng.Next(0, 11).ToString();

			DisableButtons();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//set up socket
			mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

			mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

			//binding sockets
			epLocal = new IPEndPoint(IPAddress.Parse(myIP), port);
			mySocket.Bind(epLocal);
			//Connecting To Remote IP
			epRemote = new IPEndPoint(IPAddress.Parse(otherIP), 9000);
			mySocket.Connect(epRemote);

			//Listening TO specific Port
			buffer = new byte[1500];
			mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

			button1.Text = rng.Next(0, 11).ToString();
			button2.Text = rng.Next(0, 11).ToString();
			button3.Text = rng.Next(0, 11).ToString();
			button4.Text = rng.Next(0, 11).ToString();
		}
	}
}
