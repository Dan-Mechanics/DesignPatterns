using UnityEngine;

public class CreateObjectCommand : ICommand
{
    private readonly GameObject prefab;
    private readonly Vector3 position;
    private readonly Quaternion rotation;
    private GameObject instance;

    public CreateObjectCommand(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        this.prefab = prefab;
        this.position = position;
        this.rotation = rotation;
    }

    public void Execute()
    {
        if (instance != null)
            return;

        instance = Object.Instantiate(prefab, position, rotation);
    }

    public void Undo()
    {
        if (instance == null)
            return;

        Object.Destroy(instance);
        instance = null;
    }
}
