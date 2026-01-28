using UnityEngine;

public class W4Pigeon : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Animator _animator;

    // EVENT: other objects subscribe to this to learn the pigeon coo'd
    public delegate void PigeonCooAction();
    public event PigeonCooAction OnPigeonCoo;

    // don't change the code in this method!
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Coo();
        }
    }

    private void Coo()
    {
        Debug.Log("squack!");

        // do pigeon stuff
        _audio.Play();
        _animator.SetTrigger("wiggle");

        // fire the event (alerts all subscribers)
        OnPigeonCoo?.Invoke();
    }
}
