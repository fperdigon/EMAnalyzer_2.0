/*
 * Created by SharpDevelop.
 * User: Francisco Perdigon Romero
 * Date: 2/16/2022
 * Time: 2:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EMAnalizer_2._0
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}			
		

		
		void Label2Click(object sender, EventArgs e)
		{
			string url = "https://github.com/fperdigon";
			url = url.Replace("&", "^&");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string url = "https://github.com/fperdigon";
			url = url.Replace("&", "^&");
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });			
		}
	}
}
