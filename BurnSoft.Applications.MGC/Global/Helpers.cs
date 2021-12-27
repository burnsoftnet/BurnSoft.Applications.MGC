using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
// ReSharper disable CompareOfFloatsByEqualityOperator

// ReSharper disable TooWideLocalVariableScope
// ReSharper disable UseNameofExpression
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

// ReSharper disable UnusedMember.Local

namespace BurnSoft.Applications.MGC.Global
{
    /// <summary>
    /// Class Helpers.
    /// </summary>
    public class Helpers
    {

        #region "Exception Error Handling"        
        /// <summary>
        /// The class location
        /// </summary>
        private static string _classLocation = "BurnSoft.Applications.MGC.Global.Helpers";
        /// <summary>
        /// Errors the message for regular Exceptions
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, Exception e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for access violations
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, AccessViolationException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for invalid cast exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, InvalidCastException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message argument exception
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentException e) => $"{_classLocation}.{functionName} - {e.Message}";
        /// <summary>
        /// Errors the message for argument null exception.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        private static string ErrorMessage(string functionName, ArgumentNullException e) => $"{_classLocation}.{functionName} - {e.Message}";
        #endregion
        //End Snippet
        /// <summary>
        /// Convert an Object to a Byte Array
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// Formats from XML.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string FormatFromXml(string value)
        {
            string sAns = value.Replace("&amp;", "&");
            sAns = sAns.Replace("'", "''");
            return sAns;
        }
        /// <summary>
        /// Sets the type of the catalog to insert into the database.
        /// </summary>
        /// <param name="useNumberOnlyCatalog">if set to <c>true</c> [use number only catalog].</param>
        /// <param name="value">The value.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.String.</returns>
        public static string SetCatalogInsType(bool useNumberOnlyCatalog, string value, out string errOut)
        {
            string sAns = value;
            errOut = @"";
            try
            {
                if (!useNumberOnlyCatalog) sAns = $"'{value}'";
            }
            catch (Exception e)
            {
                errOut = ErrorMessage("SetCatalogInsType",e);
            }
            return sAns;
        }
        /// <summary>
        /// Determines whether the specified text is numeric.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is numeric; otherwise, <c>false</c>.</returns>
        public static bool IsNumeric(string text) => double.TryParse(text, out _);
        /// <summary>
        /// Mids the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="index">The index.</param>
        /// <param name="newChar">The new character.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentNullException">input</exception>
        public static string Mid(string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            chars[index - 1] = newChar;
            return new string(chars);
        }
        /// <summary>
        /// Mids the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>System.String.</returns>
        public static string Mid(string s, int a, int b)
        {
            string temp = s.Substring(a - 1, b);
            return temp;
        }
        /// <summary>
        /// Converts the text to number.
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns>System.Double.</returns>
        public static double ConvertTextToNumber(string strValue, out string errOut)
        {
            double dAns = 0;
            errOut = "";
            try
            {
                int intChar = strValue.Length;
                int i;
                string curValue;
                string newValue = "";
                string lastValue = "";
                bool needDiv = false;
                for (i = 1; i <= intChar; i++)
                {
                    curValue = Mid(strValue, i, 1);
                    if (curValue == " ")
                        break;
                    if (IsNumeric(curValue))
                    {
                        if (lastValue.Length != 0)
                            lastValue = Mid(newValue, newValue.Length, 1);
                        else
                            lastValue = curValue;
                        if (!needDiv)
                            newValue += curValue;
                        else
                            newValue =$"{Convert.ToDouble(curValue) / Convert.ToDouble(lastValue)}";
                        needDiv = false;
                    }
                    else
                        switch (curValue)
                        {
                            case ".":
                            {
                                newValue += curValue;
                                needDiv = false;
                                break;
                            }

                            case "/":
                            {
                                needDiv = true;
                                break;
                            }
                        }
                }
                dAns = Convert.ToDouble(newValue);
            }
            catch (Exception ex)
            {
                errOut = ErrorMessage("ConvertTextToNumber", ex);
            }
            return dAns;
        }
        /// <summary>
        /// Determines whether the specified string value is required.
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <param name="strField">The string field.</param>
        /// <param name="strTitle">The string title.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if the specified string value is required; otherwise, <c>false</c>.</returns>
        public bool IsRequired(string strValue, string strField, string strTitle, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                bAns = (strValue.Trim().Length > 0);
                if (!bAns)
                    MessageBox.Show($"Please put in a value for {strField}", strTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                errOut = ErrorMessage("IsRequired", ex);
            }
            return bAns;
        }
        /// <summary>
        /// Determines whether the specified l value is required.
        /// </summary>
        /// <param name="lValue">The l value.</param>
        /// <param name="lDefault">The l default.</param>
        /// <param name="strField">The string field.</param>
        /// <param name="strTitle">The string title.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if the specified l value is required; otherwise, <c>false</c>.</returns>
        public bool IsRequired(long lValue, long lDefault, string strField, string strTitle, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                bAns = lValue != lDefault;
                if (!bAns)
                    MessageBox.Show($"Please put in a value for {strField}", strTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                errOut = ErrorMessage("IsRequired", ex);
            }
            return bAns;
        }
        /// <summary>
        /// Determines whether the specified l value is required.
        /// </summary>
        /// <param name="lValue">The l value.</param>
        /// <param name="lDefault">The l default.</param>
        /// <param name="strField">The string field.</param>
        /// <param name="strTitle">The string title.</param>
        /// <param name="errOut">The error out.</param>
        /// <returns><c>true</c> if the specified l value is required; otherwise, <c>false</c>.</returns>
        public bool IsRequired(double lValue, double lDefault, string strField, string strTitle, out string errOut)
        {
            bool bAns = false;
            errOut = "";
            try
            {
                bAns = lValue != lDefault;
                if (!bAns)
                    MessageBox.Show($"Please put in a value for {strField}", strTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                errOut = ErrorMessage("IsRequired", ex);
            }
            return bAns;
        }

    }
}
