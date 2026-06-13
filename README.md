# Dungeon Quest: I3E Assignment 1 Game 2026

**Name:** Adam Clark
**Module:** Interactive 3D Experience
**Target Platform:** Windows Desktop
**Unity Version Used:** Unity 6000.3.13f1

---

## 1. Project Overview

This project is a first-person 3D dungeon escape experience made in Unity for I3E Assignment 1.

The player explores a dungeon-like environment, collects items, unlocks doors, avoids hazards, and tries to complete the level by collecting all required gems. The main focus of this project is on player interaction, gameplay logic, UI updates, hazards, collectibles, and using C# scripts to connect the different systems together.

The game uses a raycast-based interaction system, meaning the player has to look at interactable objects and press the interact button to use them. This is used for collecting coins, gems, keys, hearts, pressing buttons, and opening or unlocking doors.

---

## 2. How to Run the Project

1. Download or clone the GitHub repository.
2. Open the project in Unity.
3. The project was made using **Unity 6000.3.13f1**.
4. Open the main gameplay scene:
   - `Assets/Scenes/0.unity`

5. Press the Play button in Unity to test the game.
6. For submission/build testing, the intended platform is **Windows Desktop**.

---

## 3. Controls

| Control       | Action                                      |
| ------------- | ------------------------------------------- |
| W / A / S / D | Move                                        |
| Mouse         | Look around                                 |
| E             | Interact with objects                       |
| Esc           | Open / close pause menu                     |
| Left Shift    | Sprint, through the first-person controller |
| Space         | Jump, through the first-person controller   |

The main interaction key is **E**. The player needs to look at an interactable object first before pressing E.

---

## 4. Game Objective

The objective is to explore the dungeon, collect items, survive hazards, and collect all the gems needed to complete the game.

The player can collect:

- Coins for score
- Gems for main progress
- Keys to unlock doors
- Hearts to recover health

The player must avoid or survive:

- Laser walls
- Toxic gas
- Falling / rolling boulder hazards
- Goblin enemy hazards

The game is completed when all gems in the level are collected.

---

## 5. Main Features

### First-Person Player Experience

The game uses a first-person player controller so that the player can move through the environment from a first-person view.

### Raycast Interaction System

The player interacts with objects using a raycast from the centre of the screen. When the player looks at an interactable object, the UI displays a message such as, but not limited to:

- `E to Pick Up Coin`
- `E to Get Gem`
- `E to Pick up Key`

This keeps the interaction system consistent because the player only needs to look at an object and press E.

### Interactable Interface

The project uses an `IInteractible` interface so that different objects can share the same interaction structure. This allows coins, gems, keys, hearts, buttons, and doors to all be interacted with through the same player raycast system, even though each object does something different.

### Collectibles

The game includes multiple collectible types:

#### Coins

Coins add to the player's score. Each coin has an adjustable score value in the Unity Inspector.

#### Gems

Gems are the main progress collectible. The UI shows how many gems have been collected out of the total number of gems in the scene. Once all gems are collected, the game triggers the win state.

#### Keys

Keys are collected and added into the player's inventory. Some doors require a specific key before they can be unlocked.

#### Hearts

Hearts restore the player's health and are useful after taking damage from hazards.

---

## 6. Door and Lock System

Doors can be opened and closed by pressing E while looking at them. Doors also close when the player moves away from them, which helps make the environment feel more interactive instead of doors just staying open forever.

Some doors are locked and require a key. If the player does not have the correct key, the game displays a locked message. If the player has the correct key, the door unlocks, the key is removed from the inventory, and the door can be opened.

The door system includes:

- Normal doors
- Locked doors
- Key-required doors
- Door open / close interaction
- Lock visual feedback
- Prompt messages for locked and unlocked doors

---

## 7. Inventory System

The inventory system tracks key items collected by the player.

When the player picks up a key, it is added to the inventory list and displayed on the UI. When a locked door uses that key, the key is removed from the inventory.

The inventory is mainly used for:

- Checking whether the player has the key needed for a locked door
- Displaying collected key items on screen
- Removing keys after they are used

---

## 8. Score and Progress System

The score system tracks:

- Current score
- Gem collection progress
- Secret buttons found

Coins increase the player's score. Gems increase both score and gem progress. The UI updates whenever the player collects score-based items.

The gem progress UI shows the player's current gem amount compared to the total gems in the scene. The total number of gems is detected automatically from the scene, so the system can still work if more gems are added later.

When all gems are collected, the game triggers the win condition.

---

## 9. Health System

The player has a health system with a maximum health value and current health value.

Health is shown on screen in this format:

`Health: current / max`

The player loses health when touching hazards. If health reaches 0, the game over state is triggered and the game over menu appears.

The player can also collect hearts to gain health back, up to the maximum health limit.

---

## 10. Hazards

The game includes multiple hazards that damage the player in different ways.

### Laser Wall

The laser wall deals damage over time while the player stays in contact with it. It can also be deactivated by pressing a linked button, which gives the player another way to interact with the environment instead of only avoiding danger.

### Toxic Gas

The toxic gas is an area hazard. When the player stays inside the gas trigger area, they take damage over time.

### Boulder Hazard

