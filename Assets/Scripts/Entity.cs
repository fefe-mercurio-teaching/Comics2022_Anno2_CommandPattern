using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Command
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] private float stepDuration = 1f;

        [SerializeField] private Button upButton;
        [SerializeField] private Button downButton;
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [SerializeField] private Button changeColorButton;

        [SerializeField] private Button undoButton;

        private ActionHandler _actionHandler = new ActionHandler();

        private void Start()
        {
            upButton.onClick.AddListener(() => _actionHandler.RecordAction(new MoveAction(this, Vector2.up)));
            downButton.onClick.AddListener(() => _actionHandler.RecordAction(new MoveAction(this, Vector2.down)));
            leftButton.onClick.AddListener(() => _actionHandler.RecordAction(new MoveAction(this, Vector2.left)));
            rightButton.onClick.AddListener(() => _actionHandler.RecordAction(new MoveAction(this, Vector2.right)));

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            changeColorButton.onClick.AddListener(() => _actionHandler.RecordAction(new ChangeColorAction(spriteRenderer)));
            
            undoButton.onClick.AddListener(() => _actionHandler.Undo());
        }

        public void Move(Vector2 direction)
        {
            StartCoroutine(DoMove(direction));
        }

        private IEnumerator DoMove(Vector2 direction)
        {
            Vector3 startPosition = transform.position;
            Vector3 destination = startPosition + (Vector3)direction;

            float amount = 0f;

            while (amount < stepDuration)
            {
                amount += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, destination, amount / stepDuration);

                yield return null;
            }
        }
    }
}