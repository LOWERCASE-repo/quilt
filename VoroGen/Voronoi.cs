using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Voronoi : MonoBehaviour {
  
  [SerializeField]
  private Vector2Int size;
  [SerializeField]
  private int zoneCount;
  
  [SerializeField]
  private SpriteRenderer renderer;
  
  private void Start() {
    renderer.sprite = Sprite.Create(
      GetDiagram(),
      new Rect(0, 0, size.x, size.y),
      Vector2.one * 0.5f
    );
  }
  
  private Texture2D GetDiagram() {
    
    Vector2Int[] centroids = new Vector2Int[zoneCount];
    Color[] zones = new Color[zoneCount];
    for (int i = 0; i < zoneCount; i++) {
      centroids[i] = new Vector2Int(Random.Range(0, size.x), Random.Range(0, size.y));
      zones[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
    }
    
    Color[] pixelColors = new Color[size.x * size.x + size.y];
    for (int x = 0; x < size.x; x++) {
      for (int y = 0; y < size.y; y++) {
        int index = x * size.x + y;
        pixelColors[index] = zones[GetClosestCentroid(new Vector2Int(x, y), centroids)];
      }
    }
    return GenImage(pixelColors);
  }
  
  private int GetClosestCentroid(Vector2Int pos, Vector2Int[] centroids) {
    float minDist = float.MaxValue;
    int index = 0;
    for (int i = 0; i < centroids.Length; i++) {
      float dist = (pos - centroids[i]).sqrMagnitude;
      if (dist < minDist) {
        minDist = dist;
        index = i;
      }
    }
    return index;
  }
  
  private Texture2D GenImage(Color[] pixelColors) {
    Texture2D tex = new Texture2D(size.x, size.y);
    tex.filterMode = FilterMode.Point;
    tex.SetPixels(pixelColors);
    tex.Apply();
    return tex;
  }
}
