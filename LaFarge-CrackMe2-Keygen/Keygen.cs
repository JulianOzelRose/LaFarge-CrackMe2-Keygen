using System;
using System.Collections.Generic;
using System.Windows.Forms;

/*
    Julian O. Rose
    LaFarge-CrackMe2-Keygen
    8-31-2023
*/

namespace LaFarge_CrackMe2_Keygen
{
    public partial class Keygen : Form
    {
        public Keygen()
        {
            InitializeComponent();
        }

        static List<byte> GetUsernameBytes(string username)
        {
            // Convert characters to integers while skipping first character
            List<int> parsedUsername = new List<int>();
            for (int i = 1; i < username.Length; i++)
            {
                parsedUsername.Add((int)username[i]);
            }

            // Add null terminator
            parsedUsername.Add(0);

            // Convert username integers to bytes
            List<byte> usernameBytes = new List<byte>();
            for (int i = 0; i < parsedUsername.Count; i++)
            {
                usernameBytes.Add((byte)parsedUsername[i]);
            }

            return usernameBytes;
        }

        static List<byte> XorLeftToRight(List<byte> xorBytes, List<byte> byteArray)
        {
            List<byte> cipherBytes = new List<byte>(new byte[byteArray.Count]);

            int keyIndex = 0;

            for (int i = 0; i < byteArray.Count; i++)
            {
                byte currentUsernameByte = byteArray[i];
                byte keyByte = xorBytes[keyIndex];
                byte cipherByte = (byte)(currentUsernameByte ^ keyByte);

                cipherBytes[i] = cipherByte;
                xorBytes[keyIndex] = currentUsernameByte;

                keyIndex++;

                if (keyIndex == xorBytes.Count)
                {
                    keyIndex = 0;
                }
            }

            return cipherBytes;
        }

        static List<byte> XorRightToLeft(List<byte> xorBytes, List<byte> byteArray)
        {
            List<byte> cipherBytes = new List<byte>(new byte[byteArray.Count]);

            int keyLength = xorBytes.Count;
            int keyIndex = 0;
            
            for (int i = byteArray.Count - 1; i >= 0; i--)
            {
                byte currentUsernameByte = byteArray[i];
                byte keyByte = xorBytes[keyIndex];
                byte cipherByte = (byte)(currentUsernameByte ^ keyByte);

                cipherBytes[i] = cipherByte;
                xorBytes[keyIndex] = currentUsernameByte;

                keyIndex++;

                if (keyIndex == keyLength)
                {
                    keyIndex = 0;
                }
            }

            return cipherBytes;
        }

        static List<byte> AddRightToLeft(List<byte> zeroBytes, List<byte> byteArray)
        {
            List<byte> resultantBytes = new List<byte>(new byte[byteArray.Count]);

            int keyIndex = 0;
            
            for (int i = 0; i < byteArray.Count; i++)
            {
                byte currentUsernameByte = byteArray[i];
                byte keyByte = zeroBytes[keyIndex];
                byte addedByte = (byte)((currentUsernameByte + keyByte) & 0xFF);

                resultantBytes[i] = addedByte;
                zeroBytes[keyIndex] = addedByte;

                keyIndex++;

                if (keyIndex == zeroBytes.Count)
                {
                    keyIndex = 0;
                }
            }

            return zeroBytes;
        }

        static List<byte> Divide(List<byte> zeroResult)
        {
            int divisor = 0xA;                              // Divisor for decimal representation
            List<byte> quotientBytes = new List<byte>();    // Digits of the quotient

            long currentValue = 0;                          // Current chunk being processed
            int shiftAmount = 0;                            // Number of bits to shift for the next chunk

            for (int i = 0; i < zeroResult.Count; i++)
            {
                currentValue |= ((long)zeroResult[i] << shiftAmount);
                shiftAmount += 8;

                if (shiftAmount >= 64)
                {
                    // Process the current chunk
                    while (currentValue != 0)
                    {
                        long remainder = currentValue % divisor;
                        currentValue /= divisor;
                        quotientBytes.Add((byte)(0x30 + remainder));
                    }

                    shiftAmount = 0;
                    currentValue = 0;
                }
            }

            // Process any remaining chunk
            while (currentValue != 0)
            {
                long remainder = currentValue % divisor;
                currentValue /= divisor;
                quotientBytes.Add((byte)(0x30 + remainder));
            }

            return quotientBytes;
        }

        static long ReverseNumber(List<byte> byteArray)
        {
            long reversedNumber = 0;
            int trailingZeroCount = 0;

            for (int i = byteArray.Count - 1; i >= 0; i--)
            {
                byte currentByte = byteArray[i];

                if (currentByte == 0x30)
                {
                    trailingZeroCount++;
                }
                else
                {
                    trailingZeroCount = 0;
                }

                reversedNumber = reversedNumber * 10 + (currentByte - 0x30);
            }

            if (trailingZeroCount > 0)
            {
                trailingZeroCount--;
            }

            for (int i = 0; i < trailingZeroCount; i++)
            {
                reversedNumber *= 10;
            }

            return reversedNumber;
        }

        void GenerateKey(string username)
        {
            // Declare XOR and zero byte arrays
            List<byte> xorBytes1 = new List<byte> { 0xAA, 0x89, 0xC4, 0xFE, 0x46 };
            List<byte> xorBytes2 = new List<byte> { 0x78, 0xF0, 0xD0, 0x03, 0xE7 };
            List<byte> xorBytes3 = new List<byte> { 0xF7, 0xFD, 0xF4, 0xE7, 0xB9 };
            List<byte> xorBytes4 = new List<byte> { 0xB5, 0x1B, 0xC9, 0x50, 0x73 };
            List<byte> zeroBytes = new List<byte> { 0x00, 0x00, 0x00, 0x00 };

            // Parse username as byte array
            List<byte> usernameBytes = GetUsernameBytes(username);

            // XOR, addition, and division operations
            List<byte> firstXorResult = XorLeftToRight(xorBytes1, usernameBytes);
            List<byte> secondXorResult = XorRightToLeft(xorBytes2, firstXorResult);
            List<byte> thirdXorResult = XorLeftToRight(xorBytes3, secondXorResult);
            List<byte> fourthXorResult = XorRightToLeft(xorBytes4, thirdXorResult);
            List<byte> addedResult = AddRightToLeft(zeroBytes, fourthXorResult);
            List<byte> dividedResult = Divide(addedResult);

            // Reverse number for serial key
            long serialKey = ReverseNumber(dividedResult);
            serialKeyTextBox.Text = serialKey.ToString();
        }

        private void GenerateKeyButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;

            if (username.Length < 4)
            {
                serialKeyTextBox.Clear();
                MessageBox.Show("Username must be at least 4 characters.", "ERROR");      
            }
            else
            {
                GenerateKey(username);
            }
        }
    }
}
