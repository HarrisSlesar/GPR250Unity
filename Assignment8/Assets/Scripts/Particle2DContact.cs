using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2DContact : MonoBehaviour
{
    public GameObject mObj1 = null;
    public GameObject mObj2 = null;
    public float mRestitutionCoefficient = 0;
    public Vector2 mContactNormal = new Vector2(0, 0);
    public float mPenetration = 0;
    public Vector2 mMove1 = new Vector2(0, 0);
    public Vector2 mMove2 = new Vector2(0, 0);


	
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		
    }

	public void create(GameObject pOne, GameObject pTwo, float rest, Vector2 contactN, float pen, Vector2 mOne, Vector2 mTwo)
	{
		mObj1 = pOne;
		mObj2 = pTwo;
		mRestitutionCoefficient = rest;
		mContactNormal = contactN;
		mPenetration = pen;
		mMove1 = mOne;
		mMove2 = mTwo;
	}


	public void resolve()
	{
		resolveVelocity();
		resolveInterpenetration();
	}

	public float calculateSeparatingVelocity()
	{
		Vector2 relativeVel = new Vector2(0,0);
		if (mObj1)
		{
			relativeVel = mObj1.GetComponent<Particle2D>().GetVelocity();
			
		}
		if (mObj2)
		{
			relativeVel -= mObj2.GetComponent<Particle2D>().GetVelocity();
		}
		return Vector2.Dot(relativeVel, mContactNormal);
	}

	public void resolveVelocity()
	{
		if (mObj1 == null || mObj2 == null)
			return;
		float separatingVel = calculateSeparatingVelocity();
		if (separatingVel > 0.0f)//already separating so need to resolve
			return;

		float newSepVel = -separatingVel * mRestitutionCoefficient;

		Vector2 velFromAcc = mObj1.GetComponent<Particle2D>().GetAcceleration();
		if (mObj2)
			velFromAcc -= mObj2.GetComponent<Particle2D>().GetAcceleration();
		float accCausedSepVelocity = Vector2.Dot(velFromAcc, mContactNormal) * .016f;

		if (accCausedSepVelocity < 0.0f)
		{
			newSepVel += mRestitutionCoefficient * accCausedSepVelocity;
			if (newSepVel < 0.0f)
				newSepVel = 0.0f;
		}

		float deltaVel = newSepVel - separatingVel;

		float totalInverseMass = mObj1.GetComponent<Particle2D>().GetInverseMass();
		if (mObj2)
			totalInverseMass += mObj2.GetComponent<Particle2D>().GetInverseMass();

		if (totalInverseMass <= 0)//all infinite massed objects
			return;

		float impulse = deltaVel / totalInverseMass;
		Vector2 impulsePerIMass = mContactNormal * impulse;

		Vector2 newVelocity = mObj1.GetComponent<Particle2D>().GetVelocity() + impulsePerIMass * mObj1.GetComponent<Particle2D>().GetInverseMass();
		//mObj1.GetComponent<Particle2D>().SetVel(newVelocity);
		if (mObj2)
		{
			newVelocity = mObj2.GetComponent<Particle2D>().GetVelocity() + impulsePerIMass * -mObj2.GetComponent<Particle2D>().GetInverseMass();
			//mObj2.GetComponent<Particle2D>().SetVel(newVelocity);
		}

	}	

	void resolveInterpenetration()
	{
		if (mObj1 == null || mObj2 == null)
			return;
		if (mPenetration <= 0.0f)
			return;

		float totalInverseMass = mObj1.GetComponent<Particle2D>().GetInverseMass();
		if (mObj2)
			totalInverseMass += mObj2.GetComponent<Particle2D>().GetInverseMass();

		if (totalInverseMass <= 0)//all infinite massed objects
			return;

		Vector2 movePerIMass = mContactNormal * (mPenetration / totalInverseMass);

		mMove1 = movePerIMass * mObj1.GetComponent<Particle2D>().GetInverseMass();
		if (mObj2)
			mMove2 = movePerIMass * -mObj2.GetComponent<Particle2D>().GetInverseMass();
		else
			mMove2 = new Vector2(0, 0);

		Vector2 newPosition = new Vector2(mObj1.transform.position.x + mMove1.x, mObj1.transform.position.y + mMove1.y);
		mObj1.transform.position = newPosition;
		if (mObj2)
		{
			newPosition = new Vector2(mObj2.transform.position.x + mMove2.x, mObj2.transform.position.y + mMove2.y);
			mObj2.transform.position = newPosition;
		}
	}
}
