 using UnityEngine;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }

    public W4Pigeon Player { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);   // kill duplicates
            return;
        }

        Instance = this;

        // Option A: find by tag (matches your instructions)
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        Player = playerObj.GetComponent<W4Pigeon>();
    }
}
