/*
 * Author: Adam Clark
 * Date: 9 June 2026
 * Description: Interface that defines interaction properties for raycasted items
 */

public interface IInteractible
{
    /// <summary>
    /// Interacts with the GameObject
    /// </summary>
    /// <returns>Score from the interaction</returns>
    int Interact();
}
