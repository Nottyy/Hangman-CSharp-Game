Hangman C# Game
====================

Design patterns used: 
-	Creational - singletone, prototype
-	Structural - proxy, facade,
-	Behavioral - strategy command


C# game, following the best practices in the OOP such as SOLID, DRY and KISS principles.

Hangman is a words guessing game. The computer picks up a random word and the player tries to guess it by suggesting letters.

The word to guess is represented by a row of dashes, giving the number of letters. If the player suggests a letter which occurs in the word, the computer prints it in all its correct positions. If the suggested letter  does not occur in the word, the computer marks the guess as wrong. The player has 10 guessing tries. The game ends when :
- The guessing player completes the word, or guesses the whole word correctly
- The guessing player exceeds the 10 available guesses without revealing the word.
