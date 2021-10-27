using System;
using System.Collections.Generic;
using GameApi.AlgoritmService;
using GameApi.Exceptions;
using GameApi.ValidateService;
using GameApi.ValueInputService;
using NUnit.Framework;

namespace GameApiTest
{
    public class ValueInputTest
    {
        private IValueInputService _valueInputService;

        [SetUp]
        public void Setup()
        {
            _valueInputService = new ValueInputService();
        }

        [Test, Order(1)]
        public void Check_Correct_Value_Throws_Exception()
        {
            Assert.Throws<IncorrectValueException>(() => _valueInputService.Validate(12));
        }

        [Test, Order(2)]
        public void Check_Correct_Value_Throws_Format_Exception()
        {
            Assert.Throws<FormatException>(() => _valueInputService.Validate(Convert.ToInt32("1.4")));
            Assert.Throws<FormatException>(() => _valueInputService.Validate(Convert.ToInt32("value")));
            Assert.Throws<FormatException>(() => _valueInputService.Validate(Convert.ToInt32("2/5")));
        }

        [Test, Order(3)]
        public void Check_Correct_Value_Return_Success()
        {
            var expectedFoo = "Foo";
            var expectedBar = "Bar";
            var expectedFooBar = "Foo Bar";

            Assert.AreEqual(_valueInputService.Validate(3), expectedFoo);
            Assert.AreEqual(_valueInputService.Validate(15), expectedFooBar);
            Assert.AreEqual(_valueInputService.Validate(5), expectedBar);
            Assert.AreEqual(_valueInputService.Validate(30), expectedFooBar);
        }
    }
}