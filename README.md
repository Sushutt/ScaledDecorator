# ScaledDecorator
A KSP plugin that loads AssetBundles into KSP's ScaledSpace. Can be used to display particles and models at planetary scale.

## Config Format:
Put this into the a .cfg in GameData
```C#
ScaledDecoratorObject
{
    assetBundle = Path/To/AssetBundle.unity3d // Path to the AssetBundle. Below are instructions on making one
    prefab = NAMEOFPREFAB // Name of the GameObject you want to load
    localPosition = 0,0,0 // Position relative to the parent body
    rotatesWithParent = false // Whether or not the prefab rotates with the parent body
    rotation = 0,0,0 // Rotation of the prefab
    rotationSpeed = 0,0,0 // Rotation direction of the prefab
    parent = Sun // Name of the parent body
}
```
More detailed info:
| Value | Description |
| ------------- | ------------- |
| assetBundle  | Filepath to the AssetBundle you wish to load. The path begins at GameData. Below this table are instructions on how to export an AssetBundle from Unity. |
| prefab  | The name of the GameObject within the AssetBundle. This is because AssetBundles load several things (textures, materials, meshes, prefabs) so you have to specify the name of the thing you wish to Instantiate (in this case it should be the name of the prefab)  |
| localPosition  | The position relative to the parent body. |
| rotatesWithParent  | If true, rotation will be locked to rotate with the parent planet. Otherwise it will rotate independently. |
| rotation  | The initial rotation of the object. If rotatesWithParent is true, then the object will be rotated locally within the parent. Otherwise it will be rotated globally. |
| rotationSpeed  | The degrees per second that the object rotates. Only functions if rotatesWithParent is false. |
| parent  | The name of celestial body that the object is parented to. |

## Recommended tools:
### Unity Explorer: https://github.com/KSPModdingLibs/UnityExplorerKSP/releases
* The object is parented in: ``DontDestroyOnLoad/scaledSpace/[parent]/``
* Allows you to edit the position/scale/rotation within KSP for fine tuning (since Unity's coordinates are largely arbitrary)

### "Flare Export:" https://github.com/Kopernicus/flare-export
* The name is a bit reductive, as this unity project can export any kind of AssetBundle. Not just lens flares.
* To export your GameObject, save it as a prefab by dragging it into the Assets folder, then right click the newly made prefab and click "Build Lens Flare Object". Remember to give it a meaningful name and move it into wherever you want within your mod.


## Example uses:
### Particle effects such as jets and comet trails: (The black hole lensing effect is from Singularity!)
<img src=https://github.com/user-attachments/assets/ca213353-6d09-4563-aaf1-8cda1c8df3d9 width=100% height=100%> <img src=https://github.com/user-attachments/assets/668d9ac6-ae26-41c3-b3b4-74b73a839f76 width=100% height=100%> <img src=https://github.com/user-attachments/assets/cf4633ac-4206-42fa-ab12-3b773425f1bf width=100% height=100%>

### Also importing 3d models, but I haven't gotten any examples that don't spoil an event I'm doing yet..

