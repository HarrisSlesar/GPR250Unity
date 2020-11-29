using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Particle2DLink : MonoBehaviour
{
    float mLength = 1f;
    public int id1, id2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateContacts(GameObject object1, GameObject object2)
    {
        if (object1 == null || object2 == null)
            return;
        Debug.Log("contact created");

        float currentLength = getCurrentLength(object1, object2);
        Debug.Log(currentLength);
        if (currentLength == mLength)
        {
            return;
        }
        Vector3 normal = object2.transform.position - object1.transform.position;
        Vector3.Normalize(normal);
        float penetration = 0;
        if (currentLength > mLength)
        {
            penetration = (currentLength - mLength)/100;
        }
        else
        {
            normal = normal * -1.0f;
            penetration = (mLength - currentLength)/100;

        }
        Particle2DContact contact = new Particle2DContact();
        contact.create(object1, object2, 0.0f, normal, penetration, new Vector2(0,0), new Vector2(0, 0));

        ContactResolver.contacts.Add(contact);

    }

    float getCurrentLength(GameObject obj1, GameObject obj2)
    {

        float distance = Vector3.Distance(obj1.transform.position, obj2.transform.position);
	    return distance;
    }
}
