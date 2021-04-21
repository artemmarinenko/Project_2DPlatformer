using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControll;


public enum CollideTypes
{
    Enemy,
    Player,
    Ground,
    Spike,
    InAir
}
public class CollideController : MonoBehaviour
{
     
    public CollideTypes ColliderUnderPlayerType(IRewindable irwindableObject)
    {
       RaycastHit2D boxHit = Physics2D.BoxCast(irwindableObject.GetCollider().bounds.center, 
                                                new Vector2(irwindableObject.GetCollider().size.x-0.05f, irwindableObject.GetCollider().size.y),
                                                0f,
                                                Vector2.down,
                                                0.15f,
                                                LayerMask.GetMask(new string[] { "Enemy", "Tilemap" }));
          
       //RaycastHit2D raycastHit = Physics2D.Raycast(_boxCollider.bounds.center, Vector2.down, _boxCollider.bounds.extents.y + 0.15f, LayerMask.GetMask(new string[] { "Enemy","Tilemap" }));

        if (boxHit.collider == null)
            return CollideTypes.InAir;

        switch (boxHit.collider.tag)
        {
            case "Enemy":
                return CollideTypes.Enemy;
                
            case "Spike":
                return CollideTypes.Spike;

            case "Ground":
                return CollideTypes.Ground;

            default:
                return CollideTypes.InAir;
        }
        
    }

    
}
