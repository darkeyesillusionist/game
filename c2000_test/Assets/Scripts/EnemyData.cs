using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
        public string enemyName;
        public int health;
        public float speed;
        public int attackDamage;
        public float attackRange;
        public float aggroRange;
        public GameObject enemyPrefab;
}
