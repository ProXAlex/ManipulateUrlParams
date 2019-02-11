using NUnit.Framework;


namespace ManipulateUrlParams
{

    public class Tests
    {



        [TestCase("www.example.com", "key=value", ExpectedResult = "www.example.com?key=value")]
        [TestCase("www.example.com?key=value", "key2=value2", ExpectedResult = "www.example.com?key=value&key2=value2")]
        [TestCase("www.example.com?key=oldValue", "key=newValue", ExpectedResult = "www.example.com?key=newValue")]

        [TestCase("www.example.com", "", ExpectedResult = "www.example.com")]
        [TestCase("www.example.com?key=value", "", ExpectedResult = "www.example.com?key=value")]

        [TestCase("www.example.com?key=value&key2=value2", "", ExpectedResult = "www.example.com?key=value&key2=value2")]
        [TestCase("www.example.com?key=value&key2=value2", "key3=value3&key4=value4", ExpectedResult = "www.example.com?key=value&key2=value2&key3=value3&key4=value4")]
        public string AddOrChangeUrlParameterTest(string url, string parameters) => ManipulateUrl.AddOrChangeUrlParameter(url, parameters);

    }
}