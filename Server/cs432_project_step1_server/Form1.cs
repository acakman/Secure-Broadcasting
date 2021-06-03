using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Security.Cryptography;

namespace cs432_project_step1_server
{
    public partial class Form1 : Form
    {
        private static Thread socketListener;
        private static Socket listeningSocket;
        private static IPEndPoint localEndPoint;
        private static List<Client> clients = new List<Client>();
        private static bool stopServer = false;
        private static string encPrivateKey;
        private static string encSignKey;
        private static string password;
        private static string decPrivateKey;
        private static string decSignKey;
        private static Dictionary<string, string> users;
        private readonly object clientsLock = new object();
        public Form1()
        {
            InitializeComponent();
            consoleText.ReadOnly = true;
            shutdownServerButton.Enabled = false;
            runServerButton.Enabled = false;
            using (System.IO.StreamReader fileReader =
                            new System.IO.StreamReader(@"C:\Users\Ahmet\source\repos\CS432 Project\cs432_project_step1_server\cs432_project_step1_server\encrypted_server_enc_dec_pub_prv.txt"))
            {
                encPrivateKey = Encoding.Default.GetString(hexStringToByteArray(fileReader.ReadLine()));
            }
            using (System.IO.StreamReader fileReader =
                            new System.IO.StreamReader(@"C:\Users\Ahmet\source\repos\CS432 Project\cs432_project_step1_server\cs432_project_step1_server\encrypted_server_signing_verification_pub_prv.txt"))
            {
                encSignKey = Encoding.Default.GetString(hexStringToByteArray(fileReader.ReadLine()));
            }
            consoleText.Text += "Please enter the password:\n";
        }

