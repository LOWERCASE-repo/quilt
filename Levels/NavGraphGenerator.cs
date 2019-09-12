using UnityEngine;
using System;

internal static class NavGraphGenerator {
  
  private static LinkedList<Vector2> positions;
  private static float[] weights;
  private static Func<float, Vector2> eval;
  private static float tolerance;
  
  private static void GenPositions(LinkedListNode<Vector2> prev, float prevTime, float nextTime) {
    float midTime = (prevTime + nextTime) / 2f;
    Vector2 midPos = eval(midTime);
    
    LinkedListNode<Vector2> mid = new LinkedListNode<Vector2>(midPos);
    positions.AddAfter(prev, mid);
    
    float prevDist = (midPos - prev.Value).magnitude;
    if (prevDist > tolerance) {
      GenGraphRec(prev, prevTime, midTime);
    }
    float nextDist = (midPos - prev.Next.value).magnitude;
    if (nextDist > tolerance) {
      GenGraphRec(mid, midTime, nextTime);
    }
  }
  
  private static void GenWeights() {
    weights = new float[positions.Count - 1];
    for (int i = 0; i < weights.Length;) {
      weights[i] = (positions[i] - positions[++i]).magnitude;
    }
  }
  
  internal static NavGraph GenGraph(Func<float, Vector2> eval, float tolerance) {
    this.eval = eval;
    this.tolerance = tolerance;
    positions = new LinkedList<Vector2>();
    LinkedListNode<Vector2> start = new LinkedListNode<Vector2>(eval(0f));
    positions.AddFirst(start);
    positions.AddLast(eval(1f));
    GenPositions(start, 0f, 1f);
    GenWeights();
    NavGraph graph = new NavGraph(positions, weights, tolerance);
    return graph;
  }
}
