# 2048
C# Console 2048 Clone

# Program Brief
Implement a 2D sliding block puzzle game where blocks with numbers are combined to add their values.<br>
The rules are that each turn the player must perform a valid move shifting all tiles in one direction <br>
(up, down, left or right). A move is valid when at least one tile can be moved in that direction.<br>
When moved against each other tiles with the same number on them combine into one. A new tile with<br>
the value of 2 is spawned at the end of each turn if there is an empty spot for it.To win the player <br>
must create a tile with the number 2048. The player loses if no valid moves are possible.<br>
The name comes from the popular open-source implementation of this game mechanic, 2048.<br>
Requirements:<br>
"Non-greedy" movement.The tiles that were created by combining other tiles should not<br>
be combined again during the same turn (move). That is to say that moving the tile row of<br>
[2][2][2][2]<br>
to the right should result in<br>
 ......[4][4]<br>
and not<br>
 .........[8]<br>
"Move direction priority". If more than one variant of combining is possible, move direction shows one that will take effect. <br>For example, moving the tile row of<br>
...[2][2][2]<br>
to the right should result in<br>
 ......[2][4]<br>
and not<br>
 ......[4][2]<br>
Adding a new tile on a blank space.Most of the time new "2" is to be added and occasionally(10% of the time) - "4"<br>
Check for valid moves.The player shouldn't be able to skip their turn by trying a move that doesn't change the board.<br>
Win condition.<br>
Lose condition<br>
