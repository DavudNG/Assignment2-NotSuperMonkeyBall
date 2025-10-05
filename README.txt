GAME: NOTSUPERMONKEYBALL

HOW TO RUN
Run the exe file located in the build folder's zips.

CONTROLS
Not Super Monkey Ball’s controls are basic enough to support full functionality without overcomplicating the learning process. The controls are as follows:
A,D or Left/Right arrow keys to move the player left and right
Space Bar to jump
Space Bar while connected to a vertical collision box to jump up the wall
Q to push the ball
E to ‘kick’ the ball in to the air
R to restart the level
ESC to pause the game
Contributions 

Angus:
Three unique levels each with their own gimmick
Unique spritesheet designs for each level with background
Defined start and end points for each level
Obstacles and decorations
Wind system and particle effects for level 3
Custom objects and spriting
Custom spring sprite and physics
Fan object propelling the player and ball away
Particle effects for the fan and wind in level 3
Player and ball HP/Damage system
Player and ball assigned unique health management script
Integration with spikes, creating damage
Player will die after receiving enough damage
Multiple tilemaps and collisions
Main tilemap with ground collisions. Different physics materials for each main object ie. ice has less friction and sand has more. Tilemap colliders
Deco tilemap, displayed on a higher Z order than ground, no collisions
Spike tilemap for spike collisions and damage taking
Barrier tilemap preventing the player from leaving the level
Multiple UI screens based on Julians UI screens
Death screen
Multiple buttons and a restart system
Unique overlay
Level complete screen
Level complete logic - collision with a flag with custom sprite
Buttons to restart the level, go to the next level and go to the main menu
Dyslexia accessibility
OpenDyslexia font support
Option to toggle between normal and dyslexia font, updating all in game text
Use player preferences to keep track of locked/unlocked levels and high scores for each

David 
Physics based Player movement (Playermovement.cs)
Player Attack script
Particle effects 
Player jump particle effect
Kick particle effect
Launch particle effect
	
Animation
Player animation controller statemachine
Player movement animations logic 
PlayerAttack animation controller statemachine 
attack animation setup
Animations events for Kick and launch
Animation clips
Monkey_Move
Monkey_Idle
Monkey_Jump
Monkey_Kick
Monkey_Uppercut
Ball logic
Launch logic
Kick logic 
Hit flash 
Fps cap
FPSCap.cs
Hit flash implementation
Cinemachine setup
Player prefab
Ball prefab

James: 
Teleporting enemies
Allows spawn locations of groups of enemies to be changed
Allows for groups of enemies to be teleported to a specified location
Allows for groups of enemies to be reset to an initial location
Automatic teleportation of enemies to suit the different levels
Enemy AI
Parent enemy AI class created with 2 different movement types
Enemies are able to have back and forth movement
Enemies are able to have movement following the player
Child class created that explodes the player should the player collide
Sound Management
Sound manager prefab created that allows other scripts to play sounds at a specified volume
Altered most of the sounds to fit the theme of the game better
Made the hit, jump, land and launch sounds myself
Heavily altered the hurt and walk sounds from their original sample
Ball.cs plays launch sound when ball is launched
Ball.cs plays hit sound when ball is kicked
PlayerMovement.cs plays jump sound when player jumps
PlayerMovement.cs plays walking sound when player presses a key while grounded
PlayerMovement.cs plays landing sound when player collides with an object
SpawnPlayer.cs plays the level 1 soundtrack when level 1 is loaded
SpawnPlayer.cs plays the level 2 soundtrack when level 2 is loaded
SpawnPlayer.cs plays the level 3 soundtrack when level 3 is loaded
MenuMusic.cs plays the menu music soundtrack when the main menu is loaded
FinishFlag.cs plays the win sound when its OnTriggerStay2D is executed
PlayerHealth.cs plays the hurt sound when the player gets hurt but does not die
PlayerHealth.cs plays the death sound when the player dies
Scene Control
Created a script that allows other scripts to load a different scene when need be
Player movement
Coded the jumping mechanic
Coded the explode mechanic
Coded the explode coroutine to disable player movement when exploded
Coded the isGrounded logic
Reading/Writing to a textfile
Allows a text file with key/value pairs at a certain path within the game files to be manipulated
Text file pair values can be verified with a method that returns a true or false bool based on the text file data
Text file pair values can be returned with a method that returns a string version of the value in a pair in the text file
Text file pair values can be overwritten
Unused code contribution
Created a wide variety of different scripts at the beginning of development that did not get used in the end
BouncePlayer.cs - makes the player jump when grounded on a certain object that the script is attached to
SlipPlayer.cs - makes the player slippery according to the value of “isSlippery” in the text file
SlowPlayer.cs - makes the player slowed according to the value of “isSlowed” in the text file
Powerup.cs - changes the jump height of the player should the player collide with the object this script is attached to

