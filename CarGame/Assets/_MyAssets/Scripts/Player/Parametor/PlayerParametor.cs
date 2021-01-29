using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParametor : IPlayerParametor
{
    private float _energy = 100f;

    public float GetEnergy() { return _energy = Mathf.Clamp(_energy, 0, 100); }
    public void SetEnergy(float energy) { _energy += energy; }
}
