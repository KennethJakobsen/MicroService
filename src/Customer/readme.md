# How to generate an ApiClient

1. Download openapi-generator
2. Start Client from visual studio OR by running: *docker compose up customer.api -d*
3. Run the following command from the solution folder:

>  openapi-generator generate -i http://localhost:5010/swagger/v1/swagger.json -g csharp-netcore --additional-properties=packageName=Customer.ApiClient,sourceFolder=src/Customer

This creates a client to the */src/Customer/Customer.ApiClient* folder with a namespace of Customer.ApiClient
