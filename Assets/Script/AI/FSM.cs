using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    protected Transform playerTransorm;

    protected Vector3 Nextpost;

    protected List<GameObject> pointList;

    // Nos jika si enemy ketinggalan jauh atau di depan player jauh

    protected bool Nos;

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
