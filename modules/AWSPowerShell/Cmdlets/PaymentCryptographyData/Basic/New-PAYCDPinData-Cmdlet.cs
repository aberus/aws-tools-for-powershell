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
using Amazon.PaymentCryptographyData;
using Amazon.PaymentCryptographyData.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCD
{
    /// <summary>
    /// Generates pin-related data such as PIN, PIN Verification Value (PVV), PIN Block, and
    /// PIN Offset during new card issuance or reissuance. For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/generate-pin-data.html">Generate
    /// PIN data</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// 
    ///  
    /// <para>
    /// PIN data is never transmitted in clear to or from Amazon Web Services Payment Cryptography.
    /// This operation generates PIN, PVV, or PIN Offset and then encrypts it using Pin Encryption
    /// Key (PEK) to create an <c>EncryptedPinBlock</c> for transmission from Amazon Web Services
    /// Payment Cryptography. This operation uses a separate Pin Verification Key (PVK) for
    /// VISA PVV generation. 
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>.
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>GenerateCardValidationData</a></para></li><li><para><a>TranslatePinData</a></para></li><li><para><a>VerifyPinData</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PAYCDPinData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data GeneratePinData API operation.", Operation = new[] {"GeneratePinData"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPAYCDPinDataCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Ibm3624NaturalPin_DecimalizationTable
        /// <summary>
        /// <para>
        /// <para>The decimalization table to use for IBM 3624 PIN algorithm. The table is used to convert
        /// the algorithm intermediate result from hexadecimal characters to decimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624NaturalPin_DecimalizationTable")]
        public System.String Ibm3624NaturalPin_DecimalizationTable { get; set; }
        #endregion
        
        #region Parameter Ibm3624PinFromOffset_DecimalizationTable
        /// <summary>
        /// <para>
        /// <para>The decimalization table to use for IBM 3624 PIN algorithm. The table is used to convert
        /// the algorithm intermediate result from hexadecimal characters to decimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624PinFromOffset_DecimalizationTable")]
        public System.String Ibm3624PinFromOffset_DecimalizationTable { get; set; }
        #endregion
        
        #region Parameter Ibm3624PinOffset_DecimalizationTable
        /// <summary>
        /// <para>
        /// <para>The decimalization table to use for IBM 3624 PIN algorithm. The table is used to convert
        /// the algorithm intermediate result from hexadecimal characters to decimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624PinOffset_DecimalizationTable")]
        public System.String Ibm3624PinOffset_DecimalizationTable { get; set; }
        #endregion
        
        #region Parameter Ibm3624RandomPin_DecimalizationTable
        /// <summary>
        /// <para>
        /// <para>The decimalization table to use for IBM 3624 PIN algorithm. The table is used to convert
        /// the algorithm intermediate result from hexadecimal characters to decimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624RandomPin_DecimalizationTable")]
        public System.String Ibm3624RandomPin_DecimalizationTable { get; set; }
        #endregion
        
        #region Parameter Ibm3624PinOffset_EncryptedPinBlock
        /// <summary>
        /// <para>
        /// <para>The encrypted PIN block data. According to ISO 9564 standard, a PIN Block is an encoded
        /// representation of a payment card Personal Account Number (PAN) and the cardholder
        /// Personal Identification Number (PIN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624PinOffset_EncryptedPinBlock")]
        public System.String Ibm3624PinOffset_EncryptedPinBlock { get; set; }
        #endregion
        
        #region Parameter VisaPinVerificationValue_EncryptedPinBlock
        /// <summary>
        /// <para>
        /// <para>The encrypted PIN block data to verify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_VisaPinVerificationValue_EncryptedPinBlock")]
        public System.String VisaPinVerificationValue_EncryptedPinBlock { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the PEK that Amazon Web Services Payment Cryptography uses to
        /// encrypt the PIN Block.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EncryptionKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter GenerationKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the PEK that Amazon Web Services Payment Cryptography uses for
        /// pin data generation.</para>
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
        public System.String GenerationKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter PinBlockFormat
        /// <summary>
        /// <para>
        /// <para>The PIN encoding format for pin data generation as specified in ISO 9564. Amazon Web
        /// Services Payment Cryptography supports <c>ISO_Format_0</c> and <c>ISO_Format_3</c>.</para><para>The <c>ISO_Format_0</c> PIN block format is equivalent to the ANSI X9.8, VISA-1, and
        /// ECI-1 PIN block formats. It is similar to a VISA-4 PIN block format. It supports a
        /// PIN from 4 to 12 digits in length.</para><para>The <c>ISO_Format_3</c> PIN block format is the same as <c>ISO_Format_0</c> except
        /// that the fill digits are random values from 10 to 15.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.PinBlockFormatForPinData")]
        public Amazon.PaymentCryptographyData.PinBlockFormatForPinData PinBlockFormat { get; set; }
        #endregion
        
        #region Parameter PinDataLength
        /// <summary>
        /// <para>
        /// <para>The length of PIN under generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PinDataLength { get; set; }
        #endregion
        
        #region Parameter Ibm3624PinFromOffset_PinOffset
        /// <summary>
        /// <para>
        /// <para>The PIN offset value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624PinFromOffset_PinOffset")]
        public System.String Ibm3624PinFromOffset_PinOffset { get; set; }
        #endregion
        
        #region Parameter Ibm3624NaturalPin_PinValidationData
        /// <summary>
        /// <para>
        /// <para>The unique data for cardholder identification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624NaturalPin_PinValidationData")]
        public System.String Ibm3624NaturalPin_PinValidationData { get; set; }
        #endregion
        
        #region Parameter Ibm3624PinFromOffset_PinValidationData
        /// <summary>
        /// <para>
        /// <para>The unique data for cardholder identification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624PinFromOffset_PinValidationData")]
        public System.String Ibm3624PinFromOffset_PinValidationData { get; set; }
        #endregion
        
        #region Parameter Ibm3624PinOffset_PinValidationData
        /// <summary>
        /// <para>
        /// <para>The unique data for cardholder identification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624PinOffset_PinValidationData")]
        public System.String Ibm3624PinOffset_PinValidationData { get; set; }
        #endregion
        
        #region Parameter Ibm3624RandomPin_PinValidationData
        /// <summary>
        /// <para>
        /// <para>The unique data for cardholder identification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624RandomPin_PinValidationData")]
        public System.String Ibm3624RandomPin_PinValidationData { get; set; }
        #endregion
        
        #region Parameter Ibm3624NaturalPin_PinValidationDataPadCharacter
        /// <summary>
        /// <para>
        /// <para>The padding character for validation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624NaturalPin_PinValidationDataPadCharacter")]
        public System.String Ibm3624NaturalPin_PinValidationDataPadCharacter { get; set; }
        #endregion
        
        #region Parameter Ibm3624PinFromOffset_PinValidationDataPadCharacter
        /// <summary>
        /// <para>
        /// <para>The padding character for validation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624PinFromOffset_PinValidationDataPadCharacter")]
        public System.String Ibm3624PinFromOffset_PinValidationDataPadCharacter { get; set; }
        #endregion
        
        #region Parameter Ibm3624PinOffset_PinValidationDataPadCharacter
        /// <summary>
        /// <para>
        /// <para>The padding character for validation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624PinOffset_PinValidationDataPadCharacter")]
        public System.String Ibm3624PinOffset_PinValidationDataPadCharacter { get; set; }
        #endregion
        
        #region Parameter Ibm3624RandomPin_PinValidationDataPadCharacter
        /// <summary>
        /// <para>
        /// <para>The padding character for validation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_Ibm3624RandomPin_PinValidationDataPadCharacter")]
        public System.String Ibm3624RandomPin_PinValidationDataPadCharacter { get; set; }
        #endregion
        
        #region Parameter VisaPin_PinVerificationKeyIndex
        /// <summary>
        /// <para>
        /// <para>The value for PIN verification index. It is used in the Visa PIN algorithm to calculate
        /// the PVV (PIN Verification Value).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_VisaPin_PinVerificationKeyIndex")]
        public System.Int32? VisaPin_PinVerificationKeyIndex { get; set; }
        #endregion
        
        #region Parameter VisaPinVerificationValue_PinVerificationKeyIndex
        /// <summary>
        /// <para>
        /// <para>The value for PIN verification index. It is used in the Visa PIN algorithm to calculate
        /// the PVV (PIN Verification Value).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_VisaPinVerificationValue_PinVerificationKeyIndex")]
        public System.Int32? VisaPinVerificationValue_PinVerificationKeyIndex { get; set; }
        #endregion
        
        #region Parameter PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN), a unique identifier for a payment credit or debit
        /// card that associates the card with a specific account holder.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PAYCDPinData (GeneratePinData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse, NewPAYCDPinDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EncryptionKeyIdentifier = this.EncryptionKeyIdentifier;
            #if MODULAR
            if (this.EncryptionKeyIdentifier == null && ParameterWasBound(nameof(this.EncryptionKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptionKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Ibm3624NaturalPin_DecimalizationTable = this.Ibm3624NaturalPin_DecimalizationTable;
            context.Ibm3624NaturalPin_PinValidationData = this.Ibm3624NaturalPin_PinValidationData;
            context.Ibm3624NaturalPin_PinValidationDataPadCharacter = this.Ibm3624NaturalPin_PinValidationDataPadCharacter;
            context.Ibm3624PinFromOffset_DecimalizationTable = this.Ibm3624PinFromOffset_DecimalizationTable;
            context.Ibm3624PinFromOffset_PinOffset = this.Ibm3624PinFromOffset_PinOffset;
            context.Ibm3624PinFromOffset_PinValidationData = this.Ibm3624PinFromOffset_PinValidationData;
            context.Ibm3624PinFromOffset_PinValidationDataPadCharacter = this.Ibm3624PinFromOffset_PinValidationDataPadCharacter;
            context.Ibm3624PinOffset_DecimalizationTable = this.Ibm3624PinOffset_DecimalizationTable;
            context.Ibm3624PinOffset_EncryptedPinBlock = this.Ibm3624PinOffset_EncryptedPinBlock;
            context.Ibm3624PinOffset_PinValidationData = this.Ibm3624PinOffset_PinValidationData;
            context.Ibm3624PinOffset_PinValidationDataPadCharacter = this.Ibm3624PinOffset_PinValidationDataPadCharacter;
            context.Ibm3624RandomPin_DecimalizationTable = this.Ibm3624RandomPin_DecimalizationTable;
            context.Ibm3624RandomPin_PinValidationData = this.Ibm3624RandomPin_PinValidationData;
            context.Ibm3624RandomPin_PinValidationDataPadCharacter = this.Ibm3624RandomPin_PinValidationDataPadCharacter;
            context.VisaPin_PinVerificationKeyIndex = this.VisaPin_PinVerificationKeyIndex;
            context.VisaPinVerificationValue_EncryptedPinBlock = this.VisaPinVerificationValue_EncryptedPinBlock;
            context.VisaPinVerificationValue_PinVerificationKeyIndex = this.VisaPinVerificationValue_PinVerificationKeyIndex;
            context.GenerationKeyIdentifier = this.GenerationKeyIdentifier;
            #if MODULAR
            if (this.GenerationKeyIdentifier == null && ParameterWasBound(nameof(this.GenerationKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GenerationKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PinBlockFormat = this.PinBlockFormat;
            #if MODULAR
            if (this.PinBlockFormat == null && ParameterWasBound(nameof(this.PinBlockFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter PinBlockFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PinDataLength = this.PinDataLength;
            context.PrimaryAccountNumber = this.PrimaryAccountNumber;
            #if MODULAR
            if (this.PrimaryAccountNumber == null && ParameterWasBound(nameof(this.PrimaryAccountNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryAccountNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.PaymentCryptographyData.Model.GeneratePinDataRequest();
            
            if (cmdletContext.EncryptionKeyIdentifier != null)
            {
                request.EncryptionKeyIdentifier = cmdletContext.EncryptionKeyIdentifier;
            }
            
             // populate GenerationAttributes
            var requestGenerationAttributesIsNull = true;
            request.GenerationAttributes = new Amazon.PaymentCryptographyData.Model.PinGenerationAttributes();
            Amazon.PaymentCryptographyData.Model.VisaPin requestGenerationAttributes_generationAttributes_VisaPin = null;
            
             // populate VisaPin
            var requestGenerationAttributes_generationAttributes_VisaPinIsNull = true;
            requestGenerationAttributes_generationAttributes_VisaPin = new Amazon.PaymentCryptographyData.Model.VisaPin();
            System.Int32? requestGenerationAttributes_generationAttributes_VisaPin_visaPin_PinVerificationKeyIndex = null;
            if (cmdletContext.VisaPin_PinVerificationKeyIndex != null)
            {
                requestGenerationAttributes_generationAttributes_VisaPin_visaPin_PinVerificationKeyIndex = cmdletContext.VisaPin_PinVerificationKeyIndex.Value;
            }
            if (requestGenerationAttributes_generationAttributes_VisaPin_visaPin_PinVerificationKeyIndex != null)
            {
                requestGenerationAttributes_generationAttributes_VisaPin.PinVerificationKeyIndex = requestGenerationAttributes_generationAttributes_VisaPin_visaPin_PinVerificationKeyIndex.Value;
                requestGenerationAttributes_generationAttributes_VisaPinIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_VisaPin should be set to null
            if (requestGenerationAttributes_generationAttributes_VisaPinIsNull)
            {
                requestGenerationAttributes_generationAttributes_VisaPin = null;
            }
            if (requestGenerationAttributes_generationAttributes_VisaPin != null)
            {
                request.GenerationAttributes.VisaPin = requestGenerationAttributes_generationAttributes_VisaPin;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.VisaPinVerificationValue requestGenerationAttributes_generationAttributes_VisaPinVerificationValue = null;
            
             // populate VisaPinVerificationValue
            var requestGenerationAttributes_generationAttributes_VisaPinVerificationValueIsNull = true;
            requestGenerationAttributes_generationAttributes_VisaPinVerificationValue = new Amazon.PaymentCryptographyData.Model.VisaPinVerificationValue();
            System.String requestGenerationAttributes_generationAttributes_VisaPinVerificationValue_visaPinVerificationValue_EncryptedPinBlock = null;
            if (cmdletContext.VisaPinVerificationValue_EncryptedPinBlock != null)
            {
                requestGenerationAttributes_generationAttributes_VisaPinVerificationValue_visaPinVerificationValue_EncryptedPinBlock = cmdletContext.VisaPinVerificationValue_EncryptedPinBlock;
            }
            if (requestGenerationAttributes_generationAttributes_VisaPinVerificationValue_visaPinVerificationValue_EncryptedPinBlock != null)
            {
                requestGenerationAttributes_generationAttributes_VisaPinVerificationValue.EncryptedPinBlock = requestGenerationAttributes_generationAttributes_VisaPinVerificationValue_visaPinVerificationValue_EncryptedPinBlock;
                requestGenerationAttributes_generationAttributes_VisaPinVerificationValueIsNull = false;
            }
            System.Int32? requestGenerationAttributes_generationAttributes_VisaPinVerificationValue_visaPinVerificationValue_PinVerificationKeyIndex = null;
            if (cmdletContext.VisaPinVerificationValue_PinVerificationKeyIndex != null)
            {
                requestGenerationAttributes_generationAttributes_VisaPinVerificationValue_visaPinVerificationValue_PinVerificationKeyIndex = cmdletContext.VisaPinVerificationValue_PinVerificationKeyIndex.Value;
            }
            if (requestGenerationAttributes_generationAttributes_VisaPinVerificationValue_visaPinVerificationValue_PinVerificationKeyIndex != null)
            {
                requestGenerationAttributes_generationAttributes_VisaPinVerificationValue.PinVerificationKeyIndex = requestGenerationAttributes_generationAttributes_VisaPinVerificationValue_visaPinVerificationValue_PinVerificationKeyIndex.Value;
                requestGenerationAttributes_generationAttributes_VisaPinVerificationValueIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_VisaPinVerificationValue should be set to null
            if (requestGenerationAttributes_generationAttributes_VisaPinVerificationValueIsNull)
            {
                requestGenerationAttributes_generationAttributes_VisaPinVerificationValue = null;
            }
            if (requestGenerationAttributes_generationAttributes_VisaPinVerificationValue != null)
            {
                request.GenerationAttributes.VisaPinVerificationValue = requestGenerationAttributes_generationAttributes_VisaPinVerificationValue;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.Ibm3624NaturalPin requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin = null;
            
             // populate Ibm3624NaturalPin
            var requestGenerationAttributes_generationAttributes_Ibm3624NaturalPinIsNull = true;
            requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin = new Amazon.PaymentCryptographyData.Model.Ibm3624NaturalPin();
            System.String requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_DecimalizationTable = null;
            if (cmdletContext.Ibm3624NaturalPin_DecimalizationTable != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_DecimalizationTable = cmdletContext.Ibm3624NaturalPin_DecimalizationTable;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_DecimalizationTable != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin.DecimalizationTable = requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_DecimalizationTable;
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPinIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_PinValidationData = null;
            if (cmdletContext.Ibm3624NaturalPin_PinValidationData != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_PinValidationData = cmdletContext.Ibm3624NaturalPin_PinValidationData;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_PinValidationData != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin.PinValidationData = requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_PinValidationData;
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPinIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_PinValidationDataPadCharacter = null;
            if (cmdletContext.Ibm3624NaturalPin_PinValidationDataPadCharacter != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_PinValidationDataPadCharacter = cmdletContext.Ibm3624NaturalPin_PinValidationDataPadCharacter;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_PinValidationDataPadCharacter != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin.PinValidationDataPadCharacter = requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin_ibm3624NaturalPin_PinValidationDataPadCharacter;
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPinIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin should be set to null
            if (requestGenerationAttributes_generationAttributes_Ibm3624NaturalPinIsNull)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin = null;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin != null)
            {
                request.GenerationAttributes.Ibm3624NaturalPin = requestGenerationAttributes_generationAttributes_Ibm3624NaturalPin;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.Ibm3624RandomPin requestGenerationAttributes_generationAttributes_Ibm3624RandomPin = null;
            
             // populate Ibm3624RandomPin
            var requestGenerationAttributes_generationAttributes_Ibm3624RandomPinIsNull = true;
            requestGenerationAttributes_generationAttributes_Ibm3624RandomPin = new Amazon.PaymentCryptographyData.Model.Ibm3624RandomPin();
            System.String requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_DecimalizationTable = null;
            if (cmdletContext.Ibm3624RandomPin_DecimalizationTable != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_DecimalizationTable = cmdletContext.Ibm3624RandomPin_DecimalizationTable;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_DecimalizationTable != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPin.DecimalizationTable = requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_DecimalizationTable;
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPinIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_PinValidationData = null;
            if (cmdletContext.Ibm3624RandomPin_PinValidationData != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_PinValidationData = cmdletContext.Ibm3624RandomPin_PinValidationData;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_PinValidationData != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPin.PinValidationData = requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_PinValidationData;
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPinIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_PinValidationDataPadCharacter = null;
            if (cmdletContext.Ibm3624RandomPin_PinValidationDataPadCharacter != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_PinValidationDataPadCharacter = cmdletContext.Ibm3624RandomPin_PinValidationDataPadCharacter;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_PinValidationDataPadCharacter != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPin.PinValidationDataPadCharacter = requestGenerationAttributes_generationAttributes_Ibm3624RandomPin_ibm3624RandomPin_PinValidationDataPadCharacter;
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPinIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_Ibm3624RandomPin should be set to null
            if (requestGenerationAttributes_generationAttributes_Ibm3624RandomPinIsNull)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624RandomPin = null;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624RandomPin != null)
            {
                request.GenerationAttributes.Ibm3624RandomPin = requestGenerationAttributes_generationAttributes_Ibm3624RandomPin;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.Ibm3624PinFromOffset requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset = null;
            
             // populate Ibm3624PinFromOffset
            var requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffsetIsNull = true;
            requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset = new Amazon.PaymentCryptographyData.Model.Ibm3624PinFromOffset();
            System.String requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_DecimalizationTable = null;
            if (cmdletContext.Ibm3624PinFromOffset_DecimalizationTable != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_DecimalizationTable = cmdletContext.Ibm3624PinFromOffset_DecimalizationTable;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_DecimalizationTable != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset.DecimalizationTable = requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_DecimalizationTable;
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffsetIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinOffset = null;
            if (cmdletContext.Ibm3624PinFromOffset_PinOffset != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinOffset = cmdletContext.Ibm3624PinFromOffset_PinOffset;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinOffset != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset.PinOffset = requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinOffset;
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffsetIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinValidationData = null;
            if (cmdletContext.Ibm3624PinFromOffset_PinValidationData != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinValidationData = cmdletContext.Ibm3624PinFromOffset_PinValidationData;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinValidationData != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset.PinValidationData = requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinValidationData;
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffsetIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinValidationDataPadCharacter = null;
            if (cmdletContext.Ibm3624PinFromOffset_PinValidationDataPadCharacter != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinValidationDataPadCharacter = cmdletContext.Ibm3624PinFromOffset_PinValidationDataPadCharacter;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinValidationDataPadCharacter != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset.PinValidationDataPadCharacter = requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset_ibm3624PinFromOffset_PinValidationDataPadCharacter;
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffsetIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset should be set to null
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffsetIsNull)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset = null;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset != null)
            {
                request.GenerationAttributes.Ibm3624PinFromOffset = requestGenerationAttributes_generationAttributes_Ibm3624PinFromOffset;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.Ibm3624PinOffset requestGenerationAttributes_generationAttributes_Ibm3624PinOffset = null;
            
             // populate Ibm3624PinOffset
            var requestGenerationAttributes_generationAttributes_Ibm3624PinOffsetIsNull = true;
            requestGenerationAttributes_generationAttributes_Ibm3624PinOffset = new Amazon.PaymentCryptographyData.Model.Ibm3624PinOffset();
            System.String requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_DecimalizationTable = null;
            if (cmdletContext.Ibm3624PinOffset_DecimalizationTable != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_DecimalizationTable = cmdletContext.Ibm3624PinOffset_DecimalizationTable;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_DecimalizationTable != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset.DecimalizationTable = requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_DecimalizationTable;
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffsetIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_EncryptedPinBlock = null;
            if (cmdletContext.Ibm3624PinOffset_EncryptedPinBlock != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_EncryptedPinBlock = cmdletContext.Ibm3624PinOffset_EncryptedPinBlock;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_EncryptedPinBlock != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset.EncryptedPinBlock = requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_EncryptedPinBlock;
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffsetIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_PinValidationData = null;
            if (cmdletContext.Ibm3624PinOffset_PinValidationData != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_PinValidationData = cmdletContext.Ibm3624PinOffset_PinValidationData;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_PinValidationData != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset.PinValidationData = requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_PinValidationData;
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffsetIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_PinValidationDataPadCharacter = null;
            if (cmdletContext.Ibm3624PinOffset_PinValidationDataPadCharacter != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_PinValidationDataPadCharacter = cmdletContext.Ibm3624PinOffset_PinValidationDataPadCharacter;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_PinValidationDataPadCharacter != null)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset.PinValidationDataPadCharacter = requestGenerationAttributes_generationAttributes_Ibm3624PinOffset_ibm3624PinOffset_PinValidationDataPadCharacter;
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffsetIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_Ibm3624PinOffset should be set to null
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinOffsetIsNull)
            {
                requestGenerationAttributes_generationAttributes_Ibm3624PinOffset = null;
            }
            if (requestGenerationAttributes_generationAttributes_Ibm3624PinOffset != null)
            {
                request.GenerationAttributes.Ibm3624PinOffset = requestGenerationAttributes_generationAttributes_Ibm3624PinOffset;
                requestGenerationAttributesIsNull = false;
            }
             // determine if request.GenerationAttributes should be set to null
            if (requestGenerationAttributesIsNull)
            {
                request.GenerationAttributes = null;
            }
            if (cmdletContext.GenerationKeyIdentifier != null)
            {
                request.GenerationKeyIdentifier = cmdletContext.GenerationKeyIdentifier;
            }
            if (cmdletContext.PinBlockFormat != null)
            {
                request.PinBlockFormat = cmdletContext.PinBlockFormat;
            }
            if (cmdletContext.PinDataLength != null)
            {
                request.PinDataLength = cmdletContext.PinDataLength.Value;
            }
            if (cmdletContext.PrimaryAccountNumber != null)
            {
                request.PrimaryAccountNumber = cmdletContext.PrimaryAccountNumber;
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
        
        private Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.GeneratePinDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "GeneratePinData");
            try
            {
                #if DESKTOP
                return client.GeneratePinData(request);
                #elif CORECLR
                return client.GeneratePinDataAsync(request).GetAwaiter().GetResult();
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
            public System.String EncryptionKeyIdentifier { get; set; }
            public System.String Ibm3624NaturalPin_DecimalizationTable { get; set; }
            public System.String Ibm3624NaturalPin_PinValidationData { get; set; }
            public System.String Ibm3624NaturalPin_PinValidationDataPadCharacter { get; set; }
            public System.String Ibm3624PinFromOffset_DecimalizationTable { get; set; }
            public System.String Ibm3624PinFromOffset_PinOffset { get; set; }
            public System.String Ibm3624PinFromOffset_PinValidationData { get; set; }
            public System.String Ibm3624PinFromOffset_PinValidationDataPadCharacter { get; set; }
            public System.String Ibm3624PinOffset_DecimalizationTable { get; set; }
            public System.String Ibm3624PinOffset_EncryptedPinBlock { get; set; }
            public System.String Ibm3624PinOffset_PinValidationData { get; set; }
            public System.String Ibm3624PinOffset_PinValidationDataPadCharacter { get; set; }
            public System.String Ibm3624RandomPin_DecimalizationTable { get; set; }
            public System.String Ibm3624RandomPin_PinValidationData { get; set; }
            public System.String Ibm3624RandomPin_PinValidationDataPadCharacter { get; set; }
            public System.Int32? VisaPin_PinVerificationKeyIndex { get; set; }
            public System.String VisaPinVerificationValue_EncryptedPinBlock { get; set; }
            public System.Int32? VisaPinVerificationValue_PinVerificationKeyIndex { get; set; }
            public System.String GenerationKeyIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.PinBlockFormatForPinData PinBlockFormat { get; set; }
            public System.Int32? PinDataLength { get; set; }
            public System.String PrimaryAccountNumber { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.GeneratePinDataResponse, NewPAYCDPinDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
