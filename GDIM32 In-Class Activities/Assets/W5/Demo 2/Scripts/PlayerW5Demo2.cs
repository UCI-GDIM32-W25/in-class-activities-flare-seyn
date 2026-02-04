using System.Collections.Generic;
using UnityEngine;

public class PlayerW5Demo2 : MonoBehaviour
{
    [SerializeField] private List<ItemW5Demo2> _inventory;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private InventoryUI _ui;

    // singleton stuff
    public static PlayerW5Demo2 Instance { get; private set; }

    // singleton stuff
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Update ()
    {
        // movement
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }

        // toggles the item list text
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ui.ToggleShowInventory(_inventory);
        }

        _spriteRenderer.sortingOrder = -(int)transform.position.y;
    }
}