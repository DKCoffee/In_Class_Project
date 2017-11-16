using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiController : MonoBehaviour
{
    [SerializeField]
    private Transform[] gunsTransformList;
    [SerializeField]
    private float timeToFire = 2;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletVelocity = 10;

    private GameManager gameManager;

    private Animator animator;

    int numberFlasch = 1;

    private bool fire;

	// Use this for initialization
	void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(Fire());
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if(fire == true)
        {
           // animator.SetBool("EnnemyAttack", true);
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToFire);
            animator.SetTrigger("EnemyAttack");
            foreach (Transform t in gunsTransformList)
            {
                GameObject bullet = Instantiate(bulletPrefab, t.position, t.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = t.right * bulletVelocity;
                Destroy(bullet, 5);
                
                
            }

        }  
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HitPlayer")
        {
            numberFlasch++;
            Destroy(collision.gameObject);
            StartCoroutine(Flasch());
            Flasch();
            gameManager.EnemyDie();
        }
    }

    private IEnumerator Flasch()
    {
        for (int i = 0; i < numberFlasch; i++)
        {
            
            
            GetComponent<SpriteRenderer>().color = Color.clear;
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(.1f);

        }
    }
}
/*
private IEnumerator Fire()
{
    while (true)
    {
        yield return new WaitForSeconds(timeToFire);

        foreach (Transform t in gunsTransformList)
        {
            GameObject bullet = Instantiate(bulletPrefab, t.position, t.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = t.right * bulletVelocity;
            animator.SetTrigger("Attack");
            Destroy(bullet, 5);

        }
    }
}*/