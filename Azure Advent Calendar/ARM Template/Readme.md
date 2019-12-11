# ARM Template - Deploy Cognitive Services Account

This template allows you to deploy a Cognitive Services Account using pricing tier S0.
In case you need to use the Free tier, you need to deploy or create each of the individual Cognitive Services you want to use.

In case you want to use Cloud Shell to deploy this template, you can upload this template to your shell session, and then run the following commands in the shell:

This first command will create a Resource Group named *ExampleGroup* in the *Central US* location.

```
az group create --name ExampleGroup --location "Central US"
```

The second command will deploy the template to the given resource group and location.

```
az group deployment create \
  --name ExampleDeployment \
  --resource-group ExampleGroup \
  --template-file template.json \
  --parameters @parameters.json
```	


