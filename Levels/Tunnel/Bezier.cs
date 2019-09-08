using UnityEngine;

internal class Bezier {
  
  internal Vector2[] pivots;
  internal Vector2 start {
    get { return pivots[0]; }
  }
  internal Vector2 end {
    get { return pivots[pivots.Length - 1]; }
  }
  
  private Vector2 EvalRec(double time, int startIndex, int endIndex) {
    if (startIndex == endIndex) return pivots[startIndex];
    Vector2 start = EvalRec(time, startIndex, endIndex - 1);
    Vector3 end = EvalRec(time, startIndex + 1, endIndex);
    return Vector2.Lerp(start, end, (float)time);
  }
  
  internal Vector2 Eval(double time) {
    return EvalRec(time, 0, pivots.Length - 1);
  }
  
  internal Bezier(Vector2[] pivots) {
    this.pivots = pivots;
  }
}
