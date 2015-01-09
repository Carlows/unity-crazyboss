using UnityEngine;
using System.Collections;

public class IABossController : MonoBehaviour {

	public Transform _target;
	private NavMeshAgent _agent;
	private Animator _anim;
	private BossTrigger _trigger;
	public GameObject teddy;

	private float timer;
	private float TimeToSetTarget = 5.0f;

	private float _timerHide;
	// Use this for initialization
	void Start () {
		_trigger = GetComponent<BossTrigger>();
		_anim = GetComponentInChildren<Animator>();
		_agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {		
//		_anim.SetFloat("Speed", _agent.velocity.magnitude);
//
//		timer += Time.deltaTime;
//
//		Color textureColor = teddy.renderer.material.color;
//		textureColor.a = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
//		teddy.renderer.material.color = textureColor;
		if(_trigger.TalkedToMe)
		{
			//teddy.SetActive(false);
		}
		if(_trigger.BossFaseOn)
		{
			if( timer > TimeToSetTarget )
			{
				_agent.SetDestination(_target.position);
				timer = 0;
			}
		}
	}
}
