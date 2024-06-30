using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    #region Singleton

    public static NPCManager instance;


    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    #endregion

    // init the dictionary;
    [SerializeField] private Dictionary<string, NPC> npcs = new();

    // Register the npc to the dictionary with the id and the npc component;
    public void RegisterNPC(string id, NPC npc) {
        if (!npcs.ContainsKey(id)) {
            npcs.Add(id, npc);
        }
    }


    // Function to return the npc form the dictionary by the npc id;
    public NPC GetNPCById(string id) {
        npcs.TryGetValue(id, out NPC npc);
        return npc;
    }
}
