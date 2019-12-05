# Einführung in Infrastructure as Code mit ARM-Templates

ARM-Templates sind Template-Dateien die den Azure Resource Manager ermöglichen bestimmte Infrastrukturresourcen zu deployen. In ARM-Templates wird der Aufbau der Infrastruktur beschrieben.

Die offizielle Dokumentation ist hier einzusehen: 

ARM Dokumentation: https://docs.microsoft.com/en-us/azure/azure-resource-manager/

Resourcentemplates: https://docs.microsoft.com/en-us/azure/templates/

## Aufbau eines ARM Templates


ARM-Template Skelett (`arm!` in VisualStudio Code):
```
{
    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {},
    "variables": {},
    "resources": [],
    "outputs": {},
    "functions": []
} 
```


Ein ARM-Template besteht aus folgenden Blöcken:

### $schema

Definiert das zu verwendende JSON schema.

### contentVersion

Versionsnummer des ARM-Templates welche man frei setzen kann.

### parameters

Parameterliste des ARM-Templates. Dieser Block bestimmt die Parameter welche von außen (z.B. Pipeline, PowerShell) dem Template mitgegeben werden können.

### variables

Variablenliste des ARM-Templates. Definiert Template interne Variablen die im gesamten Template benutzt werden können

### resources

Resourceblock. Hier werden alle Resourcen definiert die durch ARM deployt werden sollen.

### outputs

Liste von Outputparameter. Properties die durch das Deployen von Resourcen entstehen können hier zurückgegeben werden.

### functions

Definition von eigenen Funktionen die im Template benutzt werden können.

https://docs.microsoft.com/en-us/azure/azure-resource-manager/template-user-defined-functions
