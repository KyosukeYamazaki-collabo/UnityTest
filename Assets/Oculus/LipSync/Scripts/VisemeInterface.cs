using UnityEngine;
using System.Linq;

public class VisemeInterface : MonoBehaviour
{
    new AudioSource audio;
    OVRLipSyncContextMorphTarget morphTarget;
    float[] wavedata = new float[1024];

    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        morphTarget = this.GetComponent<OVRLipSyncContextMorphTarget>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        audio.GetOutputData(wavedata, 1);
        Debug.Log(GetLoudness());
    }


    /// <summary> 
    /// 指定されたVisemeのBlendShapeの値をFloatで受け取る。
    /// TargetNum
    ///    0 sil,
    ///    1 PP,
    ///    2 FF,
    ///    3 TH,
    ///    4 DD,
    ///    5 kk,
    ///    6 CH,
    ///    7 SS,
    ///    8 nn,
    ///    9 RR,
    ///    10 aa,
    ///    11 E,
    ///    12 ih,
    ///    13 oh,
    ///    14 ou
    /// </summary>
    /// <param name="TargetNum">欲しいBlendShape値が格納されているVisemeの番号（上記参照）</param>
    public float GetVisemeValue(int TargetNum)
    {
        float num = 0;
        num = morphTarget.frame.Visemes[TargetNum] * 100.0f;
        return num;
    }


    /// <summary>
    /// 音圧をFloatで返す
    /// </summary>
    /// <returns></returns>
    public float GetLoudness()
    {
        return wavedata.Select(x => x * x).Sum() / wavedata.Length;
    }

}
