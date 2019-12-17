# Description

This was a Meetup presentation (https://www.meetup.com/Net-Mafia-C-Mobsters-and-other-Microsoft-family/events/265086341/) where i had the opportunity to talk, together with two more speakers, about topics related to Microservices, Service Mesh and Elastic APM. My presentation was dedicated to Service Mesh and explaining why you should use Service Mesh, when to use it, how you can use it and then i finalized the presentation with a demo using Istio and Kubernetes Cluster hosted in Minikube.

You have the presentation available [here](./meetup-presentation.ppsx).

# Deployment Instructions

If you want to deploy and try the demo application, you can follow this guide with the high-level steps required to configure it.
For more details, please follow the reference links included in the presentation.

- Install Docker (https://docs.docker.com/install/)
- Install Minikube (https://kubernetes.io/docs/tasks/tools/install-minikube/)
- Run Minikube - be careful with amount of memory and CPUs you allocate in order to everything work as expected (minikube start --memory=16384 --cpus=4)
- Activate minikube tunnel in separate command-line, in case you run Minikube on Windows ( minikube tunnel )
- Install Istio (https://istio.io/docs/setup/install/kubernetes/)
	Note: When you reach the Deploy your app, you can consider to deploy the demo app - Bookinfo (https://istio.io/docs/examples/bookinfo/)
- Validate list of pods running (kubectl get pods)
- Validate containers per each pod (kubectl get pods -o=custom-columns=NameSpace:.metadata.namespace,NAME:.metadata.name,CONTAINERS:.spec.containers[*].name
	      Also, use auto inject for the sidecar proxies
- Get from the terminal the external ip for your cluster (is showing in the terminal where you activated the minikube tunnel.)
- Validate demo app is running (http://192.168.99.101:31380/productpage)

- Validate Grafana service is running (kubectl -n istio-system get svc grafana)
- Get Grafana's service name (kubectl -n istio-system get pod -l app=grafana -o jsonpath='{.items[0].metadata.name}’)

- Enable port forwarding for Grafana's Service (kubectl -n istio-system port-forward  grafana-nnnnnnnnn 3000:3000)
- Enable port forwarding for Kiali's service (kubectl -n istio-system port-forward kiali-nnnnnnnnnnnn 20001:20001)

- Open Grafana's dashboard (http://localhost:3000/?orgId=1)
- Open Kiali's dashboard (http://localhost:20001/kiali/) (by default **username**: admin, **password**: admin)
