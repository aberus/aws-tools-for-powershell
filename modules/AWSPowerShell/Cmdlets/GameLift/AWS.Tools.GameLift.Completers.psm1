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

# Argument completions for service Amazon GameLift Service


$GML_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.GameLift.AcceptanceType
        "Confirm-GMLMatch/AcceptanceType"
        {
            $v = "ACCEPT","REJECT"
            break
        }

        # Amazon.GameLift.BackfillMode
        {
            ($_ -eq "New-GMLMatchmakingConfiguration/BackfillMode") -Or
            ($_ -eq "Update-GMLMatchmakingConfiguration/BackfillMode")
        }
        {
            $v = "AUTOMATIC","MANUAL"
            break
        }

        # Amazon.GameLift.BalancingStrategy
        {
            ($_ -eq "New-GMLGameServerGroup/BalancingStrategy") -Or
            ($_ -eq "Update-GMLGameServerGroup/BalancingStrategy")
        }
        {
            $v = "ON_DEMAND_ONLY","SPOT_ONLY","SPOT_PREFERRED"
            break
        }

        # Amazon.GameLift.BuildStatus
        "Get-GMLBuild/Status"
        {
            $v = "FAILED","INITIALIZED","READY"
            break
        }

        # Amazon.GameLift.CertificateType
        "New-GMLFleet/CertificateConfiguration_CertificateType"
        {
            $v = "DISABLED","GENERATED"
            break
        }

        # Amazon.GameLift.ComparisonOperatorType
        "Write-GMLScalingPolicy/ComparisonOperator"
        {
            $v = "GreaterThanOrEqualToThreshold","GreaterThanThreshold","LessThanOrEqualToThreshold","LessThanThreshold"
            break
        }

        # Amazon.GameLift.ComputeType
        "New-GMLFleet/ComputeType"
        {
            $v = "ANYWHERE","EC2"
            break
        }

        # Amazon.GameLift.ContainerFleetBillingType
        "New-GMLContainerFleet/BillingType"
        {
            $v = "ON_DEMAND","SPOT"
            break
        }

        # Amazon.GameLift.ContainerGroupType
        {
            ($_ -eq "Get-GMLContainerGroupDefinitionList/ContainerGroupType") -Or
            ($_ -eq "New-GMLContainerGroupDefinition/ContainerGroupType")
        }
        {
            $v = "GAME_SERVER","PER_INSTANCE"
            break
        }

        # Amazon.GameLift.ContainerOperatingSystem
        {
            ($_ -eq "New-GMLContainerGroupDefinition/OperatingSystem") -Or
            ($_ -eq "Update-GMLContainerGroupDefinition/OperatingSystem")
        }
        {
            $v = "AMAZON_LINUX_2023"
            break
        }

        # Amazon.GameLift.DeploymentImpairmentStrategy
        "Update-GMLContainerFleet/DeploymentConfiguration_ImpairmentStrategy"
        {
            $v = "MAINTAIN","ROLLBACK"
            break
        }

        # Amazon.GameLift.DeploymentProtectionStrategy
        "Update-GMLContainerFleet/DeploymentConfiguration_ProtectionStrategy"
        {
            $v = "IGNORE_PROTECTION","WITH_PROTECTION"
            break
        }

        # Amazon.GameLift.EC2InstanceType
        {
            ($_ -eq "Get-GMLEC2InstanceLimit/EC2InstanceType") -Or
            ($_ -eq "New-GMLFleet/EC2InstanceType")
        }
        {
            $v = "c3.2xlarge","c3.4xlarge","c3.8xlarge","c3.large","c3.xlarge","c4.2xlarge","c4.4xlarge","c4.8xlarge","c4.large","c4.xlarge","c5.12xlarge","c5.18xlarge","c5.24xlarge","c5.2xlarge","c5.4xlarge","c5.9xlarge","c5.large","c5.xlarge","c5a.12xlarge","c5a.16xlarge","c5a.24xlarge","c5a.2xlarge","c5a.4xlarge","c5a.8xlarge","c5a.large","c5a.xlarge","c5d.12xlarge","c5d.18xlarge","c5d.24xlarge","c5d.2xlarge","c5d.4xlarge","c5d.9xlarge","c5d.large","c5d.xlarge","c6a.12xlarge","c6a.16xlarge","c6a.24xlarge","c6a.2xlarge","c6a.4xlarge","c6a.8xlarge","c6a.large","c6a.xlarge","c6g.12xlarge","c6g.16xlarge","c6g.2xlarge","c6g.4xlarge","c6g.8xlarge","c6g.large","c6g.medium","c6g.xlarge","c6gn.12xlarge","c6gn.16xlarge","c6gn.2xlarge","c6gn.4xlarge","c6gn.8xlarge","c6gn.large","c6gn.medium","c6gn.xlarge","c6i.12xlarge","c6i.16xlarge","c6i.24xlarge","c6i.2xlarge","c6i.4xlarge","c6i.8xlarge","c6i.large","c6i.xlarge","c7g.12xlarge","c7g.16xlarge","c7g.2xlarge","c7g.4xlarge","c7g.8xlarge","c7g.large","c7g.medium","c7g.xlarge","g5g.16xlarge","g5g.2xlarge","g5g.4xlarge","g5g.8xlarge","g5g.xlarge","m3.2xlarge","m3.large","m3.medium","m3.xlarge","m4.10xlarge","m4.2xlarge","m4.4xlarge","m4.large","m4.xlarge","m5.12xlarge","m5.16xlarge","m5.24xlarge","m5.2xlarge","m5.4xlarge","m5.8xlarge","m5.large","m5.xlarge","m5a.12xlarge","m5a.16xlarge","m5a.24xlarge","m5a.2xlarge","m5a.4xlarge","m5a.8xlarge","m5a.large","m5a.xlarge","m6g.12xlarge","m6g.16xlarge","m6g.2xlarge","m6g.4xlarge","m6g.8xlarge","m6g.large","m6g.medium","m6g.xlarge","m7g.12xlarge","m7g.16xlarge","m7g.2xlarge","m7g.4xlarge","m7g.8xlarge","m7g.large","m7g.medium","m7g.xlarge","r3.2xlarge","r3.4xlarge","r3.8xlarge","r3.large","r3.xlarge","r4.16xlarge","r4.2xlarge","r4.4xlarge","r4.8xlarge","r4.large","r4.xlarge","r5.12xlarge","r5.16xlarge","r5.24xlarge","r5.2xlarge","r5.4xlarge","r5.8xlarge","r5.large","r5.xlarge","r5a.12xlarge","r5a.16xlarge","r5a.24xlarge","r5a.2xlarge","r5a.4xlarge","r5a.8xlarge","r5a.large","r5a.xlarge","r5d.12xlarge","r5d.16xlarge","r5d.24xlarge","r5d.2xlarge","r5d.4xlarge","r5d.8xlarge","r5d.large","r5d.xlarge","r6g.12xlarge","r6g.16xlarge","r6g.2xlarge","r6g.4xlarge","r6g.8xlarge","r6g.large","r6g.medium","r6g.xlarge","r7g.12xlarge","r7g.16xlarge","r7g.2xlarge","r7g.4xlarge","r7g.8xlarge","r7g.large","r7g.medium","r7g.xlarge","t2.large","t2.medium","t2.micro","t2.small"
            break
        }

        # Amazon.GameLift.FleetType
        "New-GMLFleet/FleetType"
        {
            $v = "ON_DEMAND","SPOT"
            break
        }

        # Amazon.GameLift.FlexMatchMode
        {
            ($_ -eq "New-GMLMatchmakingConfiguration/FlexMatchMode") -Or
            ($_ -eq "Update-GMLMatchmakingConfiguration/FlexMatchMode")
        }
        {
            $v = "STANDALONE","WITH_QUEUE"
            break
        }

        # Amazon.GameLift.GameServerGroupDeleteOption
        "Remove-GMLGameServerGroup/DeleteOption"
        {
            $v = "FORCE_DELETE","RETAIN","SAFE_DELETE"
            break
        }

        # Amazon.GameLift.GameServerHealthCheck
        "Update-GMLGameServer/HealthCheck"
        {
            $v = "HEALTHY"
            break
        }

        # Amazon.GameLift.GameServerProtectionPolicy
        {
            ($_ -eq "New-GMLGameServerGroup/GameServerProtectionPolicy") -Or
            ($_ -eq "Update-GMLGameServerGroup/GameServerProtectionPolicy")
        }
        {
            $v = "FULL_PROTECTION","NO_PROTECTION"
            break
        }

        # Amazon.GameLift.GameServerUtilizationStatus
        "Update-GMLGameServer/UtilizationStatus"
        {
            $v = "AVAILABLE","UTILIZED"
            break
        }

        # Amazon.GameLift.InstanceRoleCredentialsProvider
        "New-GMLFleet/InstanceRoleCredentialsProvider"
        {
            $v = "SHARED_CREDENTIAL_FILE"
            break
        }

        # Amazon.GameLift.ListComputeInputStatus
        "Get-GMLComputeList/ComputeStatus"
        {
            $v = "ACTIVE","IMPAIRED"
            break
        }

        # Amazon.GameLift.LogDestination
        {
            ($_ -eq "New-GMLContainerFleet/LogConfiguration_LogDestination") -Or
            ($_ -eq "Update-GMLContainerFleet/LogConfiguration_LogDestination")
        }
        {
            $v = "CLOUDWATCH","NONE","S3"
            break
        }

        # Amazon.GameLift.MetricName
        "Write-GMLScalingPolicy/MetricName"
        {
            $v = "ActivatingGameSessions","ActiveGameSessions","ActiveInstances","AvailableGameSessions","AvailablePlayerSessions","ConcurrentActivatableGameSessions","CurrentPlayerSessions","IdleInstances","PercentAvailableGameSessions","PercentIdleInstances","QueueDepth","WaitTime"
            break
        }

        # Amazon.GameLift.OperatingSystem
        "New-GMLBuild/OperatingSystem"
        {
            $v = "AMAZON_LINUX","AMAZON_LINUX_2","AMAZON_LINUX_2023","WINDOWS_2012","WINDOWS_2016"
            break
        }

        # Amazon.GameLift.PlacementFallbackStrategy
        "Start-GMLGameSessionPlacement/PriorityConfigurationOverride_PlacementFallbackStrategy"
        {
            $v = "DEFAULT_AFTER_SINGLE_PASS","NONE"
            break
        }

        # Amazon.GameLift.PlayerSessionCreationPolicy
        "Update-GMLGameSession/PlayerSessionCreationPolicy"
        {
            $v = "ACCEPT_ALL","DENY_ALL"
            break
        }

        # Amazon.GameLift.PolicyType
        "Write-GMLScalingPolicy/PolicyType"
        {
            $v = "RuleBased","TargetBased"
            break
        }

        # Amazon.GameLift.ProtectionPolicy
        {
            ($_ -eq "New-GMLContainerFleet/NewGameSessionProtectionPolicy") -Or
            ($_ -eq "New-GMLFleet/NewGameSessionProtectionPolicy") -Or
            ($_ -eq "Update-GMLContainerFleet/NewGameSessionProtectionPolicy") -Or
            ($_ -eq "Update-GMLFleetAttribute/NewGameSessionProtectionPolicy") -Or
            ($_ -eq "Update-GMLGameSession/ProtectionPolicy")
        }
        {
            $v = "FullProtection","NoProtection"
            break
        }

        # Amazon.GameLift.RoutingStrategyType
        {
            ($_ -eq "New-GMLAlias/RoutingStrategy_Type") -Or
            ($_ -eq "Update-GMLAlias/RoutingStrategy_Type") -Or
            ($_ -eq "Get-GMLAlias/RoutingStrategyType")
        }
        {
            $v = "SIMPLE","TERMINAL"
            break
        }

        # Amazon.GameLift.ScalingAdjustmentType
        "Write-GMLScalingPolicy/ScalingAdjustmentType"
        {
            $v = "ChangeInCapacity","ExactCapacity","PercentChangeInCapacity"
            break
        }

        # Amazon.GameLift.ScalingStatusType
        "Get-GMLScalingPolicy/StatusFilter"
        {
            $v = "ACTIVE","DELETED","DELETE_REQUESTED","DELETING","ERROR","UPDATE_REQUESTED","UPDATING"
            break
        }

        # Amazon.GameLift.SortOrder
        "Get-GMLGameServerList/SortOrder"
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.GameLift.TerminationMode
        "Stop-GMLGameSession/TerminationMode"
        {
            $v = "FORCE_TERMINATE","TRIGGER_ON_PROCESS_TERMINATE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GML_map = @{
    "AcceptanceType"=@("Confirm-GMLMatch")
    "BackfillMode"=@("New-GMLMatchmakingConfiguration","Update-GMLMatchmakingConfiguration")
    "BalancingStrategy"=@("New-GMLGameServerGroup","Update-GMLGameServerGroup")
    "BillingType"=@("New-GMLContainerFleet")
    "CertificateConfiguration_CertificateType"=@("New-GMLFleet")
    "ComparisonOperator"=@("Write-GMLScalingPolicy")
    "ComputeStatus"=@("Get-GMLComputeList")
    "ComputeType"=@("New-GMLFleet")
    "ContainerGroupType"=@("Get-GMLContainerGroupDefinitionList","New-GMLContainerGroupDefinition")
    "DeleteOption"=@("Remove-GMLGameServerGroup")
    "DeploymentConfiguration_ImpairmentStrategy"=@("Update-GMLContainerFleet")
    "DeploymentConfiguration_ProtectionStrategy"=@("Update-GMLContainerFleet")
    "EC2InstanceType"=@("Get-GMLEC2InstanceLimit","New-GMLFleet")
    "FleetType"=@("New-GMLFleet")
    "FlexMatchMode"=@("New-GMLMatchmakingConfiguration","Update-GMLMatchmakingConfiguration")
    "GameServerProtectionPolicy"=@("New-GMLGameServerGroup","Update-GMLGameServerGroup")
    "HealthCheck"=@("Update-GMLGameServer")
    "InstanceRoleCredentialsProvider"=@("New-GMLFleet")
    "LogConfiguration_LogDestination"=@("New-GMLContainerFleet","Update-GMLContainerFleet")
    "MetricName"=@("Write-GMLScalingPolicy")
    "NewGameSessionProtectionPolicy"=@("New-GMLContainerFleet","New-GMLFleet","Update-GMLContainerFleet","Update-GMLFleetAttribute")
    "OperatingSystem"=@("New-GMLBuild","New-GMLContainerGroupDefinition","Update-GMLContainerGroupDefinition")
    "PlayerSessionCreationPolicy"=@("Update-GMLGameSession")
    "PolicyType"=@("Write-GMLScalingPolicy")
    "PriorityConfigurationOverride_PlacementFallbackStrategy"=@("Start-GMLGameSessionPlacement")
    "ProtectionPolicy"=@("Update-GMLGameSession")
    "RoutingStrategy_Type"=@("New-GMLAlias","Update-GMLAlias")
    "RoutingStrategyType"=@("Get-GMLAlias")
    "ScalingAdjustmentType"=@("Write-GMLScalingPolicy")
    "SortOrder"=@("Get-GMLGameServerList")
    "Status"=@("Get-GMLBuild")
    "StatusFilter"=@("Get-GMLScalingPolicy")
    "TerminationMode"=@("Stop-GMLGameSession")
    "UtilizationStatus"=@("Update-GMLGameServer")
}

