# Online-TickTackToe

A real-time Tic Tac Toe game implemented using C# socket programming.

## Overview

This project delivers a real-time Tic Tac Toe experience, allowing 2 players to compete and 3 additional participants to observe the gameplay. If a player exits the game prematurely, an observer will be automatically promoted to play.

## Features

- **Real-Time Interaction**: The game updates in real-time, ensuring a seamless experience for both players and observers.
- **Automatic Observer Promotion**: If a player drops out, an observer takes their place, keeping the game ongoing.
- **Socket Programming**: Uses C# socket programming to establish and manage connections.

## How to Play

1. **Starting the Server**: Launch the server application first.
2. **Connecting as a Player/Observer**: Launch the client application and connect to the server. The first two clients will be players, while subsequent clients (up to 3) will be observers.
3. **Gameplay**: Players take turns to make their moves. Observers can watch the game progression in real-time.
4. **Player Dropouts**: If a player disconnects, the first observer in the queue will become a player and continue the game.

## Setup and Usage

1. Clone/download the repository.
2. Open the solution in your preferred C# IDE (e.g., Visual Studio).
3. Build and run the server application.
4. Build and run multiple client applications (up to 5) to simulate players and observers.
5. Follow on-screen instructions to play or observe the game.

## Contributing

Contributions are welcome! If you have improvements, bug fixes, or other suggestions, please open a pull request or issue.



