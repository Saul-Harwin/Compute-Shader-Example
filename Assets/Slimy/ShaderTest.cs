using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour {
    public ComputeShader computeShader;
    public RenderTexture renderTexture;
    
    public Mesh mesh;
    public Material material;

    // Start is called before the first frame update
    void Start() {
        renderTexture = new RenderTexture(256, 256, 24);
            renderTexture.enableRandomWrite = true;
            renderTexture.Create();

            computeShader.SetTexture(0, "Result", renderTexture);
            computeShader.SetFloat("resolution", renderTexture.width);
            computeShader.Dispatch(0, renderTexture.width / 8, renderTexture.height / 8, 1);
    }

    // private void OnRenderImage(RenderTexture src, RenderTexture dest) {
    //     if (renderTexture == null) {
    //         renderTexture = new RenderTexture(256, 256, 24);
    //         renderTexture.enableRandomWrite = true;
    //         renderTexture.Create();
    //     }

    //     // computeShader.SetInt("width", 256);
    //     // computeShader.SetInt("height", 256);
    //     computeShader.Dispatch(0, 8, 1, 1);

    //     Graphics.Blit(renderTexture, dest);
    // }
}
