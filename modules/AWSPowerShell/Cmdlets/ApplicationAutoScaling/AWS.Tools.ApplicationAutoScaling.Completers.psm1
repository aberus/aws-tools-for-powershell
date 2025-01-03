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

# Argument completions for service Application Auto Scaling


$AAS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ApplicationAutoScaling.AdjustmentType
        "Set-AASScalingPolicy/StepScalingPolicyConfiguration_AdjustmentType"
        {
            $v = "ChangeInCapacity","ExactCapacity","PercentChangeInCapacity"
            break
        }

        # Amazon.ApplicationAutoScaling.MetricAggregationType
        "Set-AASScalingPolicy/StepScalingPolicyConfiguration_MetricAggregationType"
        {
            $v = "Average","Maximum","Minimum"
            break
        }

        # Amazon.ApplicationAutoScaling.MetricStatistic
        "Set-AASScalingPolicy/CustomizedMetricSpecification_Statistic"
        {
            $v = "Average","Maximum","Minimum","SampleCount","Sum"
            break
        }

        # Amazon.ApplicationAutoScaling.MetricType
        "Set-AASScalingPolicy/PredefinedMetricSpecification_PredefinedMetricType"
        {
            $v = "ALBRequestCountPerTarget","AppStreamAverageCapacityUtilization","CassandraReadCapacityUtilization","CassandraWriteCapacityUtilization","ComprehendInferenceUtilization","DynamoDBReadCapacityUtilization","DynamoDBWriteCapacityUtilization","EC2SpotFleetRequestAverageCPUUtilization","EC2SpotFleetRequestAverageNetworkIn","EC2SpotFleetRequestAverageNetworkOut","ECSServiceAverageCPUUtilization","ECSServiceAverageMemoryUtilization","ElastiCacheDatabaseCapacityUsageCountedForEvictPercentage","ElastiCacheDatabaseMemoryUsageCountedForEvictPercentage","ElastiCachePrimaryEngineCPUUtilization","ElastiCacheReplicaEngineCPUUtilization","KafkaBrokerStorageUtilization","LambdaProvisionedConcurrencyUtilization","NeptuneReaderAverageCPUUtilization","RDSReaderAverageCPUUtilization","RDSReaderAverageDatabaseConnections","SageMakerInferenceComponentConcurrentRequestsPerCopyHighResolution","SageMakerInferenceComponentInvocationsPerCopy","SageMakerVariantConcurrentRequestsPerModelHighResolution","SageMakerVariantInvocationsPerInstance","SageMakerVariantProvisionedConcurrencyUtilization","WorkSpacesAverageUserSessionsCapacityUtilization"
            break
        }

        # Amazon.ApplicationAutoScaling.PolicyType
        "Set-AASScalingPolicy/PolicyType"
        {
            $v = "PredictiveScaling","StepScaling","TargetTrackingScaling"
            break
        }

        # Amazon.ApplicationAutoScaling.PredictiveScalingMaxCapacityBreachBehavior
        "Set-AASScalingPolicy/PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior"
        {
            $v = "HonorMaxCapacity","IncreaseMaxCapacity"
            break
        }

        # Amazon.ApplicationAutoScaling.PredictiveScalingMode
        "Set-AASScalingPolicy/PredictiveScalingPolicyConfiguration_Mode"
        {
            $v = "ForecastAndScale","ForecastOnly"
            break
        }

        # Amazon.ApplicationAutoScaling.ScalableDimension
        {
            ($_ -eq "Add-AASScalableTarget/ScalableDimension") -Or
            ($_ -eq "Get-AASPredictiveScalingForecast/ScalableDimension") -Or
            ($_ -eq "Get-AASScalableTarget/ScalableDimension") -Or
            ($_ -eq "Get-AASScalingActivity/ScalableDimension") -Or
            ($_ -eq "Get-AASScalingPolicy/ScalableDimension") -Or
            ($_ -eq "Get-AASScheduledAction/ScalableDimension") -Or
            ($_ -eq "Remove-AASScalableTarget/ScalableDimension") -Or
            ($_ -eq "Remove-AASScalingPolicy/ScalableDimension") -Or
            ($_ -eq "Remove-AASScheduledAction/ScalableDimension") -Or
            ($_ -eq "Set-AASScalingPolicy/ScalableDimension") -Or
            ($_ -eq "Set-AASScheduledAction/ScalableDimension")
        }
        {
            $v = "appstream:fleet:DesiredCapacity","cassandra:table:ReadCapacityUnits","cassandra:table:WriteCapacityUnits","comprehend:document-classifier-endpoint:DesiredInferenceUnits","comprehend:entity-recognizer-endpoint:DesiredInferenceUnits","custom-resource:ResourceType:Property","dynamodb:index:ReadCapacityUnits","dynamodb:index:WriteCapacityUnits","dynamodb:table:ReadCapacityUnits","dynamodb:table:WriteCapacityUnits","ec2:spot-fleet-request:TargetCapacity","ecs:service:DesiredCount","elasticache:replication-group:NodeGroups","elasticache:replication-group:Replicas","elasticmapreduce:instancegroup:InstanceCount","kafka:broker-storage:VolumeSize","lambda:function:ProvisionedConcurrency","neptune:cluster:ReadReplicaCount","rds:cluster:ReadReplicaCount","sagemaker:inference-component:DesiredCopyCount","sagemaker:variant:DesiredInstanceCount","sagemaker:variant:DesiredProvisionedConcurrency","workspaces:workspacespool:DesiredUserSessions"
            break
        }

        # Amazon.ApplicationAutoScaling.ServiceNamespace
        {
            ($_ -eq "Add-AASScalableTarget/ServiceNamespace") -Or
            ($_ -eq "Get-AASPredictiveScalingForecast/ServiceNamespace") -Or
            ($_ -eq "Get-AASScalableTarget/ServiceNamespace") -Or
            ($_ -eq "Get-AASScalingActivity/ServiceNamespace") -Or
            ($_ -eq "Get-AASScalingPolicy/ServiceNamespace") -Or
            ($_ -eq "Get-AASScheduledAction/ServiceNamespace") -Or
            ($_ -eq "Remove-AASScalableTarget/ServiceNamespace") -Or
            ($_ -eq "Remove-AASScalingPolicy/ServiceNamespace") -Or
            ($_ -eq "Remove-AASScheduledAction/ServiceNamespace") -Or
            ($_ -eq "Set-AASScalingPolicy/ServiceNamespace") -Or
            ($_ -eq "Set-AASScheduledAction/ServiceNamespace")
        }
        {
            $v = "appstream","cassandra","comprehend","custom-resource","dynamodb","ec2","ecs","elasticache","elasticmapreduce","kafka","lambda","neptune","rds","sagemaker","workspaces"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AAS_map = @{
    "CustomizedMetricSpecification_Statistic"=@("Set-AASScalingPolicy")
    "PolicyType"=@("Set-AASScalingPolicy")
    "PredefinedMetricSpecification_PredefinedMetricType"=@("Set-AASScalingPolicy")
    "PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior"=@("Set-AASScalingPolicy")
    "PredictiveScalingPolicyConfiguration_Mode"=@("Set-AASScalingPolicy")
    "ScalableDimension"=@("Add-AASScalableTarget","Get-AASPredictiveScalingForecast","Get-AASScalableTarget","Get-AASScalingActivity","Get-AASScalingPolicy","Get-AASScheduledAction","Remove-AASScalableTarget","Remove-AASScalingPolicy","Remove-AASScheduledAction","Set-AASScalingPolicy","Set-AASScheduledAction")
    "ServiceNamespace"=@("Add-AASScalableTarget","Get-AASPredictiveScalingForecast","Get-AASScalableTarget","Get-AASScalingActivity","Get-AASScalingPolicy","Get-AASScheduledAction","Remove-AASScalableTarget","Remove-AASScalingPolicy","Remove-AASScheduledAction","Set-AASScalingPolicy","Set-AASScheduledAction")
    "StepScalingPolicyConfiguration_AdjustmentType"=@("Set-AASScalingPolicy")
    "StepScalingPolicyConfiguration_MetricAggregationType"=@("Set-AASScalingPolicy")
}

_awsArgumentCompleterRegistration $AAS_Completers $AAS_map

$AAS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AAS.$($commandName.Replace('-', ''))Cmdlet]"
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

$AAS_SelectMap = @{
    "Select"=@("Remove-AASScalingPolicy",
               "Remove-AASScheduledAction",
               "Remove-AASScalableTarget",
               "Get-AASScalableTarget",
               "Get-AASScalingActivity",
               "Get-AASScalingPolicy",
               "Get-AASScheduledAction",
               "Get-AASPredictiveScalingForecast",
               "Get-AASResourceTag",
               "Set-AASScalingPolicy",
               "Set-AASScheduledAction",
               "Add-AASScalableTarget",
               "Add-AASResourceTag",
               "Remove-AASResourceTag")
}

_awsArgumentCompleterRegistration $AAS_SelectCompleters $AAS_SelectMap

