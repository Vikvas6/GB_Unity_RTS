using UnityEngine;


public interface ISelectable
{
    float Health { get; }
    float MaxHealth { get; }
    Sprite Icon { get; }

    void SelectObject();
    void UnSelectObject();
}
