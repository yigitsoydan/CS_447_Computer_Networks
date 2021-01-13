using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CS447BoomProject
{
    public class BoomServer
    {
        IPAddress mIP;
        int mPort;
        TcpListener mTCPListener;

        List<TcpClient> mClients;

        Game games = new Game();
        int[] gamebombsarray;

        int bombplayer1 = 0;
        int bombplayer2 = 0;

        int restartwant = 0;

        Random r = new Random();
        
        public int playerturn = 1;
        

        public bool KeepRunning { get; set; }

        public BoomServer()
        {
            mClients = new List<TcpClient>();
        }

        public void TurnChecker()
        {
            if (playerturn % 2 == 1) SendToAll("333");
            else if(playerturn % 2 == 0) SendToAll("334");
        }

        public void startTurn()
        {
            playerturn = r.Next(1, 3);
        }
        
        

        public async void StartListeningForIncomingConnection(IPAddress ipaddr = null, int port = 23000)
        {
            if (ipaddr == null)
            {
                ipaddr = IPAddress.Any;
            }

            if (port <= 0)
            {
                port = 23000;
            }

            mIP = ipaddr;
            mPort = port;

            System.Diagnostics.Debug.WriteLine(string.Format("IP Address: {0} - Port: {1}", mIP.ToString(), mPort));

            mTCPListener = new TcpListener(mIP, mPort);

            try
            {
                mTCPListener.Start();

                KeepRunning = true;

                while (KeepRunning)
                {
                    var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();

                    mClients.Add(returnedByAccept);

                    Debug.WriteLine(
                        string.Format("Client connected successfully, count: {0} - {1}",
                        mClients.Count, returnedByAccept.Client.RemoteEndPoint)
                        );
                    if(mClients.Count == 2)
                    {
                        gamebombsarray = games.BombLocate();
                        Console.WriteLine("Oyun hazırlandı.");
                    }
                    TakeCareOfTCPClient(returnedByAccept);
                }

            }
            catch (Exception excp)
            {
                System.Diagnostics.Debug.WriteLine(excp.ToString());
            }
        }

        public void StopServer()
        {
            try
            {
                if (mTCPListener != null)
                {
                    mTCPListener.Stop();
                }

                foreach (TcpClient c in mClients)
                {
                    c.Close();
                }

                mClients.Clear();
            }
            catch (Exception excp)
            {

                Debug.WriteLine(excp.ToString());
            }
        }

        private async void TakeCareOfTCPClient(TcpClient paramClient)
        {
            NetworkStream stream = null;
            System.IO.StreamReader reader = null;

            try
            {
                stream = paramClient.GetStream();
                reader = new System.IO.StreamReader(stream);

                char[] buff = new char[64];

                while (KeepRunning)
                {
                    Debug.WriteLine("Ready to read");

                    int nRet = await reader.ReadAsync(buff, 0, buff.Length);

                    if (nRet == 0)
                    {
                        RemoveClient(paramClient);

                        break;
                    }

                    string receivedText = new string(buff);


                    Console.WriteLine("Server get the message: " + receivedText);

                    if(receivedText.Trim('\0').Equals("1") && gamebombsarray[0] == 0)
                    { 
                        SendToAll("101");
                        playerturn++;
                        TurnChecker();
                    }
                    else if(receivedText.Trim('\0').Equals("1") && gamebombsarray[0] == 1)
                    {
                        SendToAll("201");
                        

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                       

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("2") && gamebombsarray[1] == 0)
                    {
                        
                        SendToAll("102");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("2") && gamebombsarray[1] == 1)
                    {

                        SendToAll("202");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("3") && gamebombsarray[2] == 0)
                    {
                        
                        SendToAll("103");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("3") && gamebombsarray[2] == 1)
                    {
                        SendToAll("203");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("4") && gamebombsarray[3] == 0)
                    {
                        
                        SendToAll("104");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("4") && gamebombsarray[3] == 1)
                    {

                        SendToAll("204");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }

                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("5") && gamebombsarray[4] == 0)
                    {
                        
                        SendToAll("105");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("5") && gamebombsarray[4] == 1)
                    {
                        SendToAll("205");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("6") && gamebombsarray[5] == 0)
                    {
                        
                        SendToAll("106");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("6") && gamebombsarray[5] == 1)
                    {
                        SendToAll("206");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("7") && gamebombsarray[6] == 0)
                    {
                        
                        SendToAll("107");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("7") && gamebombsarray[6] == 1)
                    {
                        SendToAll("207");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("8") && gamebombsarray[7] == 0)
                    {
                        
                        SendToAll("108");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("8") && gamebombsarray[7] == 1)
                    {
                        SendToAll("208");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                       

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("9") && gamebombsarray[8] == 0)
                    {
                        
                        SendToAll("109");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("9") && gamebombsarray[8] == 1)
                    {
                        SendToAll("209");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                       

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("10") && gamebombsarray[9] == 0)
                    {
                       
                        SendToAll("110");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("10") && gamebombsarray[9] == 1)
                    {
                        SendToAll("210");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("11") && gamebombsarray[10] == 0)
                    {
                        
                        SendToAll("111");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("11") && gamebombsarray[10] == 1)
                    {
                        SendToAll("211");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("12") && gamebombsarray[11] == 0)
                    {
                        
                        SendToAll("112");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("12") && gamebombsarray[11] == 1)
                    {
                        SendToAll("212");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("13") && gamebombsarray[12] == 0)
                    {
                        
                        SendToAll("113");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("13") && gamebombsarray[12] == 1)
                    {
                        SendToAll("213");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("14") && gamebombsarray[13] == 0)
                    {
                        
                        SendToAll("114");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("14") && gamebombsarray[13] == 1)
                    {
                        SendToAll("214");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("15") && gamebombsarray[14] == 0)
                    {
                        SendToAll("115");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("15") && gamebombsarray[14] == 1)
                    {
                        SendToAll("215");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("16") && gamebombsarray[15] == 0)
                    {
                        SendToAll("116");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("16") && gamebombsarray[15] == 1)
                    {
                        SendToAll("216");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }

                    else if (receivedText.Trim('\0').Equals("17") && gamebombsarray[16] == 0)
                    {
                       
                        SendToAll("117");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("17") && gamebombsarray[16] == 1)
                    {
                        SendToAll("217");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("18") && gamebombsarray[17] == 0)
                    {
                        
                        SendToAll("118");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("18") && gamebombsarray[17] == 1)
                    {
                        SendToAll("218");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("19") && gamebombsarray[18] == 0)
                    {
                        
                        SendToAll("119");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("19") && gamebombsarray[18] == 1)
                    {
                        SendToAll("219");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("20") && gamebombsarray[19] == 0)
                    {
                        
                        SendToAll("120");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("20") && gamebombsarray[19] == 1)
                    {
                        SendToAll("220");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("21") && gamebombsarray[20] == 0)
                    {
                        
                        SendToAll("121");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("21") && gamebombsarray[20] == 1)
                    {
                        SendToAll("221");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("1");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("22") && gamebombsarray[21] == 0)
                    {
                        
                        SendToAll("122");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("22") && gamebombsarray[21] == 1)
                    {
                        SendToAll("222");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("23") && gamebombsarray[22] == 0)
                    {
                        
                        SendToAll("123");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("23") && gamebombsarray[22] == 1)
                    {
                        SendToAll("223");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("24") && gamebombsarray[23] == 0)
                    {
                        
                        SendToAll("124");
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("24") && gamebombsarray[23] == 1)
                    {
                        SendToAll("224");
                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if (playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("25") && gamebombsarray[24] == 0)
                    {
                        
                        SendToAll("125");

                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("25") && gamebombsarray[24] == 1)
                    {
                        SendToAll("225");

                        if (playerturn % 2 == 1)
                        {
                            ++bombplayer1;
                            SendToFirst("1");
                        }
                        else if(playerturn % 2 == 0)
                        {
                            ++bombplayer2;
                            SendToSecond("2");
                        }

                        

                        if (bombplayer1 == 3)
                        {
                            SendToAll("991");
                        }
                        else if (bombplayer2 == 3)
                        {
                            SendToAll("992");
                        }
                        playerturn++;
                        TurnChecker();
                    }
                    else if (receivedText.Trim('\0').Equals("777"))
                    {
                        if (mClients.Count == 1)
                        {
                            SendToFirst("776");
                        }
                        else if (mClients.Count == 2) {
                            SendToFirst("778");
                            SendToSecond("780");
                            SendToAll("779");
                        }
                    }

                    if (receivedText.Trim('\0').Equals("444"))
                    {
                        ++restartwant;
                        bombplayer1 = 0;
                        bombplayer2 = 0;
                        gamebombsarray = games.BombLocate();
                        playerturn = 1;

                        if (restartwant %2 == 0)
                        {
                            SendToAll("445");
                        }
                    }
                    

                    Array.Clear(buff, 0, buff.Length);


                }

            }
            catch (Exception excp)
            {
                RemoveClient(paramClient);
            }

        }

        private void RemoveClient(TcpClient paramClient)
        {
            if (mClients.Contains(paramClient))
            {
                mClients.Remove(paramClient);
            }
        }

        public async void SendToAll(string leMessage)
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }

            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(leMessage);

                foreach (TcpClient c in mClients)
                {
                    await c.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }

        }
        public async void SendToSecond(string leMessage)
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }

            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(leMessage);

                TcpClient b = mClients[1];
                await b.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }

        }
        public async void SendToFirst(string leMessage)
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }

            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(leMessage);

                TcpClient a = mClients[0];
                await a.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);

            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }

        }
    }
}
