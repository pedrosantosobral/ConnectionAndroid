using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTouchManager : MonoBehaviour
{
    [SerializeField] private LeanTweenType _rotationType;
    [SerializeField] private float _rotationSpeed;

    void Update(){

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    float finalRotation = hit.collider.gameObject.transform.rotation.eulerAngles.z;

                    if(!LeanTween.isTweening())
                     LeanTween.rotateZ(hit.collider.gameObject, hit.collider.gameObject.transform.rotation.eulerAngles.z + 60f,
                    _rotationSpeed).setEase(_rotationType);
                }
            }
            
        }
    }
}
