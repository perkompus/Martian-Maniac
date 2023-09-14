using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeScript : MonoBehaviour
{

    [SerializeField] private GameObject PelletParticles;
    [SerializeField] private GameObject LeafParticles;
    
    public GameObject innerBubblePrefab;
    [SerializeField] private float innerBubbleInitialSize;
    [SerializeField] private float innerBubbleTargetSize;

    public GameObject outerBubblePrefab;
    [SerializeField] private float outerBubbleInitialSize;
    [SerializeField] private float outerBubbleTargetSize;

    public float explosionDuration = 1f;
    private Vector3 TargetScale = Vector3.one * 1f;
    private Vector3 TargetScaleOuter = Vector3.one * 1f;
    float t = 0;
    ParticleSystem ps;
    ParticleSystem psl;
    private GameObject Bubble;
    private GameObject BubbleOuter;
    private GameObject PelletParticleSystem;
    private GameObject LeafParticleSystem;
    Vector3 startScale;
    Vector3 startScaleOuter;
	Vector3 newScale;
    void Start()
    {

        TargetScale = Vector3.one * innerBubbleTargetSize;
        TargetScaleOuter = Vector3.one * outerBubbleTargetSize;
        // ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
			Bubble = Instantiate(innerBubblePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			Bubble.transform.parent = gameObject.transform;
			startScale = Vector3.one * innerBubbleInitialSize;

            BubbleOuter = Instantiate(outerBubblePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			BubbleOuter.transform.parent = gameObject.transform;
			startScaleOuter = Vector3.one * outerBubbleInitialSize;
            
			t = 0;

            PelletParticleSystem = Instantiate(PelletParticles, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			PelletParticleSystem.transform.parent = gameObject.transform;
            ps = PelletParticleSystem.GetComponent<ParticleSystem>();
            ps.Play();

            LeafParticleSystem = Instantiate(LeafParticles, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			LeafParticleSystem.transform.parent = gameObject.transform;
            psl = LeafParticleSystem.GetComponent<ParticleSystem>();
            psl.Play();
        }

        if (Bubble != null )
		{
			StartCoroutine(LerpGameObject());

		}
    }

    public IEnumerator LerpGameObject()
	{
		t += Time.deltaTime / explosionDuration;

		Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t * 30);
		Bubble.transform.localScale = newScale;

        Vector3 newScaleOuter = Vector3.Lerp(startScaleOuter, TargetScaleOuter, t * 30);
		BubbleOuter.transform.localScale = newScaleOuter;

		yield return null;
	}
}
