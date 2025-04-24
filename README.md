🎮 Bounce Bash
A hyper-casual 2D arcade-style Unity game where you control a bouncing charcter, dodge deadly obstacles, and collect coins to climb the scoreboard!

✅ Features I Added

Physics & Core Concepts: Used Unity stuff like Rigidbody2D, colliders, and a simple singleton class for managing things easily.

Dynamic Spawning: Added a system where coins and obstacles spawn based on probability — so it’s not totally random chaos.

Obstacle Variety: There are multiple types of obstacles, and one gets picked randomly each time to keep things interesting.support to add extra obstacles is provided

Editor Tooling: Made a little editor script to help with anchoring UI elements — just to make sure stuff looks good on different screens.

Skin System: Added basic skin support so the charcter can have different looks.

ScriptableObjects: Used ScriptableObjects to store the charcter skin types and their values — makes things easier to manage.

Coin Feedback Animation: Added a small pop animation to the coin text whenever the player grabs a coin — just a nice little touch.

Persistent Data: Used PlayerPrefs to store high scores and total coins locally on the player’s device.

Daily Challenge System: Built out a daily challenge manager (like “collect 50 coins”), though I haven’t hooked up the UI for it yet.Manager of daily Challenge is commited in the project


🐞 Known Issues

Right now, if the saved coin count is lower than the current coin count, nothing really happens — just a debug log shows up. Could improve that logic.

The coin and obstacle spawn probability is purely random at the moment. It could’ve been better if it took previous difficulty levels into account to scale the challenge over time.


