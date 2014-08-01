using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace YChatServer
{
    public partial class formYChatServer : Form
    {
        public formYChatServer()
        {
            InitializeComponent();
        }

        private void formYChatServer_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.buttonStart.Enabled = false;
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TcpListener listener = new TcpListener(ip, 8500);
            listener.Start();
            //Console.WriteLine("Start Listening");

            String originalTitle = this.Text;
            this.Text = originalTitle + "- Wait for client...";
            TcpClient remoteClient = listener.AcceptTcpClient();
            this.Text = originalTitle + "- Connected!";

            
            byte[] buffer = new byte[8192];
            int bytesRead = 0;
            string receivedMsg = "";
            
                NetworkStream streamToClient = remoteClient.GetStream();
                bytesRead = streamToClient.Read(buffer, 0, 8192);

                receivedMsg = Encoding.Unicode.GetString(buffer, 0, bytesRead);

                this.richTextBox2.AppendText(receivedMsg);

        }

    }
}