Julian:
Main Menu
Animations
UIMonkey.anim
UIBallScript.cs
Buttons
Custom font
Level Select
Levels 2 and 3 locked at the beginning of the game
LevelSelection.cs
Level select screen displays level high scores
Menu animation
TextPulseScript.cs
Settings Menu
Allows the player to reset the highscores of each level
“HUD”
Level timer
LevelTimerScript.cs
Timer linked to High Score, remaining time becomes high score
Frozen Status
Frozen status image appears on the top left of screen when ball is frozen
Ball colour is changed when frozen to match status image
Ball become blue
Goals
Player hitting the goal post unlocks the next level and moves player to next level scene
Enemies
Created Ice enemy that freezes the ball
Added animation to the ice enemy, when ball collides with enemy attack, ball is “frozen” and loses all velocity
Pause Menu
Allows player to pause the game
Allows player to back out of the level and return to main menu
Pause menu freezes all game logic
Prefabs
Menu element prefabs
Manager prefabs (scene manager, game manager, timer manager)
Pause menu prefab
Screen Size
Game UI + overlay is made constant so it changes based on user device screen size.


Requirements:

Game states: Main Menu → Level Select → Gameplay → Pause → Game Over or Win. Use a simple state manager.

Our game does not function using a single centralised Game state manager, but instead has multiple scripts that keeps track of the states via different stages. The game begins with the Main menu and allows the user to choose either to start the game, enter the settings menu or change the game font. Selecting to begin the game starts the level select script which checks which levels are locked and which are available to the player. Selecting a level begins the next state which runs the level and timer script, keeping track of the player’s current level and score. There is a pause scene script that is run when the player presses the “escape” key which allows the user to return to the first state, the main menu. After successfully beating or failing the level, the final state script is run which determines if the player has beaten the game in its entirety, unlocked the next level or is required to retry the current level.





Levels: 

Our game adheres to this requirement by supporting 3 unique levels, each with unique gimmicks and design choices. The levels were intentionally kept short, however a certain degree of difficulty was maintained to support replayability. 

By default, level 1 is unlocked and levels 2 and 3 are locked. After beating level 1, level 2 will unlock, and level 3 will unlock after beating level 2. This is tracked through Player Preferences in Unity, as this method is simple to implement and requires no file and permissions management.

Each level has an accompanying high score value which is also stored in player prefs. The high scores, as well as the locked/unlocked status of each level can be seen in the level select scene.


Points and Heads-Up Display (HUD):

In our game, a HUD is present that allows the user to see how much time they have remaining in the level and an indicator that lets the player know whether the ball has any status effects applied to it. The points are based on the time remaining for each level and the quickest time to beat the level is displayed on the level select. The settings menu also allows the user to reset all the scores for each level. When the timer reaches 0, the player loses the level and is prompted to either restart the level or return to the main menu.

Our game also implements a pause menu that allows the player to pause the game and return to the title screen if they desire. The death screen and level completion screen also have options to return to the main menu, but they also incorporate buttons that allow the user to retry the level or move on to the next.

Level Select: 
	
Our game incorporates a “Level Select” mechanism that allows the player to select the level they wish to play. This screen begins with level 2 and 3 locked, and unlocks levels when the player progresses. The level select screen also incorporates a way for the user to view their high score for each level, and is updated if the user beats the level quicker than their previous attempt.

The level select screen implements a Scene Manager that is used to refer to Player Prefs to check whether or not the player has beaten any levels. This is used to keep inaccessible levels locked until the player beats the level before it. The Scene Manager also handles the High Scores and updates the text accordingly.


Physics and collisions: correct Layer Collision Matrix. Use at least four Physics Materials on colliders.

Physics materials
1 Ball physics material 
Settings:
	Friction: 0.4
bounciness : 0  
Desc: material used on the ball

2. testbounce material ( player) 
Settings:
Friction: 0.4
bounciness : 0  
Desc: material used on the player
3. Grass physics
	Settings:
Friction: 0.25
bounciness : 0.1
Desc: material used for Grass stage terrain 
4. Ice Physics 
	Settings: 
