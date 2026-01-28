using UnityEngine;
using System.Collections;

public class W4UI : MonoBehaviour
{
    [SerializeField] private GameObject _pigeonCooDialogue;
    [SerializeField] private float _duration;

    // add a new method here
    // use the Locator to find the Pigeon
    // then, subscribe the HandlePigeonCoo method to the Pigeon coo event






    // don't change the code in this method!
    public void HandlePigeonCoo ()
    {
        _pigeonCooDialogue.SetActive(true);

        // waits a few seconds to remove the coo UI
        StartCoroutine(WaitAndDeactivate());
    }

    // don't change the code in this method!
    IEnumerator WaitAndDeactivate()
    {
        yield return new WaitForSeconds(_duration);
        _pigeonCooDialogue.SetActive(false);
    }
}