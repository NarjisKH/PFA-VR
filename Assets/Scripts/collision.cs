using UnityEngine;

public class collision : MonoBehaviour
{
//  [SerializeField] private GameObject led;
   //  private SpawnManager _spawnManager;

   // [SerializeField] private bool _isEnabled = true;
   // [SerializeField] private Color _color = Color.green;
   // [SerializeField] private float _size = 10;


    void OnCollisionEnter (Collision collisionInfo)
      {
         Debug.Log(collisionInfo.collider.name);
         // if(collisionInfo.collider.name=="DropArea"){
         //    Debug.Log("You placed the LED in the right spot : DropArea ");
         // }
      }

}
