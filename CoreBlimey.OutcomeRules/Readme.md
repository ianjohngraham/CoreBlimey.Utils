# Outcome Rules Runner

Due to the fact that currently Sitecore Outcomes are not able to be triggered in the Sitecore editor, I have created a custom Sitecore Rule Action to trigger an Outcome under specific conditions using the Sitecore Rules Engine.

The project also contains a pippline processer to evaluate and run the rules.

* The pipeline processor appends to the InitializeTracker pipeline and is placed just after the following pipeline processor:

   Sitecore.Analytics.Pipelines.InitializeTracker.RunRules

* This project was compiled using binaries from Sitecore 8 Update-2

* The Sitecore items for the solution can be found under the packages directory

