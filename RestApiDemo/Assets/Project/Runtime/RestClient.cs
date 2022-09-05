using System;
using System.Collections;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace RestApiDemo
{
    public class RestClient
    {
        public IEnumerator Get(string url, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var request = new UnityWebRequest(url, "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            
            yield return request.SendWebRequest();
            
            OnCompleteRequest(request, onSuccess, onFail);
        }
        
        public async UniTask GetAsync(string url, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var request = new UnityWebRequest(url, "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            
            await request.SendWebRequest();;
            
            OnCompleteRequest(request, onSuccess, onFail);
        }
        
        
        public IEnumerator Post(string url, string data, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(new UTF8Encoding().GetBytes(data));
            request.downloadHandler = new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            OnCompleteRequest(request, onSuccess, onFail);
        }
        
        public async UniTask PostAsync(string url, string data, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(new UTF8Encoding().GetBytes(data));
            request.downloadHandler = new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();

            OnCompleteRequest(request, onSuccess, onFail);
        }
        
        
        public IEnumerator Put(string url, string data, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var request = new UnityWebRequest(url, "PUT");
            request.uploadHandler = new UploadHandlerRaw(new UTF8Encoding().GetBytes(data));
            request.downloadHandler = new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            OnCompleteRequest(request, onSuccess, onFail);
        }

        public async UniTask PutAsync(string url, string data, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var request = new UnityWebRequest(url, "PUT");
            request.uploadHandler = new UploadHandlerRaw(new UTF8Encoding().GetBytes(data));
            request.downloadHandler = new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();

            OnCompleteRequest(request, onSuccess, onFail);
        }
        
        
        public IEnumerator Delete(string url, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var request = new UnityWebRequest(url, "DELETE");
            request.downloadHandler = new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            OnCompleteRequest(request, onSuccess, onFail);
        }
        
        public async UniTask DeleteAsync(string url, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var request = new UnityWebRequest(url, "DELETE");
            request.downloadHandler = new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();

            OnCompleteRequest(request, onSuccess, onFail);
        }
        
        
        private void OnCompleteRequest(UnityWebRequest request, Action<string> onSuccess, Action<UnityWebRequest.Result> onFail)
        {
            var responseData = Encoding.UTF8.GetString(request.downloadHandler.data);
            
            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(responseData);
            }
            else if (request.result == UnityWebRequest.Result.ConnectionError || 
                     request.result == UnityWebRequest.Result.ProtocolError || 
                     request.result == UnityWebRequest.Result.DataProcessingError)
            {
                onFail?.Invoke(request.result);
            }
        }
    }
}