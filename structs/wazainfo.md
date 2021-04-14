# wazainfo layout
Length: 0x8c, start of file: 0x1e

| Offset | Name | DataType | Notes |
| --- | --- | --- | --- |
| 0x0 | Tier | short | 0 = Lv.1 1 = Lv.2 2 = Lv.3 3 = SP |
| 0x2 | Base Power | short |  |
| 0x4 | Max Power | short | Hissatsu's power with max Kakusei |
| 0x6 | TP | short | TP Cost |
| 0x8 | Element | short | 0 = Wind 1 = Wood 2 = Fire 3 = Earth 4 = Void |
| 0xA | Status | short | 0 = Normal 1 = Long Shoot 2 = Block 3 = Chain |
| 0x14 | Co-Op Player Count | short | Number of players required to do the hissatsu |
| 0x1A-0x2C | Users | short | ID's of the possible users |
| 0x2E-0x40 | Co-Op Partners | short | ID's of the possible partners |

Other values are unknown

All of these values were found by GalacticPirate