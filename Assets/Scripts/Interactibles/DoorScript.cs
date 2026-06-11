using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractible
{
    [SerializeField] private bool isLocked = false;
    [SerializeField] private string promptText = "Door Locked!";
    private bool isClosed = true;
    
    public string GetInteractText()
    {
        if (isClosed == true) 
        { 
            return "E to Open Door";
        }
        else
        {
            return "E to Close Door";
        }
    }

    public void Interact()
    {
        if (isLocked == true)
        {
            UIManager.instance.SetPromptText(true, promptText);
        }
        else 
        {            
            var animatorComponent = GetComponentsInChildren<Animator>();

            foreach (var animator in animatorComponent)
            {
                animator.SetBool("IsOpen", isClosed);
                Debug.Log($"DOORSCIPT: x1 door bool changed (Animator: {animator})");
            }

                isClosed = !isClosed;
        }
    }
}
