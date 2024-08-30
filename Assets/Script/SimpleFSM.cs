using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class SimpleFSM : FSM
{
    public enum FSMState
    {
        None,
        Move
    }
    
    [SerializeField] FSMState currentstate;

    private float curspeed;
    private Vector3 pointPosisition;
    private Animator animator;
    private NavMeshAgent agent;


    
    protected override void fsm_init()
    {
        currentstate = FSMState.Move;
       
        agent = GetComponent<NavMeshAgent>();   
        foreach (var waypoint in GameObject.FindGameObjectsWithTag("Waypoint")) {
            Waypoints.Add(waypoint);

        }

        Debug.Log(Waypoints[4].transform.childCount);

        int index = Random.RandomRange(0, Waypoints[4].transform.childCount -  1);
        Vector3 tujuan = Waypoints[4].transform.GetChild(index).position;
        pointPosisition = tujuan;
        agent.destination = tujuan;
        Dest = tujuan;

    }

   /* protected override void fsm_update()
    {
        switch (currentstate)
        {
            case FSMState.Move:
                UpdateMove();
                break;
            default:
                break;

        }
        Debug.Log(pointPosisition);
        Debug.Log(transform.position);
    }*/
    /*  protected override void fsm_update() {
          switch (currentstate)
          {
              case FSMState.Move:UpdateMove(); 
                  break;
              default:
                  break;

          }


          if(Vector3.Distance(transform.position, Dest) < 100f)
          {
              currentstate = FSMState.Move;

          }
      }
*/
  /*  private void FindNextPoint()
    {

        int randindex = Random.RandomRange(0, Waypoints.Count);
        float radius = 5f;
        Vector3 rndPosisition = Vector3.zero;
        Dest = Waypoints[randindex].transform.position + rndPosisition;
        Debug.Log(Waypoints[randindex].gameObject);
        *//*        Dest = Waypoints[randindex].transform.position + rndPosisition;
        */
        /*     if (IsInCurrentRange(Dest)) {
   *//*              rndPosisition = new Vector3(Random.Range(-radius, radius), 0.0f, Random.Range(-radius, radius));
   *//*              Dest = Waypoints[randindex].transform.position + rndPosisition;

             }*/

        /*        animator.SetBool("isMoving", true);  // Set animasi bergerak
        *//*
    }*/


    private bool IsInCurrentRange(Vector3 pos)
    {
        float xpos = Mathf.Abs(pos.x - transform.position.x);
        float zpos = Mathf.Abs(pos.z - transform.position.z);
        if (xpos <= 50 && zpos <= 50) return true;

        return false;

    }
    private void UpdateMove()
    {

        if (Vector3.Distance(transform.position, agent.destination) < agent.stoppingDistance + 1f)
        {
/*            FindNextPoint();
*/        }
        agent.destination = Dest;
            /* Quaternion targetrotation = Quaternion.LookRotation(Dest - transform.position);
         transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, Time.deltaTime * 2F);
         transform.Translate(Vector3.forward * Time.deltaTime 
             * curspeed);*/
    }
    protected override void fsm_fixedUpdate()
    {

    }
}
