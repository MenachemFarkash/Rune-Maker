using UnityEngine;

public class EquipmentManager : MonoBehaviour {
    #region Singleton
    public static EquipmentManager Instance;

    private void Awake() {
        Instance = this;
    }

    #endregion



    public Equipment[] defaultItems;
    public Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    public Transform rightHandTarget;
    public Transform leftHandTarget;


    public SkinnedMeshRenderer targetMesh;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;


    private void Start() {
        inventory = Inventory.Instance;


        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];

        currentMeshes = new SkinnedMeshRenderer[numberOfSlots];

        EquipDefaultItems();

    }

    public void Equip(Equipment newItem) {
        // We cast it into a int to get the index in the Enum;
        int slotIndex = (int)newItem.equipSlot;


        Equipment oldItem = Unequip(slotIndex);



        if (onEquipmentChanged != null) {
            onEquipmentChanged(newItem, oldItem);
        }
        if (newItem.equipSlot == EquipmentSlot.Weapon) {
            //Transform newItemEquiped = Instantiate(newItem.mesh, rightHandTarget).transform;
            SkinnedMeshRenderer newItemEquiped = Instantiate(newItem.mesh, rightHandTarget);

            //newItemEquiped.transform.localScale = Vector3.one;
            //newItemEquiped.transform.localRotation = Quaternion.Euler(90, 180, 0);
            //newItemEquiped.transform.localPosition = Vector3.zero;
            currentEquipment[slotIndex] = newItem;
            currentMeshes[slotIndex] = newItemEquiped;


        } else if (newItem.equipSlot == EquipmentSlot.Shield) {
            SkinnedMeshRenderer newItemEquiped = Instantiate(newItem.mesh, leftHandTarget);

            newItemEquiped.transform.localScale = Vector3.one;
            newItemEquiped.transform.localRotation = Quaternion.Euler(90, 180, 0);
            newItemEquiped.transform.localPosition = Vector3.zero;
            currentEquipment[slotIndex] = newItem;
            currentMeshes[slotIndex] = newItemEquiped;


        } else {

            SetEquipmnetBlendShapes(newItem, 100);

            currentEquipment[slotIndex] = newItem;
            SkinnedMeshRenderer newMesh = Instantiate(newItem.mesh);
            newMesh.transform.parent = targetMesh.transform;

            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
            currentMeshes[slotIndex] = newMesh;
        }

    }

    public Equipment Unequip(int slotIndex) {

        if (currentEquipment[slotIndex] != null) {
            if (currentMeshes[slotIndex] != null) {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            Equipment oldItem = currentEquipment[slotIndex];
            //SetEquipmnetBlendShapes(oldItem, 0);
            inventory.AddItem(oldItem);


            currentEquipment[slotIndex] = null;


            if (onEquipmentChanged != null) {
                onEquipmentChanged(null, oldItem);
            }
            return oldItem;
        }
        return null;

    }

    public void UnequipAll() {
        for (int i = 0; i < currentEquipment.Length; i++) {
            Unequip(i);
        }
        EquipDefaultItems();
    }

    void SetEquipmnetBlendShapes(Equipment item, int weight) {
        foreach (EquipmentMeshRegion blendShape in item.coveredMeshRegions) {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
        }
    }

    void EquipDefaultItems() {
        foreach (Equipment item in defaultItems) {
            Equip(item);
        }
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            UnequipAll();
        }

    }


}
