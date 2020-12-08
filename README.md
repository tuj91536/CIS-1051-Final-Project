# CIS-1051-Final-Project

<youtubelink>

Our original idea for a final project was a simple maze game made in Unity where the player had to make choices about which path to take and would be met with different outcomes
depending on the path taken. However, as we got into using Unity it seemed like the easiest type of game to make would be a topdown 2D game.

We maintained our original idea by making the game a topdown maze game where the player plays as Link and has to reach the end of a maze filled with enemies to 
save princess Zelda. Our finished project is based on the Unity "Ruby 2D Beginner Tutorial," which gives the bare essentials needed to make a topdown 2D game. 
We used the scripts created in the Ruby tutorial to develop our own scripts with many unique changes. One of the first and most minor changes we made was simply
using Input.GetAxisRaw instead of Input.GetAxis to disable motion smoothing. A more significant change we made was adding code to make both Link and enemies turn red when
damaged, and we also added code to respawn Link in his original position with full health if his health bar ever reaches zero. We also edited the Launch function
taught by Ruby to make four unique Launch functions that fire arrows facing different directions based on the direction that Link is facing. We also added a timer
so that the player has to wait briefly after firing an arrow before they are able to fire another.

We also made changes to the enemy script created in the Ruby tutorial. The first change we made was adding a public health variable so that enemies could be given
different health values easily. We also added code to create more advanced enemies that automatically switch whether they are moving horizontally or vertically
and also are able to fire projectiles with modifications to the Launch function.

The last big change we made was creating a Victory screen that displays when Link saves Zelda, which then automatically causes the game to exit after a few seconds.

Working with the preliminary scripts from the Ruby tutorial gave us a good idea of how to implement new things in our game, such as the basic method of adding a timer variable
that decreased by Time.deltatime, which allowed for many new features to be put into our game like the enemy fireball disappearing after a certain amount of time
and the enemy switching horizontal and vertical movement after a certain amount of time. Coding in c# also got easier the more we worked on the project because
we became more familar with how to use and where to implement the basic functions that are built into Unity that the Ruby tutorial teaches.

The one thing we were not able to accomplish that was in our best case scenario was randomly generating the maze every time the player starts a new game. Instead,
our maze is static and remains the same every time the game is played.

All scripts used in our game have been put in the Game-Scripts branch.
