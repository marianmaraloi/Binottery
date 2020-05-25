The game goes through the next steps:

1 	When it starts it checks if there is any saved game. You should type "continue" to resume or "new" for a new game.
I assumed that the only 3 commands accepted are "continue", "new" and "exit" for the first step. 
Moreover, the "continue" and "new" commands are valid just at the beginning of the game.

2 	The game receives commands from STDIN and processes them as the assignment requests. The assignment documentation 
does not specify when the credit is cleaned so I assumed that this would happen after commands such as "new", "end" but
not after the game ends when the player made his 5 guesses (otherwise, doubling the credit would not make much sense).