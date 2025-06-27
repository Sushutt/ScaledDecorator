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
| rotationSpeed  | The degrees per secondt that the object rotates. Only functions if rotatesWithParent is false. |
| parent  | The name of celestial body that the object is parented to. |

