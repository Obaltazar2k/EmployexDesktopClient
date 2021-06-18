# IO.Swagger.Api.JobOfferApi

All URIs are relative to *https://virtserver.swaggerhub.com/ricardorzan/Employex/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddAplicationToJobOffer**](JobOfferApi.md#addaplicationtojoboffer) | **POST** /users/{user_id}/job_offers/{job_offer_id}/aplications | Adds an aplication to a specified job offer
[**AddJobOffer**](JobOfferApi.md#addjoboffer) | **POST** /job_offers | Add a new job offer to the catalog
[**GetJobOffers**](JobOfferApi.md#getjoboffers) | **GET** /job_offers | Returns a list of job offers
[**GetJobOffersAplications**](JobOfferApi.md#getjoboffersaplications) | **GET** /users/{user_id}/job_offer/{job_offer_id}/aplications | Returns a list of aplications in a specified job offer published by the user
[**GetJobOffersPublishedByTheUser**](JobOfferApi.md#getjobofferspublishedbytheuser) | **GET** /users/{user_id}/job_offer | Returns a list of job offers published by the user

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

            var apiInstance = new JobOfferApi();
            var userId = 56;  // int? | Unique identifier of the user
            var jobOfferId = 56;  // int? | Unique identifier of the job offer

            try
            {
                // Adds an aplication to a specified job offer
                apiInstance.AddAplicationToJobOffer(userId, jobOfferId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JobOfferApi.AddAplicationToJobOffer: " + e.Message );
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
<a name="addjoboffer"></a>
# **AddJobOffer**
> void AddJobOffer (JobOffer body)

Add a new job offer to the catalog

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddJobOfferExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobOfferApi();
            var body = new JobOffer(); // JobOffer | Job offer object that needs to be added to the catalog

            try
            {
                // Add a new job offer to the catalog
                apiInstance.AddJobOffer(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JobOfferApi.AddJobOffer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**JobOffer**](JobOffer.md)| Job offer object that needs to be added to the catalog | 

### Return type

void (empty response body)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getjoboffers"></a>
# **GetJobOffers**
> List<JobOffer> GetJobOffers (int? page)

Returns a list of job offers

A list of the last ten job offers published by the others users

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetJobOffersExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobOfferApi();
            var page = 56;  // int? | Pagination

            try
            {
                // Returns a list of job offers
                List&lt;JobOffer&gt; result = apiInstance.GetJobOffers(page);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JobOfferApi.GetJobOffers: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **page** | **int?**| Pagination | 

### Return type

[**List<JobOffer>**](JobOffer.md)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

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

            var apiInstance = new JobOfferApi();
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
                Debug.Print("Exception when calling JobOfferApi.GetJobOffersAplications: " + e.Message );
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
<a name="getjobofferspublishedbytheuser"></a>
# **GetJobOffersPublishedByTheUser**
> List<JobOffer> GetJobOffersPublishedByTheUser (int? userId)

Returns a list of job offers published by the user

A list of the job offers published by the user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetJobOffersPublishedByTheUserExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: oAuthSample
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobOfferApi();
            var userId = 56;  // int? | Unique identifier of the user

            try
            {
                // Returns a list of job offers published by the user
                List&lt;JobOffer&gt; result = apiInstance.GetJobOffersPublishedByTheUser(userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JobOfferApi.GetJobOffersPublishedByTheUser: " + e.Message );
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

[**List<JobOffer>**](JobOffer.md)

### Authorization

[oAuthSample](../README.md#oAuthSample)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
