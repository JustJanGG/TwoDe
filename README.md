# TwoDe - 2D Game Development Showcase

This project is a university assignment designed to showcase various aspects and mechanics of 2D game development using **Unity** and **C#**.

## Features

The project demonstrates the following key features of 2D game development:

- **Smooth 2D Movement & Basic Combat**  
  Implementing character movement with fluid animations and basic combat mechanics.

- **2D Animations with Sprite Sheets**  
  Using sprite sheets to create dynamic character and object animations.

- **Combat Spells with Sprites & Unity Particle System**  
  Visualizing combat abilities through sprite effects and particle systems for a more immersive experience.

- **Mapping with Tilemaps**  
  Creating levels using Unity's tilemap system for efficient and flexible 2D map design.

- **Parallax Backgrounds**  
  Adding depth and immersion with parallax scrolling for backgrounds.

- **2D Lighting Effects**  
  Enhancing the atmosphere of the game with 2D lighting techniques.

- **Enemy AI**
  Basic Enemy behavior following the Player.

## Developers

- **Jan Haufer**
- **Lennart Petrick**

## Artists

all sprites were provided by
- **Sevarihk** https://aurora-sprites.wixsite.com/main

## Controls

- WASD for movement


- Space Bar for jumping


- Left Click for shooting 


## Challanges and Experiences
Throughout the development of our project, we learnt a lot about developing 2D games in Unity.  

Some examples include: 

- **Player Movement**  
  A lot of fine-tuning of values and variables is required to make the player's movements feel responsive. Getting the right feel for the game takes some time and experimentation, especially when working with the Unity engine and forces. Tricks like coyote time and jump cutting are important to include to remove the stiff movement and make it fair to the player. 

- **2D Animation**  
  Our animations are managed through animation controllers that play animation clips. These clips are set up using sprite sheets. After slicing the sprite sheets into separate sprites, they can simply be put on the timeline of an animation clip and then be played back.   The animation controller then manages what animation clip should be played through parameters that trigger transitions. For more complex animation controllers such as the one used to animate the player, we decided to use blend trees to manage the animation clips. These  mostly operate on a 2-dimensional plane that works like a coordinate system that takes in the speed of the player as the x value and the direction the player is facing as the y value and depending on the resulting coordinate a different animation gets played. Getting   these values just right to look smooth took a lot of trial and error, this cost us a lot more time than we initially expected. 

- **Particle System**  
  The particle system is the part that took some time to find all the necessary options for the use case we wanted. There are many different options and settings available and finding the right one takes time. One problem was adding Light2D components to the particle system as it was not supported. Instead, we decided to use an illuminated material to make the particles visible in the dark. 

- **Auto tiling**  
  The auto tiling allows for very easy and fast level building once set up. This took us a while to figure out and set up properly. The rules needed to set up the rule tiles can be very large in relation to the number of tiles in the tile set. 

- **Parallax Backgrounds**  
  In 2D games Parallax Backgrounds are used to create the illusion of depth. They work by having the background divided into multiple layers that move at different speeds based on the main camera. We used a simple script that multiplies the current camera movement by a certain amount and then moves the current background layer by the resulting amount. With this we managed to achieve the desired feeling of depth in our background. 

- **Lighting**  
  Lighting in 2D works very similar to 3D in Unity. The main difference is having to set up shadow masks. This took us a bit of time to properly figure out until we found an asset that automate the process. For more detailed lighting where we wanted specific shadows, we ended up using freeform lights that allowed us to precisely decide where the light should fall and how deep into our tiles it should reach. 

- **Enemy Ai**  
  Our enemies utilize the Astar pathfinding Project to calculate an effective route to get to our player. It uses a simple grid that can detect where the enemy can and cannot go.  

 

## Notable Tutorials used

https://medium.com/@Code_With_K/parallax-background-in-unity-fd8766d5a9bd 

https://youtu.be/KbtcEVCM7bw?si=gUilNO9L_9OO97or 

 

## Used Assets

https://github.com/Lumos-Github/Auto-add-Shadow-Caster-2D-on-TileMap 

https://arongranberg.com/astar/
