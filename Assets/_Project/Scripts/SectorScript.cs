using UnityEngine;

public class SectorScript : MonoBehaviour
{
    public bool Isgood = true;
    public Material GoodMaterial;
    public Material BadMaterial;

    private void Awake()
    {
        UpdateMethod();
    }

    private void UpdateMethod()
    {
        GetComponent<Renderer>().sharedMaterial = Isgood ? GoodMaterial : BadMaterial;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);

        if (dot < 0.5) return;

        if (Isgood) player.Bounce();
        else player.Die();

    }
    private void OnValidate()
    {
        UpdateMethod();
    }
}
