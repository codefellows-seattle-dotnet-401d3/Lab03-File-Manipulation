# Lab 03 File IO
## Word Guessing game
======================================
## Overview
This is a word guessing console app. It's like hangman in the console!

There is a small list of words pre-loaded into the app, and more words can be added by the user.

Note: Nothing in this app is case sensitive.

## Use
You need to be able to compile and then run C# code for console apps.

### starting screen
If the game is run correctly, the starting console screen should look like this:
```
Would you like to play a game?
1. Play with random word
2. Add a word to list
3. Remove a word from list
4. Display word list
5. quit.
```
Select an option from the menu by inputing a number and pressing the enter key.

### menu options
In the opposite order, the options do:
5. the application will exit
4. Will display to the console screen the list of words available
3. Gives you the option to remove a word from the list. You must type the word correctly.
2. Allows you to input a word and have it added to the list
1. selects a word from the list and begins the game.

### Game Play
The game will begin with something like this:
```
_ _ _ _
What letter would you like to guess next?
```
Each underscore in that first line represents a hidden letter. The user should input a letter to guess. If it is a match, the underscore will be replaced with the letter. Once every letter in the word has been guessed, the game will notify the user of their victory and return to the main menu.

## Architecture
This app was built as an exercise in file manipulation. For that reason, the word list is kept in an external .txt file.

### Classes
Word: This class describes the behavior of a word in the guessing game. It will hold the correct answer, hold the array of underscores and letters that represents the current state of the word, and will update that state given a guess.

Program: all other behavior is in the Program class.

## Change log:
2018-03-21 v0.7 game released, but not functional.
2018-03-30 v1.0 game fully functional, unit tested and debugged.
2018-03-31 v1.1 minor comment tweaks, expanded unit testing