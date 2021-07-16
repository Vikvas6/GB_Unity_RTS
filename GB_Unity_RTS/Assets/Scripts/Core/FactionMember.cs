using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class FactionMember : MonoBehaviour, IFactionMember
{
    public int FactionId => _factionId;
    [SerializeField] private int _factionId;

    private static Dictionary<int, int> _factionsMembers = new Dictionary<int, int>();

    private void Awake()
    {
        AddMemeberToFactions(_factionId);
    }
    
    private void OnDestroy()
    {
        _factionsMembers[_factionId] = _factionsMembers[_factionId] - 1;
    }

    public void SetFaction(int factionId)
    {
        _factionsMembers[_factionId] = _factionsMembers[_factionId] - 1;
        _factionId = factionId;
        AddMemeberToFactions(factionId);
    }

    private void AddMemeberToFactions(int factionId)
    {
        if (_factionsMembers.ContainsKey(factionId))
        {
            _factionsMembers[factionId] = _factionsMembers[factionId] += 1;
        }
        else
        {
            _factionsMembers[factionId] = 1;
        }
    }

    public static int GetAliveFactionsCount()
    {
        int result = 0;
        foreach (var factionsMember in _factionsMembers)
        {
            if (factionsMember.Value > 0)
            {
                result += 1;
            }
        }

        return result;
    }

    public static int GetFirstFaction()
    {
        foreach (var factionsMember in _factionsMembers)
        {
            if (factionsMember.Value > 0)
            {
                return factionsMember.Key;
            }
        }

        return -1;
    }
}