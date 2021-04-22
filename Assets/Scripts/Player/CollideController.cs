using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControll;
using System;

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
     
    public Tuple<CollideTypes, Collider2D> ColliderUnderPlayerType(IRewindable irewindableObject,LayerMask layerMask)
    {
        BoxCollider2D boxCollider = irewindableObject.GetCollider();

        RaycastHit2D boxHit = Physics2D.BoxCast(boxCollider.bounds.center, 
                                                new Vector2(boxCollider.size.x-0.05f, boxCollider.size.y),
                                                0f,
                                                Vector2.down,
                                                0.15f,
                                                layerMask);
          
       //RaycastHit2D raycastHit = Physics2D.Raycast(_boxCollider.bounds.center, Vector2.down, _boxCollider.bounds.extents.y + 0.15f, LayerMask.GetMask(new string[] { "Enemy","Tilemap" }));

        if (boxHit.collider == null)
            return Tuple.Create(CollideTypes.InAir, boxHit.collider);
        
        switch (boxHit.collider.tag)
        {
            case "Enemy":
                return Tuple.Create(CollideTypes.Enemy, boxHit.collider);
                
            case "Spike":
                return Tuple.Create(CollideTypes.Spike, boxHit.collider);

            case "Ground":
                return Tuple.Create(CollideTypes.Ground, boxHit.collider);

            default:
                return Tuple.Create(CollideTypes.InAir, boxHit.collider);
        }
        
    }

    public CollideTypes ColliderFaced(IRewindable irewindableObject,LayerMask layerMask)
    {
        RaycastHit2D raycastHit = new RaycastHit2D();
        BoxCollider2D boxCollider = irewindableObject.GetCollider();

        if (irewindableObject.GetFlip() == false)
        {
            raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.right, boxCollider.bounds.extents.x + 0.15f, layerMask);
        }
        else
        {
            raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.left, boxCollider.bounds.extents.x + 0.15f, layerMask);
        }

        //Debug.DrawRay(_boxCollider.bounds.center,transform.TransformDirection(transform.forward)*5f,Color.red);

        //Debug.Log (raycastHit.collider != null);


        if (raycastHit.collider == null)
            return CollideTypes.InAir;

        switch (raycastHit.collider.tag)
        {
            case "Player":
                return CollideTypes.Player;

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
