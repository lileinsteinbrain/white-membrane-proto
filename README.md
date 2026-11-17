# White Membrane (prototype)

## What this is
A Unity mobile/XR prototype of the White Mask series: a face-like membrane that shifts between identities when it is touched, exploring how being read by others changes how a face presents itself.

## Input
- Taps and double-taps (mouse in the editor, touch on device)

## Processing
- `StateManager` holds a single app state: **Idle → Face1 → Face2 → Abstract**
- `GestureManager` turns taps / double-taps into state transitions
- Other components subscribe to state changes through an event

## Output
- `FaceMaterialController` swaps the membrane's material for each state
- `HUDController` shows the current state on screen

## Project
- Unity **6000.0.30f1**, XR Plug-in Management enabled, iOS build target
- Main scene: `Assets/Scenes/FaceScene.unity`

## Related
- [whitemask-phasefield](https://github.com/lileinsteinbrain/whitemask-phasefield): phase-field model of the same mask
- [gazing-attention](https://github.com/lileinsteinbrain/gazing-attention): sensor-driven physical version
