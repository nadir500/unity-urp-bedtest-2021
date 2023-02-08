# Naming Convention for Unity Project

This repository contains a project built with Unity and follows a set of naming conventions for code, prefabs, and other files. The purpose of these conventions is to maintain a clear, organized, and consistent structure for the project, making it easier to navigate and maintain over time.

## Code Naming Convention

The code in this project follows a clear and consistent naming convention to make it easy to identify the purpose and function of each class. The following best practices should be followed when naming classes in the project:

1. Use descriptive names: Use descriptive names for classes that reflect their purpose and function.

2. Use namespaces: Use namespaces to group related classes and avoid naming collisions with other classes in the project.

3. Group related classes: Group related classes into sub-folders within the `Scripts` folder to keep the project organized and easy to navigate.

4. Be consistent with your naming conventions: Consistency is key for maintainability, so make sure to stick to your naming conventions throughout the entire project.

Example:

```
Assets/
  Scripts/
    Character/
      CharacterController.cs
      CharacterAnimator.cs
      CharacterInventory.cs
    GUI/
      GUIHandler.cs
      GUIManager.cs
      GUIInventory.cs
    Inventory/
      InventoryManager.cs
      InventoryItem.cs
      InventorySlot.cs
    Main/
      GameManager.cs
      Main.cs
      SceneLoader.cs
```


## Prefab Naming Convention

The prefabs in this project also follow a clear and consistent naming convention to make it easy to identify the purpose and function of each prefab. The following best practices should be followed when naming prefabs in the project:

1. Use descriptive names: Use descriptive names for prefabs that reflect their purpose and function.

2. Use a prefix or suffix for clarity: Prefix or suffix prefabs with a letter or abbreviation to indicate their type (e.g. "prefab_", "pfb_").

3. Group related prefabs: Group related prefabs into folders to keep your project organized and easy to navigate.

4. Be consistent with your naming conventions: Consistency is key for maintainability, so make sure to stick to your naming conventions throughout the entire project.

Example:

```
Assets/
  Prefabs/
    Characters/
      prefab_PlayerCharacter.prefab
      prefab_N
```

## Rest Of The Files Naming Convention

1. Use meaningful names: Use descriptive names for objects, variables, assets, and folders that reflect their purpose and function.

2. Use a prefix or suffix for clarity: Prefix or suffix assets and objects with a letter or abbreviation to indicate their type (e.g. "model_", "asset_").

2. Group related assets: Group related assets into folders to keep your project organized and easy to navigate. For example, you could have separate folders for 3D models, textures, and audio files.

3. Use a standardized file format: Use a standardized file format for assets, such as .fbx for 3D models and .png for textures.

4. Be consistent with your naming conventions: Consistency is key for maintainability, so make sure to stick to your naming conventions throughout the entire project.


```
Assets/
  Models/
    model_Building.fbx
    model_Tree.fbx
    model_Character.fbx
  Textures/
    texture_Building.png
    texture_Tree.png
    texture_Character.png
  Audio/
    audio_BackgroundMusic.mp3
    audio_Footsteps.wav
  Scripts/
    CharacterController.cs
    GUIHandler.cs
    InventoryManager.cs
  Prefabs/
    prefab_PlayerCharacter.prefab
    prefab_NPC.prefab
```



