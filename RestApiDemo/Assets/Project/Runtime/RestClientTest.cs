using UnityEngine;
using UnityEngine.UI;

namespace RestApiDemo
{
    public class RestClientTest : MonoBehaviour
    {
        #region Content: UI

        [Header("Content: UI")]
        
        [SerializeField]
        private Text _txtRequest;
        
        [SerializeField]
        private Text _txtResponse;

        #endregion
        
        private readonly RestClient _restClient = new RestClient();
        
        
        public async void TestGet(bool isAsync)
        {
            _txtRequest.text = "(GET) - https://dummyjson.com/products";
            
            if (isAsync)
            {
                await _restClient.GetAsync("https://dummyjson.com/products",
                    (data) =>
                    {
                        var log = $"Async Get - Success\nData: {data}";
                        _txtResponse.text = data;
                        Debug.Log(log);
                    },
                    (result) =>
                    {
                        var log = $"Async Get - Fail - Error: {result}";
                        _txtResponse.text = result.ToString();
                        Debug.Log(log);
                    });
            }
            else
            {
                StartCoroutine(_restClient.Get("https://dummyjson.com/products",
                    (data) =>
                    {
                        var log = $"Get - Success\nData: {data}";
                        _txtResponse.text = log;
                        Debug.Log(log);
                    },
                    (result) =>
                    {
                        var log = $"Get - Fail - Error: {result}";
                        _txtResponse.text = result.ToString();
                        Debug.Log(log);
                    }));
            }
        }

        public async void TestPost(bool isAsync)
        {
            var productData = @"{
                                ""title"": ""iPhone 9"",

                                ""description"": ""An apple mobile which is nothing like apple"",
                                ""price"": 549,
                                ""discountPercentage"": 12.96,
                                ""rating"": 4.69,
                                ""stock"": 94,
                                ""brand"": ""Apple"",
                                ""category"": ""smartphones"",
                                ""thumbnail"": ""https://dummyjson.com/image/i/products/1/thumbnail.jpg"",
                                ""images"": 
                                    [
                                        ""https://dummyjson.com/image/i/products/1/1.jpg"",
                                        ""https://dummyjson.com/image/i/products/1/2.jpg"",
                                        ""https://dummyjson.com/image/i/products/1/3.jpg"",
                                        ""https://dummyjson.com/image/i/products/1/4.jpg"",
                                        ""https://dummyjson.com/image/i/products/1/thumbnail.jpg""
                                    ]
                            }";

            _txtRequest.text = "(POST) - https://dummyjson.com/products/add";
            
            if (isAsync)
            {
                await _restClient.PostAsync("https://dummyjson.com/products/add",
                    productData,
                    (data) =>
                    {
                        var log = $"Async Post - Success\nData: {data}";
                        _txtResponse.text = data;
                        Debug.Log(log);
                    },
                    (result) =>
                    {
                        var log = $"Async Post - Fail - Error: {result}";
                        _txtResponse.text = result.ToString();
                        Debug.Log(log);
                    });
            }
            else
            {
                StartCoroutine(_restClient.Post("https://dummyjson.com/products/add", 
                    productData,
                    (data) =>
                    {
                        var log = $"Post - Success\nData: {data}";
                        _txtResponse.text = data;
                        Debug.Log(log);
                    },
                    (result) =>
                    {
                        var log = $"Post - Fail - Error: {result}";
                        _txtResponse.text = result.ToString();
                        Debug.Log(log);
                    }));
            }
        }
        
        public async void TestPut(bool isAsync)
        {
            var productData = @"{
                                ""title"": ""Title Has Changed!!! - iPhone 9999"",

                                ""description"": ""An apple mobile which is nothing like apple"",
                                ""price"": 549,
                                ""discountPercentage"": 12.96,
                                ""rating"": 4.69,
                                ""stock"": 94,
                                ""brand"": ""Apple"",
                                ""category"": ""smartphones"",
                                ""thumbnail"": ""https://dummyjson.com/image/i/products/1/thumbnail.jpg"",
                                ""images"": 
                                    [
                                        ""https://dummyjson.com/image/i/products/1/1.jpg"",
                                        ""https://dummyjson.com/image/i/products/1/2.jpg"",
                                        ""https://dummyjson.com/image/i/products/1/3.jpg"",
                                        ""https://dummyjson.com/image/i/products/1/4.jpg"",
                                        ""https://dummyjson.com/image/i/products/1/thumbnail.jpg""
                                    ]
                            }";

            _txtRequest.text = "(PUT) - https://dummyjson.com/products/1";
            
            if (isAsync)
            {
                await _restClient.PutAsync("https://dummyjson.com/products/1",
                    productData,
                    (data) =>
                    {
                        var log = $"Async Put - Success\nData: {data}";
                        _txtResponse.text = data;
                        Debug.Log(log);
                    },
                    (result) =>
                    {
                        var log = $"Async Put - Fail - Error: {result}";
                        _txtResponse.text = result.ToString();
                        Debug.Log(log);
                    });
            }
            else
            {
                StartCoroutine(_restClient.Put("https://dummyjson.com/products/1", 
                    productData,
                    (data) =>
                    {
                        var log = $"Put - Success\nData: {data}";
                        _txtResponse.text = data;
                        Debug.Log(log);
                    },
                    (result) =>
                    {
                        var log = $"Put - Fail - Error: {result}";
                        _txtResponse.text = result.ToString();
                        Debug.Log(log);
                    }));
            }
        }
        
        public async void TestDelete(bool isAsync)
        {
            _txtRequest.text = "(DELETE) - https://dummyjson.com/products/1";
            
            if (isAsync)
            {
                await _restClient.DeleteAsync("https://dummyjson.com/products/1",
                    (data) =>
                    {
                        var log = $"Async Delete - Success\nData: {data}";
                        _txtResponse.text = data;
                        Debug.Log(log);
                    },
                    (result) =>
                    {
                        var log = $"Async Delete - Fail - Error: {result}";
                        _txtResponse.text = result.ToString();
                        Debug.Log(log);
                    });
            }
            else
            {
                StartCoroutine(_restClient.Delete("https://dummyjson.com/products/1",
                    (data) =>
                    {
                        var log = $"Delete - Success\nData: {data}";
                        _txtResponse.text = data;
                        Debug.Log(log);
                    },
                    (result) =>
                    {
                        var log = $"Delete - Fail - Error: {result}";
                        _txtResponse.text = result.ToString();
                        Debug.Log(log);
                    }));
            }
        }


        public void ClearLog()
        {
            _txtRequest.text = "";
            _txtResponse.text = "";
        }
    }
}