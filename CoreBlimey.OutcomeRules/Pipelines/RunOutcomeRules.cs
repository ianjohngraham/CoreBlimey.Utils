﻿using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Analytics.Pipelines.InitializeTracker;

namespace CoreBlimey.OutcomeRules.Pipelines
{
    public class RunOutcomeRules :  InitializeTrackerProcessor
    {
        public string OutcomeRootItemId { get; set; }
        public string OutcomeDefinitionId { get; set; }
        private const string RulesField = "Rules";

        public override void Process(InitializeTrackerArgs args)
        {
            if (Context.Database == null
                || Context.Item == null
                || Context.PageMode.IsExperienceEditorEditing
                || String.Compare(Context.Database.Name, "core", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return;
            }

            if(Context.Item.Paths.IsContentItem)
                 ProcessOutcomeRules();
        }

        private void ProcessOutcomeRules()
        {
            var outcomes = GetOutcomeItems();
            foreach(var outcome in outcomes)
            {
                RunRule(outcome);
            }
        }

        private IEnumerable<Item> GetOutcomeItems()
        {
            var outcomeRootItem = Sitecore.Context.Database.GetItem(ID.Parse(OutcomeRootItemId));
            if(outcomeRootItem != null)
              return outcomeRootItem.Axes.GetDescendants().Where(c => c.TemplateID.Equals(ID.Parse(OutcomeDefinitionId)) && !string.IsNullOrEmpty(c[RulesField])).ToList();

            return new List<Item>();
        }

        public bool RunRule(Item outcomeItem)
        {
            if (outcomeItem == null)
                return false;

            var ruleXml = outcomeItem[RulesField];

            if (String.IsNullOrEmpty(ruleXml))
                return false;

            var rules = new RuleList<RuleContext> { Name = outcomeItem.Paths.Path };
            var parsed = RuleFactory.ParseRules<RuleContext>(
                Context.Database,
                ruleXml);
            rules.AddRange(parsed.Rules);

            if (rules.Count < 1)
                return false;

            var ruleContext = new RuleContext { Item = Context.Item };
            ruleContext.Parameters.Add("DefinitionItem",outcomeItem);
            
            rules.Run(ruleContext);
            return ruleContext.IsAborted;
        }  
    }
}
