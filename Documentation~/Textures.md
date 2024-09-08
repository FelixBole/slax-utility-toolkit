# Textures

This section goes over the methods available in the different texture classes for texture manipulation and creation in Unity.

## `Texture2DHelper` Methods

| Method Name | Description | When to Use |
| --- | --- | --- |
| `ScaleTexture` | Scales a `Texture2D` to the specified width and height. | Use this method when you need to resize an existing texture. |
| `TextureToSprite` | Converts a `Texture2D` to a `Sprite`. | Use this method when you need to convert a texture into a sprite. |
| `FillTexture` | Fills an existing `Texture2D` with a solid color. | Use this method to reset or fill a texture with a uniform color. |

### Example Usage:

```csharp
// Scale a texture
Texture2D scaledTexture = Texture2DHelper.ScaleTexture(originalTexture, 256, 256);

// Convert a texture to a sprite
Sprite newSprite = Texture2DHelper.TextureToSprite(someTexture);

// Fill a texture with a solid color
Texture2DHelper.FillTexture(existingTexture, Color.red);
```

---

## `Texture2DMaker` Methods

### Basic Textures

| Method Name | Description | When to Use |
| --- | --- | --- |
| `MakeSolidColorTexture` | Creates a new texture with a specified width, height, and color. | Use when you need a simple texture of a single, solid color. |
| `MakeCheckerboardTexture` | Creates a checkerboard pattern texture with two colors, width, height, and cell size. | Use for textures with a regular alternating pattern (e.g., chessboard). |

### Gradient Textures

| Method Name | Description | When to Use |
| --- | --- | --- |
| `MakeHorizontalGradientTexture` | Creates a horizontal gradient texture from `leftColor` to `rightColor`. | Use when you need a smooth color transition from left to right. |
| `MakeVerticalGradientTexture` | Creates a vertical gradient texture from `topColor` to `bottomColor`. | Use when you need a smooth color transition from top to bottom. |
| `MakeMultiColorGradientTexture` | Creates a gradient texture from a list of colors, evenly distributed across the texture's width. | Use when you need a gradient transitioning between multiple colors. |
| `MakeMultiColorGradientWithSteps` | Creates a gradient texture from a list of colors, with defined steps for each color transition. | Use when you need a gradient with custom steps between color transitions. |

### Example Usage:

```csharp
// Create a solid color texture
Texture2D solidTexture = Texture2DMaker.MakeSolidColorTexture(256, 256, Color.blue);

// Create a checkerboard pattern texture
Texture2D checkerboardTexture = Texture2DMaker.MakeCheckerboardTexture(256, 256, Color.white, Color.black, 32);

// Create a horizontal gradient texture
Texture2D horizontalGradient = Texture2DMaker.MakeHorizontalGradientTexture(512, 256, Color.red, Color.blue);

// Create a vertical gradient texture
Texture2D verticalGradient = Texture2DMaker.MakeVerticalGradientTexture(512, 256, Color.green, Color.yellow);

// Create a multi-color gradient texture
List<Color> colors = new List<Color> { Color.red, Color.green, Color.blue };
Texture2D multiColorGradient = Texture2DMaker.MakeMultiColorGradientTexture(512, 256, colors);

// Create a multi-color gradient texture with steps
List<int> steps = new List<int> { 100, 200, 300 }; // Defines the width of each color transition
Texture2D multiColorGradientWithSteps = Texture2DMaker.MakeMultiColorGradientWithSteps(600, 256, colors, steps);
```

---

## General Tips:

- Use **`Texture2DHelper`** for common utility operations on existing textures, such as scaling or converting them to sprites.
- Use **`Texture2DMaker`** for generating new textures with specific patterns or gradients.
- Both classes allow you to create textures programmatically, which can be useful for procedural generation, UI design, or dynamic asset creation.
