
az account set --subscription mbr_mvp_12k

$path = Join-Path $PSScriptRoot 'azuredeploy.json'
$rgName = 'mbr-aboutazure-post-test-rg'

if (-not $path) {
    throw 'cant find path'
}
    
az deployment group create `
    --resource-group $rgName `
    --template-file $path `
    --parameters 'appServicePlanName=mbr-aboutazure-post-test-asp' 'webAppName=mbr-aboutazure-post-test'