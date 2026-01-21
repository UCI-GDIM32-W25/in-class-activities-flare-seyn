using UnityEngine;

public enum MovementState {
    Idle, Flying
}

public class Pigeon : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    // (1) add a member variable to represent the Pigeon's state
    private MovementState _state = MovementState.Idle;

    void Update()
    {
        UpdateState();
        UpdateAppearance();
    }

    // (2) update the pigeon's state based on input
    // if the player is pressing 'A', state = Flying, otherwise Idle
    private void UpdateState ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _state = MovementState.Flying;
        }
        else
        {
            _state = MovementState.Idle;
        }
    }

    // (3) update the pigeon's animation based on its state
    // use a switch statement!
    private void UpdateAppearance()
    {
        switch (_state)
        {
            case MovementState.Flying:
                PlayFlyAnimation();
                break;

            case MovementState.Idle:
                PlayIdleAnimation();
                break;
        }
    }

    private void PlayFlyAnimation () {
        _animator.SetBool("isFlying", true);
    }

    private void PlayIdleAnimation () {
        _animator.SetBool("isFlying", false);
    }
}
