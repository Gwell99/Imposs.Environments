using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class AsciiArtFilter : MonoBehaviour {

    public enum ColorType
	{
		Mono,
		Color
	}
	public ColorType colorType;
	public Shader shaderMono;
	public Shader shaderColor;
	public Texture sample;
	public int sampleNumber = 8;
	[Range(1,100)]
	public float heightSegment = 40;
    // Use this for initialization
    private Material mat;
	protected void Start ()
	{
		if (!SystemInfo.supportsImageEffects) {
			enabled = false;
			return;
		}
		if (!shaderMono ||!shaderColor || !shaderMono.isSupported  || !shaderColor.isSupported)
			enabled = false;
	}

    private int frameCounter = 0;
    private const int FRAMES_PER_CHANGE = 30;

    void Update () {
        if (mat == null)
        {
            mat = new Material(colorType == ColorType.Mono ? shaderMono : shaderColor);
            mat.hideFlags = HideFlags.HideAndDontSave;
        }
        else if (mat.shader != (colorType == ColorType.Mono ? shaderMono : shaderColor))
        {
            mat.shader = colorType == ColorType.Mono ? shaderMono : shaderColor;
        }
        Camera cam = GetComponent<Camera>();
        mat.SetTexture("_SampleTex", sample);

        // Check if enough frames have passed to change the value
        if (frameCounter >= FRAMES_PER_CHANGE)
        {
            // Set heightSegment to a random value between 1 and 100
            heightSegment = Random.Range(20, 50);
            frameCounter = 0; // reset the counter
        }
        else
        {
            frameCounter++; // increment the counter
        }

        mat.SetFloat("_SegmentX", heightSegment * (float)cam.pixelRect.width / cam.pixelRect.height);
        mat.SetFloat("_SegmentY", heightSegment);
        mat.SetInt("_SampleNumber", sampleNumber);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
		Graphics.Blit(src, dest, mat);
	}

	void OnDisable(){
		DestroyImmediate (mat);
	}
}
