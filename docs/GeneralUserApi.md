# IO.Swagger.Api.GeneralUserApi

All URIs are relative to *https://virtserver.swaggerhub.com/ricardorzan/Employex/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**LoginUser**](GeneralUserApi.md#loginuser) | **GET** /users/login | Logs user into the system
[**LogoutUser**](GeneralUserApi.md#logoutuser) | **GET** /users/logout | Logs out current logged in user session

<a name="loginuser"></a>
# **LoginUser**
> string LoginUser (string username, string password)

Logs user into the system

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LoginUserExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GeneralUserApi();
            var username = username_example;  // string | The user name for login
            var password = password_example;  // string | The password for login in clear text

            try
            {
                // Logs user into the system
                string result = apiInstance.LoginUser(username, password);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GeneralUserApi.LoginUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **username** | **string**| The user name for login | 
 **password** | **string**| The password for login in clear text | 

### Return type

**string**

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="logoutuser"></a>
# **LogoutUser**
> void LogoutUser ()

Logs out current logged in user session

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LogoutUserExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new GeneralUserApi();

            try
            {
                // Logs out current logged in user session
                apiInstance.LogoutUser();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GeneralUserApi.LogoutUser: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
