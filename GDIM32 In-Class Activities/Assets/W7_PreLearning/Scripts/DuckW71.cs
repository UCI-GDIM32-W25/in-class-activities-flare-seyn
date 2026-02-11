using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

public class DuckW71 : MonoBehaviour
{
    [SerializeField] private string _dialogue;

    [SerializeField] private DialogueBubble _dialogueBubble;
    [SerializeField] private float _dialogueDistance;
    [SerializeField] private Vector3 _raycastStartOffset;
    [SerializeField] private bool _runLineOfSight = false;

    private string _playerTag = "Player";
    private Vector3 _playerPos;
    private Vector3 _playerForward;
    private Vector3 _playerToMe;

    private Vector3 _raycastHitLocation;
    private Vector3 _raycastStart;
    private Vector3 _raycastDir;

    private void Update ()
    {
        PlayerW71 player = PlayerW71.Instance;
        Assert.IsNotNull(player);
        if(player != null)
        {
            if(_runLineOfSight)
            {
                RunLineOfSightCheck();
            } else
            {
                RunFacingCheck(player);
            }
        }
    }

    private void RunFacingCheck (PlayerW71 player)
    {
        _playerPos = player.transform.position;
        // Transform.forward is a vector telling us what direction this object is facing
        _playerForward = player.transform.forward;

        bool withinDistanceAndFacing = false;

        // this if statement prevents displaying dialogue if player is too far away
        if(Vector3.Distance(transform.position, _playerPos) <= _dialogueDistance)
        {
            Debug.Log("close");

            // get vector pointing from the duck to the player
            _playerToMe = transform.position - _playerPos;
            _playerToMe = _playerToMe.normalized;
            
            // test if dot product between _playerToMe and my forward vector is positive
            // essentially, test if me and the player are facing each other
            float dot = Vector3.Dot(_playerToMe, _playerForward);
            Debug.Log(dot);
            bool playerIsFacingMe = dot >= 0;

            if(playerIsFacingMe)
            {
                withinDistanceAndFacing = true;
                
            }
        }
        
        if(withinDistanceAndFacing)
        {
            _dialogueBubble.ShowDialogue(_dialogue);
        }
        else
        {
            _dialogueBubble.HideDialogue();
        }
    }

    private void RunLineOfSightCheck ()
    {
        _raycastStart = transform.TransformPoint(_raycastStartOffset);
        _raycastDir = transform.forward;

        bool hasLineOfSightToPlayer = false;
        RaycastHit hitInfo;
        if(Physics.Raycast(_raycastStart, _raycastDir, out hitInfo, _dialogueDistance))
        {
            _raycastHitLocation = hitInfo.point;
            if(hitInfo.collider.gameObject.tag.Equals(_playerTag))
            {
                hasLineOfSightToPlayer = true;
            }
        }

        if(hasLineOfSightToPlayer)
        {
            _dialogueBubble.ShowDialogue(_dialogue);
        }
        else 
        {
            _dialogueBubble.HideDialogue();
        }
    }

    private void OnDrawGizmos ()
    {
        if(_runLineOfSight) {
            // draw debug stuff for line of sight check
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_raycastStart, _raycastDir * _dialogueDistance);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_raycastHitLocation, 0.1f);
        } else {
            // draw debug stuff for facing check
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, _playerToMe);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, _playerForward);
        }
    }
}
