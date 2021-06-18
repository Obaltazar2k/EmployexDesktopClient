# IO.Swagger.Api.EducationApi

All URIs are relative to *https://virtserver.swaggerhub.com/ricardorzan/Employex/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddEducation**](EducationApi.md#addeducation) | **POST** /users/independient_user/{user_id}/education | Adds education info to an independient user

<a name="addeducation"></a>
# **AddEducation**
> void AddEducation (Education body, int? userId)

Adds education info to an independient user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddEducationExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EducationApi();
            var body = new Education(); // Education | Education object that needs to be added to the catalog
            var userId = 56;  // int? | Unique identifier of the user

            try
            {
                // Adds education info to an independient user
                apiInstance.AddEducation(body, userId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EducationApi.AddEducation: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**Education**](Education.md)| Education object that needs to be added to the catalog | 
 **userId** | **int?**| Unique identifier of the user | 

### Return type

void (empty response body)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
