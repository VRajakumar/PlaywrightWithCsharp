using System;
	using Reqnroll;
	
	namespace MyNamespace
	{
		[Binding]
		public class StepDefinitions
		{
			private readonly ScenarioContext _scenarioContext;
	
			public StepDefinitions(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}
			
		}
	}