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
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Security.Cryptography;

namespace cs432_project_step1_client
{
    public partial class Form1 : Form
    {
        private static Socket socket;
        private static bool isListening = false;
        private static string pubkRSA;
        private static string pubkSign;
        public Form1()
        {
            InitializeComponent();
            dcButton.Enabled = false;
            using (System.IO.StreamReader fileReader =
            new System.IO.StreamReader(@"C:\Users\Ahmet\source\repos\CS432 Project\cs432_project_step1_client\cs432_project_step1_client\server_enc_dec_pub.txt"))
            {
                pubkRSA = fileReader.ReadLine();
                byte[] publicKeyBytes = Encoding.Default.GetBytes(pubkRSA);
                publicKeyRSA.Text = generateHexStringFromByteArray(publicKeyBytes);
                //publicKeyRSA.Text = Encoding.Default.GetString(publicKeyBytes);
                //publicKeyRSA.Text = Encoding.Default.GetString(hexStringToByteArray(pubkRSA));
            }

            using (System.IO.StreamReader fileReader =
            new System.IO.StreamReader(@"C:\Users\Ahmet\source\repos\CS432 Project\cs432_project_step1_client\cs432_project_step1_client\server_signing_verification_pub.txt"))
            {
                pubkSign = fileReader.ReadLine();
                byte[] publicKeySignBytes = Encoding.Default.GetBytes(pubkSign);
                publicKeySign.Text = generateHexStringFromByteArray(publicKeySignBytes);
                //publicKeySign.Text = Encoding.Default  Burayi halletmek gerekecek, formda gostermemiz lazim.
                // .GetString(hexStringToByteArray(pubkSign));
            }
        }
        public static byte[] hexStringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void sendMessage(string message)
        {
            int messageLength = message.Length;
            byte[] intBytes = BitConverter.GetBytes(messageLength);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;

            // First send of the length of the message in 4 bytes
            int bytesSent = socket.Send(result);
            byte[] encodedMessage = Encoding.ASCII.GetBytes(message);
            //then send the message itself
            socket.Send(encodedMessage);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string serverIP = ipBox.Text;
                int port = Int32.Parse(portBox.Text);
                
                IPAddress ipAddress = IPAddress.Parse(serverIP);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(serverIP, port);
                enrollButton.Enabled = false;
                dcButton.Enabled = true;
                isListening = true;
                // Hash the password using SHA-256
                byte[] enrollHash = hashWithSHA256(passwordBox.Text);
                string mostSignificantHash = getMostSignificantHash(enrollHash);
                int lengthofhash = mostSignificantHash.Length;
                string enrollMessage = mostSignificantHash + nameBox.Text;
                byte[] enrollRSA = encryptWithRSA(enrollMessage, 3072, pubkRSA);
                string enrollRSAstring = generateHexStringFromByteArray(enrollRSA);// Send the data through the socket.  
                sendMessage("Enroll");
                consoleBox.Text = $"Client sent:\n 'Enroll'\n";
                sendMessage(enrollRSAstring);
                string enrollmentSignature = receiveMessage();
                enrollSignText.Text = enrollmentSignature;
                consoleBox.Text = $"Server sent:\n {enrollmentSignature}\n";
                byte[] enrollmentSignatureBytes = hexStringToByteArray(enrollmentSignature);
                string enrollmentResponse = receiveMessage();
                consoleBox.Text = $"Server sent:\n {enrollmentResponse}\n";
                bool enrollVerification = verifyWithRSA(enrollmentResponse, 3072, pubkSign, enrollmentSignatureBytes);
                enrollSignVerification.Text = enrollVerification.ToString();
                if (enrollVerification)
                {
                    consoleBox.Text += "Enrollment signature is valid.\n";
                    if (enrollmentResponse == "error")
                    {
                        enrollButton.Enabled = true;
                        consoleBox.Text += "Username already exists. Login with a different username.\n";
                    }
                    else
                    {
                        consoleBox.Text += "Enrollment is successful.\n";
                        loginButton.Enabled = true;
                    }
                }
                else {
                    enrollButton.Enabled = true;
                    consoleBox.Text += "Enrollment signature is invalid.\n";
                }
                //buttonConnectServer.Enabled = false;
                // Thread receiveMessageThread = new Thread(receiveMessage);
                //receiveMessageThread.Start();
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { consoleBox.Text += ex.ToString() + "\n Please enter port and IP address again\n"; }));
            }
        }
        private string receiveMessage()
        {
            byte[] messageLengthByte = new byte[4];
            socket.Receive(messageLengthByte);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(messageLengthByte);
            int messageLengthInt = BitConverter.ToInt32(messageLengthByte, 0);

            byte[] messageByte = new byte[messageLengthInt];
            int k = socket.Receive(messageByte);
            string message = Encoding.ASCII.GetString(messageByte, 0, k);
            return message;
        }
        static string getMostSignificantHash(byte[] hash)
        {
            string str;
            byte[] half = new byte[hash.Length / 2];
            Array.Copy(hash, half, hash.Length / 2);
            return generateHexStringFromByteArray(half);
        }
        static string generateHexStringFromByteArray(byte[] input)
        {
            string hexString = BitConverter.ToString(input);
            return hexString.Replace("-", "");
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
        static byte[] encryptWithRSA(string input, int algoLength, string xmlStringKey)
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
                //true flag is set to perform direct RSA encryption using OAEP padding
                result = rsaObject.Encrypt(byteInput, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dcButton_Click(object sender, EventArgs e)
        {
            try
            {
                isListening = false;
                //sendArbitraryLengthMessage("DISCONNECT");
                socket.Close();
                dcButton.Enabled = false;
                Invoke(new Action(() =>
                {
                    enrollButton.Enabled = true;
                
                    consoleBox.Text += "You are disconnected from server." + "\n";
                    
                }));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { consoleBox.Text += ex.ToString() + "\n";  }));
            }
        }
        // HMAC with SHA-256
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sendMessage("Auth" + nameBox.Text);
                string response = receiveMessage();
                randomNumberText.Text = response;
                consoleBox.Text = $"Server sent:\n {response}\n";
                //consoleBox.Text = response;
                byte[] responseBytes = hexStringToByteArray(response);


                //Burada HMAC keyi elde etme şekli değişebilir
                byte[] HMACKey = new byte[16];
                Array.Copy(hashWithSHA256(passwordBox.Text), HMACKey, 16);

                // Array.Copy(hash, half, hash.Length / 2);
                byte[] HMACValue = applyHMACwithSHA256(response, HMACKey);
                hmacValueText.Text = generateHexStringFromByteArray(HMACValue);
                sendMessage(generateHexStringFromByteArray(HMACValue));
                consoleBox.Text = $"Client sent:\n {generateHexStringFromByteArray(HMACValue)}\n";
                string answer = receiveMessage();
                consoleBox.Text = $"Server sent:\n {answer}\n";
                string serverSignature = receiveMessage();
                loginSignText.Text = serverSignature;
                consoleBox.Text = $"Server sent:\n {serverSignature}\n";
                byte [] serverSign = hexStringToByteArray(serverSignature);
                bool verificationResult = verifyWithRSA(answer, 3072, pubkSign, serverSign);
                loginSignVerification.Text = verificationResult.ToString();
                if (verificationResult)
                {
                    consoleBox.Text += "Login signature is valid.\n";
                    if (answer == "yes")
                    {
                        consoleBox.Text += "Login is successful.\n";
                        loginButton.Enabled = false;
                    }
                    else
                    {
                        consoleBox.Text += "Login is not successful.\n";
                    }
                }
                else
                {
                    consoleBox.Text += "Login signature is invalid.\n";
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => { consoleBox.Text += ex.ToString() + "\n"; }));
            }
        }
        static bool verifyWithRSA(string input, int algoLength, string xmlString, byte[] signature)
        {
            // convert input string to byte array
            byte[] byteInput = Encoding.Default.GetBytes(input);
            // create RSA object from System.Security.Cryptography
            RSACryptoServiceProvider rsaObject = new RSACryptoServiceProvider(algoLength);
            // set RSA object with xml string
            rsaObject.FromXmlString(xmlString);
            bool result = false;

            try
            {
                result = rsaObject.VerifyData(byteInput, "SHA256", signature);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
