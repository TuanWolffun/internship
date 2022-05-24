using System;
using Photon.Deterministic;
using Quantum;
using UnityEngine;

public class LocalInput : MonoBehaviour {
    private void Start() {
      QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
    }

    public void PollInput(CallbackPollInput callback) {
      Quantum.Input i = new Quantum.Input(); 
      i.Fire = UnityEngine.Input.GetMouseButton(0);

      var x = UnityEngine.Input.GetAxis("Horizontal");
      var y = UnityEngine.Input.GetAxis("Vertical");
      i.Direction = new Vector2(x,y).ToFPVector2();
      if(UnityEngine.Input.GetMouseButton(0))
        i.Fire = UnityEngine.Input.GetMouseButton(0);

      callback.SetInput(i, DeterministicInputFlags.Repeatable);
    }
}
