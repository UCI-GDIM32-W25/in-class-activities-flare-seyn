using UnityEngine;
using UnityEngine.Assertions;

public class EnemyW5Demo2 : MonoBehaviour
{
    [SerializeField] private EnemyStats _stats;

    [SerializeField] private DialogueBubble _dialogueBubble;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _dialogueDistance;

    private void Start ()
    {
        _spriteRenderer.sortingOrder = -(int)transform.position.y;
    }

    private void Update ()
    {
        PlayerW5Demo2 player = PlayerW5Demo2.Instance;
        Assert.IsNotNull(player);
        if(player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if(distance <= _dialogueDistance)
            {
                _dialogueBubble.ShowDialogue(_stats.dialogueLine);
            }
            else 
            {
                _dialogueBubble.HideDialogue();
            }
        }
    }
}
