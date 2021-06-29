using UnityEngine;


public interface ISelectable : IHealth
{
    Sprite Icon { get; }
    Transform PivotPoint { get; }
}
