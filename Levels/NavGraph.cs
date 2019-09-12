using UnityEngine;

internal class NavGraph {
  
  internal float tolerance;
  internal Vector2[] positions;
  internal float[] weights;
  
  internal NavGraph(Vector2[] positions, float[] weights, float tolerance) {
    this.positions = positions;
    this.weights = weights;
    this.tolerance = tolerance;
  }
}
