# LaFarge-CrackMe2-Keygen
This is a simple keygen for LaFarge's crackme #2. You can find a link to the crackme [here](https://crackmes.one/crackme/5ab77f5633c5d40ad448c2f2).
To run this keygen, simply navigate to the **LaFarge-CrackMe2-Keygen/bin/x64/Release** folder, download the .exe, and open it.
#### Screenshot of LaFarge-CrackMe2-Keygen
![LaFarge-CrackMe2-Keygen-UI](https://github.com/JulianOzelRose/LaFarge-CrackMe2-Keygen/assets/95890436/abe91478-a045-4774-b24f-3d8e3e505dda)

# Serial key check subroutine
The serial key check subroutine begins at the address on ```0x4010B4```. The serial key generation algorithm itself begins on ```0x4012A3```.
The user-entered serial key is compared with the generated serial key on ```0x4012B5``` using ```lstrcmp```. Notice both the user-entered
key and the generated serial key both being pushed onto the stack just before ```lstrcmp```.
#### Serial compare subroutine viewed in x32dbg
![Serial key compare](https://github.com/JulianOzelRose/LaFarge-CrackMe2-Keygen/assets/95890436/fab08de8-a3aa-427c-b927-01d692f15a93)

# Serial key generation algorithm
The serial key generation algorithm is based on the entered username, and consists of 7 transformations. The first character of the username is ignored.
1. Perform XOR operations on each character of the username using the array ```{0xAA, 0x89, 0xC4, 0xFE, 0x46}```.
2. Perform XOR operations on the resulting bytes from the first transformation, using the array ```{0x78, 0xF0, 0xD0, 0x03, 0xE7}```.
3. Perform XOR operations on the resulting bytes from the second transformation using the array ```{0xF7, 0xFD, 0xF4, 0xE7, 0xB9}```.
4. Perform XOR operations on the bytes from the third transformation, using the array ```{0xB5, 0x1B, 0xC9, 0x50, 0x73}```.
5. Take the initial four numbers at ```0x406345``` and add them to the numbers from the key that was generated through the first four transformations.
6. Take the DWORD value at ```0x406549``` and store it in ```EAX```, then divide ```EAX``` by 0xA, storing the result in ```EAX```. 0x30 is then added to the remainder.
7. Reverse the characters of the serial to the get final number.

# Patching the .exe
As opposed to reversing the serial key generation algorithm, it is also possible to take a shortcut by modifying the .exe slightly. By changing the ```jne``` instruction
at ```0x4012BC``` to ```jmp```, you effectively bypass the serial check subroutine so that the program counts any serial key as valid. Although it should be noted
that the ruleset for this particular crackme specifies "no patching".
