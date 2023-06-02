using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {

            if (hit.collider.tag == "interact") {

                if (Input.GetMouseButtonDown(0)) {

                    Debug.Log("interacted");

                    hit.collider.gameObject.GetComponent<Interaction>().events.Invoke();

                }

            }

        }
    }
}
