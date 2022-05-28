description: A game where the user guesses a letter (hang man style)
and if the letter is part of the word it is placed on the board,
otherwise a part of the parachute is removed.

structure:
    Object: TerminalService
        responsibility: 
            Draws the jumper and the word spaces. 
            Accepts user input.
        behaviors: 
            Display the jumper and its parachute. 
            Display the guessed letters, accept user input.
        states: None
    Object: GamePlay
        responsibility: 
            keep track of functions and objects, run the game.
        behaviors: 
            StartGame
            Make a guess
            Make TerminalService, Jumper, and Word objects
        states: 
            Still playing
            Correct/Incorrect
    Object: Jumper
        responsibility: 
            Keep track of how much parachute is left
        behaviors: 
            Remove part of the parachute if letter is not in word
        states: 
            Full parachute, part parachute, no parachute
    Object: Word
        responsibility: 
            Chooses a word from a list of words keep track if the guessed letter is in the word (private variable)
        behaviors: 
            Returns a word at begining. 
            Returns true or false if letter is in the word or not
        states: True or False

    variables:
        guess: Whether the letter is in the word
        still_playint: If the word is not guessed or the parachute is gone

required software: Using .net6

name & email: Kyle Roundy, rou21007@byui.edu