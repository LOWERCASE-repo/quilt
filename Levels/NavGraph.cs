using UnityEngine;
using System.Collections.Generic;

internal class NavGraph {
  
  internal HashSet<Vector2> positions;
  internal NavNode start; // can get rid of this for internal List<Vector2> nodes;
  internal float tolerance;
  
  internal NavGraph(NavNode start, float tolerance) {
    this.start = start;
    this.tolerance = tolerance;
    positions = new HashSet<Vector2>();
  }
}
