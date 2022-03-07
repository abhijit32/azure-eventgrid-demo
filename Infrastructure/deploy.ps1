$subscriptionId = "<SUBSCRIPTIONID>"

az deployment sub create -c --subscription $subscriptionId `
                            --location "West Europe" `
                            --template-file main.bicep