Friction: 0
bounciness : 0 
Desc: material used for ice stage terrain 
5. Sand physics
	Settings:
Friction: 100
bounciness : 0 
Desc: material used for sand stage terrain 
Modular systems: 

Health - Simple health script to handle the player’s hp and dying, as well as hitflash when they take damage
Attack - attack script that sets a cooldown for 2 attack functions: kick and launch, ray casts forward and back to check for objects hit and applies the correct method on them, handles animation logic too
Spawn - spawn script to move groups of enemies using serialized fields for the enemies moved, and functions for changing their spawn location, resetting it, and teleporting them to that location

Animations and feedback: basic animations plus clear feedback on hit, collect, win and lose.

Player Animations: 
The player has idle, move, jump animations as well as 2 attack animations for kick and upper cut
	
Hitflash:
When the ball is hit and when the player takes damage they flash a colour, white and red respectively. 

Sound fx : When the player does various actions a sound effect plays for feedback

Menu pop up and pause: When the player dies the contextual menu pops up.

Use a mix of assets:

Our game adheres to this requirement through an extensive set of sprites, mainly sprite sheets. All of the building blocks for each level have been created through sprite sheets and unity’s tilemap functionality. 

The main sprite sheet has been sourced from itch.io, and was created by BigManJD, available for free [2]. These tiles were the inspiration for much of level 1’s design. 

The main character sprite was sourced from Itch.io by ccaropng [1], which had various animations attached. This spritesheet was available for free.

For level 2, a simple filter was applied over the same spritesheet used in level 1 to make all the green colours white. This along with some photoshop and drawing on PNG files created a snowy theme for level 2. 

Ice blocks were sourced from Starter Tiles by SciGho [6] on itch.io. These sprites were available for free.

Level 3 uses a unique set of desert spritesheets made by user Lil Cthulhu on itch.io [7] [8]. These sprites are available for free. 

A singular fan sprite sourced for free from itch.io was used in level 3 and uploaded by Missing Rice [9]. This sprite was stretched using photoshop's perspective tool and turned into an animation for the fan in level 3.

Finally, various assets including the spring and end-of-level flag were designed by Angus using photoshop.

Attack Sprite: Free Slash Sprite Cartoon Effects by craftpix

Published WebGL build, on itch.io

Majority of the sounds in the game other than the soundtracks ([16], [17], [18], [19]), the death sound [15] and win sound [14] were created by James using FL Studio or had their original samples heavily changed by James. The ones created by James include the hit, jump, land and launch sounds, while the ones heavily changed include the hurt [15] and walk [13] sounds.


Innovation features

Juice pack:

Hitflash 
	When the ball is hit it flashes white
Jump particles 
when the player jumps it is wired to play jump effect particles

Damage flash on player damage
	When the player takes damage it flashes red
Freeze
	When the ball is frozen it turns blue

Tilemap implementation

Multiple tilemaps were used in the creation of Not Super Monkey Ball. Tilemaps are a simple and effective way to use spritesheets in Unity: By slicing spritesheets and placing them in to a tile palette, tiles can be drawn on to the scene editor in a grid. This allowed for really easy level editing and creation as tiles can be separated in to each theme and simply drawn where they need to go

Alongside a tilemap, tilemap colliders and composite colliders were used to create the actual collision boxes. Tilemap colliders create a collision box around each individual tile, however this was creating some jagged edges meaning the player would seemingly get stuck on nothing. Therefore, a composite collider was used to create one big collision box around all tiles which was much smoother.

Multiple tilemaps were used in the creation of each level, including:

main tilemap - used for the main building blocks in each level.
decoration tilemap - used for the decoration and background elements as these could not have a collision box.
spike tilemap - used for the spikes as they needed certain collision rules.
barrier tilemap - used for the invisible barriers at the end and beginning of each level, ensuring the player could not leave the map.
ice tilemap - Used for ice blocks in level 2 as they needed specific friction rules.

Using multiple tilemaps allowed for segregation of physics features and collision boxes, as well as simple editing for each level. 

Sounds were created for this project by James using FL Studio. These include the hit, jump, land and launch sounds. Other sounds were heavily changed by James from their original sample to better fit the theme of the game including the hurt [15] and walk [13] sounds.



Accessibility - adherence to Dyslexic players

A core idea of our game was centered around accessibility for all players. As a prt of this adherence, the fonts of the game are able to be toggled between a dyslexia friendly font and a regular stylistic font. The font chosen for the dyslexia option was OpenDyslexia, created by Abbie Gonzales and available on itch.io [10]. 

