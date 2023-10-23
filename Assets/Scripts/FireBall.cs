using Unity.Mathematics;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float fireBallSpeed = 10f;
    public int damage = 20;
    public float lifeTime;

    public ParticleSystem fireExplosion;

    public Vector3 effectSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        effectSpawn = gameObject.transform.position;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(fireExplosion, effectSpawn, quaternion.identity);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
            Instantiate(fireExplosion, effectSpawn, quaternion.identity);
        }
        
    }

    public void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
            Destroy(gameObject);
    }
}
