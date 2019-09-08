using UnityEngine;

internal class PivotGroup {
  
  internal Vector2 center;
  internal Vector2 dir;
  internal Vector2 prev {
    get { return center + dir; }
  }
  internal Vector2 next {
    get { return center - dir; }
  }
  
  internal PivotGroup(Vector2 center, Vector2 dir) {
    this.center = center;
    this.dir = dir;
  }
}
