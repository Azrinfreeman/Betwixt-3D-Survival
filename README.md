# Betwixt — 3D Survival Prototype

A Unity third-person game prototype set in a hell-themed world. The tracked gameplay scripts cover camera-relative movement, jumping and running, damage and health feedback, a pause-menu overlay, and level transitions.

## Implemented systems

- CharacterController movement with smooth turning, gravity, and ground checks.
- Mouse-controlled orbit camera with a clamped vertical angle.
- Animator parameters for movement, running, and jumping.
- Trigger-based damage with an invulnerability interval and a health display.
- Collision impact audio and a player-triggered win menu.
- An asynchronous transition to `Level2`.

The build configuration lists **MainMenu**, **Level1**, and **Level2**. This overview is based on source inspection; scene wiring, playability, and a complete survival loop have not been verified.

## Open the project

1. Install **Unity 2020.3.33f1**, as recorded in [ProjectVersion.txt](ProjectSettings/ProjectVersion.txt).
2. Clone the complete repository and add its folder in Unity Hub.
3. Open it with the recorded editor and allow [package resolution](Packages/manifest.json) to finish. Declared packages include Cinemachine 2.6.11, ProBuilder 4.5.2, TextMesh Pro 3.0.6, and Unity UI 1.0.0.
4. Review [the build scene list](ProjectSettings/EditorBuildSettings.asset), then open `Assets/Scenes/MainMenu.unity`.
5. Check the console, scene references, input mappings, colliders, and animator configuration before entering Play Mode.

The repository also tracks generated Unity `Library` content and IDE files. These were retained during documentation cleanup; editor import behaviour and builds are untested.

## Controls represented in source

| Action | Input |
| --- | --- |
| Move | Legacy `Horizontal` / `Vertical` axes; inspect Input Manager mappings |
| Orbit camera | Legacy `Mouse X` / `Mouse Y` axes |
| Jump | Legacy `Jump` button, with ground and animation checks |
| Run | Left Shift |
| Toggle menu overlay | Escape |

The menu overlay currently does not suspend simulation. See [validation notes](docs/VALIDATION.md) for limitations and checks before a release.

## Source guide

| System | Source |
| --- | --- |
| Movement and camera | [PlayerController.cs](Assets/PlayerController.cs), [CameraMove.cs](Assets/CameraMove.cs) |
| Damage and health | [MeleeAttack.cs](Assets/MeleeAttack.cs), [PlayerHealthController.cs](Assets/PlayerHealthController.cs) |
| UI and progression | [UIController.cs](Assets/UIController.cs), [EventController.cs](Assets/EventController.cs), [SceneController.cs](Assets/SceneController.cs) |
| Impact audio | [ImpactController.cs](Assets/ImpactController.cs) |

Bundled assets and packages retain their respective terms. This documentation does not add a project-wide licence or establish redistribution rights for models, audio, or other assets.
