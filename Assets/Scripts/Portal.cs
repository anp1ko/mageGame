using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneChangeManager.Instance.ChangeScene("Dungeon");
            
        }
    }
}
