using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

public class Cow : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Vector3 _meToPlayer;

    private void Update ()
    {
        PlayerW71 player = PlayerW71.Instance;
        Assert.IsNotNull(player);
        if(player != null)
        {
            // get the direction pointing from the cow to the player
            _meToPlayer = player.transform.position - transform.position;

            // Q: why do we normalize this vector?
            _meToPlayer = _meToPlayer.normalized;

            // apply displacement to cow's position
            transform.position += _meToPlayer * _speed * Time.deltaTime;

            // after learning about coordinate spaces:
            // transform.Translate(_meToPlayer * _speed * Time.deltaTime); // wrong
            // transform.Translate(_meToPlayer * _speed * Time.deltaTime, Space.World); // right

            // helper function in Transform that points this object towards the argument's position
            // we can use this methods like this to avoid having to worry about math! :D
            transform.LookAt(player.transform);
        }
    }

    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, _meToPlayer);
    }
}