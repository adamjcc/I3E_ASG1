using System.Reflection;
using UnityEngine;

public class KeyScript : MonoBehaviour, IInteractible
{
    private string keyName;
    private string promptText;

    private void Start()
    {
        keyName = gameObject.name;
        promptText = $"You picked up a {keyName}!";
    }

    public string GetInteractText()
    {
        return $"E to Pick up {keyName}";
    }

    public void Interact()
    {
        // Hide key
        GetComponentInChildren<Renderer>().enabled = false;

        InventoryManager.instance.AddItem(keyName);

        gameObject.SetActive(false);

        UIManager.instance.SetPromptText(true, promptText);
    }
}
