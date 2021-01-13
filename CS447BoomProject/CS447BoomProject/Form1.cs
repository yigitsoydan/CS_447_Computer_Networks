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

namespace CS447BoomProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BoomServer mServer = new BoomServer();
            mServer.StartListeningForIncomingConnection();
        }

        int flag = 0;

        int bomb1 = 0;
        int bomb2 = 0;

        private async void btnConnect_Click_1(object sender, EventArgs e)
        {
            btnConnect.Visible = false;
            lblConnectedToServer.Visible = true;
            ButtonStartGame.Visible = true;
           
            SetServerIPAddress("192.168.2.167");  // WRITE YOUR IP ADDRESS HERE
            SetPortNumber("23000");
            await ConnectToServer();
        }

        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            SendToServer("777");     
        }
        
        public void makeAllButtonSame()
        {
            btn1.BackColor = Color.Sienna;
            btn2.BackColor = Color.Sienna;
            btn3.BackColor = Color.Sienna;
            btn4.BackColor = Color.Sienna;
            btn5.BackColor = Color.Sienna;
            btn6.BackColor = Color.Sienna;
            btn7.BackColor = Color.Sienna;
            btn8.BackColor = Color.Sienna;
            btn9.BackColor = Color.Sienna;
            btn10.BackColor = Color.Sienna;
            btn11.BackColor = Color.Sienna;
            btn12.BackColor = Color.Sienna;
            btn13.BackColor = Color.Sienna;
            btn14.BackColor = Color.Sienna;
            btn15.BackColor = Color.Sienna;
            btn16.BackColor = Color.Sienna;
            btn17.BackColor = Color.Sienna;
            btn18.BackColor = Color.Sienna;
            btn19.BackColor = Color.Sienna;
            btn20.BackColor = Color.Sienna;
            btn21.BackColor = Color.Sienna;
            btn22.BackColor = Color.Sienna;
            btn23.BackColor = Color.Sienna;
            btn24.BackColor = Color.Sienna;
            btn25.BackColor = Color.Sienna;
        }

        public void makeAllButtonsVisible()
        {
            btn1.Visible = true;
            btn2.Visible = true;
            btn3.Visible = true;
            btn4.Visible = true;
            btn5.Visible = true;
            btn6.Visible = true;
            btn7.Visible = true;
            btn8.Visible = true;
            btn9.Visible = true;
            btn10.Visible = true;
            btn11.Visible = true;
            btn12.Visible = true;
            btn13.Visible = true;
            btn14.Visible = true;
            btn15.Visible = true;
            btn16.Visible = true;
            btn17.Visible = true;
            btn18.Visible = true;
            btn19.Visible = true;
            btn20.Visible = true;
            btn21.Visible = true;
            btn22.Visible = true;
            btn23.Visible = true;
            btn24.Visible = true;
            btn25.Visible = true;
        }


        public void closeAllButtons()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            btn10.Enabled = false;
            btn11.Enabled = false;
            btn12.Enabled = false;
            btn13.Enabled = false;
            btn14.Enabled = false;
            btn15.Enabled = false;
            btn16.Enabled = false;
            btn17.Enabled = false;
            btn18.Enabled = false;
            btn19.Enabled = false;
            btn20.Enabled = false;
            btn21.Enabled = false;
            btn22.Enabled = false;
            btn23.Enabled = false;
            btn24.Enabled = false;
            btn25.Enabled = false;
        }

        public void openAllButtons()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btn10.Enabled = true;
            btn11.Enabled = true;
            btn12.Enabled = true;
            btn13.Enabled = true;
            btn14.Enabled = true;
            btn15.Enabled = true;
            btn16.Enabled = true;
            btn17.Enabled = true;
            btn18.Enabled = true;
            btn19.Enabled = true;
            btn20.Enabled = true;
            btn21.Enabled = true;
            btn22.Enabled = true;
            btn23.Enabled = true;
            btn24.Enabled = true;
            btn25.Enabled = true;
            
        }

        public void allButtonsHide()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;
        }

        
        private void btn1_Click_1(object sender, EventArgs e)
        {
            SendToServer("1");
            flag = 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SendToServer("2");
            flag = 1;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SendToServer("3");
            flag = 1;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SendToServer("4");
            flag = 1;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SendToServer("5");
            flag = 1;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SendToServer("6");
            flag = 1;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SendToServer("7");
            flag = 1;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SendToServer("8");
            flag = 1;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            SendToServer("9");
            flag = 1;
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            SendToServer("10");
            flag = 1;
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            SendToServer("11");
            flag = 1;
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            SendToServer("12");
            flag = 1;
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            SendToServer("13");
            flag = 1;
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            SendToServer("14");
            flag = 1;
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            SendToServer("15");
            flag = 1;
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            SendToServer("16");
            flag = 1;
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            SendToServer("17");
            flag = 1;
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            SendToServer("18");
            flag = 1;
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            SendToServer("19");
            flag = 1;
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            SendToServer("20");
            flag = 1;
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            SendToServer("21");
            flag = 1;
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            SendToServer("22");
            flag = 1;
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            SendToServer("23");
            flag = 1;
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            SendToServer("24");
            flag = 1;
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            SendToServer("25");
            flag = 1;
        }




        //CLIENT CONNECTION STARTS HERE

        IPAddress mServerIPAddress;
        public IPAddress ServerIPAddress
        {
            get
            {
                return mServerIPAddress;
            }
        }

        public bool SetServerIPAddress(string _IPAddressServer)
        {
            IPAddress ipaddr = null;
            if (!IPAddress.TryParse(_IPAddressServer, out ipaddr))
            {
                Console.WriteLine("Invalid server IP supplied.");
                return false;
            }

            mServerIPAddress = ipaddr;
            return true;
        }

        int mServerPort;
        public int ServerPort
        {
            get
            {
                return mServerPort;
            }
        }

        public bool SetPortNumber(string _ServerPort)
        {
            int portNumber = 0;

            if (!int.TryParse(_ServerPort.Trim(), out portNumber))
            {
                Console.WriteLine("Invalid port number supplied, return.");
                return false;
            }

            if (portNumber <= 0 || portNumber > 65535)
            {
                Console.WriteLine("Port number must be between 0 and 65535.");
                return false;
            }

            mServerPort = portNumber;

            return true;
        }

        TcpClient mClient;

        public async void SendToServer(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Empty string supplied to send.");
                return;
            }
            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    System.IO.StreamWriter clientStreamWriter = new System.IO.StreamWriter(mClient.GetStream());
                    clientStreamWriter.AutoFlush = true;
                    clientStreamWriter.WriteAsync(userInput);
                    Console.WriteLine("Write data to server done. ");
                }
            }
        }

        public async Task ConnectToServer()
        {
            if (mClient == null)
            {
                mClient = new TcpClient();
            }
            try
            {
                await mClient.ConnectAsync(mServerIPAddress, mServerPort);
                Console.WriteLine(string.Format("Connected to server IP/Port: {0} / {1}", mServerIPAddress, mServerPort));

                System.IO.StreamReader clientStreamReader = new System.IO.StreamReader(mClient.GetStream());

                char[] buff = new char[64];
                int readByteCount = 0;

                while (true)
                {
                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);

                    if (readByteCount <= 0)
                    {
                        Console.WriteLine("Disconnected from server.");
                        break;
                    }

                    Console.WriteLine(string.Format("Received bytes: {0} - Message: {1}", readByteCount, new string(buff)));

                    if (new string(buff).Trim('\0').Equals("101"))
                    {
                        btn1.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("201") || new string(buff).Contains("201"))
                    {
                        btn1.BackColor = Color.Red;
                        pictureBox1.Visible = true;
                        pictureBox1.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;

                    }
                    else if (new string(buff).Trim('\0').Equals("102"))
                    {
                        btn2.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("202") || new string(buff).Contains("202"))
                    {
                        btn2.BackColor = Color.Red;
                        pictureBox2.Visible = true;
                        pictureBox2.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("103"))
                    {
                        btn3.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("203") || new string(buff).Contains("203"))
                    {
                        btn3.BackColor = Color.Red;
                        pictureBox3.Visible = true;
                        pictureBox3.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("104"))
                    {
                        btn4.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("204") || new string(buff).Contains("204"))
                    {
                        btn4.BackColor = Color.Red;
                        pictureBox4.Visible = true;
                        pictureBox4.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("105"))
                    {
                        btn5.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("205") || new string(buff).Contains("205"))
                    {
                        btn5.BackColor = Color.Red;
                        pictureBox5.Visible = true;
                        pictureBox5.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("106"))
                    {
                        btn6.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("206") || new string(buff).Contains("206"))
                    {
                        btn6.BackColor = Color.Red;
                        pictureBox6.Visible = true;
                        pictureBox6.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("107"))
                    {
                        btn7.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("207") || new string(buff).Contains("207"))
                    {
                        btn7.BackColor = Color.Red;
                        pictureBox7.Visible = true;
                        pictureBox7.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("108") )
                    {
                        btn8.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("108") || new string(buff).Contains("208"))
                    {
                        btn8.BackColor = Color.Red;
                        pictureBox8.Visible = true;
                        pictureBox8.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("109"))
                    {
                        btn9.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("209") || new string(buff).Contains("209") )
                    {
                        btn9.BackColor = Color.Red;
                        pictureBox9.Visible = true;
                        pictureBox9.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("110"))
                    {
                        btn10.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("210") || new string(buff).Contains("210"))
                    {
                        btn10.BackColor = Color.Red;
                        pictureBox10.Visible = true;
                        pictureBox10.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("111"))
                    {
                        btn11.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("211") || new string(buff).Contains("211"))
                    {
                        btn11.BackColor = Color.Red;
                        pictureBox11.Visible = true;
                        pictureBox11.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("112"))
                    {
                        btn12.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("212") || new string(buff).Contains("212"))
                    {
                        btn12.BackColor = Color.Red;
                        pictureBox12.Visible = true;
                        pictureBox12.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("113"))
                    {
                        btn13.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("213") || new string(buff).Contains("213"))
                    {
                        btn13.BackColor = Color.Red;
                        pictureBox13.Visible = true;
                        pictureBox13.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("114"))
                    {
                        btn14.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("214") || new string(buff).Contains("214"))
                    {
                        btn14.BackColor = Color.Red;
                        pictureBox14.Visible = true;
                        pictureBox14.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("115"))
                    {
                        btn15.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("215") || new string(buff).Contains("215"))
                    {
                        btn15.BackColor = Color.Red;
                        pictureBox15.Visible = true;
                        pictureBox15.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("116"))
                    {
                        btn16.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("216") || new string(buff).Contains("216"))
                    {
                        btn16.BackColor = Color.Red;
                        pictureBox16.Visible = true;
                        pictureBox16.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("117"))
                    {
                        btn17.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("217") || new string(buff).Contains("217"))
                    {
                        btn17.BackColor = Color.Red;
                        pictureBox17.Visible = true;
                        pictureBox17.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("118"))
                    {
                        btn18.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("218") || new string(buff).Contains("218"))
                    {
                        btn18.BackColor = Color.Red;
                        pictureBox18.Visible = true;
                        pictureBox18.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("119"))
                    {
                        btn19.BackColor = Color.Green;
                        
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("219") || new string(buff).Contains("219"))
                    {
                        btn19.BackColor = Color.Red;
                        pictureBox19.Visible = true;
                        pictureBox19.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("120"))
                    {
                        btn20.BackColor = Color.Green;

                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("220") || new string(buff).Contains("220"))
                    {
                        btn20.BackColor = Color.Red;
                        pictureBox20.Visible = true;
                        pictureBox20.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;

                    }
                    else if (new string(buff).Trim('\0').Equals("121"))
                    {
                        btn21.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("221") || new string(buff).Contains("221"))
                    {
                        btn21.BackColor = Color.Red;
                        pictureBox21.Visible = true;
                        pictureBox21.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("122"))
                    {
                        btn22.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("222") || new string(buff).Contains("222"))
                    {
                        btn22.BackColor = Color.Red;
                        pictureBox22.Visible = true;
                        pictureBox22.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("123"))
                    {
                        btn23.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("223") || new string(buff).Contains("223"))
                    {
                        btn23.BackColor = Color.Red;
                        pictureBox23.Visible = true;
                        pictureBox23.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("124"))
                    {
                        btn24.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("224") || new string(buff).Contains("224"))
                    {
                        btn24.BackColor = Color.Red;
                        pictureBox24.Visible = true;
                        pictureBox24.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("125"))
                    {
                        btn25.BackColor = Color.Green;
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("225") || new string(buff).Contains("225"))
                    {
                        btn25.BackColor = Color.Red;
                        pictureBox25.Visible = true;
                        pictureBox25.BringToFront();
                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }

                    if (new string(buff).Contains("991") || new string(buff).Trim('\0').Equals("991") || new string(buff).Trim('\0').Equals("991333") || new string(buff).Trim('\0').Equals("991334") || new string(buff).Trim('\0').Equals("1991333") || new string(buff).Trim('\0').Equals("1991333") || new string(buff).Trim('\0').Equals("1991334")) {
                        
                        lblWinner.Text = "PLAYER 2 WINS!";
                        lblWinner.BringToFront(); 
                        lblWinner.Visible = true;
                        btnRestart.Visible = true;
                        lblPlayerTurn.Visible = false;
                        lblGameStarted.Visible = false;
                        closeAllButtons();
                    }
                    else if (new string(buff).Trim('\0').Contains("992") || new string(buff).Trim('\0').Equals("992") || new string(buff).Trim('\0').Equals("992333") || new string(buff).Trim('\0').Equals("992334") || new string(buff).Trim('\0').Equals("1992334") || new string(buff).Trim('\0').Equals("1992333"))
                    {
                        lblWinner.Text = "PLAYER 1 WINS";
                        lblWinner.BringToFront();
                        lblWinner.Visible = true;
                        btnRestart.Visible = true;
                        lblPlayerTurn.Visible = false;
                        lblGameStarted.Visible = false;
                        closeAllButtons();

                    }else if(new string(buff).Trim('\0').Equals("333") || new string(buff).Trim('\0').Equals("1333") || new string(buff).Trim('\0').Equals("2333"))
                    {
                        lblPlayerTurn.Text = "Player 1's Turn";
                    }
                    else if (new string(buff).Trim('\0').Equals("334") || new string(buff).Trim('\0').Equals("1334") ||  new string(buff).Trim('\0').Equals("2334"))
                    {
                        lblPlayerTurn.Text = "Player 2's Turn";
                    }
                    else if (new string(buff).Trim('\0').Equals("778")) // Just Client 1
                    {
                        lblPlayerChooser1.Text = "Player 1";
                        lblPlayerChooser1.Visible = true;
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("779")) // Common for Clients
                    {
                        
                        lblGameStarted.Text = "Game started!";
                        lblGameStarted.Visible = true;
                        lblPlayerTurn.Visible = true;
                        ButtonStartGame.Visible = false;
                        lblConnectedToServer.Visible = false;
                        txtScore.Visible = true;
                        makeAllButtonsVisible();

                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;
                    }
                    else if (new string(buff).Trim('\0').Equals("780")) // Just Client 2
                    {
                        lblPlayerChooser2.Text = "Player 2";
                        lblPlayerChooser2.Visible = true;

                        flag = 1;
                    }
                    else if (new string(buff).Trim('\0').Equals("776")) // Client1 1 bağlantı varken
                    {
                        lblGameStarted.Text = "Searching for opponent";
                        lblGameStarted.Visible = true;
                    }
                    else if (new string(buff).Trim('\0').Equals("782")) // Client2 2.oyun ve sonrası
                    {
                        lblPlayerChooser2.Text = "Player 2";
                        lblPlayerChooser2.Visible = true;
                        
                    }
                    else if (new string(buff).Trim('\0').Equals("783")) // Common for Clients 2.oyun sonrası
                    {
                        lblGameStarted.Text = "Game started!";
                        lblGameStarted.Visible = true;
                        lblPlayerTurn.Visible = false;
                        ButtonStartGame.Visible = false;
                        lblConnectedToServer.Visible = false;
                        txtScore.Visible = true;
                        makeAllButtonsVisible();

                        if (flag == 1)
                        {
                            closeAllButtons();
                        }
                        else openAllButtons();
                        flag = 0;

                    }

                    if (new string(buff).Trim('\0').Equals("1") || new string(buff).Trim('\0').Equals("1334") || new string(buff).Trim('\0').Equals("1333") || new string(buff).Trim('\0').Equals("1991334") || new string(buff).Trim('\0').Equals("1991333"))
                    {
                        
                        ++bomb1;
                        txtScore.Text = bomb1.ToString();
                    }
                    else if (new string(buff).Trim('\0').Equals("2") || new string(buff).Trim('\0').Equals("2334") || new string(buff).Trim('\0').Equals("2333") || new string(buff).Trim('\0').Equals("2991334") || new string(buff).Trim('\0').Equals("2991333"))
                    {
                        ++bomb2;
                        txtScore.Text = bomb2.ToString();
                    }


                    if(new string(buff).Trim('\0').Equals("445"))
                    {
                        ButtonStartGame.Visible = true;
                        
                    }

                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            SendToServer("444");
            ButtonStartGame.Visible = true;
            makeAllButtonSame();
            lblWinner.Visible = false;
            bomb1 = 0;
            bomb2 = 0;
            txtScore.Text = "";
            lblBombsFound.Visible = false;
            lblPlayerChooser1.Visible = false;
            lblPlayerChooser2.Visible = false;
            txtScore.Visible = false;
            lblGameStarted.Text = "Waiting for other player";
            allButtonsHide();
            btnRestart.Visible = false;

        }
    }
}
