using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "Shop/New Shop")]
public class ShopItems : ScriptableObject {
    public List<Item> shopItems;
}
