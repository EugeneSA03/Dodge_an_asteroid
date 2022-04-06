using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    /// <summary>
    /// <param name="arg0">
    /// <list type="bullet">
    /// <item>(0) ENDED</item>
    /// <item>(1) STARTED</item>
    /// <item>(2) PAUSED</item>
    /// </list>
    /// </param>
    /// </summary>
    static public UnityEvent<int> OnGameStatusChanged = new UnityEvent<int>();
}
