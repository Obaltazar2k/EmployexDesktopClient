/* 
 * Employex
 *
 * This is a sample API that allows to manage Employex system, which serves for users seeking to apply for job offers. 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: ricardorzan@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using Employex.Client;
using Employex.Model;
using System.Threading.Tasks;

namespace Employex.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface IIndependientUserApi : IApiAccessor
        {
        #region Synchronous Operations
        /// <summary>
        /// Get user by user id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>IndependientUser</returns>
        IndependientUser GetIndependintUserById (string userId);

        /// <summary>
        /// Get user by user id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>ApiResponse of IndependientUser</returns>
        ApiResponse<IndependientUser> GetIndependintUserByIdWithHttpInfo (string userId);
        /// <summary>
        /// Patch user by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to patch</param>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns></returns>
        void PatchIndependintUserById(IndependientUser body, string userId);

        /// <summary>
        /// Patch user by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to patch</param>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PatchIndependintUserByIdWithHttpInfo(IndependientUser body, string userId);
        /// <summary>
        /// Register independient user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to register</param>
        /// <returns></returns>
        void RegisterIndpendientUser (IndependientUser body);

        /// <summary>
        /// Register independient user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to register</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RegisterIndpendientUserWithHttpInfo (IndependientUser body);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get user by user id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>Task of IndependientUser</returns>
        System.Threading.Tasks.Task<IndependientUser> GetIndependintUserByIdAsync (int? userId);

        /// <summary>
        /// Get user by user id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>Task of ApiResponse (IndependientUser)</returns>
        System.Threading.Tasks.Task<ApiResponse<IndependientUser>> GetIndependintUserByIdAsyncWithHttpInfo (int? userId);
        /// <summary>
        /// Patch user by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to patch</param>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task PatchIndependintUserByIdAsync(IndependientUser body, string userId);

        /// <summary>
        /// Patch user by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to patch</param>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> PatchIndependintUserByIdAsyncWithHttpInfo(IndependientUser body, string userId);
        /// <summary>
        /// Register independient user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to register</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RegisterIndpendientUserAsync (IndependientUser body);

        /// <summary>
        /// Register independient user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to register</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RegisterIndpendientUserAsyncWithHttpInfo (IndependientUser body);
        #endregion Asynchronous Operations
        }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IndependientUserApi : IIndependientUserApi
    {
        private Employex.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndependientUserApi"/> class.
        /// </summary>
        /// <returns></returns>
        public IndependientUserApi(String basePath)
        {
            this.Configuration = new Employex.Client.Configuration { BasePath = basePath };

            ExceptionFactory = Employex.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndependientUserApi"/> class
        /// </summary>
        /// <returns></returns>
        public IndependientUserApi()
        {
            this.Configuration = Employex.Client.Configuration.Default;

            ExceptionFactory = Employex.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndependientUserApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public IndependientUserApi(Employex.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Employex.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Employex.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Employex.Client.Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Employex.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get user by user id 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>IndependientUser</returns>
        public IndependientUser GetIndependintUserById(string userId)
        {
            ApiResponse<IndependientUser> localVarResponse = GetIndependintUserByIdWithHttpInfo(userId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get user by user id 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>ApiResponse of IndependientUser</returns>
        public ApiResponse<IndependientUser> GetIndependintUserByIdWithHttpInfo(string userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IndependientUserApi->GetIndependintUserById");

            var localVarPath = "/users/independient_user/{user_id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (userId != null) localVarPathParams.Add("user_id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            // authentication (oAuthSample) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIndependintUserById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<IndependientUser>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (IndependientUser)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(IndependientUser)));
        }

        /// <summary>
        /// Get user by user id 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>Task of IndependientUser</returns>
        public async System.Threading.Tasks.Task<IndependientUser> GetIndependintUserByIdAsync(string userId)
        {
            ApiResponse<IndependientUser> localVarResponse = await GetIndependintUserByIdAsyncWithHttpInfo(userId);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Get user by user id 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>Task of ApiResponse (IndependientUser)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<IndependientUser>> GetIndependintUserByIdAsyncWithHttpInfo(string userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IndependientUserApi->GetIndependintUserById");

            var localVarPath = "/users/independient_user/{user_id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (userId != null) localVarPathParams.Add("user_id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            // authentication (oAuthSample) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetIndependintUserById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<IndependientUser>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (IndependientUser)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(IndependientUser)));
        } 

        /// <summary>
        /// Patch user by id 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to patch</param>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns></returns>
        public void PatchIndependintUserById(IndependientUser body, string userId)
        {
            PatchIndependintUserByIdWithHttpInfo(body, userId);
        }

        /// <summary>
        /// Patch user by id 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to patch</param>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> PatchIndependintUserByIdWithHttpInfo(IndependientUser body, string userId)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IndependientUserApi->PatchIndependintUserById");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IndependientUserApi->PatchIndependintUserById");

            var localVarPath = "/users/independient_user/{user_id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (userId != null) localVarPathParams.Add("user_id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (oAuthSample) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PatchIndependintUserById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Patch user by id 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to patch</param>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PatchIndependintUserByIdAsync(IndependientUser body, string userId)
        {
            await PatchIndependintUserByIdAsyncWithHttpInfo(body, userId);

        }

        /// <summary>
        /// Patch user by id 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to patch</param>
        /// <param name="userId">Unique identifier of the user</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> PatchIndependintUserByIdAsyncWithHttpInfo(IndependientUser body, string userId)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IndependientUserApi->PatchIndependintUserById");
            // verify the required parameter 'userId' is set
            if (userId == null)
                throw new ApiException(400, "Missing required parameter 'userId' when calling IndependientUserApi->PatchIndependintUserById");

            var localVarPath = "/users/independient_user/{user_id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (userId != null) localVarPathParams.Add("user_id", this.Configuration.ApiClient.ParameterToString(userId)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (oAuthSample) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PatchIndependintUserById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Register independient user 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to register</param>
        /// <returns></returns>
        public void RegisterIndpendientUser (IndependientUser body)
        {
             RegisterIndpendientUserWithHttpInfo(body);
        }

        /// <summary>
        /// Register independient user 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to register</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> RegisterIndpendientUserWithHttpInfo (IndependientUser body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IndependientUserApi->RegisterIndpendientUser");

            var localVarPath = "/users/independient_user";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (oAuthSample) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            localVarHeaderParams["Authorization"] = string.Format("Bearer {0}", "046b6c7f - 0b8a - 43b9 - b35d - 6489e6daee91");

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RegisterIndpendientUser", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        /// Register independient user 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to register</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RegisterIndpendientUserAsync (IndependientUser body)
        {
             await RegisterIndpendientUserAsyncWithHttpInfo(body);

        }

        /// <summary>
        /// Register independient user 
        /// </summary>
        /// <exception cref="Employex.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Independient user object to register</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> RegisterIndpendientUserAsyncWithHttpInfo (IndependientUser body)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling IndependientUserApi->RegisterIndpendientUser");

            var localVarPath = "/users/independient_user";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }
            // authentication (oAuthSample) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RegisterIndpendientUser", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                null);
        }

        public Task<IndependientUser> GetIndependintUserByIdAsync(int? userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<IndependientUser>> GetIndependintUserByIdAsyncWithHttpInfo(int? userId)
        {
            throw new NotImplementedException();
        }
    }
}
