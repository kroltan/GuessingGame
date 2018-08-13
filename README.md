# GuessingGame

A simple guessing game, similar to Akinator. Developed for a recruitment test.

Loads data from a provided data file, and supports many descriptions of each entry.
It also prompts the user for information when it hits a dead end, but does not
persist that across sessions (but could be made to).


## Implementation

The software's logic is implemented in 2 main levels of abstraction:

 - The data layer, which stores "Subjects" which can have one or more "Traits",
   and allows querying across the dataset, with eager execution.

 - The game layer, which is a simple asynchronous state machine that operates
   over the data layer, laying query over query based on user input, and a basic
   game loop to process the state machine.
   
The data layer can be easily used programmatically, while the game supports
pluggable user interfaces.

## GUI

The graphical user interface is implemented on a separate project, and depends
directly on the game and data layers. It also handles file I/O for data storage.

## Unit Tests

There are tests for the data layer, but unfortunately for personal reasons I
could not complete the game and interface tests within the alotted time.

