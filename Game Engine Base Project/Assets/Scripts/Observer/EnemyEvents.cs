using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyEvents
{
    public abstract Color EnemyColor();
}

public class Blue : EnemyEvents
{
    public override Color EnemyColor()
    {
        return Color.blue;
    }
}
