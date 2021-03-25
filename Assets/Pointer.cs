using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [Header("Lazer Length")]
    [SerializeField] 
    private float _lazerLenght;

    [SerializeField]
    private Gradient _lazerColor;
    private LineRenderer _lazerLine;

    void Start()
    {
        //get line
        _lazerLine = GetComponent<LineRenderer>();
        ResetLazer();
    }

    void ResetLazer(){
        _lazerLine.SetPosition(1,new Vector3 (0f, _lazerLenght , 0f));
        _lazerLine.colorGradient = _lazerColor;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, _lazerLenght);
        if(hit.collider != null){

            if(hit.collider.tag.Equals("Core")){
                //Set core colors as same as line color
                Debug.Log("Hit a core");
            }

            //set line lenght to hit position
            _lazerLine.SetPosition(1,new Vector3(0f,Vector3.Distance(transform.position, hit.point),0f));
        } else {
            ResetLazer();
        }

    }
}
