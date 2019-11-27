using UnityEngine;

internal class CircleGen : MonoBehaviour {
  
  /*
  start w/ circle
  inscribe spoked poly
  poly has a chance of being circle tipped
  stars also possibility
  
  to make a star, connect all even, then all odd
  
  */
  
  private bool mainTipped;
  
  [SerializeField]
  private LineRenderer lineRenderer;
  
  private void Start() {
    int pointCount = 3 + (int)((Random.value - Mathf.Epsilon) * 4);
    lineRenderer.positionCount = pointCount;
    lineRenderer.SetPositions(GenPoly(0.5f, pointCount));
  }
  
  private Vector3[] GenPoly(float radius, int pointCount) {
    Vector3[] points = new Vector3[pointCount];
    float deltaAng = 360f / pointCount;
    Quaternion deltaRot = Quaternion.AngleAxis(deltaAng, Vector3.forward);
    
    for (int i = 0; i < pointCount; i++) {
      Vector3 point = Vector3.up * radius;
      for (int j = 0; j < i; j++) {
        point = deltaRot * point;
      }
      Debug.Log(point);
      points[i] = point;
    }
    
    return points;
  }
  
  
}