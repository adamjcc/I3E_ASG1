/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Interface that defines interaction properties for raycasted items
 */

/// <summary>
/// Defines the shared interaction contract used by the player's raycast interaction system.
/// </summary>
public interface IInteractible
{
    /// <summary>
    /// Gets the message shown while the player is looking at this interactable.
    /// </summary>
    /// <returns>Custom interact message</returns>
    string GetInteractText();

    /// <summary>
    /// Performs the interactable object's behaviour when the player presses the interact key.
    /// </summary>
    void Interact();
}
