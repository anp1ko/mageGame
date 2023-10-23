using UnityEngine;

public class Spell : MonoBehaviour
{
    public int damage;
    public int manaCost;
    public float cooldown;
    public float duration;

    public virtual void CastSpell(Camera cam)
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit) && hit.transform.gameObject.CompareTag("Floor"))
        {
            Instantiate(gameObject, hit.point, transform.rotation);
        }
        
    }
}
