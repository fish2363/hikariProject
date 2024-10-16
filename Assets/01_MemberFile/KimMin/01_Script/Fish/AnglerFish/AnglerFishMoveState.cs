using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFishMoveState : FishState
{
    private Vector3 _moveDir;
    private Transform _fishTrm;

    private int _wayCount;

    public AnglerFishMoveState(FishSetting _onwer, StateMachine state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _fishTrm = _fish.transform;
        _fish.RigidCompo.velocity = Vector2.zero;

        FindClosestWayPoint();
    }

    public override void UpdateState()
    {
        //Debug.Log(_fish.BrightPlant.brightStep);

        base.UpdateState();

        Move();
        _fish.MoveFlip(_moveDir);

        float distance = Vector2.Distance
            (_fish.targetTrm.position, _fish.transform.position);

        if (distance < _fish.detectRadius && distance > _fish.attackRadius)
        {
            if (_fish.BrightPlant.brightStep == 0)
                return;

            _stateMachine.ChangeState(FishStateEnum.Chase);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public void Move()
    {
        _fish._targetWay = _fish.way[_wayCount];


        Vector3 dir = _fish._targetWay.position - _fishTrm.position;
        _moveDir = dir.normalized;

        float movingSpeed;
        float wayDistance = Vector2.Distance
            (_fish._targetWay.position, _fishTrm.position);

        movingSpeed = wayDistance < 5f ? _fish.moveSpeed + 3.5f : _fish.moveSpeed;

        _fishTrm.position += _moveDir * movingSpeed * Time.deltaTime;

        if (Vector3.Distance(_fishTrm.position, _fish._targetWay.position) < 0.1f)
        {
            _wayCount++;
            if (_wayCount >= _fish.way.Length)
            {
                _wayCount = 0;
            }
        }
    }

    public void FindClosestWayPoint()
    {
        for (int i = 0; i < _fish.way.Length; i++)
        {
            float distance = Vector2.Distance(_fishTrm.position, _fish.way[i].position);
            float minDistance = float.MaxValue;

            if (distance < minDistance)
            {
                minDistance = distance;
                _wayCount = i;
            }
        }
    }
}
