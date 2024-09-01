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

    [SerializeField] private AudioSource engineSoundSource;


    public FSMState State;

    private float elapsedTime = 0.0f;

    protected override  void Inisialisasi() { 
        State = FSMState.Race;
        foreach(var  obj in GameObject.FindGameObjectsWithTag("WandarPoint")) pointList.Add(obj);
        FindNextPoint();
    }
    private float currentSpeed;
    private void UpdateRaceStatet()
    {
        if (Vector3.Distance(transform.position, Nextpost) <= 50f)
        {
            Debug.Log("Mencapai titik tujuan, mencari titik berikutnya...");
            FindNextPoint();
        }

        // Kontrol kecepatan
        if (currentSpeed < 50f)
        {
            currentSpeed += 10f * Time.deltaTime;
        }
        else
        {
            currentSpeed -= 10f * Time.deltaTime;
        }

        Quaternion targetRotation = Quaternion.LookRotation(Nextpost - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);

        transform.Rotate(Vector3.up * 25f * Time.deltaTime, Space.Self);

        transform.Rotate(Vector3.forward * 20f * Time.deltaTime, Space.Self);

        transform.Rotate(Vector3.right * 10f * Time.deltaTime, Space.Self);   

        // Translasi maju
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed, Space.Self);
    }

    bool b = false;
  /*  private void COntoh()
    {
        if(b)
        {
            b = !b;
        }

    }*/
    private void UpdateNosStatet()
    {

    }


    private void AudioSystem()
    {
        if (engineSoundSource == null)
            return;

        if (State == FSMState.Race)
        {
            engineSoundSource.pitch = Mathf.Lerp(engineSoundSource.pitch, 1.5f, 10f * Time.deltaTime);

           /* if (planeIsDead)
            {
                engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, 0f, 10f * Time.deltaTime);
            }
            else
            {
                engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, maxEngineSound, 1f * Time.deltaTime);
            }*/
        }
       /* else if (airplaneState == AirplaneState.Landing)
        {
            engineSoundSource.pitch = Mathf.Lerp(engineSoundSource.pitch, defaultSoundPitch, 1f * Time.deltaTime);
            engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, 0f, 1f * Time.deltaTime);
        }
        else if (airplaneState == AirplaneState.Takeoff)
        {
            engineSoundSource.pitch = Mathf.Lerp(engineSoundSource.pitch, turboSoundPitch, 1f * Time.deltaTime);
            engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, maxEngineSound, 1f * Time.deltaTime);
        }*/
    }
    protected override void FSMUpdate() {
        AudioSystem();

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
/*        Nextpost += rndPosition;
*/    }


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
