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


	public void resolveContacts(List<Particle2DContact> contacts)
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
				float sepVel = contacts[i].calculateSeparatingVelocity();
				if (sepVel < max && (sepVel < 0.0f || contacts[i].mPenetration > 0.0f))
				{
					max = sepVel;
					maxIndex = i;
				}
			}
			if (maxIndex == numContacts)
				break;

			contacts[maxIndex].resolve();

			for (int i = 0; i < numContacts; i++)
			{
				if (contacts[i].mObj1 == contacts[maxIndex].mObj1)
				{
					contacts[i].mPenetration -= Vector2.Dot(contacts[maxIndex].mMove1,contacts[i].mContactNormal);
				}
				else if (contacts[i].mObj1 == contacts[maxIndex].mObj2)
				{
					contacts[i].mPenetration -= Vector2.Dot(contacts[maxIndex].mMove2, contacts[i].mContactNormal);
				}

				if (contacts[i].mObj2)
				{
					if (contacts[i].mObj2 == contacts[maxIndex].mObj1)
					{
						contacts[i].mPenetration += Vector2.Dot(contacts[maxIndex].mMove1, contacts[i].mContactNormal);
					}
					else if (contacts[i].mObj2 == contacts[maxIndex].mObj2)
					{
						contacts[i].mPenetration -= Vector2.Dot(contacts[maxIndex].mMove2, contacts[i].mContactNormal);
					}
				}
			}
			mIterationsUsed++;
		}
	}
}
