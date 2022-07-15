# Gateway.ApiClient.Api.CustomerApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateNewCustomer**](CustomerApi.md#createnewcustomer) | **POST** /Customer | 
[**GetCustomerById**](CustomerApi.md#getcustomerbyid) | **GET** /Customer/{id} | 
[**ListAllCustomers**](CustomerApi.md#listallcustomers) | **GET** /Customer | 


<a name="createnewcustomer"></a>
# **CreateNewCustomer**
> Guid CreateNewCustomer (string body = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Gateway.ApiClient.Api;
using Gateway.ApiClient.Client;
using Gateway.ApiClient.Model;

namespace Example
{
    public class CreateNewCustomerExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new CustomerApi(config);
            var body = "body_example";  // string |  (optional) 

            try
            {
                Guid result = apiInstance.CreateNewCustomer(body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomerApi.CreateNewCustomer: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | **string**|  | [optional] 

### Return type

**Guid**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcustomerbyid"></a>
# **GetCustomerById**
> CustomerModel GetCustomerById (string id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Gateway.ApiClient.Api;
using Gateway.ApiClient.Client;
using Gateway.ApiClient.Model;

namespace Example
{
    public class GetCustomerByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new CustomerApi(config);
            var id = "id_example";  // string | 

            try
            {
                CustomerModel result = apiInstance.GetCustomerById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomerApi.GetCustomerById: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**CustomerModel**](CustomerModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="listallcustomers"></a>
# **ListAllCustomers**
> List&lt;CustomerModel&gt; ListAllCustomers ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Gateway.ApiClient.Api;
using Gateway.ApiClient.Client;
using Gateway.ApiClient.Model;

namespace Example
{
    public class ListAllCustomersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new CustomerApi(config);

            try
            {
                List<CustomerModel> result = apiInstance.ListAllCustomers();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CustomerApi.ListAllCustomers: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List&lt;CustomerModel&gt;**](CustomerModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