The boulder deals damage when it collides with the player. It also resets after a delay, allowing the hazard to repeat. A cooldown is used so that the player does not take damage too many times instantly from one collision.

### Goblin Hazard

The goblin damages the player when the player enters its trigger area. It also has a damage cooldown to prevent repeated instant damage.

---

## 11. UI Features

The project includes several UI elements:

- Score text
- Health text
- Interact prompt text
- General prompt / feedback text
- Inventory text
- Gem progress text
- Pause menu
- Game over panel
- Game win panel

The UI updates during gameplay when the player:

- Collects coins
- Collects gems
- Collects keys
- Uses keys
- Gains health
- Takes damage
- Wins the game
- Dies / loses the game
- Opens or closes the pause menu

---

## 12. Audio / Game Juice

Audio is used to make the game feel more complete and responsive.

Audio is included for different gameplay events such as:

- Collecting coins
- Collecting gems
- Collecting keys
- Picking up hearts
- Opening doors
- Pressing buttons
- Taking damage from certain hazards
- Opening the menu
- Game over feedback

Some objects use their own AudioSource components so that different interactions can have their own sound effects.

---

## 13. Game Menus

### Pause Menu

The player can press Esc to open or close the pause menu. When the menu is open, the cursor is unlocked and time is frozen. When the player exits the menu, the cursor is locked again and gameplay resumes.

### Game Over Menu

The game over menu appears when the player health reaches 0. Time is frozen and the cursor is unlocked.

### Game Win Menu

The game win menu appears when the player successfully collects all gems. Time is frozen and the cursor is unlocked.

---

## 14. How to Complete the Game / Answer Key

To complete the game:

1. Explore the dungeon carefully.
2. Collect coins to increase score.
3. Collect keys when found.
4. Use the correct keys to unlock locked doors.
5. Avoid the laser wall, toxic gas, boulder, and goblin hazards.
6. Press buttons where needed to disable or affect certain obstacles.
7. Collect hearts if health is low.
8. Find and collect all gems.
9. Once all gems are collected, the game win screen will appear.

### Puzzle / Interaction Notes

- Locked doors require their matching key.
- If a door is locked, the UI will show that it requires a key.
- Some buttons may affect hazards or hidden areas.
- Secret buttons are tracked separately. Finding the required secret buttons can trigger a secret event.

---

## 15. Game Hack / Testing Notes

There is no separate cheat code implemented in the game.

For testing purposes in the Unity Editor:

- Collect all gems to trigger the win condition.
- Set the player's health higher in the Inspector if more time is needed for testing hazards.
- Lower hazard damage values in the Inspector if testing movement or level flow.
- Move the player near locked doors or collectible objects in the Scene view to test specific interactions faster.
- Temporarily disable hazard GameObjects if only testing doors, collectibles, or UI.

---

## 16. Known Limitations / Bugs

These are the current limitations or things to take note of:

- The project is designed mainly for Windows desktop and has not been tested for mobile or web builds.
- Some UI prompt messages may stay visible until another interaction or raycast update changes them.
- Hazard damage values may need balancing depending on how difficult the level should feel.
- Some interactions depend on objects being correctly assigned in the Unity Inspector, such as door keys, button links, UI text fields, and AudioSource components.
- If an object is missing its assigned reference, that specific interaction may not work as intended.
- Asset audio volume levels may need adjustment depending on the build settings or speaker volume.
- The game is intended as a basic 3D player experience rather than a full polished commercial game.

---

## 17. References and Credits

The project uses a mix of self-created gameplay logic and Unity/third-party assets.

### Unity Packages / Built-in Systems

- Unity Engine
- Universal Render Pipeline
- Unity Input System
- TextMeshPro
- ProBuilder
- Unity UI
- Unity Physics
- Unity Starter Assets / First Person Controller

### Asset Folders Used in Project

The project includes assets from folders such as:

- [Player Controller: Starter Assets](https://assetstore.unity.com/packages/essentials/starter-assets-character-controllers-urp-267961)
- [Simple item & gems pack](https://assetstore.unity.com/packages/3d/props/simple-gems-and-items-ultimate-animated-customizable-pack-73764)
- [Elementary Dungeon Pack Lite](https://assetstore.unity.com/packages/3d/environments/dungeons/lite-dungeon-pack-low-poly-3d-art-by-gridness-242692)
- [Goblin character assets](https://assetstore.unity.com/packages/3d/characters/goblin-lowpoly-animation-311643)
- [Free Casual Game SFX Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)

All third-party assets are used for educational purposes for this assignment. Any external assets, models, textures, materials, or sounds used in the final project should be credited according to their original source and license.

---

## 18. Final Notes

This project was built as an individual assignment for I3E Assignment 1. My main focus was to create a complete basic 3D player experience with working gameplay systems instead of only focusing on visuals.

The main systems I focused on were:

- Raycast-based interaction
- Collectibles
- Scoring
- Inventory
- Locked doors
- Health
- Hazards
- UI feedback
- Audio feedback
- Win and game over states
- Clean project organization and GitHub tracking

Overall, this project helped me understand how different gameplay systems communicate with each other in Unity, especially how the player interaction system, managers, UI, collectibles, doors, inventory, health, and hazards connect together.
