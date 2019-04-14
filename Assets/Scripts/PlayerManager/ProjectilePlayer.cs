using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// projectile
/// </summary>
public class ProjectilePlayer : MonoBehaviour
{
    private Transform target;
    private int projectileDamage;
    public float speed = 20f;
    public Rigidbody2D rb;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        projectileDamage = 20;
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        //direction to launch 
        target = PlayerManager.instance.player.GetComponent<PlayerBehaviour>().GetClosestEnemy();
       
    }
    private void Update()
    {
        direction = target.position - transform.position;
        rb.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if(hitInfo.transform.tag == "Enemy")
        {
            hitInfo.GetComponent<EnemyController>().ReceivingDamage(projectileDamage);
            Destroy(gameObject);
        }
    }


}
