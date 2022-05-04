using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    /// <summary>
    /// <param name="arg0">
    /// <list type="bullet">
    /// <item>(0) MENU</item>
    /// <item>(1) GAME</item>
    /// <item>(2) JUMP</item>
    /// <item>(3) OVER</item>
    /// <item>(4) OPEN APP</item>
    /// </list>
    /// </param>
    /// </summary>
    static public UnityEvent<int> OnGameStatusChanged = new UnityEvent<int>();
}
