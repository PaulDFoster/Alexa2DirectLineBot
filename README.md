# DirectLineBot2Alexa
A sample that connects Microsoft Bot Framework to Alexa Skill via the Bot Framework Direct Line connector client.

Based on Stefan Negritoiu (FreeBusy) Alexaskills.net Speechlet project. See License file for details.

There is an alternative NodeJS Alexa Bridge published here (https://github.com/CatalystCode/alexa-bridge).
You will still need to use the custom slot approach documented here to prevent truncation of the received utterance.

Modified very simply with the Direct Line client for the Microsoft Bot Connector. You can now have an Alexa skill deliver its utterance to your Bot Framework bot.

There are serious limitations.
<li>The Alexa skill has a limited word count it can receive
<li>It appears that Alexa's speech recognition ability is reduced without a focused vocabulary. Your mileage will vary.
<li>Alexa session is closed after each interaction. Retaining the session is to be tested.
<li>This isn't an Amazon recognised technique. I have shared my approach with Amazon and hope they will support it. Collaboration is the way forward to a better world :-)

<b>Build your bot with Microsoft Bot Framework</b>.
 
 (https://docs.microsoft.com/en-us/bot-framework/bot-builder-overview-getstarted)

Publish your bot (https://docs.microsoft.com/en-us/bot-framework/portal-register-bot) and enable a Direct Line channel via the Bot Connector (https://docs.microsoft.com/en-us/bot-framework/channel-connect-directline).

<b>Alexa Skill definition</b>

 A generic Alexa skill definition is published via the Amazon developer Alexa Skills site (http://developer.Amazon.com).

 <h3>Interaction Model</h3>

 Intent Schema
 ```
 {
  "intents": [
    {
      "slots": [
        {
          "name": "phrase",
          "type": "phrase"
        }
      ],
      "intent": "GetUserIntent"
    }
  ]
}
```
<h3>Custom Slot Type: phrase </h3>

```
blah
blah blah
blah blah blah
blah blah blah blah
blah blah blah blah blah
blah blah blah blah blah blah
blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah
blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah
```
Note: an utterance is required for the utterance word count you expect to receive. If you receive a truncated GetUserIntent utterance from the skill you need to increase entries here. Above delivers 1 to 20 words utterance output.

<h3>Sample Utterances</h3>

```
GetUserIntent {phrase}
```

<h3>Endpoint configuration.</h3>

Service Endpoint type:

```
https
```
Default:

```
https://yourwebappapi.azurewebsites.net/
```

<b>Azure web app service Alexa Skill Kit .Net implementation.</b>

Clone this repro to build your basic ASP.net web api service.

Edit SampleSessionSpeechlet.cs to change the values for the direct line details to your bot.

```
        private static string directLineSecret = "<your secret here>";
        private static string botId = "<your bot text id here>";
```
Edit OnRequestValidation to test for your Alexa Skill application id.

```
            if (requestEnvelope?.Session?.Application?.Id?.Equals("<your Alexa skill application id") == false)
```
Now edit your OnIntent method to deliver the Alexa card format you want.

<b>Testing</b>

Once the web api service is published you can test your Alexa skill from the test page of your Alexa skill definition Service Simulator.

<b>To Do:</b>

<li>Implement Bot Framework hero cards into Alexa Skill cards
