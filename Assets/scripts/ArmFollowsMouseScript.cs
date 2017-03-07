using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmFollowsMouseScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        var pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        Vector3 current_direction = this.transform.right;
        var q = Quaternion.FromToRotation(this.transform.up, pos - transform.position);


        this.transform.Rotate(q.eulerAngles);

    }
}
