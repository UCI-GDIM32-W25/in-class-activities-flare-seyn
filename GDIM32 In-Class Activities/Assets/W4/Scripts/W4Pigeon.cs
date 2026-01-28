using UnityEngine;

public class W4Pigeon : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Animator _animator;

    // REMOVE these references to other objects!
    // we're going to alert them via EVENT instead!!
    [SerializeField] private W4Seagull[] _seagulls;
    [SerializeField] private W4UI _ui;
    [SerializeField] private W4VFX _vfx;

    // HERE, add an event to tell other objects that the pigeon coo'd!

    // don't change the code in this method!
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Coo();
        }
    }

    private void Coo ()
    {
        Debug.Log("squack!");

        // do pigeon stuff
        _audio.Play();
        _animator.SetTrigger("wiggle");

        // HERE, you'll want to REMOVE the code to "tell seagulls", "tell UI", and "tell VFX"
        // instead, fire your coo event!
        
        // tell seagulls
        foreach(W4Seagull seagull in _seagulls)
        {
            seagull.HandlePigeonCoo();
        }

        // tell UI
        _ui.HandlePigeonCoo();

        // tell VFX
        _vfx.HandlePigeonCoo();
    }
}
