using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class FSM : MonoBehaviour
{
    protected Transform playerTransorm;

    protected Vector3 Nextpost;

    protected List<GameObject> pointList = new List<GameObject>();


    // Nos jika si enemy ketinggalan jauh atau di depan player jauh

    protected bool Nos;


    // Rotasi Speed 

    protected float yawSpeed = 50f;

    protected float pitchSpeed = 100f;

    protected float rollSpeed = 200f;


    // Moving Speed 


    //
    protected int currentindex = 0; 

    protected virtual void Inisialisasi() { }

    protected virtual void FSMUpdate() {  }

    protected virtual void FSMFixedUpdate() {  }
    
    void Start()
    {
        Inisialisasi(); 
    }
    
    // Update is called once per frame
    void Update()
    {
        FSMUpdate();
    }
    private void FixedUpdate()
    {
        FSMFixedUpdate();   
    }
}
