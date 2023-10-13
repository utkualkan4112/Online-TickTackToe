using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TikTakToServer
{
    public partial class Form1 : Form
    {
        // When client disconnects no problem with server
        Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> ClientSockets = new List<Socket>();

        List<string> Sides = new List<string> { "X", "O" }; //Set a array of sides

        String[,] GameBoard = new String[3, 3]; //Matrix to keep current game

        string[] winner_table = new string[20]; // keeps track of winners
        int winer_table_size = 0;


        bool bTerminating = false;
        bool bListening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            for (int i = 0; i < 3; i++) //Makes the current board initialy empty
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i, j] = "";
                }
            }
            InitializeComponent();
        }
        string xname;
        string oname;
        bool bJoin;
        private void Accept()  //Accepting requested Sockets
        {
            while (bListening)
            {
                try
                {


                    Socket newClient = ServerSocket.Accept(); // if there is a player wants to join accapt it than add it in ClientSockets list
                    ClientSockets.Add(newClient);

                   
                    Thread receiveThread = new Thread(() => WaitJoin(newClient)); // Create new thread with this player
                    receiveThread.Start();
                    bJoin = true;
                        
                }
                catch
                {
                    if (bTerminating)
                    {
                        bListening = false;
                    }
                    else
                    {
                        log.AppendText("The socket stop working.\n\n");
                    }

                }
            }
        }
        private void WaitJoin(Socket thisClient) // this function connects the player and wait for Join message from player
        {
            while (bJoin)
            {
                Byte[] buffer = new Byte[64];
                thisClient.Receive(buffer);

                string incomingMessage = Encoding.Default.GetString(buffer);
                incomingMessage.Trim('\0');
                string[] token = incomingMessage.Split('-');
                if (token[0] == "Join")
                {
                    Thread receiveThread = new Thread(() => Join()); // Create new thread on this player to Join function
                    receiveThread.Start();
                    bJoin = false;
                }
                
            }
            
        }

        private void Join() // This function will wait for 2 player to join then it will asign the signs from sides list
        {

                string Message;
                Sides.Remove(Sides[Sides.Count - 1]);               
                if (Sides.Count == 0) // When there is 2 Player
                {
                    
                    int count = 0;
                    foreach(Socket client in ClientSockets) // For each socket
                    {
                        if (count == 0) // first assign X
                        {
                            Byte[] buffer = new Byte[64];
                            client.Receive(buffer);
                            string name = Encoding.Default.GetString(buffer);                     
                            string[] token = name.Split('-');

                            xname = token[0]; // Take name from X player socket
                            log.AppendText("Player " + xname + " has joined the game as X\n\n");

                            Message = "init-X-";
                            string Message2 = "X-"; // X always starts first
                            buffer = Encoding.Default.GetBytes(Message);
                            Byte[] buffer2 = Encoding.Default.GetBytes(Message2);
                            try
                            {
                                client.Send(buffer);
                                client.Send(buffer2);
                                bConnectedX = true;
                                
                                Thread receiveThread = new Thread(() => ReceiveX(client)); // X side has its own thead and function
                                receiveThread.Start();
                            }
                            catch
                            {
                                log.AppendText("There is a problem! Please check the connection...\n\n");
                                bTerminating = true;
                                ServerSocket.Close();
                            }
                        }
                        else // Then assign O
                        {
                            Byte[] buffer = new Byte[64];
                            client.Receive(buffer);
                            string name = Encoding.Default.GetString(buffer);
                            string[] token = name.Split('-');

                            oname = token[0];  // Take name from O player socket
                            log.AppendText("Player " + oname + " has joined the game as O\n\n");

                            Message = "init-O-";
                            buffer = Encoding.Default.GetBytes(Message);
                            try
                            {
                                client.Send(buffer);
                                Thread receiveThread = new Thread(() => ReceiveO(client)); // O side has its own thead and function
                                receiveThread.Start();
                            }
                            catch
                            {
                                log.AppendText("There is a problem! Please check the connection...\n\n");
                                bTerminating = true;
                                ServerSocket.Close();
                            }
                        }
                        count++;
                    }
                }
            else
            {
                bJoin = true;
            }
                
            
        }

        bool bConnectedX = false;
        bool bConnectedO = false;
        private void ReceiveX(Socket thisClient) // Function that will activate when X's turn
        {
            while (!bTerminating)
            {
                try
                {
                    while (bConnectedX)
                    {
                        bConnectedO = false;
                        log.AppendText("X's turn\n");
                        Byte[] buffer = new Byte[64];
                        thisClient.Receive(buffer);

                        string incomingMessage = Encoding.Default.GetString(buffer);
                        incomingMessage.Trim('\0');
                        log.AppendText(xname + ": " + incomingMessage + "\n\n"); // Log the name and incoming massage from X player
                        log.AppendText("\n");
                        if (incomingMessage[0] == '1') // This if else if lines checks if the player sends wich location to put X
                        {
                            GameBoard[0, 0] = "X";
                            box1.Text = "X";
                            if(!Check_Win() && !Check_Draw()) // At every input check if the resulting table is win or draw
                            {
                                bConnectedO = true; // if not enable RecieveX for next turn
                            }
                            
                        }
                        else if (incomingMessage[0] == '2')
                        {
                            GameBoard[0, 1] = "X";
                            box2.Text = "X";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedO = true;
                            }
                        }
                        else if (incomingMessage[0] == '3')
                        {
                            GameBoard[0, 2] = "X";
                            box3.Text = "X";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedO = true;
                            }
                        }
                        else if (incomingMessage[0] == '4')
                        {
                            GameBoard[1, 0] = "X";
                            box4.Text = "X";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedO = true;
                            }
                        }
                        else if (incomingMessage[0] == '5')
                        {
                            GameBoard[1, 1] = "X";
                            box5.Text = "X";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedO = true;
                            }
                        }
                        else if (incomingMessage[0] == '6')
                        {
                            GameBoard[1, 2] = "X";
                            box6.Text = "X";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedO = true;
                            }
                        }
                        else if (incomingMessage[0] == '7')
                        {
                            GameBoard[2, 0] = "X";
                            box7.Text = "X";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedO = true;
                            }
                        }
                        else if (incomingMessage[0] == '8')
                        {
                            GameBoard[2, 1] = "X";
                            box8.Text = "X";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedO = true;
                            }
                        }
                        else if (incomingMessage[0] == '9')
                        {
                            GameBoard[2, 2] = "X";
                            box9.Text = "X";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedO = true;
                            }
                        }
                        if (Check_Win()) // Checks if the current game board lead to win
                        {
                            
                           
                            string Converted_Message = "UPDATE-"; // Update both board on X and O
                            Converted_Message += Convert_GameBoard() + "-";

                            Byte[] result = Encoding.Default.GetBytes(Converted_Message);

                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(result);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with players \n\n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }
                            winner_table[winer_table_size] = "X"; // Adds the current winner to winner_table
                            winer_table_size++; // Keeps track of winner_table size
                            
                            log.AppendText(xname + " wich side is X has won the game\n\n"); // Since we got win condition after X move then winner is X
                            string Win_Message = "X Win-"; // Send winner message to both players
                            Byte[] bufferwin = Encoding.Default.GetBytes(Win_Message);
                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(bufferwin);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with both players\n\n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }
                            bConnectedO = false;
                            bConnectedX= false;
                            foreach (Socket client in ClientSockets)
                            {
                                Thread receiveThread = new Thread(() => Refresh_The_Game(client)); // Create a thread wich waits for players to request re-match or not
                                receiveThread.Start();
                            }
                            
                        }
                        else if (Check_Draw()) // if current game lead to draw
                        {
                            string Converted_Message = "UPDATE-"; // Update both players board
                            Converted_Message += Convert_GameBoard() + "-";

                            Byte[] result = Encoding.Default.GetBytes(Converted_Message);

                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(result);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with players \n\n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }

                            winner_table[winer_table_size] = "-"; // Adds the draw sign
                            winer_table_size++; // keep track of winner table size

                            string Win_Message = "Draw-"; // Send draw message to both boards
                            log.AppendText("Game Draw\n\n");
                            Byte[] bufferwin = Encoding.Default.GetBytes(Win_Message);
                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(bufferwin);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with both players\n\n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }
                            bConnectedO = false;
                            bConnectedX = false;
                            foreach (Socket client in ClientSockets) 
                            {
                                Thread receiveThread = new Thread(() => Refresh_The_Game(client)); // Create a thread wich waits for players to request re-match or not
                                receiveThread.Start();
                            }

                        }
                        else
                        {
                            string Converted_Message = "UPDATE-"; // if game is not finished
                            Converted_Message += Convert_GameBoard() + "-"; // Convert the matrix of gameboard to message that will be number 1 to 9 exept the allocated numbers change with a sign which alocated it before

                            Byte[] result = Encoding.Default.GetBytes(Converted_Message);

                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(result);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with players \n\n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }


                            string Message = "O-"; // next turn is O send O message to O's socket
                            Byte[] bufferO = Encoding.Default.GetBytes(Message);


                            foreach (Socket client in ClientSockets)
                            {
                                if (client != thisClient)
                                {
                                    try
                                    {
                                        client.Send(bufferO);
                                    }
                                    catch
                                    {
                                        log.AppendText("Cant comminicate with player O\n\n");
                                        bTerminating = true;
                                        ServerSocket.Close();
                                    }

                                }
                            }

                        }

                    }
                    
                    


                }
                catch
                {
                    if (!bTerminating)
                    {
                        log.AppendText("X player has disconnected. Game Stoped\n\n");
                    }
                    thisClient.Close();
                    ClientSockets.Remove(thisClient);
                    bConnectedX = false;
                    

                }
            }
        }

        private void ReceiveO(Socket thisClient) // Function that will activate when O's turn
        {
            while (!bTerminating)
            {
                try
                {
                    while (bConnectedO)
                    {
                        bConnectedX = false;
                        log.AppendText("O's turn\n\n");
                        Byte[] buffer = new Byte[64];
                        thisClient.Receive(buffer);

                        string incomingMessage = Encoding.Default.GetString(buffer);
                        incomingMessage.Trim('\0');
                        log.AppendText(oname +": " + incomingMessage + "\n\n"); // Log the name and incoming massage from O player
                        log.AppendText("\n");
                        if (incomingMessage[0] == '1') // This if else if lines checks if the player sends wich location to put O
                        {
                            GameBoard[0, 0] = "O";
                            box1.Text = "O";
                            if (!Check_Win() && !Check_Draw()) // At every input check if the resulting table is win or draw
                            {
                                bConnectedX = true; // if not enable RecieveX for next turn
                            }
                        }
                        else if (incomingMessage[0] == '2')
                        {
                            GameBoard[0, 1] = "O";
                            box2.Text = "O";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedX = true;
                            }
                        }
                        else if (incomingMessage[0] == '3')
                        {
                            GameBoard[0, 2] = "O";
                            box3.Text = "O";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedX = true;
                            }
                        }
                        else if (incomingMessage[0] == '4')
                        {
                            GameBoard[1, 0] = "O";
                            box4.Text = "O";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedX = true;
                            }
                        }
                        else if (incomingMessage[0] == '5')
                        {
                            GameBoard[1, 1] = "O";
                            box5.Text = "O";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedX = true;
                            }
                        }
                        else if (incomingMessage[0] == '6')
                        {
                            GameBoard[1, 2] = "O";
                            box6.Text = "O";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedX = true;
                            }
                        }
                        else if (incomingMessage[0] == '7')
                        {
                            GameBoard[2, 0] = "O";
                            box7.Text = "O";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedX = true;
                            }
                        }
                        else if (incomingMessage[0] == '8')
                        {
                            GameBoard[2, 1] = "O";
                            box8.Text = "O";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedX = true;
                            }
                        }
                        else if (incomingMessage[0] == '9')
                        {
                            GameBoard[2, 2] = "O";
                            box9.Text = "O";
                            if (!Check_Win() && !Check_Draw())
                            {
                                bConnectedX = true;
                            }
                        }
                        if (Check_Win()) // Checks if the current game board lead to win
                        {
                            string Converted_Message = "UPDATE-"; // Update both board on X and O
                            Converted_Message += Convert_GameBoard() + "-";

                            Byte[] result = Encoding.Default.GetBytes(Converted_Message);

                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(result);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with players \n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }
                            winner_table[winer_table_size] = "O"; // Adds the current winner to the winer list
                            winer_table_size++; // keep track of winner table size
                            string Win_Message = "O Win-"; // Since we got win condition after X move then winner is O
                            log.AppendText(oname + " wich side is O has won the game\n\n"); // Send winner message to both players
                            Byte[] bufferwin = Encoding.Default.GetBytes(Win_Message);
                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(bufferwin);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with both players\n\n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }
                            bConnectedO = false;
                            bConnectedX = false;

                            foreach (Socket client in ClientSockets) // Create a thread wich waits for players to request re-match or not
                            {
                                Thread receiveThread = new Thread(() => Refresh_The_Game(client)); // X side has its own thead and function
                                receiveThread.Start();
                            }


                        }
                        else if (Check_Draw()) // if current game lead to draw
                        {
                            string Converted_Message = "UPDATE-"; // Update both players board
                            Converted_Message += Convert_GameBoard() + "-";

                            Byte[] result = Encoding.Default.GetBytes(Converted_Message);

                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(result);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with players \n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }
                            winner_table[winer_table_size] = "-"; // Adds the draw sign
                            winer_table_size++; // keep track of winner table size
                            string Win_Message = "Draw-"; // Send draw message to both boards
                            log.AppendText("Game Draw");
                            Byte[] bufferwin = Encoding.Default.GetBytes(Win_Message);
                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(bufferwin);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with both players\n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }
                            bConnectedO = false;
                            bConnectedX = false;
                            foreach (Socket client in ClientSockets) // Create a thread wich waits for players to request re-match or not
                            {
                                Thread receiveThread = new Thread(() => Refresh_The_Game(client)); // X side has its own thead and function
                                receiveThread.Start();
                            }

                        }
                        else // if game is not finished
                        {
                            string Converted_Message = "UPDATE-";  // Convert the matrix of gameboard to message that will be number 1 to 9 exept the allocated numbers change with a sign which alocated it before
                            Converted_Message += Convert_GameBoard() + "-";

                            Byte[] result = Encoding.Default.GetBytes(Converted_Message);

                            foreach (Socket client in ClientSockets)
                            {
                                try
                                {
                                    client.Send(result);
                                }
                                catch
                                {
                                    log.AppendText("Cant comminicate with players \n");
                                    bTerminating = true;
                                    ServerSocket.Close();
                                }
                            }

                            string Message = "X-"; // next turn is X send X message to X's socket
                            Byte[] bufferX = Encoding.Default.GetBytes(Message);
                            foreach (Socket client in ClientSockets)
                            {
                                if (client != thisClient)
                                {
                                    try
                                    {
                                        client.Send(bufferX);
                                    }
                                    catch
                                    {
                                        log.AppendText("Cant comminicate with player X\n");
                                        bTerminating = true;
                                        ServerSocket.Close();
                                    }
                                }
                            }


                        }
                        
                    }                               

                }
                catch
                {
                    if (!bTerminating)
                    {
                        log.AppendText("O player has disconnected. Game Stoped\n");
                    }
                    thisClient.Close();
                    ClientSockets.Remove(thisClient);
                    bConnectedO = false;
                    

                }
            }
        }
        bool bXRefresh = false;
        bool bORefresh = false;


        private void Refresh_The_Game(Socket thisClient)
        {
            Byte[] buffer = new Byte[64];
            thisClient.Receive(buffer);
            string name = Encoding.Default.GetString(buffer);
            string[] token = name.Split('-');
            // Recieve the Refresh message from both player.
            if (token[0] == "X" && token[1] == "Refresh") 
            {
                bXRefresh= true; // Each request makes the boolean control variable true
                log.AppendText(xname + " Has requested re-match\n\n");
            }
            else if (token[0] == "O" && token[1] == "Refresh") {
                bORefresh= true; // Each request makes the boolean control variable true
                log.AppendText(oname + " Has requested re-match\n\n");
            }
            if (bXRefresh && bORefresh) // Check if both players requested re-match
            {
                log.AppendText("Game Refreshing\n\n");
                bXRefresh = false;
                bORefresh = false;
                //Makes the current board initialy empty
                for (int i = 0; i < 3; i++) 
                {
                    for (int j = 0; j < 3; j++)
                    {
                        GameBoard[i, j] = "";
                    }
                }
                box1.Text = "";
                box2.Text = "";
                box3.Text = "";
                box4.Text = "";
                box5.Text = "";
                box6.Text = "";
                box7.Text = "";
                box8.Text = "";
                box9.Text = "";


                string refresh_Message = "Refresh-"; // Send Refresh message to players
                Byte[] refresh = Encoding.Default.GetBytes(refresh_Message);
                foreach (Socket client in ClientSockets)
                {
                    try
                    {
                        client.Send(refresh);
                    }
                    catch
                    {
                        log.AppendText("Cant comminicate with players \n");
                        bTerminating = true;
                        ServerSocket.Close();
                    }
                }
              
                if (winner_table[winer_table_size - 1] == "X") // Check last winner and start the game with the winner
                {
                    log.AppendText("Last time " + xname + " has won its starting\n\n");
                    bConnectedX= true;
                    string Message = "X-"; // next turn is X send X message to X's socket
                    Byte[] bufferO = Encoding.Default.GetBytes(Message);


                    foreach (Socket client in ClientSockets)
                    {
                        
                            try
                            {
                                client.Send(bufferO);
                            }
                            catch
                            {
                                log.AppendText("Cant comminicate with player X\n\n");
                                bTerminating = true;
                                ServerSocket.Close();
                            }

                        
                    }
                }
                else
                {
                    log.AppendText("Last time " + oname + " has won its starting\n\n");
                    bConnectedO = true;
                    string Message = "O-"; // next turn is O send O message to O's socket
                    Byte[] bufferO = Encoding.Default.GetBytes(Message);


                    foreach (Socket client in ClientSockets)
                    {
                        
                            try
                            {
                                client.Send(bufferO);
                            }
                            catch
                            {
                                log.AppendText("Cant comminicate with player O\n\n");
                                bTerminating = true;
                                ServerSocket.Close();
                            }

                        
                    }
                }

            }
        }

       
        private string Convert_GameBoard() // Converts the gameboard matrix to numbered string starting at 1 to 9 
        {
            string Converted_String = ""; 
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard[i, j] == "X") // if the matrix marked with X or O in string it should be X or O to
                    {
                        Converted_String += "X";
                    }
                    else if (GameBoard[i, j] == "O")
                    {
                        Converted_String += "O";
                    }
                    else
                    {
                        Converted_String += count.ToString();
                    }
                    count++;
                }
            }
            return Converted_String;
        }

        private void BtnLst_Click_1(object sender, EventArgs e) // When cliced the listen button if port number is correct it will start listining that port
        {
            int PortNumber;
            if (Int32.TryParse(TxtPrt.Text, out PortNumber))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PortNumber); // İnterface
                // bind to endpoint
                ServerSocket.Bind(endPoint);
                ServerSocket.Listen(3); // # of element in queue. not importent number. not really large.

                bListening = true;
                BtnLst.Enabled = false;

                Thread AcceptThread = new Thread(Accept); // We create new thread for Accept function
                AcceptThread.Start();

                log.AppendText("Start listining on port: " + PortNumber + "\n");
            }
            else
            {
                log.AppendText("Please check port number\n");
            }
        }

        private bool Check_Win() //Checks if current game win
        {
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[i, 0] != "" && GameBoard[i, 0] == GameBoard[i, 1] && GameBoard[i, 0] == GameBoard[i, 2])
                {
                    return true;
                }

                if (GameBoard[0, i] != "" && GameBoard[0, i] == GameBoard[1, i] && GameBoard[0, i] == GameBoard[2, i])
                {
                    return true;
                }
            }

            // Check diagonals
            if (GameBoard[0, 0] != "" && GameBoard[0, 0] == GameBoard[1, 1] && GameBoard[0, 0] == GameBoard[2, 2])
            {
                return true;
            }

            if (GameBoard[0, 2] != "" && GameBoard[0, 2] == GameBoard[1, 1] && GameBoard[0, 2] == GameBoard[2, 0])
            {
                return true;
            }
            return false;

        }

        private bool Check_Draw() //Checks if current game Draw
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard[i, j] == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e) // When press close on window it will deattach sockets
        {
            bListening = false;
            bTerminating = true;
            Environment.Exit(0);
        }
    }
}
