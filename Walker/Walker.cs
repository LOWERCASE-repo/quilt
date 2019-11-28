using UnityEngine;

internal class Walker : MonoBehaviour {
  
  /*
  body center
  legRadius
  
  find surface of nearest collider
  calc points on surface equal dist apart
  within legradius
  put legs there
  
  or give each leg a script?
  
  */
  
  [SerializeField]
  private Transform sides;
  [SerializeField]
  private Transform spokes;
  
  private void Start() {
    float radius = transform.localScale.x / 2f;
    int pointCount = 3 + (int)((Random.value - Mathf.Epsilon) * 4);
    Quaternion deltaRot = Quaternion.AngleAxis(360f / pointCount, Vector3.forward);
    GenPoly(radius, pointCount, deltaRot);
    GenSpokes(radius, pointCount, deltaRot);
  }
  
  private void GenPoly(float radius, int pointCount, Quaternion deltaRot) {
    float ang = Mathf.PI / pointCount;
    float sideLength = 2f * 0.5f * Mathf.Sin(ang);
    float sideDist = radius * Mathf.Cos(ang);
    Quaternion baseRot = Quaternion.AngleAxis(180f / pointCount, Vector3.forward);
    
    for (int i = 0; i < pointCount; i++) {
      Transform side = sides.GetChild(i);
      side.gameObject.SetActive(true);
      side.localScale = new Vector3(sideLength, side.localScale.y, 1f);
      side.position = new Vector3(0f, sideDist, 0f);
      side.position = baseRot * side.position;
      side.rotation = baseRot * side.rotation;
      for (int j = 0; j < i; j++) {
        side.position = deltaRot * side.position;
        side.rotation = deltaRot * side.rotation;
      }
    }
  }
  
  private void GenSpokes(float radius, int pointCount, Quaternion deltaRot) {
    for (int i = 0; i < pointCount; i++) {
      Transform spoke = spokes.GetChild(i);
      spoke.gameObject.SetActive(true);
      spoke.localScale = new Vector3(spoke.localScale.x, 0.5f, 1f);
      spoke.position = new Vector3(0f, radius / 2f, 0f);
      for (int j = 0; j < i; j++) {
        spoke.position = deltaRot * spoke.position;
        spoke.rotation = deltaRot * spoke.rotation;
      }
    }
  }
}