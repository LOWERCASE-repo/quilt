using UnityEngine;
using System.Collections.Generic;

internal class NavGraph {
  
  internal HashSet<Vector2> positions;
  internal NavNode start;
  internal float width;
  
  internal NavGraph(HashSet<Vector2> positions, NavNode start, float width) {
    this.positions = positions;
    this.start = start;
    this.width = width;
  }
}
