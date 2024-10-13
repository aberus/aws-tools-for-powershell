/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// <note><para>
    /// This action might generate an SMS text message. Starting June 1, 2021, US telecom
    /// carriers require you to register an origination phone number before you can send SMS
    /// messages to US phone numbers. If you use SMS text messages in Amazon Cognito, you
    /// must register a phone number with <a href="https://console.aws.amazon.com/pinpoint/home/">Amazon
    /// Pinpoint</a>. Amazon Cognito uses the registered number automatically. Otherwise,
    /// Amazon Cognito users who must receive SMS messages might not be able to sign up, activate
    /// their accounts, or sign in.
    /// </para><para>
    /// If you have never used SMS text messages with Amazon Cognito or any other Amazon Web
    /// Servicesservice, Amazon Simple Notification Service might place your account in the
    /// SMS sandbox. In <i><a href="https://docs.aws.amazon.com/sns/latest/dg/sns-sms-sandbox.html">sandbox
    /// mode</a></i>, you can send messages only to verified phone numbers. After you test
    /// your app while in the sandbox environment, you can move out of the sandbox and into
    /// production. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-sms-settings.html">
    /// SMS message settings for Amazon Cognito user pools</a> in the <i>Amazon Cognito Developer
    /// Guide</i>.
    /// </para></note><para>
    /// Creates a new Amazon Cognito user pool and sets the password policy for the pool.
    /// </para><important><para>
    /// If you don't provide a value for an attribute, Amazon Cognito sets it to its default
    /// value.
    /// </para></important><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "CGIPUserPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.UserPoolType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider CreateUserPool API operation.", Operation = new[] {"CreateUserPool"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.CreateUserPoolResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.UserPoolType or Amazon.CognitoIdentityProvider.Model.CreateUserPoolResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.UserPoolType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.CreateUserPoolResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGIPUserPoolCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter UserPoolAddOns_AdvancedSecurityMode
        /// <summary>
        /// <para>
        /// <para>The operating mode of advanced security features for standard authentication types
        /// in your user pool, including username-password and secure remote password (SRP) authentication.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AdvancedSecurityModeType")]
        public Amazon.CognitoIdentityProvider.AdvancedSecurityModeType UserPoolAddOns_AdvancedSecurityMode { get; set; }
        #endregion
        
        #region Parameter AliasAttribute
        /// <summary>
        /// <para>
        /// <para>Attributes supported as an alias for this user pool. Possible values: <b>phone_number</b>,
        /// <b>email</b>, or <b>preferred_username</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AliasAttributes")]
        public System.String[] AliasAttribute { get; set; }
        #endregion
        
        #region Parameter AdminCreateUserConfig_AllowAdminCreateUserOnly
        /// <summary>
        /// <para>
        /// <para>Set to <c>True</c> if only the administrator is allowed to create user profiles. Set
        /// to <c>False</c> if users can sign themselves up via an app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdminCreateUserConfig_AllowAdminCreateUserOnly { get; set; }
        #endregion
        
        #region Parameter UserAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate
        /// <summary>
        /// <para>
        /// <para>Requires that your user verifies their email address, phone number, or both before
        /// Amazon Cognito updates the value of that attribute. When you update a user attribute
        /// that has this option activated, Amazon Cognito sends a verification message to the
        /// new phone number or email address. Amazon Cognito doesn’t change the value of the
        /// attribute until your user responds to the verification message and confirms the new
        /// value.</para><para>You can verify an updated email address or phone number with a <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_VerifyUserAttribute.html">VerifyUserAttribute</a>
        /// API request. You can also call the <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_AdminUpdateUserAttributes.html">AdminUpdateUserAttributes</a>
        /// API and set <c>email_verified</c> or <c>phone_number_verified</c> to true.</para><para>When <c>AttributesRequireVerificationBeforeUpdate</c> is false, your user pool doesn't
        /// require that your users verify attribute changes before Amazon Cognito updates them.
        /// In a user pool where <c>AttributesRequireVerificationBeforeUpdate</c> is false, API
        /// operations that change attribute values can immediately update a user’s <c>email</c>
        /// or <c>phone_number</c> attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] UserAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate { get; set; }
        #endregion
        
        #region Parameter AutoVerifiedAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes to be auto-verified. Possible values: <b>email</b>, <b>phone_number</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoVerifiedAttributes")]
        public System.String[] AutoVerifiedAttribute { get; set; }
        #endregion
        
        #region Parameter UsernameConfiguration_CaseSensitive
        /// <summary>
        /// <para>
        /// <para>Specifies whether user name case sensitivity will be applied for all users in the
        /// user pool through Amazon Cognito APIs. For most use cases, set case sensitivity to
        /// <c>False</c> (case insensitive) as a best practice. When usernames and email addresses
        /// are case insensitive, users can sign in as the same user when they enter a different
        /// capitalization of their user name.</para><para>Valid values include:</para><dl><dt>True</dt><dd><para>Enables case sensitivity for all username input. When this option is set to <c>True</c>,
        /// users must sign in using the exact capitalization of their given username, such as
        /// “UserName”. This is the default value.</para></dd><dt>False</dt><dd><para>Enables case insensitivity for all username input. For example, when this option is
        /// set to <c>False</c>, users can sign in using <c>username</c>, <c>USERNAME</c>, or
        /// <c>UserName</c>. This option also enables both <c>preferred_username</c> and <c>email</c>
        /// alias to be case insensitive, in addition to the <c>username</c> attribute.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UsernameConfiguration_CaseSensitive { get; set; }
        #endregion
        
        #region Parameter DeviceConfiguration_ChallengeRequiredOnNewDevice
        /// <summary>
        /// <para>
        /// <para>When true, a remembered device can sign in with device authentication instead of SMS
        /// and time-based one-time password (TOTP) factors for multi-factor authentication (MFA).</para><note><para>Whether or not <c>ChallengeRequiredOnNewDevice</c> is true, users who sign in with
        /// devices that have not been confirmed or remembered must still provide a second factor
        /// in a user pool that requires MFA.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeviceConfiguration_ChallengeRequiredOnNewDevice { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_ConfigurationSet
        /// <summary>
        /// <para>
        /// <para>The set of configuration rules that can be applied to emails sent using Amazon Simple
        /// Email Service. A configuration set is applied to an email by including a reference
        /// to the configuration set in the headers of the email. Once applied, all of the rules
        /// in that configuration set are applied to the email. Configuration sets can be used
        /// to apply the following types of rules to emails: </para><dl><dt>Event publishing</dt><dd><para>Amazon Simple Email Service can track the number of send, delivery, open, click, bounce,
        /// and complaint events for each email sent. Use event publishing to send information
        /// about these events to other Amazon Web Services services such as and Amazon CloudWatch</para></dd><dt>IP pool management</dt><dd><para>When leasing dedicated IP addresses with Amazon Simple Email Service, you can create
        /// groups of IP addresses, called dedicated IP pools. You can then associate the dedicated
        /// IP pools with configuration sets.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailConfiguration_ConfigurationSet { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_CreateAuthChallenge
        /// <summary>
        /// <para>
        /// <para>Creates an authentication challenge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_CreateAuthChallenge { get; set; }
        #endregion
        
        #region Parameter AdvancedSecurityAdditionalFlows_CustomAuthMode
        /// <summary>
        /// <para>
        /// <para>The operating mode of advanced security features in custom authentication with <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-lambda-challenge.html">
        /// Custom authentication challenge Lambda triggers</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserPoolAddOns_AdvancedSecurityAdditionalFlows_CustomAuthMode")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AdvancedSecurityEnabledModeType")]
        public Amazon.CognitoIdentityProvider.AdvancedSecurityEnabledModeType AdvancedSecurityAdditionalFlows_CustomAuthMode { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_CustomMessage
        /// <summary>
        /// <para>
        /// <para>A custom Message Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_CustomMessage { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_DefaultEmailOption
        /// <summary>
        /// <para>
        /// <para>The default email option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.DefaultEmailOptionType")]
        public Amazon.CognitoIdentityProvider.DefaultEmailOptionType VerificationMessageTemplate_DefaultEmailOption { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_DefineAuthChallenge
        /// <summary>
        /// <para>
        /// <para>Defines the authentication challenge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_DefineAuthChallenge { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>When active, <c>DeletionProtection</c> prevents accidental deletion of your user pool.
        /// Before you can delete a user pool that you have protected against deletion, you must
        /// deactivate this feature.</para><para>When you try to delete a protected user pool in a <c>DeleteUserPool</c> API request,
        /// Amazon Cognito returns an <c>InvalidParameterException</c> error. To delete a protected
        /// user pool, send a new <c>DeleteUserPool</c> request after you deactivate deletion
        /// protection in an <c>UpdateUserPool</c> API request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.DeletionProtectionType")]
        public Amazon.CognitoIdentityProvider.DeletionProtectionType DeletionProtection { get; set; }
        #endregion
        
        #region Parameter DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt
        /// <summary>
        /// <para>
        /// <para>When true, Amazon Cognito doesn't automatically remember a user's device when your
        /// app sends a <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_ConfirmDevice.html">
        /// ConfirmDevice</a> API request. In your app, create a prompt for your user to choose
        /// whether they want to remember their device. Return the user's choice in an <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_UpdateDeviceStatus.html">
        /// UpdateDeviceStatus</a> API request.</para><para>When <c>DeviceOnlyRememberedOnUserPrompt</c> is <c>false</c>, Amazon Cognito immediately
        /// remembers devices that you register in a <c>ConfirmDevice</c> API request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_EmailMessage
        /// <summary>
        /// <para>
        /// <para>The message template for email messages. EmailMessage is allowed only if <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">EmailSendingAccount</a>
        /// is DEVELOPER. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_EmailMessage")]
        public System.String InviteMessageTemplate_EmailMessage { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_EmailMessage
        /// <summary>
        /// <para>
        /// <para>The template for email messages that Amazon Cognito sends to your users. You can set
        /// an <c>EmailMessage</c> template only if the value of <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">
        /// EmailSendingAccount</a> is <c>DEVELOPER</c>. When your <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">EmailSendingAccount</a>
        /// is <c>DEVELOPER</c>, your user pool sends email messages with your own Amazon SES
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_EmailMessage { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_EmailMessageByLink
        /// <summary>
        /// <para>
        /// <para>The email message template for sending a confirmation link to the user. You can set
        /// an <c>EmailMessageByLink</c> template only if the value of <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">
        /// EmailSendingAccount</a> is <c>DEVELOPER</c>. When your <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">EmailSendingAccount</a>
        /// is <c>DEVELOPER</c>, your user pool sends email messages with your own Amazon SES
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_EmailMessageByLink { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_EmailSendingAccount
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon Cognito uses its built-in functionality to send your users
        /// email messages, or uses your Amazon Simple Email Service email configuration. Specify
        /// one of the following values:</para><dl><dt>COGNITO_DEFAULT</dt><dd><para>When Amazon Cognito emails your users, it uses its built-in email functionality. When
        /// you use the default option, Amazon Cognito allows only a limited number of emails
        /// each day for your user pool. For typical production environments, the default email
        /// limit is less than the required delivery volume. To achieve a higher delivery volume,
        /// specify DEVELOPER to use your Amazon SES email configuration.</para><para>To look up the email delivery limit for the default option, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/limits.html">Limits</a>
        /// in the <i>Amazon Cognito Developer Guide</i>.</para><para>The default FROM address is <c>no-reply@verificationemail.com</c>. To customize the
        /// FROM address, provide the Amazon Resource Name (ARN) of an Amazon SES verified email
        /// address for the <c>SourceArn</c> parameter.</para></dd><dt>DEVELOPER</dt><dd><para>When Amazon Cognito emails your users, it uses your Amazon SES configuration. Amazon
        /// Cognito calls Amazon SES on your behalf to send email from your verified email address.
        /// When you use this option, the email delivery limits are the same limits that apply
        /// to your Amazon SES verified email address in your Amazon Web Services account.</para><para>If you use this option, provide the ARN of an Amazon SES verified email address for
        /// the <c>SourceArn</c> parameter.</para><para>Before Amazon Cognito can email your users, it requires additional permissions to
        /// call Amazon SES on your behalf. When you update your user pool with this option, Amazon
        /// Cognito creates a <i>service-linked role</i>, which is a type of role in your Amazon
        /// Web Services account. This role contains the permissions that allow you to access
        /// Amazon SES and send email messages from your email address. For more information about
        /// the service-linked role that Amazon Cognito creates, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/using-service-linked-roles.html">Using
        /// Service-Linked Roles for Amazon Cognito</a> in the <i>Amazon Cognito Developer Guide</i>.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.EmailSendingAccountType")]
        public Amazon.CognitoIdentityProvider.EmailSendingAccountType EmailConfiguration_EmailSendingAccount { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_EmailSubject
        /// <summary>
        /// <para>
        /// <para>The subject line for email messages. EmailSubject is allowed only if <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">EmailSendingAccount</a>
        /// is DEVELOPER. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_EmailSubject")]
        public System.String InviteMessageTemplate_EmailSubject { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_EmailSubject
        /// <summary>
        /// <para>
        /// <para>The subject line for the email message template. You can set an <c>EmailSubject</c>
        /// template only if the value of <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">
        /// EmailSendingAccount</a> is <c>DEVELOPER</c>. When your <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">EmailSendingAccount</a>
        /// is <c>DEVELOPER</c>, your user pool sends email messages with your own Amazon SES
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_EmailSubject { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_EmailSubjectByLink
        /// <summary>
        /// <para>
        /// <para>The subject line for the email message template for sending a confirmation link to
        /// the user. You can set an <c>EmailSubjectByLink</c> template only if the value of <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">
        /// EmailSendingAccount</a> is <c>DEVELOPER</c>. When your <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_EmailConfigurationType.html#CognitoUserPools-Type-EmailConfigurationType-EmailSendingAccount">EmailSendingAccount</a>
        /// is <c>DEVELOPER</c>, your user pool sends email messages with your own Amazon SES
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_EmailSubjectByLink { get; set; }
        #endregion
        
        #region Parameter EmailVerificationMessage
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. See <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_VerificationMessageTemplateType.html">VerificationMessageTemplateType</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailVerificationMessage { get; set; }
        #endregion
        
        #region Parameter EmailVerificationSubject
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. See <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_VerificationMessageTemplateType.html">VerificationMessageTemplateType</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailVerificationSubject { get; set; }
        #endregion
        
        #region Parameter SmsConfiguration_ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID provides additional security for your IAM role. You can use an <c>ExternalId</c>
        /// with the IAM role that you use with Amazon SNS to send SMS messages for your user
        /// pool. If you provide an <c>ExternalId</c>, your Amazon Cognito user pool includes
        /// it in the request to assume your IAM role. You can configure the role trust policy
        /// to require that Amazon Cognito, and any principal, provide the <c>ExternalID</c>.
        /// If you use the Amazon Cognito Management Console to create a role for SMS multi-factor
        /// authentication (MFA), Amazon Cognito creates a role with the required permissions
        /// and a trust policy that demonstrates use of the <c>ExternalId</c>.</para><para>For more information about the <c>ExternalId</c> of a role, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_create_for-user_externalid.html">How
        /// to use an external ID when granting access to your Amazon Web Services resources to
        /// a third party</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsConfiguration_ExternalId { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_From
        /// <summary>
        /// <para>
        /// <para>Either the sender’s email address or the sender’s name with their email address. For
        /// example, <c>testuser@example.com</c> or <c>Test User &lt;testuser@example.com&gt;</c>.
        /// This address appears before the body of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailConfiguration_From { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_KMSKeyID
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an <a href="/kms/latest/developerguide/concepts.html#master_keys">KMS
        /// key</a>. Amazon Cognito uses the key to encrypt codes and temporary passwords sent
        /// to <c>CustomEmailSender</c> and <c>CustomSMSSender</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_KMSKeyID { get; set; }
        #endregion
        
        #region Parameter CustomEmailSender_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the function that you want to assign to your Lambda
        /// trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaConfig_CustomEmailSender_LambdaArn")]
        public System.String CustomEmailSender_LambdaArn { get; set; }
        #endregion
        
        #region Parameter CustomSMSSender_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the function that you want to assign to your Lambda
        /// trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaConfig_CustomSMSSender_LambdaArn")]
        public System.String CustomSMSSender_LambdaArn { get; set; }
        #endregion
        
        #region Parameter PreTokenGenerationConfig_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the function that you want to assign to your Lambda
        /// trigger.</para><para>This parameter and the <c>PreTokenGeneration</c> property of <c>LambdaConfig</c> have
        /// the same value. For new instances of pre token generation triggers, set <c>LambdaArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaConfig_PreTokenGenerationConfig_LambdaArn")]
        public System.String PreTokenGenerationConfig_LambdaArn { get; set; }
        #endregion
        
        #region Parameter CustomEmailSender_LambdaVersion
        /// <summary>
        /// <para>
        /// <para>The user pool trigger version of the request that Amazon Cognito sends to your Lambda
        /// function. Higher-numbered versions add fields that support new features.</para><para>You must use a <c>LambdaVersion</c> of <c>V1_0</c> with a custom sender function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaConfig_CustomEmailSender_LambdaVersion")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.CustomEmailSenderLambdaVersionType")]
        public Amazon.CognitoIdentityProvider.CustomEmailSenderLambdaVersionType CustomEmailSender_LambdaVersion { get; set; }
        #endregion
        
        #region Parameter CustomSMSSender_LambdaVersion
        /// <summary>
        /// <para>
        /// <para>The user pool trigger version of the request that Amazon Cognito sends to your Lambda
        /// function. Higher-numbered versions add fields that support new features.</para><para>You must use a <c>LambdaVersion</c> of <c>V1_0</c> with a custom sender function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaConfig_CustomSMSSender_LambdaVersion")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.CustomSMSSenderLambdaVersionType")]
        public Amazon.CognitoIdentityProvider.CustomSMSSenderLambdaVersionType CustomSMSSender_LambdaVersion { get; set; }
        #endregion
        
        #region Parameter PreTokenGenerationConfig_LambdaVersion
        /// <summary>
        /// <para>
        /// <para>The user pool trigger version of the request that Amazon Cognito sends to your Lambda
        /// function. Higher-numbered versions add fields that support new features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaConfig_PreTokenGenerationConfig_LambdaVersion")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.PreTokenGenerationLambdaVersionType")]
        public Amazon.CognitoIdentityProvider.PreTokenGenerationLambdaVersionType PreTokenGenerationConfig_LambdaVersion { get; set; }
        #endregion
        
        #region Parameter MfaConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies MFA configuration details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.UserPoolMfaType")]
        public Amazon.CognitoIdentityProvider.UserPoolMfaType MfaConfiguration { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_MinimumLength
        /// <summary>
        /// <para>
        /// <para>The minimum length of the password in the policy that you have set. This value can't
        /// be less than 6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_MinimumLength")]
        public System.Int32? PasswordPolicy_MinimumLength { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_PasswordHistorySize
        /// <summary>
        /// <para>
        /// <para>The number of previous passwords that you want Amazon Cognito to restrict each user
        /// from reusing. Users can't set a password that matches any of <c>n</c> previous passwords,
        /// where <c>n</c> is the value of <c>PasswordHistorySize</c>.</para><para>Password history isn't enforced and isn't displayed in <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_DescribeUserPool.html">DescribeUserPool</a>
        /// responses when you set this value to <c>0</c> or don't provide it. To activate this
        /// setting, <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pool-settings-advanced-security.html">
        /// advanced security features</a> must be active in your user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_PasswordHistorySize")]
        public System.Int32? PasswordPolicy_PasswordHistorySize { get; set; }
        #endregion
        
        #region Parameter PoolName
        /// <summary>
        /// <para>
        /// <para>A string used to name the user pool.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PoolName { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PostAuthentication
        /// <summary>
        /// <para>
        /// <para>A post-authentication Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PostAuthentication { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PostConfirmation
        /// <summary>
        /// <para>
        /// <para>A post-confirmation Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PostConfirmation { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PreAuthentication
        /// <summary>
        /// <para>
        /// <para>A pre-authentication Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PreAuthentication { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PreSignUp
        /// <summary>
        /// <para>
        /// <para>A pre-registration Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PreSignUp { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PreTokenGeneration
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the function that you want to assign to your Lambda
        /// trigger.</para><para>Set this parameter for legacy purposes. If you also set an ARN in <c>PreTokenGenerationConfig</c>,
        /// its value must be identical to <c>PreTokenGeneration</c>. For new instances of pre
        /// token generation triggers, set the <c>LambdaArn</c> of <c>PreTokenGenerationConfig</c>.</para><para>You can set <code /></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PreTokenGeneration { get; set; }
        #endregion
        
        #region Parameter AccountRecoverySetting_RecoveryMechanism
        /// <summary>
        /// <para>
        /// <para>The list of <c>RecoveryOptionTypes</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountRecoverySetting_RecoveryMechanisms")]
        public Amazon.CognitoIdentityProvider.Model.RecoveryOptionType[] AccountRecoverySetting_RecoveryMechanism { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_ReplyToEmailAddress
        /// <summary>
        /// <para>
        /// <para>The destination to which the receiver of the email should reply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailConfiguration_ReplyToEmailAddress { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireLowercase
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one lowercase letter in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_RequireLowercase")]
        public System.Boolean? PasswordPolicy_RequireLowercase { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireNumber
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one number in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_RequireNumbers")]
        public System.Boolean? PasswordPolicy_RequireNumber { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireSymbol
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one symbol in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_RequireSymbols")]
        public System.Boolean? PasswordPolicy_RequireSymbol { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireUppercase
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one uppercase letter in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_RequireUppercase")]
        public System.Boolean? PasswordPolicy_RequireUppercase { get; set; }
        #endregion
        
        #region Parameter Schema
        /// <summary>
        /// <para>
        /// <para>An array of schema attributes for the new user pool. These attributes can be standard
        /// or custom attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CognitoIdentityProvider.Model.SchemaAttributeType[] Schema { get; set; }
        #endregion
        
        #region Parameter SmsAuthenticationMessage
        /// <summary>
        /// <para>
        /// <para>A string representing the SMS authentication message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsAuthenticationMessage { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_SmsMessage
        /// <summary>
        /// <para>
        /// <para>The template for SMS messages that Amazon Cognito sends to your users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_SmsMessage { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_SMSMessage
        /// <summary>
        /// <para>
        /// <para>The message template for SMS messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_SMSMessage")]
        public System.String InviteMessageTemplate_SMSMessage { get; set; }
        #endregion
        
        #region Parameter SmsVerificationMessage
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used. See <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_VerificationMessageTemplateType.html">VerificationMessageTemplateType</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsVerificationMessage { get; set; }
        #endregion
        
        #region Parameter SmsConfiguration_SnsCallerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS caller. This is the ARN of the IAM
        /// role in your Amazon Web Services account that Amazon Cognito will use to send SMS
        /// messages. SMS messages are subject to a <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-settings-email-phone-verification.html">spending
        /// limit</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsConfiguration_SnsCallerArn { get; set; }
        #endregion
        
        #region Parameter SmsConfiguration_SnsRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region to use with Amazon SNS integration. You can choose
        /// the same Region as your user pool, or a supported <b>Legacy Amazon SNS alternate Region</b>.
        /// </para><para> Amazon Cognito resources in the Asia Pacific (Seoul) Amazon Web Services Region must
        /// use your Amazon SNS configuration in the Asia Pacific (Tokyo) Region. For more information,
        /// see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-sms-settings.html">SMS
        /// message settings for Amazon Cognito user pools</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsConfiguration_SnsRegion { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_SourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a verified email address or an address from a verified domain in Amazon
        /// SES. You can set a <c>SourceArn</c> email from a verified domain only with an API
        /// request. You can set a verified email address, but not an address in a verified domain,
        /// in the Amazon Cognito console. Amazon Cognito uses the email address that you provide
        /// in one of the following ways, depending on the value that you specify for the <c>EmailSendingAccount</c>
        /// parameter:</para><ul><li><para>If you specify <c>COGNITO_DEFAULT</c>, Amazon Cognito uses this address as the custom
        /// FROM address when it emails your users using its built-in email account.</para></li><li><para>If you specify <c>DEVELOPER</c>, Amazon Cognito emails your users with this address
        /// by calling Amazon SES on your behalf.</para></li></ul><para>The Region value of the <c>SourceArn</c> parameter must indicate a supported Amazon
        /// Web Services Region of your user pool. Typically, the Region in the <c>SourceArn</c>
        /// and the user pool Region are the same. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-email.html#user-pool-email-developer-region-mapping">Amazon
        /// SES email configuration regions</a> in the <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools.html">Amazon
        /// Cognito Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailConfiguration_SourceArn { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_TemporaryPasswordValidityDay
        /// <summary>
        /// <para>
        /// <para>The number of days a temporary password is valid in the password policy. If the user
        /// doesn't sign in during this time, an administrator must reset their password. Defaults
        /// to <c>7</c>. If you submit a value of <c>0</c>, Amazon Cognito treats it as a null
        /// value and sets <c>TemporaryPasswordValidityDays</c> to its default value.</para><note><para>When you set <c>TemporaryPasswordValidityDays</c> for a user pool, you can no longer
        /// set a value for the legacy <c>UnusedAccountValidityDays</c> parameter in that user
        /// pool.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_TemporaryPasswordValidityDays")]
        public System.Int32? PasswordPolicy_TemporaryPasswordValidityDay { get; set; }
        #endregion
        
        #region Parameter AdminCreateUserConfig_UnusedAccountValidityDay
        /// <summary>
        /// <para>
        /// <para>The user account expiration limit, in days, after which a new account that hasn't
        /// signed in is no longer usable. To reset the account after that time limit, you must
        /// call <c>AdminCreateUser</c> again, specifying <c>"RESEND"</c> for the <c>MessageAction</c>
        /// parameter. The default value for this parameter is 7.</para><note><para>If you set a value for <c>TemporaryPasswordValidityDays</c> in <c>PasswordPolicy</c>,
        /// that value will be used, and <c>UnusedAccountValidityDays</c> will be no longer be
        /// an available parameter for that user pool.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminCreateUserConfig_UnusedAccountValidityDays")]
        public System.Int32? AdminCreateUserConfig_UnusedAccountValidityDay { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_UserMigration
        /// <summary>
        /// <para>
        /// <para>The user migration Lambda config type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_UserMigration { get; set; }
        #endregion
        
        #region Parameter UsernameAttribute
        /// <summary>
        /// <para>
        /// <para>Specifies whether a user can use an email address or phone number as a username when
        /// they sign up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UsernameAttributes")]
        public System.String[] UsernameAttribute { get; set; }
        #endregion
        
        #region Parameter UserPoolTag
        /// <summary>
        /// <para>
        /// <para>The tag keys and values to assign to the user pool. A tag is a label that you can
        /// use to categorize and manage user pools in different ways, such as by purpose, owner,
        /// environment, or other criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserPoolTags")]
        public System.Collections.Hashtable UserPoolTag { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_VerifyAuthChallengeResponse
        /// <summary>
        /// <para>
        /// <para>Verifies the authentication challenge response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_VerifyAuthChallengeResponse { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserPool'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.CreateUserPoolResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.CreateUserPoolResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserPool";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PoolName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PoolName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PoolName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PoolName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIPUserPool (CreateUserPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.CreateUserPoolResponse, NewCGIPUserPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PoolName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountRecoverySetting_RecoveryMechanism != null)
            {
                context.AccountRecoverySetting_RecoveryMechanism = new List<Amazon.CognitoIdentityProvider.Model.RecoveryOptionType>(this.AccountRecoverySetting_RecoveryMechanism);
            }
            context.AdminCreateUserConfig_AllowAdminCreateUserOnly = this.AdminCreateUserConfig_AllowAdminCreateUserOnly;
            context.InviteMessageTemplate_EmailMessage = this.InviteMessageTemplate_EmailMessage;
            context.InviteMessageTemplate_EmailSubject = this.InviteMessageTemplate_EmailSubject;
            context.InviteMessageTemplate_SMSMessage = this.InviteMessageTemplate_SMSMessage;
            context.AdminCreateUserConfig_UnusedAccountValidityDay = this.AdminCreateUserConfig_UnusedAccountValidityDay;
            if (this.AliasAttribute != null)
            {
                context.AliasAttribute = new List<System.String>(this.AliasAttribute);
            }
            if (this.AutoVerifiedAttribute != null)
            {
                context.AutoVerifiedAttribute = new List<System.String>(this.AutoVerifiedAttribute);
            }
            context.DeletionProtection = this.DeletionProtection;
            context.DeviceConfiguration_ChallengeRequiredOnNewDevice = this.DeviceConfiguration_ChallengeRequiredOnNewDevice;
            context.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt = this.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt;
            context.EmailConfiguration_ConfigurationSet = this.EmailConfiguration_ConfigurationSet;
            context.EmailConfiguration_EmailSendingAccount = this.EmailConfiguration_EmailSendingAccount;
            context.EmailConfiguration_From = this.EmailConfiguration_From;
            context.EmailConfiguration_ReplyToEmailAddress = this.EmailConfiguration_ReplyToEmailAddress;
            context.EmailConfiguration_SourceArn = this.EmailConfiguration_SourceArn;
            context.EmailVerificationMessage = this.EmailVerificationMessage;
            context.EmailVerificationSubject = this.EmailVerificationSubject;
            context.LambdaConfig_CreateAuthChallenge = this.LambdaConfig_CreateAuthChallenge;
            context.CustomEmailSender_LambdaArn = this.CustomEmailSender_LambdaArn;
            context.CustomEmailSender_LambdaVersion = this.CustomEmailSender_LambdaVersion;
            context.LambdaConfig_CustomMessage = this.LambdaConfig_CustomMessage;
            context.CustomSMSSender_LambdaArn = this.CustomSMSSender_LambdaArn;
            context.CustomSMSSender_LambdaVersion = this.CustomSMSSender_LambdaVersion;
            context.LambdaConfig_DefineAuthChallenge = this.LambdaConfig_DefineAuthChallenge;
            context.LambdaConfig_KMSKeyID = this.LambdaConfig_KMSKeyID;
            context.LambdaConfig_PostAuthentication = this.LambdaConfig_PostAuthentication;
            context.LambdaConfig_PostConfirmation = this.LambdaConfig_PostConfirmation;
            context.LambdaConfig_PreAuthentication = this.LambdaConfig_PreAuthentication;
            context.LambdaConfig_PreSignUp = this.LambdaConfig_PreSignUp;
            context.LambdaConfig_PreTokenGeneration = this.LambdaConfig_PreTokenGeneration;
            context.PreTokenGenerationConfig_LambdaArn = this.PreTokenGenerationConfig_LambdaArn;
            context.PreTokenGenerationConfig_LambdaVersion = this.PreTokenGenerationConfig_LambdaVersion;
            context.LambdaConfig_UserMigration = this.LambdaConfig_UserMigration;
            context.LambdaConfig_VerifyAuthChallengeResponse = this.LambdaConfig_VerifyAuthChallengeResponse;
            context.MfaConfiguration = this.MfaConfiguration;
            context.PasswordPolicy_MinimumLength = this.PasswordPolicy_MinimumLength;
            context.PasswordPolicy_PasswordHistorySize = this.PasswordPolicy_PasswordHistorySize;
            context.PasswordPolicy_RequireLowercase = this.PasswordPolicy_RequireLowercase;
            context.PasswordPolicy_RequireNumber = this.PasswordPolicy_RequireNumber;
            context.PasswordPolicy_RequireSymbol = this.PasswordPolicy_RequireSymbol;
            context.PasswordPolicy_RequireUppercase = this.PasswordPolicy_RequireUppercase;
            context.PasswordPolicy_TemporaryPasswordValidityDay = this.PasswordPolicy_TemporaryPasswordValidityDay;
            context.PoolName = this.PoolName;
            #if MODULAR
            if (this.PoolName == null && ParameterWasBound(nameof(this.PoolName)))
            {
                WriteWarning("You are passing $null as a value for parameter PoolName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Schema != null)
            {
                context.Schema = new List<Amazon.CognitoIdentityProvider.Model.SchemaAttributeType>(this.Schema);
            }
            context.SmsAuthenticationMessage = this.SmsAuthenticationMessage;
            context.SmsConfiguration_ExternalId = this.SmsConfiguration_ExternalId;
            context.SmsConfiguration_SnsCallerArn = this.SmsConfiguration_SnsCallerArn;
            context.SmsConfiguration_SnsRegion = this.SmsConfiguration_SnsRegion;
            context.SmsVerificationMessage = this.SmsVerificationMessage;
            if (this.UserAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate != null)
            {
                context.UserAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate = new List<System.String>(this.UserAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate);
            }
            if (this.UsernameAttribute != null)
            {
                context.UsernameAttribute = new List<System.String>(this.UsernameAttribute);
            }
            context.UsernameConfiguration_CaseSensitive = this.UsernameConfiguration_CaseSensitive;
            context.AdvancedSecurityAdditionalFlows_CustomAuthMode = this.AdvancedSecurityAdditionalFlows_CustomAuthMode;
            context.UserPoolAddOns_AdvancedSecurityMode = this.UserPoolAddOns_AdvancedSecurityMode;
            if (this.UserPoolTag != null)
            {
                context.UserPoolTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.UserPoolTag.Keys)
                {
                    context.UserPoolTag.Add((String)hashKey, (System.String)(this.UserPoolTag[hashKey]));
                }
            }
            context.VerificationMessageTemplate_DefaultEmailOption = this.VerificationMessageTemplate_DefaultEmailOption;
            context.VerificationMessageTemplate_EmailMessage = this.VerificationMessageTemplate_EmailMessage;
            context.VerificationMessageTemplate_EmailMessageByLink = this.VerificationMessageTemplate_EmailMessageByLink;
            context.VerificationMessageTemplate_EmailSubject = this.VerificationMessageTemplate_EmailSubject;
            context.VerificationMessageTemplate_EmailSubjectByLink = this.VerificationMessageTemplate_EmailSubjectByLink;
            context.VerificationMessageTemplate_SmsMessage = this.VerificationMessageTemplate_SmsMessage;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CognitoIdentityProvider.Model.CreateUserPoolRequest();
            
            
             // populate AccountRecoverySetting
            var requestAccountRecoverySettingIsNull = true;
            request.AccountRecoverySetting = new Amazon.CognitoIdentityProvider.Model.AccountRecoverySettingType();
            List<Amazon.CognitoIdentityProvider.Model.RecoveryOptionType> requestAccountRecoverySetting_accountRecoverySetting_RecoveryMechanism = null;
            if (cmdletContext.AccountRecoverySetting_RecoveryMechanism != null)
            {
                requestAccountRecoverySetting_accountRecoverySetting_RecoveryMechanism = cmdletContext.AccountRecoverySetting_RecoveryMechanism;
            }
            if (requestAccountRecoverySetting_accountRecoverySetting_RecoveryMechanism != null)
            {
                request.AccountRecoverySetting.RecoveryMechanisms = requestAccountRecoverySetting_accountRecoverySetting_RecoveryMechanism;
                requestAccountRecoverySettingIsNull = false;
            }
             // determine if request.AccountRecoverySetting should be set to null
            if (requestAccountRecoverySettingIsNull)
            {
                request.AccountRecoverySetting = null;
            }
            
             // populate AdminCreateUserConfig
            var requestAdminCreateUserConfigIsNull = true;
            request.AdminCreateUserConfig = new Amazon.CognitoIdentityProvider.Model.AdminCreateUserConfigType();
            System.Boolean? requestAdminCreateUserConfig_adminCreateUserConfig_AllowAdminCreateUserOnly = null;
            if (cmdletContext.AdminCreateUserConfig_AllowAdminCreateUserOnly != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_AllowAdminCreateUserOnly = cmdletContext.AdminCreateUserConfig_AllowAdminCreateUserOnly.Value;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_AllowAdminCreateUserOnly != null)
            {
                request.AdminCreateUserConfig.AllowAdminCreateUserOnly = requestAdminCreateUserConfig_adminCreateUserConfig_AllowAdminCreateUserOnly.Value;
                requestAdminCreateUserConfigIsNull = false;
            }
            System.Int32? requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay = null;
            if (cmdletContext.AdminCreateUserConfig_UnusedAccountValidityDay != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay = cmdletContext.AdminCreateUserConfig_UnusedAccountValidityDay.Value;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay != null)
            {
                request.AdminCreateUserConfig.UnusedAccountValidityDays = requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay.Value;
                requestAdminCreateUserConfigIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.MessageTemplateType requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate = null;
            
             // populate InviteMessageTemplate
            var requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = true;
            requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate = new Amazon.CognitoIdentityProvider.Model.MessageTemplateType();
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage = null;
            if (cmdletContext.InviteMessageTemplate_EmailMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage = cmdletContext.InviteMessageTemplate_EmailMessage;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate.EmailMessage = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage;
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = false;
            }
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject = null;
            if (cmdletContext.InviteMessageTemplate_EmailSubject != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject = cmdletContext.InviteMessageTemplate_EmailSubject;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate.EmailSubject = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject;
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = false;
            }
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage = null;
            if (cmdletContext.InviteMessageTemplate_SMSMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage = cmdletContext.InviteMessageTemplate_SMSMessage;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate.SMSMessage = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage;
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = false;
            }
             // determine if requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate should be set to null
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate = null;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate != null)
            {
                request.AdminCreateUserConfig.InviteMessageTemplate = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate;
                requestAdminCreateUserConfigIsNull = false;
            }
             // determine if request.AdminCreateUserConfig should be set to null
            if (requestAdminCreateUserConfigIsNull)
            {
                request.AdminCreateUserConfig = null;
            }
            if (cmdletContext.AliasAttribute != null)
            {
                request.AliasAttributes = cmdletContext.AliasAttribute;
            }
            if (cmdletContext.AutoVerifiedAttribute != null)
            {
                request.AutoVerifiedAttributes = cmdletContext.AutoVerifiedAttribute;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection;
            }
            
             // populate DeviceConfiguration
            var requestDeviceConfigurationIsNull = true;
            request.DeviceConfiguration = new Amazon.CognitoIdentityProvider.Model.DeviceConfigurationType();
            System.Boolean? requestDeviceConfiguration_deviceConfiguration_ChallengeRequiredOnNewDevice = null;
            if (cmdletContext.DeviceConfiguration_ChallengeRequiredOnNewDevice != null)
            {
                requestDeviceConfiguration_deviceConfiguration_ChallengeRequiredOnNewDevice = cmdletContext.DeviceConfiguration_ChallengeRequiredOnNewDevice.Value;
            }
            if (requestDeviceConfiguration_deviceConfiguration_ChallengeRequiredOnNewDevice != null)
            {
                request.DeviceConfiguration.ChallengeRequiredOnNewDevice = requestDeviceConfiguration_deviceConfiguration_ChallengeRequiredOnNewDevice.Value;
                requestDeviceConfigurationIsNull = false;
            }
            System.Boolean? requestDeviceConfiguration_deviceConfiguration_DeviceOnlyRememberedOnUserPrompt = null;
            if (cmdletContext.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt != null)
            {
                requestDeviceConfiguration_deviceConfiguration_DeviceOnlyRememberedOnUserPrompt = cmdletContext.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt.Value;
            }
            if (requestDeviceConfiguration_deviceConfiguration_DeviceOnlyRememberedOnUserPrompt != null)
            {
                request.DeviceConfiguration.DeviceOnlyRememberedOnUserPrompt = requestDeviceConfiguration_deviceConfiguration_DeviceOnlyRememberedOnUserPrompt.Value;
                requestDeviceConfigurationIsNull = false;
            }
             // determine if request.DeviceConfiguration should be set to null
            if (requestDeviceConfigurationIsNull)
            {
                request.DeviceConfiguration = null;
            }
            
             // populate EmailConfiguration
            var requestEmailConfigurationIsNull = true;
            request.EmailConfiguration = new Amazon.CognitoIdentityProvider.Model.EmailConfigurationType();
            System.String requestEmailConfiguration_emailConfiguration_ConfigurationSet = null;
            if (cmdletContext.EmailConfiguration_ConfigurationSet != null)
            {
                requestEmailConfiguration_emailConfiguration_ConfigurationSet = cmdletContext.EmailConfiguration_ConfigurationSet;
            }
            if (requestEmailConfiguration_emailConfiguration_ConfigurationSet != null)
            {
                request.EmailConfiguration.ConfigurationSet = requestEmailConfiguration_emailConfiguration_ConfigurationSet;
                requestEmailConfigurationIsNull = false;
            }
            Amazon.CognitoIdentityProvider.EmailSendingAccountType requestEmailConfiguration_emailConfiguration_EmailSendingAccount = null;
            if (cmdletContext.EmailConfiguration_EmailSendingAccount != null)
            {
                requestEmailConfiguration_emailConfiguration_EmailSendingAccount = cmdletContext.EmailConfiguration_EmailSendingAccount;
            }
            if (requestEmailConfiguration_emailConfiguration_EmailSendingAccount != null)
            {
                request.EmailConfiguration.EmailSendingAccount = requestEmailConfiguration_emailConfiguration_EmailSendingAccount;
                requestEmailConfigurationIsNull = false;
            }
            System.String requestEmailConfiguration_emailConfiguration_From = null;
            if (cmdletContext.EmailConfiguration_From != null)
            {
                requestEmailConfiguration_emailConfiguration_From = cmdletContext.EmailConfiguration_From;
            }
            if (requestEmailConfiguration_emailConfiguration_From != null)
            {
                request.EmailConfiguration.From = requestEmailConfiguration_emailConfiguration_From;
                requestEmailConfigurationIsNull = false;
            }
            System.String requestEmailConfiguration_emailConfiguration_ReplyToEmailAddress = null;
            if (cmdletContext.EmailConfiguration_ReplyToEmailAddress != null)
            {
                requestEmailConfiguration_emailConfiguration_ReplyToEmailAddress = cmdletContext.EmailConfiguration_ReplyToEmailAddress;
            }
            if (requestEmailConfiguration_emailConfiguration_ReplyToEmailAddress != null)
            {
                request.EmailConfiguration.ReplyToEmailAddress = requestEmailConfiguration_emailConfiguration_ReplyToEmailAddress;
                requestEmailConfigurationIsNull = false;
            }
            System.String requestEmailConfiguration_emailConfiguration_SourceArn = null;
            if (cmdletContext.EmailConfiguration_SourceArn != null)
            {
                requestEmailConfiguration_emailConfiguration_SourceArn = cmdletContext.EmailConfiguration_SourceArn;
            }
            if (requestEmailConfiguration_emailConfiguration_SourceArn != null)
            {
                request.EmailConfiguration.SourceArn = requestEmailConfiguration_emailConfiguration_SourceArn;
                requestEmailConfigurationIsNull = false;
            }
             // determine if request.EmailConfiguration should be set to null
            if (requestEmailConfigurationIsNull)
            {
                request.EmailConfiguration = null;
            }
            if (cmdletContext.EmailVerificationMessage != null)
            {
                request.EmailVerificationMessage = cmdletContext.EmailVerificationMessage;
            }
            if (cmdletContext.EmailVerificationSubject != null)
            {
                request.EmailVerificationSubject = cmdletContext.EmailVerificationSubject;
            }
            
             // populate LambdaConfig
            var requestLambdaConfigIsNull = true;
            request.LambdaConfig = new Amazon.CognitoIdentityProvider.Model.LambdaConfigType();
            System.String requestLambdaConfig_lambdaConfig_CreateAuthChallenge = null;
            if (cmdletContext.LambdaConfig_CreateAuthChallenge != null)
            {
                requestLambdaConfig_lambdaConfig_CreateAuthChallenge = cmdletContext.LambdaConfig_CreateAuthChallenge;
            }
            if (requestLambdaConfig_lambdaConfig_CreateAuthChallenge != null)
            {
                request.LambdaConfig.CreateAuthChallenge = requestLambdaConfig_lambdaConfig_CreateAuthChallenge;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_CustomMessage = null;
            if (cmdletContext.LambdaConfig_CustomMessage != null)
            {
                requestLambdaConfig_lambdaConfig_CustomMessage = cmdletContext.LambdaConfig_CustomMessage;
            }
            if (requestLambdaConfig_lambdaConfig_CustomMessage != null)
            {
                request.LambdaConfig.CustomMessage = requestLambdaConfig_lambdaConfig_CustomMessage;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_DefineAuthChallenge = null;
            if (cmdletContext.LambdaConfig_DefineAuthChallenge != null)
            {
                requestLambdaConfig_lambdaConfig_DefineAuthChallenge = cmdletContext.LambdaConfig_DefineAuthChallenge;
            }
            if (requestLambdaConfig_lambdaConfig_DefineAuthChallenge != null)
            {
                request.LambdaConfig.DefineAuthChallenge = requestLambdaConfig_lambdaConfig_DefineAuthChallenge;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_KMSKeyID = null;
            if (cmdletContext.LambdaConfig_KMSKeyID != null)
            {
                requestLambdaConfig_lambdaConfig_KMSKeyID = cmdletContext.LambdaConfig_KMSKeyID;
            }
            if (requestLambdaConfig_lambdaConfig_KMSKeyID != null)
            {
                request.LambdaConfig.KMSKeyID = requestLambdaConfig_lambdaConfig_KMSKeyID;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PostAuthentication = null;
            if (cmdletContext.LambdaConfig_PostAuthentication != null)
            {
                requestLambdaConfig_lambdaConfig_PostAuthentication = cmdletContext.LambdaConfig_PostAuthentication;
            }
            if (requestLambdaConfig_lambdaConfig_PostAuthentication != null)
            {
                request.LambdaConfig.PostAuthentication = requestLambdaConfig_lambdaConfig_PostAuthentication;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PostConfirmation = null;
            if (cmdletContext.LambdaConfig_PostConfirmation != null)
            {
                requestLambdaConfig_lambdaConfig_PostConfirmation = cmdletContext.LambdaConfig_PostConfirmation;
            }
            if (requestLambdaConfig_lambdaConfig_PostConfirmation != null)
            {
                request.LambdaConfig.PostConfirmation = requestLambdaConfig_lambdaConfig_PostConfirmation;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PreAuthentication = null;
            if (cmdletContext.LambdaConfig_PreAuthentication != null)
            {
                requestLambdaConfig_lambdaConfig_PreAuthentication = cmdletContext.LambdaConfig_PreAuthentication;
            }
            if (requestLambdaConfig_lambdaConfig_PreAuthentication != null)
            {
                request.LambdaConfig.PreAuthentication = requestLambdaConfig_lambdaConfig_PreAuthentication;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PreSignUp = null;
            if (cmdletContext.LambdaConfig_PreSignUp != null)
            {
                requestLambdaConfig_lambdaConfig_PreSignUp = cmdletContext.LambdaConfig_PreSignUp;
            }
            if (requestLambdaConfig_lambdaConfig_PreSignUp != null)
            {
                request.LambdaConfig.PreSignUp = requestLambdaConfig_lambdaConfig_PreSignUp;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PreTokenGeneration = null;
            if (cmdletContext.LambdaConfig_PreTokenGeneration != null)
            {
                requestLambdaConfig_lambdaConfig_PreTokenGeneration = cmdletContext.LambdaConfig_PreTokenGeneration;
            }
            if (requestLambdaConfig_lambdaConfig_PreTokenGeneration != null)
            {
                request.LambdaConfig.PreTokenGeneration = requestLambdaConfig_lambdaConfig_PreTokenGeneration;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_UserMigration = null;
            if (cmdletContext.LambdaConfig_UserMigration != null)
            {
                requestLambdaConfig_lambdaConfig_UserMigration = cmdletContext.LambdaConfig_UserMigration;
            }
            if (requestLambdaConfig_lambdaConfig_UserMigration != null)
            {
                request.LambdaConfig.UserMigration = requestLambdaConfig_lambdaConfig_UserMigration;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_VerifyAuthChallengeResponse = null;
            if (cmdletContext.LambdaConfig_VerifyAuthChallengeResponse != null)
            {
                requestLambdaConfig_lambdaConfig_VerifyAuthChallengeResponse = cmdletContext.LambdaConfig_VerifyAuthChallengeResponse;
            }
            if (requestLambdaConfig_lambdaConfig_VerifyAuthChallengeResponse != null)
            {
                request.LambdaConfig.VerifyAuthChallengeResponse = requestLambdaConfig_lambdaConfig_VerifyAuthChallengeResponse;
                requestLambdaConfigIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.CustomEmailLambdaVersionConfigType requestLambdaConfig_lambdaConfig_CustomEmailSender = null;
            
             // populate CustomEmailSender
            var requestLambdaConfig_lambdaConfig_CustomEmailSenderIsNull = true;
            requestLambdaConfig_lambdaConfig_CustomEmailSender = new Amazon.CognitoIdentityProvider.Model.CustomEmailLambdaVersionConfigType();
            System.String requestLambdaConfig_lambdaConfig_CustomEmailSender_customEmailSender_LambdaArn = null;
            if (cmdletContext.CustomEmailSender_LambdaArn != null)
            {
                requestLambdaConfig_lambdaConfig_CustomEmailSender_customEmailSender_LambdaArn = cmdletContext.CustomEmailSender_LambdaArn;
            }
            if (requestLambdaConfig_lambdaConfig_CustomEmailSender_customEmailSender_LambdaArn != null)
            {
                requestLambdaConfig_lambdaConfig_CustomEmailSender.LambdaArn = requestLambdaConfig_lambdaConfig_CustomEmailSender_customEmailSender_LambdaArn;
                requestLambdaConfig_lambdaConfig_CustomEmailSenderIsNull = false;
            }
            Amazon.CognitoIdentityProvider.CustomEmailSenderLambdaVersionType requestLambdaConfig_lambdaConfig_CustomEmailSender_customEmailSender_LambdaVersion = null;
            if (cmdletContext.CustomEmailSender_LambdaVersion != null)
            {
                requestLambdaConfig_lambdaConfig_CustomEmailSender_customEmailSender_LambdaVersion = cmdletContext.CustomEmailSender_LambdaVersion;
            }
            if (requestLambdaConfig_lambdaConfig_CustomEmailSender_customEmailSender_LambdaVersion != null)
            {
                requestLambdaConfig_lambdaConfig_CustomEmailSender.LambdaVersion = requestLambdaConfig_lambdaConfig_CustomEmailSender_customEmailSender_LambdaVersion;
                requestLambdaConfig_lambdaConfig_CustomEmailSenderIsNull = false;
            }
             // determine if requestLambdaConfig_lambdaConfig_CustomEmailSender should be set to null
            if (requestLambdaConfig_lambdaConfig_CustomEmailSenderIsNull)
            {
                requestLambdaConfig_lambdaConfig_CustomEmailSender = null;
            }
            if (requestLambdaConfig_lambdaConfig_CustomEmailSender != null)
            {
                request.LambdaConfig.CustomEmailSender = requestLambdaConfig_lambdaConfig_CustomEmailSender;
                requestLambdaConfigIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.CustomSMSLambdaVersionConfigType requestLambdaConfig_lambdaConfig_CustomSMSSender = null;
            
             // populate CustomSMSSender
            var requestLambdaConfig_lambdaConfig_CustomSMSSenderIsNull = true;
            requestLambdaConfig_lambdaConfig_CustomSMSSender = new Amazon.CognitoIdentityProvider.Model.CustomSMSLambdaVersionConfigType();
            System.String requestLambdaConfig_lambdaConfig_CustomSMSSender_customSMSSender_LambdaArn = null;
            if (cmdletContext.CustomSMSSender_LambdaArn != null)
            {
                requestLambdaConfig_lambdaConfig_CustomSMSSender_customSMSSender_LambdaArn = cmdletContext.CustomSMSSender_LambdaArn;
            }
            if (requestLambdaConfig_lambdaConfig_CustomSMSSender_customSMSSender_LambdaArn != null)
            {
                requestLambdaConfig_lambdaConfig_CustomSMSSender.LambdaArn = requestLambdaConfig_lambdaConfig_CustomSMSSender_customSMSSender_LambdaArn;
                requestLambdaConfig_lambdaConfig_CustomSMSSenderIsNull = false;
            }
            Amazon.CognitoIdentityProvider.CustomSMSSenderLambdaVersionType requestLambdaConfig_lambdaConfig_CustomSMSSender_customSMSSender_LambdaVersion = null;
            if (cmdletContext.CustomSMSSender_LambdaVersion != null)
            {
                requestLambdaConfig_lambdaConfig_CustomSMSSender_customSMSSender_LambdaVersion = cmdletContext.CustomSMSSender_LambdaVersion;
            }
            if (requestLambdaConfig_lambdaConfig_CustomSMSSender_customSMSSender_LambdaVersion != null)
            {
                requestLambdaConfig_lambdaConfig_CustomSMSSender.LambdaVersion = requestLambdaConfig_lambdaConfig_CustomSMSSender_customSMSSender_LambdaVersion;
                requestLambdaConfig_lambdaConfig_CustomSMSSenderIsNull = false;
            }
             // determine if requestLambdaConfig_lambdaConfig_CustomSMSSender should be set to null
            if (requestLambdaConfig_lambdaConfig_CustomSMSSenderIsNull)
            {
                requestLambdaConfig_lambdaConfig_CustomSMSSender = null;
            }
            if (requestLambdaConfig_lambdaConfig_CustomSMSSender != null)
            {
                request.LambdaConfig.CustomSMSSender = requestLambdaConfig_lambdaConfig_CustomSMSSender;
                requestLambdaConfigIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.PreTokenGenerationVersionConfigType requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig = null;
            
             // populate PreTokenGenerationConfig
            var requestLambdaConfig_lambdaConfig_PreTokenGenerationConfigIsNull = true;
            requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig = new Amazon.CognitoIdentityProvider.Model.PreTokenGenerationVersionConfigType();
            System.String requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig_preTokenGenerationConfig_LambdaArn = null;
            if (cmdletContext.PreTokenGenerationConfig_LambdaArn != null)
            {
                requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig_preTokenGenerationConfig_LambdaArn = cmdletContext.PreTokenGenerationConfig_LambdaArn;
            }
            if (requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig_preTokenGenerationConfig_LambdaArn != null)
            {
                requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig.LambdaArn = requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig_preTokenGenerationConfig_LambdaArn;
                requestLambdaConfig_lambdaConfig_PreTokenGenerationConfigIsNull = false;
            }
            Amazon.CognitoIdentityProvider.PreTokenGenerationLambdaVersionType requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig_preTokenGenerationConfig_LambdaVersion = null;
            if (cmdletContext.PreTokenGenerationConfig_LambdaVersion != null)
            {
                requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig_preTokenGenerationConfig_LambdaVersion = cmdletContext.PreTokenGenerationConfig_LambdaVersion;
            }
            if (requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig_preTokenGenerationConfig_LambdaVersion != null)
            {
                requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig.LambdaVersion = requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig_preTokenGenerationConfig_LambdaVersion;
                requestLambdaConfig_lambdaConfig_PreTokenGenerationConfigIsNull = false;
            }
             // determine if requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig should be set to null
            if (requestLambdaConfig_lambdaConfig_PreTokenGenerationConfigIsNull)
            {
                requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig = null;
            }
            if (requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig != null)
            {
                request.LambdaConfig.PreTokenGenerationConfig = requestLambdaConfig_lambdaConfig_PreTokenGenerationConfig;
                requestLambdaConfigIsNull = false;
            }
             // determine if request.LambdaConfig should be set to null
            if (requestLambdaConfigIsNull)
            {
                request.LambdaConfig = null;
            }
            if (cmdletContext.MfaConfiguration != null)
            {
                request.MfaConfiguration = cmdletContext.MfaConfiguration;
            }
            
             // populate Policies
            var requestPoliciesIsNull = true;
            request.Policies = new Amazon.CognitoIdentityProvider.Model.UserPoolPolicyType();
            Amazon.CognitoIdentityProvider.Model.PasswordPolicyType requestPolicies_policies_PasswordPolicy = null;
            
             // populate PasswordPolicy
            var requestPolicies_policies_PasswordPolicyIsNull = true;
            requestPolicies_policies_PasswordPolicy = new Amazon.CognitoIdentityProvider.Model.PasswordPolicyType();
            System.Int32? requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength = null;
            if (cmdletContext.PasswordPolicy_MinimumLength != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength = cmdletContext.PasswordPolicy_MinimumLength.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength != null)
            {
                requestPolicies_policies_PasswordPolicy.MinimumLength = requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Int32? requestPolicies_policies_PasswordPolicy_passwordPolicy_PasswordHistorySize = null;
            if (cmdletContext.PasswordPolicy_PasswordHistorySize != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_PasswordHistorySize = cmdletContext.PasswordPolicy_PasswordHistorySize.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_PasswordHistorySize != null)
            {
                requestPolicies_policies_PasswordPolicy.PasswordHistorySize = requestPolicies_policies_PasswordPolicy_passwordPolicy_PasswordHistorySize.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase = null;
            if (cmdletContext.PasswordPolicy_RequireLowercase != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase = cmdletContext.PasswordPolicy_RequireLowercase.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireLowercase = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber = null;
            if (cmdletContext.PasswordPolicy_RequireNumber != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber = cmdletContext.PasswordPolicy_RequireNumber.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireNumbers = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol = null;
            if (cmdletContext.PasswordPolicy_RequireSymbol != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol = cmdletContext.PasswordPolicy_RequireSymbol.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireSymbols = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase = null;
            if (cmdletContext.PasswordPolicy_RequireUppercase != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase = cmdletContext.PasswordPolicy_RequireUppercase.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireUppercase = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Int32? requestPolicies_policies_PasswordPolicy_passwordPolicy_TemporaryPasswordValidityDay = null;
            if (cmdletContext.PasswordPolicy_TemporaryPasswordValidityDay != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_TemporaryPasswordValidityDay = cmdletContext.PasswordPolicy_TemporaryPasswordValidityDay.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_TemporaryPasswordValidityDay != null)
            {
                requestPolicies_policies_PasswordPolicy.TemporaryPasswordValidityDays = requestPolicies_policies_PasswordPolicy_passwordPolicy_TemporaryPasswordValidityDay.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
             // determine if requestPolicies_policies_PasswordPolicy should be set to null
            if (requestPolicies_policies_PasswordPolicyIsNull)
            {
                requestPolicies_policies_PasswordPolicy = null;
            }
            if (requestPolicies_policies_PasswordPolicy != null)
            {
                request.Policies.PasswordPolicy = requestPolicies_policies_PasswordPolicy;
                requestPoliciesIsNull = false;
            }
             // determine if request.Policies should be set to null
            if (requestPoliciesIsNull)
            {
                request.Policies = null;
            }
            if (cmdletContext.PoolName != null)
            {
                request.PoolName = cmdletContext.PoolName;
            }
            if (cmdletContext.Schema != null)
            {
                request.Schema = cmdletContext.Schema;
            }
            if (cmdletContext.SmsAuthenticationMessage != null)
            {
                request.SmsAuthenticationMessage = cmdletContext.SmsAuthenticationMessage;
            }
            
             // populate SmsConfiguration
            var requestSmsConfigurationIsNull = true;
            request.SmsConfiguration = new Amazon.CognitoIdentityProvider.Model.SmsConfigurationType();
            System.String requestSmsConfiguration_smsConfiguration_ExternalId = null;
            if (cmdletContext.SmsConfiguration_ExternalId != null)
            {
                requestSmsConfiguration_smsConfiguration_ExternalId = cmdletContext.SmsConfiguration_ExternalId;
            }
            if (requestSmsConfiguration_smsConfiguration_ExternalId != null)
            {
                request.SmsConfiguration.ExternalId = requestSmsConfiguration_smsConfiguration_ExternalId;
                requestSmsConfigurationIsNull = false;
            }
            System.String requestSmsConfiguration_smsConfiguration_SnsCallerArn = null;
            if (cmdletContext.SmsConfiguration_SnsCallerArn != null)
            {
                requestSmsConfiguration_smsConfiguration_SnsCallerArn = cmdletContext.SmsConfiguration_SnsCallerArn;
            }
            if (requestSmsConfiguration_smsConfiguration_SnsCallerArn != null)
            {
                request.SmsConfiguration.SnsCallerArn = requestSmsConfiguration_smsConfiguration_SnsCallerArn;
                requestSmsConfigurationIsNull = false;
            }
            System.String requestSmsConfiguration_smsConfiguration_SnsRegion = null;
            if (cmdletContext.SmsConfiguration_SnsRegion != null)
            {
                requestSmsConfiguration_smsConfiguration_SnsRegion = cmdletContext.SmsConfiguration_SnsRegion;
            }
            if (requestSmsConfiguration_smsConfiguration_SnsRegion != null)
            {
                request.SmsConfiguration.SnsRegion = requestSmsConfiguration_smsConfiguration_SnsRegion;
                requestSmsConfigurationIsNull = false;
            }
             // determine if request.SmsConfiguration should be set to null
            if (requestSmsConfigurationIsNull)
            {
                request.SmsConfiguration = null;
            }
            if (cmdletContext.SmsVerificationMessage != null)
            {
                request.SmsVerificationMessage = cmdletContext.SmsVerificationMessage;
            }
            
             // populate UserAttributeUpdateSettings
            var requestUserAttributeUpdateSettingsIsNull = true;
            request.UserAttributeUpdateSettings = new Amazon.CognitoIdentityProvider.Model.UserAttributeUpdateSettingsType();
            List<System.String> requestUserAttributeUpdateSettings_userAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate = null;
            if (cmdletContext.UserAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate != null)
            {
                requestUserAttributeUpdateSettings_userAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate = cmdletContext.UserAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate;
            }
            if (requestUserAttributeUpdateSettings_userAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate != null)
            {
                request.UserAttributeUpdateSettings.AttributesRequireVerificationBeforeUpdate = requestUserAttributeUpdateSettings_userAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate;
                requestUserAttributeUpdateSettingsIsNull = false;
            }
             // determine if request.UserAttributeUpdateSettings should be set to null
            if (requestUserAttributeUpdateSettingsIsNull)
            {
                request.UserAttributeUpdateSettings = null;
            }
            if (cmdletContext.UsernameAttribute != null)
            {
                request.UsernameAttributes = cmdletContext.UsernameAttribute;
            }
            
             // populate UsernameConfiguration
            var requestUsernameConfigurationIsNull = true;
            request.UsernameConfiguration = new Amazon.CognitoIdentityProvider.Model.UsernameConfigurationType();
            System.Boolean? requestUsernameConfiguration_usernameConfiguration_CaseSensitive = null;
            if (cmdletContext.UsernameConfiguration_CaseSensitive != null)
            {
                requestUsernameConfiguration_usernameConfiguration_CaseSensitive = cmdletContext.UsernameConfiguration_CaseSensitive.Value;
            }
            if (requestUsernameConfiguration_usernameConfiguration_CaseSensitive != null)
            {
                request.UsernameConfiguration.CaseSensitive = requestUsernameConfiguration_usernameConfiguration_CaseSensitive.Value;
                requestUsernameConfigurationIsNull = false;
            }
             // determine if request.UsernameConfiguration should be set to null
            if (requestUsernameConfigurationIsNull)
            {
                request.UsernameConfiguration = null;
            }
            
             // populate UserPoolAddOns
            var requestUserPoolAddOnsIsNull = true;
            request.UserPoolAddOns = new Amazon.CognitoIdentityProvider.Model.UserPoolAddOnsType();
            Amazon.CognitoIdentityProvider.AdvancedSecurityModeType requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityMode = null;
            if (cmdletContext.UserPoolAddOns_AdvancedSecurityMode != null)
            {
                requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityMode = cmdletContext.UserPoolAddOns_AdvancedSecurityMode;
            }
            if (requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityMode != null)
            {
                request.UserPoolAddOns.AdvancedSecurityMode = requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityMode;
                requestUserPoolAddOnsIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.AdvancedSecurityAdditionalFlowsType requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows = null;
            
             // populate AdvancedSecurityAdditionalFlows
            var requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlowsIsNull = true;
            requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows = new Amazon.CognitoIdentityProvider.Model.AdvancedSecurityAdditionalFlowsType();
            Amazon.CognitoIdentityProvider.AdvancedSecurityEnabledModeType requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows_advancedSecurityAdditionalFlows_CustomAuthMode = null;
            if (cmdletContext.AdvancedSecurityAdditionalFlows_CustomAuthMode != null)
            {
                requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows_advancedSecurityAdditionalFlows_CustomAuthMode = cmdletContext.AdvancedSecurityAdditionalFlows_CustomAuthMode;
            }
            if (requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows_advancedSecurityAdditionalFlows_CustomAuthMode != null)
            {
                requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows.CustomAuthMode = requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows_advancedSecurityAdditionalFlows_CustomAuthMode;
                requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlowsIsNull = false;
            }
             // determine if requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows should be set to null
            if (requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlowsIsNull)
            {
                requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows = null;
            }
            if (requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows != null)
            {
                request.UserPoolAddOns.AdvancedSecurityAdditionalFlows = requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityAdditionalFlows;
                requestUserPoolAddOnsIsNull = false;
            }
             // determine if request.UserPoolAddOns should be set to null
            if (requestUserPoolAddOnsIsNull)
            {
                request.UserPoolAddOns = null;
            }
            if (cmdletContext.UserPoolTag != null)
            {
                request.UserPoolTags = cmdletContext.UserPoolTag;
            }
            
             // populate VerificationMessageTemplate
            var requestVerificationMessageTemplateIsNull = true;
            request.VerificationMessageTemplate = new Amazon.CognitoIdentityProvider.Model.VerificationMessageTemplateType();
            Amazon.CognitoIdentityProvider.DefaultEmailOptionType requestVerificationMessageTemplate_verificationMessageTemplate_DefaultEmailOption = null;
            if (cmdletContext.VerificationMessageTemplate_DefaultEmailOption != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_DefaultEmailOption = cmdletContext.VerificationMessageTemplate_DefaultEmailOption;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_DefaultEmailOption != null)
            {
                request.VerificationMessageTemplate.DefaultEmailOption = requestVerificationMessageTemplate_verificationMessageTemplate_DefaultEmailOption;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessage = null;
            if (cmdletContext.VerificationMessageTemplate_EmailMessage != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessage = cmdletContext.VerificationMessageTemplate_EmailMessage;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessage != null)
            {
                request.VerificationMessageTemplate.EmailMessage = requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessage;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessageByLink = null;
            if (cmdletContext.VerificationMessageTemplate_EmailMessageByLink != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessageByLink = cmdletContext.VerificationMessageTemplate_EmailMessageByLink;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessageByLink != null)
            {
                request.VerificationMessageTemplate.EmailMessageByLink = requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessageByLink;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubject = null;
            if (cmdletContext.VerificationMessageTemplate_EmailSubject != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubject = cmdletContext.VerificationMessageTemplate_EmailSubject;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubject != null)
            {
                request.VerificationMessageTemplate.EmailSubject = requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubject;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubjectByLink = null;
            if (cmdletContext.VerificationMessageTemplate_EmailSubjectByLink != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubjectByLink = cmdletContext.VerificationMessageTemplate_EmailSubjectByLink;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubjectByLink != null)
            {
                request.VerificationMessageTemplate.EmailSubjectByLink = requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubjectByLink;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_SmsMessage = null;
            if (cmdletContext.VerificationMessageTemplate_SmsMessage != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_SmsMessage = cmdletContext.VerificationMessageTemplate_SmsMessage;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_SmsMessage != null)
            {
                request.VerificationMessageTemplate.SmsMessage = requestVerificationMessageTemplate_verificationMessageTemplate_SmsMessage;
                requestVerificationMessageTemplateIsNull = false;
            }
             // determine if request.VerificationMessageTemplate should be set to null
            if (requestVerificationMessageTemplateIsNull)
            {
                request.VerificationMessageTemplate = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CognitoIdentityProvider.Model.CreateUserPoolResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.CreateUserPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "CreateUserPool");
            try
            {
                #if DESKTOP
                return client.CreateUserPool(request);
                #elif CORECLR
                return client.CreateUserPoolAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<Amazon.CognitoIdentityProvider.Model.RecoveryOptionType> AccountRecoverySetting_RecoveryMechanism { get; set; }
            public System.Boolean? AdminCreateUserConfig_AllowAdminCreateUserOnly { get; set; }
            public System.String InviteMessageTemplate_EmailMessage { get; set; }
            public System.String InviteMessageTemplate_EmailSubject { get; set; }
            public System.String InviteMessageTemplate_SMSMessage { get; set; }
            public System.Int32? AdminCreateUserConfig_UnusedAccountValidityDay { get; set; }
            public List<System.String> AliasAttribute { get; set; }
            public List<System.String> AutoVerifiedAttribute { get; set; }
            public Amazon.CognitoIdentityProvider.DeletionProtectionType DeletionProtection { get; set; }
            public System.Boolean? DeviceConfiguration_ChallengeRequiredOnNewDevice { get; set; }
            public System.Boolean? DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt { get; set; }
            public System.String EmailConfiguration_ConfigurationSet { get; set; }
            public Amazon.CognitoIdentityProvider.EmailSendingAccountType EmailConfiguration_EmailSendingAccount { get; set; }
            public System.String EmailConfiguration_From { get; set; }
            public System.String EmailConfiguration_ReplyToEmailAddress { get; set; }
            public System.String EmailConfiguration_SourceArn { get; set; }
            public System.String EmailVerificationMessage { get; set; }
            public System.String EmailVerificationSubject { get; set; }
            public System.String LambdaConfig_CreateAuthChallenge { get; set; }
            public System.String CustomEmailSender_LambdaArn { get; set; }
            public Amazon.CognitoIdentityProvider.CustomEmailSenderLambdaVersionType CustomEmailSender_LambdaVersion { get; set; }
            public System.String LambdaConfig_CustomMessage { get; set; }
            public System.String CustomSMSSender_LambdaArn { get; set; }
            public Amazon.CognitoIdentityProvider.CustomSMSSenderLambdaVersionType CustomSMSSender_LambdaVersion { get; set; }
            public System.String LambdaConfig_DefineAuthChallenge { get; set; }
            public System.String LambdaConfig_KMSKeyID { get; set; }
            public System.String LambdaConfig_PostAuthentication { get; set; }
            public System.String LambdaConfig_PostConfirmation { get; set; }
            public System.String LambdaConfig_PreAuthentication { get; set; }
            public System.String LambdaConfig_PreSignUp { get; set; }
            public System.String LambdaConfig_PreTokenGeneration { get; set; }
            public System.String PreTokenGenerationConfig_LambdaArn { get; set; }
            public Amazon.CognitoIdentityProvider.PreTokenGenerationLambdaVersionType PreTokenGenerationConfig_LambdaVersion { get; set; }
            public System.String LambdaConfig_UserMigration { get; set; }
            public System.String LambdaConfig_VerifyAuthChallengeResponse { get; set; }
            public Amazon.CognitoIdentityProvider.UserPoolMfaType MfaConfiguration { get; set; }
            public System.Int32? PasswordPolicy_MinimumLength { get; set; }
            public System.Int32? PasswordPolicy_PasswordHistorySize { get; set; }
            public System.Boolean? PasswordPolicy_RequireLowercase { get; set; }
            public System.Boolean? PasswordPolicy_RequireNumber { get; set; }
            public System.Boolean? PasswordPolicy_RequireSymbol { get; set; }
            public System.Boolean? PasswordPolicy_RequireUppercase { get; set; }
            public System.Int32? PasswordPolicy_TemporaryPasswordValidityDay { get; set; }
            public System.String PoolName { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.SchemaAttributeType> Schema { get; set; }
            public System.String SmsAuthenticationMessage { get; set; }
            public System.String SmsConfiguration_ExternalId { get; set; }
            public System.String SmsConfiguration_SnsCallerArn { get; set; }
            public System.String SmsConfiguration_SnsRegion { get; set; }
            public System.String SmsVerificationMessage { get; set; }
            public List<System.String> UserAttributeUpdateSettings_AttributesRequireVerificationBeforeUpdate { get; set; }
            public List<System.String> UsernameAttribute { get; set; }
            public System.Boolean? UsernameConfiguration_CaseSensitive { get; set; }
            public Amazon.CognitoIdentityProvider.AdvancedSecurityEnabledModeType AdvancedSecurityAdditionalFlows_CustomAuthMode { get; set; }
            public Amazon.CognitoIdentityProvider.AdvancedSecurityModeType UserPoolAddOns_AdvancedSecurityMode { get; set; }
            public Dictionary<System.String, System.String> UserPoolTag { get; set; }
            public Amazon.CognitoIdentityProvider.DefaultEmailOptionType VerificationMessageTemplate_DefaultEmailOption { get; set; }
            public System.String VerificationMessageTemplate_EmailMessage { get; set; }
            public System.String VerificationMessageTemplate_EmailMessageByLink { get; set; }
            public System.String VerificationMessageTemplate_EmailSubject { get; set; }
            public System.String VerificationMessageTemplate_EmailSubjectByLink { get; set; }
            public System.String VerificationMessageTemplate_SmsMessage { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.CreateUserPoolResponse, NewCGIPUserPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserPool;
        }
        
    }
}
