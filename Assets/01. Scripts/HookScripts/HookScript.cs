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

    private void OnTriggerEnter2D(Collider2D target)
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
            SoundManager.instance.HoorGrab_Gold();
        }
        else if (target.tag == Tags.LARGE_STONE || target.tag == Tags.MIDDEL_STONE)
        {
            SoundManager.instance.HoorGrab_Stone();
        }
        SoundManager.instance.PullSound(true);

        if(target.tag == Tags.DELIVER_ITEM)
        {
            if(itemAttached)
            {
                itemAttached = false;
                Transform objChild = itemHolder.GetChild(0);
                objChild.parent = null;
                objChild.gameObject.SetActive(false);

                SoundManager.instance.PullSound(false);
            }
        }
    }
}
