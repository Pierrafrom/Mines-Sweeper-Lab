# Mines-Sweeper-Lab

This repository contains a C# implementation of the classic Minesweeper game. The game is designed to be played in a Windows Form Application, developed using Visual Studio.

## Features

- The game supports three difficulty levels: Easy, Medium, and Hard. Each level has a different grid size and number of mines.
- The game uses a matrix to represent the game board and a combination of buttons and labels to represent each cell.
- The game includes a timer that starts when a new game is initialized.

## How to Play

1. The game starts by asking for the difficulty level.
2. The game then generates a grid with a certain number of mines.
3. Players uncover cells one by one. If a cell contains a mine, the game ends. If a cell does not contain a mine, it shows the number of mines in the adjacent cells.
4. The game continues until all cells that do not contain a mine are uncovered.

## Code Structure

The main class of the program is `frmMain`, which represents the main form of the application.

The program uses several constants to define the parameters of the game, such as the size of the cells, the number of bombs, and the size of the board for each difficulty level.

The `initializeNewGame()` function is used to start a new game. It sets up the game board and starts the timer.

The `createButtons()` function is used to create a button for each cell on the game board.

## Requirements

- .NET Framework
- Visual Studio

## Usage

To play the game, open the solution in Visual Studio, build the solution, and then run the application.

