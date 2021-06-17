**Solution - What is it?**

* The solution provides intellegent automation framework to test UI and API scenarios.
* It provides a single platform to run UI Tests, API Tests and Integration tests which verifies UI behaviour against API responses.
* Test scenarios are written using gherkin language which supports BDD/TDD.
* This framework is built on Specflow, which uses C# as a scripting language.
* Visual Studio is used as IDE,  it provides support to run spec flowflow tests easily.
* Azure Devops is the preferred tool to run test suites in pipeline as dedicated or dev-integrated pipeline. However, this can also be easily implemented in tools like Jenkins and TeamCity


**How tests are coded?**

* Features - 3 features are written inside feature folder.
   1) SearchPostcode :  this covers UI test scenarios.
   2) WeatherAppAPI : this covers API test scenarios.
   3) WeatherAppIntegration : this covers integration test scenarios, in which - first we call API and then check the API response parameters against the weather      details displayed on UI.
* Steps : this folder stores the classes which defines the steps in the feature files.
* PagesObjects: the framework implements page object model, and all page classes are stored in this folder.
* APIHelper: all API related classes are stored in this folder.
* Factories: this has driver factory classes which defines the selection and initialisation of browser drivers.
* Support: this folder should be a collection of config related classes like hooks, which defines actions called before and after test or scenarios.
* TestResults: all html test results are saved in this folder.

 
**Instruction - how to execute tests**

* Tool required: you only need to install visual studio 2019, you can find the latest version for Mac [here ](https://visualstudio.microsoft.com/vs/mac/) . Then install ‘Specflow for visual studio 2019’ extension. 
* Clone the git repo from [here](https://github.com/NaitKay/WeatherChecker.BDD)
* Open WeatherCheck.BDD.sln file in VS2019 as a new solution.
* Build the solution - it should be successful.
* Open test explorer - here you can see all test scenarios. Right click on the test or suite you want to execute and select run.
