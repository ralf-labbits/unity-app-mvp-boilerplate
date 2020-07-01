using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UniRx;
using UnityEngine.Networking;

namespace RxRest
{
    public class RestClient
    {
        public static Dictionary<string, string> mHeader = new Dictionary<string, string>() { { "Content-Type", "application/json" } };

        public static IObservable<T> Get<T>(string url, Dictionary<String, String> header = null)
        {
            return Observable.FromCoroutine<T>((observer, cancellationToken) => UnityGet(url, header, observer, cancellationToken));
        }

        public static IObservable<string> Get(string url, Dictionary<String, String> header = null)
        {
            return Observable.FromCoroutine<string>((observer, cancellationToken) => UnityGet(url, header, observer, cancellationToken));
        }

        //public static IObservable<T> Post<T>(string url, T postData, Dictionary<string, string> header = null)
        //{
        //    return Observable.FromCoroutine<T>((observer, cancellation) => UnityPost(url, postData, observer, cancellation, header));
        //}

        public static IObservable<T> Post<T>(string url, T body, Dictionary<string, string> header = null)
        {
            var requestHeader = RestClient.mHeader;
            if (header != null) header.ToList().ForEach(m => requestHeader.Add(m.Key, m.Value));

            var bodyJson = JsonConvert.SerializeObject(body);
            var b = Encoding.ASCII.GetBytes(bodyJson);

            return ObservableWWW.Post(url, b, requestHeader).Select(data => JsonConvert.DeserializeObject<T>(data));
        }

        public static IObservable<string> Post(string url, string body, Dictionary<string, string> header = null)
        {
            var requestHeader = RestClient.mHeader;
            if (header != null) header.ToList().ForEach(m => requestHeader.Add(m.Key, m.Value));

            var b = Encoding.ASCII.GetBytes(body);

            return ObservableWWW.Post(url, b, requestHeader);
        }

        static IEnumerator UnityGet<T>(string url, Dictionary<string, string> header, IObserver<T> observer, CancellationToken cancellationToken)
        {
            var requestHeader = RestClient.mHeader;
            if (header != null) header.ToList().ForEach(m => requestHeader.Add(m.Key, m.Value));

            UnityWebRequest webRequest = UnityWebRequest.Get(url);

            foreach (var h in requestHeader)
            {
                webRequest.SetRequestHeader(h.Key, h.Value);
            }

            webRequest.SendWebRequest();

            while (!webRequest.isDone && !cancellationToken.IsCancellationRequested)
            {
                yield return null;
            }
            //yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                observer.OnError(new Exception(webRequest.error));
            }
            else
            {
                observer.OnNext(JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text));
            }
            observer.OnCompleted();
        }

        static IEnumerator UnityGet(string url, Dictionary<string, string> header, IObserver<string> observer, CancellationToken cancellationToken)
        {
            var requestHeader = RestClient.mHeader;
            if (header != null) header.ToList().ForEach(m => requestHeader.Add(m.Key, m.Value));

            UnityWebRequest webRequest = UnityWebRequest.Get(url);

            foreach (var h in requestHeader)
            {
                webRequest.SetRequestHeader(h.Key, h.Value);
            }

            //webRequest.SendWebRequest();

            //while (!webRequest.isDone && !cancellationToken.IsCancellationRequested)
            //{
            //    yield return null;
            //}
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                observer.OnError(new Exception(webRequest.error));
            }
            else
            {
                observer.OnNext(webRequest.downloadHandler.text);
            }
            observer.OnCompleted();
        }


        //private static IEnumerator UnityPost<T>(string url, T postData, IObserver<T> observer, CancellationToken cancellationToken, Dictionary<string, string> header = null)
        //{
        //    var requestHeader = RestClient.mHeader;
        //    if (header != null) header.ToList().ForEach(m => requestHeader.Add(m.Key, m.Value));

        //    var post = JsonConvert.SerializeObject(postData).Replace("\"","");

        //    UnityWebRequest webRequest = UnityWebRequest.Post(url, post);
        //    requestHeader.ToList().ForEach(m => webRequest.SetRequestHeader(m.Key, m.Value));

        //    webRequest.SendWebRequest();

        //    while (!webRequest.isDone && !cancellationToken.IsCancellationRequested)
        //    {
        //        yield return null;
        //    }

        //    if (webRequest.isNetworkError || webRequest.isHttpError)
        //    {
        //        observer.OnError(new Exception(webRequest.error));
        //    } else
        //    {
        //        observer.OnNext(JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text));
        //    }
        //    observer.OnCompleted();
        //}

        //private static IEnumerator UnityPost(string url, string postData, IObserver<string> observer, CancellationToken cancellationToken, Dictionary<string, string> header = null)
        //{
        //    var requestHeader = RestClient.mHeader;
        //    if (header != null) header.ToList().ForEach(m => requestHeader.Add(m.Key, m.Value));

        //    UnityWebRequest webRequest = UnityWebRequest.Post(url, postData);
        //    requestHeader.ToList().ForEach(m => webRequest.SetRequestHeader(m.Key, m.Value));

        //    webRequest.SendWebRequest();

        //    while (!webRequest.isDone && !cancellationToken.IsCancellationRequested)
        //    {
        //        yield return null;
        //    }

        //    if (webRequest.isNetworkError || webRequest.isHttpError)
        //    {
        //        observer.OnError(new Exception(webRequest.error));
        //    }
        //    else
        //    {
        //        observer.OnNext(webRequest.downloadHandler.text);
        //    }
        //    observer.OnCompleted();
        //}
    }
}