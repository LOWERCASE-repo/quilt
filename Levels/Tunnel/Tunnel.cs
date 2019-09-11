using UnityEngine;

public class Tunnel : LevelStyle {
  
  [SerializeField]
  private float size;
  [SerializeField]
  private int curveCount;
  [SerializeField]
  private int curveMag;
  [SerializeField]
  private int curveChaos;
  [SerializeField]
  private float shapeChaos;
  
  private Bezier[] beziers;
  
  private Vector2 Eval(float time) {
    float curveLen = 1f / beziers.Length;
    int index = (time == 1f) ? beziers.Length - 1 : (int)(time * beziers.Length);
    float evalTime = (time % curveLen) / curveLen;
    return beziers[index].Eval(evalTime);
  }
  
  private void GenBeziers() { // TODO move to tunnel generator
    float spacing = size / (curveCount - 1);
    PivotGroup[] groups = new PivotGroup[curveCount + 1];
    beziers = new Bezier[curveCount];
    
    // gen groups
    groups[0] = new PivotGroup(Vector2.zero, dir);
    for (int i = 1; i < groups.Length; i++) {
      dir = groups[i - 1].dir.x > 0 ? Vector2.left : Vector2.right;
      dir *= curveMag + Random.value * curveChaos;
      groups[i] = new PivotGroup(Vector2.down * i * spacing, dir);
    }
    
    // flavour groups
    for (int i = 0; i < groups.Length; i++) {
      PivotGroup group = groups[i];
      group.center += Random.insideUnitCircle * shapeChaos;
      group.dir += Random.insideUnitCircle * shapeChaos;
    }
    
    // construct beziers
    for (int i = 1; i < groups.Length; i++) {
      PivotGroup prev = groups[i - 1];
      PivotGroup next = groups[i];
      Vector2[] pivots = new Vector2[] {
        prev.center, prev.next, next.prev, next.center
      };
      beziers[i - 1] = new Bezier(pivots);
    }
  }
  
  private void Start() {
    GenBeziers();
    BuildLevel();
  }
}
