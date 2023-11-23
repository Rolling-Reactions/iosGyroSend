using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class gyro_control : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        photonView.RPC("RPC_HandleGyroscopeInput", RpcTarget.All, Input.gyro.attitude.x, Input.gyro.attitude.y, Input.gyro.attitude.z, Input.gyro.attitude.w);
    }

    [PunRPC]
    private void RPC_HandleGyroscopeInput(float x, float y, float z, float w)
    {
        transform.rotation = new Quaternion(x, y, -z, -w);
        Debug.Log($"Received Gyroscope Data: x={x}, y={y}, z={z}, w={w}");
    }

}
