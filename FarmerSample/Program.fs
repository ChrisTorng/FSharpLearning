open Farmer
open Farmer.Builders

// Create a storage account with a container
let myStorageAccount = storageAccount {
    name "myteststorage"
    add_public_container "mycontainer"
}

// Create a web app with application insights that's connected to the storage account.
let myWebApp = webApp {
    name "myTestWebApp"
    setting "storageKey" myStorageAccount.Key
}

// Create an ARM template
let deployment = arm {
    location Location.NorthEurope
    add_resources [
        myStorageAccount
        myWebApp
    ]
}

// Deploy it to Azure!
deployment
|> Writer.quickWrite "myResourceGroup"

// deployment
// |> Deploy.execute "myResourceGroup" Deploy.NoParameters
// |> ignore