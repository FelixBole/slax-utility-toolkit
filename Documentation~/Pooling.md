# Object Pooling

This section might move in its own package if Pooling becomes bigger.

## Overview

The `ObjectPool<T>` class is a generic object pool implementation for Unity's `MonoBehaviour` objects. Object pools are used to optimize performance by reusing instances of frequently instantiated and destroyed objects, such as bullets, enemies, or effects, rather than creating and destroying them repeatedly.

By using object pools, you can improve the performance of your game by reducing memory allocations and garbage collection overhead, which can lead to smoother gameplay.

## ObjectPool<T>

### Features:

- **Generic Pool**: Works with any `MonoBehaviour` object type.
- **Memory Efficiency**: Objects are recycled rather than instantiated and destroyed frequently.
- **Automatic Resizing**: Instantiates new objects when the pool runs out.
- **Custom Parent Transform**: Optionally parent all pooled objects under a single GameObject to keep the hierarchy clean.

### Constructor:

```csharp
ObjectPool(T prefab, int initialSize, Transform parent = null)
```

- **`prefab`**: The `MonoBehaviour` prefab to pool.
- **`initialSize`**: The initial number of objects to preload into the pool.
- **`parent`** *(optional)*: The parent `Transform` to group all pooled objects under (e.g., for scene organization).

### Methods:

#### `T GetFromPool()`
Retrieves an object from the pool, activating it in the scene. If the pool is empty, a new object is instantiated.

#### `void ReturnToPool(T obj)`
Returns an object to the pool, deactivating it in the scene.

### Example Usage

```csharp
public class BulletManager : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    private ObjectPool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(bulletPrefab, 20, this.transform);
    }

    public void Shoot(Vector3 position, Quaternion rotation)
    {
        Bullet bullet = bulletPool.GetFromPool();
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.Init();
    }

    public void ReturnBullet(Bullet bullet)
    {
        bulletPool.ReturnToPool(bullet);
    }
}
```

## Benefits of Object Pooling

- **Performance**: Object pooling significantly reduces the overhead of memory allocation and garbage collection, which is especially beneficial for games with a large number of short-lived objects (e.g., bullets, particles).
- **Memory Management**: Pooling helps manage memory by limiting the number of object instantiations and destructions, which can result in more predictable performance.
- **Flexibility**: The pool can grow dynamically if needed, but having a reasonable initial size minimizes the need for frequent object instantiation.
