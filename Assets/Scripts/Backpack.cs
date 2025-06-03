using UnityEngine;

public class Backpack : MonoBehaviour
{
    public bool getBackpack {  get; private set; }
    void Start()
    {
        getBackpack = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Player>())
        {
            getBackpack =true;
        }
    }

}
