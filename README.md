# LaFarge's CrackMe #2 Keygen
This is a simple keygen for LaFarge's CrackMe #2. You can find a link to the crackme challenge [here](https://crackmes.one/crackme/5ab77f5633c5d40ad448c2f2).
To run this keygen, simply navigate to the [Release](https://github.com/JulianOzelRose/LaFarge-CrackMe2-Keygen/tree/master/LaFarge-CrackMe2-Keygen/bin/x64/Release) folder,
then download ```LaFarge-CrackMe2-Keygen.exe```, and open it. To generate a key, enter a username at least 4 characters long, then click ```Generate Key```. The keygen
will then provide you with a valid serial key.

#### Screenshot of LaFarge-CrackMe2-Keygen
![LaFarge-CrackMe2-Keygen-UI](https://github.com/JulianOzelRose/LaFarge-CrackMe2-Keygen/assets/95890436/2cb914f8-c56b-4b98-b547-e17c08b98edc)

## Serial key check subroutine
The serial key check subroutine begins at the address on ```0x4010B4```. The serial key generation algorithm itself begins on ```0x40117A```.
The user-entered serial key is compared with the generated serial key on ```0x4012B5``` using ```lstrcmp```. Notice both the user-entered
key and the generated serial key being pushed onto the stack just before ```lstrcmp``` is called.
#### Serial compare subroutine viewed in x32dbg
![Serial key compare](https://github.com/JulianOzelRose/LaFarge-CrackMe2-Keygen/assets/95890436/ec2ba48c-76b4-4068-a8c1-abc43ca41dfc)

## Serial key generation algorithm
The serial key generation algorithm is based on the entered username, and consists of 7 transformations. The first character of the username is ignored.
1. Perform XOR operations on each character of the username using the array ```{0xAA, 0x89, 0xC4, 0xFE, 0x46}```.
2. Perform XOR operations on the resulting bytes from the first transformation, using the array ```{0x78, 0xF0, 0xD0, 0x03, 0xE7}```.
3. Perform XOR operations on the resulting bytes from the second transformation using the array ```{0xF7, 0xFD, 0xF4, 0xE7, 0xB9}```.
4. Perform XOR operations on the resulting bytes from the third transformation, using the array ```{0xB5, 0x1B, 0xC9, 0x50, 0x73}```.
5. Take the initial four numbers at ```0x406345``` and add them to the numbers from the key that was generated through the first four transformations.
6. Take the DWORD value at ```0x406549``` and store it in ```EAX```, then divide ```EAX``` by 0xA, storing the result in ```EAX```. Then add 0x30 to the remainder.
7. Reverse the characters from the 6th transformation to get the final number.

## Patching the .exe file
As opposed to reversing the serial key generation algorithm, it is also possible to take a shortcut by modifying the .exe file slightly. By changing the ```jne``` instruction
at ```0x4012BC``` to ```jmp```, you effectively bypass the serial check subroutine so that the program counts any serial key as valid. Although it should be noted
that the ruleset for this particular crackme specifies "no patching".

## Sources
During the process of reverse engineering and creating the keygen for LaFarge's CrackMe #2, I relied on the following sources for guidance, insights, and techniques:

- [aleid: Solution-LaFarges-crackme-2](https://www.aldeid.com/wiki/Solution-LaFarges-crackme-2)
  This comprehensive write-up by aleid offers a step-by-step walkthrough of the reverse engineering process for LaFarge's CrackMe #2. The detailed explanations of the algorithms and techniques used were instrumental in understanding the crackme's inner workings.

- [YouTube: Reverse Engineering the LaFarge Crackme #2 and keygen](https://www.youtube.com/watch?v=DEDYk8zN53A)
  This video tutorial provides a detailed walkthrough of the process of reversing the algorithm. Following along with the video helped solidify my understanding of the keygen creation process.

- [crackmes.one](https://crackmes.one/)
  The original source of the crackme challenge, this platform provides a repository of reverse engineering challenges, crackmes, and solutions.
