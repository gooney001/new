﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowItems
{
    public class ApprovedFailedWrokflowStep : StepBody
    {
        //public ApprovalFlow approval { get; set; }
        //public int ApprovalId { get; set; }
        public ApprovalMessage approvalMessage { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            //Console.WriteLine(approval.UserId + "已审批，审批状态：" + approval.State + "；审批意见：" + approval.Reason + "；内容：" + approval.ApprovalMessage.Message);
            Console.WriteLine(approvalMessage.Id + "已审批，审批状态：" + approvalMessage.State + "；审批意见：" + approvalMessage.ApprovalFlow?.Reason + "；内容：" + approvalMessage.Message);
            return ExecutionResult.Next();
        }
    }
}