        private void runServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Int32.Parse(portBox.Text);
                runServer(port);
                socketListener = new Thread(startListening);
                socketListener.Start();
                runServerButton.Enabled = false;
                shutdownServerButton.Enabled = true;
                portBox.Enabled = false;
            }
            catch
            {
                consoleText.Text += "Please enter a valid port number." + "\n" ;
            }
        }
        public void runServer(int port)
        {
            try
            {
                
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                localEndPoint = new IPEndPoint(IPAddress.Any, port);
                consoleText.Text += "Server is running." + "\n"; 
            }
            catch (Exception ex)
            {
                consoleText.Text += ex.ToString() +"\n"; 
            }
        }

        public void startListening()
        {
            try
            {
                listeningSocket.Bind(localEndPoint);
                listeningSocket.Listen(10);
                Invoke(new Action(() => { consoleText.Text += "Server is listening to incoming requests." + "\n"; }));
                while (true)
                {

                    Socket newClientSocket = listeningSocket.Accept();
                    Client newClient = new Client("", newClientSocket);
                    Thread newCLientListenThread = new Thread(() => clientListener(newClient));
                    newCLientListenThread.Start();
                    //simdilik deneme icin
                    Invoke(new Action(() => { consoleText.Text += "CLIENT CONNECTED" + "\n"; }));
                }
                
                
            }
            catch (Exception e)
            {
                Invoke(new Action(() => { consoleText.Text += "Server encountered an error. " +e.ToString() + "\n"; }));
            }
        }
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void portBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void shutdownServerButton_Click(object sender, EventArgs e)
        {
           

           foreach (Client client in clients)
           {
               client.socket.Close();
           }
           runServerButton.Enabled = true;
           shutdownServerButton.Enabled = false;
           portBox.Enabled = true;
           Invoke(new Action(() => { consoleText.Text += "Server stopped listening." + "\n"; }));
        }
        public void clientListener(Client client)
        {
            string clientUsername = "";
            bool kickClient = false;
            while (!stopServer && !kickClient)
            {
                try
                {
                    string message = client.receiveMessage();
                    consoleText.Text += $"Client sent:\n {message}\n";
                    if (message == "DISCONNECT")
                    { 

                    }
                    else if (message.Substring(0, 4) == "Auth")
                    {
                        byte[] randBytes = new byte[16];
                        byte[] RSASign;
                        using (var rng = new RNGCryptoServiceProvider())
                        {
                            rng.GetBytes(randBytes);
                        }
                        string randNum = generateHexStringFromByteArray(randBytes);
                        client.sendMessage(randNum);
                        randomNumberText.Text = randNum;
                        consoleText.Text += $"Server sent:\n {randNum}\n";
                        //consoleText.Text = message + "\n";
                        string clientHMAC = client.receiveMessage();
                        hmacValueText.Text = clientHMAC;
                        consoleText.Text += $"Client sent:\n {clientHMAC}\n";
                        //Invoke(new Action(() => { consoleText.Text += clientHMAC + "\n"; }));
                        //Invoke(new Action(() => { consoleText.Text = decSignKey + "\n"; }));
                        //randBytes burada dummy, oraya clientın gerçek şifresinin hashinin üst 16 byteının gelmesi lazım.
                        string pwUpperHash = "";
                        lock (clientsLock) {
                             pwUpperHash = client.password;
                                }
                        if (clientHMAC == generateHexStringFromByteArray(applyHMACwithSHA256(randNum, hexStringToByteArray(pwUpperHash))))
                        {
                            client.sendMessage("yes");
                            consoleText.Text += "Server sent:\n'yes'\n";
                            RSASign = signWithRSA("yes", 3072, decSignKey);
                            client.sendMessage(generateHexStringFromByteArray(RSASign));
                            consoleText.Text += $"Server sent:\n{generateHexStringFromByteArray(RSASign)}\n";
                        }
                        else {
                            client.sendMessage("no");
                            consoleText.Text += "Server sent:\n'no'\n";
                            kickClient = true;
                            RSASign = signWithRSA("no", 3072, decSignKey);
                            client.sendMessage(generateHexStringFromByteArray(RSASign));
                            consoleText.Text += $"Server sent:\n{generateHexStringFromByteArray(RSASign)}";
                            //clients.Remove(client);


                        }
                        loginSignText.Text = generateHexStringFromByteArray(RSASign);
                    }
                    else if (message == "Enroll")
                    {
                        message = client.receiveMessage();
                        string messageXML = Encoding.Default.GetString(hexStringToByteArray(message));
                        consoleText.Text += $"Client sent:\n {message}\n";
                        byte[] decryptedMsgByte = decryptWithRSA(messageXML, 3072, decPrivateKey);
                        byte[] enrollmentSignature;
                        string enrollmentResponse;
                        string decryptedMsg = Encoding.Default.GetString(decryptedMsgByte);
                        string username = decryptedMsg.Substring(32, decryptedMsg.Length - 32);
                        string password = decryptedMsg.Substring(0, 32);
                        bool checkUsername = true;
                        lock (clientsLock) {
                            foreach (Client cli in clients)
                            {
                                if (username == cli.name && checkUsername)
                                {
                                    client.sendMessage($"Username {username} user exists.");
                                    consoleText.Text += $"Server sent:\n Username {username} user exists.";
                                    checkUsername = false;
                                }
                            }
                            if (checkUsername)
                            {
                                client.name = username;
                                client.password = password;
                                enrollmentResponse = "success";
                                clients.Add(client);
                            }
                            else
                                enrollmentResponse = "error";
                            enrollmentSignature = signWithRSA(enrollmentResponse, 3072, decSignKey);
                            enrollSignatureText.Text = generateHexStringFromByteArray(enrollmentSignature);
                            client.sendMessage(generateHexStringFromByteArray(enrollmentSignature));
                            consoleText.Text += $"Server sent:\n {generateHexStringFromByteArray(enrollmentSignature)}\n";
                            client.sendMessage(enrollmentResponse);
                            consoleText.Text += $"Server sent:\n {enrollmentResponse}\n";
                        }
                    
                    }
                    else{
                        Console.WriteLine("Entered else :)");
                    }
                }

                catch (SocketException ex)
                {

                    Console.WriteLine("SocketException:\n" + ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception:\n" + ex.ToString());
                }
            }
        }
        static byte[] applyHMACwithSHA256(string input, byte[] key)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);
            // create HMAC applier object from System.Security.Cryptography
            HMACSHA256 hmacSHA256 = new HMACSHA256(key);
            // get the result of HMAC operation
            byte[] result = hmacSHA256.ComputeHash(byteInput);

            return result;
        }
        static byte[] decryptWithRSA(string input, int algoLength, string xmlStringKey)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);
            // create RSA object from System.Security.Cryptography
            RSACryptoServiceProvider rsaObject = new RSACryptoServiceProvider(algoLength);
            // set RSA object with xml string
            rsaObject.FromXmlString(xmlStringKey);
            byte[] result = null;

            try
            {
                result = rsaObject.Decrypt(byteInput, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return result;
        }

        static byte[] decryptWithAES128(string input, byte[] key, byte[] IV)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);
            // create AES object from System.Security.Cryptography
            RijndaelManaged aesObject = new RijndaelManaged();
            // since we want to use AES-128
            aesObject.KeySize = 128;
            // block size of AES is 128 bits
            aesObject.BlockSize = 128;
            // mode -> CipherMode.*
            aesObject.Mode = CipherMode.CFB;
            // feedback size should be equal to block size
            // aesObject.FeedbackSize = 128;
            // set the key
            aesObject.Key = key;
            // set the IV
            aesObject.IV = IV;

            // create an encryptor with the settings provided
            ICryptoTransform decryptor = aesObject.CreateDecryptor();
            byte[] result = null;

            try
            {
                result = decryptor.TransformFinalBlock(byteInput, 0, byteInput.Length);
            }
            catch (Exception e) // if encryption fails
            {
                Console.WriteLine(e.Message); // display the cause
            }

            return result;
        }

        public class Client
        {
            public string name;
            public string password;
            public Socket socket;
            public bool connected;

            public Client(string name, Socket socket)
            {
                this.name = name;
                this.socket = socket;
            }

            public bool isActive()
            {

                try
                {
                    try
                    {
                        return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
                    }
                    catch (SocketException) { return false; }
                }
                catch (SocketException) { return false; }
            }

            public void sendMessage(string message)
            {
                int messageLength = message.Length;
                byte[] intBytes = BitConverter.GetBytes(messageLength);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(intBytes);
                byte[] result = intBytes;

                // First send of the length of the message in 4 bytes
                int bytesSent = this.socket.Send(result);
                byte[] msg = Encoding.ASCII.GetBytes(message);
                //then send the message itself
                this.socket.Send(msg);
            }
            public string receiveMessage()
            {
                byte[] messageLengthByte = new byte[4];
                this.socket.Receive(messageLengthByte);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(messageLengthByte);
                int messageLengthInt = BitConverter.ToInt32(messageLengthByte, 0);

                byte[] messageByte = new byte[messageLengthInt];
                int k = this.socket.Receive(messageByte);
                string message = Encoding.ASCII.GetString(messageByte, 0, k);
                return message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static string generateHexStringFromByteArray(byte[] input)
        {
            string hexString = BitConverter.ToString(input);
            return hexString.Replace("-", "");
        }

        public static byte[] hexStringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        static byte[] hashWithSHA256(string input)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);
            // create a hasher object from System.Security.Cryptography
            SHA256CryptoServiceProvider sha256Hasher = new SHA256CryptoServiceProvider();
            // hash and save the resulting byte array
            byte[] result = sha256Hasher.ComputeHash(byteInput);

            return result;
        }



        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                password = inputText.Text;
                byte[] passwordHash = hashWithSHA256(password);
                inputText.Text = "";
                byte[] passwordKey = new byte[16];
                inputText.ReadOnly = true;
                submitButton.Enabled = false;
                byte[] pwIV = new byte[16];
                Array.Copy(passwordHash, 0, pwIV, 0, 16);
                Array.Copy(passwordHash, 16, passwordKey, 0, 16);
                aesIVText.Text = generateHexStringFromByteArray(pwIV);
                consoleText.Text += $"AES IV is:\n{generateHexStringFromByteArray(pwIV)}\n";
                consoleText.Text += $"AES key is:\n{generateHexStringFromByteArray(passwordKey)}\n";
                aesKeyText.Text = generateHexStringFromByteArray(passwordKey);
                byte[] decryptedPrivateKey = decryptWithAES128(encPrivateKey, passwordKey, pwIV);
                decPrivateKey= System.Text.UTF8Encoding.UTF8.GetString(decryptedPrivateKey);
                consoleText.Text += $"Public/private key pair is:\n{generateHexStringFromByteArray(decryptedPrivateKey)}\n";
                byte[] decryptedSignKey = decryptWithAES128(encSignKey, passwordKey, pwIV);
                decSignKey = System.Text.UTF8Encoding.UTF8.GetString(decryptedSignKey);
                consoleText.Text += $"Public/private key pair for signature is:\n{generateHexStringFromByteArray(decryptedSignKey)}\n";
                runServerButton.Enabled = true;
                consoleText.Text += "Keys have been decrypted successfully.\n";
                rsaSignKeyText.Text = generateHexStringFromByteArray(decryptedSignKey);
                rsaKeyText.Text = generateHexStringFromByteArray(decryptedPrivateKey);
            }
            catch(Exception ex)
            {
                inputText.ReadOnly = false;
                submitButton.Enabled = true;
                runServerButton.Enabled = false;
                consoleText.Text += ex.ToString() + "\nPlease enter the password again.\n";
            }
            }
        static byte[] signWithRSA(string input, int algoLength, string xmlString)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);
            // create RSA object from System.Security.Cryptography
            RSACryptoServiceProvider rsaObject = new RSACryptoServiceProvider(algoLength);
            // set RSA object with xml string
            rsaObject.FromXmlString(xmlString);
            byte[] result = null;

            try
            {
                result = rsaObject.SignData(byteInput, "SHA256");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
        private void inputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
