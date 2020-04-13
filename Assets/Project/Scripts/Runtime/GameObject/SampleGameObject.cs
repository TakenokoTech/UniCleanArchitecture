using System;
using System.Collections;
using Runtime.Exception;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Networking;
using Log = Runtime.Utils.Log;

namespace Runtime.GameObject
{
    public class SampleGameObject : MonoBehaviour
    {
        private const string Tag = "SampleGameObject";

        void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.A))
                .Subscribe(_ => Do());

            Observable.FromCoroutine<string>(observer => GetApiAsync(observer, "localhost:8080"))
                .Subscribe(next => Log.D(Tag, next), err => Log.D(Tag, err.Message));
        }

        void Update()
        {
        }

        private void Do()
        {
            Log.D(Tag, "Do");
        }

        private IEnumerator GetApiAsync(IObserver<string> observer, string uri)
        {
            var www = UnityWebRequest.Get(uri);

            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                observer.OnError(new ApiException(www.error));
            }
            else
            {
                observer.OnNext(www.downloadHandler.text);
                observer.OnCompleted();
            }
        }
    }
}