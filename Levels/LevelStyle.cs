using UnityEngine;

internal abstract class LevelStyle : MonoBehaviour {
  
  [SerializeField]
  private float tolerance;
  [SerializeField]
  private float width;
  [SerializeField]
  private MeshFilter filter;
  [SerializeField]
  private EdgeCollider2D collider;
  
  protected abstract Vector2 Eval(float time);
  
  protected void BuildLevel() {
    NavGraph graph = NavGraphGenerator.GenGraph(Eval, tolerance);
    MapHull hull = MapHullGenerator.GenHull(graph, width);
    filter.mesh = hull.mesh;
    collider.points = hull.edges;
  }
}
