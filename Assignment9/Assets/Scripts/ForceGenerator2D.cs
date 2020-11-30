using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceGenerator2D : MonoBehaviour
{
    protected int mId;
    protected bool shouldEffectAll;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void UpdateForce(GameObject particle)
    {
        return;
    }

    public virtual void SetID(int id)
    {
        mId = id;
        return;
    }

    public int GetID()
    { return mId; }

    public bool GetShouldEffectAll()
    {
        return shouldEffectAll;
    }

    public void SetShouldEffectAll(bool shouldEffect)
    {
        shouldEffectAll = shouldEffect;
    }

}

