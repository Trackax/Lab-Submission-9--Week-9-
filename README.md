Donovan Peckham

I used an object pool for the projectiles. They deactive after a few seconds, so they can be reused instead of floading the game with entities.
I used the builder to spawn in different variations of the targets, each of them having a different speed and give different amounts of points.
I used an observer for the score system, so the score increases whenever a projectile collides with a target.
