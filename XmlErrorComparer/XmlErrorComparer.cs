using System.Xml.Linq;

namespace XmlErrorComparer
{
    public static class XmlErrorComparer
    {
        public static bool IsCurrentRunHavingLessErrors(string currentInputDataAsString, string existingInputDataAsString)
        {
            var currentErrorsCount = GetErrorsCount(currentInputDataAsString);
            var existingErrorsCount = GetErrorsCount(existingInputDataAsString);

            return currentErrorsCount < existingErrorsCount;
        }

        private static int GetErrorsCount(string currentInputDataAsString)
        {
            var document = XDocument.Parse(currentInputDataAsString);
            var root = document.Root;

            return root == null ? 0 : CountErrors(root);
        }

        private static int CountErrors(XElement node)
        {
            var hasError = node.Attribute("ErrorSource")?.Value == "Error";
            if (hasError)
                return node.HasElements ? node.Descendants("SubScenario").Count() : 1;

            return node.Elements().Select(CountErrors).Sum();
        }
    }
}