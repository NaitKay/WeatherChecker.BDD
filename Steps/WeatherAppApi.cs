using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;
using FluentAssertions;
using WeatherChecker.BDD.ApiHelper;
using RestSharp;
using System.Net;
using RestSharp.Serialization.Json;

namespace WeatherChecker.BDD.StepDefinitions
{
    [Binding]
    public class WeatherAppApi 
    {
        private readonly ApiCaller apiCaller;
        private readonly string validPostcodeRequest = @"{""address"": ""W6 0NW""}";
        private readonly string nonExistingValidPostcodeRequest = @"{""address"": ""B99 9AA""}";
        private readonly string invalidPostcodeRequest = @"{""address"": ""EC1A 1BB""}";
        private IRestResponse actualResponse;

        private readonly string addressNotFoundError = "Problem with Geocode API: Unable to find that address.";
        private readonly string invalidAddressError = "Invalid Address";

        public WeatherAppApi(IWebDriver driver)
        {
            apiCaller = new ApiCaller();
            
        }

        [When(@"Weather App API is called with valid postcode")]
        public void WhenWeatherAppAPIIsCalledWithValidPostcode()
        {
            actualResponse = apiCaller.CallPOST(validPostcodeRequest);
        }

        [Then(@"(.*) response returned with Time, Temperature and humidity")]
        public void ThenResponseReturnedWithCorrectDateFormat(int responseStatus)
        {
            actualResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            WeatherAppResponse weatherAppResponse = new JsonDeserializer().Deserialize<WeatherAppResponse>(actualResponse);
            weatherAppResponse.currently.time.Should().NotBe(null);
            weatherAppResponse.currently.temperature.Should().NotBe(null);
            weatherAppResponse.currently.humidity.Should().NotBe(null);
        }

        [When(@"Weather App API is called with postcode (.*)")]
        public void WhenWeatherAppAPIIsCalledWithPostcode(string postcode)
        {
            string request = @"{""address"": ""+ postcode +""}";
            apiCaller.CallPOST(request);

        }

        [When(@"Weather App API is called with non-existing valid postcode")]
        public void WhenWeatherAppAPIIsCalledWithNon_ExistingValidPostcode()
        {
            actualResponse = apiCaller.CallPOST(nonExistingValidPostcodeRequest);
        }

        [When(@"Weather App API is called with invalid postcode")]
        public void WhenWeatherAppAPIIsCalledWithInvalidPostcode()
        {
            actualResponse = apiCaller.CallPOST(invalidPostcodeRequest);
        }

        [Then(@"address not found error returned")]
        public void ThenAddressNotFoundErrorReturned()
        {
            actualResponse.StatusCode.Should().NotBe(HttpStatusCode.OK);
            Error error = new JsonDeserializer().Deserialize<Error>(actualResponse);
            error.errorMessage.Should().Equals(addressNotFoundError);

        }

        [Then(@"invalid address error returned")]
        public void ThenInvalidAddressErrorReturned()
        {
            actualResponse.StatusCode.Should().NotBe(HttpStatusCode.OK);
            Error error = new JsonDeserializer().Deserialize<Error>(actualResponse);
            error.errorMessage.Should().Equals(invalidAddressError);
        }

        [Then(@"(.*) response should returned")]
        public void ThenShouldReturned(int status)
        {
            actualResponse.StatusCode.Should().Be(status);
        }



    }
}