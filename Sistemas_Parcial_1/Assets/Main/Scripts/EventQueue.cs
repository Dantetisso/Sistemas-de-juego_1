using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : MonoBehaviour
{
    private List<ICommand> currentCommands = new();
    public static EventQueue Instance { get; private set; }

   private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void QueueCommand(ICommand command)
    {
        currentCommands.Add(command);
    }

    private void LateUpdate()
    {
        if (currentCommands.Count == 0)
        {
            return;
        }

        for (int i = currentCommands.Count - 1; i >= 0; i--)
        {
            currentCommands[i].Execute();
            // currentCommands.RemoveAt(i);
        }

        currentCommands.Clear();
    }

}
