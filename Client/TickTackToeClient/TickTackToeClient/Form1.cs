using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace TickTackToeClient
{
    public partial class Form1 : Form
    {
        bool bTerminating = false;
        bool bConnected = false;
        Socket clientSocket;
        String[,] GameBoard = new String[3, 3]; //To keep gameboard as variable

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false; 
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            for (int i = 0; i < 3; i++)  //this loop makes the gameboard initialy empty
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i, j] = "";
                }
            }
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, EventArgs e) // Connect button to conncet to server
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = TxtIP.Text;
            int portNum;
            if (Int32.TryParse(TxtPort.Text, out portNum)) // Checks port is correct or not
            {
                try
                {
                    clientSocket.Connect(IP, portNum); // tries to conncet if not thow exeption
                    button1.Enabled = true;

                    BtnConnect.Enabled = false;
                    bConnected = true;
                    log.AppendText("Connected to the server\n");

                    Thread recieveThread = new Thread(Recieve); //Start Reciveve function to recieve message from server
                    recieveThread.Start();
                }
                catch
                {
                    log.AppendText("Couldn't connecte to the server\n");
                }
            }
            else
            {
                log.AppendText("Check the port\n");
            }
        }
        string side;
        string updatedGameBoard;
        private void Recieve() // Revieves message from server
        {
            while (bConnected)
            {
                try
                {
                    Byte[] buffer = new Byte[64]; 
                    clientSocket.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    string[] tokens = incomingMessage.Split('-');
                    
                    if (side == tokens[0]) { // if message only inculde side information and if its equal to player sign
                        log.AppendText("Its your turn\n\n");
                        Enable_NonFilled_Cells(); // Enable avaible cell to be choose
                    }
                    else if (tokens[0] == "init") // This message will send from server iff start of the the game. 
                    {
                        side = tokens[1]; // Asign the side in the message
                        log.AppendText("Your side is " + side + "\n\n");
                    }
                    else if (tokens[0] == "UPDATE") // if this message come from server than update the current board
                    {
                        updatedGameBoard = tokens[1];
                        Update_GameBoard(updatedGameBoard); // takes encoded message and decode to our implementation matrix
                        Update_Boxes(); // update representation of board in window
                        Disable_All_Cells(); // Disable all cell after every update
                    }
                    else if (tokens[0] == "O Win") // O Win message
                    {
                        if (side == "O") // if player side is O then that means it win
                        {
                            log.AppendText("You Win\n\n");
                        }
                        else
                        {
                            log.AppendText("O Win\n\n");
                        }
                        btnRefresh.Enabled = true;
                    } 
                    else if (tokens[0] == "X Win") // X Win message
                    {
                        if(side == "X") // if player side is X then that means it win
                        {
                            log.AppendText("You Win\n\n");
                        }
                        else
                        {
                            log.AppendText("X Win\n\n");
                        }
                        btnRefresh.Enabled = true;
                    }
                    else if (tokens[0] == "Draw") // Draw
                    {
                        log.AppendText("Draw\n\n");
                        btnRefresh.Enabled = true;
                    }
                    else if (tokens[0] == "Refresh") // if server message Refresh then clean the board
                    {
                        log.AppendText("Game is refreshing");
                        for (int i = 0; i < 3; i++)  //this loop makes the gameboard initialy empty
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                GameBoard[i, j] = "";
                            }
                        }
                        Update_Boxes(); // update representation of board in window
                        Disable_All_Cells(); // Disable all cell after every update
                        btnRefresh.Enabled = false;
                    }

                }
                catch
                {
                    if (!bTerminating)
                    {
                        log.AppendText("The server has disconnected.\n\n");
                        BtnConnect.Enabled = true;
                    }

                    clientSocket.Close();
                    bConnected = false;
                }


            }
        }

        private void Update_GameBoard(String Message) // this function takes the encoded gameboard and decode and asign it to player board
        {
            int row = 0;
            int column = 0;
            for(int i = 0; i < Message.Length; i++)
            {
                
                if (Message[i] == (char)(i+1))
                {
                    GameBoard[row, column] = "";
                }
                else if (Message[i] == 'X')
                {
                    GameBoard[row, column] = "X";
                }
                else if (Message[i] == 'O')
                {
                    GameBoard[row, column] = "O";
                }
                if(column == 2)
                {
                    column= 0;
                    row++;
                }
                else
                {
                    column++;
                }
            }
        }

        private void Update_Boxes() // Updates the representation of board in window
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (i == 0 && j == 0)
                    {
                        box1.Text = GameBoard[i, j];
                    }
                    else if (i == 0 && j == 1)
                    {
                        box2.Text = GameBoard[i, j];
                    }
                    else if (i == 0 && j == 2)
                    {
                        box3.Text = GameBoard[i, j];
                    }
                    if (i == 1 && j == 0)
                    {
                        box4.Text = GameBoard[i, j];
                    }
                    else if (i == 1 && j == 1)
                    {
                        box5.Text = GameBoard[i, j];
                    }
                    else if (i == 1 && j == 2)
                    {
                        box6.Text = GameBoard[i, j];
                    }
                    if (i == 2 && j == 0)
                    {
                        box7.Text = GameBoard[i, j];
                    }
                    else if (i == 2 && j == 1)
                    {
                        box8.Text = GameBoard[i, j];
                    }
                    else if (i == 2 && j == 2)
                    {
                        box9.Text = GameBoard[i, j];
                    }
                    

                }
            }
        }

        private void Enable_NonFilled_Cells() // This function enables all avaible cells in the gameboard
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(GameBoard[i, j] == "")
                    {
                        if( i == 0 && j == 0)
                        {
                            box1.Enabled = true;
                        }
                        else if(i == 0 && j == 1)
                        {
                            box2.Enabled = true;
                        }
                        else if(i == 0 && j == 2)
                        {
                            box3.Enabled = true;
                        }
                        if (i == 1 && j == 0)
                        {
                            box4.Enabled = true;
                        }
                        else if (i == 1 && j == 1)
                        {
                            box5.Enabled = true;
                        }
                        else if (i == 1 && j == 2)
                        {
                            box6.Enabled = true;
                        }
                        if (i == 2 && j == 0)
                        {
                            box7.Enabled = true;
                        }
                        else if (i == 2 && j == 1)
                        {
                            box8.Enabled= true;
                        }
                        else if (i == 2 && j == 2)
                        {
                            box9.Enabled = true;
                        }
                    }

                }
            }
        }

        private void Disable_All_Cells() // Disables all the cells in the gameboard
        {
            box1.Enabled = false;
            box2.Enabled = false; 
            box3.Enabled = false;
            box4.Enabled = false;
            box5.Enabled = false;
            box6.Enabled = false;
            box7.Enabled = false;
            box8.Enabled = false;
            box9.Enabled = false;

        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bConnected = false;
            bTerminating = true;
            Environment.Exit(0);
        }


        // Each button represent a cell in game board 1-9. When click any of them it will asign that symbol on the button and update the current gameboard
        // Also sends message to server number of choosen cell
        private void box1_Click(object sender, EventArgs e) 
        {
            string Message = "1";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected= false;
                bTerminating = true;
            }

        }

        private void box2_Click(object sender, EventArgs e)
        {
            string Message = "2";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }

        private void box3_Click(object sender, EventArgs e)
        {
            string Message = "3";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }

        private void box4_Click(object sender, EventArgs e)
        {
            string Message = "4";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }

        private void box5_Click(object sender, EventArgs e)
        {
            string Message = "5";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }

        private void box6_Click(object sender, EventArgs e)
        {
            string Message = "6";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }

        private void box7_Click(object sender, EventArgs e)
        {
            string Message = "7";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }

        private void box8_Click(object sender, EventArgs e)
        {
            string Message = "8";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }

        private void box9_Click(object sender, EventArgs e)
        {
            string Message = "9";
            Byte[] buffer = Encoding.Default.GetBytes(Message); 
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = namebox.Text + "-";
            string Message = "Join-";
            Byte[] buffer = Encoding.Default.GetBytes(Message);
            Byte[] buffer2 = Encoding.Default.GetBytes(name);
            try
            {
                clientSocket.Send(buffer);
                clientSocket.Send(buffer2);                   
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
            button1.Enabled= false;
        }

        private void btnRefresh_Click(object sender, EventArgs e) // Sends re-match request to server
        {
            string Message = side + "-Refresh-";
            Byte[] buffer = Encoding.Default.GetBytes(Message);
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                log.AppendText("Cannot send message to server");
                bConnected = false;
                bTerminating = true;
            }
        }
    }
}
