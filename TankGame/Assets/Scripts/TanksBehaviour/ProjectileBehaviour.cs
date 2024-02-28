using System;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField, Min(1)]
    private int damageValue;
    [SerializeField]
    private LayerMask layerToDamage;

    [Header ("Collision FXs")]
    [SerializeField]
    private GameObject tankCollisionFXprefab;
    [SerializeField]
    private GameObject otherCollisionFXprefab;

    private void OnCollisionEnter(Collision other) 
    {
        if((layerToDamage.value & (1 << other.gameObject.layer)) != 0)
        {
            try {
                GameObject fx = Instantiate(tankCollisionFXprefab, other.contacts[0].point, Quaternion.identity);
                other.gameObject.GetComponent<IDamagable>().TakeDamage(damageValue);
                Destroy(fx, 3f);
            }catch(Exception e)
            {
                Debug.Log($"ProjectileBehaviour is trying to access IDamagable inteface of {other.gameObject.name}. Exception: {e}");
            }
        }else
        {
            GameObject fx = Instantiate(otherCollisionFXprefab, other.contacts[0].point, Quaternion.identity);
            Destroy(fx, 3f);
        }

        ProjectilePool.Instance.ReturnObject(this.gameObject);
    }
}
