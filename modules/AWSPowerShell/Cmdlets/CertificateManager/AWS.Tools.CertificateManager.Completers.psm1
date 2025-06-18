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

# Argument completions for service AWS Certificate Manager


$ACM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CertificateManager.CertificateExport
        {
            ($_ -eq "Get-ACMCertificateList/Includes_ExportOption") -Or
            ($_ -eq "New-ACMCertificate/Options_Export") -Or
            ($_ -eq "Update-ACMCertificateOption/Options_Export")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CertificateManager.CertificateManagedBy
        {
            ($_ -eq "Get-ACMCertificateList/Includes_ManagedBy") -Or
            ($_ -eq "New-ACMCertificate/ManagedBy")
        }
        {
            $v = "CLOUDFRONT"
            break
        }

        # Amazon.CertificateManager.CertificateTransparencyLoggingPreference
        {
            ($_ -eq "New-ACMCertificate/Options_CertificateTransparencyLoggingPreference") -Or
            ($_ -eq "Update-ACMCertificateOption/Options_CertificateTransparencyLoggingPreference")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CertificateManager.KeyAlgorithm
        "New-ACMCertificate/KeyAlgorithm"
        {
            $v = "EC_prime256v1","EC_secp384r1","EC_secp521r1","RSA_1024","RSA_2048","RSA_3072","RSA_4096"
            break
        }

        # Amazon.CertificateManager.RevocationReason
        "Revoke-ACMCertificate/RevocationReason"
        {
            $v = "AFFILIATION_CHANGED","A_A_COMPROMISE","CA_COMPROMISE","CERTIFICATE_HOLD","CESSATION_OF_OPERATION","KEY_COMPROMISE","PRIVILEGE_WITHDRAWN","REMOVE_FROM_CRL","SUPERCEDED","SUPERSEDED","UNSPECIFIED"
            break
        }

        # Amazon.CertificateManager.SortBy
        "Get-ACMCertificateList/SortBy"
        {
            $v = "CREATED_AT"
            break
        }

        # Amazon.CertificateManager.SortOrder
        "Get-ACMCertificateList/SortOrder"
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.CertificateManager.ValidationMethod
        "New-ACMCertificate/ValidationMethod"
        {
            $v = "DNS","EMAIL","HTTP"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ACM_map = @{
    "Includes_ExportOption"=@("Get-ACMCertificateList")
    "Includes_ManagedBy"=@("Get-ACMCertificateList")
    "KeyAlgorithm"=@("New-ACMCertificate")
    "ManagedBy"=@("New-ACMCertificate")
    "Options_CertificateTransparencyLoggingPreference"=@("New-ACMCertificate","Update-ACMCertificateOption")
    "Options_Export"=@("New-ACMCertificate","Update-ACMCertificateOption")
    "RevocationReason"=@("Revoke-ACMCertificate")
    "SortBy"=@("Get-ACMCertificateList")
    "SortOrder"=@("Get-ACMCertificateList")
    "ValidationMethod"=@("New-ACMCertificate")
}

_awsArgumentCompleterRegistration $ACM_Completers $ACM_map

$ACM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ACM.$($commandName.Replace('-', ''))Cmdlet]"
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

$ACM_SelectMap = @{
    "Select"=@("Add-ACMCertificateTag",
               "Remove-ACMCertificate",
               "Get-ACMCertificateDetail",
               "Export-ACMCertificate",
               "Get-ACMAccountConfiguration",
               "Get-ACMCertificate",
               "Import-ACMCertificate",
               "Get-ACMCertificateList",
               "Get-ACMCertificateTagList",
               "Write-ACMAccountConfiguration",
               "Remove-ACMCertificateTag",
               "Invoke-ACMCertificateRenewal",
               "New-ACMCertificate",
               "Send-ACMValidationEmail",
               "Revoke-ACMCertificate",
               "Update-ACMCertificateOption")
}

_awsArgumentCompleterRegistration $ACM_SelectCompleters $ACM_SelectMap