_awsArgumentCompleterRegistration $GML_Completers $GML_map

$GML_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GML.$($commandName.Replace('-', ''))Cmdlet]"
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

$GML_SelectMap = @{
    "Select"=@("Confirm-GMLMatch",
               "Request-GMLGameServer",
               "New-GMLAlias",
               "New-GMLBuild",
               "New-GMLContainerFleet",
               "New-GMLContainerGroupDefinition",
               "New-GMLFleet",
               "New-GMLFleetLocation",
               "New-GMLGameServerGroup",
               "New-GMLGameSession",
               "New-GMLGameSessionQueue",
               "New-GMLLocation",
               "New-GMLMatchmakingConfiguration",
               "New-GMLMatchmakingRuleSet",
               "New-GMLPlayerSession",
               "New-GMLScript",
               "New-GMLVpcPeeringAuthorization",
               "New-GMLVpcPeeringConnection",
               "Remove-GMLAlias",
               "Remove-GMLBuild",
               "Remove-GMLContainerFleet",
               "Remove-GMLContainerGroupDefinition",
               "Remove-GMLFleet",
               "Remove-GMLFleetLocation",
               "Remove-GMLGameServerGroup",
               "Remove-GMLGameSessionQueue",
               "Remove-GMLLocation",
               "Remove-GMLMatchmakingConfiguration",
               "Remove-GMLMatchmakingRuleSet",
               "Remove-GMLScalingPolicy",
               "Remove-GMLScript",
               "Remove-GMLVpcPeeringAuthorization",
               "Remove-GMLVpcPeeringConnection",
               "Unregister-GMLCompute",
               "Unregister-GMLGameServer",
               "Get-GMLAliasDetail",
               "Get-GMLBuildDetail",
               "Get-GMLCompute",
               "Get-GMLContainerFleet",
               "Get-GMLContainerGroupDefinition",
               "Get-GMLEC2InstanceLimit",
               "Get-GMLFleetAttribute",
               "Get-GMLFleetCapacity",
               "Get-GMLFleetDeployment",
               "Get-GMLFleetEvent",
               "Get-GMLFleetLocationAttribute",
               "Get-GMLFleetLocationCapacity",
               "Get-GMLFleetLocationUtilization",
               "Get-GMLFleetPortSetting",
               "Get-GMLFleetUtilization",
               "Get-GMLGameServer",
               "Get-GMLGameServerGroup",
               "Get-GMLGameServerInstance",
               "Get-GMLGameSessionDetail",
               "Get-GMLGameSessionPlacement",
               "Get-GMLGameSessionQueue",
               "Get-GMLGameSession",
               "Get-GMLInstance",
               "Get-GMLMatchmaking",
               "Get-GMLMatchmakingConfiguration",
               "Get-GMLMatchmakingRuleSet",
               "Get-GMLPlayerSession",
               "Get-GMLRuntimeConfiguration",
               "Get-GMLScalingPolicy",
               "Get-GMLScript",
               "Get-GMLVpcPeeringAuthorization",
               "Get-GMLVpcPeeringConnection",
               "Get-GMLComputeAccess",
               "Get-GMLComputeAuthToken",
               "Get-GMLGameSessionLogUrl",
               "Get-GMLInstanceAccess",
               "Get-GMLAlias",
               "Get-GMLBuild",
               "Get-GMLComputeList",
               "Get-GMLContainerFleetList",
               "Get-GMLContainerGroupDefinitionList",
               "Get-GMLContainerGroupDefinitionVersionList",
               "Get-GMLFleetDeploymentList",
               "Get-GMLFleet",
               "Get-GMLGameServerGroupList",
               "Get-GMLGameServerList",
               "Get-GMLLocationList",
               "Get-GMLScriptList",
               "Get-GMLResourceTag",
               "Write-GMLScalingPolicy",
               "Register-GMLCompute",
               "Register-GMLGameServer",
               "Request-GMLUploadCredential",
               "Resolve-GMLAlias",
               "Resume-GMLGameServerGroup",
               "Find-GMLGameSession",
               "Start-GMLFleetAction",
               "Start-GMLGameSessionPlacement",
               "Start-GMLMatchBackfill",
               "Start-GMLMatchmaking",
               "Stop-GMLFleetAction",
               "Stop-GMLGameSessionPlacement",
               "Stop-GMLMatchmaking",
               "Suspend-GMLGameServerGroup",
               "Add-GMLResourceTag",
               "Stop-GMLGameSession",
               "Remove-GMLResourceTag",
               "Update-GMLAlias",
               "Update-GMLBuild",
               "Update-GMLContainerFleet",
               "Update-GMLContainerGroupDefinition",
               "Update-GMLFleetAttribute",
               "Update-GMLFleetCapacity",
               "Update-GMLFleetPortSetting",
               "Update-GMLGameServer",
               "Update-GMLGameServerGroup",
               "Update-GMLGameSession",
               "Update-GMLGameSessionQueue",
               "Update-GMLMatchmakingConfiguration",
               "Update-GMLRuntimeConfiguration",
               "Update-GMLScript",
               "Test-GMLMatchmakingRuleSetValidity")
}

_awsArgumentCompleterRegistration $GML_SelectCompleters $GML_SelectMap

