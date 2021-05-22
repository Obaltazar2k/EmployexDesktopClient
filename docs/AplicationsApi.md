# IO.Swagger.Api.AplicationsApi

All URIs are relative to *https://virtserver.swaggerhub.com/ricardorzan/Employex/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddAplicationToJobOffer**](AplicationsApi.md#addaplicationtojoboffer) | **POST** /users/{user_id}/job_offers/{job_offer_id}/aplications | Adds an aplication to a specified job offer
[**GetJobOffersAplications**](AplicationsApi.md#getjoboffersaplications) | **GET** /users/{user_id}/job_offer/{job_offer_id}/aplications | Returns a list of aplications in a specified job offer published by the user

<a name="addaplicationtojoboffer"></a>
# **AddAplicationToJobOffer**
> void AddAplicationToJobOffer (int? userId, int? jobOfferId)

Adds an aplication to a specified job offer

Adds an aplication to a specified job offer

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddAplicationToJobOfferExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AplicationsApi();
            var userId = 56;  // int? | Unique identifier of the user
            var jobOfferId = 56;  // int? | Unique identifier of the job offer

            try
            {
                // Adds an aplication to a specified job offer
                apiInstance.AddAplicationToJobOffer(userId, jobOfferId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AplicationsApi.AddAplicationToJobOffer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **int?**| Unique identifier of the user | 
 **jobOfferId** | **int?**| Unique identifier of the job offer | 

### Return type

void (empty response body)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getjoboffersaplications"></a>
# **GetJobOffersAplications**
> List<Aplication> GetJobOffersAplications (int? userId, int? jobOfferId)

Returns a list of aplications in a specified job offer published by the user

A list of aplications in the job offer specified published by the user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetJobOffersAplicationsExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AplicationsApi();
            var userId = 56;  // int? | Unique identifier of the user
            var jobOfferId = 56;  // int? | Unique identifier of the job offer

            try
            {
                // Returns a list of aplications in a specified job offer published by the user
                List&lt;Aplication&gt; result = apiInstance.GetJobOffersAplications(userId, jobOfferId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AplicationsApi.GetJobOffersAplications: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **int?**| Unique identifier of the user | 
 **jobOfferId** | **int?**| Unique identifier of the job offer | 

### Return type

[**List<Aplication>**](Aplication.md)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
