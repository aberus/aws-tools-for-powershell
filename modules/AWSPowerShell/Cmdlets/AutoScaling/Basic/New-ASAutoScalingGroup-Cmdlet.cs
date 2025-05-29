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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// <b>We strongly recommend using a launch template when calling this operation to ensure
    /// full functionality for Amazon EC2 Auto Scaling and Amazon EC2.</b><para>
    /// Creates an Auto Scaling group with the specified name and attributes. 
    /// </para><para>
    /// If you exceed your maximum limit of Auto Scaling groups, the call fails. To query
    /// this limit, call the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_DescribeAccountLimits.html">DescribeAccountLimits</a>
    /// API. For information about updating this limit, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-quotas.html">Quotas
    /// for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// If you're new to Amazon EC2 Auto Scaling, see the introductory tutorials in <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/get-started-with-ec2-auto-scaling.html">Get
    /// started with Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// Every Auto Scaling group has three size properties (<c>DesiredCapacity</c>, <c>MaxSize</c>,
    /// and <c>MinSize</c>). Usually, you set these sizes based on a specific number of instances.
    /// However, if you configure a mixed instances policy that defines weights for the instance
    /// types, you must specify these sizes with the same units that you use for weighting
    /// instances.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ASAutoScalingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling CreateAutoScalingGroup API operation.", Operation = new[] {"CreateAutoScalingGroup"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewASAutoScalingGroupCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group. This name must be unique per Region per account.</para><para>The name can contain any ASCII character 33 to 126 including most punctuation characters,
        /// digits, and upper and lowercased letters.</para><note><para>You cannot use a colon (:) in the name.</para></note>
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
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A list of Availability Zones where instances in the Auto Scaling group can be created.
        /// Used for launching into the default VPC subnet in each Availability Zone when not
        /// using the <c>VPCZoneIdentifier</c> property, or for attaching a network interface
        /// when an existing network interface ID is specified in a launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneDistribution_CapacityDistributionStrategy
        /// <summary>
        /// <para>
        /// <para> If launches fail in an Availability Zone, the following strategies are available.
        /// The default is <c>balanced-best-effort</c>. </para><ul><li><para><c>balanced-only</c> - If launches fail in an Availability Zone, Auto Scaling will
        /// continue to attempt to launch in the unhealthy zone to preserve a balanced distribution.</para></li><li><para><c>balanced-best-effort</c> - If launches fail in an Availability Zone, Auto Scaling
        /// will attempt to launch in another healthy Availability Zone instead.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.CapacityDistributionStrategy")]
        public Amazon.AutoScaling.CapacityDistributionStrategy AvailabilityZoneDistribution_CapacityDistributionStrategy { get; set; }
        #endregion
        
        #region Parameter CapacityRebalance
        /// <summary>
        /// <para>
        /// <para>Indicates whether Capacity Rebalancing is enabled. Otherwise, Capacity Rebalancing
        /// is disabled. When you turn on Capacity Rebalancing, Amazon EC2 Auto Scaling attempts
        /// to launch a Spot Instance whenever Amazon EC2 notifies that a Spot Instance is at
        /// an elevated risk of interruption. After launching a new instance, it then terminates
        /// an old instance. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-capacity-rebalancing.html">Use
        /// Capacity Rebalancing to handle Amazon EC2 Spot Interruptions</a> in the in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CapacityRebalance { get; set; }
        #endregion
        
        #region Parameter CapacityReservationTarget_CapacityReservationId
        /// <summary>
        /// <para>
        /// <para> The Capacity Reservation IDs to launch instances into. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationIds")]
        public System.String[] CapacityReservationTarget_CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter CapacityReservationSpecification_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para> The capacity reservation preference. The following options are available: </para><ul><li><para><c>capacity-reservations-only</c> - Auto Scaling will only launch instances into
        /// a Capacity Reservation or Capacity Reservation resource group. If capacity isn't available,
        /// instances will fail to launch.</para></li><li><para><c>capacity-reservations-first</c> - Auto Scaling will try to launch instances into
        /// a Capacity Reservation or Capacity Reservation resource group first. If capacity isn't
        /// available, instances will run in On-Demand capacity.</para></li><li><para><c>none</c> - Auto Scaling will not launch instances into a Capacity Reservation.
        /// Instances will run in On-Demand capacity. </para></li><li><para><c>default</c> - Auto Scaling uses the Capacity Reservation preference from your
        /// launch template or an open Capacity Reservation.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.CapacityReservationPreference")]
        public Amazon.AutoScaling.CapacityReservationPreference CapacityReservationSpecification_CapacityReservationPreference { get; set; }
        #endregion
        
        #region Parameter CapacityReservationTarget_CapacityReservationResourceGroupArn
        /// <summary>
        /// <para>
        /// <para> The resource group ARNs of the Capacity Reservation to launch instances into. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArns")]
        public System.String[] CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context { get; set; }
        #endregion
        
        #region Parameter DefaultCooldown
        /// <summary>
        /// <para>
        /// <para><i>Only needed if you use simple scaling policies.</i></para><para>The amount of time, in seconds, between one scaling activity ending and another one
        /// starting due to simple scaling policies. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-scaling-cooldowns.html">Scaling
        /// cooldowns for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para><para>Default: <c>300</c> seconds</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultCooldown { get; set; }
        #endregion
        
        #region Parameter DefaultInstanceWarmup
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, until a new instance is considered to have finished
        /// initializing and resource consumption to become stable after it enters the <c>InService</c>
        /// state. </para><para>During an instance refresh, Amazon EC2 Auto Scaling waits for the warm-up period after
        /// it replaces an instance before it moves on to replacing the next instance. Amazon
        /// EC2 Auto Scaling also waits for the warm-up period before aggregating the metrics
        /// for new instances with existing instances in the Amazon CloudWatch metrics that are
        /// used for scaling, resulting in more reliable usage data. For more information, see
        /// <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-default-instance-warmup.html">Set
        /// the default instance warmup for an Auto Scaling group</a> in the <i>Amazon EC2 Auto
        /// Scaling User Guide</i>.</para><important><para>To manage various warm-up settings at the group level, we recommend that you set the
        /// default instance warmup, <i>even if it is set to 0 seconds</i>. To remove a value
        /// that you previously set, include the property but specify <c>-1</c> for the value.
        /// However, we strongly recommend keeping the default instance warmup enabled by specifying
        /// a value of <c>0</c> or other nominal value.</para></important><para>Default: None </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultInstanceWarmup { get; set; }
        #endregion
        
        #region Parameter DesiredCapacity
        /// <summary>
        /// <para>
        /// <para>The desired capacity is the initial capacity of the Auto Scaling group at the time
        /// of its creation and the capacity it attempts to maintain. It can scale beyond this
        /// capacity if you configure auto scaling. This number must be greater than or equal
        /// to the minimum size of the group and less than or equal to the maximum size of the
        /// group. If you do not specify a desired capacity, the default is the minimum size of
        /// the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DesiredCapacity { get; set; }
        #endregion
        
        #region Parameter DesiredCapacityType
        /// <summary>
        /// <para>
        /// <para>The unit of measurement for the value specified for desired capacity. Amazon EC2 Auto
        /// Scaling supports <c>DesiredCapacityType</c> for attribute-based instance type selection
        /// only. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/create-mixed-instances-group-attribute-based-instance-type-selection.html">Create
        /// a mixed instances group using attribute-based instance type selection</a> in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para><para>By default, Amazon EC2 Auto Scaling specifies <c>units</c>, which translates into
        /// number of instances.</para><para>Valid values: <c>units</c> | <c>vcpu</c> | <c>memory-mib</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DesiredCapacityType { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriod
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that Amazon EC2 Auto Scaling waits before checking
        /// the health status of an EC2 instance that has come into service and marking it unhealthy
        /// due to a failed health check. This is useful if your instances do not immediately
        /// pass their health checks after they enter the <c>InService</c> state. For more information,
        /// see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/health-check-grace-period.html">Set
        /// the health check grace period for an Auto Scaling group</a> in the <i>Amazon EC2 Auto
        /// Scaling User Guide</i>.</para><para>Default: <c>0</c> seconds</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckGracePeriod { get; set; }
        #endregion
        
        #region Parameter HealthCheckType
        /// <summary>
        /// <para>
        /// <para>A comma-separated value string of one or more health check types.</para><para>The valid values are <c>EC2</c>, <c>EBS</c>, <c>ELB</c>, and <c>VPC_LATTICE</c>. <c>EC2</c>
        /// is the default health check and cannot be disabled. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-health-checks.html">Health
        /// checks for instances in an Auto Scaling group</a> in the <i>Amazon EC2 Auto Scaling
        /// User Guide</i>.</para><para>Only specify <c>EC2</c> if you must clear a value that was previously set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckType { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior
        /// <summary>
        /// <para>
        /// <para> Specifies the health check behavior for the impaired Availability Zone in an active
        /// zonal shift. If you select <c>Replace unhealthy</c>, instances that appear unhealthy
        /// will be replaced in all Availability Zones. If you select <c>Ignore unhealthy</c>,
        /// instances will not be replaced in the Availability Zone with the active zonal shift.
        /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-zonal-shift.html">Auto
        /// Scaling group zonal shift</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.ImpairedZoneHealthCheckBehavior")]
        public Amazon.AutoScaling.ImpairedZoneHealthCheckBehavior AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance used to base the launch configuration on. If specified, Amazon
        /// EC2 Auto Scaling uses the configuration values from the specified instance to create
        /// a new launch configuration. To get the instance ID, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeInstances.html">DescribeInstances</a>
        /// API operation. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/create-asg-from-instance.html">Create
        /// an Auto Scaling group using parameters from an existing instance</a> in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter LaunchConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the launch configuration to use to launch instances. </para><para>Conditional: You must specify either a launch template (<c>LaunchTemplate</c> or <c>MixedInstancesPolicy</c>)
        /// or a launch configuration (<c>LaunchConfigurationName</c> or <c>InstanceId</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String LaunchConfigurationName { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template. To get the template ID, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplates.html">DescribeLaunchTemplates</a>
        /// API operation. New launch templates can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplate.html">CreateLaunchTemplate</a>
        /// API. </para><para>Conditional: You must specify either a <c>LaunchTemplateId</c> or a <c>LaunchTemplateName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template. To get the template name, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplates.html">DescribeLaunchTemplates</a>
        /// API operation. New launch templates can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplate.html">CreateLaunchTemplate</a>
        /// API. </para><para>Conditional: You must specify either a <c>LaunchTemplateId</c> or a <c>LaunchTemplateName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter LifecycleHookSpecificationList
        /// <summary>
        /// <para>
        /// <para>One or more lifecycle hooks to add to the Auto Scaling group before instances are
        /// launched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AutoScaling.Model.LifecycleHookSpecification[] LifecycleHookSpecificationList { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>A list of Classic Load Balancers associated with this Auto Scaling group. For Application
        /// Load Balancers, Network Load Balancers, and Gateway Load Balancers, specify the <c>TargetGroupARNs</c>
        /// property instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancerNames")]
        public System.String[] LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter InstanceMaintenancePolicy_MaxHealthyPercentage
        /// <summary>
        /// <para>
        /// <para>Specifies the upper threshold as a percentage of the desired capacity of the Auto
        /// Scaling group. It represents the maximum percentage of the group that can be in service
        /// and healthy, or pending, to support your workload when replacing instances. Value
        /// range is 100 to 200. To clear a previously set value, specify a value of <c>-1</c>.</para><para>Both <c>MinHealthyPercentage</c> and <c>MaxHealthyPercentage</c> must be specified,
        /// and the difference between them cannot be greater than 100. A large range increases
        /// the number of instances that can be replaced at the same time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceMaintenancePolicy_MaxHealthyPercentage { get; set; }
        #endregion
        
        #region Parameter MaxInstanceLifetime
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that an instance can be in service. The default
        /// is null. If specified, the value must be either 0 or a number equal to or greater
        /// than 86,400 seconds (1 day). For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-max-instance-lifetime.html">Replace
        /// Auto Scaling instances based on maximum instance lifetime</a> in the <i>Amazon EC2
        /// Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxInstanceLifetime { get; set; }
        #endregion
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum size of the group.</para><note><para>With a mixed instances policy that uses instance weighting, Amazon EC2 Auto Scaling
        /// may need to go above <c>MaxSize</c> to meet your capacity requirements. In this event,
        /// Amazon EC2 Auto Scaling will never go above <c>MaxSize</c> by more than your largest
        /// instance weight (weights that define how many units each instance contributes to the
        /// desired capacity of the group).</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MaxSize { get; set; }
        #endregion
        
        #region Parameter InstanceMaintenancePolicy_MinHealthyPercentage
        /// <summary>
        /// <para>
        /// <para>Specifies the lower threshold as a percentage of the desired capacity of the Auto
        /// Scaling group. It represents the minimum percentage of the group to keep in service,
        /// healthy, and ready to use to support your workload when replacing instances. Value
        /// range is 0 to 100. To clear a previously set value, specify a value of <c>-1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceMaintenancePolicy_MinHealthyPercentage { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum size of the group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MinSize { get; set; }
        #endregion
        
        #region Parameter MixedInstancesPolicy
        /// <summary>
        /// <para>
        /// <para>The mixed instances policy. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-mixed-instances-groups.html">Auto
        /// Scaling groups with multiple instance types and purchase options</a> in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AutoScaling.Model.MixedInstancesPolicy MixedInstancesPolicy { get; set; }
        #endregion
        
        #region Parameter NewInstancesProtectedFromScaleIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether newly launched instances are protected from termination by Amazon
        /// EC2 Auto Scaling when scaling in. For more information about preventing instances
        /// from terminating on scale in, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-instance-protection.html">Use
        /// instance scale-in protection</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NewInstancesProtectedFromScaleIn { get; set; }
        #endregion
        
        #region Parameter PlacementGroup
        /// <summary>
        /// <para>
        /// <para>The name of the placement group into which to launch your instances. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">Placement
        /// groups</a> in the <i>Amazon EC2 User Guide</i>.</para><note><para>A <i>cluster</i> placement group is a logical grouping of instances within a single
        /// Availability Zone. You cannot specify multiple Availability Zones and a cluster placement
        /// group. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlacementGroup { get; set; }
        #endregion
        
        #region Parameter ServiceLinkedRoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service-linked role that the Auto Scaling group
        /// uses to call other Amazon Web Services service on your behalf. By default, Amazon
        /// EC2 Auto Scaling uses a service-linked role named <c>AWSServiceRoleForAutoScaling</c>,
        /// which it creates if it does not exist. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/autoscaling-service-linked-role.html">Service-linked
        /// roles</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceLinkedRoleARN { get; set; }
        #endregion
        
        #region Parameter SkipZonalShiftValidation
        /// <summary>
        /// <para>
        /// <para> If you enable zonal shift with cross-zone disabled load balancers, capacity could
        /// become imbalanced across Availability Zones. To skip the validation, specify <c>true</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-zonal-shift.html">Auto
        /// Scaling group zonal shift</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipZonalShiftValidation { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags. You can tag your Auto Scaling group and propagate the tags to the
        /// Amazon EC2 instances it launches. Tags are not propagated to Amazon EBS volumes. To
        /// add tags to Amazon EBS volumes, specify the tags in a launch template but use caution.
        /// If the launch template specifies an instance tag with a key that is also specified
        /// for the Auto Scaling group, Amazon EC2 Auto Scaling overrides the value of that instance
        /// tag with the value specified by the Auto Scaling group. For more information, see
        /// <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-tagging.html">Tag
        /// Auto Scaling groups and instances</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AutoScaling.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetGroupARNs
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARN) of the Elastic Load Balancing target groups to associate
        /// with the Auto Scaling group. Instances are registered as targets with the target groups.
        /// The target groups receive incoming traffic and route requests to one or more registered
        /// targets. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/autoscaling-load-balancer.html">Use
        /// Elastic Load Balancing to distribute traffic across the instances in your Auto Scaling
        /// group</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TargetGroupARNs { get; set; }
        #endregion
        
        #region Parameter TerminationPolicy
        /// <summary>
        /// <para>
        /// <para>A policy or a list of policies that are used to select the instance to terminate.
        /// These policies are executed in the order that you list them. For more information,
        /// see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-termination-policies.html">Configure
        /// termination policies for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling
        /// User Guide</i>.</para><para>Valid values: <c>Default</c> | <c>AllocationStrategy</c> | <c>ClosestToNextInstanceHour</c>
        /// | <c>NewestInstance</c> | <c>OldestInstance</c> | <c>OldestLaunchConfiguration</c>
        /// | <c>OldestLaunchTemplate</c> | <c>arn:aws:lambda:region:account-id:function:my-function:my-alias</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TerminationPolicies")]
        public System.String[] TerminationPolicy { get; set; }
        #endregion
        
        #region Parameter TrafficSource
        /// <summary>
        /// <para>
        /// <para>The list of traffic sources to attach to this Auto Scaling group. You can use any
        /// of the following as traffic sources for an Auto Scaling group: Classic Load Balancer,
        /// Application Load Balancer, Gateway Load Balancer, Network Load Balancer, and VPC Lattice.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrafficSources")]
        public Amazon.AutoScaling.Model.TrafficSourceIdentifier[] TrafficSource { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number, <c>$Latest</c>, or <c>$Default</c>. To get the version number,
        /// use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplateVersions.html">DescribeLaunchTemplateVersions</a>
        /// API operation. New launch template versions can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplateVersion.html">CreateLaunchTemplateVersion</a>
        /// API. If the value is <c>$Latest</c>, Amazon EC2 Auto Scaling selects the latest version
        /// of the launch template when launching instances. If the value is <c>$Default</c>,
        /// Amazon EC2 Auto Scaling selects the default version of the launch template when launching
        /// instances. The default value is <c>$Default</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter VPCZoneIdentifier
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of subnet IDs for a virtual private cloud (VPC) where instances
        /// in the Auto Scaling group can be created. If you specify <c>VPCZoneIdentifier</c>
        /// with <c>AvailabilityZones</c>, the subnets that you specify must reside in those Availability
        /// Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VPCZoneIdentifier { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled
        /// <summary>
        /// <para>
        /// <para> If <c>true</c>, enable zonal shift for your Auto Scaling group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoScalingGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASAutoScalingGroup (CreateAutoScalingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse, NewASAutoScalingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoScalingGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AvailabilityZoneDistribution_CapacityDistributionStrategy = this.AvailabilityZoneDistribution_CapacityDistributionStrategy;
            context.AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior = this.AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior;
            context.AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled = this.AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled;
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
            context.CapacityRebalance = this.CapacityRebalance;
            context.CapacityReservationSpecification_CapacityReservationPreference = this.CapacityReservationSpecification_CapacityReservationPreference;
            if (this.CapacityReservationTarget_CapacityReservationId != null)
            {
                context.CapacityReservationTarget_CapacityReservationId = new List<System.String>(this.CapacityReservationTarget_CapacityReservationId);
            }
            if (this.CapacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                context.CapacityReservationTarget_CapacityReservationResourceGroupArn = new List<System.String>(this.CapacityReservationTarget_CapacityReservationResourceGroupArn);
            }
            context.Context = this.Context;
            context.DefaultCooldown = this.DefaultCooldown;
            context.DefaultInstanceWarmup = this.DefaultInstanceWarmup;
            context.DesiredCapacity = this.DesiredCapacity;
            context.DesiredCapacityType = this.DesiredCapacityType;
            context.HealthCheckGracePeriod = this.HealthCheckGracePeriod;
            context.HealthCheckType = this.HealthCheckType;
            context.InstanceId = this.InstanceId;
            context.InstanceMaintenancePolicy_MaxHealthyPercentage = this.InstanceMaintenancePolicy_MaxHealthyPercentage;
            context.InstanceMaintenancePolicy_MinHealthyPercentage = this.InstanceMaintenancePolicy_MinHealthyPercentage;
            context.LaunchConfigurationName = this.LaunchConfigurationName;
            context.LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            if (this.LifecycleHookSpecificationList != null)
            {
                context.LifecycleHookSpecificationList = new List<Amazon.AutoScaling.Model.LifecycleHookSpecification>(this.LifecycleHookSpecificationList);
            }
            if (this.LoadBalancerName != null)
            {
                context.LoadBalancerName = new List<System.String>(this.LoadBalancerName);
            }
            context.MaxInstanceLifetime = this.MaxInstanceLifetime;
            context.MaxSize = this.MaxSize;
            #if MODULAR
            if (this.MaxSize == null && ParameterWasBound(nameof(this.MaxSize)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxSize which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinSize = this.MinSize;
            #if MODULAR
            if (this.MinSize == null && ParameterWasBound(nameof(this.MinSize)))
            {
                WriteWarning("You are passing $null as a value for parameter MinSize which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MixedInstancesPolicy = this.MixedInstancesPolicy;
            context.NewInstancesProtectedFromScaleIn = this.NewInstancesProtectedFromScaleIn;
            context.PlacementGroup = this.PlacementGroup;
            context.ServiceLinkedRoleARN = this.ServiceLinkedRoleARN;
            context.SkipZonalShiftValidation = this.SkipZonalShiftValidation;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AutoScaling.Model.Tag>(this.Tag);
            }
            if (this.TargetGroupARNs != null)
            {
                context.TargetGroupARNs = new List<System.String>(this.TargetGroupARNs);
            }
            if (this.TerminationPolicy != null)
            {
                context.TerminationPolicy = new List<System.String>(this.TerminationPolicy);
            }
            if (this.TrafficSource != null)
            {
                context.TrafficSource = new List<Amazon.AutoScaling.Model.TrafficSourceIdentifier>(this.TrafficSource);
            }
            context.VPCZoneIdentifier = this.VPCZoneIdentifier;
            
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
            var request = new Amazon.AutoScaling.Model.CreateAutoScalingGroupRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            
             // populate AvailabilityZoneDistribution
            var requestAvailabilityZoneDistributionIsNull = true;
            request.AvailabilityZoneDistribution = new Amazon.AutoScaling.Model.AvailabilityZoneDistribution();
            Amazon.AutoScaling.CapacityDistributionStrategy requestAvailabilityZoneDistribution_availabilityZoneDistribution_CapacityDistributionStrategy = null;
            if (cmdletContext.AvailabilityZoneDistribution_CapacityDistributionStrategy != null)
            {
                requestAvailabilityZoneDistribution_availabilityZoneDistribution_CapacityDistributionStrategy = cmdletContext.AvailabilityZoneDistribution_CapacityDistributionStrategy;
            }
            if (requestAvailabilityZoneDistribution_availabilityZoneDistribution_CapacityDistributionStrategy != null)
            {
                request.AvailabilityZoneDistribution.CapacityDistributionStrategy = requestAvailabilityZoneDistribution_availabilityZoneDistribution_CapacityDistributionStrategy;
                requestAvailabilityZoneDistributionIsNull = false;
            }
             // determine if request.AvailabilityZoneDistribution should be set to null
            if (requestAvailabilityZoneDistributionIsNull)
            {
                request.AvailabilityZoneDistribution = null;
            }
            
             // populate AvailabilityZoneImpairmentPolicy
            var requestAvailabilityZoneImpairmentPolicyIsNull = true;
            request.AvailabilityZoneImpairmentPolicy = new Amazon.AutoScaling.Model.AvailabilityZoneImpairmentPolicy();
            Amazon.AutoScaling.ImpairedZoneHealthCheckBehavior requestAvailabilityZoneImpairmentPolicy_availabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior = null;
            if (cmdletContext.AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior != null)
            {
                requestAvailabilityZoneImpairmentPolicy_availabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior = cmdletContext.AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior;
            }
            if (requestAvailabilityZoneImpairmentPolicy_availabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior != null)
            {
                request.AvailabilityZoneImpairmentPolicy.ImpairedZoneHealthCheckBehavior = requestAvailabilityZoneImpairmentPolicy_availabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior;
                requestAvailabilityZoneImpairmentPolicyIsNull = false;
            }
            System.Boolean? requestAvailabilityZoneImpairmentPolicy_availabilityZoneImpairmentPolicy_ZonalShiftEnabled = null;
            if (cmdletContext.AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled != null)
            {
                requestAvailabilityZoneImpairmentPolicy_availabilityZoneImpairmentPolicy_ZonalShiftEnabled = cmdletContext.AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled.Value;
            }
            if (requestAvailabilityZoneImpairmentPolicy_availabilityZoneImpairmentPolicy_ZonalShiftEnabled != null)
            {
                request.AvailabilityZoneImpairmentPolicy.ZonalShiftEnabled = requestAvailabilityZoneImpairmentPolicy_availabilityZoneImpairmentPolicy_ZonalShiftEnabled.Value;
                requestAvailabilityZoneImpairmentPolicyIsNull = false;
            }
             // determine if request.AvailabilityZoneImpairmentPolicy should be set to null
            if (requestAvailabilityZoneImpairmentPolicyIsNull)
            {
                request.AvailabilityZoneImpairmentPolicy = null;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.CapacityRebalance != null)
            {
                request.CapacityRebalance = cmdletContext.CapacityRebalance.Value;
            }
            
             // populate CapacityReservationSpecification
            var requestCapacityReservationSpecificationIsNull = true;
            request.CapacityReservationSpecification = new Amazon.AutoScaling.Model.CapacityReservationSpecification();
            Amazon.AutoScaling.CapacityReservationPreference requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = null;
            if (cmdletContext.CapacityReservationSpecification_CapacityReservationPreference != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = cmdletContext.CapacityReservationSpecification_CapacityReservationPreference;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference != null)
            {
                request.CapacityReservationSpecification.CapacityReservationPreference = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference;
                requestCapacityReservationSpecificationIsNull = false;
            }
            Amazon.AutoScaling.Model.CapacityReservationTarget requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = null;
            
             // populate CapacityReservationTarget
            var requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = true;
            requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = new Amazon.AutoScaling.Model.CapacityReservationTarget();
            List<System.String> requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = null;
            if (cmdletContext.CapacityReservationTarget_CapacityReservationId != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = cmdletContext.CapacityReservationTarget_CapacityReservationId;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget.CapacityReservationIds = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId;
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
            List<System.String> requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn = null;
            if (cmdletContext.CapacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn = cmdletContext.CapacityReservationTarget_CapacityReservationResourceGroupArn;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget.CapacityReservationResourceGroupArns = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn;
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
             // determine if requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget should be set to null
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = null;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget != null)
            {
                request.CapacityReservationSpecification.CapacityReservationTarget = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget;
                requestCapacityReservationSpecificationIsNull = false;
            }
             // determine if request.CapacityReservationSpecification should be set to null
            if (requestCapacityReservationSpecificationIsNull)
            {
                request.CapacityReservationSpecification = null;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.DefaultCooldown != null)
            {
                request.DefaultCooldown = cmdletContext.DefaultCooldown.Value;
            }
            if (cmdletContext.DefaultInstanceWarmup != null)
            {
                request.DefaultInstanceWarmup = cmdletContext.DefaultInstanceWarmup.Value;
            }
            if (cmdletContext.DesiredCapacity != null)
            {
                request.DesiredCapacity = cmdletContext.DesiredCapacity.Value;
            }
            if (cmdletContext.DesiredCapacityType != null)
            {
                request.DesiredCapacityType = cmdletContext.DesiredCapacityType;
            }
            if (cmdletContext.HealthCheckGracePeriod != null)
            {
                request.HealthCheckGracePeriod = cmdletContext.HealthCheckGracePeriod.Value;
            }
            if (cmdletContext.HealthCheckType != null)
            {
                request.HealthCheckType = cmdletContext.HealthCheckType;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate InstanceMaintenancePolicy
            var requestInstanceMaintenancePolicyIsNull = true;
            request.InstanceMaintenancePolicy = new Amazon.AutoScaling.Model.InstanceMaintenancePolicy();
            System.Int32? requestInstanceMaintenancePolicy_instanceMaintenancePolicy_MaxHealthyPercentage = null;
            if (cmdletContext.InstanceMaintenancePolicy_MaxHealthyPercentage != null)
            {
                requestInstanceMaintenancePolicy_instanceMaintenancePolicy_MaxHealthyPercentage = cmdletContext.InstanceMaintenancePolicy_MaxHealthyPercentage.Value;
            }
            if (requestInstanceMaintenancePolicy_instanceMaintenancePolicy_MaxHealthyPercentage != null)
            {
                request.InstanceMaintenancePolicy.MaxHealthyPercentage = requestInstanceMaintenancePolicy_instanceMaintenancePolicy_MaxHealthyPercentage.Value;
                requestInstanceMaintenancePolicyIsNull = false;
            }
            System.Int32? requestInstanceMaintenancePolicy_instanceMaintenancePolicy_MinHealthyPercentage = null;
            if (cmdletContext.InstanceMaintenancePolicy_MinHealthyPercentage != null)
            {
                requestInstanceMaintenancePolicy_instanceMaintenancePolicy_MinHealthyPercentage = cmdletContext.InstanceMaintenancePolicy_MinHealthyPercentage.Value;
            }
            if (requestInstanceMaintenancePolicy_instanceMaintenancePolicy_MinHealthyPercentage != null)
            {
                request.InstanceMaintenancePolicy.MinHealthyPercentage = requestInstanceMaintenancePolicy_instanceMaintenancePolicy_MinHealthyPercentage.Value;
                requestInstanceMaintenancePolicyIsNull = false;
            }
             // determine if request.InstanceMaintenancePolicy should be set to null
            if (requestInstanceMaintenancePolicyIsNull)
            {
                request.InstanceMaintenancePolicy = null;
            }
            if (cmdletContext.LaunchConfigurationName != null)
            {
                request.LaunchConfigurationName = cmdletContext.LaunchConfigurationName;
            }
            
             // populate LaunchTemplate
            var requestLaunchTemplateIsNull = true;
            request.LaunchTemplate = new Amazon.AutoScaling.Model.LaunchTemplateSpecification();
            System.String requestLaunchTemplate_launchTemplate_LaunchTemplateId = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateId != null)
            {
                requestLaunchTemplate_launchTemplate_LaunchTemplateId = cmdletContext.LaunchTemplate_LaunchTemplateId;
            }
            if (requestLaunchTemplate_launchTemplate_LaunchTemplateId != null)
            {
                request.LaunchTemplate.LaunchTemplateId = requestLaunchTemplate_launchTemplate_LaunchTemplateId;
                requestLaunchTemplateIsNull = false;
            }
            System.String requestLaunchTemplate_launchTemplate_LaunchTemplateName = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateName != null)
            {
                requestLaunchTemplate_launchTemplate_LaunchTemplateName = cmdletContext.LaunchTemplate_LaunchTemplateName;
            }
            if (requestLaunchTemplate_launchTemplate_LaunchTemplateName != null)
            {
                request.LaunchTemplate.LaunchTemplateName = requestLaunchTemplate_launchTemplate_LaunchTemplateName;
                requestLaunchTemplateIsNull = false;
            }
            System.String requestLaunchTemplate_launchTemplate_Version = null;
            if (cmdletContext.LaunchTemplate_Version != null)
            {
                requestLaunchTemplate_launchTemplate_Version = cmdletContext.LaunchTemplate_Version;
            }
            if (requestLaunchTemplate_launchTemplate_Version != null)
            {
                request.LaunchTemplate.Version = requestLaunchTemplate_launchTemplate_Version;
                requestLaunchTemplateIsNull = false;
            }
             // determine if request.LaunchTemplate should be set to null
            if (requestLaunchTemplateIsNull)
            {
                request.LaunchTemplate = null;
            }
            if (cmdletContext.LifecycleHookSpecificationList != null)
            {
                request.LifecycleHookSpecificationList = cmdletContext.LifecycleHookSpecificationList;
            }
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerNames = cmdletContext.LoadBalancerName;
            }
            if (cmdletContext.MaxInstanceLifetime != null)
            {
                request.MaxInstanceLifetime = cmdletContext.MaxInstanceLifetime.Value;
            }
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
            }
            if (cmdletContext.MixedInstancesPolicy != null)
            {
                request.MixedInstancesPolicy = cmdletContext.MixedInstancesPolicy;
            }
            if (cmdletContext.NewInstancesProtectedFromScaleIn != null)
            {
                request.NewInstancesProtectedFromScaleIn = cmdletContext.NewInstancesProtectedFromScaleIn.Value;
            }
            if (cmdletContext.PlacementGroup != null)
            {
                request.PlacementGroup = cmdletContext.PlacementGroup;
            }
            if (cmdletContext.ServiceLinkedRoleARN != null)
            {
                request.ServiceLinkedRoleARN = cmdletContext.ServiceLinkedRoleARN;
            }
            if (cmdletContext.SkipZonalShiftValidation != null)
            {
                request.SkipZonalShiftValidation = cmdletContext.SkipZonalShiftValidation.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetGroupARNs != null)
            {
                request.TargetGroupARNs = cmdletContext.TargetGroupARNs;
            }
            if (cmdletContext.TerminationPolicy != null)
            {
                request.TerminationPolicies = cmdletContext.TerminationPolicy;
            }
            if (cmdletContext.TrafficSource != null)
            {
                request.TrafficSources = cmdletContext.TrafficSource;
            }
            if (cmdletContext.VPCZoneIdentifier != null)
            {
                request.VPCZoneIdentifier = cmdletContext.VPCZoneIdentifier;
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
        
        private Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.CreateAutoScalingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "CreateAutoScalingGroup");
            try
            {
                #if DESKTOP
                return client.CreateAutoScalingGroup(request);
                #elif CORECLR
                return client.CreateAutoScalingGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupName { get; set; }
            public Amazon.AutoScaling.CapacityDistributionStrategy AvailabilityZoneDistribution_CapacityDistributionStrategy { get; set; }
            public Amazon.AutoScaling.ImpairedZoneHealthCheckBehavior AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior { get; set; }
            public System.Boolean? AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled { get; set; }
            public List<System.String> AvailabilityZone { get; set; }
            public System.Boolean? CapacityRebalance { get; set; }
            public Amazon.AutoScaling.CapacityReservationPreference CapacityReservationSpecification_CapacityReservationPreference { get; set; }
            public List<System.String> CapacityReservationTarget_CapacityReservationId { get; set; }
            public List<System.String> CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
            public System.String Context { get; set; }
            public System.Int32? DefaultCooldown { get; set; }
            public System.Int32? DefaultInstanceWarmup { get; set; }
            public System.Int32? DesiredCapacity { get; set; }
            public System.String DesiredCapacityType { get; set; }
            public System.Int32? HealthCheckGracePeriod { get; set; }
            public System.String HealthCheckType { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? InstanceMaintenancePolicy_MaxHealthyPercentage { get; set; }
            public System.Int32? InstanceMaintenancePolicy_MinHealthyPercentage { get; set; }
            public System.String LaunchConfigurationName { get; set; }
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public List<Amazon.AutoScaling.Model.LifecycleHookSpecification> LifecycleHookSpecificationList { get; set; }
            public List<System.String> LoadBalancerName { get; set; }
            public System.Int32? MaxInstanceLifetime { get; set; }
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public Amazon.AutoScaling.Model.MixedInstancesPolicy MixedInstancesPolicy { get; set; }
            public System.Boolean? NewInstancesProtectedFromScaleIn { get; set; }
            public System.String PlacementGroup { get; set; }
            public System.String ServiceLinkedRoleARN { get; set; }
            public System.Boolean? SkipZonalShiftValidation { get; set; }
            public List<Amazon.AutoScaling.Model.Tag> Tag { get; set; }
            public List<System.String> TargetGroupARNs { get; set; }
            public List<System.String> TerminationPolicy { get; set; }
            public List<Amazon.AutoScaling.Model.TrafficSourceIdentifier> TrafficSource { get; set; }
            public System.String VPCZoneIdentifier { get; set; }
            public System.Func<Amazon.AutoScaling.Model.CreateAutoScalingGroupResponse, NewASAutoScalingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
