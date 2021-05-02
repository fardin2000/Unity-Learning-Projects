﻿using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;
    void Start() {
        offsetX = Random.Range(0f, 999999f);
        offsetY = Random.Range(0f, 999999f);
    }
    void Update () {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture() {
        Texture2D texture = new Texture2D(width, height);

        // generate with perlin noise
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y) {

        float xCord = (float)x / width * scale + offsetX;
        float yCord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCord, yCord);
        return new Color(sample, sample, sample);
    }

}
