using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "ScriptableObjects/Enemy Stats", order = 1)]
public class EnemyStats : ScriptableObject {
    public string enemyName;
    public float health;
    public string dialogueLine;
}