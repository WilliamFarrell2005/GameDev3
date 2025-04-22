using UnityEngine;
public class HpScript : MonoBehaviour
{
    public float hp;
    private void Update()
    {
        if (hp <= 0)
        {
         Destroy(gameObject);   
        }
    }
}
