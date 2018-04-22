using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTags : MonoBehaviour {

    public static string JUMP = "Jump";
    public static string ATTACK = "Attack";
    public static string FLIP = "Flip";
    public static string ACTION = "Action";
    
    public static List<string> GetActions() {
        List<string> actions = new List<string>();
        actions.Add(ACTION);
        actions.Add(JUMP);
        actions.Add(ATTACK);
        actions.Add(FLIP);
        return actions;
    }
}
