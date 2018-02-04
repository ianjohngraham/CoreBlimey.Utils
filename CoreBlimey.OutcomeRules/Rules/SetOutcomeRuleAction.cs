using System;
using Sitecore.Analytics;
using Sitecore.Analytics.Outcome;
using Sitecore.Analytics.Outcome.Extensions;
using Sitecore.Analytics.Outcome.Model;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Actions;

namespace CoreBlimey.OutcomeRules.Rules
{
    public class SetOutcomeRuleAction<T> : RuleAction<T> where T : RuleContext
    {
        public decimal MonetaryValue { get; set; }

        public override void Apply(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");

            var outomeDefinitionItem = (Item)ruleContext.Parameters["DefinitionItem"];

            SetOutcome(outomeDefinitionItem);
        }

        private void SetOutcome(Item definitonItem)
        {
            if (Tracker.Current == null)
                return;

            var id = ID.NewID;
            var interactionId = ID.Parse(Tracker.Current.Interaction.InteractionId);
            var contactId = ID.Parse(Tracker.Current.Contact.ContactId);
            var definitionItem = definitonItem;

            if(Tracker.Current.HasOutcome(definitionItem.ID))
                return;

            var outcome = new ContactOutcome(id,definitionItem.ID,contactId)
            {
                DateTime = DateTime.UtcNow.Date,
                MonetaryValue = MonetaryValue,
                InteractionId = interactionId
            };

            Tracker.Current.RegisterContactOutcome(outcome);
        }
    }
}
