using UnityEngine;

internal class LevelStyle : MonoBehaviour {
  
  [SerializeField]
  private float tolerence;
  [SerializeField]
  private float width;
  [SerializeField]
  private MeshFilter filter;
  [SerializeField]
  private EdgeCollider2D collider;
  
  protected abstract void Eval(float time);
  
  protected void BuildLevel() {
    graph = NavGraphGenerator.GenGraph(Eval, tolerence);
    hull = MapHullGenerator.GenHull(graph, width);
    filter.mesh = hull.mesh;
    collider.points = hull.edges;
  }
}
