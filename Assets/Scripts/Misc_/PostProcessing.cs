using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessing : MonoBehaviour
{

    private Material mMaterial;
    public Shader shader;

    // Start is called before the first frame update
    void Start()
    {
        mMaterial = new Material(shader);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, dest, mMaterial);
    }

}
