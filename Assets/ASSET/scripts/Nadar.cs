using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
[RequireComponent(typeof(FirstPersonController))]
public class Nadar : MonoBehaviour {
	public string TagAgua = "AGUA";
	[Range(-0.2f,0.2f)] public float toleranciaAltura = 0.1f;
	[Range(-0.5f,2.0f)] public float velocidadeVertical = 1.5f;
	private FirstPersonController FPSController;
	private CharacterController controlador;
	private bool dentroDaAgua = false;
	private float alturaDaAguaNoMundo, alturaAjusteControlador;
	private float originalWalkSpeed, originalRunSpeed, originalJumpSpeed, originalGravity;
	void Awake () {
		FPSController = GetComponent<FirstPersonController> ();
		controlador = GetComponent<CharacterController> ();
		alturaAjusteControlador = 0.275f * controlador.height;
		originalWalkSpeed = FPSController.m_WalkSpeed;
		originalRunSpeed = FPSController.m_RunSpeed;
		originalJumpSpeed = FPSController.m_JumpSpeed;
		originalGravity = FPSController.m_GravityMultiplier;
	}
	void Update () {
		if (dentroDaAgua == true && (transform.position.y < (alturaDaAguaNoMundo - alturaAjusteControlador + (toleranciaAltura * alturaAjusteControlador)))) {
			FPSController.m_WalkSpeed = 2.0f;
			FPSController.m_RunSpeed = 2.0f;
			FPSController.m_JumpSpeed = 0.0f;
			//
			float inputGravidadeY = (-Camera.main.transform.forward.y / 20.0f) * Input.GetAxis ("Vertical") * velocidadeVertical;
			if (Input.GetKey (KeyCode.Space)) {
				inputGravidadeY -= 0.15f * velocidadeVertical;
			}
			if (Mathf.Abs (controlador.velocity.y) > 2.0f) {
				inputGravidadeY += controlador.velocity.y * velocidadeVertical;
			}
			FPSController.m_GravityMultiplier = inputGravidadeY;
			if (Mathf.Abs (Input.GetAxis ("Vertical")) < 0.5f && Mathf.Abs (Input.GetAxis ("Horizontal")) < 0.5f && !Input.GetKey (KeyCode.Space)) {
				FPSController.m_GravityMultiplier = 0;
				FPSController.m_MoveDir = Vector3.Lerp (FPSController.m_MoveDir, Vector3.zero, Time.deltaTime * 2.0f);
			}
		} else {
			FPSController.m_WalkSpeed = Mathf.Lerp (FPSController.m_WalkSpeed, originalWalkSpeed, Time.deltaTime * 2.0f);
			FPSController.m_RunSpeed = Mathf.Lerp (FPSController.m_RunSpeed, originalRunSpeed, Time.deltaTime * 2.0f);
			FPSController.m_JumpSpeed = Mathf.Lerp (FPSController.m_JumpSpeed, originalJumpSpeed, Time.deltaTime * 0.5f);
			FPSController.m_GravityMultiplier = Mathf.Lerp (FPSController.m_GravityMultiplier, originalGravity, Time.deltaTime * 2.0f);
		}
	}
	void OnTriggerEnter(Collider colisor){
		if (colisor.gameObject.CompareTag (TagAgua)) {
			dentroDaAgua = true;
			alturaDaAguaNoMundo = colisor.gameObject.GetComponent<BoxCollider> ().bounds.center.y + colisor.gameObject.GetComponent<BoxCollider> ().bounds.extents.y;
		}
	}
	void OnTriggerExit(Collider colisor){
		if (colisor.gameObject.CompareTag (TagAgua)) {
			dentroDaAgua = false;
		}
	}
}
