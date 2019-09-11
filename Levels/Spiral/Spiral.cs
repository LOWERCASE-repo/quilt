using UnityEngine;
using System.Collections.Generic;

public class Spiral : LevelStyle {
  
  [SerializeField]
  private float radius;
  [SerializeField]
  private float cycles;
  
  private float totalRot;
  
  private void Eval(float time) {
    Quaternion rot = Quaternion.AngleAxis(totalRot * time, Vector3.forward);
    return rot * Vector2.up * time * radius;
  }
  
  private void Start() {
    totalRot = cycles * 360f;
    BuildLevel();
  }
}
