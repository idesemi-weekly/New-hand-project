using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class VisibleBallHand : MonoBehaviour
{
    public Hand rightHand;
    [SerializeField]
    GameObject m_ProviderObject;

    LeapServiceProvider m_Provider;

    public Text scoreText;
    public GameObject Apple;

    Vector3 right_normal;
    Vector3 right_direction;
    Vector3 right_position;
    Vector3 left_normal;
    Vector3 left_direction;
    Vector3 left_position;

    public float distance;

    public NewBehaviourScript demoscript;
    
    void Start()
    {
        m_Provider = m_ProviderObject.GetComponent<LeapServiceProvider>();
    }

    

    void Update()
    {
        Frame frame = m_Provider.CurrentFrame;

        rightHand = null;
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

        if (rightHand == null && leftHand == null)
        {
            return;
        }

        
        float distance;

        if (rightHand != null && leftHand != null)
        {
            right_normal = rightHand.PalmNormal;
            right_direction = rightHand.Direction;
            right_position = rightHand.PalmPosition;
            left_normal = leftHand.PalmNormal;
            left_direction = leftHand.Direction;
            left_position = leftHand.PalmPosition;
            distance = Vector3.Distance(right_position, left_position);
            scoreText.text = "右手の指先:"+ rightHand.Fingers[0].TipPosition.ToString()+"\n"+
                             "右手の指先1:" + rightHand.Fingers[1].TipPosition.ToString() + "\n" +
                             "右手の指先2:" + rightHand.Fingers[2].TipPosition.ToString() + "\n" +
                             "右手の指先3:" + rightHand.Fingers[3].TipPosition.ToString() + "\n" +
                             "右手の指先4:" + rightHand.Fingers[4].TipPosition.ToString() + "\n" +
                             "右手の法線ベクトル: " + right_normal + "\n" +
                             "右手の方向ベクトル: " + right_direction + "\n" +
                             "右手の位置ベクトル: " + right_position + "\n" +
                             "左手の指先:"+ leftHand.Fingers[0].TipPosition.ToString()+"\n"+
                             "左手の指先1:" + leftHand.Fingers[1].TipPosition.ToString() + "\n" +
                             "左手の指先2:" + leftHand.Fingers[2].TipPosition.ToString() + "\n" +
                             "左手の指先3:" + leftHand.Fingers[3].TipPosition.ToString() + "\n" +
                             "左手の指先4:" + leftHand.Fingers[4].TipPosition.ToString() + "\n" +
                             "左手の法線ベクトル: " + left_normal + "\n" +
                             "左手の方向ベクトル: " + left_direction + "\n" +
                             "左手の位置ベクトル: " + left_position + "\n" +
                             "内積: " + Vector3.Dot(right_normal, left_normal) + "\n" +
                             "中点: " + Vector3.Lerp(right_position, left_position, 0.5f) + "\n" +
                             "２点間の距離: " + distance;
        }

        if (rightHand != null && leftHand == null)
        {
            right_normal = rightHand.PalmNormal;
            right_direction = rightHand.Direction;
            right_position = rightHand.PalmPosition;
            scoreText.text = "右手の指先:"+ rightHand.Fingers[0].TipPosition.ToString()+"\n"+
                             "右手の指先1:" + rightHand.Fingers[1].TipPosition.ToString() + "\n" +
                             "右手の指先2:" + rightHand.Fingers[2].TipPosition.ToString() + "\n" +
                             "右手の指先3:" + rightHand.Fingers[3].TipPosition.ToString() + "\n" +
                             "右手の指先4:" + rightHand.Fingers[4].TipPosition.ToString() + "\n" +
                             "右手の法線ベクトル: " + right_normal + "\n" +
                             "右手の方向ベクトル: " + right_direction + "\n" +
                             "右手の位置ベクトル: " + right_position;
        }
        if (rightHand == null && leftHand != null)
        {
            left_normal = leftHand.PalmNormal;
            left_direction = leftHand.Direction;
            left_position = leftHand.PalmPosition;
            scoreText.text = "左手の指先:"+ leftHand.Fingers[0].TipPosition.ToString()+"\n"+
                             "左手の指先1:" + leftHand.Fingers[1].TipPosition.ToString() + "\n" +
                             "左手の指先2:" + leftHand.Fingers[2].TipPosition.ToString() + "\n" +
                             "左手の指先3:" + leftHand.Fingers[3].TipPosition.ToString() + "\n" +
                             "左手の指先4:" + leftHand.Fingers[4].TipPosition.ToString() + "\n" +
                             "左手の法線ベクトル: " + left_normal + "\n" +
                             "左手の方向ベクトル: " + left_direction + "\n" +
                             "左手の位置ベクトル: " + left_position;
        }
    }

    /*public void BallHand()
    {
        Frame frame = m_Provider.CurrentFrame;

        Hand rightHand = null;
        Hand leftHand = null;

        float distance;

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

        if (rightHand == null && leftHand == null)
        {
            return;
        }

        // 以下のコードはrightHandとleftHandがnullでないことを確認した後に実行する
        right_normal = rightHand.PalmNormal;
        right_direction = rightHand.Direction;
        right_position = rightHand.PalmPosition;
        left_normal = leftHand.PalmNormal;
        left_direction = leftHand.Direction;
        left_position = leftHand.PalmPosition;
        distance = Vector3.Distance(right_position, left_position);

        rightHand.Fingers[0].TipPosition.ToString();
        rightHand.Fingers[1].TipPosition.ToString();
        rightHand.Fingers[2].TipPosition.ToString();
        rightHand.Fingers[3].TipPosition.ToString();
        rightHand.Fingers[4].TipPosition.ToString();

        leftHand.Fingers[0].TipPosition.ToString();
        leftHand.Fingers[1].TipPosition.ToString();
        leftHand.Fingers[2].TipPosition.ToString();
        leftHand.Fingers[3].TipPosition.ToString();
        leftHand.Fingers[4].TipPosition.ToString();
    }*/

}
