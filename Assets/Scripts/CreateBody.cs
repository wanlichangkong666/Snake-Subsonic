using UnityEngine;
using System.Collections;

public class CreateBody : MonoBehaviour
{

    public GameObject next;
    void Start()
    {

    }


    void Update()
    {

    }

    public void moveTo(Vector3 pos)
    {
        Vector3 old = this.transform.position;
        this.transform.position = pos;
        if (next != null)
        {
            next.GetComponent<CreateBody>().moveTo(old);
        }



    }
}
