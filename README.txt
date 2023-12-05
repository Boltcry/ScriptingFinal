All assets made by Crystal

Github repo link:  https://github.com/Boltcry/ScriptingFinal

note: The series of "revert" commits in the Github was me panicking yesterday trying to figure out how edit .asset files to resolve merge conflicts



This is a game using systems from the game Cake Mania with different art. It is controlled on a day-by-day basis. 

The following are contained via scriptables:
- Day data
- Customer data
- Food data

These scriptables are then passed into objects and scripts in the scene to run the game.

Player movement is handled by pathfinding towards nodes preset in the scene. When the player clicks on the screen tasks are added to a Task Manager queue. There are 2 types of tasks: Move Tasks and Clickable Tasks. 
Every click the player will move to the closest node to the mouse position, and if the player is clicking on an interactable, a Clickable Task will be added. Every interactable in the game inherits from a class called ClickableObject.

Since our presentation today I fixed:
- UI having a fixed resolution
- Customers leaving when clicked before they order

