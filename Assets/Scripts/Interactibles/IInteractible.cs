/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Interface that defines interaction properties for raycasted items
 */

public interface IInteractible
{
    /// <summary>
    /// Interacts with the GameObject and displays custom Interact message
    /// </summary>
    /// <returns>Score from the interaction</returns>
    string GetInteractText();
    void Interact();
}
