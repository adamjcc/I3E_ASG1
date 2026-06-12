using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractible
{
    [SerializeField] private GameObject lockVisual;
    [SerializeField] private bool isLocked = false;
    [SerializeField] private GameObject keyRequired;
    private string keyRequiredName;
    private string promptText = "Door Locked! (Requires Key)";
    private bool isClosed = true;

    private void Start()
    {
        lockVisual.SetActive(isLocked); // show Lock visual if door is locked, and vise versa
        if (keyRequired == null)
        {
            keyRequiredName = "";
        }
        else
        {
            keyRequiredName = keyRequired.name;
        }
    }

    public string GetInteractText()
    {
        if (isClosed == true) 
        { 
            if (isLocked == true)
            {
                return "E to Unlock Door";
            }
            else 
            {
                return "E to Open Door";
            }
        }
        else
        {
            return "E to Close Door";
        }
    }

    public void Interact()
    {
        if (isLocked == true && InventoryManager.instance.HasItem(keyRequiredName) == false)
        {
            UIManager.instance.SetPromptText(true, promptText);
        }
        else 
        {
            if (isLocked == true)
            {
                InventoryManager.instance.RemoveItem(keyRequiredName);
                isLocked = false;
                lockVisual.SetActive(false);
            }

            var animatorComponent = GetComponentsInChildren<Animator>();

            foreach (var animator in animatorComponent)
            {
                animator.SetBool("IsOpen", isClosed);
            }
            
            isClosed = !isClosed;
        }
    }
}
