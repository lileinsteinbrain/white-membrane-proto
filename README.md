# White Membrane

**An XR prototype of a face-like membrane that changes identity each time you touch it, from a neutral surface to two faces to an abstract form.**

Part of the **White Mask** series → see also [gazing-attention](https://github.com/lileinsteinbrain/gazing-attention) (physical mask) and [whitemask-phasefield](https://github.com/lileinsteinbrain/whitemask-phasefield) (simulation).

## The idea
The White Mask series is about how being perceived shapes the face we present. This prototype explores that on a phone or headset: a white membrane sits in front of you, and each touch makes it present a different "version" of itself. It is a quick, tangible way to test how a face reads as it moves between neutral, specific and abstract.

## How it works
- **Tap** → move to the next state: Idle → Face 1 → Face 2 → Abstract
- **Double tap** → return to Idle
- A small state machine (`StateManager`) broadcasts each change; the membrane's material and an on-screen label update in response

## What's in this repo
| Path | What it is |
|---|---|
| `Assets/Scripts/StateManager.cs` | The four states and change events |
| `Assets/Scripts/GestureManager.cs` | Tap / double-tap detection (mouse or touch) |
| `Assets/Scripts/FaceMaterialController.cs` | Swaps the membrane's material per state |
| `Assets/Scripts/HUDController.cs` | On-screen state label |
| `Assets/Scenes/FaceScene.unity` | Main scene |

## Status
Interaction prototype; visuals are placeholders for the final face materials.

## Open it
Unity **6000.0.30f1** with XR Plug-in Management; builds for iOS. Open `Assets/Scenes/FaceScene.unity`.
