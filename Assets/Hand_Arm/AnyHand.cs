using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System.Collections.Generic;

public class AnyHand : MonoBehaviour {

    [SerializeField]
    GameObject m_ProviderObject;

    LeapServiceProvider m_Provider;

    void Start () {
        m_Provider = m_ProviderObject.GetComponent<LeapServiceProvider>();
    }

    void Update() {
        Frame frame = m_Provider.CurrentFrame;

         // 右手を取得する
        Hand rightHand = null;
        foreach (Hand hand in frame.Hands) {
            if (hand.IsRight) {
                rightHand = hand;
                break;
            }
        }

        if (rightHand == null) {
            return;
        }

        // 手のひらの法線
        Vector3 normal = rightHand.PalmNormal;

        // 手の向き
        Vector3 direction = rightHand.Direction;

    }
 }
