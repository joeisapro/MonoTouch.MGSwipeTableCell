using System;
using ObjCRuntime;

[assembly: LinkWith ("libMGSwipeCell.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, Frameworks = "QuartzCore", SmartLink = true, ForceLoad = true)]
