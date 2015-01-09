#pragma strict

private var crouching : boolean = false;

public var crouchDeltaHeight : float = 0.5f;
public var crouchingCamHeight : float = 1.0f;
public var standardCamHeight : float = 3.0f;

function Start () {

}

function Update () {
	
	if( Input.GetButton("Crouch"))
	{
		if(!crouching)
		{
			crouch();
			return;
		}
	}
	else
	{
		if(crouching)
		{
			stopCrouching();
			return;
		}
	}
	
//	if (Input.GetButtonDown ("Crouch")){
//	    if(crouching){
//	        stopCrouching();
//	        return;
//	    }
//	 
//	    if(!crouching)
//	        crouch();
//	}

	if(crouching){
	    if(Camera.main.transform.localPosition.y > crouchingCamHeight){
	        if(Camera.main.transform.localPosition.y - (crouchDeltaHeight*Time.deltaTime*8) < crouchingCamHeight){
	            Camera.main.transform.localPosition.y = crouchingCamHeight;
	        } else {
	            Camera.main.transform.localPosition.y -= crouchDeltaHeight*Time.deltaTime*8;
	        }
	    }
	} else {
	    if(Camera.main.transform.localPosition.y < standardCamHeight){
	        if(Camera.main.transform.localPosition.y + (crouchDeltaHeight*Time.deltaTime*8) > standardCamHeight){
	            Camera.main.transform.localPosition.y = standardCamHeight;
	        } else {
	            Camera.main.transform.localPosition.y += crouchDeltaHeight*Time.deltaTime*8;
	        }
	    } 
	}
}

function crouch() {
        (collider as CapsuleCollider).height -= crouchDeltaHeight;
        (collider as CapsuleCollider).center -= Vector3(0,crouchDeltaHeight/2, 0);
        crouching = true;
    }
    
function stopCrouching(){
            crouching = false;
            (collider as CapsuleCollider).height += crouchDeltaHeight;
        	(collider as CapsuleCollider).center += Vector3(0,crouchDeltaHeight/2, 0);
        }