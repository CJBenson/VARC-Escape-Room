using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSplit : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pieces;
    [SerializeField]
    private Transform[] locations;
    [SerializeField]
    private GameObject mirror;
    [SerializeField]
    float breakingVelocity;

    private bool aboveBreakVel = false;

    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > breakingVelocity)
            aboveBreakVel = true;

        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude <= breakingVelocity)
            aboveBreakVel = false;
    }

    public void Split()
    {

        for(int i = 0; i < pieces.Length; i++)
        {
            Transform thisTrans = locations[i];
            Instantiate(pieces[i], thisTrans.position, thisTrans.rotation);
        }


        Destroy(mirror);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (aboveBreakVel)
            Split();
    }
}
