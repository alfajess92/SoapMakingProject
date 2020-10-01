using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]// to show in inspector

public class Chat // not monobehaviour because it will not sit on a script
{
    //public string name;

    [TextArea (3,10)]

    public string[] sentences;


}
