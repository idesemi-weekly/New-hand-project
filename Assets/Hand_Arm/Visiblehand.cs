using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using System.Collections.Generic;
using UnityEngine.UI;

public class Visiblehand : MonoBehaviour
{
    [SerializeField]
    GameObject m_ProviderObject;
    public Text scoreText;

    LeapServiceProvider m_Provider;
    // Start is called before the first frame update
    void Start()
    {
        m_Provider = m_ProviderObject.GetComponent<LeapServiceProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = m_Provider.CurrentFrame;

        // 右手と左手を取得する
        Hand rightHand = null;
        Hand leftHand = null;
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsRight)
            {
                rightHand = hand;
            }
            if (hand.IsLeft)
            {
                leftHand = hand;
            }
        }

        if (rightHand != null)
        {
            Debug.Log(rightHand.Fingers[0].TipPosition);
        }
    }
}