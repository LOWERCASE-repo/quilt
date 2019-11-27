using UnityEngine;

internal class CircleGen : MonoBehaviour {
  
  /*
  start w/ circle
  inscribe spoked poly
  poly has a chance of being circle tipped
  stars also possibility
  
  to make a star, connect all even, then all odd
  
  */
  
  [SerializeField]
  private Transform sides;
  [SerializeField]
  private Transform spokes;
  
  private void Start() {
    float radius = 0.5f;
    int pointCount = 3 + (int)((Random.value - Mathf.Epsilon) * 4);
    Quaternion deltaRot = Quaternion.AngleAxis(360f / pointCount, Vector3.forward);
    GenPoly(radius, pointCount, deltaRot);
    // GenSpokes(radius, pointCount, deltaRot);
  }
  
  private void GenPoly(float radius, int pointCount, Quaternion deltaRot) {
    float ang = Mathf.PI / pointCount;
    float sideLength = 2f * radius * Mathf.Sin(ang);
    float sideDist = radius * Mathf.Cos(ang);
    float deltaAng = 360f / pointCount;
    
    for (int i = 0; i < pointCount; i++) {
      Transform side = sides.GetChild(i);
      side.gameObject.SetActive(true);
      side.localScale = new Vector3(sideLength, side.localScale.y, 1f);
      side.position = new Vector3(0f, sideDist, 0f);
      for (int j = 0; j < i; j++) {
        side.position = deltaRot * side.position;
        side.rotation = deltaRot * side.rotation;
      }
    }
  }
  
  private void GenSpokes(float radius, int pointCount, Quaternion deltaRot) {
    
  }
}