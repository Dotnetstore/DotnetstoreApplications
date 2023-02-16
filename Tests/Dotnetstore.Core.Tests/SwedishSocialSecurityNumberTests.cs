using Dotnetstore.Core.Structs;
using static NUnit.Framework.Assert;

namespace Dotnetstore.Core.Tests
{
    public class SwedishSocialSecurityNumberTests
    {
        [TestCase("7102240475", "7102240475")]
        [TestCase("197102240475", "7102240475")]
        [TestCase("19710224-0475", "7102240475")]
        [TestCase("710224-0475", "7102240475")]
        public void TestSwedishSocialSecurityNumberAsUnformatted(string number, string expectedNumber)
        {
            That(new SwedishSocialSecurityNumber(number).Number, Is.EqualTo(expectedNumber));
        }

        [TestCase("710224-0475", "7102240475")]
        [TestCase("710224+0475", "7102240475")]
        [TestCase("19710224-0475", "7102240475")]
        [TestCase("19710224+0475", "7102240475")]
        public void FiltersAndRemovesPlusAndMinusCharactersCorrectly(string number, string expectedNumber)
        {
            That(new SwedishSocialSecurityNumber(number).Number, Is.EqualTo(expectedNumber));
        }

        [TestCase("710224-0475", true)]
        [TestCase("710224+0475", true)]
        [TestCase("71022404-75", false)]
        [TestCase("71022404+75", false)]
        [TestCase("710-224-0475", false)]
        [TestCase("710224+04+75", false)]
        public void PlusAndMinusCharactersOnlyAllowedInCertainPositions(string number, bool isValid)
        {
            That(new SwedishSocialSecurityNumber(number).IsValid, Is.EqualTo(isValid));
        }

        [TestCase("551213-7986", true)]
        [TestCase("710224-0475", false)]
        [TestCase("19710224-0475", false)]
        public void MaleAndFemale_CorrectlyIdentified(string number, bool isFemale)
        {
            Multiple(() =>
            {
                That(new SwedishSocialSecurityNumber(number).IsFemale, Is.EqualTo(isFemale));
                That(new SwedishSocialSecurityNumber(number).IsMale, Is.Not.EqualTo(isFemale));
            });
        }

        [TestCase("460126")]
        public void ToString_EqualsNormalizedNumber(string number)
        {
            That(new SwedishSocialSecurityNumber(number).ToString(), Is.EqualTo(new SwedishSocialSecurityNumber(number).Number));
        }

        [TestCase("800212", "19800212")]
        [TestCase("800212", "800212")]
        [TestCase("8002121234", "19800212-1234")]
        public void TwoNumbers_ConsideredEqual_IfNormalizedNumbersAreEqual(string number, string expected)
        {
            That(new SwedishSocialSecurityNumber(number), Is.EqualTo(new SwedishSocialSecurityNumber(expected)));
        }

        [TestCase("800212", "19800212")]
        [TestCase("800212", "800212")]
        [TestCase("8002121234", "19800212-1234")]
        public void EqualsOperatorOverloaded_AsEquals(string number, string numberToCompare)
        {
            That(new SwedishSocialSecurityNumber(number) == new SwedishSocialSecurityNumber(numberToCompare), Is.True);
        }

        [TestCase("800213", false)]
        [TestCase("800213-0123", false)]
        [TestCase("800213+0123", true)]
        public void IsPlus100YearsOld(string number, bool isOver100YearsOld)
        {
            That(new SwedishSocialSecurityNumber(number).IsPlus100YearsOld, Is.EqualTo(isOver100YearsOld));
        }
    }
}