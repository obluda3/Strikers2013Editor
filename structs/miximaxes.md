# Miximaxes
main.dol @0x804c8b90 => gMiximaxTable

| Offset | Name | DataType | Notes |
| --- | --- | --- | --- |
| 0x0 | Original Player | u16 | |
| 0x2 | Slot | u16 |  |
| 0x4 | Destination Player | u16 | |
| 0x6 | Move 1 | u16 | seems to always be 0xEB => miximax transformation |
| 0x8 | Move 2 | u16 | |
| 0xA | Move 3 | u16 | |