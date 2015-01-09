using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMerge.Util
{
    public class UpgradeObject
    {
        public string TableName;
        public string[] UpdateColumns;
    }
    public class UpgradeObjects
    {
        public List<UpgradeObject> List = new List<UpgradeObject>();
        public UpgradeObjects()
        {
            List.Add(new UpgradeObject() { TableName = "AdvancedProperty", UpdateColumns = new string[] { "Id", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "AdvancedPropertyValue", UpdateColumns = new string[] { "Id", "PropertyId" } });
            List.Add(new UpgradeObject() { TableName = "AreaDimension", UpdateColumns = new string[] { "Id", "HierarchyId", "ParentId" } });
            List.Add(new UpgradeObject() { TableName = "Benchmark", UpdateColumns = new string[] { "SpId" } });
            List.Add(new UpgradeObject() { TableName = "BuildingCoverWidgetRelation", UpdateColumns = new string[] { "Id", "UserId", "CustomerId", "HierarchyId", "DashboardId", "WidgetId" } });
            List.Add(new UpgradeObject() { TableName = "BuildingLocation", UpdateColumns = new string[] { "BuildingId", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "BuildingPicture", UpdateColumns = new string[] { "Id", "BuildingId" } });
            List.Add(new UpgradeObject() { TableName = "Calendar", UpdateColumns = new string[] { "Id", "SpId" } });
            List.Add(new UpgradeObject() { TableName = "CalendarItem", UpdateColumns = new string[] { "Id", "CalendarId" } });
            List.Add(new UpgradeObject() { TableName = "CarbonFactor", UpdateColumns = new string[] { "Id", "SpId" } });
            // List.Add(new UpgradeObject() { TableName = "CarbonFactorConfigChanged", UpdateColumns = new string[] { "Id" } });
            List.Add(new UpgradeObject() { TableName = "CarbonFactorItem", UpdateColumns = new string[] { "Id", "CarbonFactorId" } });
            List.Add(new UpgradeObject() { TableName = "CostCommodity", UpdateColumns = new string[] { "Id", "CostId" } });
            List.Add(new UpgradeObject() { TableName = "CostComplexItem", UpdateColumns = new string[] { "Id", "HourTagId", "ReactiveTagId", "RealTagId", "TouTariffId", "CostCommodityId" } });
            List.Add(new UpgradeObject() { TableName = "CostSimpleItem", UpdateColumns = new string[] { "Id", "CostCommodityId" } });
            List.Add(new UpgradeObject() { TableName = "CostStartTime", UpdateColumns = new string[] { "Id", "HierarchyId", "AreaDimensionId", "SystemDimensionTemplateItemId" } });
            List.Add(new UpgradeObject() { TableName = "Customer", UpdateColumns = new string[] { "HierarchyId", "SpId" } });
            List.Add(new UpgradeObject() { TableName = "CustomerEnergyInfo", UpdateColumns = new string[] { "CustomerId", "EnergyInfoId" } });
            List.Add(new UpgradeObject() { TableName = "CustomerLabelling", UpdateColumns = new string[] { "Id", "CustomerId" } });
            List.Add(new UpgradeObject() { TableName = "CustomerLabellingItem", UpdateColumns = new string[] { "Id", "LabellingId" } });
            List.Add(new UpgradeObject() { TableName = "Dashboard", UpdateColumns = new string[] { "Id", "CustomerId", "HierarchyId", "UserId" } });
            List.Add(new UpgradeObject() { TableName = "Edge", UpdateColumns = new string[] { "Id", "EntryEdgeId", "DirectEdgeId", "ExitEdgeId", "StartVertex", "EndVertex" } });
            List.Add(new UpgradeObject() { TableName = "Hierarchy", UpdateColumns = new string[] { "Id", "ParentId", "CustomerId" } });
            List.Add(new UpgradeObject() { TableName = "HierarchyAdvancedPropertyVersion", UpdateColumns = new string[] { "Id", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "HierarchyCalendar", UpdateColumns = new string[] { "Id", "PropertyVersionId", "CalendarId", "WorkTimeId" } });
            List.Add(new UpgradeObject() { TableName = "HierarchyCalendarReference", UpdateColumns = new string[] { "Id", "HierarchyId", "PropertyVersionId" } });
            List.Add(new UpgradeObject() { TableName = "Labeling", UpdateColumns = new string[] { "Id", "SpId" } });
            List.Add(new UpgradeObject() { TableName = "Logo", UpdateColumns = new string[] { "Id", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "PeakTariff", UpdateColumns = new string[] { "Id", "TouTariffId" } });
            List.Add(new UpgradeObject() { TableName = "PeakTariffTime", UpdateColumns = new string[] { "Id", "PeakTariffId" } });
            List.Add(new UpgradeObject() { TableName = "RawDataModify", UpdateColumns = new string[] { "Id", "CustomerId" } });
            List.Add(new UpgradeObject() { TableName = "RawDataModifyDetail", UpdateColumns = new string[] { "Id", "TagId", "ModifyId" } });
            List.Add(new UpgradeObject() { TableName = "ReceiveShareInfo", UpdateColumns = new string[] { "Id", "ReceiveUserId", "ReceiveDashboardId", "ReceiveWidgetId", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "Role", UpdateColumns = new string[] { "Id", "SpId" } });
            List.Add(new UpgradeObject() { TableName = "RolePrivilege", UpdateColumns = new string[] { "Id", "RoleId" } });
            List.Add(new UpgradeObject() { TableName = "SendShareInfo", UpdateColumns = new string[] { "Id", "SendUserId", "HierarchyId", "SendDashboardId", "SendWidgetId" } });
            //  List.Add(new UpgradeObject() { TableName = "SPConfigChanged", UpdateColumns = new string[] { "Id" } });
            List.Add(new UpgradeObject() { TableName = "SystemDimension", UpdateColumns = new string[] { "Id", "TemplateItemId", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "SystemDimensionTemplate", UpdateColumns = new string[] { "Id", "CustomerId" } });
            List.Add(new UpgradeObject() { TableName = "SystemDimensionTemplateItem", UpdateColumns = new string[] { "Id", "ParentId", "TemplateId" } });
            List.Add(new UpgradeObject() { TableName = "Tag", UpdateColumns = new string[] { "Id", "CustomerId", "SystemDimensionId", "AreaDimensionId", "HierarchyId", "Formula", "FormulaRpn" } });
            // List.Add(new UpgradeObject() { TableName = "TagConfigChanged", UpdateColumns = new string[] { "Id", "SystemDimensionId", "AreaDimensionId", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "TagDirectRefer", UpdateColumns = new string[] { "StartId", "EndId" } });
            List.Add(new UpgradeObject() { TableName = "TagImportHistory", UpdateColumns = new string[] { "Id", "CustomerId" } });
            // List.Add(new UpgradeObject() { TableName = "TagRawDataChanged", UpdateColumns = new string[] { "Id", "CustomerId", "TagId" } });
            List.Add(new UpgradeObject() { TableName = "TargetBaseline", UpdateColumns = new string[] { "Id", "TagId" } });
            // List.Add(new UpgradeObject() { TableName = "TargetBaselineDataChanged", UpdateColumns = new string[] { "Id", "CustomerId", "TagId" } });
            List.Add(new UpgradeObject() { TableName = "TargetBaselineDataVersion", UpdateColumns = new string[] { "Id", "TargetBaselineId" } });
            List.Add(new UpgradeObject() { TableName = "TargetBaselineNormalDate", UpdateColumns = new string[] { "Id", "TargetBaselineId" } });
            List.Add(new UpgradeObject() { TableName = "TargetBaselineSpecialDate", UpdateColumns = new string[] { "Id", "TargetBaselineId" } });
            //  List.Add(new UpgradeObject() { TableName = "TBConfigChanged", UpdateColumns = new string[] { "Id", "TBId", "SystemDimensionId", "AreaDimensionId", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "TouTariff", UpdateColumns = new string[] { "Id", "SpId" } });
            List.Add(new UpgradeObject() { TableName = "TouTariffItem", UpdateColumns = new string[] { "Id", "TouTariffId" } });
            List.Add(new UpgradeObject() { TableName = "User", UpdateColumns = new string[] { "Id", "SpId" } });
            List.Add(new UpgradeObject() { TableName = "UserCustomer", UpdateColumns = new string[] { "UserId", "HierarchyId" } });
            List.Add(new UpgradeObject() { TableName = "UserDataPrivilege", UpdateColumns = new string[] { "Id", "UserId", "PrivilegeItemId" } });
            List.Add(new UpgradeObject() { TableName = "UserRole", UpdateColumns = new string[] { "RoleId", "UserId" } });
            List.Add(new UpgradeObject() { TableName = "VEEAnomalyRecord", UpdateColumns = new string[] { "Id", "TagId", "RuleId", "RuleDescription", "TagDescription" } });
            List.Add(new UpgradeObject() { TableName = "VEEReceiver", UpdateColumns = new string[] { "RuleId", "UserId" } });
            List.Add(new UpgradeObject() { TableName = "VEERule", UpdateColumns = new string[] { "Id", "CustomerId" } });
            List.Add(new UpgradeObject() { TableName = "VEETag", UpdateColumns = new string[] { "RuleId", "TagId" } });
            // List.Add(new UpgradeObject() { TableName = "VEETask", UpdateColumns = new string[] { "Id", "RuleId", "RuleDescription", "TagIds", "UserIds" } });
            List.Add(new UpgradeObject() { TableName = "Widget", UpdateColumns = new string[] { "Id", "DashboardId", "ContentSyntax" } });
            List.Add(new UpgradeObject() { TableName = "WidgetCollaborative", UpdateColumns = new string[] { "Id", "SourceWidgetId", "ContentSyntax", "CustomerId", "SponsorId" } });
            List.Add(new UpgradeObject() { TableName = "WidgetCollaborativeComment", UpdateColumns = new string[] { "Id", "CollaborativeId" } });
            List.Add(new UpgradeObject() { TableName = "WidgetCollaborativeUser", UpdateColumns = new string[] { "CollaborativeId", "UserId" } });


        }
    }
}
