xDB Contact Creator

This is a quick and dirty Web Form to submimt data to the MongoDB database when using xDB.

To compile, just add references to Sitecore.Analytics and Sitecore.Analytics.Model.

When ending the session, the data might not be fully complete in MongoDB - To force MongoDB to populate the data, create another contact or call the Identify() method again in the API