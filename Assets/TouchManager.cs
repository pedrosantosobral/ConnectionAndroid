using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private LeanTweenType rotation_type;

    void Update(){

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    Debug.Log("holla marileni");
                    hit.collider.gameObject.transform.Rotate(0,180,0);
                }
            }
            
        }
    }
}
