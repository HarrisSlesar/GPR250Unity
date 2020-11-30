using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactResolver : MonoBehaviour
{
    
    
	private int mIterations;
    // Start is called before the first frame update
    void Start()
    {
		mIterations = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	public void resolveContacts(List<GameObject> contacts)
	{
		mIterations = 10;
		int mIterationsUsed = 0;
		while (mIterationsUsed < mIterations)
		{
			float max = float.MaxValue;
			int numContacts = contacts.Count;
			int maxIndex = numContacts;
			for (int i = 0; i < numContacts; i++)
			{
				float sepVel = contacts[i].GetComponent<Particle2DContact>().calculateSeparatingVelocity();
				if (sepVel < max && (sepVel < 0.0f || contacts[i].GetComponent<Particle2DContact>().mPenetration > 0.0f))
				{
					max = sepVel;
					maxIndex = i;
				}
			}
			if (maxIndex == numContacts)
				break;

			contacts[maxIndex].GetComponent<Particle2DContact>().resolve();

			for (int i = 0; i < numContacts; i++)
			{
				if (contacts[i].GetComponent<Particle2DContact>().mObj1 == contacts[maxIndex].GetComponent<Particle2DContact>().mObj1)
				{
					contacts[i].GetComponent<Particle2DContact>().mPenetration -= Vector2.Dot(contacts[maxIndex].GetComponent<Particle2DContact>().mMove1,contacts[i].GetComponent<Particle2DContact>().mContactNormal);
				}
				else if (contacts[i].GetComponent<Particle2DContact>().mObj1 == contacts[maxIndex].GetComponent<Particle2DContact>().mObj2)
				{
					contacts[i].GetComponent<Particle2DContact>().mPenetration -= Vector2.Dot(contacts[maxIndex].GetComponent<Particle2DContact>().mMove2, contacts[i].GetComponent<Particle2DContact>().mContactNormal);
				}

				if (contacts[i].GetComponent<Particle2DContact>().mObj2)
				{
					if (contacts[i].GetComponent<Particle2DContact>().mObj2 == contacts[maxIndex].GetComponent<Particle2DContact>().mObj1)
					{
						contacts[i].GetComponent<Particle2DContact>().mPenetration += Vector2.Dot(contacts[maxIndex].GetComponent<Particle2DContact>().mMove1, contacts[i].GetComponent<Particle2DContact>().mContactNormal);
					}
					else if (contacts[i].GetComponent<Particle2DContact>().mObj2 == contacts[maxIndex].GetComponent<Particle2DContact>().mObj2)
					{
						contacts[i].GetComponent<Particle2DContact>().mPenetration -= Vector2.Dot(contacts[maxIndex].GetComponent<Particle2DContact>().mMove2, contacts[i].GetComponent<Particle2DContact>().mContactNormal);
					}
				}
			}
			mIterationsUsed++;
		}
		for(int i = 0; i < contacts.Count; i++)
		{
			Destroy(contacts[i]);
		}
		contacts.Clear();
	}
}
