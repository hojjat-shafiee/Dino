Dino Clone (Unity)
A simple and clean recreation of the classic Chrome “Dino” offline game, developed using the Unity Engine.

This project is designed as a lightweight, beginner‑friendly introduction to 2D endless runner mechanics.

Features
Classic endless‑runner gameplay
Jump and duck controls
Obstacle spawning with increasing difficulty
Score and high‑score tracking
Simple UI (Start, Game Over, Restart)
Organized and readable C# code
Easy to extend or modify
Project Structure
text
Assets/
  Scripts/
    PlayerController.cs
    ObstacleSpawner.cs
    GameManager.cs
    ScoreManager.cs
  Sprites/
  Prefabs/
  Scenes/
    Game.unity
Requirements
Unity Version: (replace with your version, e.g., 2022.3 LTS or higher)
Platform: PC / WebGL (mobile optional)
How to Run
Clone the repository:
bash
   git clone https://github.com/your-username/your-dino-repo.git
Open the project in Unity Hub.
Open the main scene (Game.unity).
Press Play.
Gameplay Overview
The player controls a running dinosaur that must avoid obstacles by jumping or ducking.

Difficulty gradually increases as the game progresses, and a high score is saved locally.

Core Systems
PlayerController: Handles movement and inputs
ObstacleSpawner: Generates obstacles at random intervals
GameManager: Controls game states and restarts
ScoreManager: Tracks and displays the score
Future Improvements
Add animations
Add sound effects
Add flying enemies
Add themes or skins
Add touch controls for mobile builds
License
This project is released under the MIT License (or replace with your chosen license).

Contributing
Pull requests and suggestions are welcome.

If you want, I can:

Add badges (Unity version, license, build status, etc.)
Include screenshots or GIF previews
Tailor this README to match your exact folder structure
