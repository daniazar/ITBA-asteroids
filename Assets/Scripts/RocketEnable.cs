using UnityEngine;
using System.Collections;

public class RocketEnable : MonoBehaviour {
	ParticleEmitter[] renderers;
	// Use this for initialization
	void Start () {
		renderers  = gameObject.GetComponentsInChildren<ParticleEmitter>();
	}

	float acel = 0F;
    float turn = 0F;
	
	// Update is called once per frame
	void Update () {
 
        acel = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");
 
		if(acel > 0 || turn != 0){ 
   			 foreach(ParticleEmitter re in renderers) {
    		    re.emit = true;
	    	}
		}else{
	   		 foreach(ParticleEmitter re in renderers) {
	    	    re.emit = false;
	    	}
		}
	}
	
/*	
	//Anda pero muy brusco.....
	void Update() {
	    if (Input.GetKeyDown(KeyCode.Z)) {
	        ToggleVisibility();
	    }
	}

   void ToggleVisibility() {
	    // toggles the visibility of this gameobject and all it's children
   
   		 foreach(ParticleEmitter re in renderers) {
    	    re.emit = !re.emit;
    	}
	}
*/	
	//Anda pero no para particulas.......
/*	void Update() {
	    if (Input.GetKeyDown(KeyCode.Z)) {
	        ToggleVisibility();
	    }
	}

   void ToggleVisibility() {
	    // toggles the visibility of this gameobject and all it's children
   		 Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
   		 foreach(Renderer re in renderers) {
    	    re.enabled = !re.enabled;
    	}
	}*/
}
