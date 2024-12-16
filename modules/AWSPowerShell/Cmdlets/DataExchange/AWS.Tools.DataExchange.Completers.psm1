# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

# Argument completions for service AWS Data Exchange


$DTEX_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DataExchange.AssetType
        "New-DTEXDataSet/AssetType"
        {
            $v = "API_GATEWAY_API","LAKE_FORMATION_DATA_PERMISSION","REDSHIFT_DATA_SHARE","S3_DATA_ACCESS","S3_SNAPSHOT"
            break
        }

        # Amazon.DataExchange.GrantDistributionScope
        "New-DTEXDataGrant/GrantDistributionScope"
        {
            $v = "AWS_ORGANIZATION","NONE"
            break
        }

        # Amazon.DataExchange.NotificationType
        "Send-DTEXDataSetNotification/Type"
        {
            $v = "DATA_DELAY","DATA_UPDATE","DEPRECATION","SCHEMA_CHANGE"
            break
        }

        # Amazon.DataExchange.ProtocolType
        "New-DTEXJob/ImportAssetFromApiGatewayApi_ProtocolType"
        {
            $v = "REST"
            break
        }

        # Amazon.DataExchange.ServerSideEncryptionTypes
        {
            ($_ -eq "New-DTEXJob/Details_ExportRevisionsToS3_Encryption_Type") -Or
            ($_ -eq "New-DTEXEventAction/Encryption_Type") -Or
            ($_ -eq "New-DTEXJob/Encryption_Type") -Or
            ($_ -eq "Update-DTEXEventAction/Encryption_Type")
        }
        {
            $v = "AES256","aws:kms"
            break
        }

        # Amazon.DataExchange.Type
        "New-DTEXJob/Type"
        {
            $v = "CREATE_S3_DATA_ACCESS_FROM_S3_BUCKET","EXPORT_ASSETS_TO_S3","EXPORT_ASSET_TO_SIGNED_URL","EXPORT_REVISIONS_TO_S3","IMPORT_ASSETS_FROM_LAKE_FORMATION_TAG_POLICY","IMPORT_ASSETS_FROM_REDSHIFT_DATA_SHARES","IMPORT_ASSETS_FROM_S3","IMPORT_ASSET_FROM_API_GATEWAY_API","IMPORT_ASSET_FROM_SIGNED_URL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DTEX_map = @{
    "AssetType"=@("New-DTEXDataSet")
    "Details_ExportRevisionsToS3_Encryption_Type"=@("New-DTEXJob")
    "Encryption_Type"=@("New-DTEXEventAction","New-DTEXJob","Update-DTEXEventAction")
    "GrantDistributionScope"=@("New-DTEXDataGrant")
    "ImportAssetFromApiGatewayApi_ProtocolType"=@("New-DTEXJob")
    "Type"=@("New-DTEXJob","Send-DTEXDataSetNotification")
}

_awsArgumentCompleterRegistration $DTEX_Completers $DTEX_map

$DTEX_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DTEX.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DTEX_SelectMap = @{
    "Select"=@("Receive-DTEXDataGrant",
               "Stop-DTEXJob",
               "New-DTEXDataGrant",
               "New-DTEXDataSet",
               "New-DTEXEventAction",
               "New-DTEXJob",
               "New-DTEXRevision",
               "Remove-DTEXAsset",
               "Remove-DTEXDataGrant",
               "Remove-DTEXDataSet",
               "Remove-DTEXEventAction",
               "Remove-DTEXRevision",
               "Get-DTEXAsset",
               "Get-DTEXDataGrant",
               "Get-DTEXDataSet",
               "Get-DTEXEventAction",
               "Get-DTEXJob",
               "Get-DTEXReceivedDataGrant",
               "Get-DTEXRevision",
               "Get-DTEXDataGrantList",
               "Get-DTEXDataSetRevisionList",
               "Get-DTEXDataSetList",
               "Get-DTEXEventActionList",
               "Get-DTEXJobList",
               "Get-DTEXReceivedDataGrantList",
               "Get-DTEXRevisionAssetList",
               "Get-DTEXResourceTag",
               "Revoke-DTEXRevision",
               "Send-DTEXApiAsset",
               "Send-DTEXDataSetNotification",
               "Start-DTEXJob",
               "Add-DTEXResourceTag",
               "Remove-DTEXResourceTag",
               "Update-DTEXAsset",
               "Update-DTEXDataSet",
               "Update-DTEXEventAction",
               "Update-DTEXRevision")
}

_awsArgumentCompleterRegistration $DTEX_SelectCompleters $DTEX_SelectMap

