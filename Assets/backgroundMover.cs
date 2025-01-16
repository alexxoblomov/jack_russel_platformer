using UnityEngine;

public class BackgroundMover : MonoBehaviour
    {
        public Transform player; // Перетяните сюда объект игрока
        public float parallaxEffect; // Экспериментируйте с этим значением для эффекта параллакса

        private Vector3 lastPlayerPosition;

        void Start()
        {
            lastPlayerPosition = player.position;
        }

        void Update()
        {
            float deltaX = player.position.x - lastPlayerPosition.x;
            transform.position += new Vector3(deltaX * parallaxEffect, 0, 0);
            lastPlayerPosition = player.position;
        }
    }