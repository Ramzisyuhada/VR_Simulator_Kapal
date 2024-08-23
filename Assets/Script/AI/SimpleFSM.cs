using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Timers;
using UnityEngine;
using UnityEngine.Windows;

public class SimpleFSM : FSM
{
    public enum FSMState
    {
        None,
        Race,
        Nos,
    }


    public FSMState State;

    private float elapsedTime = 0.0f;

    protected override  void Inisialisasi() { 
        State = FSMState.Race;
        foreach(var  obj in GameObject.FindGameObjectsWithTag("WandarPoint")) pointList.Add(obj);
        FindNextPoint();
    }

    private void UpdateRaceStatet()
    {
        if (Vector3.Distance(transform.position, Nextpost) <= 50f)
        {
            Debug.Log("Mencapai titik tujuan, mencari titik berikutnya...");
            FindNextPoint();
        }

        // Rotasi objek ke arah target (Nextpost)
        Quaternion targetRotation = Quaternion.LookRotation(Nextpost - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);

        // Rotasi yaw (hanya satu arah, sesuai keinginan)
        transform.Rotate(Vector3.up * 25f * Time.deltaTime, Space.Self);

        // Rotasi tambahan untuk roll dan pitch
        transform.Rotate(Vector3.forward * 150f * Time.deltaTime, Space.Self); // Roll
        transform.Rotate(Vector3.right * 50f * Time.deltaTime, Space.Self);   // Pitch

        // Translasi maju
        transform.Translate(Vector3.forward * Time.deltaTime * 50f, Space.Self);
    }


    private void UpdateNosStatet()
    {

    }
    protected override void FSMUpdate() {
        switch (State)
        {
            case FSMState.Race: UpdateRaceStatet(); break; 
            case FSMState.Nos: UpdateNosStatet(); break;
        }

        elapsedTime += Time.deltaTime;


    }

    protected override void FSMFixedUpdate() {
    
    }

    private void FindNextPoint()
    {
        if (currentindex + 1 < pointList.Count)
        {
            currentindex++;
            Debug.Log("Berpindah ke point: " + pointList[currentindex].gameObject.name);
        }
        else
        {
            Debug.Log("Semua point sudah dicapai.");
        }

        // Tentukan titik berikutnya
        Nextpost = pointList[currentindex].transform.position;

        float rndRadius = 2f;
        Vector3 rndPosition = new Vector3(UnityEngine.Random.Range(-rndRadius, rndRadius), UnityEngine.Random.Range(-rndRadius, rndRadius), UnityEngine.Random.Range(-rndRadius, rndRadius));
        Nextpost += rndPosition;
    }


    private bool IsInCurrentRange(Vector3 pos)
    {
        float xpos = Mathf.Abs(pos.x - transform.position.x);
        float zpos = Mathf.Abs(pos.z - transform.position.z);
        float ypos = Mathf.Abs(pos.y - transform.position.y);


        if (xpos <= 50 && zpos <= 50 && ypos <= 50)
        {
            return true;
        }
        return false;
    }
}
