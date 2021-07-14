using UnityEngine;


public interface ISelectable : IHealth, IIconHolder
{
    Transform PivotPoint { get; }
}
