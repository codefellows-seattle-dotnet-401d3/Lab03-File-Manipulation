# Word Guess Game

**Author**: Arthur Allen

**Version**: 1.9.0 (increment the patch/fix version number up if you make more commits past your first submission)

## Overview
<!-- Provide a high level overview of what this application is and why you are building it, beyond the fact that it's an assignment for a Code Fellows 401 class. (i.e. What's your problem domain?) -->
Plays a word guess game similar to Hangman, in which you have a limited number of chances to guess a randomly chosen word.  You can see the dictionary, and add and delete words.

## Getting Started
<!-- What are the steps that a user must take in order to build this app on their own machine and get it running? -->
Visual Studio 2017

## Example
<!-- Show them what looks like and how how to use the application.  -->
The user has a main menu for accessing the options.  If she plays the game, she is presented with a number of underscores representing the length of the word.  When she types in a letter, the letter appears on the "guesses" line.  If the letter is part of the word, the letter also appears in its proper place in the word in progress.  Play continues until the word is found or the number of tries runs out.  In non-game mode, the user also can see the dictionary, add a word to the dictionary, or remove a word.

## Architecture
<!-- Provide a detailed description of the application design. What technologies (languages, libraries, etc) you're using, and any other relevant design information. -->
C#

## Change Log
<!-- Use this are to document the iterative changes made to your application as each feature is successfully implemented. Use time stamps. Here's an example:

01-01-2001 4:59pm - Added functionality to add and delete some things. -->
03-27-2018 7:50pm - Fixed bug that wouldn't exit on exceeding the number of tries.  Final commit.