Silverware POS API Proxy 🚀
A lightweight ASP.NET Core 8 proxy API to fetch daily sales data from the Silverware POS API. It provides endpoints to retrieve daily sales totals, closed check IDs, and detailed order information, returning structured JSON responses.
📜 Overview
This API acts as a proxy to connect to the Silverware POS API using Bearer Token authentication. It supports:

Daily Sales Totals: Fetch sales data for a specified date range.
Retrieving Order IDs: Retrieve order IDs for a business date.
Order Details: Get detailed information for a specific order by ID.

Responses are structured using strongly-typed models (DailyTotalsResponse, GetOrdersResponse, GetOrderResponse).
✨ Features

🔐 Bearer Token Authentication for secure API calls.
📊 Structured JSON Responses with sales, discounts, taxes, and more.
🕒 Client-Side Caching (5 minutes) to reduce external API load.
📝 Swagger UI for interactive API documentation.
📜 Logging of requests, responses, and errors.
✅ Configuration Validation at startup.

🛠️ Prerequisites

.NET 8 SDK
IDE (Visual Studio 2022, VS Code, or JetBrains Rider)
Valid Bearer Token for the Silverware POS API

🚀 Setup
Installation

Clone the repository:
https://github.com/zodiactobacco/ApiDataFetcher.git

Restore dependencies:
dotnet restore

Run the application:
dotnet run

The API will be available at:

HTTP: http://localhost:5119
HTTPS: https://localhost:7213

Swagger UI opens at: https://localhost:7213/swagger

⚙️ Configuration

Settings: Configured via SilverwareDataSettings in appsettings.json. Validated at startup to ensure BaseUrl, BearerToken, and Endpoints are present.
Logging: Console logs with Information level. Errors include status codes and messages.

📡 Endpoints
All endpoints are under /api/SilverwareData and cached for 5 minutes on the client side.

1. POST /api/SilverwareData/daily-totals
Fetch daily sales totals for a date range.

Request Body (DailyTotalsRequest):

{
  "businessDateFrom": "2024-04-04",
  "businessDateTo": "2024-04-04"
}

2. GET /api/SilverwareData/get-orders?Date=2024-04-04&Statuses=1
Retrieve closed check IDs for a business date.

Query Parameter (GetOrdersRequest):
Date: Date in YYYY-MM-DD format
Statuses: List in range 0-3

3. GET /api/SilverwareData/get-order?OrderId=9700b5aa-fa3a-49b2-a25e-82ddd6b16f49
Fetch detailed order information by Order ID.

Query Parameter (GetOrderRequest):
OrderId: GUID

🧪 Testing
Swagger UI

Run the API (dotnet run).
Open https://localhost:7213/swagger.
Test endpoints with request bodies or query parameters.

🚨 Error Handling

External API Errors: Non-success responses (e.g., 400, 401) throw ExternalApiException, logged with details and returned to the client.
Configuration Errors: Missing or invalid appsettings.json fields fail startup with descriptive errors.
Request Validation: Invalid requests return 400 Bad Request.

📋 Notes

Caching: Responses are cached for 5 minutes, which may delay updates for dynamic data.
GET vs. POST: get-orders and get-order use GET for simplicity, but internally call POST on the Silverware POS API.
Logging: Requests and responses are logged at Information/Debug levels; errors at Error level.

⚠️ Blockers

The provided BaseUrl, endpoint paths, and Bearer Token are sufficient.
Ensure the Bearer Token remains valid (30-day expiration).
It wasn't completely clear what data type to expect from SiliverWare POS API for some responses (it wasn't specified in the documentation)

🔮 Future Improvements

📋 Security: Store BearerToken in User Secrets or a key vault. Update the token every 30 days.
🛡️ Add Polly for retrying transient API errors.
📜 Use Serilog for structured logging.
🔢 Implement API versioning for future endpoint changes.
🌐 Add CORS for browser-based clients.
🧪 Write unit tests for SilverwareDataFetcher and HttpClientWrapper.
