# Validation notes

## Scope

Source and configuration review only. No Unity Editor, gameplay session, build, or external service was run. Documentation changes do not modify scripts, scenes, packages, or assets.

## Source observations

- `PlayerHealthController.Start` initializes health to `maxHealth - 50`. Confirm the intended starting health and Inspector value; small maximum values can produce a nonpositive start.
- Damage clamps health to zero, but the zero-health branch contains only a comment. No death, restart, or loss flow is implemented in that method.
- Health initialization accesses UI fields assigned in `UIController.Start`. Confirm initialization order or Inspector assignments; execution order was not verified.
- The menu overlay changes UI visibility and cursor state without stopping time or gating player input. Do not describe it as a full gameplay pause.
- `UIController.hidePause` subtracts `CursorLockMode.Locked` from the current cursor state rather than explicitly assigning it. Verify cursor capture after resuming.
- Jumping is blocked while the current animation state has the `isWalking` tag. Check intended movement/jump combinations and Animator tags.
- `EventController` looks up and hides `WinMenu` only when its own object is named `triggerDoor`; its trigger callback uses that reference regardless. Check every instance and assignment.
- `SceneController` persists across scenes without a duplicate-instance guard. Check transitions and repeated scene entry.
- Damage triggers require the Player tag and a PlayerHealthController on the contacted object. Impact audio also requires an assigned AudioSource.

These observations identify paths to test, not reproduced runtime failures.

## Suggested playtest

1. Import with Unity 2020.3.33f1 and confirm package resolution and compilation.
2. Exercise MainMenu, Level1, and Level2 navigation and any bound menu buttons.
3. Check movement, camera limits, jumping, running, ground layers, and animation transitions.
4. Check damage intervals, health UI, initial health, and the intended zero-health outcome.
5. Check Escape/resume cursor behaviour, trigger-driven win UI, and collision audio.
6. Review bundled asset rights and perform a separate history/credential review before publication.

Relative documentation links and enabled build scene paths are checked against tracked files. This is not a release certification or publication security audit.
