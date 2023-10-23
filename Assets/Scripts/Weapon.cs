using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float _attackRate = 1f;
    private float _nextAttack = 0f;
    public Vector3 destination;

    public Transform shootingPoint;
    public GameObject fireBall;

    public Camera cam;

    public FireBall FireBall;
    
    public void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _attackRate;
            Attack();
        }
        
    }

    public void Attack()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);
        
        InstantiateProjectile(shootingPoint);
    }

    public void InstantiateProjectile(Transform firePoint)
    {
        var fireBallObj = Instantiate(fireBall, firePoint.position, Quaternion.identity);
        fireBallObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * FireBall.fireBallSpeed;
    }

}
