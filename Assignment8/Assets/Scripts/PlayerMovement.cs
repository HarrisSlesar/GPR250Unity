using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed;
    Vector3 rotate = new Vector3(0, 0, 1);
    public GameObject[] weaponTypes;
    int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            transform.Rotate(rotate * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            transform.Rotate(-rotate * speed * Time.deltaTime);

        }


        if(Input.GetKeyDown(KeyCode.W))
        {
            currentWeapon += 1;
            if(currentWeapon + 1 > weaponTypes.Length)
            {
                currentWeapon = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Fire();
        }

    }


    void Fire()
    {
        GameObject Projectile = Instantiate(weaponTypes[currentWeapon], transform.position, transform.rotation);

        //Add to Game manager list of particles to integrate


        return;
    }


  
}
