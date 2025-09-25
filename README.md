# PlanA test for Alan Gaspar

For this test, I implemented an MVC architecture to clearly separate the game logic from the visuals. The entire logic runs independently of any visual representation, making it possible to swap the current grid gameplay for another visual layer with minimal effort or use the same visuals for another gameplay based on a grid.

I would have liked to polish the game further, but due to time constraints I had to prioritize core features. I hope this demonstrates my approach to clean architecture and maintainable code. Looking forward to your feedback!

## Plugins used:
	•	Extenject – for Dependency Injection
	•	UniTask – for async operations

## Potential Improvements:
	•	Improve handling of game reloading/reset
	•	Replace Actions with UniRX observables for state communication
	•	Add animations for smoother player feedback
	•	Implement an AudioManager for sounds and music
	•	Add particle effects for visual polish
	•	Move the collider to a child object of the board element to mantain the prefab structure cleaner
	•	Create a proper GameManager for centralized flow control
	•	Organize the project into assemblies for cleaner separation

## What I think about the test:
	•	The limited time frame made the final stretch intense, but also fun
	•	It was a great opportunity to showcase my coding style and how I structure projects.
	•	I focused on making the core logic flexible and maintainable.
