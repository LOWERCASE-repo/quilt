using UnityEngine;
using System.Collections.Generic;

internal class MapHullGenerator {
  
  private static Quaternion shift = Quaternion.AngleAxis(60f, Vector3.forward);
  
  private static List<Vector2> GenHullPoints(MapHull hull, NavNode node, HashSet<NavNode> visited) {
    Vector2 forward = Vector2.zero;
    foreach (NavNode link in node.links.Keys) {
      forward += link.pos - node.pos;
    }
    forward = forward.normalized;
    Vector2 left = new Vector2(forward.y, -forward.x) * hull.width;
    Vector2 right = -left;
    hull.vertices.Add(node.pos + left);
    hull.vertices.Add(node.pos + right);
    // if (node.links.Count == 1) {
    //   Vector2 endLeft = shift * (shift * forward);
    //   Vector2 endRight = shift * endLeft;
    //   hull.vertices.Add(endLeft);
    //   hull.vertices.Add(endRight);
    // }
    foreach (NavNode link in node.links.Keys) {
      if (!visited.Contains(link)) {
        GenHullPoints(link, visited);
      }
    }
  }
  
  internal static MapHull GenHull(NavGraph graph) {
    MapHull hull = new MapHull();
    //
    GenHullPoints(hull, graph.start, new HashSet<NavNode>());
  }
}
