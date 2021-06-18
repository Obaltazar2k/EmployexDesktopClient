# IO.Swagger.Api.IndependientUserApi

All URIs are relative to *https://virtserver.swaggerhub.com/ricardorzan/Employex/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetIndependintUserById**](IndependientUserApi.md#getindependintuserbyid) | **GET** /users/independient_user/{user_id} | Get user by user id
[**RegisterIndpendientUser**](IndependientUserApi.md#registerindpendientuser) | **POST** /users/independient_user | Register independient user

<a name="getindependintuserbyid"></a>
# **GetIndependintUserById**
> IndependientUser GetIndependintUserById (int? userId)

Get user by user id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetIndependintUserByIdExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IndependientUserApi();
            var userId = 56;  // int? | Unique identifier of the user

            try
            {
                // Get user by user id
                IndependientUser result = apiInstance.GetIndependintUserById(userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IndependientUserApi.GetIndependintUserById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **int?**| Unique identifier of the user | 

### Return type

[**IndependientUser**](IndependientUser.md)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="registerindpendientuser"></a>
# **RegisterIndpendientUser**
> void RegisterIndpendientUser (IndependientUser body)

Register independient user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegisterIndpendientUserExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new IndependientUserApi();
            var body = new IndependientUser(); // IndependientUser | Independient user object to register

            try
            {
                // Register independient user
                apiInstance.RegisterIndpendientUser(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IndependientUserApi.RegisterIndpendientUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**IndependientUser**](IndependientUser.md)| Independient user object to register | 

### Return type

void (empty response body)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
