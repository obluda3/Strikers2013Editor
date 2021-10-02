# playerinfo layout

# ChargeData
Length: 0x60, start: 0x1C - u32

| Offset | Name |
| --- | --- |
| 0x0 | Idle |
| 0x4 | Holding the ball |
| 0x8 | Pass |
| 0xC | Normal Shoot |
| 0x10 | Normal Catch |
| 0x14 | Goal |
| 0x18 | Received goal |
| 0x1C | Tackle |
| 0x24 | Tackle (on an opponent) |
| 0x28 | Tackle (on an opponent) |
| 0x40 | Tactical Action (on an opponent) |
| 0x44 | Tactical Action |
| 0x48 | Tactical Action (on an opponent?) |
| 0x4C | Through pass |
| 0x50 | Direct shot |
| 0x54 | Cross |
| 0x58 | Volley |

The gauge gets filled when it reaches 200.

# PlayerDef
Length: 0x148, start: 0xE5C

| Offset | Name | DataType | Notes |
| --- | --- | --- | --- |
| 0x0 | Hex ID | u32 | Player's HEX ID |
| 0x8 | Hidden name | u32 | Index into an entry of the text file |
| 0xC | Short Name ID | u32 | Index into an entry of the text file |
| 0x10 | Full Name ID | u32 | Index into an entry of the text file |
| 0x14 | Player Name | string |  |
| 0x2c | Gender | u32 | 0 = Male 1 = Female 2 = Other |
| 0x30 | Idle Animation | u32 | Used in caravan and minigame selection |
| 0x38 | Description | u32 | Index into an entry of the text file |
| 0x3c | Bodytype | u32 | 0 = Man 1 = Large 2 = Chibi 3 = Muscle 4 = Girl1 5 = Girl2 |
| 0x40 | Height | u32 | Player height specification |
| 0x44 | Shadow Size | u32 | |
| 0x48 | Tactical Action | u32 | 0x14 = Feint 0x15 = Roll 0x16 = Short 0x17 = Jump 0x18 = White Sprint 0x19 = Red Sprint 0x1A = Girl |
| 0x4C | Course Animation | u32 | 1 for males to have Kappa's animation | 
| 0x50 | Team | u32 | Player's team |
| 0x54 | Emblem | u32 | Player's emblem |
| 0x58 | Team Portrait ID | u32 | Portrait in the team list |
| 0x5C | Position | u32 | GK = 0 DF = 0x23 MF = 0x24 FW = 0x25 |
| 0x60 | Face Model | u32 | Player's 3D Model (in match) |
| 0x64 | Face Model | u32 | Player's 3D Model (index u32o grp.bin minus 800) |
| 0x68 | Face Model | u32 | Player's 3D Model (index u32o grp.bin minus 800) |
| 0x6C | Body Model | u32 | Player's Body Model (reserved - replaced in game) |
| 0x70 | Body Model | u32 | Player's Body Model (reserved - replaced in game) |
| 0x78 | Portrait | u32 | Player's 2D Portrait |
| 0x80 | Left Match Portrait | u32 | 2D Portrait in Match, left side |
| 0x84 | Right Match Portrait | u32 | 2D Portrait in Match, right side |
| 0x88 | Neck and legs skin color | u32 | xRGB |
| 0x8C | Arms and knees color | u32 | xRGB |
| 0xF4 | Element | u32 | 0 = Wind 1 = Wood 2 = Fire 3 = Earth 4 = Void |
| 0xF8 | Charge profile | u32 | Player's charge profile (see above) |
| 0x104 | Voice | u32 |  |
| 0x110 | Price | s16 | A value above 0 enables the player, a value of -1 makes the player unlocked by default |
| 0x112 | list position | u16 | |
| 0x114 | list position | u32 | |


Other values are unknown

Help from : 
- AS (Element, Tactical Action, Bodytype)
- Coconutz
- Alpha (Price)
- 43044 (Charge Profile)
