using UnityEngine;
using System.Collections.Generic;

internal class NavGraph {
  
  internal HashSet<Vector2> positions;
  internal NavNode start;
  internal float width;
  
  internal NavGraph(NavNode start, float width) {
    this.start = start;
    this.width = width;
    positions = new HashSet<Vector2>();
  }
}
