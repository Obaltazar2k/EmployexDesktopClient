# IO.Swagger.Api.OrganizationUserApi

All URIs are relative to *https://virtserver.swaggerhub.com/ricardorzan/Employex/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetOrganizationUserById**](OrganizationUserApi.md#getorganizationuserbyid) | **GET** /users/organization_user/{user_id} | Get user by user id
[**RegisterOrganizationUser**](OrganizationUserApi.md#registerorganizationuser) | **POST** /users/organization_user | Register organization user

<a name="getorganizationuserbyid"></a>
# **GetOrganizationUserById**
> IndependientUser GetOrganizationUserById (int? userId)

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
    public class GetOrganizationUserByIdExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrganizationUserApi();
            var userId = 56;  // int? | Unique identifier of the user

            try
            {
                // Get user by user id
                IndependientUser result = apiInstance.GetOrganizationUserById(userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrganizationUserApi.GetOrganizationUserById: " + e.Message );
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
<a name="registerorganizationuser"></a>
# **RegisterOrganizationUser**
> void RegisterOrganizationUser (OrganizationUser body)

Register organization user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegisterOrganizationUserExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrganizationUserApi();
            var body = new OrganizationUser(); // OrganizationUser | Organization user object to register

            try
            {
                // Register organization user
                apiInstance.RegisterOrganizationUser(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrganizationUserApi.RegisterOrganizationUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**OrganizationUser**](OrganizationUser.md)| Organization user object to register | 

### Return type

void (empty response body)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
