using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CollideTypes
{
    Enemy,
    Ground,
    Spike,
    InAir
}
public class PlayerCollideController : MonoBehaviour
{
     
    public CollideTypes ColliderFacedType(BoxCollider2D _boxCollider)
    {
       RaycastHit2D boxHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.size,0f,Vector2.down,0.15f, LayerMask.GetMask(new string[] { "Enemy", "Tilemap" }));
          
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
