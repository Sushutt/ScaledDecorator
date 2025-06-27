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
| assetBundle  | Content Cell  |
| prefab  | Content Cell  |
| localPosition  | Content Cell  |
| rotatesWithParent  | Content Cell  |
| rotation  | Content Cell  |
| rotationSpeed  | Content Cell  |
| parent  | Content Cell  |
