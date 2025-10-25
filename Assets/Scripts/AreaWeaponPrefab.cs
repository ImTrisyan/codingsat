using UnityEngine;

public class AreaWeaponPrefab : MonoBehaviour
{
    public AreaWeapon weapon;
    private Vector3 targetSize;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weapon = GameObject.Find("AreaWeapon").GetComponent<AreaWeapon>();
        targetSize = Vector3.one * weapon.range;
        transform.localScale = targetSize;
        Destroy(gameObject, weapon.duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider) 
    {
        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage(weapon.damage);
        }

    }


}
