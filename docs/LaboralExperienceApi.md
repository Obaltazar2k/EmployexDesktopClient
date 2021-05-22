# IO.Swagger.Api.LaboralExperienceApi

All URIs are relative to *https://virtserver.swaggerhub.com/ricardorzan/Employex/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddLaboralExperience**](LaboralExperienceApi.md#addlaboralexperience) | **POST** /users/independient_user/{user_id}/laboral_experience | Adds laboral experience info to an independient user

<a name="addlaboralexperience"></a>
# **AddLaboralExperience**
> void AddLaboralExperience (LaboralExperience body, int? userId)

Adds laboral experience info to an independient user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddLaboralExperienceExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LaboralExperienceApi();
            var body = new LaboralExperience(); // LaboralExperience | Laboral experience object that needs to be added to the catalog
            var userId = 56;  // int? | Unique identifier of the user

            try
            {
                // Adds laboral experience info to an independient user
                apiInstance.AddLaboralExperience(body, userId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LaboralExperienceApi.AddLaboralExperience: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**LaboralExperience**](LaboralExperience.md)| Laboral experience object that needs to be added to the catalog | 
 **userId** | **int?**| Unique identifier of the user | 

### Return type

void (empty response body)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
