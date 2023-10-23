using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IceShowerSpell : Spell
{
    public int damagePerTime;
    public float timeBetweenDamage;

    public override void CastSpell(Camera cam)
    {
        base.CastSpell(cam);
    }
    
    public void Update()
    {
        duration -= Time.deltaTime;
        if(duration <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(DamagePerTime(other));
        }
    }

    IEnumerator DamagePerTime(Collider other)
    {
        other.GetComponent<EnemyHealth>()?.TakeDamage(damage);
        
        while (duration > 0 && other != null)
        {
            other.GetComponent<EnemyHealth>()?.TakeDamage(damagePerTime);
            yield return new WaitForSeconds(timeBetweenDamage);
        }
    }
}
