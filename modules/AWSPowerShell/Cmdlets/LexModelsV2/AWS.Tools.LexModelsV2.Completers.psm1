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

# Argument completions for service Amazon Lex Model Building V2


$LMBV2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.LexModelsV2.AggregatedUtterancesSortAttribute
        "Get-LMBV2AggregatedUtteranceList/SortBy_Attribute"
        {
            $v = "HitCount","MissedCount"
            break
        }

        # Amazon.LexModelsV2.BotLocaleSortAttribute
        "Get-LMBV2BotLocaleList/SortBy_Attribute"
        {
            $v = "BotLocaleName"
            break
        }

        # Amazon.LexModelsV2.BotSortAttribute
        "Get-LMBV2BotList/SortBy_Attribute"
        {
            $v = "BotName"
            break
        }

        # Amazon.LexModelsV2.BotVersionSortAttribute
        "Get-LMBV2BotVersionList/SortBy_Attribute"
        {
            $v = "BotVersion"
            break
        }

        # Amazon.LexModelsV2.BuiltInIntentSortAttribute
        "Get-LMBV2BuiltInIntentList/SortBy_Attribute"
        {
            $v = "IntentSignature"
            break
        }

        # Amazon.LexModelsV2.BuiltInSlotTypeSortAttribute
        "Get-LMBV2BuiltInSlotTypeList/SortBy_Attribute"
        {
            $v = "SlotTypeSignature"
            break
        }

        # Amazon.LexModelsV2.Effect
        "New-LMBV2ResourcePolicyStatement/Effect"
        {
            $v = "Allow","Deny"
            break
        }

        # Amazon.LexModelsV2.ExportSortAttribute
        "Get-LMBV2ExportList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime"
            break
        }

        # Amazon.LexModelsV2.ImportExportFileFormat
        "New-LMBV2Export/FileFormat"
        {
            $v = "LexJson"
            break
        }

        # Amazon.LexModelsV2.ImportSortAttribute
        "Get-LMBV2ImportList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime"
            break
        }

        # Amazon.LexModelsV2.IntentSortAttribute
        "Get-LMBV2IntentList/SortBy_Attribute"
        {
            $v = "IntentName","LastUpdatedDateTime"
            break
        }

        # Amazon.LexModelsV2.MergeStrategy
        "Start-LMBV2Import/MergeStrategy"
        {
            $v = "FailOnConflict","Overwrite"
            break
        }

        # Amazon.LexModelsV2.ObfuscationSettingType
        {
            ($_ -eq "New-LMBV2Slot/ObfuscationSetting_ObfuscationSettingType") -Or
            ($_ -eq "Update-LMBV2Slot/ObfuscationSetting_ObfuscationSettingType")
        }
        {
            $v = "DefaultObfuscation","None"
            break
        }

        # Amazon.LexModelsV2.SlotConstraint
        {
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotConstraint") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotConstraint")
        }
        {
            $v = "Optional","Required"
            break
        }

        # Amazon.LexModelsV2.SlotSortAttribute
        "Get-LMBV2SlotList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime","SlotName"
            break
        }

        # Amazon.LexModelsV2.SlotTypeSortAttribute
        "Get-LMBV2SlotTypeList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime","SlotTypeName"
            break
        }

        # Amazon.LexModelsV2.SlotValueResolutionStrategy
        {
            ($_ -eq "New-LMBV2SlotType/ValueSelectionSetting_ResolutionStrategy") -Or
            ($_ -eq "Update-LMBV2SlotType/ValueSelectionSetting_ResolutionStrategy")
        }
        {
            $v = "OriginalValue","TopResolution"
            break
        }

        # Amazon.LexModelsV2.SortOrder
        {
            ($_ -eq "Get-LMBV2AggregatedUtteranceList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BotList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BotLocaleList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BotVersionList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BuiltInIntentList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BuiltInSlotTypeList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2ExportList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2ImportList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2IntentList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2SlotList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2SlotTypeList/SortBy_Order")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.LexModelsV2.TimeDimension
        "Get-LMBV2AggregatedUtteranceList/AggregationDuration_RelativeAggregationDuration_TimeDimension"
        {
            $v = "Days","Hours","Weeks"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LMBV2_map = @{
    "AggregationDuration_RelativeAggregationDuration_TimeDimension"=@("Get-LMBV2AggregatedUtteranceList")
    "Effect"=@("New-LMBV2ResourcePolicyStatement")
    "FileFormat"=@("New-LMBV2Export")
    "MergeStrategy"=@("Start-LMBV2Import")
    "ObfuscationSetting_ObfuscationSettingType"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "SortBy_Attribute"=@("Get-LMBV2AggregatedUtteranceList","Get-LMBV2BotList","Get-LMBV2BotLocaleList","Get-LMBV2BotVersionList","Get-LMBV2BuiltInIntentList","Get-LMBV2BuiltInSlotTypeList","Get-LMBV2ExportList","Get-LMBV2ImportList","Get-LMBV2IntentList","Get-LMBV2SlotList","Get-LMBV2SlotTypeList")
    "SortBy_Order"=@("Get-LMBV2AggregatedUtteranceList","Get-LMBV2BotList","Get-LMBV2BotLocaleList","Get-LMBV2BotVersionList","Get-LMBV2BuiltInIntentList","Get-LMBV2BuiltInSlotTypeList","Get-LMBV2ExportList","Get-LMBV2ImportList","Get-LMBV2IntentList","Get-LMBV2SlotList","Get-LMBV2SlotTypeList")
    "ValueElicitationSetting_SlotConstraint"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueSelectionSetting_ResolutionStrategy"=@("New-LMBV2SlotType","Update-LMBV2SlotType")
}

_awsArgumentCompleterRegistration $LMBV2_Completers $LMBV2_map

$LMBV2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.LMBV2.$($commandName.Replace('-', ''))Cmdlet]"
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

$LMBV2_SelectMap = @{
    "Select"=@("Invoke-LMBV2BuildBotLocale",
               "New-LMBV2Bot",
               "New-LMBV2BotAlias",
               "New-LMBV2BotLocale",
               "New-LMBV2BotVersion",
               "New-LMBV2Export",
               "New-LMBV2Intent",
               "New-LMBV2ResourcePolicy",
               "New-LMBV2ResourcePolicyStatement",
               "New-LMBV2Slot",
               "New-LMBV2SlotType",
               "New-LMBV2UploadUrl",
               "Remove-LMBV2Bot",
               "Remove-LMBV2BotAlias",
               "Remove-LMBV2BotLocale",
               "Remove-LMBV2BotVersion",
               "Remove-LMBV2Export",
               "Remove-LMBV2Import",
               "Remove-LMBV2Intent",
               "Remove-LMBV2ResourcePolicy",
               "Remove-LMBV2ResourcePolicyStatement",
               "Remove-LMBV2Slot",
               "Remove-LMBV2SlotType",
               "Remove-LMBV2Utterance",
               "Get-LMBV2Bot",
               "Get-LMBV2BotAlias",
               "Get-LMBV2BotLocale",
               "Get-LMBV2BotVersion",
               "Get-LMBV2Export",
               "Get-LMBV2Import",
               "Get-LMBV2Intent",
               "Get-LMBV2ResourcePolicy",
               "Get-LMBV2Slot",
               "Get-LMBV2SlotType",
               "Get-LMBV2AggregatedUtteranceList",
               "Get-LMBV2BotAliasList",
               "Get-LMBV2BotLocaleList",
               "Get-LMBV2BotList",
               "Get-LMBV2BotVersionList",
               "Get-LMBV2BuiltInIntentList",
               "Get-LMBV2BuiltInSlotTypeList",
               "Get-LMBV2ExportList",
               "Get-LMBV2ImportList",
               "Get-LMBV2IntentList",
               "Get-LMBV2SlotList",
               "Get-LMBV2SlotTypeList",
               "Get-LMBV2ResourceTag",
               "Start-LMBV2Import",
               "Add-LMBV2ResourceTag",
               "Remove-LMBV2ResourceTag",
               "Update-LMBV2Bot",
               "Update-LMBV2BotAlias",
               "Update-LMBV2BotLocale",
               "Update-LMBV2Export",
               "Update-LMBV2Intent",
               "Update-LMBV2ResourcePolicy",
               "Update-LMBV2Slot",
               "Update-LMBV2SlotType")
}

_awsArgumentCompleterRegistration $LMBV2_SelectCompleters $LMBV2_SelectMap

