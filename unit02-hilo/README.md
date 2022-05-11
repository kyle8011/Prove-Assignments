Title: hilo

description: A game where the user guesses whether the next card drawn
will be higher or lower than the last, they are granted or taken away
points based on if their guess was correct or not.

structure:
    Object: card
        responsibility: select a random number from 1 - 13
        behaviors: Display the number drawn
        states: none
    Object: GamePlay
        responsibility: keep track of score, user input, and display
        behaviors: display information to the user, add up score, take user input
        states: still playing, correct, incorrect

    variables:
        guess: whether the next card will be higher or lower
        score: keep track of what points were earned
        play again: to end the game or keep playing

required software: Using .net6

name & email: Kyle Roundy, rou21007@byui.edu