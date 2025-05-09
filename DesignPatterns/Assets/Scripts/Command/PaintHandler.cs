using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CommandPattern
{
    /// <summary>
    /// This prolly works.
    /// </summary>
    public class PaintHandler : MonoBehaviour, ICommand
    {
        [SerializeField] private GameObject prefab = default;
        [SerializeField] private Camera cam = default;
        [SerializeField] private Text text = default;
        [SerializeField] private int maxHistoryLength = default;

        private readonly List<ICommand> commands = new List<ICommand>();
        private readonly InputHandler handler = new InputHandler();
        private int current;

        private void Start()
        {
            handler.Bind(KeyCode.Mouse0, this);
        }

        private void Update()
        {
            handler.Update();

            // undo
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Undo();

            if (Input.GetKeyDown(KeyCode.RightArrow))
                Redo();
        }

        private void FixedUpdate()
        {
            //print(current);
            text.text = $"{current} | {commands.Count} | {maxHistoryLength}";
        }

        public void Execute()
        {
            // Thank you GEMINI !!
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = cam.nearClipPlane;
            Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition);

            commands.Add(new CreateObjectCommand(prefab, worldPosition, Quaternion.identity));
            Clamp();

            current = commands.Count - 1;
            commands[current].Execute();
            //isUpToDate = true;
        }

        public void Undo()
        {
            if (current < 0 || current >= commands.Count)
                return;

            commands[current].Undo();
            current--;

            if (current < 0)
                current = 0;
        }

        public void Redo()
        {
            if (current < 0 || current >= commands.Count)
                return;

            commands[current].Execute();
            current++;

            if (current >= commands.Count)
                current = commands.Count - 1;
        }

        private void Clamp()
        {
            if (commands == null || maxHistoryLength <= 0)
                return;

            while (commands.Count > maxHistoryLength)
            {
                commands.RemoveAt(0);
                current--;
            }

            if (current < 0)
                current = 0;
        }
    }
}