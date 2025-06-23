/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates or updates a scaling policy for an Auto Scaling group. Scaling policies are
    /// used to scale an Auto Scaling group based on configurable metrics. If no policies
    /// are defined, the dynamic scaling and predictive scaling features are not used. 
    /// 
    ///  
    /// <para>
    /// For more information about using dynamic scaling, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scaling-target-tracking.html">Target
    /// tracking scaling policies</a> and <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scaling-simple-step.html">Step
    /// and simple scaling policies</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// For more information about using predictive scaling, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-predictive-scaling.html">Predictive
    /// scaling for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// You can view the scaling policies for an Auto Scaling group using the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_DescribePolicies.html">DescribePolicies</a>
    /// API call. If you are no longer using a scaling policy, you can delete it by calling
    /// the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_DeletePolicy.html">DeletePolicy</a>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AutoScaling.Model.PutScalingPolicyResponse")]
    [AWSCmdlet("Calls the AWS Auto Scaling PutScalingPolicy API operation.", Operation = new[] {"PutScalingPolicy"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.PutScalingPolicyResponse))]
    [AWSCmdletOutput("Amazon.AutoScaling.Model.PutScalingPolicyResponse",
        "This cmdlet returns an Amazon.AutoScaling.Model.PutScalingPolicyResponse object containing multiple properties."
    )]
    public partial class WriteASScalingPolicyCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdjustmentType
        /// <summary>
        /// <para>
        /// <para>Specifies how the scaling adjustment is interpreted (for example, an absolute number
        /// or a percentage). The valid values are <c>ChangeInCapacity</c>, <c>ExactCapacity</c>,
        /// and <c>PercentChangeInCapacity</c>.</para><para>Required if the policy type is <c>StepScaling</c> or <c>SimpleScaling</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scaling-simple-step.html#as-scaling-adjustment">Scaling
        /// adjustment types</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdjustmentType { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
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
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter Cooldown
        /// <summary>
        /// <para>
        /// <para>A cooldown period, in seconds, that applies to a specific simple scaling policy. When
        /// a cooldown period is specified here, it overrides the default cooldown.</para><para>Valid only if the policy type is <c>SimpleScaling</c>. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-scaling-cooldowns.html">Scaling
        /// cooldowns for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Cooldown { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions of the metric.</para><para>Conditional: If you published your metric with dimensions, you must specify the same
        /// dimensions in your scaling policy.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Dimensions")]
        public Amazon.AutoScaling.Model.MetricDimension[] CustomizedMetricSpecification_Dimension { get; set; }
        #endregion
        
        #region Parameter TargetTrackingConfiguration_DisableScaleIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether scaling in by the target tracking scaling policy is disabled. If
        /// scaling in is disabled, the target tracking scaling policy doesn't remove instances
        /// from the Auto Scaling group. Otherwise, the target tracking scaling policy can remove
        /// instances from the Auto Scaling group. The default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TargetTrackingConfiguration_DisableScaleIn { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the scaling policy is enabled or disabled. The default is enabled.
        /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-enable-disable-scaling-policy.html">Disable
        /// a scaling policy for an Auto Scaling group</a> in the <i>Amazon EC2 Auto Scaling User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EstimatedInstanceWarmup
        /// <summary>
        /// <para>
        /// <para><i>Not needed if the default instance warmup is defined for the group.</i></para><para>The estimated time, in seconds, until a newly launched instance can contribute to
        /// the CloudWatch metrics. This warm-up period applies to instances launched due to a
        /// specific target tracking or step scaling policy. When a warm-up period is specified
        /// here, it overrides the default instance warmup.</para><para>Valid only if the policy type is <c>TargetTrackingScaling</c> or <c>StepScaling</c>.</para><note><para>The default is to use the value for the default instance warmup defined for the group.
        /// If default instance warmup is null, then <c>EstimatedInstanceWarmup</c> falls back
        /// to the value of default cooldown.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EstimatedInstanceWarmup { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingConfiguration_MaxCapacityBreachBehavior
        /// <summary>
        /// <para>
        /// <para>Defines the behavior that should be applied if the forecast capacity approaches or
        /// exceeds the maximum capacity of the Auto Scaling group. Defaults to <c>HonorMaxCapacity</c>
        /// if not specified.</para><para>The following are possible values:</para><ul><li><para><c>HonorMaxCapacity</c> - Amazon EC2 Auto Scaling can't increase the maximum capacity
        /// of the group when the forecast capacity is close to or exceeds the maximum capacity.</para></li><li><para><c>IncreaseMaxCapacity</c> - Amazon EC2 Auto Scaling can increase the maximum capacity
        /// of the group when the forecast capacity is close to or exceeds the maximum capacity.
        /// The upper limit is determined by the forecasted capacity and the value for <c>MaxCapacityBuffer</c>.</para></li></ul><important><para>Use caution when allowing the maximum capacity to be automatically increased. This
        /// can lead to more instances being launched than intended if the increased maximum capacity
        /// is not monitored and managed. The increased maximum capacity then becomes the new
        /// normal maximum capacity for the Auto Scaling group until you manually update it. The
        /// maximum capacity does not automatically decrease back to the original maximum.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.PredictiveScalingMaxCapacityBreachBehavior")]
        public Amazon.AutoScaling.PredictiveScalingMaxCapacityBreachBehavior PredictiveScalingConfiguration_MaxCapacityBreachBehavior { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingConfiguration_MaxCapacityBuffer
        /// <summary>
        /// <para>
        /// <para>The size of the capacity buffer to use when the forecast capacity is close to or exceeds
        /// the maximum capacity. The value is specified as a percentage relative to the forecast
        /// capacity. For example, if the buffer is 10, this means a 10 percent buffer, such that
        /// if the forecast capacity is 50, and the maximum capacity is 40, then the effective
        /// maximum capacity is 55.</para><para>If set to 0, Amazon EC2 Auto Scaling may scale capacity higher than the maximum capacity
        /// to equal but not exceed forecast capacity. </para><para>Required if the <c>MaxCapacityBreachBehavior</c> property is set to <c>IncreaseMaxCapacity</c>,
        /// and cannot be used otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PredictiveScalingConfiguration_MaxCapacityBuffer { get; set; }
        #endregion
        
        #region Parameter MetricAggregationType
        /// <summary>
        /// <para>
        /// <para>The aggregation type for the CloudWatch metrics. The valid values are <c>Minimum</c>,
        /// <c>Maximum</c>, and <c>Average</c>. If the aggregation type is null, the value is
        /// treated as <c>Average</c>.</para><para>Valid only if the policy type is <c>StepScaling</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricAggregationType { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric. To get the exact metric name, namespace, and dimensions, inspect
        /// the <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_Metric.html">Metric</a>
        /// object that is returned by a call to <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_ListMetrics.html">ListMetrics</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_MetricName")]
        public System.String CustomizedMetricSpecification_MetricName { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Metric
        /// <summary>
        /// <para>
        /// <para>The metrics to include in the target tracking scaling policy, as a metric data query.
        /// This can include both raw metric and metric math expressions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Metrics")]
        public Amazon.AutoScaling.Model.TargetTrackingMetricDataQuery[] CustomizedMetricSpecification_Metric { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingConfiguration_MetricSpecification
        /// <summary>
        /// <para>
        /// <para>This structure includes the metrics and target utilization to use for predictive scaling.
        /// </para><para>This is an array, but we currently only support a single metric specification. That
        /// is, you can specify a target value and a single metric pair, or a target value and
        /// one scaling metric and one load metric.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PredictiveScalingConfiguration_MetricSpecifications")]
        public Amazon.AutoScaling.Model.PredictiveScalingMetricSpecification[] PredictiveScalingConfiguration_MetricSpecification { get; set; }
        #endregion
        
        #region Parameter MinAdjustmentMagnitude
        /// <summary>
        /// <para>
        /// <para>The minimum value to scale by when the adjustment type is <c>PercentChangeInCapacity</c>.
        /// For example, suppose that you create a step scaling policy to scale out an Auto Scaling
        /// group by 25 percent and you specify a <c>MinAdjustmentMagnitude</c> of 2. If the group
        /// has 4 instances and the scaling policy is performed, 25 percent of 4 is 1. However,
        /// because you specified a <c>MinAdjustmentMagnitude</c> of 2, Amazon EC2 Auto Scaling
        /// scales out the group by 2 instances.</para><para>Valid only if the policy type is <c>StepScaling</c> or <c>SimpleScaling</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scaling-simple-step.html#as-scaling-adjustment">Scaling
        /// adjustment types</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para><note><para>Some Auto Scaling groups use instance weights. In this case, set the <c>MinAdjustmentMagnitude</c>
        /// to a value that is at least as large as your largest instance weight.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinAdjustmentMagnitude { get; set; }
        #endregion
        
        #region Parameter MinAdjustmentStep
        /// <summary>
        /// <para>
        /// <para>Available for backward compatibility. Use <c>MinAdjustmentMagnitude</c> instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinAdjustmentStep { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingConfiguration_Mode
        /// <summary>
        /// <para>
        /// <para>The predictive scaling mode. Defaults to <c>ForecastOnly</c> if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.PredictiveScalingMode")]
        public Amazon.AutoScaling.PredictiveScalingMode PredictiveScalingConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Namespace")]
        public System.String CustomizedMetricSpecification_Namespace { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Period
        /// <summary>
        /// <para>
        /// <para> The period of the metric in seconds. The default value is 60. Accepted values are
        /// 10, 30, and 60. For high resolution metric, set the value to less than 60. For more
        /// information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/policy-creating-high-resolution-metrics.html">Create
        /// a target tracking policy using high-resolution metrics for faster response</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Period")]
        public System.Int32? CustomizedMetricSpecification_Period { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>One of the following policy types: </para><ul><li><para><c>TargetTrackingScaling</c></para></li><li><para><c>StepScaling</c></para></li><li><para><c>SimpleScaling</c> (default)</para></li><li><para><c>PredictiveScaling</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyType { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_PredefinedMetricType
        /// <summary>
        /// <para>
        /// <para>The metric type. The following predefined metrics are available:</para><ul><li><para><c>ASGAverageCPUUtilization</c> - Average CPU utilization of the Auto Scaling group.</para></li><li><para><c>ASGAverageNetworkIn</c> - Average number of bytes received on all network interfaces
        /// by the Auto Scaling group.</para></li><li><para><c>ASGAverageNetworkOut</c> - Average number of bytes sent out on all network interfaces
        /// by the Auto Scaling group.</para></li><li><para><c>ALBRequestCountPerTarget</c> - Average Application Load Balancer request count
        /// per target for your Auto Scaling group.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType")]
        [AWSConstantClassSource("Amazon.AutoScaling.MetricType")]
        public Amazon.AutoScaling.MetricType PredefinedMetricSpecification_PredefinedMetricType { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_ResourceLabel
        /// <summary>
        /// <para>
        /// <para>A label that uniquely identifies a specific Application Load Balancer target group
        /// from which to determine the average request count served by your Auto Scaling group.
        /// You can't specify a resource label unless the target group is attached to the Auto
        /// Scaling group.</para><para>You create the resource label by appending the final portion of the load balancer
        /// ARN and the final portion of the target group ARN into a single value, separated by
        /// a forward slash (/). The format of the resource label is:</para><para><c>app/my-alb/778d41231b141a0f/targetgroup/my-alb-target-group/943f017f100becff</c>.</para><para>Where:</para><ul><li><para>app/&lt;load-balancer-name&gt;/&lt;load-balancer-id&gt; is the final portion of the
        /// load balancer ARN</para></li><li><para>targetgroup/&lt;target-group-name&gt;/&lt;target-group-id&gt; is the final portion
        /// of the target group ARN.</para></li></ul><para>To find the ARN for an Application Load Balancer, use the <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/APIReference/API_DescribeLoadBalancers.html">DescribeLoadBalancers</a>
        /// API operation. To find the ARN for the target group, use the <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/APIReference/API_DescribeTargetGroups.html">DescribeTargetGroups</a>
        /// API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_PredefinedMetricSpecification_ResourceLabel")]
        public System.String PredefinedMetricSpecification_ResourceLabel { get; set; }
        #endregion
        
        #region Parameter ScalingAdjustment
        /// <summary>
        /// <para>
        /// <para>The amount by which to scale, based on the specified adjustment type. A positive value
        /// adds to the current capacity while a negative number removes from the current capacity.
        /// For exact capacity, you must specify a non-negative value.</para><para>Required if the policy type is <c>SimpleScaling</c>. (Not used with any other policy
        /// type.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingAdjustment { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingConfiguration_SchedulingBufferTime
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, by which the instance launch time can be advanced.
        /// For example, the forecast says to add capacity at 10:00 AM, and you choose to pre-launch
        /// instances by 5 minutes. In that case, the instances will be launched at 9:55 AM. The
        /// intention is to give resources time to be provisioned. It can take a few minutes to
        /// launch an EC2 instance. The actual amount of time required depends on several factors,
        /// such as the size of the instance and whether there are startup scripts to complete.
        /// </para><para>The value must be less than the forecast interval duration of 3600 seconds (60 minutes).
        /// Defaults to 300 seconds if not specified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PredictiveScalingConfiguration_SchedulingBufferTime { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic")]
        [AWSConstantClassSource("Amazon.AutoScaling.MetricStatistic")]
        public Amazon.AutoScaling.MetricStatistic CustomizedMetricSpecification_Statistic { get; set; }
        #endregion
        
        #region Parameter StepAdjustment
        /// <summary>
        /// <para>
        /// <para>A set of adjustments that enable you to scale based on the size of the alarm breach.</para><para>Required if the policy type is <c>StepScaling</c>. (Not used with any other policy
        /// type.) </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StepAdjustments")]
        public Amazon.AutoScaling.Model.StepAdjustment[] StepAdjustment { get; set; }
        #endregion
        
        #region Parameter TargetTrackingConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>The target value for the metric.</para><note><para>Some metrics are based on a count instead of a percentage, such as the request count
        /// for an Application Load Balancer or the number of messages in an SQS queue. If the
        /// scaling policy specifies one of these metrics, specify the target utilization as the
        /// optimal average request or message count per instance during any one-minute interval.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? TargetTrackingConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of the metric. For a complete list of the units that CloudWatch supports,
        /// see the <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_MetricDatum.html">MetricDatum</a>
        /// data type in the <i>Amazon CloudWatch API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Unit")]
        public System.String CustomizedMetricSpecification_Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.PutScalingPolicyResponse).
        /// Specifying the name of a property of type Amazon.AutoScaling.Model.PutScalingPolicyResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASScalingPolicy (PutScalingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.PutScalingPolicyResponse, WriteASScalingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdjustmentType = this.AdjustmentType;
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Cooldown = this.Cooldown;
            context.Enabled = this.Enabled;
            context.EstimatedInstanceWarmup = this.EstimatedInstanceWarmup;
            context.MetricAggregationType = this.MetricAggregationType;
            context.MinAdjustmentMagnitude = this.MinAdjustmentMagnitude;
            context.MinAdjustmentStep = this.MinAdjustmentStep;
            context.PolicyName = this.PolicyName;
            #if MODULAR
            if (this.PolicyName == null && ParameterWasBound(nameof(this.PolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyType = this.PolicyType;
            context.PredictiveScalingConfiguration_MaxCapacityBreachBehavior = this.PredictiveScalingConfiguration_MaxCapacityBreachBehavior;
            context.PredictiveScalingConfiguration_MaxCapacityBuffer = this.PredictiveScalingConfiguration_MaxCapacityBuffer;
            if (this.PredictiveScalingConfiguration_MetricSpecification != null)
            {
                context.PredictiveScalingConfiguration_MetricSpecification = new List<Amazon.AutoScaling.Model.PredictiveScalingMetricSpecification>(this.PredictiveScalingConfiguration_MetricSpecification);
            }
            context.PredictiveScalingConfiguration_Mode = this.PredictiveScalingConfiguration_Mode;
            context.PredictiveScalingConfiguration_SchedulingBufferTime = this.PredictiveScalingConfiguration_SchedulingBufferTime;
            context.ScalingAdjustment = this.ScalingAdjustment;
            if (this.StepAdjustment != null)
            {
                context.StepAdjustment = new List<Amazon.AutoScaling.Model.StepAdjustment>(this.StepAdjustment);
            }
            if (this.CustomizedMetricSpecification_Dimension != null)
            {
                context.CustomizedMetricSpecification_Dimension = new List<Amazon.AutoScaling.Model.MetricDimension>(this.CustomizedMetricSpecification_Dimension);
            }
            context.CustomizedMetricSpecification_MetricName = this.CustomizedMetricSpecification_MetricName;
            if (this.CustomizedMetricSpecification_Metric != null)
            {
                context.CustomizedMetricSpecification_Metric = new List<Amazon.AutoScaling.Model.TargetTrackingMetricDataQuery>(this.CustomizedMetricSpecification_Metric);
            }
            context.CustomizedMetricSpecification_Namespace = this.CustomizedMetricSpecification_Namespace;
            context.CustomizedMetricSpecification_Period = this.CustomizedMetricSpecification_Period;
            context.CustomizedMetricSpecification_Statistic = this.CustomizedMetricSpecification_Statistic;
            context.CustomizedMetricSpecification_Unit = this.CustomizedMetricSpecification_Unit;
            context.TargetTrackingConfiguration_DisableScaleIn = this.TargetTrackingConfiguration_DisableScaleIn;
            context.PredefinedMetricSpecification_PredefinedMetricType = this.PredefinedMetricSpecification_PredefinedMetricType;
            context.PredefinedMetricSpecification_ResourceLabel = this.PredefinedMetricSpecification_ResourceLabel;
            context.TargetTrackingConfiguration_TargetValue = this.TargetTrackingConfiguration_TargetValue;
            
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
            var request = new Amazon.AutoScaling.Model.PutScalingPolicyRequest();
            
            if (cmdletContext.AdjustmentType != null)
            {
                request.AdjustmentType = cmdletContext.AdjustmentType;
            }
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.Cooldown != null)
            {
                request.Cooldown = cmdletContext.Cooldown.Value;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EstimatedInstanceWarmup != null)
            {
                request.EstimatedInstanceWarmup = cmdletContext.EstimatedInstanceWarmup.Value;
            }
            if (cmdletContext.MetricAggregationType != null)
            {
                request.MetricAggregationType = cmdletContext.MetricAggregationType;
            }
            if (cmdletContext.MinAdjustmentMagnitude != null)
            {
                request.MinAdjustmentMagnitude = cmdletContext.MinAdjustmentMagnitude.Value;
            }
            if (cmdletContext.MinAdjustmentStep != null)
            {
                request.MinAdjustmentStep = cmdletContext.MinAdjustmentStep.Value;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            
             // populate PredictiveScalingConfiguration
            var requestPredictiveScalingConfigurationIsNull = true;
            request.PredictiveScalingConfiguration = new Amazon.AutoScaling.Model.PredictiveScalingConfiguration();
            Amazon.AutoScaling.PredictiveScalingMaxCapacityBreachBehavior requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MaxCapacityBreachBehavior = null;
            if (cmdletContext.PredictiveScalingConfiguration_MaxCapacityBreachBehavior != null)
            {
                requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MaxCapacityBreachBehavior = cmdletContext.PredictiveScalingConfiguration_MaxCapacityBreachBehavior;
            }
            if (requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MaxCapacityBreachBehavior != null)
            {
                request.PredictiveScalingConfiguration.MaxCapacityBreachBehavior = requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MaxCapacityBreachBehavior;
                requestPredictiveScalingConfigurationIsNull = false;
            }
            System.Int32? requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MaxCapacityBuffer = null;
            if (cmdletContext.PredictiveScalingConfiguration_MaxCapacityBuffer != null)
            {
                requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MaxCapacityBuffer = cmdletContext.PredictiveScalingConfiguration_MaxCapacityBuffer.Value;
            }
            if (requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MaxCapacityBuffer != null)
            {
                request.PredictiveScalingConfiguration.MaxCapacityBuffer = requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MaxCapacityBuffer.Value;
                requestPredictiveScalingConfigurationIsNull = false;
            }
            List<Amazon.AutoScaling.Model.PredictiveScalingMetricSpecification> requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MetricSpecification = null;
            if (cmdletContext.PredictiveScalingConfiguration_MetricSpecification != null)
            {
                requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MetricSpecification = cmdletContext.PredictiveScalingConfiguration_MetricSpecification;
            }
            if (requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MetricSpecification != null)
            {
                request.PredictiveScalingConfiguration.MetricSpecifications = requestPredictiveScalingConfiguration_predictiveScalingConfiguration_MetricSpecification;
                requestPredictiveScalingConfigurationIsNull = false;
            }
            Amazon.AutoScaling.PredictiveScalingMode requestPredictiveScalingConfiguration_predictiveScalingConfiguration_Mode = null;
            if (cmdletContext.PredictiveScalingConfiguration_Mode != null)
            {
                requestPredictiveScalingConfiguration_predictiveScalingConfiguration_Mode = cmdletContext.PredictiveScalingConfiguration_Mode;
            }
            if (requestPredictiveScalingConfiguration_predictiveScalingConfiguration_Mode != null)
            {
                request.PredictiveScalingConfiguration.Mode = requestPredictiveScalingConfiguration_predictiveScalingConfiguration_Mode;
                requestPredictiveScalingConfigurationIsNull = false;
            }
            System.Int32? requestPredictiveScalingConfiguration_predictiveScalingConfiguration_SchedulingBufferTime = null;
            if (cmdletContext.PredictiveScalingConfiguration_SchedulingBufferTime != null)
            {
                requestPredictiveScalingConfiguration_predictiveScalingConfiguration_SchedulingBufferTime = cmdletContext.PredictiveScalingConfiguration_SchedulingBufferTime.Value;
            }
            if (requestPredictiveScalingConfiguration_predictiveScalingConfiguration_SchedulingBufferTime != null)
            {
                request.PredictiveScalingConfiguration.SchedulingBufferTime = requestPredictiveScalingConfiguration_predictiveScalingConfiguration_SchedulingBufferTime.Value;
                requestPredictiveScalingConfigurationIsNull = false;
            }
             // determine if request.PredictiveScalingConfiguration should be set to null
            if (requestPredictiveScalingConfigurationIsNull)
            {
                request.PredictiveScalingConfiguration = null;
            }
            if (cmdletContext.ScalingAdjustment != null)
            {
                request.ScalingAdjustment = cmdletContext.ScalingAdjustment.Value;
            }
            if (cmdletContext.StepAdjustment != null)
            {
                request.StepAdjustments = cmdletContext.StepAdjustment;
            }
            
             // populate TargetTrackingConfiguration
            var requestTargetTrackingConfigurationIsNull = true;
            request.TargetTrackingConfiguration = new Amazon.AutoScaling.Model.TargetTrackingConfiguration();
            System.Boolean? requestTargetTrackingConfiguration_targetTrackingConfiguration_DisableScaleIn = null;
            if (cmdletContext.TargetTrackingConfiguration_DisableScaleIn != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_DisableScaleIn = cmdletContext.TargetTrackingConfiguration_DisableScaleIn.Value;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_DisableScaleIn != null)
            {
                request.TargetTrackingConfiguration.DisableScaleIn = requestTargetTrackingConfiguration_targetTrackingConfiguration_DisableScaleIn.Value;
                requestTargetTrackingConfigurationIsNull = false;
            }
            System.Double? requestTargetTrackingConfiguration_targetTrackingConfiguration_TargetValue = null;
            if (cmdletContext.TargetTrackingConfiguration_TargetValue != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_TargetValue = cmdletContext.TargetTrackingConfiguration_TargetValue.Value;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_TargetValue != null)
            {
                request.TargetTrackingConfiguration.TargetValue = requestTargetTrackingConfiguration_targetTrackingConfiguration_TargetValue.Value;
                requestTargetTrackingConfigurationIsNull = false;
            }
            Amazon.AutoScaling.Model.PredefinedMetricSpecification requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification = null;
            
             // populate PredefinedMetricSpecification
            var requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull = true;
            requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification = new Amazon.AutoScaling.Model.PredefinedMetricSpecification();
            Amazon.AutoScaling.MetricType requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = null;
            if (cmdletContext.PredefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = cmdletContext.PredefinedMetricSpecification_PredefinedMetricType;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification.PredefinedMetricType = requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = null;
            if (cmdletContext.PredefinedMetricSpecification_ResourceLabel != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = cmdletContext.PredefinedMetricSpecification_ResourceLabel;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification.ResourceLabel = requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull = false;
            }
             // determine if requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification should be set to null
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification = null;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification != null)
            {
                request.TargetTrackingConfiguration.PredefinedMetricSpecification = requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification;
                requestTargetTrackingConfigurationIsNull = false;
            }
            Amazon.AutoScaling.Model.CustomizedMetricSpecification requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification = null;
            
             // populate CustomizedMetricSpecification
            var requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = true;
            requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification = new Amazon.AutoScaling.Model.CustomizedMetricSpecification();
            List<Amazon.AutoScaling.Model.MetricDimension> requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = null;
            if (cmdletContext.CustomizedMetricSpecification_Dimension != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = cmdletContext.CustomizedMetricSpecification_Dimension;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Dimensions = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = null;
            if (cmdletContext.CustomizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = cmdletContext.CustomizedMetricSpecification_MetricName;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.MetricName = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            List<Amazon.AutoScaling.Model.TargetTrackingMetricDataQuery> requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Metric = null;
            if (cmdletContext.CustomizedMetricSpecification_Metric != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Metric = cmdletContext.CustomizedMetricSpecification_Metric;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Metric != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Metrics = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Metric;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = null;
            if (cmdletContext.CustomizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = cmdletContext.CustomizedMetricSpecification_Namespace;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Namespace = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.Int32? requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Period = null;
            if (cmdletContext.CustomizedMetricSpecification_Period != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Period = cmdletContext.CustomizedMetricSpecification_Period.Value;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Period != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Period = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Period.Value;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            Amazon.AutoScaling.MetricStatistic requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = null;
            if (cmdletContext.CustomizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = cmdletContext.CustomizedMetricSpecification_Statistic;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Statistic = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = null;
            if (cmdletContext.CustomizedMetricSpecification_Unit != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = cmdletContext.CustomizedMetricSpecification_Unit;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Unit = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
             // determine if requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification should be set to null
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification = null;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification != null)
            {
                request.TargetTrackingConfiguration.CustomizedMetricSpecification = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification;
                requestTargetTrackingConfigurationIsNull = false;
            }
             // determine if request.TargetTrackingConfiguration should be set to null
            if (requestTargetTrackingConfigurationIsNull)
            {
                request.TargetTrackingConfiguration = null;
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
        
        private Amazon.AutoScaling.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "PutScalingPolicy");
            try
            {
                return client.PutScalingPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AdjustmentType { get; set; }
            public System.String AutoScalingGroupName { get; set; }
            public System.Int32? Cooldown { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.Int32? EstimatedInstanceWarmup { get; set; }
            public System.String MetricAggregationType { get; set; }
            public System.Int32? MinAdjustmentMagnitude { get; set; }
            public System.Int32? MinAdjustmentStep { get; set; }
            public System.String PolicyName { get; set; }
            public System.String PolicyType { get; set; }
            public Amazon.AutoScaling.PredictiveScalingMaxCapacityBreachBehavior PredictiveScalingConfiguration_MaxCapacityBreachBehavior { get; set; }
            public System.Int32? PredictiveScalingConfiguration_MaxCapacityBuffer { get; set; }
            public List<Amazon.AutoScaling.Model.PredictiveScalingMetricSpecification> PredictiveScalingConfiguration_MetricSpecification { get; set; }
            public Amazon.AutoScaling.PredictiveScalingMode PredictiveScalingConfiguration_Mode { get; set; }
            public System.Int32? PredictiveScalingConfiguration_SchedulingBufferTime { get; set; }
            public System.Int32? ScalingAdjustment { get; set; }
            public List<Amazon.AutoScaling.Model.StepAdjustment> StepAdjustment { get; set; }
            public List<Amazon.AutoScaling.Model.MetricDimension> CustomizedMetricSpecification_Dimension { get; set; }
            public System.String CustomizedMetricSpecification_MetricName { get; set; }
            public List<Amazon.AutoScaling.Model.TargetTrackingMetricDataQuery> CustomizedMetricSpecification_Metric { get; set; }
            public System.String CustomizedMetricSpecification_Namespace { get; set; }
            public System.Int32? CustomizedMetricSpecification_Period { get; set; }
            public Amazon.AutoScaling.MetricStatistic CustomizedMetricSpecification_Statistic { get; set; }
            public System.String CustomizedMetricSpecification_Unit { get; set; }
            public System.Boolean? TargetTrackingConfiguration_DisableScaleIn { get; set; }
            public Amazon.AutoScaling.MetricType PredefinedMetricSpecification_PredefinedMetricType { get; set; }
            public System.String PredefinedMetricSpecification_ResourceLabel { get; set; }
            public System.Double? TargetTrackingConfiguration_TargetValue { get; set; }
            public System.Func<Amazon.AutoScaling.Model.PutScalingPolicyResponse, WriteASScalingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
