npm install -g autorest
autorest --csharp --output-folder=.  --namespace=ApiClient  --input-file=docs.json --public-clients=true
