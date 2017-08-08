using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
//lucas ip: 10.64.14.116
namespace MainServer
{
	public partial class Connection : Form
	{
		
		public Connection()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var frm = new Form1();
			frm.port = 9000;
			frm.myIP = txtLocalIP.Text;
			frm.otherIP = txtRemoteIP.Text;
			//frm.mySocket = mySocket;
			//frm.epLocal = epLocal;
			//frm.epRemote = epRemote;
			frm.Location = this.Location;
			frm.StartPosition = FormStartPosition.Manual;
			frm.FormClosing += delegate { this.Show(); };
			frm.Show();
			this.Hide();
		}

		private void Connection_Load(object sender, EventArgs e)
		{
		
			
			//get user IP
			txtLocalIP.Text = GetLocalIP();
			
		}
		private string GetLocalIP()
		{
			IPHostEntry myHost;
			myHost = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in myHost.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
					return ip.ToString();
			}
			return "127.0.0.1";
		}
	}
}
