﻿using System;
using Project.Scripts.Runtime.Exception;
using UniRx.Async;
using UnityEngine.Networking;

namespace Common.Scripts.Runtime.Utils
{
    public class ApiBuilder : IApiBuilder
    {
        public IObservable<string> GetObservable(string uri) => GetAsync(uri).ToObservable();
        
        public async UniTask<string> GetAsync(string uri)
        {
            var uwr = UnityWebRequest.Get(uri);
            await uwr.SendWebRequest();
            if (uwr.isHttpError || uwr.isNetworkError) throw new ApiException(uwr.error);
            return uwr.downloadHandler.text;
        }
    }

    public interface IApiBuilder
    {
        IObservable<string> GetObservable(string uri);
        
        UniTask<string> GetAsync(string uri);
    }
}