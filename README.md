Sitefinity MVC Client Implicit Flow Authorization
====================================

Sitefinity MVC Client Implicit Flow Authorization is a sample MVC application, which can obtain access tokens from sitefinity with implicit flow and can call the Sitefinity Web API

### Requirements

* Sitefinity CMS license
* .NET Framework 4.5
* Visual Studio 2013/2015
* Microsoft SQL Server

### Prerequisites

Go to the Constants class and change:

* Sitefinity BaseUrl
* Sitefinity STSUrl
* Sitefinity NewsItemsApiUrl
* In the Sitefinity App Register your client as client to your STS. Go to Administration -> Settings- > Advanced -> Authentication -> SecurityTokenService -> IdentityServer -> Clients and Create new client
   
   * Client name: testApp 
   * Client id: testApp 
   * Enabled: true 
   * Client flow: Implicit
   * Add redirect url - http://localhost:64761/ 
   * Add postlogout url -http://localhost:64761/

You should be enable to run the application and to get access token and make call with it to the Sitefinity Web API
