<h3>Start-up:</h3>
Both client and server program do pre-computations before their initial connection starts. 
These computations are about the RSA components of the system.
<h3>Client:</h3>
Client simply loads the public RSA keys for both data encryption and signature.
<h3>Server:</h3>
Server has private RSA keys for exchange and authentication in an encrypted hexadecimal
format, encrypted with AES128 in CFB mode algorithm. At first, the server reads these encrypted 
hexadecimal keys, converts them to bytes and then converts them to default string. Later on, the 
password to decrypt these keys is given with the submit button. For this step, the password is 
“Bohemian”. This password is hashed with SHA256, this results in a 256 bit output which corresponds 
to 32 bytes. First 16 bytes are used as the required IV value for the CFB mode and the last 16 bytes are 
used as the key. Then, both RSA keys are decrypted with the key and IV obtained from the password 
“Bohemian”.
<h3>Connection</h3>
Client and server communicate through sockets. Server listens to a port whose number is 
given by the server user. Client initiates this process with “Enroll” button.
<h3>Socket Communication</h3>
Messages are sent in bytes through a socket. First, length of the message is sent and 
then the message itself is sent through the socket. Same order is followed when messages are received, 
except that they are encoded to ASCII from bytes. For each client, a client listening thread is created 
so that server can handle each client separately.
<h3>Enrollment</h3>
Client starts the communication with server. After taking the port number and server IP as a 
user input, client connects to server. The client needs to enroll in the server first. To do so, client 
hashes his/her password with SHA256 which results in 32 bytes, takes the last 16 bytes of this hash 
and then appends username to it. Then the client sends the message “Enroll” to let the server know it 
is going to receive an enrollment message next. The enrollment message is encrypted with the public 
key of the server and sent through the socket. Here, the server decrypts the message with its private 
key. It gets the password hash from the first 32 characters of the string, then gets the username which
is the rest. Afterwards, server checks if such username exists already, if so; server sends the message 
“username ‘username’ already exists” and sets the enrollment response to “error”. Else, the server 
adds the client to the clients list and sets the enrollment response to “success”. Then; server signs the 
enrollment response, sends the signed message and then sends the message itself to client. Client, 
reading this message and verifying that server sent it, finds out if the enrollment was successful or it 
has failed and needs to be initiated again.
<h3>Secure Login</h3>
After enrollment, client is able to login to server with “Login” button. However, client needs 
to authenticate himself/herself first. For this purpose, client sends the string ”Authusername” where 
username is client’s respective username to initiate the authentication protocol. This authentication is 
done via challenge-response protocol. In our implementation, server generates a 16 byte(128 bit) 
random number which is converted to hex string. The random number generator used here is the 
RNGCryptoServiceProvider which generates random numbers suitable for such cases. To our 
understanding, this random number is generated so that replay attacks are not possible. If the client 
sends HMAC of his/her password only, an attacker may repeat the same message later to gain 
authentication; with the inclusion of the random number however, uniqueness of each authentication 
message by client is required and provided. After receiving the random number, client hashes his/her 
password with SHA256 and gets the last 16 bytes of this hash as the HMAC key. Then applies HMAC
with SHA256 to the random number and sends the HMAC output to server. Server applies HMAC
with SHA256 to the random number it generated with the user’s registered password’s upper hash. If 
the client is the user he/she claims to be, the HMAC output sent by client must be equal to the HMAC 
output server generated. If so, server sends the acknowledgment string “yes” and then signs the string
with its signature private key and sends the signature afterwards. Else, server does the same with 
acknowledgement string “no” and breaks out of the loop where it receives protocol initiating messages 
from client.
<h3>Disconnect</h3>
When client wants to disconnect, he/she sends a string “DISCONNECT” to server. Upon 
receiving this, client listening thread of this client acquires the lock to remove the client from the client 
list. The lock is necessary here as this list may be modified by another thread which can result in a race 
condition problem. 
Unfortunately, we were unable to implement re-connection after disconnecting from the 
server. Also, we currently do not explicitly delete the keys when the user disconnects.
Another problem appears here is client continues to send empty messages to server after
disconnecting.
<h3>Encountered Problems</h3>
Problems we encountered in this project were mostly due to technical details of the used 
libraries or C# language. Information encoding formats caused errors with encryption-decryption 
operations and use of threads enforced us to be careful about local thread variables and globally shared 
variables. For encoding problems, we fixed the encoding in our code and for threading problem, using 
a lock solved it.
