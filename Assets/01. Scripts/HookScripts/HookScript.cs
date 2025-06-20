using UnityEngine;

public class HookScript : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;
    private bool itemAttached;
    private HookMovement hookMovement;

    private void Awake()
    {
        hookMovement = GetComponentInParent<HookMovement>();
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == Tags.SMALL_GOLD || target.tag == Tags.MIDDEL_GOLD || target.tag == Tags.LARGE_GOLD ||
            target.tag == Tags.LARGE_STONE || target.tag == Tags.MIDDEL_STONE)
        {
            itemAttached = true;
        }
        target.transform.parent = itemHolder;
        target.transform.position = itemHolder.position;

        hookMovement.HookAttachedItem();
        hookMovement.move_Speed = target.GetComponent<ItemScript>().hookSpeed;

        if (target.tag == Tags.SMALL_GOLD || target.tag == Tags.MIDDEL_GOLD || target.tag == Tags.LARGE_GOLD)
        {
            //Sound
        }
        else if (target.tag == Tags.LARGE_STONE || target.tag == Tags.MIDDEL_STONE)
        {
            //Sound
        }
        //Sound
    }
}
