# Description

This was a Meetup presentation (http://meetu.ps/e/GHY0S/tt37f/f) where i shared some of my experience, in past projects, working with Serverless Computing and Event-Driven Architecture. Given the time limitation for the presentation, i only talked about some of the Azure Services that can be used to achieve it, such as Azure Functions, Azure Event Grid and Azure Logic App. At the end, a simple demo was presented to show in practice a real scenario of a Serverless Event-Driven Architecture.

# Deployment Instructions

You can you the template included in the app.arm folder to deploy all the components that were included in the demo. After the deployment there are some steps you need to perform, considering the existing limitations:

- You need to deploy or upload the index.html file located in the app.web folder to the App Service App
- Open the Logic App Designer and configure the connections to Twitter, to Cosmos DB and to Event Grid manually.
- Ensure that is configured properly the connection with the Event Grid Trigger on the Function App by triggering the Logic App and monitoring the Function App
