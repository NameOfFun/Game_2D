using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_State : IState
{
    float time;
    float randomTime;

    public void OnEnter(Enemy enemy)
    {
        time = 0;
        randomTime = Random.Range(3f, 6f);
    }

    public void OnExecute(Enemy enemy)
    {
        time += Time.deltaTime;

        if (enemy.Target != null)
        {
            enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
            if (enemy.IsTargetInRange())
            {
                enemy.ChangeState(new Attack_State());
            }
            else
            {
                enemy.Moving();
            }
        }
        else
        {
            if (time < randomTime)
            {
                enemy.Moving();
            }
            else
            {
                enemy.ChangeState(new Idle_State());
            }
        }
    }

    public void OnExit(Enemy enemy)
    {
        
    }

}
