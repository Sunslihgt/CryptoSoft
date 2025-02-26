# CryptoSoft
CryptoSoft is a software used to encrypt and decrypt files using XOR and a 64 bit (or longer) key.

It is a simple software that allows you to encrypt and decrypt files using the same password (symetric cryptography).

The software is written in C# and is used from a command line interface.
## Install 
  1 Download win-64 from https://github.com/Sunslihgt/CryptoSoft/releases
  1.2 Extract the archive in the destination folder chosen
  1.3 Copy the folder address of the executable
  1.4 Go to Windows search Change system environment variables, click on environment variables, new and paste the folder address of the executable, click OK in each window to confirm
  1.5 Restart all currently open terminals if necessary
Verify the install :
  1.6 Launch a PowerShell window
  1.7 Run the command Where.exe CryptoSoft.exe
  1.8 If the full path of the software is displayed, the installation is complete

## Usage
```
CryptoSoft.exe <inputFilePath> <outputFilePath> <key>
```
The key has to be at least 64 bits long.

## Examples
```
CryptoSoft.exe file.txt file_encrypted.txt mypassword
CryptoSoft.exe file_encrypted.txt file_decrypted.txt mypassword
```

## Output
The output file will be the encrypted or decrypted version of the input file.

The program will also output the time it took to encrypt or decrypt the file or -1 if an error occured.

## License
This software is under the MIT License. See the [LICENSE.md](LICENSE.md) file for more information.

