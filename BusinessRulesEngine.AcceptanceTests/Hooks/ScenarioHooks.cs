using TechTalk.SpecFlow;

namespace BusinessRulesEngine.AcceptanceTests.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            UI.Program.ClearEvents();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            UI.Program.ClearEvents();
        }
    }
}