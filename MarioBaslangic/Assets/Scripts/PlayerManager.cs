using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health,bulletSpeed;

    bool dead = false;

    public Transform bullet,flooatingText;

   

    Transform muzzle;

    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShhotBullet();
        }
    }

    public void GetDamage(float damage)
    {

        Instantiate(flooatingText,transform.position, Quaternion.identity).GetComponent<TextMesh>().text= damage.ToString();

        if ( (health - damage) >= 0 )
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        AmlDead();
    }

    void AmlDead()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }

    void ShhotBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet ,muzzle.position , Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
    }
}
