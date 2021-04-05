# playerinfo layout
Length: 0x148, start of file: 0xE5C

| Offset | Name | DataType | Notes |
| --- | --- | --- | --- |
| 0x0 | Hex ID | int | Player's HEX ID |
| 0x8 | Short Name ID | int | Index into an entry of the text file |
| 0xC | Short Name ID | int | Index into an entry of the text file |
| 0x10 | Full Name ID | int | Index into an entry of the text file |
| 0x14 | Player Name | string |  |
| 0x2c | Gender | int | 0 = Male 1 = Female 2 = Other |
| 0x38 | Description | int | Index into an entry of the text file |
| 0x3c | Bodytype | int | 0 = Man 1 = Large 2 = Chibi 3 = Muscle 4 = Girl1 5 = Girl2 |
| 0x40 | Height | int | Player height specification |
| 0x48 | Tactical Action | int | 0x14 = Feint 0x15 = Roll 0x16 = Short 0x17 = Jump 0x18 = White Sprint 0x19 = Red Sprint 0x1A = Girl |
| 0x4c | Team | int | Player's team |
| 0x50 | Team | int | Player's team |
| 0x58 | Team Portrait ID | int | Portrait in the team list |
| 0x64 | Face Model | int | Player's 3D Model ID |
| 0x68 | Face Model | int | Player's 3D Model ID |
| 0x78 | Portrait | int | Player's 2D Portrait |
| 0x80 | Left Match Portrait | int | 2D Portrait in Match, left side |
| 0x84 | Right Match Portrait | int | 2D Portrait in Match, right side |
| 0xF4 | Element | int | 0 = Wind 1 = Wood 2 = Fire 3 = Earth 4 = Void |

Other values are unknown

Credits to AS for some of these values 