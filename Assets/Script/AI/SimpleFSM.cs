using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class SimpleFSM : FSM
{
    public enum FSMState
    {
        None,
        Race,
        Nos,
    }


    public FSMState State;


    private float curSpeed;

    private float curRotSpeed;

    protected override  void Inisialisasi() { 
        State = FSMState.Race;
    }

    protected override void FSMUpdate() { 
    
    }

    protected override void FSMFixedUpdate() {
    
    }

}
