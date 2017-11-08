using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rigid;
    
    [Header("Physics")]
    [SerializeField]
    private float force = 10;

    [Header("Jump")]
    [SerializeField]
    private Transform positionRaycastJump;
    [SerializeField]
    private float radiusRaycastjump;
    [SerializeField]
    private LayerMask layerMaskJump;
    [SerializeField]
    private float forceJump = 1;

    private Transform spawnTransform;

    [Header("Fire gun super sonic lol boum")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float bulletVelocity = 2;
    [SerializeField]
    private float timeToFire = 2;
    private float lastTimeFire = 0;

    private GameManager gameManager;
    

    // Use this for initialization
    void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        spawnTransform = GameObject.Find("Spawn").transform;
        gameManager = FindObjectOfType<GameManager>();
	}

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 forceDirection = new Vector2(horizontalInput, 0);
        forceDirection *= force;
        rigid.AddForce(forceDirection);
        bool touchFloor = Physics2D.OverlapCircle(positionRaycastJump.position, radiusRaycastjump, layerMaskJump);

        if (Input.GetAxis("Jump") > 0 && touchFloor)
        {
            rigid.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        }
        if (Input.GetAxis("Fire1") > 0)
        {
            fire();
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Limit")
            {
            transform.position = spawnTransform.position;
            gameManager.PlayerDie();
            
            }
            if (collision.tag == "Heart")
            {
            gameManager.Life();
            Destroy(collision.gameObject);
            }
            
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "HitEnemy")
        {
            Destroy(collision.gameObject);
            gameManager.PlayerDie();
        }
    }

    private void fire()
    {
        if(Time.realtimeSinceStartup-lastTimeFire > timeToFire )
        {
            
       
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * bulletVelocity;
        Destroy(bullet, 5);
        lastTimeFire = Time.realtimeSinceStartup;
        
        }
    }
}
