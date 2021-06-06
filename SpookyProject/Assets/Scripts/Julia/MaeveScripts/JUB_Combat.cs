using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace combat
{
    public class JUB_Combat 
    {
        // Start is called before the first frame update

        public struct AttackProfile
        {
            public float atkDamage, atkRecover, atkBuildup;
            public Vector2 atkZone, atkVector;
            public string atkName;
            public AttackProfile(float damage, Vector2 zone, float buildup, float recover, string name)
            {
                atkVector = Vector2.zero;
                atkDamage = damage;
                atkZone = zone;
                atkRecover = recover;
                atkBuildup = buildup;
                atkName = name;

            }


            public void ChangeDamage(float changeAmount)
            {
                atkDamage += changeAmount;
            }

            public void NewDamage(float newDamageValue)
            {
                atkDamage = newDamageValue;
            }

        }
    }
}
