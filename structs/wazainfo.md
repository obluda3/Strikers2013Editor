# wazainfo layout
Length: 0x8c, start of file: 0x1c

| Offset | Name | DataType | Notes |
| --- | --- | --- | --- |
| 0x0 | Tier | u16 | 0 = Lv.1 1 = Lv.2 2 = Lv.3 3 = SP |
| 0x2 | Base Power | u16 |  |
| 0x4 | Max Power | u16 | Hissatsu's power with max Kakusei |
| 0x6 | TP | u16 | TP Cost |
| 0x8 | Element | u16 | 0 = Wind 1 = Wood 2 = Fire 3 = Earth 4 = Void |
| 0xA | Status | u16 | 0 = Normal 1 = Long Shoot 2 = Block 3 = Chain 4 = Punch 1 5 = Punch 2 |
| 0x14 | Co-Op Player Count | u16 | Number of players required to do the hissatsu |
| 0x1A-0x2C | Users | u16 | ID's of the possible users |
| 0x2E-0x40 | Co-Op Partners | u16 | ID's of the possible partners |
| 0x4E | Description | u16 | Index of the description entry of the text file |
| 0x56 | Users | u16 | Index of the users entry of the text file |
| 0x86 | Power-up indicator | u16 | 0 = Normal 1 = Keshin 2 = Armed 4 = Mix |
| 0x88 | Invocation animation timer | u16 | 0 = Normal 242 = Armed 274 = Keshin |

Other values are unknown

Credits :
- GalacticPirate for most of these values
