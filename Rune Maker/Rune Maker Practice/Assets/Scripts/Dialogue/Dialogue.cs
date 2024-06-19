using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string name;
    public Sprite Image;

    [TextArea(3, 10)]
    public string[] sentences;
}
