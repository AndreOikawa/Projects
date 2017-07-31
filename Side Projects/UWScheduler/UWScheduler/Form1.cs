using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UWScheduler
{
	public partial class Form1 : Form
	{
		string _url = "https://cs.uwaterloo.ca/cscf/teaching/schedule/";
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var date = DateTime.Now;
			for (int i = date.Year; i >= date.Year - 2; i--)
			{
				yearList.Items.Add(i);
			}
			GetCourseSubject();
		}

		private List<string> GetCourseSubject()
		{
			List<string> result = new List<string>();

			string urlAddress = _url;
			List<string> parseHtml;
			

			using (WebClient client = new WebClient())
			{
				string htmlCode = client.DownloadString(urlAddress);
				client.
				parseHtml = new List<string>(htmlCode.Split('\n'));
			}
			bool foundList = false;
			foreach (var line in parseHtml)
			{
				if (line == "</select>" && result.Count >0)
					break;
				else if (foundList)
					result.Add(line);
				else if (line.Contains("name=\"subject\""))
					foundList = true;
			}
			label1.Text = String.Join(" ", result);

			return result;
		}
	}
}
