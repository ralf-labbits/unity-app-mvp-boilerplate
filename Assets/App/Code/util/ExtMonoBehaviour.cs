using System.Collections.Generic;
using UnityEngine;

public static class ExtMonoBehaviour
{
    [ContextMenu("BBBind")]
    public static void BindUIFields(this MonoBehaviour obj)
    {
        var fields = obj.GetType().GetFields();
        foreach (var f in fields)
        {
            if (fieldTypes.Contains(f.FieldType.Name))
            {
                Debug.Log(f.Name + " | " + f.FieldType.Name);
                f.SetValue(obj, GameObject.Find(f.Name).GetComponent(f.FieldType));
            }
        }
    }

    public static readonly List<string> fieldTypes = new List<string>()
    {
        "InputField",
        "Button",
        "Text"
    };
}
