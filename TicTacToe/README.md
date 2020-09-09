# Tic Tac Toe
> Tic Tac Toe Tic-tac-toe (also known as noughts and crosses or Xs and Os) is a paper-and-pencil game for two players, X and O, who take turns marking the spaces in a 3×3 board. The player who succeeds in placing three of their tokens in a horizontal, vertical, or diagonal row wins the game.

This kata has been prepared for a Language Design Quorum Review, as part of MYOB's Future Makers Academy acceleration program.  

---
## Kata Requirements
Basic:
- console based version of Tic Tac Toe 
- two human players to play the game
- 3 x 3 board

Advanced:
- computer player that is really bad
- computer player selects random position on board
- human player represented by “O”
- computer player represented by 'X'

---
## Installation

### System Requirements
- A command line interface (CLI) such as Command Prompt for Windows or Terminal for macOS
- [.Net Core 3.1 SDK](https://dotnet.microsoft.com/download) or later. If you have homebrew you can install the latest version of the .NET Core SDK by running the command `brew cask install dotnet-sdk` in the CLI

### Clone

- Clone this repo to your local machine and in the CLI, navigate into the folder containing the solution and type `dotnet restore` to install the package dependencies

```shell
$ git clone git@github.com:Martyna-krawczyk/katas.git
$ cd <your chosen folder>
$ dotnet restore
```

### Running the application
- Navigate to the solution folder called TicTacToe and run the project using the below commands:

```shell
$ cd TicTacToe/
$ dotnet run
```
---

### Running the tests
Staying in the solution folder, enter `dotnet test` in your CLI to run the unit tests in the solution

## Usage
- When prompted, enter 'y' to play against the computer, or 'n' to play against another player
- The board will display the available cells as "."
- To select your chosen coordinate, enter two digits separated by a comma - your token will be placed on the chosen cell
- The computer will take their turn automatically (if selected).
- The game will terminate when a draw or win have been identified.

## Dependencies
[XUnit](https://xunit.net/) - Testing framework