OpenDyslexia is a font specifically designed to help Dyslexia affected people to read digital text easier. By adhering to this requirement our game has been made much more accessible to people affected by Dyslexia.

On a technical level, this was achieved by creating a script assigned to all text elements in Unity. This script would read from a Player Pref, which can be changed through a toggle in the settings menu, and update the text accordingly. This change can be done in runtime and does not affect performance in any way. 


ISSUES:

Dyslexia Toggle

The dyslexia toggle system works by swapping the font of all TMP elements in the game depending on the value of a toggle. However, the toggle has trouble indicating what the internal value of what font should be displaying is. The toggle may show the value of true, while the dyslexia font is not being used and vice versa. The core functionality of switching fonts works appropriately.
Soft Lock in level 3

Under specific circumstances the player can get soft locked in a specific area in level 3. Some of the hitboxes are a little bigger than they should be and the player/ball can get stuck in a corner.  A temporary workaround involves restarting the level using ‘r’.

Incomplete level balancing

A few of the game's systems, such as damage and enemies were created asynchronously, meaning some of the design choices were based on assumptions that did not end up working out as expected. This is quite clear with the level design, the integration of enemies and spikes are incomplete as it was decided that the enemies purely be obstacles rather than killable entities. Spikes were created with the assumption that the ball should be popped, however with that functionality the game was far too difficult and hence has been removed. The spikes are now semi-obsolete. 
Level 3 Instant Ball Spike Collision Death

In level 3, should the ball collide with the spikes found in it, it will instantly kill the player, showing the “You Died” screen and playing the associated sounds. This is abnormal, as in the rest of the levels, the ball simply bounces off the spikes, without hurting the player in any way by colliding with them.


Resource credits

[1] Monkey Forest Asset Pack
Author: ccaropng
Link: https://ccaropng.itch.io/monkey-forest-asset-pack

[2] Pixelart platformer pack
Author: biggermanjd
Link: https://biggermanjd.itch.io/platformer-tileset-pixelart-grasslands

[3] Retro Impact Effect Pack All
Author: BDragon1727
Link: https://bdragon1727.itch.io/retro-impact-effect-pack-all

[4] Daydream Font
Author: DoubleGum
Link: https://www.dafont.com/daydream-3.font?l[]=10&l[]=1&l[]=6

[5] Mystic Woods
Author: Game Endeavor
Link: https://game-endeavor.itch.io/mystic-woods

[6] Starter Tiles
Author: SciGho
Link: https://ninjikin.itch.io/starter-tiles
[7] Pixel Art Tileset Desert
Author: Lil Cthulu
Link: https://lil-cthulhu.itch.io/pixel-art-tileset-desert
[8] Pixel Art Desert Background
Author: Lil Cthulu
Link: https://lil-cthulhu.itch.io/pixel-art-desert-background


[9] 16x16 Pixel Warehouse Asset Pack
Author: Missing Rice
Link: https://missingrice.itch.io/16x16-pixel-warehouse-asset-pack

[10] OpenDyslexic
Author: AbbieGonzales
Link: https://antijingoist.itch.io/opendyslexic

[11] Free Slash Sprite Cartoon Effects
Author: CraftPix
Link: https://craftpix.net/freebies/free-slash-sprite-cartoon-effects/?srsltid=AfmBOopP915tOxnj5qItvblQTZGDPV8BnEfImZELKhTlnV0MO2RYOg7k

[13] Foot walking step sounds on stone, water, snow, wood and dirt
Author: Jute
Link: https://opengameart.org/content/foot-walking-step-sounds-on-stone-water-snow-wood-and-dirt

[14] Game Start
Author: plasterbrain
Link: https://pixabay.com/sound-effects/game-start-6104/

[15] Dying sound
Author: u_ckpn52p1rm
Link: https://pixabay.com/sound-effects/dying-sound-363801/

[16] Waiting Time
Author: Lesiakower
Link: https://pixabay.com/music/video-games-waiting-time-175800/

[17] 356 | 8-Bit Chiptune Game Music
Author: nickpanek
Link: https://pixabay.com/music/video-games-356-8-bit-chiptune-game-music-357518/

[18] Multi Boss | Fast-Paced 8-Bit Chiptune
Author: nickpanek
Link: https://pixabay.com/music/video-games-multi-boss-fast-paced-8-bit-chiptune-358679/

[19] Cheerful Simple Music
Author: ArthurHale
Link: https://pixabay.com/music/modern-classical-cheerful-simple-music-308483/



