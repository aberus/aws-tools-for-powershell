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

# Argument completions for service AWS Elemental MediaTailor


$EMT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MediaTailor.AccessType
        {
            ($_ -eq "New-EMTSourceLocation/AccessConfiguration_AccessType") -Or
            ($_ -eq "Update-EMTSourceLocation/AccessConfiguration_AccessType")
        }
        {
            $v = "S3_SIGV4","SECRETS_MANAGER_ACCESS_TOKEN"
            break
        }

        # Amazon.MediaTailor.Mode
        "Set-EMTPlaybackConfiguration/AvailSuppression_Mode"
        {
            $v = "BEHIND_LIVE_EDGE","OFF"
            break
        }

        # Amazon.MediaTailor.PlaybackMode
        "New-EMTChannel/PlaybackMode"
        {
            $v = "LINEAR","LOOP"
            break
        }

        # Amazon.MediaTailor.RelativePosition
        "New-EMTProgram/ScheduleConfiguration_Transition_RelativePosition"
        {
            $v = "AFTER_PROGRAM","BEFORE_PROGRAM"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EMT_map = @{
    "AccessConfiguration_AccessType"=@("New-EMTSourceLocation","Update-EMTSourceLocation")
    "AvailSuppression_Mode"=@("Set-EMTPlaybackConfiguration")
    "PlaybackMode"=@("New-EMTChannel")
    "ScheduleConfiguration_Transition_RelativePosition"=@("New-EMTProgram")
}

_awsArgumentCompleterRegistration $EMT_Completers $EMT_map

$EMT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EMT.$($commandName.Replace('-', ''))Cmdlet]"
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

$EMT_SelectMap = @{
    "Select"=@("Add-EMTLogsForPlaybackConfiguration",
               "New-EMTChannel",
               "New-EMTProgram",
               "New-EMTSourceLocation",
               "New-EMTVodSource",
               "Remove-EMTChannel",
               "Remove-EMTChannelPolicy",
               "Remove-EMTPlaybackConfiguration",
               "Remove-EMTProgram",
               "Remove-EMTSourceLocation",
               "Remove-EMTVodSource",
               "Get-EMTChannel",
               "Get-EMTProgram",
               "Get-EMTSourceLocation",
               "Get-EMTVodSource",
               "Get-EMTChannelPolicy",
               "Get-EMTChannelSchedule",
               "Get-EMTPlaybackConfiguration",
               "Get-EMTAlertList",
               "Get-EMTChannelList",
               "Get-EMTPlaybackConfigurationList",
               "Get-EMTSourceLocationList",
               "Get-EMTResourceTag",
               "Get-EMTVodSourceList",
               "Write-EMTChannelPolicy",
               "Set-EMTPlaybackConfiguration",
               "Start-EMTChannel",
               "Stop-EMTChannel",
               "Add-EMTResourceTag",
               "Remove-EMTResourceTag",
               "Update-EMTChannel",
               "Update-EMTSourceLocation",
               "Update-EMTVodSource")
}

_awsArgumentCompleterRegistration $EMT_SelectCompleters $EMT_SelectMap

